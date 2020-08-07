using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class Recovery : Form
    {
        private Receipt Receipt;
        public Recovery(Receipt receipt)
        {
            InitializeComponent();
            Receipt = receipt;
            totalL.Text = string.Format("Итог по чеку: {0:f}", receipt.Summa);
            using (var db = new KassaDBContext())
            {
                foreach (var purchase in receipt.Purchase)
                {
                    var product = db.Product.Where(prod => prod.Id == purchase.ProductId).FirstOrDefault();
                    product.Quantity = purchase.Count;
                    product.Row_Summ = purchase.Summa;
                    Product.RowFromProduct(product, receiptDGV);
                }
            }
        }

        private void paidB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void notPaidB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
