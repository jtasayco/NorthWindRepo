using NorthWind.DAO;
using NorthWind.Entity;
using NorthWind.Win.BL;
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
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar Cliente
            frmCliente oFrmCliente = new frmCliente();
            oFrmCliente.onClienteSeleccionado += new EventHandler<TbClienteBE>(
                oFrmCliente_OnClienteSeleccionado);
            oFrmCliente.Show();
        }

        TbClienteBE otmpCliente;
        void oFrmCliente_OnClienteSeleccionado(object sender, TbClienteBE e)
        {
            txtcliente.Text = e.Nombre;
            txtruc.Text = e.Ruc;
            otmpCliente = e;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar Producto
            frmProducto oFrmProducto = new frmProducto();
            oFrmProducto.onProductoSeleccionado += new EventHandler<TbProductoBE>(oFrmProducto_onProductoSelecionado);
            oFrmProducto.Show();
        }
        TbProductoBE otmpProducto;
        void oFrmProducto_onProductoSelecionado(object sender, TbProductoBE e)
        {
            txtproducto.Text = e.Descripcion;
            txtprecio.Text = e.Precio;
            otmpProducto = e;
        }

        DocumentoBL oFacturaBL = new DocumentoBL();
        private void button3_Click(object sender, EventArgs e)
        {
            //validar que exista una cantidad

            if (validaIngreso() == true)
            {
                //Boton Agregar a Factura
                //antes de agregar: 
                List<ItemBE> oFacturaReciente = new List<ItemBE>();
                oFacturaReciente = oFacturaBL.GetDetalle();
                int itemDiferente = 0;
                if (oFacturaReciente.Count > 0)
                {
                    //si ya existen uno o mas registros, buscar en cada uno de ellos para actualizarlo

                    //ItemBE itemEncontrar = (from item in oFacturaReciente.ToArray()
                    //                        where item.Producto.CodProducto == otmpProducto.CodProducto
                    //                        select item).Single();

                    oFacturaReciente.ForEach(list =>
                    {
                        if (list.Producto.CodProducto == otmpProducto.CodProducto)
                        {
                            itemDiferente = 0;
                            list.Cantidad = list.Cantidad + Convert.ToInt32(txtcantidad.Text);
                            //oFacturaBL.ActualizarDetalle(list);
                            //oFacturaBL.SubTotal = list.Total;
                            //list.Precio = list.Precio + Convert.ToDecimal(txtprecio.Text);
                        }
                        else
                        {
                            itemDiferente = 1;
                        }
                    });

                    if (itemDiferente > 0)
                    {
                        asignaDetalle();
                    }

                }
                else
                {
                    asignaDetalle();
                    /*oFacturaBL.AgregarDetalle(new ItemBE()
                    {
                        Cantidad = Convert.ToInt32(txtcantidad.Text),
                        Precio = Convert.ToDecimal(txtprecio.Text),
                        Producto = otmpProducto
                    });*/
                }

                //Actualizar DataGrid
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = oFacturaBL.GetDetalle();

                txtsubtotal.Text = oFacturaBL.SubTotal.ToString();
                txtigv.Text = oFacturaBL.IGV.ToString();
                txttotal.Text = oFacturaBL.Total.ToString();

            }
        }

        private bool validaIngreso()
        {
            bool valor = true;

            if (string.IsNullOrEmpty(txtruc.Text))
            {
                MessageBox.Show("Debe de Ingresar el Ruc del Cliente");
                valor = false;
                button1.Select();
            }
            
            if (string.IsNullOrEmpty(txtcliente.Text))
            {
                MessageBox.Show("Debe de Ingresar el nombre del Cliente");
                valor = false;
                button1.Focus();
            }
            
            if (string.IsNullOrEmpty(txtproducto.Text))
            {
                MessageBox.Show("Debe de Ingresar la descripcion del Producto");
                valor = false;
                button2.Focus();
            }
            
            if (string.IsNullOrEmpty(txtprecio.Text))
            {
                MessageBox.Show("Debe de Ingresar el precio del producto");
                valor = false;
                button2.Focus();
            }
            
            if (string.IsNullOrEmpty(txtcantidad.Text)){
                MessageBox.Show("Debe de Ingresar una Cantidad");
                valor = false;
                txtcantidad.Focus();
            }
            return valor;
        }

        private void asignaDetalle()
        {
            oFacturaBL.AgregarDetalle(new ItemBE()
            {
                Cantidad = Convert.ToInt32(txtcantidad.Text),
                Precio = Convert.ToDecimal(txtprecio.Text),
                Producto = otmpProducto
            });
        }
        //remover de la factura
        private void eliminarItemFactura()
        {
            //verificamos si existen detalles
            if (dataGridView1.RowCount > 0)
            {
                int i = dataGridView1.CurrentRow.Index;
                string itemEliminar = dataGridView1.Rows[i].Cells[0].Value.ToString();
                ItemBE oitemEliminar = (from item in oFacturaBL.GetDetalle().ToArray()
                                        where item.Item == Convert.ToInt32(itemEliminar)
                                        select item).Single();
                oFacturaBL.RetirarDetalle(oitemEliminar);
                if (oFacturaBL.GetDetalle().Count() > 0)
                {
                    int inicializa = 1;
                    oFacturaBL.GetDetalle().ForEach(list =>
                    {
                        list.Item = inicializa;
                        inicializa += 1;
                    });
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = oFacturaBL.GetDetalle();
                }
            }
            else
            {
                MessageBox.Show("No hay Detalles a Retirar");
            }

            List<ItemBE> itemIngresado = new List<ItemBE>();
            itemIngresado = oFacturaBL.GetDetalle();

            if (itemIngresado.Count > 0)
            {
                int i = dataGridView1.CurrentRow.Index;
                string itemEliminar = dataGridView1.Rows[i].Cells[0].Value.ToString();
                ItemBE oitemEliminar = (from item in itemIngresado.ToArray()
                                        where item.Item == Convert.ToInt32(itemEliminar)
                                        select item).Single();
                itemIngresado.Remove(oitemEliminar);
                //actualizando las posiciones de los items
                int inicializa = 1;
                itemIngresado.ForEach(list =>
                {
                    list.Item = inicializa;
                    inicializa += 1;
                });

                //Actualizar DataGrid
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = itemIngresado;


            }
            else
            {
                MessageBox.Show("No hay Detalles a Retirar");
            }
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Elimiar de factura
            eliminarItemFactura();
        }

        private void frmDocumento_Load(object sender, EventArgs e)
        {
            this.dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Guardar Documento en la base de datos
            DocumentoBE oDocumento = new DocumentoBE();
            //Guardar la cabecera
            CabDocumentoBE oCabecera = new CabDocumentoBE();
            oCabecera.Cliente = otmpCliente;
            oCabecera.FechaHora = DateTime.Now;
            oCabecera.IGV = oFacturaBL.IGV;
            oCabecera.SubTotal = oFacturaBL.SubTotal;
            oCabecera.Total = oFacturaBL.Total;
            //Agregamos la cabecera al documento
            oDocumento.Cabecera = oCabecera;
            //Agregamos el detalle al documento
            oDocumento.Detalle = oFacturaBL.GetDetalle();
            //Guardar en la base de datos
            TbDocumentoDao documento = new TbDocumentoDao();
            if(documento.GuardarDocumento(oDocumento) == eEstadoProceso.Correcto){
                MessageBox.Show("Documento Guardado");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.Show();

        }

    }
}
