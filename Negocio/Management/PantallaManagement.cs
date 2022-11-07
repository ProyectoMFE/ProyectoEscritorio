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

            Utils.parse(disOld, ref dispositivo);

            return dispositivo;
        }

        public List<PantallaDTO> ObtenerPantallas()
        {
            List<PantallaDTO> dispositivos = new List<PantallaDTO>();
            PantallaDTO dispositivo;

            foreach (PANTALLAS disOld in new PantallaDAO().Consultar())
            {
                dispositivo = new PantallaDTO();

                Utils.parse(disOld, ref dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarPantalla(PantallaDTO dispositivo)
        {
            PANTALLAS disOld = new PANTALLAS();

            Utils.parse(dispositivo, ref disOld);

            return new PantallaDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarPantalla(PantallaDTO dispositivo)
        {
            PANTALLAS disOld = new PANTALLAS();

            Utils.parse(dispositivo, ref disOld);

            return new PantallaDAO().Insertar(disOld);
        }

        public bool BorrarPantalla(PantallaDTO dispositivo)
        {
            PANTALLAS disOld = new PANTALLAS();

            Utils.parse(dispositivo, ref disOld);

            return new PantallaDAO().Borrar(disOld);
        }
    }
}
