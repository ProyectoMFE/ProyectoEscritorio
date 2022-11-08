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

            ParseNew(catOld, categoria);

            return categoria;
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            CategoriaDTO categoria;

            foreach (CATEGORIAS catOld in new CategoriaDAO().Consultar())
            {
                categoria = new CategoriaDTO();

                ParseNew(catOld, categoria);

                categorias.Add(categoria);
            }

            return categorias;
        }

        public bool ModificarCategoria(CategoriaDTO categoria)
        {
            CATEGORIAS catOld = new CATEGORIAS();

            ParseOld(categoria, catOld);

            return new CategoriaDAO().Modificar(catOld.ID_CATEGORIA, catOld);
        }

        public bool InsertarCategoria(CategoriaDTO categoria)
        {
            CATEGORIAS catOld = new CATEGORIAS();

            ParseOld(categoria, catOld);

            return new CategoriaDAO().Insertar(catOld);
        }

        public bool BorrarCategoria(int idCategoria)
        {
            return new CategoriaDAO().Borrar(idCategoria);
        }

        private void ParseNew(CATEGORIAS catOld, CategoriaDTO catNew)
        {
            catNew.idCategoria = catOld.ID_CATEGORIA;
            catNew.nombre = catOld.NOMBRE;
        }

        private void ParseOld(CategoriaDTO catNew, CATEGORIAS catOld)
        {
            catOld.ID_CATEGORIA = catNew.idCategoria;
            catOld.NOMBRE = catNew.nombre;
        }
    }
}
