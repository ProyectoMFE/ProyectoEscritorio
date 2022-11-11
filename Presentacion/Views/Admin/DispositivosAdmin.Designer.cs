
namespace Presentacion.Views
{
    partial class DispositivosAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.boton = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroModelo = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroMarca = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroEstado = new Guna.UI2.WinForms.Guna2Button();
            this.btnReiniciar = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroLocalizacion = new Guna.UI2.WinForms.Guna2Button();
            this.tablaDispositivos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReservar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDispositivos)).BeginInit();
            this.SuspendLayout();
            // 
            // boton
            // 
            this.boton.BorderRadius = 10;
            this.boton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.boton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.boton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.boton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.boton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.boton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton.ForeColor = System.Drawing.Color.White;
            this.boton.Location = new System.Drawing.Point(90, 50);
            this.boton.Name = "boton";
            this.boton.Size = new System.Drawing.Size(120, 45);
            this.boton.TabIndex = 10;
            this.boton.Text = "Dispositivo";
            this.boton.Click += new System.EventHandler(this.btnFiltroDispositivo_Click);
            // 
            // btnFiltroModelo
            // 
            this.btnFiltroModelo.BorderRadius = 10;
            this.btnFiltroModelo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroModelo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroModelo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltroModelo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltroModelo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnFiltroModelo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltroModelo.ForeColor = System.Drawing.Color.White;
            this.btnFiltroModelo.Location = new System.Drawing.Point(350, 50);
            this.btnFiltroModelo.Name = "btnFiltroModelo";
            this.btnFiltroModelo.Size = new System.Drawing.Size(120, 45);
            this.btnFiltroModelo.TabIndex = 11;
            this.btnFiltroModelo.Text = "Modelo";
            this.btnFiltroModelo.Click += new System.EventHandler(this.btnFiltroModelo_Click);
            // 
            // btnFiltroMarca
            // 
            this.btnFiltroMarca.BorderRadius = 10;
            this.btnFiltroMarca.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroMarca.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroMarca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltroMarca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltroMarca.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnFiltroMarca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltroMarca.ForeColor = System.Drawing.Color.White;
            this.btnFiltroMarca.Location = new System.Drawing.Point(220, 50);
            this.btnFiltroMarca.Name = "btnFiltroMarca";
            this.btnFiltroMarca.Size = new System.Drawing.Size(120, 45);
            this.btnFiltroMarca.TabIndex = 12;
            this.btnFiltroMarca.Text = "Marca";
            this.btnFiltroMarca.Click += new System.EventHandler(this.btnFiltroMarca_Click);
            // 
            // btnFiltroEstado
            // 
            this.btnFiltroEstado.BorderRadius = 10;
            this.btnFiltroEstado.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroEstado.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroEstado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltroEstado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltroEstado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.btnFiltroEstado.Location = new System.Drawing.Point(610, 50);
            this.btnFiltroEstado.Name = "btnFiltroEstado";
            this.btnFiltroEstado.Size = new System.Drawing.Size(120, 45);
            this.btnFiltroEstado.TabIndex = 13;
            this.btnFiltroEstado.Text = "Estado";
            this.btnFiltroEstado.Click += new System.EventHandler(this.btnFiltroEstado_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BorderRadius = 10;
            this.btnReiniciar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReiniciar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReiniciar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReiniciar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReiniciar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Location = new System.Drawing.Point(740, 50);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(120, 45);
            this.btnReiniciar.TabIndex = 14;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnFiltroLocalizacion
            // 
            this.btnFiltroLocalizacion.BorderRadius = 10;
            this.btnFiltroLocalizacion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroLocalizacion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltroLocalizacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFiltroLocalizacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFiltroLocalizacion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnFiltroLocalizacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltroLocalizacion.ForeColor = System.Drawing.Color.White;
            this.btnFiltroLocalizacion.Location = new System.Drawing.Point(480, 50);
            this.btnFiltroLocalizacion.Name = "btnFiltroLocalizacion";
            this.btnFiltroLocalizacion.Size = new System.Drawing.Size(120, 45);
            this.btnFiltroLocalizacion.TabIndex = 15;
            this.btnFiltroLocalizacion.Text = "Localizacion";
            this.btnFiltroLocalizacion.Click += new System.EventHandler(this.btnFiltroLocalizacion_Click);
            // 
            // tablaDispositivos
            // 
            this.tablaDispositivos.AllowUserToAddRows = false;
            this.tablaDispositivos.AllowUserToDeleteRows = false;
            this.tablaDispositivos.AllowUserToResizeColumns = false;
            this.tablaDispositivos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.tablaDispositivos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tablaDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.NumSerie,
            this.Marca,
            this.Modelo,
            this.Localizacion,
            this.Estado,
            this.btnReservar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaDispositivos.DefaultCellStyle = dataGridViewCellStyle6;
            this.tablaDispositivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaDispositivos.Location = new System.Drawing.Point(90, 228);
            this.tablaDispositivos.Name = "tablaDispositivos";
            this.tablaDispositivos.ReadOnly = true;
            this.tablaDispositivos.RowHeadersVisible = false;
            this.tablaDispositivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaDispositivos.Size = new System.Drawing.Size(770, 374);
            this.tablaDispositivos.TabIndex = 16;
            this.tablaDispositivos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaDispositivos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tablaDispositivos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablaDispositivos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablaDispositivos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablaDispositivos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablaDispositivos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaDispositivos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tablaDispositivos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaDispositivos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaDispositivos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablaDispositivos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablaDispositivos.ThemeStyle.HeaderStyle.Height = 23;
            this.tablaDispositivos.ThemeStyle.ReadOnly = true;
            this.tablaDispositivos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaDispositivos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaDispositivos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaDispositivos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaDispositivos.ThemeStyle.RowsStyle.Height = 22;
            this.tablaDispositivos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaDispositivos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaDispositivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDispositivos_CellContentClick);
            this.tablaDispositivos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDispositivos_CellContentDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // NumSerie
            // 
            this.NumSerie.HeaderText = "Dispositivo";
            this.NumSerie.Name = "NumSerie";
            this.NumSerie.ReadOnly = true;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // Localizacion
            // 
            this.Localizacion.HeaderText = "Localizacion";
            this.Localizacion.Name = "Localizacion";
            this.Localizacion.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // btnReservar
            // 
            this.btnReservar.HeaderText = "Reservar";
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(157)))), ((int)(((byte)(180)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(740, 622);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 45);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderRadius = 10;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.IconRight = global::Presentacion.Properties.Resources.search;
            this.txtBuscar.Location = new System.Drawing.Point(660, 157);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(200, 36);
            this.txtBuscar.TabIndex = 9;
            // 
            // DispositivosAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 691);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.tablaDispositivos);
            this.Controls.Add(this.btnFiltroLocalizacion);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnFiltroEstado);
            this.Controls.Add(this.btnFiltroMarca);
            this.Controls.Add(this.btnFiltroModelo);
            this.Controls.Add(this.boton);
            this.Controls.Add(this.txtBuscar);
            this.Name = "DispositivosAdmin";
            this.Text = "Dispositivos";
            ((System.ComponentModel.ISupportInitialize)(this.tablaDispositivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Button boton;
        private Guna.UI2.WinForms.Guna2Button btnFiltroModelo;
        private Guna.UI2.WinForms.Guna2Button btnFiltroMarca;
        private Guna.UI2.WinForms.Guna2Button btnFiltroEstado;
        private Guna.UI2.WinForms.Guna2Button btnReiniciar;
        private Guna.UI2.WinForms.Guna2Button btnFiltroLocalizacion;
        private Guna.UI2.WinForms.Guna2DataGridView tablaDispositivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn btnReservar;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
    }
}