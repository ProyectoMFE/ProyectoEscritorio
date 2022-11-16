using Negocio.EntitiesDTO;
using Negocio.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Views.Admin
{
    public partial class ProgramaAdmin : Form
    {
        private Form formularioActivo;
        private Login padre;
        public ProgramaAdmin(Login padre)
        {
            InitializeComponent();
            customizeDesing();
            this.padre = padre;
            this.formularioActivo = null;
        }

        // MENU BOTON DISPOSITIVOS Y SU SUBMENU
        private void btnDispositivos_Click(object sender, EventArgs e)
        {
            openChildForm(new DispositivosAdmin());
            if (!panelDispositivos.Visible)
            {
                showSubMenu(panelDispositivos);
                MostrarSubCategorias();
            }
        }
        private void btnDispositivos1_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add(btnDispositivos1.Text);
            DispositivosAdmin dispositivos = new DispositivosAdmin();
            dispositivos.RellenarTablaFiltradaPorDispositivos(lista);
            openChildForm(dispositivos);

        }
        private void btnDispositivos2_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add(btnDispositivos2.Text);
            DispositivosAdmin dispositivos = new DispositivosAdmin();
            dispositivos.RellenarTablaFiltradaPorDispositivos(lista);
            openChildForm(dispositivos);
        }
        private void btnDispositivos3_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add(btnDispositivos3.Text);
            DispositivosAdmin dispositivos = new DispositivosAdmin();
            dispositivos.RellenarTablaFiltradaPorDispositivos(lista);
            openChildForm(dispositivos);
        }
        private void btnDispositivos4_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            lista.Add(btnDispositivos4.Text);
            DispositivosAdmin dispositivos = new DispositivosAdmin();
            dispositivos.RellenarTablaFiltradaPorDispositivos(lista);
            openChildForm(dispositivos);
        }

        // MENU BOTON PRESTAMOS Y SU SUBMENU
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            openChildForm(new PrestamosAdmin());
            if (!panelPrestamos.Visible)
            {
                showSubMenu(panelPrestamos);
                MostrarSubCategorias();
            }
        }
        private void btnPrestamos1_Click(object sender, EventArgs e)
        {

        }
        private void btnPrestamos2_Click(object sender, EventArgs e)
        {

        }
        private void btnPrestamos3_Click(object sender, EventArgs e)
        {

        }
        private void btnPrestamos4_Click(object sender, EventArgs e)
        {

        }

        // MENU BOTON SOLICITUDES Y SU SUBMENU
        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            openChildForm(new Solicitudes());
            if (!panelSolicitudes.Visible)
            {
                showSubMenu(panelSolicitudes);
            }
        }
        private void btnSolicitudesAprobadas_Click(object sender, EventArgs e)
        {

        }
        private void btnSolicitudesRechazadas_Click(object sender, EventArgs e)
        {

        }

        // MENU BOTON CONFIGURACION Y SU SUBMENU
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (!panelConfiguracion.Visible)
            {
                showSubMenu(panelConfiguracion);
            }          
        }
        private void btnConfiguracionUsuarios_Click(object sender, EventArgs e)
        {

        }
        private void btnConfiguracionCategorias_Click(object sender, EventArgs e)
        {

        }

        // BOTON SALIR DE LA APLICACION
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }

        // FUNCIONES VARIAS PARA HACER DINAMICO EL MENU
        private void customizeDesing()
        {
            panelDispositivos.Visible = false;
            panelPrestamos.Visible = false;
            panelSolicitudes.Visible = false;
            panelConfiguracion.Visible = false;

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
            if (panelConfiguracion.Visible == true)
            {
                panelConfiguracion.Visible = false;
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
        private void MostrarSubCategorias()
        {
            List<Categoria> categorias = new CategoriaManagement().ObtenerCategorias();

            int cantidadCategorias = categorias.Count();
            if (cantidadCategorias >= 4)
            {
                btnDispositivos1.Text = categorias[0].nombre;
                btnDispositivos2.Text = categorias[1].nombre;
                btnDispositivos3.Text = categorias[2].nombre;
                btnDispositivos4.Text = categorias[3].nombre;
            }
            else if (cantidadCategorias == 3)
            {
                btnDispositivos1.Text = categorias[0].nombre;
                btnDispositivos2.Text = categorias[1].nombre;
                btnDispositivos3.Text = categorias[2].nombre;
                btnDispositivos4.Hide();
            }
            else if (cantidadCategorias == 2)
            {
                btnDispositivos1.Text = categorias[0].nombre;
                btnDispositivos2.Text = categorias[1].nombre;
                btnDispositivos3.Hide();
                btnDispositivos4.Hide();
            }
            else if (cantidadCategorias == 1)
            {
                btnDispositivos1.Text = categorias[0].nombre;
                btnDispositivos2.Hide();
                btnDispositivos3.Hide();
                btnDispositivos4.Hide();
            }
        }
    }
}
