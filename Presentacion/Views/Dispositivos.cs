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

            int i = 0;
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);


                tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion,"Reservar");               
              
            }
        }

        private void RellenarTablaFiltradaPorDispositivos(List<string> categoriasSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                foreach (string item in categoriasSelecionadas)
                {
                    if (item.Equals(categoria.nombre))
                    {
                        tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion);
                    }

                }
            }
        }

        private void RellenarTablaFiltradaPorMarcas(List<string> marcasSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                foreach (string item in marcasSelecionadas)
                {
                    if (item.Equals(dispositivo.marca))
                    {
                        tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion);
                    }

                }
            }
        }

        private void RellenarTablaFiltradaPorModelo(List<string> modelosSelecionados)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                foreach (string item in modelosSelecionados)
                {
                    if (item.Equals(dispositivo.modelo))
                    {
                        tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion);
                    }

                }
            }
        }

        private void RellenarTablaFiltradaPorLocalizacion(List<string> localizacionesSelecionadas)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                foreach (string item in localizacionesSelecionadas)
                {
                    if (item.Equals(dispositivo.localizacion))
                    {
                        tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion);
                    }

                }
            }
        }

        private void RellenarTablaFiltradaPorEstado(List<string> estadosSelecionados)
        {
            List<DispositivoDTO> dispositivos = new DispositivoManagement().ObtenerDispositivos();

            tablaDispositivos.Rows.Clear();
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);

                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                foreach (string item in estadosSelecionados)
                {
                    if (item.Equals(estado))
                    {
                        tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca, dispositivo.modelo, estado, dispositivo.localizacion);
                    }

                }
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
    }
}
