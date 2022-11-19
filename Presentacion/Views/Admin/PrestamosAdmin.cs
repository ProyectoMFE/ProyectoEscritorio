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
    public partial class PrestamosAdmin : Form
    {
        public PrestamosAdmin()
        {
            InitializeComponent();
            CargarTabla();
        }

        private void CargarTabla()
        {
            List<Solicitud> solicitudes = new SolicitudManagement().listarSolicitudes();
            Dispositivo dispositivo;
            Usuario usuario;
            Categoria categoria;
            foreach (Solicitud solicitud in solicitudes)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                usuario = new UsuarioManagement().ObtenerUsuario(solicitud.idUsuario);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);
                tablaDispositivos.Rows.Add(dispositivo.numSerie, categoria.nombre, dispositivo.marca, usuario.nombre, dispositivo.localizacion, dispositivo.estado);
            }
        }
    }
}
