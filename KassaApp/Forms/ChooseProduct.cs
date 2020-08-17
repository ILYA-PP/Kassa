using KassaApp.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp.Forms
{
    /// <summary>
    /// Класс содержит логику работы формы выбора товара.
    /// </summary>
    public partial class ChooseProduct : Form
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и первичное заполнение таблицы товаров.
        /// </summary>
        public ChooseProduct()
        {
            Log.Logger.Info($"Открытие окна Выбора товара...");
            InitializeComponent();
            ViewResult(null);
            ActiveControl = productsDGV;
        }
        /// <summary>
        /// Метод обрабатывает ввод текста в textBox.
        /// Формирует массив значений, подходящих под параметры запроса.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                Log.Logger.Info($"Получение товаров, название которых содержит \"{searchTB.Text}\"");
                //получение продуктов название которых
                //содержит введённый в поисковую строку текст
                var products = db.Product.Where(p => p.Name.Contains(searchTB.Text));
                ViewResult(products);
            }
        }
        /// <summary>
        /// Метод выводит результат поиска в таблицу формы.
        /// Если результат поиска равен null выводятся все продукты.
        /// </summary>
        /// <param name="products">Массив, содержащий найденные продукты.</param>
        private void ViewResult(IQueryable<Product> products)
        {
            using (var db = new KassaDBContext())
            {
                Log.Logger.Info($"Получение списка товаров");
                productsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех товарах
                if (products == null)
                    foreach (Product p in db.Product)
                    {
                        productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife < DateTime.Now)
                            productsDGV.Rows[productsDGV.Rows.Count-1].DefaultCellStyle.BackColor = Color.Red;
                    }
                else
                    foreach (Product p in products)
                    {
                        productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife < DateTime.Now)
                            productsDGV.Rows[productsDGV.Rows.Count-1].DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }
        //обработка горячих клавиш
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
            try
            {
                using (var db = new KassaDBContext())
                {
                    Log.Logger.Info($"Получение товара, выбранного в списке");
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
                            if (product != null)
                            {
                                product.Quantity = (int)countNUD.Value;
                                product.RowSummCalculate();
                                //если количество не превышает остаток
                                if (CountController.Check(product))
                                {
                                    bool added = false;
                                    //перебор содержимого состава чека на форме Main
                                    foreach (Product p in ((Main)Owner).receipt.Products)
                                    {
                                        //если товар уже добавлен в чек новая позиция не создаётся
                                        if (p.Name == product.Name)
                                        {
                                            if (p.Type == 1)//учитываются только товары, без услуг
                                            {
                                                //обновляется запись в БД в таблице Purchase
                                                var oldP = db.Purchase.Where(pur => pur.ProductId == p.Id && pur.ReceiptId == ((Main)Owner).receipt.Id).FirstOrDefault();
                                                oldP.Count += product.Quantity;
                                                oldP.Summa += product.Row_Summ;
                                                //к существующей позиции добавляется количество и сумма
                                                p.Quantity += product.Quantity;
                                                p.Row_Summ += product.Row_Summ;
                                                ((Main)Owner).DGV_Refresh();
                                                db.SaveChanges();
                                                Log.Logger.Info($"Количество товара (ID = {p.Id}) прибавлен к существующей позиции в чеке");
                                            }
                                            added = true;
                                        }
                                    }
                                    //если товар не добавлен
                                    if (!added)
                                    {
                                        //создаётся новая позиция в чеке
                                        ((Main)Owner).receipt.Products.Add(product);
                                        Log.Logger.Info($"Создана позиция с товаром (ID = {product.Id}) в чеке");
                                        ((Main)Owner).DGV_Refresh();
                                        //данные добавляются в БД в таблицу Purchase
                                        purchase = new Purchase()
                                        {
                                            ProductId = product.Id,
                                            Count = product.Quantity,
                                            Summa = product.Row_Summ,
                                            Date = DateTime.Now,
                                            ReceiptId = ((Main)Owner).receipt.Id,
                                            Receipt = db.Receipt.Where(rec => rec.Id == ((Main)Owner).receipt.Id).FirstOrDefault()
                                        };
                                        ((Main)Owner).receipt.Purchase.Add(purchase);
                                        db.Purchase.Add(purchase);
                                        db.SaveChanges();
                                        Log.Logger.Info($"Добавлена записть в таблицу Purchase базы данных с товаром (ID = {product.Id})");
                                    }
                                    //обновление данных формы
                                    ViewResult(null);
                                    Close();
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
            Log.Logger.Info("Закрытие окна Выбора товара...");
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
            if (productsDGV.CurrentRow != null)
                productsDGV.CurrentRow.Selected = true;
        }
    }
}
