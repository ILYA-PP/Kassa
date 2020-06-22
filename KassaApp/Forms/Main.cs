using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Main : Form
    {
        private double totalForReceipt = 0;
        public Main()
        {
            InitializeComponent();
            timer.Start();
        }

        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
            }
            if (e.KeyChar == ',')
            {
                if (((TextBox)sender).Text.Contains(','))
                    e.KeyChar = '\0';
            }
        }
        private void discountOnReceiptB_Click(object sender, EventArgs e)
        {
            new DiscountOnReceipt().ShowDialog();
        }

        private void editB_Click(object sender, EventArgs e)
        {
            if(receiptDGV.SelectedRows.Count > 0)
                new AddEditProduct(Product.ProductFromRow(receiptDGV.SelectedRows[0])).ShowDialog(this);
            else
                new AddEditProduct().ShowDialog(this);
        }

        private void paymentB_Click(object sender, EventArgs e)
        {
            new Payment(0).ShowDialog();
        }

        private void receiptDGV_SelectionChanged(object sender, EventArgs e)
        {
            if(receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0]);
                nameL.Text = product.Name;
                summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeTB.Text = $"{DateTime.Now.ToLocalTime()}"; 
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            if (receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0]);
                if (MessageBox.Show("Вы действительно хотите удалить строку:\n" +
                    $"| {product.Name} | {product.Quantity} | {product.Price} | {product.Row_Summ} |","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    receiptDGV.Rows.Remove(receiptDGV.SelectedRows[0]);
            }
        }

        private void rowCount_Changed(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double result = 0, sum = 0, discount = 0;
            foreach (DataGridViewRow r in receiptDGV.Rows)
            {
                sum = double.Parse(r.Cells["countCol"].Value.ToString()) *
                    double.Parse(r.Cells["priceCol"].Value.ToString());
                discount = sum * double.Parse(r.Cells["saleCol"].Value.ToString()) / 100;
                result += sum - discount;
            }
            totalForReceipt = Math.Round(result, 2);
            resultL.Text = $"{totalForReceipt}";
            discountTB.Text = discount.ToString();
            nonDiscountTB.Text = sum.ToString();
        }

        private void rowCount_Changed()
        {
            double result = 0, sum = 0, discount = 0;
            foreach (DataGridViewRow r in receiptDGV.Rows)
            {
                sum = double.Parse(r.Cells["countCol"].Value.ToString()) *
                    double.Parse(r.Cells["priceCol"].Value.ToString());
                discount = sum * double.Parse(r.Cells["saleCol"].Value.ToString()) / 100;
                result += sum - discount;
            }
            totalForReceipt = Math.Round(result, 2);
            if(totalForReceipt != 0)
                resultL.Text = $"{totalForReceipt}";
            else
                resultL.Text = $"0.00";
            if (sum != 0)
                nonDiscountTB.Text = sum.ToString();
            else
                nonDiscountTB.Text = $"0.00";
            if (discount != 0)
                discountTB.Text = discount.ToString();
            else
                discountTB.Text = $"0.00";
        }

        private void receiptDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowCount_Changed();
        }

        private void receiptDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rowCount_Changed();
        }
        //обработка горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F10: ; break;
                case Keys.F1:; break;
                case Keys.F3: ; break;
                case Keys.F4:; break;
                case Keys.F5:; break;
                case Keys.F6:; break;
                case Keys.F9:; break;
                case Keys.Delete:; break;
                case Keys.F11:; break;
                case Keys.F12:; break;
                case Keys.F18:; break;
                case Keys.Insert:; break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
