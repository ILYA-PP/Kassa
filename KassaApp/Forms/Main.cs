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
                new AddEditProduct(receiptDGV.SelectedRows[0]).ShowDialog(this);
            else
                new AddEditProduct().ShowDialog(this);
        }

        private void paymentB_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            double sum = 0;
            foreach (DataGridViewRow row in receiptDGV.Rows)
            {
                receipt.Products.Add(Product.ProductFromRow(row));
                sum += (double)row.Cells["sumCol"].Value;
            }
            receipt.Summa = sum;
            new Payment(receipt).ShowDialog();
        }

        private void receiptDGV_SelectionChanged(object sender, EventArgs e)
        {
            if(receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0]);
                nameL.Text = product.Name;
                summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}";
                if (product.Quantity * product.Price != 0)
                    nonDiscountTB.Text = (product.Quantity * product.Price).ToString();
                else
                    nonDiscountTB.Text = $"0.00";
                if (product.Discount != 0)
                    discountTB.Text = (product.Quantity * product.Price - product.Row_Summ).ToString();
                else
                    discountTB.Text = $"0.00";
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
            rowCount_Changed();
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
                case Keys.F10:; break;
                case Keys.F1:; break;
                case Keys.F3: ; break;
                case Keys.F4:; break;
                case Keys.F5:; break;
                case Keys.F6:; break;
                case Keys.F9: editB_Click(null, null); break;
                case Keys.Delete: deleteB_Click(null, null); break;
                case Keys.F11:; break;
                case Keys.F12: paymentB_Click(null, null); break;
                case Keys.F8:; break;
                case Keys.Insert:; break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void receiptDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            rowCount_Changed();
            if (receiptDGV.SelectedRows.Count > 0)
                receiptDGV_SelectionChanged(null, null);
        }
    }
}
