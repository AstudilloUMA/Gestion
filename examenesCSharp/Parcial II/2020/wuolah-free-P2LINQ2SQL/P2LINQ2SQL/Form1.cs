using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2LINQ2SQL
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        tProveedor proveedor;
        tProducto producto;
        tCatalogo selecionado;

        bool inicio = true;

        public Form1()
        {
            InitializeComponent();
            proveedor = null;
            producto = null;
            selecionado = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxProveedores.DataSource = db.tProveedor;
            lProducto.DataSource = db.tProducto;
            listBoxProveedores.SelectedItem = null;
            lProducto.SelectedItem = null;
            lProducto.ClearSelected();
            inicio = false;
        }

        private void listBoxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicio)
            {
                proveedor = (tProveedor)listBoxProveedores.SelectedItem;
                producto = null;
                MuestraSeleccionado();
            }
        }

        private void cargaGrid()
        {
            dataGridView1.DataSource = from entrada in db.tCatalogo
                                       where entrada.IdProveedor == proveedor.IdProveedor
                                       orderby entrada.Categoria
                                       select new { entrada.Categoria, entrada.tProducto, entrada.precio };
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                producto = (tProducto)dataGridView1.SelectedRows[0].Cells[1].Value;
                selecionado = db.tCatalogo.First(x => x.IdProveedor == proveedor.IdProveedor && x.IdProducto == producto.IdProducto);
                MuestraSeleccionado();
            }
        }

        private void MuestraSeleccionado()
        {
            if (selecionado==null)
            {
                cargaGrid();
                lProducto.SelectedItem = null;
                tPrecio.Text = "";
                textCategoria.Text = "";
            }
            else
            {
                lProducto.SelectedItem = producto;
                textCategoria.Text = selecionado.Categoria;
                tPrecio.Text = selecionado.precio.ToString();
            }
        }

        private void bIns_Click(object sender, EventArgs e)
        {
            try
            {
                selecionado = new tCatalogo();
                selecionado.IdProducto = producto.IdProducto;
                selecionado.IdProveedor = proveedor.IdProveedor;
                selecionado.Categoria = textCategoria.Text;
                selecionado.precio = float.Parse(tPrecio.Text);
                selecionado.tProducto = producto;
                selecionado.tProveedor = proveedor;
                db.tCatalogo.InsertOnSubmit(selecionado);
                db.SubmitChanges();
                selecionado = null;
                MuestraSeleccionado();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                RecuperaError();
            }
        }

        private void bUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (selecionado.precio != float.Parse(tPrecio.Text)) selecionado.precio = float.Parse(tPrecio.Text);
                if (selecionado.Categoria != textCategoria.Text) selecionado.Categoria = textCategoria.Text;

                db.SubmitChanges();
                selecionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                RecuperaError();
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            try
            {
                db.tCatalogo.DeleteOnSubmit(selecionado);
                db.SubmitChanges();
                selecionado = null;
                MuestraSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                RecuperaError();
            }
        }

        private void bClean_Click(object sender, EventArgs e)
        {
            selecionado = null;
            producto = null;
            MuestraSeleccionado();
        }

        private void lProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (producto != null) lProducto.SelectedItem = producto;
            else                  producto = (tProducto)lProducto.SelectedItem;
        }

        private void RecuperaError()
        {
            db = new DataClasses1DataContext();
            listBoxProveedores.DataSource = db.tProveedor;
            lProducto.DataSource = db.tProducto;
            dataGridView1.DataSource = null;
            listBoxProveedores.SelectedItem = null;
            lProducto.SelectedItem = null;
            tPrecio.Text = "";
            textCategoria.Text = "";
            selecionado = null;
            producto = null;
        }
    }
}
