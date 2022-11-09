using Datos.DAO;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Negocio.Management
{
    public class SolicitudManagement
    {
        public bool insertarSolicitud(string correo, string numSerie)
        {
            return new SolicitudDAO().insertar(correo, numSerie);
        }

        public bool finalizarSolicitud(string correo, string numSerie)
        {
            return new SolicitudDAO().finalizar(correo, numSerie);
        }

        public bool aceptarSolicitud(string correo, string numSerie)
        {
            return new SolicitudDAO().aceptar(correo, numSerie);
        }

        public bool rechazarSolicitud(string correo, string numSerie)
        {
            return new SolicitudDAO().rechazar(correo, numSerie);
        }

        public List<SolicitudDTO> listarSolicitudes()
        {
            List<SolicitudDTO> solicitudes = new List<SolicitudDTO>();
            SolicitudDTO solicitud;

            foreach (SOLICITUDES solOld in new SolicitudDAO().Consultar())
            {
                solicitud = new SolicitudDTO();

                ParseNew(solOld, solicitud);

                solicitudes.Add(solicitud);
            }

            return solicitudes;
        }

        private void ParseNew(SOLICITUDES solOld, SolicitudDTO solNew)
        {
            solNew.numSerie = solOld.NUM_SERIE;
            solNew.idUsuario = solOld.ID_USUARIO;
            solNew.estado = solOld.ESTADO;
        }
    }
}
