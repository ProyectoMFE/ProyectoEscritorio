using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class DispositivoDTO
    {
        public string numSerie { get; set; }
        public int idCategoria { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string localizacion { get; set; }
        public string estado { get; set; }
        public CaracteristicaDTO caracteristica { get; set; }
    }
}
