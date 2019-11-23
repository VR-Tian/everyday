using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Timers;

namespace AbountCORS.WCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“HWMSService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 HWMSService.svc 或 HWMSService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class HWMSService : ICalculatorDuplex
    {
        /// <summary>
        /// 订阅服务的委托
        /// </summary>
        /// <param name="sender"></param>
        public delegate void HWMSServerEventHandler(object sender,string message);
        /// <summary>
        /// 服务的事件
        /// </summary>
        private static event HWMSServerEventHandler HWMSServerEvent;

        ICalculatorDuplexCallback callback = null;
        HWMSServerEventHandler serviceEventHander = null;

        System.Timers.Timer timer;
        private string tempStr = "WCF已开启";
        static int num = 1;

        public HWMSService()
        {
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }


        /// <summary>
        /// 伪装数据源触发发布角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //TODO：推送消息到MQ转发程序
            //1如果在定时推送消息情况下，会存在消息数据堆积的问题，如何存储
            if (callback != null && !string.IsNullOrEmpty(tempStr))
            {
                tempStr = tempStr + "|" + DateTime.Now.ToString();
                Upload(tempStr);
            }
        }

        public void Upload(string msg)
        {
            //TODO：应用层处理MQ消息
            tempStr = msg;
            Thread.Sleep(10);
            num++;
            HWMSServerEvent(this, num + "_消息；" + DateTime.Now.ToString());
        }

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            this.serviceEventHander = new HWMSServerEventHandler(SendMsgHandler);
            HWMSServerEvent += serviceEventHander;
        }

        public void Unsubscribe()
        {
            HWMSServerEvent -= serviceEventHander;
        }

        public void SendMsgHandler(object sender,string message)
        {
            callback.SendMsgToClient(message);
        }
    }
}
