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
    public partial class NuevoDispositivo : Form
    {
        public NuevoDispositivo()
        {
            InitializeComponent();
            cargarListaCategorias();
        }

        private void cargarListaCategorias()
        {
            comboBoxCategoria.Items.Add("Switch");
            comboBoxCategoria.Items.Add("Ordenador");
            comboBoxCategoria.Items.Add("Pantalla");
            comboBoxCategoria.Items.Add("Otro");
        }

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
            }
           
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

            lblCaracteristica3.Visible= false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
    }
}
