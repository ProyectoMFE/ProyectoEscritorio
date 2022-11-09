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
    public partial class Dispositivos : Form
    {
        public Dispositivos()
        {
            InitializeComponent();
            RellenarTabla();
        }

        public void RellenarTabla()
        {
            List<DispositivoDTO>dispositivos = new DispositivoManagement().ObtenerDispositivos();

            
            foreach (DispositivoDTO dispositivo in dispositivos)
            {
                string estado="";
                switch (dispositivo.estado)
                {
                    case "O":
                        estado = "Ocupado";
                        break;
                    case "D":
                        estado = "Disponible";
                        break ;
                    case "I":
                        estado = "Instalado";
                        break;
                    default:
                        break;
                }
                CategoriaDTO categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

                tablaDispositivos.Rows.Add(categoria.nombre, dispositivo.marca,dispositivo.modelo,estado,dispositivo.localizacion);

            }
        }
    }
}
