﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class Arguments
    {
        [DataMember]
        public double Arg1 { get; set; }
        [DataMember]
        public double Arg2 { get; set; }
    }
}
