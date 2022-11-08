using System;
using System.Collections.Generic;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        public UsuarioDTO ObtenerUsuario(string correo)
        {
            USUARIOS usuOld = new UsuarioDAO().Buscar(correo);
            UsuarioDTO usuario = new UsuarioDTO();

            ParseNew(usuOld, usuario);

            return usuario;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario;

            foreach (USUARIOS usuOld in new UsuarioDAO().Consultar())
            {
                usuario = new UsuarioDTO();

                ParseNew(usuOld, usuario);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public bool ModificarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            ParseOld(usuario, usuOld);

            return new UsuarioDAO().Modificar(usuOld.ID_USUARIO, usuOld);
        }

        public bool InsertarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            ParseOld(usuario, usuOld);

            return new UsuarioDAO().Insertar(usuOld);
        }

        public bool BorrarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            ParseOld(usuario, usuOld);

            return new UsuarioDAO().Borrar(usuOld);
        }

        private void ParseNew(USUARIOS usuOld, UsuarioDTO usuNew)
        {
            usuNew.contrasenia = usuOld.CONTRASENIA;
            usuNew.segundoApellido = usuOld.SEGUNDO_APELLIDO;
            usuNew.primerApellido = usuOld.PRIMER_APELLIDO;
            usuNew.nombre = usuOld.NOMBRE;
            usuNew.correo = usuOld.CORREO;
            usuNew.idUsuario = usuOld.ID_USUARIO;
            usuNew.tipo = usuOld.TIPO;
        }

        private void ParseOld(UsuarioDTO usuNew, USUARIOS usuOld)
        {
            usuOld.CONTRASENIA = usuNew.contrasenia;
            usuOld.SEGUNDO_APELLIDO = usuNew.segundoApellido;
            usuOld.PRIMER_APELLIDO = usuNew.primerApellido;
            usuOld.NOMBRE = usuNew.nombre;
            usuOld.CORREO = usuNew.correo;
            usuOld.ID_USUARIO = usuNew.idUsuario;
            usuOld.TIPO = usuNew.tipo;
        }
    }
}
