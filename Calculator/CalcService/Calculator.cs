using System;

namespace CalcService
{
    public class Calculator : ICalculator
    {
        public Result Add(Arguments args)
        {
            Result result = new Result();
            result.Value = args.Arg1 + args.Arg2;
            return result;
        }
    }
}