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

            ParseNew(disOld, dispositivo);

            return dispositivo;
        }

        public List<OrdenadorDTO> ObtenerOrdenadores()
        {
            List<OrdenadorDTO> dispositivos = new List<OrdenadorDTO>();
            OrdenadorDTO dispositivo;

            foreach (ORDENADORES disOld in new OrdenadorDAO().Consultar())
            {
                dispositivo = new OrdenadorDTO();

                ParseNew(disOld, dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarOrdenador(OrdenadorDTO dispositivo)
        {
            ORDENADORES disOld = new ORDENADORES();

            ParseOld(dispositivo, disOld);

            return new OrdenadorDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarOrdenador(OrdenadorDTO dispositivo)
        {
            ORDENADORES disOld = new ORDENADORES();

            ParseOld(dispositivo, disOld);

            return new OrdenadorDAO().Insertar(disOld);
        }

        public bool BorrarOrdenador(string numSerie)
        {
            return new OrdenadorDAO().Borrar(numSerie);
        }

        private void ParseNew(ORDENADORES disOld, OrdenadorDTO disNew)
        {
            disNew.numSerie = disOld.NUM_SERIE;
            disNew.ram = disOld.RAM;
            disNew.procesador = disOld.PROCESADOR;
            disNew.discoPrincipal = disOld.DISCO_PRINCIPAL;
            disNew.discoSecundario = disOld.DISCO_SECUNDARIO;
        }

        private void ParseOld(OrdenadorDTO disNew, ORDENADORES disOld)
        {
            disOld.NUM_SERIE = disNew.numSerie;
            disOld.RAM = disNew.ram;
            disOld.PROCESADOR = disNew.procesador;
            disOld.DISCO_PRINCIPAL = disNew.discoPrincipal;
            disOld.DISCO_SECUNDARIO = disNew.discoSecundario;
        }
    }
}
