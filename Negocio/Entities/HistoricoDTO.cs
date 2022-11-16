using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    public class HistoricoDTO
    {
        public string NUM_SERIE { get; set; }
        public int ID_USUARIO { get; set; }
        public System.DateTime FECHA { get; set; }
        public string ULTIMATUM { get; set; }
    }
}
