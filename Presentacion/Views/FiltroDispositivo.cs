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
        public FiltroDispositivo()
        {
            InitializeComponent();
            cargarListBox();
        }

        public void cargarListBox()
        {
            List<CategoriaDTO> listaCategorias = new CategoriaManagement().ObtenerCategorias();

            for (int i = 0; i < listaCategorias.Count; i++)
            {
                CategoriaDTO categoria = listaCategorias[i];                
                checkedListBoxDispositivos.Items.Add(categoria.nombre);
            }
        }
    }
}
