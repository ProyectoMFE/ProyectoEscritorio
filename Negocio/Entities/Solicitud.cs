using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class Solicitud
    {
        public string numSerie { get; set; }
        public int idUsuario { get; set; }
        public string estado { get; set; }
    }
}
