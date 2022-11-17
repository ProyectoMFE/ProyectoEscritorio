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

namespace Presentacion.Views.Admin
{
    public partial class DispositivoNuevo : Form
    {
        public DispositivoNuevo()
        {
            InitializeComponent();
            cargarListaCategorias();
        }

        // CARGAR LAS CATEGORIAS EXISTENTES EN EL COMOBOX
        private void cargarListaCategorias()
        {
            List<Categoria> categorias = new CategoriaManagement().ObtenerCategorias();

            foreach (Categoria categoria in categorias)
            {
                comboBoxCategoria.Items.Add(categoria.nombre);
            }
        
        }

        // MOSTRAR LAS CARACTERISTICAS ESPECIFICAS SEGUN LA CATEGORIA SELECCIONADA
        private void comboBoxCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            
            string categoriaSeleccionada = comboBoxCategoria.SelectedItem.ToString();

            switch (categoriaSeleccionada)
            {
                case "Switch":
                    MostrarCaracteristicasHardwareRed();
                    break;
                case "Ordenador":
                    MostrarCaracteristicasOrdenador();
                    break;
                case "Pantalla":
                    MostrarCaracteristicasPantalla();
                    break;
                default:
                    MostrarCaracteristicasComponente();
                    break;
            }
           
        }
        private void MostrarCaracteristicasHardwareRed()
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
        private void MostrarCaracteristicasOrdenador()
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Procesador";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "RAM";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = "";

            lblCaracteristica3.Visible = true;
            lblCaracteristica3.Text = "Disco 1";
            txtCaracteristica3.Visible = true;
            txtCaracteristica3.Text = "";

            lblCaracteristica4.Visible = true;
            lblCaracteristica4.Text = "Disco 2";
            txtCaracteristica4.Visible = true;
            txtCaracteristica4.Text = "";
        }
        private void MostrarCaracteristicasPantalla()
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
        private void MostrarCaracteristicasComponente()
        {
            panelCaracteristicas.Visible = false;
        }

        // SALIR DEL FORMULARIO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
