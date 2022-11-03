using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    public class CategoriasDAO : DAO<CATEGORIAS>
    {
        private ProyectoMFEEntities contexto;

        public CategoriasDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool borrar(object id)
        {
            CATEGORIAS categoria;

            try
            {
                categoria = buscar(id);
                contexto.CATEGORIAS.Remove(categoria);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CATEGORIAS buscar(object id)
        {
            return contexto.CATEGORIAS.Where(p => p.ID_CATEGORIA == Convert.ToInt32(id)).First();
        }

        public List<CATEGORIAS> consultar()
        {
            return contexto.CATEGORIAS.ToList();
        }

        public bool insertar(CATEGORIAS id)
        {
            CATEGORIAS categoria;

            try
            {
                categoria = buscar(id);
                contexto.CATEGORIAS.Add(categoria);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificar(object id, CATEGORIAS nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
