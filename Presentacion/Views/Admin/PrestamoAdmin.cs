using Negocio.EntitiesDTO;
using Negocio.Management;
using System;
using System.Windows.Forms;

namespace Presentacion.Views.Admin
{
    public partial class PrestamoAdmin : Form
    {
        public PrestamoAdmin(string correo, string numSerie)
        {
            InitializeComponent();
            mostrarDatos(correo, numSerie);
        }


        // MOSTRAR LOS DATOS DEL DISPOSITIVO
        private void mostrarDatos(string correo, string numSerie)
        {
            Usuario usuario = new UsuarioManagement().ObtenerUsuario(correo);
            Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);


            txtNumSerie.Text = dispositivo.numSerie;
            txtCategoria.Text = categoria.nombre;
            txtMarca.Text = dispositivo.marca;
            txtModelo.Text = dispositivo.modelo;
            txtLocalizacion.Text = dispositivo.localizacion;
            txtCorreo.Text = correo;
            txtProfesor.Text = usuario.nombre;


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
            txtCaracteristica1.Text = dispositivo.numPuertos + "";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "Velocidad";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = dispositivo.velocidad + "";

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
            txtCaracteristica1.Text = pantalla.pulgadas + "";

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

        // ACCIONES BOTONES
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!AceptarSolicitud())
            {
                MostrarMensajeErrorAceptarSolicitud();
            }
            else
            {
                MostrarMensajeExitoAceptarSolicitud();
            }
        }  
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!RechazarSolicitud())
            {
                MostrarMensajeFalloRechazarSolicitud();
            }
            else
            {
                MostarMensajeExitoRechazarSolicitud();
            }
        }  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // ACCIONES PARA LAS SOLICITUDES
        private bool AceptarSolicitud()
        {
            return new SolicitudManagement().aceptarSolicitud(txtCorreo.Text, txtNumSerie.Text);
        }      
        private bool RechazarSolicitud()
        {
            return new SolicitudManagement().rechazarSolicitud(txtCorreo.Text, txtNumSerie.Text);
        }

        // MENSAJES DE INFORMACION
        private static void MostrarMensajeExitoAceptarSolicitud()
        {
            MessageBox.Show("Se ha aceptado la solicitud con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static void MostrarMensajeErrorAceptarSolicitud()
        {
            MessageBox.Show("No se ha podido aceptar la solicitud", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static void MostarMensajeExitoRechazarSolicitud()
        {
            MessageBox.Show("Se ha rechazado la solicitud con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static void MostrarMensajeFalloRechazarSolicitud()
        {
            MessageBox.Show("No se ha podido rechazar la solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
