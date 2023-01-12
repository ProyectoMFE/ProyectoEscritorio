using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Controles
{
    public partial class BotonPropio : Button
    {
        public BotonPropio()
        {
            InitializeComponent();
            BackColor = Color.AliceBlue;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ForeColor = Color.White;
            Name = "btnPropio";
            Size = new System.Drawing.Size(150, 50);
            TabIndex = 2;
            Text = "Boton Propio";
            UseVisualStyleBackColor = false;
        }
    }
}
