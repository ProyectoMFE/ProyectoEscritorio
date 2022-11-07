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
    public class OrdenadorManagement
    {
        public OrdenadorDTO ObtenerOrdenador(string numSerie)
        {
            ORDENADORES disOld = new OrdenadorDAO().Buscar(numSerie);
            OrdenadorDTO dispositivo = new OrdenadorDTO();

            Utils.parse(disOld, ref dispositivo);

            return dispositivo;
        }

        public List<OrdenadorDTO> ObtenerOrdenadores()
        {
            List<OrdenadorDTO> dispositivos = new List<OrdenadorDTO>();
            OrdenadorDTO dispositivo;

            foreach (ORDENADORES disOld in new OrdenadorDAO().Consultar())
            {
                dispositivo = new OrdenadorDTO();

                Utils.parse(disOld, ref dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarOrdenador(OrdenadorDTO dispositivo)
        {
            ORDENADORES disOld = new ORDENADORES();

            Utils.parse(dispositivo, ref disOld);

            return new OrdenadorDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarOrdenador(OrdenadorDTO dispositivo)
        {
            ORDENADORES disOld = new ORDENADORES();

            Utils.parse(dispositivo, ref disOld);

            return new OrdenadorDAO().Insertar(disOld);
        }

        public bool BorrarOrdenador(OrdenadorDTO dispositivo)
        {
            ORDENADORES disOld = new ORDENADORES();

            Utils.parse(dispositivo, ref disOld);

            return new OrdenadorDAO().Borrar(disOld);
        }
    }
}
