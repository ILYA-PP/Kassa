using KassaApp.Models;
using KassaApp.Models.Connection;
using System;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы восстановления.
    /// </summary>
    public partial class Recovery : Form
    {
        private readonly Receipt Receipt;
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и первичное заполнение таблицы товаров
        /// для восстановления.
        /// </summary>
        public Recovery(Receipt receipt)
        {
            InitializeComponent();
            Receipt = receipt;
            totalL.Text = string.Format("Итог по чеку: {0:f}", receipt.Summa);
            using (var db = ConnectionFactory.GetConnection())
            {
                foreach (var purchase in receipt.Purchase)
                {
                    var product = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {purchase.ProductId}")).FirstOrDefault();
                    product.Quantity = purchase.Count;
                    product.Row_Summ = purchase.Summa;
                    Product.RowFromProduct(product, receiptDGV);
                }
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Оплачен.
        /// Устанавливает для свойства формы DialogResult значение Yes. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void paidB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Не оплачен.
        /// Устанавливает для свойства формы DialogResult значение No. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void notPaidB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
