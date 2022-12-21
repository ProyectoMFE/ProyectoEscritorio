using Negocio.EntitiesDTO;
using Negocio.Management;
using Presentacion.Informes;
using Presentacion.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Views
{
    public partial class DispositivosAdmin : Form
    {
        public DispositivosAdmin()
        {
            InitializeComponent();
            RellenarTabla();
        }

        // RELLENAR LA TABLA DE DISPOSITIVOS SIN FILTROS
        private void RellenarTabla()
        {
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().ObtenerDispositivos();


            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {
   
                Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);


                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, dispositivo.estado, "Modificar");

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
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().obtenerDispositivosPorCategoria(categoriasSelecionadas);

            LimpiarTabla();
            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {
      
                Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, dispositivo.estado, "Modificar");

            }
        }
        private void RellenarTablaFiltradaPorMarcas(List<string> marcasSelecionadas)
        {
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().obtenerDispositivosPorMarca(marcasSelecionadas);

            LimpiarTabla();
            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {

                Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, dispositivo.estado, "Modificar");
            }
        }
        private void RellenarTablaFiltradaPorModelo(List<string> modelosSelecionados)
        {
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().obtenerDispositivosPorModelo(modelosSelecionados);

            LimpiarTabla();
            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {
      
                Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, dispositivo.estado, "Modificar");
            }
        }
        private void RellenarTablaFiltradaPorLocalizacion(List<string> localizacionesSelecionadas)
        {
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().obtenerDispositivosPorLocalizacion(localizacionesSelecionadas);

            LimpiarTabla();
            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {             Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion, dispositivo.estado, "Modificar");

            }
        }
        private void RellenarTablaFiltradaPorEstado(List<string> estadosSelecionados)
        {
            List<Negocio.EntitiesDTO.Dispositivo> dispositivos = new DispositivoManagement().obtenerDispositivosPorEstado(estadosSelecionados);

            LimpiarTabla();
            foreach (Negocio.EntitiesDTO.Dispositivo dispositivo in dispositivos)
            {
    
                Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, dispositivo.modelo, dispositivo.localizacion,dispositivo.estado, "Modificar");
            }
        }

        // ACCIONES DE LOS BOTONES QUE FILTRAN
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
            LimpiarTabla();
            RellenarTabla();
        }
      
        // ACCIONES AL HACER CLICK EN LA TABLA O EN EL BOTON DE MODIFICAR
        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string estado = fila.Cells[5].Value.ToString();

                if (!estado.Equals("Disponible"))
                {
                    MessageBox.Show(this, "Este dispositivo no se puede modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string numSerie = fila.Cells[0].Value.ToString();
                    Modificar(numSerie);
                }
            }
            catch { }
        }   
        private void tablaDispositivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                    string estado = fila.Cells[5].Value.ToString();
                    if (!estado.Equals("Disponible"))
                    {
                        MessageBox.Show(this, "Este dispositivo no se puede modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string numSerie = fila.Cells[0].Value.ToString();
                        Modificar(numSerie);
                    }
                }
            }
            catch { }
        }

    
        // MOSTRAR DISPOSITIVO A MODIFICAR
        private void Modificar(string numSerie)
        {
            DispositivoAdmin dispositivo = new DispositivoAdmin(numSerie);
            dispositivo.ShowDialog();
            LimpiarTabla();
            RellenarTabla();
        }

        // ACCION AGRAGAR DISPOSITIVO NUEVO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DispositivoNuevo popup = new DispositivoNuevo();
            popup.ShowDialog();
            LimpiarTabla();
            RellenarTabla();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            InformesAdmin popup = new InformesAdmin();
            popup.ShowDialog();
        }
    }
}
