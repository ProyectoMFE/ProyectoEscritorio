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
    public class PantallaManagement
    {
        public PantallaDTO ObtenerPantalla(string numSerie)
        {
            PANTALLAS disOld = new PantallaDAO().Buscar(numSerie);
            PantallaDTO dispositivo = new PantallaDTO();

            ParseNew(disOld, dispositivo);

            return dispositivo;
        }

        public List<PantallaDTO> ObtenerPantallas()
        {
            List<PantallaDTO> dispositivos = new List<PantallaDTO>();
            PantallaDTO dispositivo;

            foreach (PANTALLAS disOld in new PantallaDAO().Consultar())
            {
                dispositivo = new PantallaDTO();

                ParseNew(disOld, dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarPantalla(PantallaDTO dispositivo)
        {
            PANTALLAS disOld = new PANTALLAS();

            ParseOld(dispositivo, disOld);

            return new PantallaDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarPantalla(PantallaDTO dispositivo)
        {
            PANTALLAS disOld = new PANTALLAS();

            ParseOld(dispositivo, disOld);

            return new PantallaDAO().Insertar(disOld);
        }

        public bool BorrarPantalla(string numSerie)
        {
            return new PantallaDAO().Borrar(numSerie);
        }

        private void ParseNew(PANTALLAS disOld, PantallaDTO disNew)
        {
            disNew.numSerie = disOld.NUM_SERIE;
            disNew.pulgadas = disOld.PULGADAS;
        }

        private void ParseOld(PantallaDTO disNew, PANTALLAS disOld)
        {
            disOld.NUM_SERIE = disNew.numSerie;
            disOld.PULGADAS = disNew.pulgadas;
        }
    }
}
