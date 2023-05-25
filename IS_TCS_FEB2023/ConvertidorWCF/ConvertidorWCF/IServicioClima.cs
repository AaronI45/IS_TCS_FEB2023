using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConvertidorWCF
{
    [ServiceContract]
    internal interface IServicioClima
    {
        [OperationContract]
        double farenheitACelcius(double gradosFarenheit);
        [OperationContract]
        double celsiusAFarenheit(double gradosCelcius);
    }
}
