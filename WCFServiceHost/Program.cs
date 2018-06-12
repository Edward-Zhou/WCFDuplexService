using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    ServiceHost host = new ServiceHost(typeof(WCFDuplexService.CalculatorService));
            //    host.Open();
            //    Console.WriteLine("ClinicalService Service Hosted Sucessfully");
            //}
            //catch (Exception ex)
            //{
            //    string[] arrStrings = new string[1];
            //    arrStrings[0] = ex.ToString();
            //    Console.WriteLine(ex.ToString());
            //}
            ServiceHost host = new ServiceHost(typeof(WCFDuplexService.CalculatorService));
            host.Open();
            Console.WriteLine("ClinicalService Service Hosted Sucessfully");

            Console.Read();

        }
    }
}
