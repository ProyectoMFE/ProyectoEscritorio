﻿using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Management
{
    public class DispositivoManagement
    {
        public DispositivoDTO ObtenerDispositivo(string numSerie)
        {
            DISPOSITIVOS disOld = new DispositivoDAO().Buscar(numSerie);
            DispositivoDTO dispositivo = new DispositivoDTO();

            Utils.parse(disOld, ref dispositivo);

            if (new HWRedDAO().Buscar(numSerie) != null)
            {

            }

            return dispositivo;
        }

        public List<DispositivoDTO> ObtenerDispositivos()
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            DispositivoDTO dispositivo;

            foreach (DISPOSITIVOS disOld in new DispositivoDAO().Consultar())
            {
                dispositivo = new DispositivoDTO();

                Utils.parse(disOld, ref dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarDispositivo(DispositivoDTO dispositivo)
        {
            DISPOSITIVOS disOld = new DISPOSITIVOS();

            Utils.parse(dispositivo, ref disOld);

            return new DispositivoDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarDispositivo(DispositivoDTO dispositivo)
        {
            DISPOSITIVOS disOld = new DISPOSITIVOS();

            Utils.parse(dispositivo, ref disOld);

            return new DispositivoDAO().Insertar(disOld);
        }

        public bool BorrarDispositivo(DispositivoDTO dispositivo)
        {
            DISPOSITIVOS disOld = new DISPOSITIVOS();

            Utils.parse(dispositivo, ref disOld);

            return new DispositivoDAO().Borrar(disOld);
        }
    }
}
