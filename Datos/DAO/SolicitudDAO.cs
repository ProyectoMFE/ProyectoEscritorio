using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    public class SolicitudDAO
    {
        private ProyectoMFEEntities contexto;

        public SolicitudDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool insertar(string correo, string numSerie)
        {
            try
            {
                contexto.ACEPTAR_SOLICITUD(correo, numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool rechazar(string correo, string numSerie)
        {
            try
            {
                contexto.RECHAZAR_SOLICITUD(correo, numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool finalizar(string correo, string numSerie)
        {
            try
            {
                contexto.FINALIZAR_SOLICITUD(correo, numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool aceptar(string correo, string numSerie)
        {
            try
            {
                contexto.ACEPTAR_SOLICITUD(correo, numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SOLICITUDES> Consultar()
        {
            return contexto.SOLICITUDES.ToList();
        }
    }
}
