﻿using Negocio.EntitiesDTO;
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
    public partial class FiltroEstado : Form
    {
        public Filtrar filtro { get; set; }
        public FiltroEstado(Filtrar filtro)
        {
            InitializeComponent();
            cargarListBox();
            this.filtro = filtro;
        }

        public void cargarListBox()
        {
            List<DispositivoDTO> listaDispositivos = new DispositivoManagement().ObtenerDispositivos();

            List<string> listaEstados = new List<string>();
            foreach (DispositivoDTO dispositivo in listaDispositivos)
            {
                string estado = formatearEstado(dispositivo.estado);
                if (!listaEstados.Contains(estado))
                {
                    listaEstados.Add(estado);
                }

            }


            foreach (string estado in listaEstados)
            {
                tablaFiltroDispositivos.Rows.Add(estado);
            }

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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> localizaciones = new List<string>();

            foreach (DataGridViewRow fila in tablaFiltroDispositivos.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    String marcaStr = fila.Cells[0].Value.ToString();
                    localizaciones.Add(marcaStr);
                }
            }
            filtro.listaParaFiltrar = localizaciones;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
