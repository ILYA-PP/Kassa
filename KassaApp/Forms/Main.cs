using KassaApp.Forms;
using KassaApp.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class Main : Form
    {
        public Receipt receipt;
        public Main()
        {
            InitializeComponent();
        }
        //ограничение вводимых значений в текстбоксы
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
        //переход на форму скидки на чек
        private void discountOnReceiptB_Click(object sender, EventArgs e)
        {
            new DiscountOnReceipt().ShowDialog(this);
        }
        //переход на форму Добавления/Удаления товаров
        private void editB_Click(object sender, EventArgs e)
        {
            //Если выбрана строка, то изменение
            if (receiptDGV.SelectedRows.Count > 0)
                new EditProduct(receiptDGV.SelectedRows[0]).ShowDialog(this);
            else
                MessageBox.Show("Строка не выбрана!");
        }
        //переход на форму оплаты
        private void paymentB_Click(object sender, EventArgs e)
        {
            if (receipt.Summa == 0)
            {
                MessageBox.Show("Сумма чека равна 0. Оплата невозможна!");
                return;
            }
            new Payment(receipt).ShowDialog(this);
        }
        //изменение значений на форме при выборе строки таблицы
        private void receiptDGV_SelectionChanged(object sender, EventArgs e)
        {
            //если строка выбрана
            //изменение значений полей Без скидки, Скидка, Итог, Сумма и отдел
            if(receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                if(product != null)
                {
                    nameL.Text = product.Name;
                    summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}";
                } 
            }
            else
            {
                nameL.Text = "";
                summL.Text = "";
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
            //если строка выбрана
            if (receiptDGV.SelectedRows.Count > 0)
            {
                //формирование удаляемого продукт из строки
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                //вывод диалогового окна
                if (product != null && MessageBox.Show("Вы действительно хотите удалить строку:\n" +
                    $"| {product.Name} | {product.Quantity} | {product.Price} | " +
                    $"{product.Row_Summ} |","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var db = new KassaDBContext())
                    {
                        //удаление из БД из таблицы Purchase
                        var purchase = db.Purchase.Where(p => p.ProductId == product.Id && p.ReceiptId == receipt.Id).FirstOrDefault();
                        db.Purchase.Remove(purchase);
                        db.SaveChanges();
                        //удаление из состава чека
                        receipt.Products.Remove(product);
                        receipt.CalculateSumm();
                        //удаление из DataGridView
                        receiptDGV.Rows.Remove(receiptDGV.SelectedRows[0]);
                        //восстановление остатка
                        CountController.Recover(product.Id, product.Quantity);
                    }
                }
            }
        }
        //изменение итога при добавлении и удалении записей таблицы
        private void rowCount_Changed()
        {
            if (receipt != null)
            {
                receipt.CalculateSumm();
                if (receipt.Summa != 0)
                {
                    resultL.Text = String.Format("{0:f}", receipt.DiscountedSum);
                    discountTB.Text = String.Format("{0:f}", receipt.DiscountSum);
                    nonDiscountTB.Text = String.Format("{0:f}", receipt.Summa);
                }
                else
                {
                    resultL.Text = "0.00";
                    discountTB.Text = "0.00";
                    nonDiscountTB.Text = "0.00";
                }
            }
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
        //обработка нажатия горячих клавиш
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
        //переход на форму поиска
        private void searchB_Click(object sender, EventArgs e)
        {
            new ChooseProduct().ShowDialog(this);
        }
        //действие при закрытии формы
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //сверка остатков по товарам, добавленным в чек
            CountController.Reconciliation(receipt);
        }
        //обновление данных DataGridView
        public void DGV_Refresh()
        {
            receiptDGV.Rows.Clear();
            foreach (Product p in receipt.Products)
                Product.RowFromProduct(p, receiptDGV);
        }
        //действие при загрузке формы
        private void Main_Load(object sender, EventArgs e)
        {
            //сверка остатков по всем товарам
            CountController.ReconciliationAll();
            //добавление нового чека в БД в таблицу Receipt
            using (var db = new KassaDBContext())
            {
                receipt = new Receipt();
                receipt = db.Receipt.Add(receipt);
                db.SaveChanges();
                timer.Start();
            }
        }
    }
}
