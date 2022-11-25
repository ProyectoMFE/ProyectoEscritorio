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
    public partial class CategoriasAdmin : Form
    {
        public CategoriasAdmin()
        {
            InitializeComponent();
            CargarTabla();
        }

        private void LimpiarTabla()
        {
            tablaCategorias.Rows.Clear();
        }
        private void CargarTabla()
        {
            List<Categoria> listaCategorias = new CategoriaManagement().ObtenerCategorias();

            foreach (Categoria categoria in listaCategorias)
            {
                tablaCategorias.Rows.Add(categoria.idCategoria,categoria.nombre, "Eliminar");
            }
        }

        private void btnAltaCategoria_Click(object sender, EventArgs e)
        {
            if (!IsEmpty(txtNombreCategoria.Text))
            {
                Categoria categoria = new Categoria()
                {
                    nombre = txtNombreCategoria.Text,
                };

                bool exito = new CategoriaManagement().InsertarCategoria(categoria);

                if (!exito)
                {
                    MessageBox.Show("No se ha podido insertar la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Categoria insertada con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTabla();
                CargarTabla();
            }
           
        }

        private bool IsEmpty(string text)
        {
            text = text.Trim();
            return text == "";
        }

        private void tablaCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                DataGridViewRow fila = tablaCategorias.Rows[e.RowIndex];
                int idCategoria = (int)fila.Cells[0].Value;

                bool exito = new CategoriaManagement().BorrarCategoria(idCategoria);

                if (!exito)
                {
                    MessageBox.Show("No se ha podido borrar la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Categoria borrada con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTabla();
                CargarTabla();
                
            }
            
        }
    }
}
