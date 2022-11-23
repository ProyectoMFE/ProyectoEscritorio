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

namespace Presentacion.Views.Admin
{
    public partial class SolicitudAdmin : Form
    {
        public SolicitudAdmin(string correo, string numSerie)
        {
            InitializeComponent();
            mostrarDatos(correo, numSerie);
        }

        private void mostrarDatos(string correo, string numSerie)
        {
            Solicitud solicitud = new SolicitudManagement().obtenerSolicitud(correo, numSerie);
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
        }
    }
}
