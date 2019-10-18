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
        public void ResultOfUpload(string processMessage)
        {
            Console.WriteLine(processMessage);
        }

        public void SendMsg(string serviceMessage)
        {
            Console.WriteLine(serviceMessage);
        }
    }
}
