using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace CalcService
{
    public interface ICalculatorCallbackChannel: ICalculatorCallback, IClientChannel { }

    public class Calculator : ICalculator
    {
        public void Add(Arguments args)
        {
            var result = new Result {Value = args.Arg1 + args.Arg2};

            var binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            var address = new EndpointAddress("net.msmq://localhost/private/calculatorcallback");
            var factory = new ChannelFactory<ICalculatorCallbackChannel>(binding,address);

            var channel = factory.CreateChannel();
            try
            {
                channel.SetResult(result);
                channel.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //Recover
            }

            //var clienChannel = (IClientChannel) channel;
            //clienChannel.Dispose();
            //!!!!!!Wird oben elegant gelöst mit dem Interface

        }
    }
}
