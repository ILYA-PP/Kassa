﻿using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class AddEditProduct : Form
    {
        private Product OldProduct;
        public AddEditProduct()
        {
            InitializeComponent();
            receiptDGV.Visible = false;
        }
        public AddEditProduct(DataGridViewRow row)
        {
            InitializeComponent();
            OldProduct = Product.ProductFromRow(row, null);
            try
            {
                if(OldProduct != null)
                {
                    //установка полученных данных для изменения
                    receiptDGV.Visible = true;
                    nameTB.Text = OldProduct.Name;
                    countNUD.Value = OldProduct.Quantity;
                    priceTB.Text = String.Format("{0:f}", OldProduct.Price);
                    discountTB.Text = String.Format("{0:f}", OldProduct.Discount);
                    ndsTB.Text = String.Format("{0:f}", OldProduct.NDS);
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
        //обработка кнопки Ввод
        private void addProductB_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new KassaDBContext();
                if (nameTB.Text != "" && countNUD.Value != 0 && priceTB.Text != ""
                    && discountTB.Text != "" && ndsTB.Text != "")
                {
                    Product product = new Product()
                    {
                        Name = nameTB.Text,
                        Quantity = (int)countNUD.Value,
                        Price = decimal.Parse(priceTB.Text),
                        Discount = double.Parse(discountTB.Text),
                        NDS = double.Parse(ndsTB.Text),
                        Department = (int)departmentNUD.Value
                    };
                    if (productRB.Checked)
                        product.Type = 1;
                    else if (serviceRB.Checked)
                        product.Type = 2;
                    product.RowSummCalculate();
                    //если идёт изменение, данные меняются на главной форме
                    //иначе данные добавляются на главную форму
                    product.Quantity -= OldProduct.Quantity; 
                    if (CountController.Check(product))
                    {
                        product.Quantity += OldProduct.Quantity;
                        int index = ((Main)Owner).receipt.Products.IndexOf(
                            ((Main)Owner).receipt.Products.Where(p => p.Name == product.Name).FirstOrDefault());
                        ((Main)Owner).receipt.Products[index] = product;
                        ((Main)Owner).DGV_Refresh();
                    }    
                    //else
                    //    ((Main)Owner).receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
                    //если товара нет в БД, то он добавляется
                    if (db.Product.Where(p => p.Name == product.Name).FirstOrDefault() == null)
                    {
                        if(MessageBox.Show("Добавить данный товар в БД?", "", 
                            MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            db.Product.Add(product);
                            db.SaveChanges();
                        }      
                    }
                    Close();
                }
                else
                    MessageBox.Show("Заполните все данные о товаре!");
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        //обработка горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {                
            switch (keyData)
            {
                case Keys.F10: discountB_Click(null, null); break;
                case Keys.F9: departmentB_Click(null, null); break;
                case Keys.F8: priceB_Click(null, null); break;
                case Keys.F7: ndsB_Click(null, null); break;
                case Keys.Multiply: countB_Click(null, null); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //закрытие формы
        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void priceB_Click(object sender, EventArgs e)
        {
            priceTB.Focus();
        }

        private void ndsB_Click(object sender, EventArgs e)
        {
            ndsTB.Focus();
        }
        private void textBoxs_TextChange(object sender, EventArgs e)
        {
            if (receiptDGV.Rows.Count > 0)
            {
                receiptDGV.Rows[0].Cells["nameCol"].Value = nameTB.Text;
                receiptDGV.Rows[0].Cells["countCol"].Value = countNUD.Value;
                receiptDGV.Rows[0].Cells["priceCol"].Value = priceTB.Text;
                receiptDGV.Rows[0].Cells["ndsCol"].Value = ndsTB.Text;
                receiptDGV.Rows[0].Cells["discountCol"].Value = discountTB.Text;
                receiptDGV.Rows[0].Cells["sumCol"].Value = Math.Round((double)countNUD.Value * double.Parse(priceTB.Text)
                    - (double)countNUD.Value * double.Parse(priceTB.Text) * double.Parse(discountTB.Text) / 100, 2);
            }
            if (sender.GetType() == typeof(TextBox) && ((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0.00";
        }

        private void textBoxs_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = String.Format("{0:f}", double.Parse(((TextBox)sender).Text));
        }
    }
}
