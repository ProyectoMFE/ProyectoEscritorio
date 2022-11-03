using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class DispositivoDTO
    {
        public string NUM_SERIE { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public string LOCALIZACION { get; set; }
        public string ESTADO { get; set; }
    }
}
