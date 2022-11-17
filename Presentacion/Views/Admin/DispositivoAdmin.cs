using Negocio.Management;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Views.Admin
{
    public partial class DispositivoAdmin : Form
    {
        
        public DispositivoAdmin(string numSerie)
        {
            InitializeComponent();
            mostrarDispositivo(numSerie);
         ;
        }

        private void mostrarCaracteristicas(string numSerie)
        {
           
        }

        private void mostrarDispositivo(string numSerie)
        {
            Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

            txtNumSerie.Text = dispositivo.numSerie;
            txtCategoria.Text = categoria.nombre;
            txtMarca.Text = dispositivo.marca;
            txtModelo.Text = dispositivo.modelo;
            txtLocalizacion.Text = dispositivo.localizacion;

            

            switch (categoria.nombre)
            {
                case "Ordenador":
                    MostrarCaracteristicasOrdenador(numSerie);
                    break;
                default:
                    break;
            }

        }

        private void MostrarCaracteristicasHardwareRed(Dispositivo dispositivo)
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Nº Puertos";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "Velocidad";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = "";

            lblCaracteristica3.Visible = false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
        private void MostrarCaracteristicasOrdenador(string numserie)
        {
            Ordenador ordenador = new OrdenadorManagement().ObtenerOrdenador(numserie);
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Procesador";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = ordenador.procesador;

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "RAM";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = ordenador.ram;

            lblCaracteristica3.Visible = true;
            lblCaracteristica3.Text = "Disco 1";
            txtCaracteristica3.Visible = true;
            txtCaracteristica3.Text = ordenador.discoPrincipal;

            lblCaracteristica4.Visible = true;
            lblCaracteristica4.Text = "Disco 2";
            txtCaracteristica4.Visible = true;
            txtCaracteristica4.Text = ordenador.discoSecundario;
        }
        private void MostrarCaracteristicasPantalla(Dispositivo dispositivo)
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Pulgadas";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

            lblCaracteristica2.Visible = false;
            txtCaracteristica2.Visible = false;

            lblCaracteristica3.Visible = false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
        private void MostrarCaracteristicasComponente(Dispositivo dispositivo)
        {
            panelCaracteristicas.Visible = false;
        }
    }
}
