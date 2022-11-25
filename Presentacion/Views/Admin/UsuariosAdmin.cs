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

namespace Presentacion.Views.Admin
{
    public partial class UsuariosAdmin : Form
    {
        public UsuariosAdmin()
        {
            InitializeComponent();
            CargarTabla();

        }

        private void CargarTabla()
        {
            List<Usuario> usuarios = new UsuarioManagement().ObtenerUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.tipo.Equals("P"))
                {
                    tablaDispositivos.Rows.Add(usuario.nombre, usuario.primerApellido + " " + usuario.segundoApellido, usuario.correo, "Dar de baja");
                }
            }

        }
        // LIMPIAR LA TABLA DE DISPOSITIVOS
        private void LimpiarTabla()
        {
            tablaDispositivos.Rows.Clear();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            new UsuarioNuevoAdmin().ShowDialog();
            LimpiarTabla();
            CargarTabla();
        }

        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string correo = fila.Cells[2].Value.ToString();

                new UsuarioAdmin(correo).ShowDialog();

                LimpiarTabla();
                CargarTabla();
            }


        }

        private void tablaDispositivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
                string correo = fila.Cells[2].Value.ToString();
                bool exito = new UsuarioManagement().BorrarUsuario(correo);
                if (!exito)
                {
                    MessageBox.Show("No se ha podido dar de baja al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Usuario borrado con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTabla();
                CargarTabla();
            }

        }
    }
}
