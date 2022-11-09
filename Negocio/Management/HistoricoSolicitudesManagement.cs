using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Management
{
    public class HistoricoSolicitudesManagement
    {
        public List<HistoricoSolicitudesDTO> listarSolicitudes()
        {
            List<HistoricoSolicitudesDTO> solicitudes = new List<HistoricoSolicitudesDTO>();
            HistoricoSolicitudesDTO solicitud;

            foreach (HISTORICO_SOLICITUDES solOld in new HistoricoSolicitudesDAO().Consultar())
            {
                solicitud = new HistoricoSolicitudesDTO();

                ParseNew(solOld, solicitud);

                solicitudes.Add(solicitud);
            }

            return solicitudes;
        }

        private void ParseNew(HISTORICO_SOLICITUDES solOld, HistoricoSolicitudesDTO solNew)
        {
            solNew.numSerie = solOld.NUM_SERIE;
            solNew.idUsuario = solOld.ID_USUARIO;
            solNew.ultimatum = solOld.ULTIMATUM;
            solNew.fecha = solOld.FECHA;
        }
    }
}
