using Negocio.EntitiesDTO;
using Negocio.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Views.Admin
{
    public partial class UsuarioNuevoAdmin : Form
    {
        public UsuarioNuevoAdmin()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
         
            if (!ComprobarCampos())
            {
                MessageBox.Show("Hay datos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!CorreoCorrecto(txtCorreo.Text))
            {
                MessageBox.Show("El correo no es del dominio '@iescomercio.com'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = new Usuario()
            {
                nombre = txtNombre.Text,
                primerApellido = txtPrimerApellido.Text,
                segundoApellido= txtSegundoApellido.Text,
                correo= txtCorreo.Text,
                contrasenia = CifrarContraseña(txtContraseña.Text)
            };

            bool insertado = new UsuarioManagement().InsertarUsuario(usuario);

            if (!insertado)
            {
                MessageBox.Show("Error al insertar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario insertado con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool ComprobarCampos()
        {
            if (IsEmpty(txtNombre.Text))
            {
                return false;
            }

            if (IsEmpty(txtPrimerApellido.Text))
            {
                return false;
            }

            if (IsEmpty(txtSegundoApellido.Text))
            {
                return false;
            }
            if (IsEmpty(txtCorreo.Text))
            {
                return false;
            }
            if (IsEmpty(txtContraseña.Text))
            {
                return false;
            }

            return true;
        }
        private bool CorreoCorrecto(string correo)
        {
            Regex expresion = new Regex("\\w+@iescomercio.com");
            return expresion.IsMatch(correo);
        }
        private bool IsEmpty(string texto)
        {
            texto = texto.Trim();
            return texto == "";
        }

        public static string CifrarContraseña(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
