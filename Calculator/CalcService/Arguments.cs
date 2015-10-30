using System.Runtime.Serialization;

namespace CalcService
{
    // Daten in unterschiedlichen Kontexten. Datacontract

    // Hilft beim Separieren.
    // DataContract = Markierung und kümmert sich um die serialisierung.
    [DataContract]
    public class Arguments
    {
        [DataMember]
        public double Arg1 { get; set; }
        [DataMember]
        public double Arg2 { get; set; }
    }
}