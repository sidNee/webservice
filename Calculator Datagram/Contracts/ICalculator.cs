using System.ServiceModel;

namespace Contracts
{
    [ServiceContract()] // ASPEKT... Klasse. ICalculator ist/wird Attribut davon
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(Arguments args); // DATAGRAM!... Result Add(Arguments args) --> Req/Res
    }
}