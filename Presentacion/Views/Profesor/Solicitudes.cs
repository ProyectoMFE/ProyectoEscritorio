using Negocio.EntitiesDTO;
using Negocio.Management;
using Presentacion.Views.Profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Views
{
    public partial class Solicitudes : Form
    {
        public Solicitudes()
        {
            InitializeComponent();
            cargarTabla();
        }

        private void cargarTabla()
        {

            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().listarSolicitudes();
            Dispositivo dispositivo;
            Usuario usuario;
            Categoria categoria;
            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                usuario = new UsuarioManagement().ObtenerUsuario(solicitud.idUsuario);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                if (usuario.correo.Equals(Login.instanciaLogin.correo))
                {
                    tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, solicitud.ultimatum);
                }               
            }
        }

        public void CargarTablaSolicitudesAprobadas()
        {
            LimpiarTabla();
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().listarSolicitudesAprobadas();
            Dispositivo dispositivo;
            Usuario usuario;
            Categoria categoria;
            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                usuario = new UsuarioManagement().ObtenerUsuario(solicitud.idUsuario);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                if (usuario.correo.Equals(Login.instanciaLogin.correo))
                {
                    tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, "Aceptado");
                }
            
            }
        }

        public void CargarTablaSolicitudesRechazadas()
        {
            LimpiarTabla();
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().listarSolicitudesRechazadas();
            Dispositivo dispositivo;
            Usuario usuario;
            Categoria categoria;
            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                usuario = new UsuarioManagement().ObtenerUsuario(solicitud.idUsuario);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                if (usuario.correo.Equals(Login.instanciaLogin.correo))
                {
                    tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, "Rechazado");
                }
               
            }
        }

        // LIMPIAR LA TABLA DE DISPOSITIVOS
        private void LimpiarTabla()
        {
            tablaDispositivos.Rows.Clear();
        }

        // RELLENAR LA TABLA DE DISPOSITIVOS SEGUN LOS FILTROS
        public void RellenarTablaFiltradaPorDispositivos(List<string> categoriasSelecionadas)
        {
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().obtenerSolicitudesPorCategoria(categoriasSelecionadas);
            CargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorMarcas(List<string> categoriasSelecionadas)
        {
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().obtenerSolicitudesPorMarca(categoriasSelecionadas);
            CargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorModelo(List<string> categoriasSelecionadas)
        {
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().obtenerSolicitudesPorModelo(categoriasSelecionadas);
            CargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorLocalizacion(List<string> categoriasSelecionadas)
        {
            List<HistoricoSolicitud> solicitudes = new HistoricoSolicitudesManagement().obtenerSolicitudesPorLocalizacion(categoriasSelecionadas);
            CargarTablaFiltrada(solicitudes);
        }

        private void CargarTablaFiltrada(List<HistoricoSolicitud> solicitudes)
        {
            Dispositivo dispositivo;
            Usuario usuario;
            Categoria categoria;
            LimpiarTabla();
            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                usuario = new UsuarioManagement().ObtenerUsuario(solicitud.idUsuario);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

                if (usuario.correo.Equals(Login.instanciaLogin.correo))
                {
                    tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, solicitud.ultimatum);
                }
              

            }
        }


        // BOTONES DE FILTRO
        private void boton_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroDispositivo popup = new FiltroDispositivo(filtro);
            popup.ShowDialog();

            List<string> categoriasSelecionadas = filtro.listaParaFiltrar;
            if (categoriasSelecionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorDispositivos(categoriasSelecionadas);
            }
        }
        private void btnFiltroMarca_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroMarca popup = new FiltroMarca(filtro);
            popup.ShowDialog();

            List<string> marcasSeleccionadas = filtro.listaParaFiltrar;
            if (marcasSeleccionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorMarcas(marcasSeleccionadas);
            }
        }
        private void btnFiltroModelo_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroModelo popup = new FiltroModelo(filtro);
            popup.ShowDialog();

            List<string> categoriasSelecionadas = filtro.listaParaFiltrar;
            if (categoriasSelecionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorModelo(categoriasSelecionadas);
            }

        }
        private void btnFiltroLocalizacion_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroLocalizacion popup = new FiltroLocalizacion(filtro);
            popup.ShowDialog();

            List<string> categoriasSelecionadas = filtro.listaParaFiltrar;
            if (categoriasSelecionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorLocalizacion(categoriasSelecionadas);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            LimpiarTabla();
            cargarTabla();
        }

        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
            string numSerie = fila.Cells[0].Value.ToString();
            new SolicitudProfesor(numSerie).ShowDialog();
        }
    }
}
