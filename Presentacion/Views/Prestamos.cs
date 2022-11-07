using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Management;

namespace Presentacion.Views
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
            List<Button> lista = new List<Button>();
            Button b1 = new Button();
            Button b2 = new Button();
            Button b3 = new Button();

            lista.Add(b1);
            lista.Add(b2);
            lista.Add(b3);
            dataGridViewPrestamos.DataSource = lista;
            //dataGridViewPrestamos.DataSource = new DispositivoManagement().ObtenerDispositivos();
        }

      
    }
}
