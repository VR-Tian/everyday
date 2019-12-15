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
        /// 订阅服务的委托类型
        /// </summary>
        /// <param name="sender"></param>
        public delegate void HWMSServerAction(object sender, string message);
        /// <summary>
        /// 响应消息处理的服务事件
        /// </summary>
        private static event HWMSServerAction HWMSRespondServerEvent;

        ICalculatorDuplexCallback callback = null;
        /// <summary>
        /// 当前的委托对象
        /// </summary>
        HWMSServerAction serviceEventHander = null;

        private static int num = 1;
        private static System.Timers.Timer timer;
        private string tempStr = "WCF已开启";


        public HWMSService()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer(2000);
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
        }


        /// <summary>
        /// 伪装数据源触发发布角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (callback != null)
            {
                //TODO：推送数据到MQ队列的转发程序(WCF的发布程序)
            }
        }

        public void Upload(string msg)
        {
            //TODO：应用层处理MQ消息
            Thread.Sleep(10);
            num = num == int.MaxValue ? num = 0 : num++;
            HWMSRespondServerEvent?.Invoke(this, num + "_消息:处理成功；" + DateTime.Now.ToString());
        }

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            this.serviceEventHander = new HWMSServerAction(OnSendMsgHandler);
            HWMSRespondServerEvent += serviceEventHander;
        }

        public void Unsubscribe()
        {
            HWMSRespondServerEvent -= serviceEventHander;
        }

        public void OnSendMsgHandler(object sender, string message)
        {
            callback.SendMsgToClient(message);
        }
    }
}
