using Dapper;
using KassaApp.Models;
using KassaApp.Models.Connection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы выбора товара.
    /// </summary>
    public partial class ChooseProduct : Form
    {
        private int Page { get; set; }
        private bool End { get; set; }
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и первичное заполнение таблицы товаров.
        /// </summary>
        public ChooseProduct()
        {
            InitializeComponent();
            Page = 0;
            End = false;
            ViewResult(null);
            ActiveControl = productsDGV;

            AddAscrollListener(productsDGV);
        }
        /// <summary>
        /// Метод обрабатывает ввод текста в textBox.
        /// Формирует массив значений, подходящих под параметры запроса.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            if(searchTB.Text.Length >= 3)
                using (var db = ConnectionFactory.GetConnection())
                {
                    //получение продуктов название которых
                    //содержит введённый в поисковую строку текст
                    var products = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Name LIKE '%{searchTB.Text}%'"));
                    ViewResult(products);
                }
        }
        /// <summary>
        /// Метод выводит результат поиска в таблицу формы.
        /// Если результат поиска равен null выводятся все продукты.
        /// </summary>
        /// <param name="products">Массив, содержащий найденные продукты.</param>
        private void ViewResult(IEnumerable<Product> products = null, bool clear = true)
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                if(clear)
                    productsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех товарах
                if (products == null)
                {
                    var allProducts = db.Query<Product>(SQLHelper.Select<Product>($"ORDER BY Id OFFSET {Pagination.Size * Page} ROWS FETCH NEXT {Pagination.Size} ROWS ONLY"));
                    foreach (Product p in allProducts)
                    {
                        productsDGV.Rows.Add(p.Id, p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife < DateTime.Now && p.ShelfLife != null)
                            productsDGV.Rows[productsDGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else
                    foreach (Product p in products)
                    {
                        productsDGV.Rows.Add(p.Id, p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife < DateTime.Now && p.ShelfLife != null)
                            productsDGV.Rows[productsDGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }
        /// <summary>
        /// Метод отвечает за обработку нажатия горячих клавиш.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: if(!cancelB.Focused) cancelB_Click(null, null); break;
                case Keys.Enter: if (!enterB.Focused) enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Ввод.
        /// Отвечает за вывод выбранного продукта в таблицу формы Main. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void enterB_Click(object sender, EventArgs e)
        {
            int maxCount = 0;
            try
            {
                using (var db = ConnectionFactory.GetConnection())
                {
                    Product product;
                    Purchase purchase;
                    //если продукт выбран
                    if (productsDGV.SelectedRows.Count > 0)
                        foreach (DataGridViewRow r in productsDGV.SelectedRows)
                        {
                            //формирование продукта из строки DataGridView
                            product = Product.ProductFromRow(r, null);
                            if (product.ShelfLife < DateTime.Now)
                                if (MessageBox.Show($"Срок годности товара \"{product.Name}\" истёк {product.ShelfLife:dd.MM.yyyy}!\n\n" +
                                    $"Действительно добавить товар в чек?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            maxCount = product.Quantity;
                            
                            if (product != null)
                            {
                                product.Quantity = (int)countNUD.Value;
                                //product.RowSummCalculate();
                                //если количество не превышает остаток
                                if (CountController.Check(product))
                                {
                                    bool added = false;
                                    //перебор содержимого состава чека на форме Main
                                    foreach (Product p in CurrentReceipt.Receipt.Products)
                                    {
                                        //если товар уже добавлен в чек новая позиция не создаётся
                                        if (p.Id == product.Id)
                                        {
                                            if (p.Type == 1)//учитываются только товары, без услуг
                                            {
                                                //обновляется запись в БД в таблице Purchase

                                                var oldP = db.Query<Purchase>($"SELECT * FROM Purchase WHERE ProductId = {p.Id} AND ReceiptId = {CurrentReceipt.Receipt.Id}").FirstOrDefault();
                                                oldP.Count += product.Quantity;
                                                oldP.Summa += product.Row_Summ;
                                                //к существующей позиции добавляется количество и сумма
                                                p.Quantity += product.Quantity;
                                                p.Row_Summ += product.Row_Summ;
                                                ((Main)Owner).DGV_Refresh();
                                                db.Execute(SQLHelper.Update(oldP));
                                                CurrentReceipt.Receipt.Purchase.Where(pur => pur.ProductId == p.Id).FirstOrDefault().Count = oldP.Count;
                                                CurrentReceipt.Receipt.Purchase.Where(pur => pur.ProductId == p.Id).FirstOrDefault().Summa = oldP.Summa;
                                                Log.Logger.Info($"Количество товара (ID = {p.Id}) прибавлен к существующей позиции в чеке");
                                            }
                                            added = true;
                                        }
                                    }
                                    //если товар не добавлен
                                    if (!added)
                                    {
                                        //создаётся новая позиция в чеке
                                        CurrentReceipt.Receipt.Products.Add(product);
                                        Log.Logger.Info($"Создана позиция с товаром (ID = {product.Id}) в чеке");
                                        ((Main)Owner).DGV_Refresh();
                                        //данные добавляются в БД в таблицу Purchase
                                        purchase = new Purchase()
                                        {
                                            ProductId = product.Id,
                                            Count = product.Quantity,
                                            Summa = product.Row_Summ,
                                            Date = DateTime.Now,
                                            ReceiptId = CurrentReceipt.Receipt.Id,
                                            Receipt = db.Query<Receipt>($"SELECT * FROM Receipt WHERE Id = {CurrentReceipt.Receipt.Id}").FirstOrDefault()
                                        };
                                        db.Execute(SQLHelper.Insert(purchase));
                                        purchase.Id = db.Query<int>("SELECT MAX(Id) FROM Purchase").FirstOrDefault();
                                        CurrentReceipt.Receipt.Purchase.Add(purchase);
                                        Log.Logger.Info($"Добавлена записть в таблицу Purchase базы данных с товаром (ID = {product.Id})");
                                    }
                                    //обновление данных формы
                                    ViewResult(null);
                                    Close();
                                }
                                else if (countNUD.Value > maxCount)
                                {
                                    countNUD.Value = maxCount;
                                }
                            }
                        }
                    else
                        MessageBox.Show("Строка не выбрана!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }

        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отмена.
        /// Вызывает метод Close для формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Метод обрабатывает событие изменения выбора в dataGridView.
        /// Выделяет строку в которой было выбрано поле.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void productsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if(productsDGV.SelectedRows.Count > 0)
            {
                var product = Product.ProductFromRow(productsDGV.SelectedRows[0], null);
                barCodeL.Text = $"ШК: {product.BarCode}";
                infoL.Text = $"Серия: {0}   ДП: {0}   МХ: {0}";
            }
            if (productsDGV.CurrentRow != null)
                productsDGV.CurrentRow.Selected = true;
        }

        private void productsDGV_Scroll(object sender, ScrollEventArgs e)
        {
            if (productsDGV.DisplayedRowCount(false) + productsDGV.FirstDisplayedScrollingRowIndex >= productsDGV.RowCount && !End)
            {
                Page++;

                using (var db = ConnectionFactory.GetConnection())
                {
                    var products = db.Query<Product>(SQLHelper.Select<Product>($"ORDER BY Id OFFSET {Pagination.Size * Page} ROWS FETCH NEXT {Pagination.Size} ROWS ONLY"));

                    if (products.Count() < Pagination.Size)
                        End = true;

                    ViewResult(products, false);
                }
            }
        }
        private bool AddAscrollListener(DataGridView dgv)
        {
            bool ret = false;

            var t = dgv.GetType();
            var pi = t.GetProperty("VerticalScrollBar", BindingFlags.Instance | BindingFlags.NonPublic);
            ScrollBar s = null;

            if (pi != null)
            {
                s = pi.GetValue(dgv, null) as ScrollBar;
            }

            if (s != null)
            {
                s.Scroll += new ScrollEventHandler(productsDGV_Scroll);
                ret = true;
            }

            return ret;
        }
    }
}
