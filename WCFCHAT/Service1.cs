using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCHAT
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;


       
        public int Connect(string  name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                OperationContext = OperationContext.Current
            };
            nextId++;
            sendMessage(user.Name + "WELCOME",0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i=>i.ID== id);
            if (user != null)
            {
                users.Remove(user);
                sendMessage(user.Name + "GO OUT",0);

            }
        }

        public void sendMessage(string message,int id )
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                   answer+=":" + user.Name+ "  ";

                }
                answer += message;
                item.OperationContext.GetCallbackChannel<IServiceChatCallBack>().messageCallBack(answer);
            }
        }
    }
}
