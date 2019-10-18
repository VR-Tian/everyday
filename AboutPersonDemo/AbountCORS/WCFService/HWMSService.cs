using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace AbountCORS.WCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“HWMSService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 HWMSService.svc 或 HWMSService.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class HWMSService : ICalculatorDuplex
    {
        double result;
        string equation;
        ICalculatorDuplexCallback callback = null;
        Timer timer;
        public HWMSService()
        {
            result = 0.0D;
            equation = result.ToString();
            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            timer = new Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //TODO：推送消息到MQ转发程序
            //1服务器在定时推送消息情况下，会存在消息数据堆积，如何存储
            callback.SendMsg("服务器推送消息：" + "。" + DateTime.Now.ToString());
        }

        public void Upload(string msg)
        {
            //TODO：应用层处理MQ消息
            callback.ResultOfUpload("处理成功/r/n===================================");
        }
    }
}
