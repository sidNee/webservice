using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class CalcJob
    {
        //Header infrastructer
        public Guid Id { get; set; }

        //Body contract
        public double Value1 { get; set; }
        public double Value2 { get; set; }
    }
}
