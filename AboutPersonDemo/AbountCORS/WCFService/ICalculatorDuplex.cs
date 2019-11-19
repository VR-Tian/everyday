using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AbountCORS.WCFService
{
    /// <summary>
    /// 接口契约
    /// </summary>
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IHWMSService”。
    [ServiceContract(SessionMode = SessionMode.Required,
                 CallbackContract = typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        /// <summary>
        /// 上传消息（数据源）
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Upload(string msg);


        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();

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
