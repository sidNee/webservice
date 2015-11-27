using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.WindowsAzure.Storage.Table;

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

    public class CalcJobSerializer
    {
        public static string Serialize(CalcJob job)
        {
            return string.Format("{0},{1},{2}", job.Id,
                XmlConvert.ToString(job.Value1),
                XmlConvert.ToString(job.Value2));
        }

        public CalcJob Deserialize(string asString)
        {
            var parts = asString.Split(',');
            return new CalcJob
            {
                Id = Guid.Parse(parts[0]),
                Value1 = XmlConvert.ToDouble(parts[1]),
                Value2 = XmlConvert.ToDouble(parts[2])
            };
        }
    }

    public class JobResult : TableEntity
    {
        public JobResult(CalcJob job, double result):base("x",job.Id.ToString())
        {
            Value1 = job.Value1;
            Value2 = job.Value2;
            Result = result;
        }

        public JobResult()
        {
            
        }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Result { get; set; }
    }
}
