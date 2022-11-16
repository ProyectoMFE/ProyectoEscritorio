using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.EntitiesDTO;
using Negocio.Management;

namespace Presentacion.Views
{
    public partial class FiltroDispositivo : Form
    {

        public Filtrar filtro { get; set; }
        public FiltroDispositivo(Filtrar filtro)
        {
            InitializeComponent();
            cargarListBox();
            this.filtro = filtro;
            
        }

        public void cargarListBox()
        {
            List<Categoria> listaCategorias = new CategoriaManagement().ObtenerCategorias();

            foreach (Categoria categoria in listaCategorias)
            {
                tablaFiltroDispositivos.Rows.Add(categoria.nombre);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> categorias = new List<string>();

            foreach (DataGridViewRow fila in tablaFiltroDispositivos.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    String categoria = fila.Cells[0].Value.ToString();
                    categorias.Add(categoria);                   
                }
            }
            filtro.listaParaFiltrar = categorias;
            this.Close();
        }
    }
}
