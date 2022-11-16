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
    public class DispositivoManagement
    {
        public Dispositivo ObtenerDispositivo(string numSerie)
        {
            return null;
        }

        public List<Dispositivo> ObtenerDispositivos()
        {
            return null;
        }

        public bool ModificarDispositivo(Dispositivo dispositivo)
        {
            return true;
        }

        public bool InsertarDispositivo(Dispositivo dispositivo)
        {
            return true;
        }

        public bool BorrarDispositivo(string numSerie)
        {
            return new DispositivoDAO().Borrar(numSerie);
        }

        public List<Dispositivo> obtenerDispositivosPorCategoria(List<string> categorias)
        {
            return null;
        }

        public List<Dispositivo> obtenerDispositivosPorMarca(List<string>marcas)
        {
            return null;
        }
        public List<Dispositivo> obtenerDispositivosPorModelo(List<string> modelos)
        {
            return null;
        }
        public List<Dispositivo> obtenerDispositivosPorLocalizacion(List<string> localizaciones)
        {
            return null;
        }
        public List<Dispositivo> obtenerDispositivosPorEstado(List<string> estados)
        {
            return null;
        }
/*
        private void ObtenerCaracteristicas(Dispositivo dispositivo)
        {
            string numSerie = dispositivo.numSerie;

            if (new HWRedDAO().Buscar(numSerie) != null)
            {
                dispositivo.caracteristica = new HWManagement().ObtenerHWRed(numSerie);
            }else if (new OrdenadorDAO().Buscar(numSerie) != null)
            {
                dispositivo.caracteristica = new OrdenadorManagement().ObtenerOrdenador(numSerie);
            }
            else if (new PantallaDAO().Buscar(numSerie) != null)
            {
                dispositivo.caracteristica = new PantallaManagement().ObtenerPantalla(numSerie);
            }
        }

        private void InsertarCaracteristicas(Dispositivo dispositivo)
        {
            string numSerie = dispositivo.numSerie;

            if (new HWRedDAO().Buscar(numSerie) != null)
            {
                new HWManagement().InsertarHWRed((HWRed) dispositivo.caracteristica);
            }
            else if (new OrdenadorDAO().Buscar(numSerie) != null)
            {
                new OrdenadorManagement().InsertarOrdenador((Ordenador) dispositivo.caracteristica);
            }
            else if (new PantallaDAO().Buscar(numSerie) != null)
            {
                new PantallaManagement().InsertarPantalla((Pantalla) dispositivo.caracteristica);
            }
        }

        private void ModificarCaracteristicas(Dispositivo dispositivo)
        {
            string numSerie = dispositivo.numSerie;

            if (new HWRedDAO().Buscar(numSerie) != null)
            {
                new HWManagement().ModificarHWRed((HWRed)dispositivo.caracteristica);
            }
            else if (new OrdenadorDAO().Buscar(numSerie) != null)
            {
                new OrdenadorManagement().ModificarOrdenador((Ordenador)dispositivo.caracteristica);
            }
            else if (new PantallaDAO().Buscar(numSerie) != null)
            {
                new PantallaManagement().ModificarPantalla((Pantalla)dispositivo.caracteristica);
            }
        }*/
    }
}
