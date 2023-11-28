namespace Canciones2223
{
    partial class Form1
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
            this.tExit = new System.Windows.Forms.Button();
            this.tInsertar = new System.Windows.Forms.Button();
            this.tModificar = new System.Windows.Forms.Button();
            this.tLimpiar = new System.Windows.Forms.Button();
            this.tBorrar = new System.Windows.Forms.Button();
            this.tCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lMotivo = new System.Windows.Forms.ListBox();
            this.lCentro = new System.Windows.Forms.ListBox();
            this.tID = new System.Windows.Forms.TextBox();
            this.tNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tSeleccionar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tExit
            // 
            this.tExit.Location = new System.Drawing.Point(730, 556);
            this.tExit.Name = "tExit";
            this.tExit.Size = new System.Drawing.Size(75, 23);
            this.tExit.TabIndex = 0;
            this.tExit.Text = "Salir";
            this.tExit.UseVisualStyleBackColor = true;
            this.tExit.Click += new System.EventHandler(this.tExit_Click);
            // 
            // tInsertar
            // 
            this.tInsertar.Location = new System.Drawing.Point(37, 556);
            this.tInsertar.Name = "tInsertar";
            this.tInsertar.Size = new System.Drawing.Size(75, 23);
            this.tInsertar.TabIndex = 1;
            this.tInsertar.Text = "Insertar";
            this.tInsertar.UseVisualStyleBackColor = true;
            this.tInsertar.Click += new System.EventHandler(this.tInsertar_Click);
            // 
            // tModificar
            // 
            this.tModificar.Location = new System.Drawing.Point(213, 556);
            this.tModificar.Name = "tModificar";
            this.tModificar.Size = new System.Drawing.Size(75, 23);
            this.tModificar.TabIndex = 2;
            this.tModificar.Text = "Modificar";
            this.tModificar.UseVisualStyleBackColor = true;
            this.tModificar.Click += new System.EventHandler(this.tModificar_Click);
            // 
            // tLimpiar
            // 
            this.tLimpiar.Location = new System.Drawing.Point(554, 556);
            this.tLimpiar.Name = "tLimpiar";
            this.tLimpiar.Size = new System.Drawing.Size(75, 23);
            this.tLimpiar.TabIndex = 3;
            this.tLimpiar.Text = "Limpiar";
            this.tLimpiar.UseVisualStyleBackColor = true;
            this.tLimpiar.Click += new System.EventHandler(this.tLimpiar_Click);
            // 
            // tBorrar
            // 
            this.tBorrar.Location = new System.Drawing.Point(388, 556);
            this.tBorrar.Name = "tBorrar";
            this.tBorrar.Size = new System.Drawing.Size(75, 23);
            this.tBorrar.TabIndex = 4;
            this.tBorrar.Text = "Borrar";
            this.tBorrar.UseVisualStyleBackColor = true;
            this.tBorrar.Click += new System.EventHandler(this.tBorrar_Click);
            // 
            // tCalendar
            // 
            this.tCalendar.Location = new System.Drawing.Point(37, 106);
            this.tCalendar.Name = "tCalendar";
            this.tCalendar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(274, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(599, 162);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lMotivo
            // 
            this.lMotivo.FormattingEnabled = true;
            this.lMotivo.Location = new System.Drawing.Point(519, 360);
            this.lMotivo.Name = "lMotivo";
            this.lMotivo.Size = new System.Drawing.Size(354, 82);
            this.lMotivo.TabIndex = 8;
            // 
            // lCentro
            // 
            this.lCentro.FormattingEnabled = true;
            this.lCentro.Location = new System.Drawing.Point(103, 360);
            this.lCentro.Name = "lCentro";
            this.lCentro.Size = new System.Drawing.Size(302, 82);
            this.lCentro.TabIndex = 9;
            // 
            // tID
            // 
            this.tID.Location = new System.Drawing.Point(103, 310);
            this.tID.Name = "tID";
            this.tID.ReadOnly = true;
            this.tID.Size = new System.Drawing.Size(302, 20);
            this.tID.TabIndex = 10;
            // 
            // tNumero
            // 
            this.tNumero.Location = new System.Drawing.Point(103, 474);
            this.tNumero.Name = "tNumero";
            this.tNumero.Size = new System.Drawing.Size(302, 20);
            this.tNumero.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Centro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Motivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Numero";
            // 
            // tSeleccionar
            // 
            this.tSeleccionar.Location = new System.Drawing.Point(86, 58);
            this.tSeleccionar.Name = "tSeleccionar";
            this.tSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.tSeleccionar.TabIndex = 15;
            this.tSeleccionar.Text = "Seleccionar";
            this.tSeleccionar.UseVisualStyleBackColor = true;
            this.tSeleccionar.Click += new System.EventHandler(this.tSeleccionar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(380, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 46);
            this.label5.TabIndex = 16;
            this.label5.Text = "ASISTENCIAS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 628);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tSeleccionar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNumero);
            this.Controls.Add(this.tID);
            this.Controls.Add(this.lCentro);
            this.Controls.Add(this.lMotivo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tCalendar);
            this.Controls.Add(this.tBorrar);
            this.Controls.Add(this.tLimpiar);
            this.Controls.Add(this.tModificar);
            this.Controls.Add(this.tInsertar);
            this.Controls.Add(this.tExit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tExit;
        private System.Windows.Forms.Button tInsertar;
        private System.Windows.Forms.Button tModificar;
        private System.Windows.Forms.Button tLimpiar;
        private System.Windows.Forms.Button tBorrar;
        private System.Windows.Forms.MonthCalendar tCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lMotivo;
        private System.Windows.Forms.ListBox lCentro;
        private System.Windows.Forms.TextBox tID;
        private System.Windows.Forms.TextBox tNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tSeleccionar;
        private System.Windows.Forms.Label label5;
    }
}