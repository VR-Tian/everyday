using ConsoleApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WCFService
{
    public class CallbackHandler: ICalculatorDuplexCallback
    {
        public void Result(double result)
        {
            Console.WriteLine("Result({0})", result);
        }

        public void Equation(string equation)
        {
            Console.WriteLine("Equation({0}", equation);
        }

        public void Equals(double result)
        {
            Console.WriteLine("Equation({0}", result);
        }

        public void SendTime(string eqn)
        {
            Console.WriteLine(eqn);
        }
    }
}
