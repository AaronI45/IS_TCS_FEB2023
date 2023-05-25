using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConvertidorWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServicioDivisa : IServicioDivisa
    {
        public double convertirDeDolarAPeso(double dolares)
        {
            double conversionAPeso = dolares * 18.15;
            return conversionAPeso;
        }

        public double convertirDePesoADolar(double pesos)
        {
            double conversionADolar = pesos / 18.15;
            return conversionADolar;
        }
    }
}
