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

        private void mostrarCaracteristicas(string numeroSerie)
        {/*
            Negocio.EntitiesDTO.Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numeroSerie);
            if (dispositivo.caracteristica.GetType() == typeof(HWRed))
            {
                HWRed aux = new HWManagement().ObtenerHWRed(numeroSerie);
                lblCategoria1.Text = "Nº Puertos";
                txtCategoria.Text = aux.numPuertos + "";
                label2.Text = "Velocidad";
                txtCategoria2.Text = aux.velocidad + "";

            }
            else if (dispositivo.caracteristica.GetType() == typeof(Ordenador))
            {
                Ordenador ordenador = new OrdenadorManagement().ObtenerOrdenador(numeroSerie);
                lblCategoria1.Text = "Procesador";
                txtCategoria1.Text = ordenador.procesador;
                lblCategoria2.Text = "RAM";
                txtCategoria2.Text = ordenador.ram;
                lblCategoria3.Text = "Disco Principal";
                txtCategoria3.Text = ordenador.discoSecundario;
            }
            else if (dispositivo.caracteristica.GetType() == typeof(Pantalla))
            {
                Pantalla pantalla = new PantallaManagement().ObtenerPantalla(numeroSerie);
                lblCategoria1.Text = "Pulgadas";
                txtCategoria1.Text = pantalla.pulgadas + "";
            }*/
        }

        private void mostrarDispositivo(string numeroSerie)
        {
            Negocio.EntitiesDTO.Dispositivo dispositivo = new DispositivoManagement().ObtenerDispositivo(numeroSerie);
            Categoria categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

            string estado = formatearEstado(dispositivo.estado);

            txtNumSerie.Text = dispositivo.numSerie;
            txtCategoria.Text = categoria.nombre;
            txtMarca.Text = dispositivo.marca;
            txtModelo.Text = dispositivo.modelo;
            txtEstado.Text = estado;
            txtLocalizacion.Text = dispositivo.localizacion;

         
            
        }


        private string formatearEstado(string estadoBD)
        {
            string estado = "";

            switch (estadoBD)
            {
                case "O":
                    estado = "Ocupado";
                    break;
                case "D":
                    estado = "Disponible";
                    break;
                case "I":
                    estado = "Instalado";
                    break;
                default:
                    break;
            }

            return estado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }
    }
}
