using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System.Collections.Generic;

namespace Negocio.Management
{
    public class CategoriaManagement
    {
        public Categoria ObtenerCategoria(int id)
        {
            return null;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return null;
        }

        public bool ModificarCategoria(Categoria categoria)
        {
            return false;
        }

        public bool InsertarCategoria(Categoria categoria)
        {
            return false;
        }

        public bool BorrarCategoria(int idCategoria)
        {
            return true;
        }
    }
}
