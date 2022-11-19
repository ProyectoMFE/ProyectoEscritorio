using Negocio.EntitiesDTO;
using Negocio.Management;
using System;
using System.Windows.Forms;

namespace Presentacion.Views
{
    public partial class DispositivoProfesor : Form
    {
        public DispositivoProfesor(string numeroSerie)
        {
            InitializeComponent();
            mostrarDispositivo(numeroSerie);
            mostrarCaracteristicas(numeroSerie);
        }
        private void mostrarDispositivo(string numeroSerie)
        {
            Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numeroSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

            txtNumSerie.Text = dispositivo.numSerie;
            txtCategoria.Text = categoria.nombre;
            txtMarca.Text = dispositivo.marca;
            txtModelo.Text = dispositivo.modelo;
            txtEstado.Text = dispositivo.estado;
            txtLocalizacion.Text = dispositivo.localizacion;
        }
        private void mostrarCaracteristicas(string numeroSerie)
        {
            Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numeroSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
            switch (categoria.nombre)
            {
                case "Switch":
                    MostarCaracteristicasSwitch(dispositivo.numSerie);
                    break;
                case "Ordenador":
                    MostrarCaracteristicasOrdenador(dispositivo.numSerie);
                    break;
                case "Pantalla":
                    MostarCaracteristicasPantalla(dispositivo.numSerie);
                    break;
                default:
                    guna2Panel2.Visible = false;
                    break;
            }           
        }
        private void MostarCaracteristicasSwitch(string numSerie)
        {
            HWRed aux = new HWManagement().ObtenerHWRed(numSerie);

            lblCategoria1.Text = "Nº Puertos";
            txtCategoria.Text = aux.numPuertos + "";

            lblCategoria2.Text = "Velocidad";
            txtCategoria2.Text = aux.velocidad + "";

            lblCategoria3.Visible = false;
            txtCategoria3.Visible = false;
            lblCategoria4.Visible = false;
            txtCategoria4.Visible = false;


        }
        private void MostrarCaracteristicasOrdenador(string numSerie)
        {
            Ordenador ordenador = new OrdenadorManagement().ObtenerOrdenador(numSerie);

            lblCategoria1.Visible= true;
            lblCategoria1.Text = "Procesador";

            txtCategoria1.Visible = true;
            txtCategoria1.Text = ordenador.procesador;

            lblCategoria2.Visible = true;
            lblCategoria2.Text = "RAM";

            txtCategoria2.Visible = true;
            txtCategoria2.Text = ordenador.ram;

            lblCategoria3.Visible = true;
            lblCategoria3.Text = "Disco Principal";

            txtCategoria3.Visible = true;
            txtCategoria3.Text = ordenador.discoPrincipal;

            lblCategoria4.Visible = true;
            lblCategoria4.Text = "Disco Secundario";

            txtCategoria4.Visible = true;
            txtCategoria4.Text = ordenador.discoSecundario;
        }
        private void MostarCaracteristicasPantalla(string numSerie)
        {
            Pantalla pantalla = new PantallaManagement().ObtenerPantalla(numSerie);
            lblCategoria1.Visible = true;
            lblCategoria1.Text = "Pulgadas";

            txtCategoria1.Visible = true;
            txtCategoria1.Text = pantalla.pulgadas + "";

            lblCategoria2.Visible = false;
            txtCategoria2.Visible = false;

            lblCategoria3.Visible = false;
            txtCategoria3.Visible = false;

            lblCategoria4.Visible = false;
            txtCategoria4.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            bool exito = new SolicitudManagement().insertarSolicitud(Login.instanciaLogin.correo, txtNumSerie.Text);
            if (exito)
            {
                MessageBox.Show("Prueba con exito");
            }
            else
            {
                MessageBox.Show("Prueba fallida");
            }
        }
    }
}
