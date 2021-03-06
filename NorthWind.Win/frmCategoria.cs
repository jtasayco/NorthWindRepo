﻿
using NorthWind.Entity;
using NorthWind.Logic;
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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        List<TbCategoriaBE> Lista = new List<TbCategoriaBE>();

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            //Lista = TbCategoriaDAO.SelectAll();
            //Lista = TbCategoriaBL.SelectAll();
            //ProxyMantenimiento.ManServiceClient proxyMan = new ProxyMantenimiento.ManServiceClient("HTTP_EndPoint");
            ProxyManIis.ManServiceClient proxyManIis = new ProxyManIis.ManServiceClient("BasicHttpBinding_IManService");
            Lista = proxyManIis.SelectAllFromCategoria();
            this.TbCategoriaBindingSource.DataSource = Lista;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
