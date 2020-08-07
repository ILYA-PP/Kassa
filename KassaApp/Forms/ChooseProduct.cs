using KassaApp.Models;
using System;
using System.Drawing;
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
            ActiveControl = productsDGV;
        }
        //обработка ввода текста в строку Поиска
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            using (var db = new KassaDBContext())
            {
                //получение продуктов название которых
                //содержит введённый в поисковую строку текст
                var products = db.Product.Where(p => p.Name.Contains(searchTB.Text));
                ViewResult(products);
            }
        }
        //вывод данных о товарах на форму
        private void ViewResult(IQueryable<Product> products)
        {
            using (var db = new KassaDBContext())
            {
                productsDGV.Rows.Clear();
                //если в метод не переданы данные для вывода
                //то выводится информация о всех товарах
                if (products == null)
                    foreach (Product p in db.Product)
                    {
                        productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife != new DateTime(1901,1,1) && p.ShelfLife < DateTime.Now)
                            productsDGV.Rows[productsDGV.Rows.Count-1].DefaultCellStyle.BackColor = Color.Red;
                    }
                else
                    foreach (Product p in products)
                    {
                        productsDGV.Rows.Add(p.Name, p.Quantity, p.Price,
                            p.Discount, p.NDS, p.Row_Summ);
                        if (p.ShelfLife != new DateTime(1901, 1, 1) && p.ShelfLife < DateTime.Now)
                            productsDGV.Rows[productsDGV.Rows.Count-1].DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }
        //обработка нажатия горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: if(!cancelB.Focused) cancelB_Click(null, null); break;
                case Keys.Enter: if (!enterB.Focused) enterB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //обработка нажатия кнопки Ввод
        private void enterB_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new KassaDBContext())
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
                                            }
                                            added = true;
                                        }
                                    }
                                    //если товар не добавлен
                                    if (!added)
                                    {
                                        //создаётся новая позиция в чеке
                                        ((Main)Owner).receipt.Products.Add(product);
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
        //обработка нажатия кнопки Отмена
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (productsDGV.CurrentRow != null)
                productsDGV.CurrentRow.Selected = true;
        }
    }
}
