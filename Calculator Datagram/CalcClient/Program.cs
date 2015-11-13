using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace CalcClient
{
    public interface ICalculatorChannel: ICalculator, IClientChannel { }
    class Program
    {
        static void Main(string[] args)
        {
            var Arguments = new Arguments();
            Arguments.Arg1 = 1;
            Arguments.Arg2 = 2;

            var host = StartCallbackHost();

            var binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            var address = new EndpointAddress("net.msmq://localhost/private/calculator");
            var factory = new ChannelFactory<ICalculatorChannel>(binding, address);

            var channel = factory.CreateChannel();

            Console.WriteLine("Client started");

            try
            {
                channel.Add(Arguments, "net.msmq://localhost/private/calculatorcallback");
                Console.Write("1+2 = ");
                channel.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //Recover
            }

            Console.ReadLine();
            host.Close();
        }

        private static ServiceHost StartCallbackHost()
        {
            var callbackBinding = new NetMsmqBinding(NetMsmqSecurityMode.None);

            var host = new ServiceHost(typeof(CalculatorCallback));
            //(Contract,Binding,Endpoint)
            host.AddServiceEndpoint(
                typeof (ICalculatorCallback),
                callbackBinding,
                "net.msmq://localhost/private/calculatorcallback");
            host.Open();
            return host;
        }
    }
}
