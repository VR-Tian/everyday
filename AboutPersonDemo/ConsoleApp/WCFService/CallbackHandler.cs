using ConsoleApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WCFService
{
    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public Action<string> OnDownloadMsgReceived;

        public CallbackHandler()
        {

        }
        public CallbackHandler(Action<string> executeDownloadDelegate)
        {
            this.OnDownloadMsgReceived = executeDownloadDelegate;
        }
        public virtual void ResultOfUpload(string processMessage)
        {
            Console.WriteLine(processMessage);
        }

        public virtual void SendMsg(string serviceMessage)
        {
            Console.WriteLine("==============服务端开始推送消息=================");
            //TODO：通过委托调用MQ发送函数
            OnDownloadMsgReceived?.Invoke(serviceMessage);
            Console.WriteLine(serviceMessage);
        }

        public void SendMsgToClient(string serviceMessage)
        {
            Console.WriteLine("==============服务端开始推送消息=================");
            Console.WriteLine(serviceMessage);
        }
    }
}
