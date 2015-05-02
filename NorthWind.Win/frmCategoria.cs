﻿using NorthWind.DAO;
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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        List<TbCategoriaBE> Lista = new List<TbCategoriaBE>();

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            Lista = TbCategoriaDAO.SelectAll();
            this.TbCategoriaBindingSource.DataSource = Lista;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}