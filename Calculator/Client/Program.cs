using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to call the service");
            Console.ReadLine();

            var client = new ServiceReference1.CalculatorClient();
            var arguments = new ServiceReference1.Arguments();
            arguments.Arg1 = 1;
            arguments.Arg2 = 2;

            var result = client.Add(arguments);

            Console.WriteLine("Result: "+ result.Value);
            Console.WriteLine("Press enter to close the application :)");
            Console.ReadLine();
        }
    }
}
