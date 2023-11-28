namespace P2LINQ2SQL
{
    partial class Form1
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
            this.listBoxProveedores = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lProducto = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tPrecio = new System.Windows.Forms.TextBox();
            this.textCategoria = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bIns = new System.Windows.Forms.Button();
            this.bUpd = new System.Windows.Forms.Button();
            this.bClean = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxProveedores
            // 
            this.listBoxProveedores.FormattingEnabled = true;
            this.listBoxProveedores.Location = new System.Drawing.Point(79, 89);
            this.listBoxProveedores.Name = "listBoxProveedores";
            this.listBoxProveedores.Size = new System.Drawing.Size(211, 147);
            this.listBoxProveedores.TabIndex = 0;
            this.listBoxProveedores.SelectedIndexChanged += new System.EventHandler(this.listBoxProveedores_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(412, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(577, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(674, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Catálogo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proveedores";
            // 
            // lProducto
            // 
            this.lProducto.FormattingEnabled = true;
            this.lProducto.Location = new System.Drawing.Point(543, 306);
            this.lProducto.Name = "lProducto";
            this.lProducto.Size = new System.Drawing.Size(446, 56);
            this.lProducto.TabIndex = 4;
            this.lProducto.SelectedIndexChanged += new System.EventHandler(this.lProducto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio";
            // 
            // tPrecio
            // 
            this.tPrecio.Location = new System.Drawing.Point(543, 391);
            this.tPrecio.Name = "tPrecio";
            this.tPrecio.Size = new System.Drawing.Size(446, 20);
            this.tPrecio.TabIndex = 7;
            // 
            // textCategoria
            // 
            this.textCategoria.Location = new System.Drawing.Point(543, 263);
            this.textCategoria.Name = "textCategoria";
            this.textCategoria.Size = new System.Drawing.Size(446, 20);
            this.textCategoria.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Categoría";
            // 
            // bIns
            // 
            this.bIns.Location = new System.Drawing.Point(233, 484);
            this.bIns.Name = "bIns";
            this.bIns.Size = new System.Drawing.Size(75, 23);
            this.bIns.TabIndex = 10;
            this.bIns.Text = "Insertar";
            this.bIns.UseVisualStyleBackColor = true;
            this.bIns.Click += new System.EventHandler(this.bIns_Click);
            // 
            // bUpd
            // 
            this.bUpd.Location = new System.Drawing.Point(391, 484);
            this.bUpd.Name = "bUpd";
            this.bUpd.Size = new System.Drawing.Size(75, 23);
            this.bUpd.TabIndex = 11;
            this.bUpd.Text = "Modifcar";
            this.bUpd.UseVisualStyleBackColor = true;
            this.bUpd.Click += new System.EventHandler(this.bUpd_Click);
            // 
            // bClean
            // 
            this.bClean.Location = new System.Drawing.Point(714, 484);
            this.bClean.Name = "bClean";
            this.bClean.Size = new System.Drawing.Size(75, 23);
            this.bClean.TabIndex = 13;
            this.bClean.Text = "Limpiar";
            this.bClean.UseVisualStyleBackColor = true;
            this.bClean.Click += new System.EventHandler(this.bClean_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(556, 484);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(75, 23);
            this.bDel.TabIndex = 12;
            this.bDel.Text = "Borrar";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 569);
            this.Controls.Add(this.bClean);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bUpd);
            this.Controls.Add(this.bIns);
            this.Controls.Add(this.textCategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBoxProveedores);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProveedores;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPrecio;
        private System.Windows.Forms.TextBox textCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bIns;
        private System.Windows.Forms.Button bUpd;
        private System.Windows.Forms.Button bClean;
        private System.Windows.Forms.Button bDel;
    }
}

