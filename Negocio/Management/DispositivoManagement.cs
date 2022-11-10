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
        public DispositivoDTO ObtenerDispositivo(string numSerie)
        {
            DISPOSITIVOS disOld = new DispositivoDAO().Buscar(numSerie);
            DispositivoDTO dispositivo = new DispositivoDTO();

            ParseNew(disOld, dispositivo);
            ObtenerCaracteristicas(dispositivo);

            return dispositivo;
        }

        public List<DispositivoDTO> ObtenerDispositivos()
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            DispositivoDTO dispositivo;

            foreach (DISPOSITIVOS disOld in new DispositivoDAO().Consultar())
            {
                dispositivo = new DispositivoDTO();

                ParseNew(disOld, dispositivo);
                ObtenerCaracteristicas(dispositivo);

                dispositivos.Add(dispositivo);
            }

            return dispositivos;
        }

        public bool ModificarDispositivo(DispositivoDTO dispositivo)
        {
            DISPOSITIVOS disOld = new DISPOSITIVOS();

            ParseOld(dispositivo, disOld);
            ModificarCaracteristicas(dispositivo);

            return new DispositivoDAO().Modificar(disOld.NUM_SERIE, disOld);
        }

        public bool InsertarDispositivo(DispositivoDTO dispositivo)
        {
            DISPOSITIVOS disOld = new DISPOSITIVOS();

            ParseOld(dispositivo, disOld);
            InsertarCaracteristicas(dispositivo);

            return new DispositivoDAO().Insertar(disOld);
        }

        public bool BorrarDispositivo(string numSerie)
        {
            return new DispositivoDAO().Borrar(numSerie);
        }

        public List<DispositivoDTO> obtenerDispositivosPorCategoria(List<string> categorias)
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            List<DISPOSITIVOS> dispositivosBD = new DispositivoDAO().ObtenerDispositivosPorCategoria(categorias);

            foreach (DISPOSITIVOS DISPOSITIVO in dispositivosBD)
            {
                DispositivoDTO dispositivo = new DispositivoDTO();
                ParseNew(DISPOSITIVO, dispositivo);
                dispositivos.Add(dispositivo);
            }
            return dispositivos;
        }

        public List<DispositivoDTO> obtenerDispositivosPorMarca(List<string>marcas)
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            List<DISPOSITIVOS> dispositivosBD = new DispositivoDAO().ObtenerDispositivosPorMarca(marcas);

            foreach (DISPOSITIVOS DISPOSITIVO in dispositivosBD)
            {
                DispositivoDTO dispositivo = new DispositivoDTO();
                ParseNew(DISPOSITIVO, dispositivo);
                dispositivos.Add(dispositivo);
            }
            return dispositivos;
        }
        public List<DispositivoDTO> obtenerDispositivosPorModelo(List<string> modelos)
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            List<DISPOSITIVOS> dispositivosBD = new DispositivoDAO().ObtenerDispositivosPorModelo(modelos);

            foreach (DISPOSITIVOS DISPOSITIVO in dispositivosBD)
            {
                DispositivoDTO dispositivo = new DispositivoDTO();
                ParseNew(DISPOSITIVO, dispositivo);
                dispositivos.Add(dispositivo);
            }
            return dispositivos;
        }
        public List<DispositivoDTO> obtenerDispositivosPorLocalizacion(List<string> localizaciones)
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            List<DISPOSITIVOS> dispositivosBD = new DispositivoDAO().ObtenerDispositivosPorLocalizaciones(localizaciones);

            foreach (DISPOSITIVOS DISPOSITIVO in dispositivosBD)
            {
                DispositivoDTO dispositivo = new DispositivoDTO();
                ParseNew(DISPOSITIVO, dispositivo);
                dispositivos.Add(dispositivo);
            }
            return dispositivos;
        }
        public List<DispositivoDTO> obtenerDispositivosPorEstado(List<string> estados)
        {
            List<DispositivoDTO> dispositivos = new List<DispositivoDTO>();
            List<DISPOSITIVOS> dispositivosBD = new DispositivoDAO().ObtenerDispositivosPorEstados(estados);

            foreach (DISPOSITIVOS DISPOSITIVO in dispositivosBD)
            {
                DispositivoDTO dispositivo = new DispositivoDTO();
                ParseNew(DISPOSITIVO, dispositivo);
                dispositivos.Add(dispositivo);
            }
            return dispositivos;
        }

        private void ParseNew(DISPOSITIVOS disOld, DispositivoDTO disNew)
        {
            disNew.numSerie = disOld.NUM_SERIE;
            disNew.idCategoria = disOld.ID_CATEGORIA;
            disNew.estado = disOld.ESTADO;
            disNew.marca = disOld.MARCA;
            disNew.modelo = disOld.MODELO;
            disNew.localizacion = disOld.LOCALIZACION;
        }

        private void ParseOld(DispositivoDTO disNew, DISPOSITIVOS disOld)
        {
            disOld.NUM_SERIE = disNew.numSerie;
            disOld.ID_CATEGORIA = disNew.idCategoria;
            disOld.ESTADO = disNew.estado;
            disOld.MARCA = disNew.marca;
            disOld.MODELO = disNew.modelo;
            disOld.LOCALIZACION = disNew.localizacion;
        }

        private void ObtenerCaracteristicas(DispositivoDTO dispositivo)
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

        private void InsertarCaracteristicas(DispositivoDTO dispositivo)
        {
            string numSerie = dispositivo.numSerie;

            if (new HWRedDAO().Buscar(numSerie) != null)
            {
                new HWManagement().InsertarHWRed((HWRedDTO) dispositivo.caracteristica);
            }
            else if (new OrdenadorDAO().Buscar(numSerie) != null)
            {
                new OrdenadorManagement().InsertarOrdenador((OrdenadorDTO) dispositivo.caracteristica);
            }
            else if (new PantallaDAO().Buscar(numSerie) != null)
            {
                new PantallaManagement().InsertarPantalla((PantallaDTO) dispositivo.caracteristica);
            }
        }

        private void ModificarCaracteristicas(DispositivoDTO dispositivo)
        {
            string numSerie = dispositivo.numSerie;

            if (new HWRedDAO().Buscar(numSerie) != null)
            {
                new HWManagement().ModificarHWRed((HWRedDTO)dispositivo.caracteristica);
            }
            else if (new OrdenadorDAO().Buscar(numSerie) != null)
            {
                new OrdenadorManagement().ModificarOrdenador((OrdenadorDTO)dispositivo.caracteristica);
            }
            else if (new PantallaDAO().Buscar(numSerie) != null)
            {
                new PantallaManagement().ModificarPantalla((PantallaDTO)dispositivo.caracteristica);
            }
        }
    }
}
