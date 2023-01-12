
namespace Presentacion.Views
{
    partial class FiltroEstado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablaFiltroDispositivos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Dispositivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filtrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCerrar = new Presentacion.Controles.BotonPropio();
            this.btnFiltar = new Presentacion.Controles.BotonPropio();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFiltroDispositivos)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaFiltroDispositivos
            // 
            this.tablaFiltroDispositivos.AllowUserToAddRows = false;
            this.tablaFiltroDispositivos.AllowUserToDeleteRows = false;
            this.tablaFiltroDispositivos.AllowUserToResizeColumns = false;
            this.tablaFiltroDispositivos.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.tablaFiltroDispositivos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaFiltroDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.tablaFiltroDispositivos.ColumnHeadersHeight = 15;
            this.tablaFiltroDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablaFiltroDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dispositivo,
            this.Filtrar});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaFiltroDispositivos.DefaultCellStyle = dataGridViewCellStyle9;
            this.tablaFiltroDispositivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaFiltroDispositivos.Location = new System.Drawing.Point(99, 36);
            this.tablaFiltroDispositivos.Name = "tablaFiltroDispositivos";
            this.tablaFiltroDispositivos.RowHeadersVisible = false;
            this.tablaFiltroDispositivos.Size = new System.Drawing.Size(304, 302);
            this.tablaFiltroDispositivos.TabIndex = 12;
            this.tablaFiltroDispositivos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaFiltroDispositivos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tablaFiltroDispositivos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablaFiltroDispositivos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablaFiltroDispositivos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablaFiltroDispositivos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablaFiltroDispositivos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tablaFiltroDispositivos.ThemeStyle.HeaderStyle.Height = 15;
            this.tablaFiltroDispositivos.ThemeStyle.ReadOnly = false;
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.Height = 22;
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaFiltroDispositivos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Dispositivo
            // 
            this.Dispositivo.HeaderText = "Estado";
            this.Dispositivo.Name = "Dispositivo";
            this.Dispositivo.ReadOnly = true;
            // 
            // Filtrar
            // 
            this.Filtrar.HeaderText = "Filtrar";
            this.Filtrar.Name = "Filtrar";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Brown;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(38, 381);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 50);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnFiltar
            // 
            this.btnFiltar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFiltar.FlatAppearance.BorderSize = 0;
            this.btnFiltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltar.ForeColor = System.Drawing.Color.White;
            this.btnFiltar.Location = new System.Drawing.Point(298, 381);
            this.btnFiltar.Name = "btnFiltar";
            this.btnFiltar.Size = new System.Drawing.Size(150, 50);
            this.btnFiltar.TabIndex = 18;
            this.btnFiltar.Text = "Filtrar";
            this.btnFiltar.UseVisualStyleBackColor = false;
            this.btnFiltar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FiltroEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFiltar);
            this.Controls.Add(this.tablaFiltroDispositivos);
            this.Name = "FiltroEstado";
            this.Text = "FiltroEstado";
            ((System.ComponentModel.ISupportInitialize)(this.tablaFiltroDispositivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView tablaFiltroDispositivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dispositivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Filtrar;
        private Controles.BotonPropio btnCerrar;
        private Controles.BotonPropio btnFiltar;
    }
}