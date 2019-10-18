using ConsoleApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WCFService
{
    public class MessageClient
    {
        /// <summary>
        /// 通信上下文
        /// </summary>
        private InstanceContext instanceContext;
        /// <summary>
        /// 消息上下文
        /// </summary>
        private CalculatorDuplexClient client;
        public MessageClient()
        {
            instanceContext = new InstanceContext(new CallbackHandler());
            client = new CalculatorDuplexClient(instanceContext);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            client.Upload(msg);
        }
    }
}
