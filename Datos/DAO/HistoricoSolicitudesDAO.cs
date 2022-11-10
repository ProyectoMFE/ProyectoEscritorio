using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
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
