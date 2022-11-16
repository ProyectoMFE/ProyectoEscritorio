using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class Dispositivo
    {
        public string numSerie { get; set; }
        public int idCategoria { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string localizacion { get; set; }
        public string estado { get; set; }
        public Categoria idCategoriaNavigation { get; set; }
        public HWRed hwRed { get; set; }
        public Ordenador ordenadores { get; set; }
        public Pantalla pantallas { get; set; }
        public List<Solicitud> solicitudes { get; set; }
    }
}
