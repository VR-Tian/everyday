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

        public void SendMsgToClient(string serviceMessage)
        {
            Console.WriteLine("==============服务端开始推送消息" + DateTime.Now + "===============");
            Console.WriteLine(serviceMessage);
        }
    }
}
