﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class ChooseProduct : Form
    {
        private KassaDBContext db;
        public ChooseProduct()
        {
            InitializeComponent();
            db = new KassaDBContext();
            ViewResult(db.Product);
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            var products = db.Product.Where(p => p.Name.Contains(searchTB.Text));
            ViewResult(products);
        }

        private void ViewResult(IQueryable<Product> ps)
        {
            productsDGV.Rows.Clear();
            foreach (Product p in ps)
                productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                    p.Discount, p.NDS, p.Row_Summ);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: cancelB_Click(null, null); break;
                case Keys.Enter: enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void enterB_Click(object sender, EventArgs e)
        {
            try
            {
                Product product;
                if (productsDGV.SelectedRows.Count > 0)
                    foreach (DataGridViewRow r in productsDGV.SelectedRows)
                    {
                        product = Product.ProductFromRow(r);
                        product.Quantity = (int)countNUD.Value;
                        product.RowSummCalculate();
                        ((Main)Owner).receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                               
        }
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
