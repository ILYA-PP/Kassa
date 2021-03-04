using Dapper;
using KassaApp.Forms;
using KassaApp.Models;
using KassaApp.Models.Connection;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    /// <summary>
    /// Класс содержит логику работы формы чека.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SinchronizationController sinchronization = new SinchronizationController(20000);
        }
        /// <summary>
        /// Метод отвечает за переход на форму установки скидки на чек. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void discountOnReceiptB_Click(object sender, EventArgs e)
        {
            new DiscountOnReceipt().ShowDialog(this);
        }
        /// <summary>
        /// Метод отвечает за переход на форму редактирования выбранного товара. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void editB_Click(object sender, EventArgs e)
        {
            //Если выбрана строка, то изменение
            if (receiptDGV.SelectedRows.Count > 0)
                new EditProduct(Product.ProductFromRow(receiptDGV.SelectedRows[0], CurrentReceipt.Receipt)).ShowDialog(this);
            else
                MessageBox.Show("Строка не выбрана!");
        }
        /// <summary>
        /// Метод отвечает за переход на форму оплаты. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void paymentB_Click(object sender, EventArgs e)
        {
            if (CurrentReceipt.Receipt.Summa > 0 || CurrentReceipt.Receipt.Products.Count() == 1 && CurrentReceipt.Receipt.Products[0].IsPrescription)
            {
                if (CurrentReceipt.Receipt.Products.Where(p => p.IsPrescription == true).Count() > 0)
                {
                    if(new PrescriptionData().ShowDialog() == DialogResult.OK)
                        new Payment(CurrentReceipt.Receipt).ShowDialog(this);
                }
                else
                    new Payment(CurrentReceipt.Receipt).ShowDialog(this);
            }
            else
                MessageBox.Show("Для нельготного товара, сумма чека не может быть равна 0. Оплата невозможна!");
        }
        /// <summary>
        /// Метод обрабатывает событие изменения выбора в dataGridView.
        /// Отвечает за изменение значений на форме при выборе строки таблицы 
        /// и выделяет строку в которой было выбрано поле.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void receiptDGV_SelectionChanged(object sender, EventArgs e)
        {
            //если строка выбрана
            //изменение значений полей Без скидки, Скидка, Итог, Сумма и отдел
            if (receiptDGV.SelectedRows.Count > 0)
            {
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], CurrentReceipt.Receipt);
                if (product != null)
                {
                    nameL.Text = product.Name;
                    summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}  Отд: {product.Department}";
                    remainsL.Text = $"Ост: {product.GetBalance()}";
                    shelfLifeL.Text = $"СГ: {product.ShelfLife:dd.MM.yyyy}";
                    if (product.ShelfLife < DateTime.Now && product.ShelfLife != null)
                        shelfLifeL.BackColor = Color.Red;
                    else
                        shelfLifeL.BackColor = remainsL.BackColor;
                    barCodeL.Text = $"ШК: {product.BarCode}";
                }
            }
            else
            {
                nameL.Text = shelfLifeL.Text = barCodeL.Text = summL.Text = remainsL.Text = "";
                shelfLifeL.BackColor = remainsL.BackColor;
            }
            if(receiptDGV.CurrentRow != null)
                receiptDGV.CurrentRow.Selected = true;
        }
        /// <summary>
        /// Метод обрабатывает событие прошествия интервала времени.
        /// Отвечает за установку даты и времени на форме 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            timeTB.Text = $"{DateTime.Now.ToLocalTime()}"; 
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Удалить.
        /// Отвечает за удаление записи таблицы. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void deleteB_Click(object sender, EventArgs e)
        {
            //если строка выбрана
            if (receiptDGV.SelectedRows.Count > 0)
            {
                //формирование удаляемого продукт из строки
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], CurrentReceipt.Receipt);
                //вывод диалогового окна
                if (product != null && MessageBox.Show("Вы действительно хотите удалить товар: " +
                    $"{product.Name} ","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var db = ConnectionFactory.GetConnection())
                    {
                        Log.Logger.Info($"Удаление данных о покупке (ID товара = {product.Id}; " +
                            $"ID чека = {CurrentReceipt.Receipt.Id}) из таблицы Purchase");
                        //удаление из БД из таблицы Purchase
                        var purchase = db.Query<Purchase>(SQLHelper.Select<Purchase>($"WHERE ProductId = {product.Id} AND ReceiptId = {CurrentReceipt.Receipt.Id}")).FirstOrDefault();
                        db.Execute(SQLHelper.Delete(purchase));
                        //удаление из состава чека
                        CurrentReceipt.Receipt.Purchase.Remove(CurrentReceipt.Receipt.Purchase.Where(p => p.Id == purchase.Id).FirstOrDefault());
                        CurrentReceipt.Receipt.Products.Remove(product);
                        CurrentReceipt.Receipt.CalculateSumm();
                        //удаление из DataGridView
                        //receiptDGV.Rows.Remove(receiptDGV.SelectedRows[0]);
                        DGV_Refresh();
                        //восстановление остатка
                        CountController.Recover(product.Id, product.Quantity);
                    }
                }
            }
        }
        /// <summary>
        /// Метод отвечает за изменение итога при добавлении и удалении записей таблицы.
        /// </summary>
        private void rowCount_Changed()
        {
            if (CurrentReceipt.Receipt != null)
            {
                CurrentReceipt.Receipt.CalculateSumm();
                if (CurrentReceipt.Receipt.Summa == 0)
                {
                    resultL.Text = "0,00";
                    discountTB.Text = "0,00";
                    nonDiscountTB.Text = "0,00";
                }
                else
                {
                    resultL.Text = string.Format("{0:f}", CurrentReceipt.Receipt.Summa);
                    discountTB.Text = string.Format("{0:f}", CurrentReceipt.Receipt.DiscountSum);
                    nonDiscountTB.Text = string.Format("{0:f}", CurrentReceipt.Receipt.Summa + CurrentReceipt.Receipt.DiscountSum);
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает событие добавления строки в таблицу.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void receiptDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowCount_Changed();
            foreach (DataGridViewRow r in receiptDGV.Rows)
                r.HeaderCell.Value = (r.Index + 1).ToString();
        }
        /// <summary>
        /// Метод обрабатывает событие удаления строки таблицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void receiptDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rowCount_Changed();
            foreach (DataGridViewRow r in receiptDGV.Rows)
                r.HeaderCell.Value = (r.Index + 1).ToString();
        }
        /// <summary>
        /// Метод отвечает за обработку нажатия горячих клавиш.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F10:; break;
                case Keys.F1:; break;
                case Keys.F3: ; break;
                case Keys.F4:; break;
                case Keys.F5:; break;
                case Keys.F6: if (!searchB.Focused) searchB_Click(null,null); break;
                case Keys.F9: if (!editB.Focused) editB_Click(null, null); break;
                case Keys.Delete: if (!deleteB.Focused) deleteB_Click(null, null); break;
                case Keys.F11:; break;
                case Keys.F12: if (!paymentB.Focused) paymentB_Click(null, null); break;
                case Keys.F8:; break;
                case Keys.Insert:; break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Метод обрабатывает событие изменения значения поля таблицы.
        /// Отвечает за обновление данных формы. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void receiptDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            rowCount_Changed();
            if (receiptDGV.SelectedRows.Count > 0)
                receiptDGV_SelectionChanged(null, null);
        }
        /// <summary>
        /// Метод отвечает за переход на форму выбора товара. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void searchB_Click(object sender, EventArgs e)
        {
            new ChooseProduct().ShowDialog(this);
        }
        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// Отвечает за вызов сравнения остатков. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //сверка остатков по товарам, добавленным в чек
            await CountController.Reconciliation(CurrentReceipt.Receipt);
        }
        /// <summary>
        /// Метод отвечает за обновление данных в таблице. 
        /// </summary>
        public void DGV_Refresh()
        {
            receiptDGV.Rows.Clear();
            foreach (Product p in CurrentReceipt.Receipt.Products)
                Product.RowFromProduct(p, receiptDGV);
        }
        /// <summary>
        /// Метод обрабатывает событие загрузки формы.
        /// Отвечает вызов сравнения остатков и создание объекта чека. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private async void Main_Load(object sender, EventArgs e)
        {
            //сверка остатков по всем товарам
            await CountController.ReconciliationAll();
            //добавление нового чека в БД в таблицу Receipt
            using (var db = ConnectionFactory.GetConnection())
            {
                CurrentReceipt.Receipt = new Receipt();
                db.ExecuteScalar(SQLHelper.Insert(CurrentReceipt.Receipt));
                CurrentReceipt.Receipt.Id = db.Query<int>("SELECT MAX(Id) FROM Receipt;").FirstOrDefault();
                Log.Logger.Info($"Создан чек (ID = {CurrentReceipt.Receipt.Id})");
                timer.Start();
            }
        }
    }
}
