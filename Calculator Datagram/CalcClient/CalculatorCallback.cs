using System;
using Contracts;

namespace CalcClient
{
    public class CalculatorCallback:ICalculatorCallback
    {
        public void SetResult(Result result)
        {
            Console.WriteLine("Result: {0}",result.Value);
        }
    }
}