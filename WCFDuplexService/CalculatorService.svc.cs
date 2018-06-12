using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFDuplexService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculatorDuplex
    {
        double result = 0.0D;
        string equation;

        public CalculatorService()
        {
            equation = result.ToString();
        }

        public void Clear()
        {
            Callback.Equation(equation + " = " + result.ToString());
            equation = result.ToString();
        }

        public void AddTo(double n)
        {
            result += n;
            equation += " + " + n.ToString();
            Callback.Result(result);
        }

        public void SubtractFrom(double n)
        {
            throw new NotImplementedException();
        }

        public void MultiplyBy(double n)
        {
            throw new NotImplementedException();
        }

        public void DivideBy(double n)
        {
            throw new NotImplementedException();
        }

        public string Test(double n)
        {
            result += n;
            equation += " + " + n.ToString();
            Callback.Result(result);
            return result.ToString();
        }

        ICalculatorDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            }
        }
    }
}
