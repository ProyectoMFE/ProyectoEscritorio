using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    /// <summary>
    /// Clase que realiza una consulta a el historial de solicitudes de de la base de datos.
    /// </summary>
    public class HistoricoSolicitudesDAO
    {
        private ProyectoMFEEntities contexto;

        public HistoricoSolicitudesDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public List<HISTORICO_SOLICITUDES> Consultar()
        {
            return contexto.HISTORICO_SOLICITUDES.ToList();
        }
    }
}
