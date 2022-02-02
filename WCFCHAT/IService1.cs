using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCHAT
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServiceChatCallBack))]
    public interface IService1
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);


        [OperationContract(IsOneWay =true)]
        void sendMessage(string message,int id);

    }
    public interface IServiceChatCallBack
    {
        [OperationContract(IsOneWay = true   )]
        void messageCallBack(string message);
    }
}
