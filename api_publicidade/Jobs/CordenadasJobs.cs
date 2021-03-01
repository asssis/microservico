using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_publicidade.Jobs
{
    public class CordenadasJobs
    {
		public double CalcularDistancia(string origem_tr, string destino_str)
		{
            string[] origem= origem_tr.Split(",");
            string[] destino = destino_str.Split(",");
            double lat1 = Convert.ToDouble(origem[0].Replace(".",","));
            double lon1 = Convert.ToDouble(origem[1].Replace(".", ","));
            double lat2 = Convert.ToDouble(destino[0].Replace(".", ","));
            double lon2 = Convert.ToDouble(destino[1].Replace(".", ","));
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            double distancia = dist * 1609.344; 
            return distancia;
        }
		
    }
}
