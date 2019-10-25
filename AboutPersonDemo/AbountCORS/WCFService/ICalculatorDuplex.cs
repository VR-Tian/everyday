using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AbountCORS.WCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IHWMSService”。
    [ServiceContract(SessionMode = SessionMode.Required,
                 CallbackContract = typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        /// <summary>
        /// 上传消息
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Upload(string msg);

        /// <summary>
        /// 客户端上线
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void OnLine();

        /// <summary>
        /// 客户端下线
        /// </summary>
        //[OperationContract(IsOneWay = true)]
        //void OffLine(string hospName);

        //[OperationContract(IsOneWay = true)]
        //void Clear();
        //[OperationContract(IsOneWay = true)]
        //void AddTo(double n);
        //[OperationContract(IsOneWay = true)]
        //void SubtractFrom(double n);
        //[OperationContract(IsOneWay = true)]
        //void MultiplyBy(double n);
        //[OperationContract(IsOneWay = true)]
        //void DivideBy(double n);
    }
}
