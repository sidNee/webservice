using System;
using System.Security.Principal;
using System.ServiceModel;

namespace CalcService
{
    public class Calculator : ICalculator
    {
        public Result Add(Arguments args)
        {
            var requestIndentity = ServiceSecurityContext.Current.WindowsIdentity;
            var threadIndentity  = WindowsIdentity.GetCurrent();
            //TODO Authorisierungsen

            var context= requestIndentity.Impersonate();

            var threadIndentity2 = WindowsIdentity.GetCurrent();
            //TODO Auf resourcen mit der request Indentity zugreifen

            Console.WriteLine("request:{0}, thread:{1}", requestIndentity.Name, threadIndentity.Name);
            Console.WriteLine("request:{0}, thread2:{1}", requestIndentity.Name, threadIndentity2.Name);

            //context.Undo();

            Result result = new Result();
            result.Value = args.Arg1 + args.Arg2;
            return result;
        }
    }
}