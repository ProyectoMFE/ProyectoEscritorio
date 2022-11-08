using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class HWRedDTO : CaracteristicaDTO
    {
        public string numSerie { get; set; }
        public int numPuertos { get; set; }
        public int velocidad { get; set; }
    }
}
