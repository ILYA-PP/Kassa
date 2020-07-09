using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    public partial class ChooseProduct : Form
    {
        
        public ChooseProduct()
        {
            InitializeComponent();
            ViewResult();
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            KassaDBContext db = new KassaDBContext();
            var products = db.Product.Where(p => p.Name.Contains(searchTB.Text));
            ViewResult();
        }

        private void ViewResult()
        {
            KassaDBContext db = new KassaDBContext();
            productsDGV.Rows.Clear();
            foreach (Product p in db.Product)
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
                        product = Product.ProductFromRow(r, null);
                        if (product != null)
                        {
                            product.Quantity = (int)countNUD.Value;
                            product.RowSummCalculate();
                            if (CountController.Check(product))
                            {
                                bool added = false;
                                foreach (Product p in ((Main)Owner).receipt.Products)
                                {
                                    if (p.Name == product.Name)
                                    {
                                        if(p.Type == 1)
                                        {
                                            p.Quantity += product.Quantity;
                                            p.Row_Summ += product.Row_Summ;
                                            ((Main)Owner).DGV_Refresh();
                                        }
                                        added = true;
                                    }
                                }
                                if (!added)
                                {
                                    ((Main)Owner).receipt.Products.Add(product);
                                    ((Main)Owner).DGV_Refresh();
                                }
                                ViewResult();
                                //Close();
                            }
                        }
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
