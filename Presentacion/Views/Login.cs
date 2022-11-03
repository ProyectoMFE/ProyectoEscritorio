using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            if (correo=="")
            {
                MessageBox.Show("El campo correo esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (contraseña == "")
            {
                MessageBox.Show("El campo contraseña vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!expresion.IsMatch(correo))
            {
                MessageBox.Show("Correo no es del dominio @.edu.es", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (correo.Equals("marcos@larioja.edu.es"))
            {
                Administrador principal = new Administrador(this);
                principal.Show();
                this.Hide();
                return;

            }
            if (correo.Equals("edu@larioja.edu.es"))
            {
                Programa principal = new Programa(this);
                principal.Show();
                this.Hide();
                return;
            }
            
        }
    }
}
