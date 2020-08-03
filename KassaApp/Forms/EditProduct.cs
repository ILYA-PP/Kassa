using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class EditProduct : Form
    {
        private Product OldProduct; //переданная строка для изменения
        public EditProduct(DataGridViewRow row)
        {
            InitializeComponent();
            OldProduct = Product.ProductFromRow(row, null);
            try
            {
                if(OldProduct != null)
                {
                    //установка полученных данных в поля формы
                    receiptDGV.Visible = true;
                    countNUD.Value = OldProduct.Quantity;
                    discountTB.Text = string.Format("{0:f}", OldProduct.Discount);
                    receiptDGV.Rows.Add(OldProduct.Name, OldProduct.Quantity,
                        OldProduct.Price, OldProduct.Discount, OldProduct.NDS, OldProduct.Row_Summ);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ограничение вводимых значений в текстбоксы
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralCodeForForms.TextBoxFormat(sender, e);
        }
        //обработка нажатия кнопки Ввод
        private void addProductB_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new KassaDBContext())
                {
                    if (countNUD.Value != 0 && discountTB.Text != "")
                    {
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
                            Type = OldProduct.Type
                        };
                        product.RowSummCalculate();
                        product.Quantity -= OldProduct.Quantity;
                        //если изменённое количесвто не превышает остаток
                        if (CountController.Check(product))
                        {
                            product.Quantity += OldProduct.Quantity;
                            //изменение данных на форме Main
                            int index = ((Main)Owner).receipt.Products.IndexOf(
                                ((Main)Owner).receipt.Products.Where(p => p.Name == product.Name).FirstOrDefault());
                            ((Main)Owner).receipt.Products[index] = product;
                            ((Main)Owner).DGV_Refresh();
                            //обновление данных в БД в таблице Purchase
                            var oldP = db.Purchase.Where(pur => pur.ProductId == product.Id && pur.ReceiptId == ((Main)Owner).receipt.Id).FirstOrDefault();
                            oldP.Count = product.Quantity;
                            oldP.Summa = (decimal)product.Row_Summ;
                            db.SaveChanges();
                        }
                        Close();
                    }
                    else
                        MessageBox.Show("Заполните все данные о товаре!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //обработка нажатия горячих клавиш
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
        //обработка нажатия кнопки Отмена
        private void cancelB_Click(object sender, EventArgs e)
        {
            Close();
        }
        //обработчики кнопок установки фокуса на текстбоксы
        private void discountB_Click(object sender, EventArgs e)
        {
            discountTB.Focus();
        }

        private void countB_Click(object sender, EventArgs e)
        {
            countNUD.Focus();
        }

        private void departmentB_Click(object sender, EventArgs e)
        {
            departmentNUD.Focus();
        }
        //изменение данных в DataGridView
        //после изменения значений текстовых полей
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
    }
}
