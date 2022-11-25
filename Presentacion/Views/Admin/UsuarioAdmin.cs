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
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Presentacion.Views.Admin
{
    public partial class UsuarioAdmin : Form
    {
        public UsuarioAdmin(string correo)
        {
            InitializeComponent();
            MostararDatos(correo);
        }

        private void MostararDatos(string correo)
        {
            Usuario usuario = new UsuarioManagement().ObtenerUsuario(correo);

            txtNombre.Text = usuario.nombre;
            txtPrimerApellido.Text = usuario.primerApellido;
            txtSegundoApellido.Text = usuario.segundoApellido;
            txtCorreo.Text = usuario.correo;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Usuario usuario = new UsuarioManagement().ObtenerUsuario(txtCorreo.Text);
            usuario.nombre = txtNombre.Text;
            usuario.primerApellido = txtPrimerApellido.Text; 
            usuario.segundoApellido = txtSegundoApellido.Text;
            if (!txtContraseña.Equals(""))
            {
                usuario.contrasenia = txtContraseña.Text;
            }
            bool exito = new UsuarioManagement().ModificarUsuario(usuario);
            if (!exito)
            {
                MessageBox.Show("No se ha podido modificar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario modicado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
