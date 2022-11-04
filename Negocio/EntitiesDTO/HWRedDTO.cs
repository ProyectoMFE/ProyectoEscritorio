using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class HWRedDTO : CaracteristicaDTO
    {
        public string NUM_SERIE { get; set; }
        public int NUM_PUERTOS { get; set; }
        public int VELOCIDAD { get; set; }
    }
}
