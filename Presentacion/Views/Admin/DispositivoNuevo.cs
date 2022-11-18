using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Negocio.EntitiesDTO;
using Negocio.Management;

namespace Presentacion.Views.Admin
{
    public partial class DispositivoNuevo : Form
    {

        private List<KeyValuePair<string, int>> categoriasValorNombre;
        public DispositivoNuevo()
        {
            InitializeComponent();
            cargarListaCategorias();
        }

        // CARGAR LAS CATEGORIAS EXISTENTES EN EL COMOBOX
        private void cargarListaCategorias()
        {
            List<Categoria> categorias = new CategoriaManagement().ObtenerCategorias();

            categoriasValorNombre = new List<KeyValuePair<string, int>>();

            foreach (Categoria categoria in categorias)
            {
                var valor = new KeyValuePair<string, int>(categoria.nombre, categoria.idCategoria);
                categoriasValorNombre.Add(valor);


            }

            comboBoxCategoria.DataSource = null;
            comboBoxCategoria.DataSource = new BindingSource(categoriasValorNombre, null);
            comboBoxCategoria.DisplayMember = "Key";
            comboBoxCategoria.ValueMember = "Value";

        }

        // MOSTRAR LAS CARACTERISTICAS ESPECIFICAS SEGUN LA CATEGORIA SELECCIONADA
        private void comboBoxCategoria_SelectedValueChanged(object sender, EventArgs e)
        {

            KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;

            string categoriaSeleccionada = seleccionado.Key;


            switch (categoriaSeleccionada)
            {
                case "Switch":
                    MostrarCaracteristicasHardwareRed();
                    break;
                case "Ordenador":
                    MostrarCaracteristicasOrdenador();
                    break;
                case "Pantalla":
                    MostrarCaracteristicasPantalla();
                    break;
                default:
                    MostrarCaracteristicasComponente();
                    break;
            }

        }
        private void MostrarCaracteristicasHardwareRed()
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Nº Puertos";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "Velocidad";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = "";

            lblCaracteristica3.Visible = false;
            txtCaracteristica3.Visible = false;

            lblCaracteristica4.Visible = false;
            txtCaracteristica4.Visible = false;
        }
        private void MostrarCaracteristicasOrdenador()
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Procesador";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

            lblCaracteristica2.Visible = true;
            lblCaracteristica2.Text = "RAM";
            txtCaracteristica2.Visible = true;
            txtCaracteristica2.Text = "";

            lblCaracteristica3.Visible = true;
            lblCaracteristica3.Text = "Disco 1";
            txtCaracteristica3.Visible = true;
            txtCaracteristica3.Text = "";

            lblCaracteristica4.Visible = true;
            lblCaracteristica4.Text = "Disco 2";
            txtCaracteristica4.Visible = true;
            txtCaracteristica4.Text = "";
        }
        private void MostrarCaracteristicasPantalla()
        {
            panelCaracteristicas.Visible = true;

            lblCaracteristica1.Visible = true;
            lblCaracteristica1.Text = "Pulgadas";
            txtCaracteristica1.Visible = true;
            txtCaracteristica1.Text = "";

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

        // SALIR DEL FORMULARIO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // AGREGAR DISPOSITIVO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;

            if (!ComprobarCampos())
            {
                MessageBox.Show("HAY CAMPOS VACIOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string categoriaSeleccionada = seleccionado.Key;
            switch (categoriaSeleccionada)
            {
                case "Ordenador":
                    InsertarOrdenador();
                    break;
                case "Switch":
                    InsertarHWRed();
                    break;
                case "Pantalla":
                    InsertarPantalla();
                    break;
                default:
                    InsertarDispositivo();
                    break;
            }

        }

        private void InsertarDispositivo()
        {

            KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;
            string estadoFormateado = EstadoFormateado(comboBoxEstado.SelectedItem.ToString());


            Dispositivo dispositivo = new Dispositivo()
            {
                numSerie = txtNumSerie.Text,
                idCategoria = seleccionado.Value,
                marca = txtMarca.Text,
                modelo = txtModelo.Text,
                localizacion = txtLocalizacion.Text,
                estado = estadoFormateado,
                idCategoriaNavigation = null,
                hwRed = null,
                ordenadores = null,
                pantallas = null,
                solicitudes = null
            };

            bool exito;
            exito = new DispositivoManagement().InsertarDispositivo(dispositivo);
            if (!exito)
            {
                MostrarErrorInsertartDispositivo();
                return;
            }
            MostrarExitoInsertarDispositivo();
        }

        private void InsertarPantalla()
        {

            if (ComprobarCaracteristicasPantalla())
            {
                KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;
                string estadoFormateado = EstadoFormateado(comboBoxEstado.SelectedItem.ToString());

                Pantalla pantalla = new Pantalla()
                {
                    numSerie = txtNumSerie.Text,
                    pulgadas = Convert.ToInt32(txtCaracteristica1.Text)
                };

                Dispositivo dispositivo = new Dispositivo()
                {
                    numSerie = txtNumSerie.Text,
                    idCategoria = seleccionado.Value,
                    marca = txtMarca.Text,
                    modelo = txtModelo.Text,
                    localizacion = txtLocalizacion.Text,
                    estado = estadoFormateado,
                    idCategoriaNavigation = null,
                    hwRed = null,
                    ordenadores = null,
                    pantallas = pantalla,
                    solicitudes = null
                };

                bool exito;
                exito = new DispositivoManagement().InsertarDispositivo(dispositivo);
                if (!exito)
                {
                    MostrarErrorInsertartDispositivo();
                    return;
                }
                MostrarExitoInsertarDispositivo();
            }
            else
            {
                MessageBox.Show("Los campos de las caracteristicas estan vacios o contienen letras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void InsertarOrdenador()
        {
            if (ComprobarCaracteristicasOrdenador())
            {
                KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;
                string estadoFormateado = EstadoFormateado(comboBoxEstado.SelectedItem.ToString());

                Ordenador ordenador = new Ordenador()
                {
                    numSerie = txtNumSerie.Text,
                    procesador = txtCaracteristica1.Text,
                    ram = txtCaracteristica2.Text,
                    discoPrincipal = txtCaracteristica3.Text,
                    discoSecundario = txtCaracteristica4.Text,
                };

                Dispositivo dispositivo = new Dispositivo()
                {
                    numSerie = txtNumSerie.Text,
                    idCategoria = seleccionado.Value,
                    marca = txtMarca.Text,
                    modelo = txtModelo.Text,
                    localizacion = txtLocalizacion.Text,
                    estado = estadoFormateado,
                    idCategoriaNavigation = null,
                    hwRed = null,
                    ordenadores = ordenador,
                    pantallas = null,
                    solicitudes = null
                };

                bool exito;
                exito = new DispositivoManagement().InsertarDispositivo(dispositivo);
                if (!exito)
                {
                    MessageBox.Show("NO SE HA PODIDO INSERTAR EL ORDENAOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("EL ORDENADOR SE HA AÑADIDO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los campos de las caracteristicas estan vacios o contienen letras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ComprobarCaracteristicasOrdenador()
        {
            bool campoVacio;

            campoVacio = IsEmpty(txtCaracteristica1.Text);
            if (campoVacio)
            {
                return false;
            }
            campoVacio = IsEmpty(txtCaracteristica2.Text);
            if (campoVacio)
            {
                return false;
            }
            campoVacio = IsEmpty(txtCaracteristica3.Text);
            if (campoVacio)
            {
                return false;
            }
            campoVacio = IsEmpty(txtCaracteristica4.Text);
            if (campoVacio)
            {
                return false;
            }

            return true;


        }


        private void InsertarHWRed()
        {
            if (ComprobarCaracteristicasHWRed())
            {
                KeyValuePair<string, int> seleccionado = (KeyValuePair<string, int>)comboBoxCategoria.SelectedItem;
                string estadoFormateado = EstadoFormateado(comboBoxEstado.SelectedItem.ToString());

                HWRed hwRed = new HWRed()
                {
                    numSerie = txtNumSerie.Text,
                    numPuertos = Convert.ToInt32(txtCaracteristica1.Text),
                    velocidad = Convert.ToInt32(txtCaracteristica2.Text)

                };

                Dispositivo dispositivo = new Dispositivo()
                {
                    numSerie = txtNumSerie.Text,
                    idCategoria = seleccionado.Value,
                    marca = txtMarca.Text,
                    modelo = txtModelo.Text,
                    localizacion = txtLocalizacion.Text,
                    estado = estadoFormateado,
                    idCategoriaNavigation = null,
                    hwRed = hwRed,
                    ordenadores = null,
                    pantallas = null,
                    solicitudes = null
                };

                bool exito;
                exito = new DispositivoManagement().InsertarDispositivo(dispositivo);
                if (!exito)
                {
                    MessageBox.Show("NO SE HA PODIDO INSERTAR EL SWITCH", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MostrarExitoInsertarDispositivo();
            }
            else
            {
                MostarErrorCaracteristicas();
            }
        }
        private bool ComprobarCaracteristicasHWRed()
        {
            string pattern = "\\d*";
            Regex rx = new Regex(pattern);

            bool campoVacio, campoConTexto;

            campoVacio = IsEmpty(txtCaracteristica1.Text);
            campoConTexto = rx.IsMatch(txtCaracteristica1.Text);
            if (campoVacio)
            {
                return false;
            }
            if (!campoConTexto)
            {
                return false;
            }

            campoVacio = IsEmpty(txtCaracteristica2.Text);
            campoConTexto = rx.IsMatch(txtCaracteristica2.Text);
            if (campoVacio)
            {
                return false;
            }
            if (!campoConTexto)
            {
                return false;
            }

            return true;
        }

        public bool ComprobarCampos()
        {
            bool campoVacio;

            campoVacio = IsEmpty(txtNumSerie.Text);
            if (campoVacio)
            {
                return false;
            }

            campoVacio = IsEmpty(comboBoxCategoria.SelectedItem.ToString());
            if (campoVacio)
            {
                return false;
            }

            campoVacio = IsEmpty(txtMarca.Text);
            if (campoVacio)
            {
                return false;
            }

            campoVacio = IsEmpty(txtModelo.Text);
            if (campoVacio)
            {
                return false;
            }

            campoVacio = IsEmpty(txtLocalizacion.Text);
            if (campoVacio)
            {
                return false;
            }

            campoVacio = IsEmpty(comboBoxEstado.SelectedItem.ToString());
            if (campoVacio)
            {
                return false;
            }

            return true;
        }

        public bool IsEmpty(string campo)
        {
            return campo == "";
        }

        public string EstadoFormateado(string estado)
        {
            string estadoFormateado;

            if (estado.Equals("Disponible"))
            {
                estadoFormateado = "D";
            }
            else
            {
                estadoFormateado = "I";
            }

            return estadoFormateado;
        }

        private void MostarErrorCaracteristicas()
        {
            MessageBox.Show("ERROR EN LAS CARACTERISTICAS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarExitoInsertarDispositivo()
        {
            MessageBox.Show("EL DISPOSITIVO SE HA AÑADIDO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MostrarErrorInsertartDispositivo() {
            MessageBox.Show("NO SE HA PODIDO INSERTAR EL DISPOSITIVO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


}
