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
    public partial class Programa : Form
    {
        private Login padre;
        public Programa(Login padre)
        {
            InitializeComponent();
            customizeDesing();
            this.padre = padre;
        }
        private void customizeDesing()
        {
            panelDispositivos.Visible = false;
            panelPrestamos.Visible = false;
            panelSolicitudes.Visible = false;
          
        }
        private void hideSubMenu()
        {
            if (panelDispositivos.Visible == true)
            {
                panelDispositivos.Visible = false;
            }
            if (panelPrestamos.Visible == true)
            {
                panelPrestamos.Visible = false;
            }
            if (panelSolicitudes.Visible == true)
            {
                panelSolicitudes.Visible = false;
            }
          
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnDispositivos_Click(object sender, EventArgs e)
        {
            openChildForm(new Dispositivos());
            showSubMenu(panelDispositivos);
            MostrarSubCategorias();

        }

        private void MostrarSubCategorias()
        {
            List<CategoriaDTO> categorias = new CategoriaManagement().ObtenerCategorias();

            int cantidadCategorias = categorias.Count();
            if (cantidadCategorias >= 4)
            {
                btnDispositivosOrdenador.Text = categorias[0].nombre;
                btnDispositivoChromeCast.Text = categorias[1].nombre;
                bntDispositivoSwitch.Text = categorias[2].nombre;
                btnDispositivoTeclado.Text = categorias[3].nombre;
            }
            else if (cantidadCategorias == 3)
            {
                btnDispositivosOrdenador.Text = categorias[0].nombre;
                btnDispositivoChromeCast.Text = categorias[1].nombre;
                bntDispositivoSwitch.Text = categorias[2].nombre;
                btnDispositivoTeclado.Hide();
            }
            else if (cantidadCategorias == 2)
            {
                btnDispositivosOrdenador.Text = categorias[0].nombre;
                btnDispositivoChromeCast.Text = categorias[1].nombre;
                bntDispositivoSwitch.Hide();
                btnDispositivoTeclado.Hide();
            }
            else if (cantidadCategorias == 1)
            {
                btnDispositivosOrdenador.Text = categorias[0].nombre;
                btnDispositivoChromeCast.Hide();
                bntDispositivoSwitch.Hide();
                btnDispositivoTeclado.Hide();
            }
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            openChildForm(new Prestamos());
            showSubMenu(panelPrestamos);
        }

        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            openChildForm(new Solicitudes());
            showSubMenu(panelSolicitudes);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }

        private Form formularioActivo = null;
        private void openChildForm(Form formulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormulario.Controls.Add(formulario);
            panelFormulario.Tag = formulario;
            formulario.BringToFront();
            formulario.Show();
        }

        private void btnDispositivosOrdenador_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add("Ordenador");
            Dispositivos dispositivos = new Dispositivos();
            dispositivos.RellenarTablaFiltradaPorDispositivos(lista);
            openChildForm(dispositivos);
     
        }
    }
}
