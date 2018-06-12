using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFClient.ServiceReference1;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construct InstanceContext to handle messages on callback interface.  
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            // Create a client.  
            CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);

            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
            Console.WriteLine();

            // Call the AddTo service operation.  
            double value = 100.00D;
            client.AddTo(value);
            Console.WriteLine("add is called");
            Console.ReadLine();
        }
    }

    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Result(double result)
        {
            Console.WriteLine("Result({0})", result);
        }

        public void Equation(string equation)
        {
            Console.WriteLine("Equation({0}", equation);
        }
    }
}
