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
using System.Text.RegularExpressions;

namespace Presentacion.Views.Admin
{
    public partial class DispositivoAdmin : Form
    {
        
        public DispositivoAdmin(string numSerie)
        {
            InitializeComponent();
            mostrarDispositivo(numSerie);
        }

     
        // MOSTRAR DISPOSITIVO Y SUS CARACTERISTICAS
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

            btnModificar.Enabled = true;
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

            btnModificar.Enabled = true;
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

            btnModificar.Enabled = true;
        }
        private void MostrarCaracteristicasComponente()
        {
            panelCaracteristicas.Visible = false;
            btnModificar.Enabled = false;
        }

        //  ACCION BORRAR
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            bool exito = new DispositivoManagement().BorrarDispositivo(txtNumSerie.Text);

            if (exito)
            {
               MostarMensajeExitoBorrar();
                this.Close();
            }
            else
            {
                MostarMensajeExitoBorrar();
            }           
        }

        // ACCION MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {

            string categoria = txtCategoria.Text;

            switch(categoria){
                case "Ordenador":
                    ModificarOrdenador();
                    break;
                case "Pantalla":
                    ModificarPantalla();                    
                    break;
                case "Switch":
                    ModificarSwitch();
                    break;
            }          
        }

        // ACCION SALIR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // MODIFICAR ORDENADOR
        private void ModificarOrdenador()
        {
            Ordenador ordenador = new Ordenador()
            {
                numSerie = txtNumSerie.Text,
                procesador = txtCaracteristica1.Text,
                ram = txtCaracteristica2.Text,
                discoPrincipal = txtCaracteristica3.Text,
                discoSecundario = txtCaracteristica4.Text,
            };
            bool extito = new OrdenadorManagement().ModificarOrdenador(ordenador);

            if (!extito)
            {
                MostrarMensajeFalloModificar();
                return;
            }
            MostrarMensajeExitoModificar();
        }

        // MODIFICAR PANTALLA
        private void ModificarPantalla()
        {

            if (!ComprobarCaracteristicasPantalla())
            {
               MostrarMensajeFalloCaracteristicas();
                return;
                
            }

            Pantalla pantalla = new Pantalla()
            {
                numSerie = txtNumSerie.Text,
                pulgadas = Convert.ToInt32(txtCaracteristica1.Text),
            };
            bool exito = new PantallaManagement().ModificarPantalla(pantalla);

            if (!exito)
            {
                MostrarMensajeFalloModificar();
                return;
            }
            MostrarMensajeExitoModificar();
        }
        private bool ComprobarCaracteristicasPantalla()
        {
            Regex rx = new Regex("^\\d+$");

            bool campoVacio, campoConTexto;

            campoVacio = IsEmpty(txtCaracteristica1.Text);
            campoConTexto = !rx.IsMatch(txtCaracteristica1.Text);
            if (campoVacio)
            {
                return false;
            }

            if (campoConTexto)
            {
                return false;
            }

            return true;
        }

        // MODIFICAR SWITCH
        private void ModificarSwitch()
        {

            if (!ComprobarCaracteristicasHWRed())
            {
                MostrarMensajeFalloCaracteristicas();
                return;

            }

           HWRed hwRed = new HWRed()
           {
               numSerie = txtNumSerie.Text,
               numPuertos = Convert.ToInt32(txtCaracteristica1.Text),
               velocidad = Convert.ToInt32(txtCaracteristica2.Text),
           };

           
            bool exito = new HWManagement().ModificarHWRed(hwRed);

            if (!exito)
            {
                MostrarMensajeFalloModificar();
                return;
            }
            MostrarMensajeExitoModificar();
        }
        private bool ComprobarCaracteristicasHWRed()
        {

            Regex rx = new Regex("^\\d+$");

            bool campoVacio, campoConTexto;

            campoVacio = IsEmpty(txtCaracteristica1.Text);
            campoConTexto = !rx.IsMatch(txtCaracteristica1.Text);
            if (campoVacio)
            {
                return false;
            }

            if (campoConTexto)
            {
                return false;
            }
            campoVacio = IsEmpty(txtCaracteristica2.Text);
            campoConTexto = !rx.IsMatch(txtCaracteristica2.Text);
            if (campoVacio)
            {
                return false;
            }

            if (campoConTexto)
            {
                return false;
            }


            return true;
        }
    
        public bool IsEmpty(string campo)
        {
            return campo == "";
        }

        // MENSAJES PARA EL USUARIO
        private void MostarMensajeExitoBorrar()
        {
            MessageBox.Show("DISPOSITIVO BORRADO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MostrarMensajeFalloBorrar()
        {
            MessageBox.Show("ERROR AL BORRAR EL DISPOSITIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void MostrarMensajeExitoModificar()
        {
            MessageBox.Show("DISPOSITIVO MODIFICADO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MostrarMensajeFalloModificar()
        {
            MessageBox.Show("ERROR AL MODIFICAR EL DISPOSITIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void MostrarMensajeFalloCaracteristicas()
        {
            MessageBox.Show("LAS CARACTERISITICAS CONTIENEN TEXTO O ESTAN EN BLANCO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
