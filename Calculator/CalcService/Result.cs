using System.Runtime.Serialization;

namespace CalcService
{
    [DataContract]
    public class Result
    {

        // im Konstruktor kein WErt, obwohl eigentlich richtig!
        // ist gefährlich und doof

        [DataMember]
        public double Value { get; set; }
    }
}