using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    
    public class Categoria
    {
        
        public int idCategoria { get; set; }
        public string nombre { get; set; }

        public List<Dispositivo> dispositivos { get; set; }

    }
}
