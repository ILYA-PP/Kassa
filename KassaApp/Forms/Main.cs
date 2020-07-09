using KassaApp.Forms;
using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Main : Form
    {
        public Receipt receipt = new Receipt();
        public Main()
        {
            InitializeComponent();
            timer.Start();
        }
        //ограничение вводимых значений в текстбоксы
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
        //переход на форму скидки на чек
        private void discountOnReceiptB_Click(object sender, EventArgs e)
        {
            new DiscountOnReceipt().ShowDialog();
        }
        //переход на форму Добавления/Удаления товаров
        private void editB_Click(object sender, EventArgs e)
        {
            //Если выбрана строка, то изменение
            //иначе добавление
            if (receiptDGV.SelectedRows.Count > 0)
                new EditProduct(receiptDGV.SelectedRows[0]).ShowDialog(this);
            else
                MessageBox.Show("Строка не выбрана!");
        }
        //формирование объекта чека и переход на форму оплаты
        private void paymentB_Click(object sender, EventArgs e)
        {
            if (receipt.Summa == 0)
            {
                MessageBox.Show("Сумма чека равна 0. Оплата невозможна!");
                return;
            }
            var db = new KassaDBContext();
            Purchase purchase;
            foreach(Product p in receipt.Products)
            {
                int id = db.Product.Where(pr => pr.Name == p.Name).FirstOrDefault().Id;
                purchase = new Purchase() 
                { 
                    ProductId = id,
                    Count = p.Quantity,
                    Summa = (decimal)p.Row_Summ,
                    Date = DateTime.Now,
                    Paid = false
                };
                db.Purchase.Add(purchase);
            }
            db.SaveChanges();
            new Payment(receipt).ShowDialog(this);
        }
        //изменение значений на форме при выборе строки таблицы
        private void receiptDGV_SelectionChanged(object sender, EventArgs e)
        {
            if(receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                if(product != null)
                {
                    nameL.Text = product.Name;
                    summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}";
                    if (product.Quantity * product.Price != 0)
                        nonDiscountTB.Text = String.Format("{0:f}", product.Quantity * product.Price);
                    else
                        nonDiscountTB.Text = $"0.00";
                    if (product.Discount != 0)
                        discountTB.Text = String.Format("{0:f}", product.Quantity * product.Price - (decimal)product.Row_Summ);
                    else
                        discountTB.Text = $"0.00";
                } 
            }
            else
            {
                nameL.Text = "";
                summL.Text = "";
                nonDiscountTB.Text = $"0.00";
                discountTB.Text = $"0.00";
            }
        }
        //вывод времени
        private void timer_Tick(object sender, EventArgs e)
        {
            timeTB.Text = $"{DateTime.Now.ToLocalTime()}"; 
        }
        //обработка кнопки удаления записи таблицы
        private void deleteB_Click(object sender, EventArgs e)
        {
            if (receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                if (product != null && MessageBox.Show("Вы действительно хотите удалить строку:\n" +
                    $"| {product.Name} | {product.Quantity} | {product.Price} | " +
                    $"{product.Row_Summ} |","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    receipt.Products.Remove(product);
                    receipt.CalculateSumm();
                    receiptDGV.Rows.Remove(receiptDGV.SelectedRows[0]);
                    CountController.Recover(product);
                }
            }
        }
        //изменение значений на форме при добавлении и удалении записей таблицы
        private void rowCount_Changed()
        {
            receipt.CalculateSumm();
            if(receipt.Summa != 0)
                resultL.Text = String.Format("{0:f}", receipt.Summa);
            else
                resultL.Text = "0.00";
        }
        //изменение значений на форме при добавлении записей таблицы
        private void receiptDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowCount_Changed();
        }
        //изменение значений на форме при удалении записей таблицы
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
                case Keys.F6: searchB_Click(null,null); break;
                case Keys.F9: editB_Click(null, null); break;
                case Keys.Delete: deleteB_Click(null, null); break;
                case Keys.F11:; break;
                case Keys.F12: paymentB_Click(null, null); break;
                case Keys.F8:; break;
                case Keys.Insert:; break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //изменение значений на форме изменении данных таблицы
        private void receiptDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            rowCount_Changed();
            if (receiptDGV.SelectedRows.Count > 0)
                receiptDGV_SelectionChanged(null, null);
        }

        private void searchB_Click(object sender, EventArgs e)
        {
            new ChooseProduct().ShowDialog(this);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receipt != null && receipt.Products != null)
                foreach (var p in receipt.Products)
                    CountController.Recover(p);
        }

        public void DGV_Refresh()
        {
            receiptDGV.Rows.Clear();
            foreach (Product p in receipt.Products)
                Product.RowFromProduct(p, receiptDGV);
        }
    }
}
