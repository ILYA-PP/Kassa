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
            ViewResult(null);
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            KassaDBContext db = new KassaDBContext();
            var products = db.Product.Where(p => p.Name.Contains(searchTB.Text));
            ViewResult(products);
        }

        private void ViewResult(IQueryable<Product> prod)
        {
            KassaDBContext db = new KassaDBContext();
            productsDGV.Rows.Clear();
            if(prod == null)
                foreach (Product p in db.Product)
                    productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                        p.Discount, p.NDS, p.Row_Summ);
            else
                foreach (Product p in prod)
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
                var db = new KassaDBContext();
                var rec = db.Receipt.Where(re => re.Id == ((Main)Owner).receipt.Id).FirstOrDefault();
                Product product;
                Purchase purchase;
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
                                foreach (Product p in rec.Products)
                                {
                                    if (p.Name == product.Name)
                                    {
                                        if (p.Type == 1)
                                        {
                                            var oldP = db.Purchase.Where(pur => pur.ProductId == p.Id && pur.ReceiptId == rec.Id).FirstOrDefault();
                                            oldP.Count += product.Quantity;
                                            oldP.Summa += (decimal)product.Row_Summ;
                                            p.Quantity += product.Quantity;
                                            p.Row_Summ += product.Row_Summ;
                                            ((Main)Owner).DGV_Refresh();
                                            db.SaveChanges();
                                        }
                                        added = true;
                                    }
                                }
                                if (!added)
                                {
                                    ((Main)Owner).receipt.Products.Add(product);
                                    ((Main)Owner).DGV_Refresh();
                                    purchase = new Purchase()
                                    {
                                        ProductId = product.Id,
                                        Count = product.Quantity,
                                        Summa = (decimal)product.Row_Summ,
                                        Date = DateTime.Now,
                                        Receipt = rec
                                    };
                                    ((Main)Owner).receipt.Purchases.Add(purchase);
                                    db.Purchase.Add(purchase);
                                    db.SaveChanges();
                                }
                                ViewResult(null);
                                //Close();
                            }
                        }
                    }
                else
                    MessageBox.Show("Строка не выбрана!");
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
