using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CalcService
{
    // Service Contract muss in " Verweise" hinzugefügt werden! SC ist eine Klasse,kann man als Metadaten interpretieren
    // WEnn Calculator initialisiert wird, hängt das Attribut da dran. Man kann dadurch Metadaten für einen Typ definieren
    //Metadaten von ICalculator kann man nun untersuchen und bekommt dieses Attribut hinzu.
    [ServiceContract]
    public interface ICalculator
    {

        // ServiceContract ist die Dienstleistung...
        [OperationContract]
        Result Add(Arguments args);
    }
}
