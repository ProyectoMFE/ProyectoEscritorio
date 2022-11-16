using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class Pantalla
    {
        public string numSerie { get; set; }
        public int pulgadas { get; set; }
        public Dispositivo numSerieNavigation { get; set; }
    }
}
