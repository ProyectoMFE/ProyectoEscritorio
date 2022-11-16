using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class HistoricoSolicitud
    {
        public string numSerie { get; set; }
        public int idUsuario { get; set; }
        public System.DateTime fecha { get; set; }
        public string ultimatum { get; set; }
        public Usuario idUsuarioNavigation { get; set; }
        public Dispositivo numSerieNavigation { get; set; }
    }
}
