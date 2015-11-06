using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace CalcService
{
    public class Calculator : ICalculator
    {
        public void Add(Arguments args)
        {
            var result = new Result {Value = args.Arg1 + args.Arg2};
            // result wieder zurück schicken
            throw new NotImplementedException();
        }
    }
}
