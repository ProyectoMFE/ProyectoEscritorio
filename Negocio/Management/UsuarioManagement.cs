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

            Utils.parse(usuOld, ref usuario);

            return usuario;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario;

            foreach (USUARIOS usuOld in new UsuarioDAO().Consultar())
            {
                usuario = new UsuarioDTO();

                Utils.parse(usuOld, ref usuario);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public bool ModificarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            Utils.parse(usuario, ref usuOld);

            return new UsuarioDAO().Modificar(usuOld.ID_USUARIO, usuOld);
        }

        public bool InsertarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            Utils.parse(usuario, ref usuOld);

            return new UsuarioDAO().Insertar(usuOld);
        }

        public bool BorrarUsuario(UsuarioDTO usuario)
        {
            USUARIOS usuOld = new USUARIOS();

            Utils.parse(usuario, ref usuOld);

            return new UsuarioDAO().Borrar(usuOld);
        }
    }
}
