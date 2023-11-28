namespace Imperial
{
    partial class FMantenimiento
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTipoNave = new System.Windows.Forms.ListBox();
            this.labelMantenimiento = new System.Windows.Forms.Label();
            this.dgvNave = new System.Windows.Forms.DataGridView();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbCapitan = new System.Windows.Forms.TextBox();
            this.tbPlanetaFabricacion = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelCapitan = new System.Windows.Forms.Label();
            this.labelPlanetaFabricacion = new System.Windows.Forms.Label();
            this.bInserta = new System.Windows.Forms.Button();
            this.bModifica = new System.Windows.Forms.Button();
            this.bBorra = new System.Windows.Forms.Button();
            this.bLimpia = new System.Windows.Forms.Button();
            this.lbTipoNaveMostrado = new System.Windows.Forms.ListBox();
            this.labelTipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNave)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTipoNave
            // 
            this.lbTipoNave.FormattingEnabled = true;
            this.lbTipoNave.Location = new System.Drawing.Point(12, 51);
            this.lbTipoNave.Name = "lbTipoNave";
            this.lbTipoNave.Size = new System.Drawing.Size(120, 147);
            this.lbTipoNave.TabIndex = 0;
            this.lbTipoNave.SelectedIndexChanged += new System.EventHandler(this.lbTipoNave_SelectedIndexChanged);
            // 
            // labelMantenimiento
            // 
            this.labelMantenimiento.AutoSize = true;
            this.labelMantenimiento.Location = new System.Drawing.Point(312, 9);
            this.labelMantenimiento.Name = "labelMantenimiento";
            this.labelMantenimiento.Size = new System.Drawing.Size(98, 13);
            this.labelMantenimiento.TabIndex = 1;
            this.labelMantenimiento.Text = "MANTENIMIENTO";
            // 
            // dgvNave
            // 
            this.dgvNave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNave.Location = new System.Drawing.Point(147, 51);
            this.dgvNave.Name = "dgvNave";
            this.dgvNave.Size = new System.Drawing.Size(535, 150);
            this.dgvNave.TabIndex = 2;
            this.dgvNave.SelectionChanged += new System.EventHandler(this.dgvNave_SelectionChanged);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(147, 240);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(288, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // tbCapitan
            // 
            this.tbCapitan.Location = new System.Drawing.Point(147, 292);
            this.tbCapitan.Name = "tbCapitan";
            this.tbCapitan.Size = new System.Drawing.Size(288, 20);
            this.tbCapitan.TabIndex = 4;
            // 
            // tbPlanetaFabricacion
            // 
            this.tbPlanetaFabricacion.Location = new System.Drawing.Point(147, 346);
            this.tbPlanetaFabricacion.Name = "tbPlanetaFabricacion";
            this.tbPlanetaFabricacion.Size = new System.Drawing.Size(288, 20);
            this.tbPlanetaFabricacion.TabIndex = 5;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(34, 243);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(57, 13);
            this.labelNombre.TabIndex = 6;
            this.labelNombre.Text = "NOMBRE:";
            // 
            // labelCapitan
            // 
            this.labelCapitan.AutoSize = true;
            this.labelCapitan.Location = new System.Drawing.Point(34, 295);
            this.labelCapitan.Name = "labelCapitan";
            this.labelCapitan.Size = new System.Drawing.Size(56, 13);
            this.labelCapitan.TabIndex = 7;
            this.labelCapitan.Text = "CAPITAN:";
            // 
            // labelPlanetaFabricacion
            // 
            this.labelPlanetaFabricacion.AutoSize = true;
            this.labelPlanetaFabricacion.Location = new System.Drawing.Point(34, 349);
            this.labelPlanetaFabricacion.Name = "labelPlanetaFabricacion";
            this.labelPlanetaFabricacion.Size = new System.Drawing.Size(85, 13);
            this.labelPlanetaFabricacion.TabIndex = 8;
            this.labelPlanetaFabricacion.Text = "PLANETA FAB.:";
            // 
            // bInserta
            // 
            this.bInserta.Location = new System.Drawing.Point(37, 414);
            this.bInserta.Name = "bInserta";
            this.bInserta.Size = new System.Drawing.Size(75, 23);
            this.bInserta.TabIndex = 9;
            this.bInserta.Text = "INSERTA";
            this.bInserta.UseVisualStyleBackColor = true;
            this.bInserta.Click += new System.EventHandler(this.bInserta_Click);
            // 
            // bModifica
            // 
            this.bModifica.Location = new System.Drawing.Point(147, 414);
            this.bModifica.Name = "bModifica";
            this.bModifica.Size = new System.Drawing.Size(75, 23);
            this.bModifica.TabIndex = 10;
            this.bModifica.Text = "MODIFICA";
            this.bModifica.UseVisualStyleBackColor = true;
            this.bModifica.Click += new System.EventHandler(this.bModifica_Click);
            // 
            // bBorra
            // 
            this.bBorra.Location = new System.Drawing.Point(257, 414);
            this.bBorra.Name = "bBorra";
            this.bBorra.Size = new System.Drawing.Size(75, 23);
            this.bBorra.TabIndex = 11;
            this.bBorra.Text = "BORRA";
            this.bBorra.UseVisualStyleBackColor = true;
            this.bBorra.Click += new System.EventHandler(this.bBorra_Click);
            // 
            // bLimpia
            // 
            this.bLimpia.Location = new System.Drawing.Point(360, 414);
            this.bLimpia.Name = "bLimpia";
            this.bLimpia.Size = new System.Drawing.Size(75, 23);
            this.bLimpia.TabIndex = 12;
            this.bLimpia.Text = "LIMPIA";
            this.bLimpia.UseVisualStyleBackColor = true;
            this.bLimpia.Click += new System.EventHandler(this.bLimpia_Click);
            // 
            // lbTipoNaveMostrado
            // 
            this.lbTipoNaveMostrado.FormattingEnabled = true;
            this.lbTipoNaveMostrado.Location = new System.Drawing.Point(517, 240);
            this.lbTipoNaveMostrado.Name = "lbTipoNaveMostrado";
            this.lbTipoNaveMostrado.Size = new System.Drawing.Size(165, 134);
            this.lbTipoNaveMostrado.TabIndex = 14;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(476, 246);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(35, 13);
            this.labelTipo.TabIndex = 13;
            this.labelTipo.Text = "TIPO:";
            // 
            // FMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 463);
            this.Controls.Add(this.lbTipoNaveMostrado);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.bLimpia);
            this.Controls.Add(this.bBorra);
            this.Controls.Add(this.bModifica);
            this.Controls.Add(this.bInserta);
            this.Controls.Add(this.labelPlanetaFabricacion);
            this.Controls.Add(this.labelCapitan);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.tbPlanetaFabricacion);
            this.Controls.Add(this.tbCapitan);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.dgvNave);
            this.Controls.Add(this.labelMantenimiento);
            this.Controls.Add(this.lbTipoNave);
            this.Name = "FMantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.FMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTipoNave;
        private System.Windows.Forms.Label labelMantenimiento;
        private System.Windows.Forms.DataGridView dgvNave;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbCapitan;
        private System.Windows.Forms.TextBox tbPlanetaFabricacion;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCapitan;
        private System.Windows.Forms.Label labelPlanetaFabricacion;
        private System.Windows.Forms.Button bInserta;
        private System.Windows.Forms.Button bModifica;
        private System.Windows.Forms.Button bBorra;
        private System.Windows.Forms.Button bLimpia;
        private System.Windows.Forms.ListBox lbTipoNaveMostrado;
        private System.Windows.Forms.Label labelTipo;
    }
}

