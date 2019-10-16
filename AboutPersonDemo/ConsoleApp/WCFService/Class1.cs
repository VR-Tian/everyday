using ConsoleApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WCFService
{
    class Class1
    {
        private InstanceContext instanceContext;
        private CalculatorDuplexClient client;
        public Class1()
        {
            instanceContext = new InstanceContext(new CallbackHandler());

            // Create a client.
            client = new CalculatorDuplexClient(instanceContext);
        }
        public void TestService()
        {
           

            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
            Console.WriteLine();

            // Call the AddTo service operation.
            double value = 100.00D;
            client.AddTo(value);

            client.MultiplyBy(2);
            client.Clear();

            Console.ReadKey();
            Console.ReadLine();
            
            //Closing the client gracefully closes the connection and cleans up resources.
            client.Close();
        }
    }
}
