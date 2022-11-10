using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    public class CategoriaDAO : DAO<CATEGORIAS>
    {
        private ProyectoMFEEntities contexto;

        public CategoriaDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            CATEGORIAS categoria;

            try
            {
                categoria = Buscar(id);
                contexto.CATEGORIAS.Remove(categoria);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CATEGORIAS Buscar(object id)
        {
            try
            {
                return contexto.CATEGORIAS.Where(p => p.ID_CATEGORIA == (int) id).First();
            } catch (Exception)
            {
                return new CATEGORIAS();
            }
        }

        public List<CATEGORIAS> Consultar()
        {
            return contexto.CATEGORIAS.ToList();
        }

        public bool Insertar(CATEGORIAS objeto)
        {
            try
            {
                contexto.CATEGORIAS.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, CATEGORIAS nuevo)
        {
            CATEGORIAS categoria;

            try
            {
                categoria = Buscar(id);

                categoria.ID_CATEGORIA = nuevo.ID_CATEGORIA;
                categoria.NOMBRE = nuevo.NOMBRE;

                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
