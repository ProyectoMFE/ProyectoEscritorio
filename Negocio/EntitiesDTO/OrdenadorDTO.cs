using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class OrdenadorDTO : CaracteristicaDTO
    {
        public string numSerie { get; set; }
        public string procesador { get; set; }
        public string ram { get; set; }
        public string discoPrincipal { get; set; }
        public string discoSecundario { get; set; }
    }
}
