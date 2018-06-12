using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using WCFCoreApp.Models;

namespace WCFCoreApp.Controllers
{
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

    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Create a client.  
            CalculatorDuplexClient client = new CalculatorDuplexClient();
            // Call the AddTo service operation.  
            double value = 100.00D;
            object[] o = new object[1024];
            Exception exception = new Exception();
            bool isCancel = false;
            object final = new object();

            ServiceReference1.ResultReceivedEventArgs eventArgs = new ResultReceivedEventArgs(o, exception, isCancel, final);
            //await client.AddToAsync(value);
            string rr = await client.TestAsync(value);
            var result = eventArgs.result1;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
