using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{ 
    /// <summary>
    /// Класс содержит логику работы формы редактирования выбранного продукта.
    /// </summary>
    public partial class EditProduct : Form
    {
        private Product OldProduct; //переданная строка для изменения
        /// <summary>
        /// Конструктор класса.
        /// Выполняет инициализацию формы и заполнение данных для редактирования.
        /// </summary>
        /// <param name="row">Строка, которую надо изменить.</param>
        public EditProduct(Product product)
        {
            Log.Logger.Info("Открытие окна Редактирования товара...");
            InitializeComponent();
            OldProduct = product;
            try
            {
                if(OldProduct != null)
                {
                    //установка полученных данных в поля формы
                    receiptDGV.Visible = true;
                    countNUD.Value = OldProduct.Quantity;
                    departmentNUD.Value = OldProduct.Department;
                    discountTB.Text = string.Format("{0:f}", OldProduct.Discount);
                    receiptDGV.Rows.Add(OldProduct.Name, OldProduct.Quantity,
                        OldProduct.Price, OldProduct.Discount, OldProduct.NDS, OldProduct.Row_Summ);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие клавиш при вводе текста в textBox.
        /// Допускает ввод дробных чисел.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод</param>
        /// <param name="e">Аргументы события</param>
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFormat.TextBoxDoubleFormat(sender, e);
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Ввод.
        /// Отвечает за проверку корректности и сохранение изменённых данных. 
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void EditProductB_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new KassaDBContext())
                {
                    if (countNUD.Value != 0 && discountTB.Text != "")
                    {
                        Log.Logger.Info($"Старые данные: Товар: {OldProduct.Name} " +
                            $"Количество: {OldProduct.Quantity} " +
                            $"Отдел: {OldProduct.Department} Скидка: {OldProduct.Discount}");
                        //создание продукта с изменёнными данными
                        Product product = new Product()
                        {
                            Id = OldProduct.Id,
                            Name = OldProduct.Name,
                            Quantity = (int)countNUD.Value,
                            Price = OldProduct.Price,
                            Discount = double.Parse(discountTB.Text),
                            NDS = OldProduct.NDS,
                            Department = (int)departmentNUD.Value,
                            Type = OldProduct.Type,
                            ShelfLife = OldProduct.ShelfLife,
                            BarCode = OldProduct.BarCode  
                        };
                        product.RowSummCalculate();
                        product.Quantity -= OldProduct.Quantity;
                        //если изменённое количесвто не превышает остаток
                        if (CountController.Check(product))
                        {
                            product.Quantity += OldProduct.Quantity;
                            //изменение данных на форме Main
                            int index = ((Main)Owner).receipt.Products.IndexOf(
                                ((Main)Owner).receipt.Products.Where(p => p.Id == product.Id).FirstOrDefault());
                            ((Main)Owner).receipt.Products[index] = product;
                            ((Main)Owner).DGV_Refresh();
                            //обновление данных в БД в таблице Purchase
                            var oldP = db.Purchase.Where(pur => pur.ProductId == product.Id && pur.ReceiptId == ((Main)Owner).receipt.Id).FirstOrDefault();
                            oldP.Count = product.Quantity;
                            oldP.Summa = product.Row_Summ;
                            db.SaveChanges();
                            ((Main)Owner).receipt.Purchase.Where(p => p.ProductId == product.Id).FirstOrDefault().Count = oldP.Count;
                            ((Main)Owner).receipt.Purchase.Where(p => p.ProductId == product.Id).FirstOrDefault().Summa = oldP.Summa;
                            Log.Logger.Info($"Изменение данных о покупке в таблице Purchase");
                            Log.Logger.Info($"Новые данные: Товар: {product.Name} " +
                            $"Количество: {product.Quantity} " +
                            $"Отдел: {product.Department} Скидка: {product.Discount}");
                        }
                        Close();
                    }
                    else
                        MessageBox.Show("Заполните все данные о товаре!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
        /// Метод отвечает за обработку нажатия горячих клавиш.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {                
            switch (keyData)
            {
                case Keys.F10: if (!discountB.Focused) discountB_Click(null, null); break;
                case Keys.F9: if (!departmentB.Focused) departmentB_Click(null, null); break;
                case Keys.Multiply: if (!countB.Focused) countB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отмена.
        /// Вызывает метод Close для формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void cancelB_Click(object sender, EventArgs e)
        {
            Log.Logger.Info("Закрытие окна Установки скидки на чек...");
            Close();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Скидка.
        /// Устанавливает фокус для поля скидки.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void discountB_Click(object sender, EventArgs e)
        {
            discountTB.Focus();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Количество.
        /// Устанавливает фокус для поля количества.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void countB_Click(object sender, EventArgs e)
        {
            countNUD.Focus();
        }
        /// <summary>
        /// Метод обрабатывает нажатие кнопки Отдел.
        /// Устанавливает фокус для поля отдела.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void departmentB_Click(object sender, EventArgs e)
        {
            departmentNUD.Focus();
        }
        /// <summary>
        /// Метод обрабатывает ввод текста в textBox.
        /// Отвечает за изменение данных в DataGridView после изменения значений текстовых полей
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void textBoxs_TextChange(object sender, EventArgs e)
        {
            if (receiptDGV.Rows.Count > 0)
            {
                receiptDGV.Rows[0].Cells["countCol"].Value = countNUD.Value;
                receiptDGV.Rows[0].Cells["discountCol"].Value = discountTB.Text;
                receiptDGV.Rows[0].Cells["sumCol"].Value = Math.Round((double)countNUD.Value * (double)OldProduct.Price
                    - (double)countNUD.Value * (double)OldProduct.Price * double.Parse(discountTB.Text) / 100, 2);
            }
            //ввод значения если текстовое поле пустое
            if (sender.GetType() == typeof(TextBox) && ((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0.00";
        }
        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавщий метод.</param>
        /// <param name="e">Аргументы события.</param>
        private void EditProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Info("Закрытие окна Изменения товара...");
        }
    }
}
