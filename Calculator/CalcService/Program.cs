﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalcService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Calculator));
            host.Open();
            Console.WriteLine("Service started.");
            Console.ReadLine();
            host.Close();
        }
    }
}
