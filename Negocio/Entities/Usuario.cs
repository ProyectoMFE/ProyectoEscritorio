using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.EntitiesDTO
{
    [Serializable]
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string tipo { get; set; }
        public string contrasenia { get; set; }
    }
}
