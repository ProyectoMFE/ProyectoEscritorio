using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class HWRed
    {
        public string numSerie { get; set; }
        public int numPuertos { get; set; }
        public int velocidad { get; set; }
        public Dispositivo numSerieNavigation { get; set; }
    }
}
