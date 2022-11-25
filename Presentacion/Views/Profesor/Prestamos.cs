using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.EntitiesDTO;
using Negocio.Management;
using Presentacion.Views.Profesor;

namespace Presentacion.Views
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
            CargarTabla();

        }

        private void CargarTabla()
        {
            List<Solicitud> solicitudes = new SolicitudManagement().obtenerSolicitudes(Login.instanciaLogin.correo);

            Dispositivo dispositivo;
            Categoria categoria;
            foreach (Solicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                if (!solicitud.estado.Equals("Pendiente"))
                {
                    tablaDispositivos.Rows.Add(solicitud.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, "Devolver");
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
            List<Solicitud> solicitudes = new SolicitudManagement().obtenerSolicitudesPorCategoria(categoriasSelecionadas);
            cargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorMarcas(List<string> categoriasSelecionadas)
        {
            List<Solicitud> solicitudes = new SolicitudManagement().obtenerSolicitudesPorMarca(categoriasSelecionadas);
            cargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorModelo(List<string> categoriasSelecionadas)
        {
            List<Solicitud> solicitudes = new SolicitudManagement().obtenerSolicitudesPorModelo(categoriasSelecionadas);
            cargarTablaFiltrada(solicitudes);
        }
        public void RellenarTablaFiltradaPorLocalizacion(List<string> categoriasSelecionadas)
        {
            List<Solicitud> solicitudes = new SolicitudManagement().obtenerSolicitudesPorLocalizacion(categoriasSelecionadas);
            cargarTablaFiltrada(solicitudes);
        }
        private void cargarTablaFiltrada(List<Solicitud> solicitudes)
        {
            Dispositivo dispositivo;
            Categoria categoria;
            LimpiarTabla();
            foreach (Solicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

                if (!solicitud.estado.Equals("Pendiente"))
                {
                    tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, "Reservar");
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
            CargarTabla();
        }

        private void tablaDispositivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string numSerie = fila.Cells[0].Value.ToString();
                Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numSerie);

                bool exito = new SolicitudManagement().finalizarSolicitud(Login.instanciaLogin.correo, numSerie);
                if (!exito)
                {
                    MessageBox.Show("No se ha podido devolver el dispositivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                exito = new DispositivoManagement().ModificarDispositivo(dispositivo);
                if (!exito)
                {
                    MessageBox.Show("No se ha podido devolver el dispositivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dispositivo devuelto", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTabla();
                CargarTabla();
            }

        }

        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string numSerie = fila.Cells[0].Value.ToString();
                new Prestamo(numSerie).ShowDialog();
                LimpiarTabla();
                CargarTabla();
            }
        }

        private void DevolverDispositivo()
        {
           
        }
    }
}
