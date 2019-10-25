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
        /// 服务消息上下文
        /// </summary>
        private CalculatorDuplexClient client;
        /// <summary>
        /// 服务器回调上下文
        /// </summary>
        private CallbackHandler callbackHandler;


        public MessageClient()
        {
            callbackHandler = new CallbackHandler();
            instanceContext = new InstanceContext(callbackHandler);
            client = new CalculatorDuplexClient(instanceContext);
            client.OnLine();
        }

        public MessageClient(Action<string> OnDowLoadMsgAction)
        {
            callbackHandler = new CallbackHandler(OnDowLoadMsgAction);
            instanceContext = new InstanceContext(callbackHandler);
            client = new CalculatorDuplexClient(instanceContext);
            client.OnLine();
        }

        /// <summary>
        /// 拉取消息
        /// </summary>
        public string DowLoadMsg()
        {
            string tempStr = string.Empty;
            callbackHandler.OnDownloadMsgReceived = (msg) =>
            {
                tempStr= msg;
            };
            return tempStr;
        }

        public void OffLine()
        {
            //client.OffLine("黄埔");
            instanceContext.Close();
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
