using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class Ordenador
    {
        public string numSerie { get; set; }
        public string procesador { get; set; }
        public string ram { get; set; }
        public string discoPrincipal { get; set; }
        public string discoSecundario { get; set; }
        public Dispositivo numSerieNavigation { get; set; }
    }
}
