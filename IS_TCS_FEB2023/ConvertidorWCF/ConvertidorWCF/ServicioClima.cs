using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertidorWCF
{
    internal class ServicioClima : IServicioClima
    {
        public double celsiusAFarenheit(double gradosCelcius)
        {
            double conversionFarenheit = (gradosCelcius * 9/5) + 32;
            return conversionFarenheit;
        }

        public double farenheitACelcius(double gradosFarenheit)
        {
            double conversionACelsius = (gradosFarenheit - 32) * 5 / 9;
            return conversionACelsius;
        }
    }
}
