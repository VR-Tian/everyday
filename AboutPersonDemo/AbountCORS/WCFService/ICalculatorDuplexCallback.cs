using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AbountCORS.WCFService
{
    public interface ICalculatorDuplexCallback
    {

        /// <summary>
        /// 推送消息
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendMsg(string serviceMessage);



        /// <summary>
        /// 处理结果
        /// </summary>
        /// <param name="processmessage"></param>
        [OperationContract(IsOneWay = true)]
        void ResultOfUpload(string processMessage);


        //[OperationContract(IsOneWay = true)]
        //void Equals(double result);
        //[OperationContract(IsOneWay = true)]
        //void Equation(string eqn);

        //[OperationContract(IsOneWay = true)]
        //void SendTime(string eqn);
    }
}
