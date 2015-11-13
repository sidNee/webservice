using System.ServiceModel;

namespace Contracts
{
    [ServiceContract()] // ASPEKT... Klasse. ICalculator ist/wird Attribut davon
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        //Ja wir wissen, dass wir SRP verletzt haben, da wir Infrastruktur mit BusinessLogic vermischen
        //In der Praxis (ha,ha,ha) würden wir jetzte SOAP-Header erweitern
        //Und die Callback-Adresse aus dem SOAP-Header auslesen
        //Der geneigte Leser kann das als Übung nachvollziehen
        void Add(Arguments args,string callbackAddress); // DATAGRAM!... Result Add(Arguments args) --> Req/Res
    }
}