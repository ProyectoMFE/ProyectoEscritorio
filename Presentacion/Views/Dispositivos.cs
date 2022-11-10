using Guna.UI2.WinForms;
using Negocio.EntitiesDTO;
using Negocio.Management;
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
    public partial class Dispositivos : Form
    {


        public Dispositivos()
        {
            InitializeComponent();
            RellenarTabla();

        }

        private void RellenarTabla()
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();


            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);


                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado, "Reservar");

            }
        }

        private void RellenarTablaFiltradaPorDispositivos(List<string> categoriasSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().obtenerDispositivosPorCategoria(categoriasSelecionadas);

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);


                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado,  "Reservar");

            }
        }

        private void RellenarTablaFiltradaPorMarcas(List<string> marcasSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().obtenerDispositivosPorMarca(marcasSelecionadas);

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado,  "Reservar");
            }
        }

        private void RellenarTablaFiltradaPorModelo(List<string> modelosSelecionados)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().obtenerDispositivosPorModelo(modelosSelecionados);

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado, "Reservar");
            }
        }

        private void RellenarTablaFiltradaPorLocalizacion(List<string> localizacionesSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().obtenerDispositivosPorLocalizacion(localizacionesSelecionadas);

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado,  "Reservar");

            }
        }

        private void RellenarTablaFiltradaPorEstado(List<string> estadosSelecionados)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().obtenerDispositivosPorEstado(estadosSelecionados);

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, estado,  "Reservar");
            }
        }

        private string formatearEstado(string estadoBD)
        {
            string estado = "";

            switch (estadoBD)
            {
                case "O":
                    estado = "Ocupado";
                    break;
                case "D":
                    estado = "Disponible";
                    break;
                case "I":
                    estado = "Instalado";
                    break;
                default:
                    break;
            }

            return estado;
        }

        private void btnFiltroMarca_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroMarca popup = new FiltroMarca(filtro);
            popup.ShowDialog();

            List<string> marcasSelecionadas = filtro.listaParaFiltrar;
            if (marcasSelecionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorMarcas(marcasSelecionadas);
            }
        }

        private void btnFiltroDispositivo_Click(object sender, EventArgs e)
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

        private void btnFiltroEstado_Click(object sender, EventArgs e)
        {
            Filtrar filtro = new Filtrar();
            FiltroEstado popup = new FiltroEstado(filtro);
            popup.ShowDialog();

            List<string> categoriasSelecionadas = filtro.listaParaFiltrar;
            if (categoriasSelecionadas.Count() > 0)
            {
                RellenarTablaFiltradaPorEstado(categoriasSelecionadas);
            }

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            RellenarTabla();
        }


        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
            string estado = fila.Cells[5].Value.ToString();
          
            if (!estado.Equals("Disponible"))
            {
                MessageBox.Show(this, "Este dispositivo no se puede reservar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string numSerie = fila.Cells[0].Value.ToString();
                Reservar(numSerie);
            }
        }

        private void Reservar(string numSerie)
        {
            Dispositivo dispositivo = new Dispositivo(numSerie);

            dispositivo.ShowDialog();
        }

        private void tablaDispositivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string estado = fila.Cells[5].Value.ToString();
                if (!estado.Equals("Disponible"))
                {
                    MessageBox.Show(this, "Este dispositivo no se puede reservar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string numSerie = fila.Cells[0].Value.ToString();
                    Reservar(numSerie);
                }
            }
        }
    }
}
