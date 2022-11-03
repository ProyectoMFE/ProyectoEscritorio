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
    public partial class Administrador : Form
    {
        private Login padre;
        public Administrador(Login padre)
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

        private void btnDispositivos_Click(object sender, EventArgs e)
        {
            openChildForm(new Dispositivos());
            showSubMenu(panelDispositivos);

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

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            openChildForm(new Solicitudes());
            showSubMenu(panelConfiguracion);
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


    }
}
