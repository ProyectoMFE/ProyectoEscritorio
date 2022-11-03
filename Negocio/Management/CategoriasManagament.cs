using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Management
{
   public class CategoriasManagament
    {

        public CategoriasDTO obtenerCategoria(int id)
        {
             
        }

        public List<CategoriasDTO> obtenerCategorias()
        {
            return null;
        }

        private void parse(CATEGORIAS usuOld, UsuarioDTO usuario)
        {
            usuario.idUsuario = usuOld.ID_USUARIO;
        }
    }
}
