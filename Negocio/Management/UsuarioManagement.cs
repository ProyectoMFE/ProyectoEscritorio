using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        public UsuarioDTO obtenerUsuario(string correo)
        {
            USUARIOS usu = new UsuarioDAO().buscar(correo);
            UsuarioDTO usu1 = new UsuarioDTO();

            usu1.idUsuario = usu.ID_USUARIO;
            usu1.correo = usu.CORREO;
            usu1.contrasenia = usu.CONTRASENIA;
            usu1.nombre = usu.NOMBRE;
            usu1.primerApellido = usu.PRIMER_APELLIDO;
            usu1.segundoApellido = usu.SEGUNDO_APELLIDO;
            usu1.tipo = usu.TIPO;

            return usu1;
        }

    }
}
