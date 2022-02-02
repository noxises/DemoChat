﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServiceChat;

namespace ChatClient
{

     
    public partial class MainWindow : Window , IService1Callback
    {
        bool isConnected = false;
        Service1Client client;
        int ID;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new Service1Client(new System.ServiceModel.InstanceContext(this));
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        void ConnectUser()
        {
            if (!isConnected)
            {
               ID =  client.Connect(tbuserName.Text);
                tbuserName.IsEnabled = false;   
                bConn.Content = "Disconnect";
                isConnected = true;
            }
        }
        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                tbuserName.IsEnabled = true;
                bConn.Content = "Connect";
                isConnected = false;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }

        public void messageCallBack(string message)
        {
           lbChat.Items.Add(message);
        }

    

        private void tbmessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(client != null)
                {
                    client.sendMessage(tbmessage.Text, ID);
                    tbmessage.Text = "";
                }
               
            }
        }
    }
}
