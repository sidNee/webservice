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

            var proxy = new ServiceReference1.CalculatorClient("BasicHttpEndpoint");
            proxy.ClientCredentials.UserName.UserName = "Simple";
            proxy.ClientCredentials.UserName.Password = "12345";


            var arguments = new ServiceReference1.Arguments();
            arguments.Arg1 = 1;
            arguments.Arg2 = 2;

            var result = proxy.Add(arguments);

            Console.WriteLine("Result: "+ result.Value);
            Console.WriteLine("Press enter to close the application :)");
            Console.ReadLine();
        }
    }
}
