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
    public partial class FiltroLocalizacion : Form
    {
        public Filtrar filtro { get; set; }
        public FiltroLocalizacion(Filtrar filtro)
        {
            InitializeComponent();
            cargarListBox();
            this.filtro = filtro;
        }
        public void cargarListBox()
        {
            List<DispositivoDTO> listaDispositivos = new DispositivoManagement().ObtenerDispositivos();

            List<string> listaLocalizaciones = new List<string>();
            foreach (DispositivoDTO dispositivo in listaDispositivos)
            {
                if (!listaLocalizaciones.Contains(dispositivo.localizacion))
                {
                    listaLocalizaciones.Add(dispositivo.localizacion);
                }

            }


            foreach (string localizacion in listaLocalizaciones)
            {
                tablaFiltroDispositivos.Rows.Add(localizacion);
            }

        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> localizaciones = new List<string>();

            foreach (DataGridViewRow fila in tablaFiltroDispositivos.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    String marcaStr = fila.Cells[0].Value.ToString();
                    localizaciones.Add(marcaStr);
                }
            }
            filtro.listaParaFiltrar = localizaciones;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
