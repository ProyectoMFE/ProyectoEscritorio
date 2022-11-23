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
    public partial class SolicitudesAdmin : Form
    {
        public SolicitudesAdmin()
        {
            InitializeComponent();
            cargarTabla();
        }

        private void cargarTabla()
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
                tablaDispositivos.Rows.Add(dispositivo.numSerie,usuario.correo, categoria.nombre, dispositivo.marca, usuario.nombre, dispositivo.localizacion, dispositivo.estado);
            }
        }

        private void tablaDispositivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = tablaDispositivos.Rows[e.RowIndex];
            string numSerie = fila.Cells[0].Value.ToString();
            string correo = fila.Cells[1].Value.ToString();

            SolicitudAdmin solicitudAdmin= new SolicitudAdmin(correo,numSerie);
            solicitudAdmin.ShowDialog();
        }
    }
}
