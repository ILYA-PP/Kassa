using KassaApp.Forms;
using KassaApp.Models;
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
        public Receipt receipt;
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы.
        /// </summary>
        public Main()
        {
            Log.Logger.Info("Открытие окна Регистрации продаж...");
            InitializeComponent();
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
                new EditProduct(receiptDGV.SelectedRows[0]).ShowDialog(this);
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
            if (receipt.Summa > 0)
                new Payment(receipt).ShowDialog(this);
            else
                MessageBox.Show("Сумма чека равна 0. Оплата невозможна!");
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
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                if (product != null)
                {
                    nameL.Text = product.Name;
                    summL.Text = $"{product.Quantity} x {product.Price} - {product.Discount}% = {product.Row_Summ}  Отд: {product.Department}";
                    remainsL.Text = $"Ост: {product.GetBalance()}";
                    shelfLifeL.Text = $"СГ: {product.ShelfLife:dd.MM.yyyy}";
                    if (product.ShelfLife < DateTime.Now)
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
                Product product = Product.ProductFromRow(receiptDGV.SelectedRows[0], receipt);
                //вывод диалогового окна
                if (product != null && MessageBox.Show("Вы действительно хотите удалить строку:\n" +
                    $"| {product.Name} | {product.Quantity} | {product.Price} | " +
                    $"{product.Row_Summ} |","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var db = new KassaDBContext())
                    {
                        Log.Logger.Info($"Удаление данных о покупке (ID товара = {product.Id}; " +
                            $"ID чека = {receipt.Id}) из таблицы Purchase");
                        //удаление из БД из таблицы Purchase
                        var purchase = db.Purchase.Where(p => p.ProductId == product.Id && p.ReceiptId == receipt.Id).FirstOrDefault();
                        db.Purchase.Remove(purchase);
                        db.SaveChanges();
                        //удаление из состава чека
                        receipt.Purchase.Remove(purchase);
                        receipt.Products.Remove(product);
                        receipt.CalculateSumm();
                        //удаление из DataGridView
                        receiptDGV.Rows.Remove(receiptDGV.SelectedRows[0]);
                        //восстановление остатка
                        CountController.Recover(product.Id, product.Quantity);
                        Log.Logger.Info($"Удалена позиция чека: " +
                            $"{product.Name} | {product.Quantity} | " +
                            $"{product.Price} | {product.Row_Summ}");
                    }
                }
            }
        }
        /// <summary>
        /// Метод отвечает за изменение итога при добавлении и удалении записей таблицы.
        /// </summary>
        private void rowCount_Changed()
        {
            if (receipt != null)
            {
                receipt.CalculateSumm();
                if (receipt.Summa == 0)
                {
                    resultL.Text = "0,00";
                    discountTB.Text = "0,00";
                    nonDiscountTB.Text = "0,00";
                }
                else
                {
                    resultL.Text = string.Format("{0:f}", receipt.Summa);
                    discountTB.Text = string.Format("{0:f}", receipt.DiscountSum);
                    nonDiscountTB.Text = string.Format("{0:f}", receipt.Summa + receipt.DiscountSum);
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
        }
        /// <summary>
        /// Метод обрабатывает событие удаления строки таблицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Регистрации продаж...");
            //сверка остатков по товарам, добавленным в чек
            CountController.Reconciliation(receipt);
        }
        /// <summary>
        /// Метод отвечает за обновление данных в таблице. 
        /// </summary>
        public void DGV_Refresh()
        {
            receiptDGV.Rows.Clear();
            foreach (Product p in receipt.Products)
                Product.RowFromProduct(p, receiptDGV);
        }
        /// <summary>
        /// Метод обрабатывает событие загрузки формы.
        /// Отвечает вызов сравнения остатков и создание объекта чека. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
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
                Log.Logger.Info($"Создан чек (ID = {receipt.Id})");
                timer.Start();
            }
        }
    }
}
