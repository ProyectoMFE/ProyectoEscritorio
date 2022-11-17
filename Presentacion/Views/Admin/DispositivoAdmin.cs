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

namespace Presentacion.Views.Admin
{
    public partial class DispositivoAdmin : Form
    {
        
        public DispositivoAdmin(string numSerie)
        {
            InitializeComponent();
            mostrarDispositivo(numSerie);
        }

     

        private void mostrarDispositivo(string numSerie)
        {
            Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

            txtNumSerie.Text = dispositivo.numSerie;
            txtCategoria.Text = categoria.nombre;
            txtMarca.Text = dispositivo.marca;
            txtModelo.Text = dispositivo.modelo;
            txtLocalizacion.Text = dispositivo.localizacion;

            

            switch (categoria.nombre)
            {
                case "Ordenador":
                    MostrarCaracteristicasOrdenador(numSerie);
                    break;
                case "Switch":
                    MostrarCaracteristicasHardwareRed(numSerie);
                    break;
                case "Pantalla":
                    MostrarCaracteristicasPantalla(numSerie);
                    break;                   
                default:
                    MostrarCaracteristicasComponente();
                    break;
            }

        }

        private void MostrarCaracteristicasHardwareRed(string numserie)
        {
            HWRed dispositivo = new HWManagement().ObtenerHWRed(numserie);
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Nº Puertos";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = dispositivo.numPuertos+"";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "Velocidad";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = dispositivo.velocidad+"";

            lblCaracteristica3.Visible = false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
        private void MostrarCaracteristicasOrdenador(string numserie)
        {
            Ordenador ordenador = new OrdenadorManagement().ObtenerOrdenador(numserie);
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Procesador";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = ordenador.procesador;

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "RAM";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = ordenador.ram;

            lblCaracteristica3.Visible = true;
            lblCaracteristica3.Text = "Disco 1";
            txtCaracteristica3.Visible = true;
            txtCaracteristica3.Text = ordenador.discoPrincipal;

            lblCaracteristica4.Visible = true;
            lblCaracteristica4.Text = "Disco 2";
            txtCaracteristica4.Visible = true;
            txtCaracteristica4.Text = ordenador.discoSecundario;
        }
        private void MostrarCaracteristicasPantalla(string numserie)
        {
            Pantalla pantalla = new PantallaManagement().ObtenerPantalla(numserie);
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Pulgadas";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text =pantalla.pulgadas+"";

            lblCaracteristica2.Visible = false;
            txtCaracteristica2.Visible = false;

            lblCaracteristica3.Visible = false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
        private void MostrarCaracteristicasComponente()
        {
            panelCaracteristicas.Visible = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            bool exito = new DispositivoManagement().BorrarDispositivo(txtNumSerie.Text);

            if (exito)
            {
                MessageBox.Show("DISPOSITIVO BORRADO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR AL BORRAR EL DISPOSITIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}
