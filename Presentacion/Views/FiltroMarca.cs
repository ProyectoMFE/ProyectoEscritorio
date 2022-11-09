using Negocio.Management;
using Negocio.EntitiesDTO;
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
    public partial class FiltroMarca : Form
    {
        public Filtrar filtro { get; set; }
        public FiltroMarca(Filtrar filtro)
        {
            InitializeComponent(); 
            cargarListBox();
            this.filtro = filtro;
        }
        public void cargarListBox()
        {
            List<DispositivoDTO> listaDispositivos = new DispositivoManagement().ObtenerDispositivos();

            List<string> listaMarcas = new List<string>();
            foreach (DispositivoDTO dispositivo in listaDispositivos)
            {
                if (!listaMarcas.Contains(dispositivo.marca))
                {
                    listaMarcas.Add(dispositivo.marca);
                }

            }
            

            foreach (string marca in listaMarcas)
            {
                tablaFiltroDispositivos.Rows.Add(marca);
            }

        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> marcas = new List<string>();

            foreach (DataGridViewRow fila in tablaFiltroDispositivos.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    String marcaStr = fila.Cells[0].Value.ToString();
                    marcas.Add(marcaStr);
                }
            }
            filtro.listaParaFiltrar = marcas;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
