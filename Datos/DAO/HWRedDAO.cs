using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    public class HWRedDAO : DAO<HW_RED>
    {
        private ProyectoMFEEntities contexto;

        public HWRedDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            HW_RED dispositivo;

            try
            {
                dispositivo = Buscar(id);
                contexto.HW_RED.Remove(dispositivo);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public HW_RED Buscar(object id)
        {
            try
            {
                return contexto.HW_RED.Where(p => p.NUM_SERIE == id).First();
            }
            catch (Exception)
            {
                return new HW_RED();
            }
        }

        public List<HW_RED> Consultar()
        {
            return contexto.HW_RED.ToList();
        }

        public bool Insertar(HW_RED objeto)
        {
            try
            {
                contexto.HW_RED.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, HW_RED nuevo)
        {
            HW_RED dispositivo;

            try
            {
                dispositivo = Buscar(id);

                dispositivo.NUM_SERIE = nuevo.NUM_SERIE;
                dispositivo.VELOCIDAD = nuevo.VELOCIDAD;
                dispositivo.NUM_PUERTOS = nuevo.NUM_PUERTOS;

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
