using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AbountCORS.WCFService
{
    /// <summary>
    /// 客户端回调接口
    /// </summary>
    public interface ICalculatorDuplexCallback
    {
        /// <summary>
        /// 回调发送
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendMsgToClient(string serviceMessage);
    }
}
