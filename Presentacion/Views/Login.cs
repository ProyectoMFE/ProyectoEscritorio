using Negocio.EntitiesDTO;
using Negocio.Management;
using Presentacion.Views.Admin;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
      
        public void pintarFondo(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(17, 157, 180), Color.FromArgb(255, 255, 255), LinearGradientMode.Vertical);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtPassword.Text;
            Regex expresion = new Regex("\\w+@larioja.edu.es");

            if (correo == "")
            {
                MessageBox.Show("El campo correo esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (contraseña == "")
            {
                MessageBox.Show("El campo contraseña vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*

            if (!expresion.IsMatch(correo))
            {
                MessageBox.Show("Correo no es del dominio @.edu.es", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            UsuarioDTO usuarioDTO = new UsuarioManagement().ObtenerUsuario(correo);
            contraseña = cifrarContraseña(contraseña);


            if (!contraseña.Equals(usuarioDTO.contrasenia))
            {
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuarioDTO.tipo.Equals("A"))
            {
                ProgramaAdmin principal = new ProgramaAdmin(this);
                principal.Show();
                this.Hide();
                return;
            }

            if (usuarioDTO.tipo.Equals("P"))
            {
                Programa principal = new Programa(this);
                principal.Show();
                this.Hide();
                return;
            }           
        }

        public static string cifrarContraseña(string input)
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
    }
}
