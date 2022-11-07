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
    public class HWManagement
    {
        public HWRedDTO ObtenerHWRed(string numSerie)
        {
            HW_RED disOld = new HWRedDAO().Buscar(numSerie);
            HWRedDTO dispositivo = new HWRedDTO();

            Utils.parse(disOld, ref dispositivo);

            return dispositivo;
        }

        public List<HWRedDTO> ObtenerHWReds()
        {
            List<HWRedDTO> dispositivos = new List<HWRedDTO>();
            HWRedDTO dispositivo;

            foreach (HW_RED disOld in new HWRedDAO().Consultar())
            {
                dispositivo = new HWRedDTO();

                Utils.parse(disOld, ref dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarHWRed(HWRedDTO dispositivo)
        {
            HW_RED disOld = new HW_RED();

            Utils.parse(dispositivo, ref disOld);

            return new HWRedDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarHWRed(HWRedDTO dispositivo)
        {
            HW_RED disOld = new HW_RED();

            Utils.parse(dispositivo, ref disOld);

            return new HWRedDAO().Insertar(disOld);
        }

        public bool BorrarHWRed(HWRedDTO dispositivo)
        {
            HW_RED disOld = new HW_RED();

            Utils.parse(dispositivo, ref disOld);

            return new HWRedDAO().Borrar(disOld);
        }
    }
}
