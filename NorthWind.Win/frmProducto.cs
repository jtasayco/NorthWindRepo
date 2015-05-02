using NorthWind.DAO;
using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind.Win
{
    
    public partial class frmProducto : Form
    {
        //agregacion del evento
        public event EventHandler<TbProductoBE> onProductoSeleccionado;

        //List<TbProductoBE> Lista = new List<TbProductoBE>();
        //Generamos 2 Listas Productos - Categoria
        List<TbProductoBE> listaProducto = new List<TbProductoBE>();
        List<TbCategoriaBE> listaCategoria = new List<TbCategoriaBE>();

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            //Lista = TbProductoBE.SelectAll();
            //Lista = TbProductoDAO.SelectAll();
            listaProducto = TbProductoDAO.SelectAll();
            listaCategoria = TbCategoriaDAO.SelectAll();
            //this.TbProductobindingSource.DataSource = Lista;
            //this.dataGridView1.SelectionMode =
            //    DataGridViewSelectionMode.FullRowSelect;
            var listJoin = from prod in listaProducto
                           join cat in listaCategoria on prod.codCategoria equals cat.CodCategoria
                           select new { codProducto = prod.CodProducto, descripcion = prod.Descripcion, categoria = cat.Nombre, precio = prod.Precio };
            //this.TbProductobindingSource.DataSource = listJoin.ToList();
            this.dataGridView1.DataSource = listJoin.ToList();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void AgregarProductoFactura()
        {
            int i = dataGridView1.CurrentRow.Index;
            String codigoProducto = dataGridView1.Rows[i].Cells[0].Value.ToString();
            TbProductoBE oProducto;
            //Lista.ForEach(list =>
            //{
            //    if (list.CodProducto == codigoProducto)
            //    {
            //        //oProducto = new TbProductoBE(list.CodProducto, list.Descripcion, list.Precio);
            //        oProducto = new TbProductoBE();
            //        oProducto.CodProducto = list.CodProducto;
            //        oProducto.Descripcion = list.Descripcion;
            //        oProducto.Precio = list.Precio;
            //        onProductoSeleccionado(new object(),oProducto);
            //    }
            //});
            //this.Close();
            //Se generara otra vez la lista
            listaProducto = TbProductoDAO.SelectAll();
            listaCategoria = TbCategoriaDAO.SelectAll();
            var listJoin = from prod in listaProducto
                           join cat in listaCategoria on prod.codCategoria equals cat.CodCategoria
                           select new { codProducto = prod.CodProducto, descripcion = prod.Descripcion, categoria = cat.Nombre, precio = prod.Precio,codCategoria = cat.CodCategoria };
            listJoin.ToList().ForEach(listaJoin =>
            {
                if (listaJoin.codProducto == codigoProducto)
                {
                    oProducto = new TbProductoBE();
                    oProducto.CodProducto = listaJoin.codProducto;
                    oProducto.Descripcion = listaJoin.descripcion;
                    oProducto.Precio = listaJoin.precio;
                    oProducto.codCategoria = listaJoin.codCategoria;
                    onProductoSeleccionado(new object(), oProducto);
                }
            });
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProductoFactura();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                AgregarProductoFactura();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listaProducto = TbProductoDAO.SelectAll();
            listaCategoria = TbCategoriaDAO.SelectAll();
            var listJoin = from prod in listaProducto
                           join cat in listaCategoria on prod.codCategoria equals cat.CodCategoria
                           select new { codProducto = prod.CodProducto, descripcion = prod.Descripcion, categoria = cat.Nombre, precio = prod.Precio,codCategoria = cat.CodCategoria };
            this.dataGridView1.DataSource = listJoin.ToList();
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            listaProducto = TbProductoDAO.SelectAll();
            listaCategoria = TbCategoriaDAO.SelectAll();
            var listJoin = from prod in listaProducto
                           join cat in listaCategoria on prod.codCategoria equals cat.CodCategoria
                           select new { codProducto = prod.CodProducto, descripcion = prod.Descripcion, categoria = cat.Nombre, precio = prod.Precio, codCategoria = cat.CodCategoria };

            var resultado = (from c in listJoin.ToList()
                             where c.descripcion.Contains(txtFiltro.Text)
                             select c).ToList();
            this.dataGridView1.DataSource = resultado;
        }

    }
}
