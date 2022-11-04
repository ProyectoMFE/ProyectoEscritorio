using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System.Collections.Generic;

namespace Negocio.Management
{
    public class CategoriaManagement
    {
        public CategoriaDTO ObtenerCategoria(int id)
        {
            CATEGORIAS catOld = new CategoriaDAO().Buscar(id);
            CategoriaDTO categoria = new CategoriaDTO();

            Utils.parse(catOld, ref categoria);

            return categoria;
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            CategoriaDTO categoria;

            foreach (CATEGORIAS catOld in new CategoriaDAO().Consultar())
            {
                categoria = new CategoriaDTO();

                Utils.parse(catOld, ref categoria);

                categorias.Add(categoria);
            }

            return categorias;
        }

        public bool ModificarCategoria(CategoriaDTO categoria)
        {
            CATEGORIAS catOld = new CATEGORIAS();

            Utils.parse(categoria, ref catOld);

            return new CategoriaDAO().Modificar(catOld.ID_CATEGORIA, catOld);
        }

        public bool InsertarCategoria(CategoriaDTO categoria)
        {
            CATEGORIAS catOld = new CATEGORIAS();

            Utils.parse(categoria, ref catOld);

            return new CategoriaDAO().Insertar(catOld);
        }

        public bool BorrarCategoria(CategoriaDTO categoria)
        {
            CATEGORIAS catOld = new CATEGORIAS();

            Utils.parse(categoria, ref catOld);

            return new CategoriaDAO().Borrar(catOld);
        }
    }
}
