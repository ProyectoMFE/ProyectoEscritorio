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

namespace Presentacion.Views
{
    public partial class FiltroModelo : Form
    {
        public Filtrar filtro { get; set; }
        public FiltroModelo(Filtrar filtro)
        {
            InitializeComponent();
            cargarListBox();
            this.filtro = filtro;
        }
        public void cargarListBox()
        {
            List<DispositivoDTO> listaDispositivos = new DispositivoManagement().ObtenerDispositivos();

            List<string> listaModelos = new List<string>();
            foreach (DispositivoDTO dispositivo in listaDispositivos)
            {
                if (!listaModelos.Contains(dispositivo.modelo))
                {
                    listaModelos.Add(dispositivo.modelo);
                }

            }


            foreach (string modelo in listaModelos)
            {
                tablaFiltroDispositivos.Rows.Add(modelo);
            }

        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> modelos = new List<string>();

            foreach (DataGridViewRow fila in tablaFiltroDispositivos.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    String marcaStr = fila.Cells[0].Value.ToString();
                    modelos.Add(marcaStr);
                }
            }
            filtro.listaParaFiltrar = modelos;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
