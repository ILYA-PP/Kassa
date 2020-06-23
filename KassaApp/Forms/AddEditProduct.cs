﻿using KassaApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class AddEditProduct : Form
    {
        private DataGridViewRow dgvRow;
        public AddEditProduct()
        {
            InitializeComponent();
            receiptDGV.Visible = false;
        }
        public AddEditProduct(DataGridViewRow row)
        {
            InitializeComponent();
            Product product = Product.ProductFromRow(row);
            dgvRow = row;
            try
            {
                //установка полученных данных для изменения
                receiptDGV.Visible = true;
                nameTB.Text = product.Name;
                countNUD.Value = product.Quantity;
                priceTB.Text = product.Price.ToString();
                discountTB.Text = product.Discount.ToString();
                ndsTB.Text = product.NDS.ToString();
                receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ограничение вводимых значений в текстбоксы
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = '\0';
            }
            if (e.KeyChar == ',')
            {
                if (((TextBox)sender).Text.Contains(','))
                    e.KeyChar = '\0';
            }
        }
        //обработка кнопки Ввод
        private void addProductB_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTB.Text != "" && countNUD.Value != 0 && priceTB.Text != ""
                    && discountTB.Text != "" && ndsTB.Text != "")
                {
                    Product product = new Product()
                    {
                        Name = nameTB.Text,
                        Quantity = (int)countNUD.Value,
                        Price = Math.Round(double.Parse(priceTB.Text), 2),
                        Discount = Math.Round(double.Parse(discountTB.Text), 2),
                        NDS = Math.Round(double.Parse(ndsTB.Text), 2)
                    };
                    product.Row_Summ = product.Quantity * product.Price; //расчёт суммы
                    product.Row_Summ -= Math.Round(product.Row_Summ * product.Discount / 100,2);//расчёт суммы с учётом скидки
                    receiptDGV.Rows.Clear();
                    receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
                    //если идёт изменение, данные меняются на главной форме
                    //иначе данные добавляются на новую форму
                    if (dgvRow != null)
                        for(int i = 0; i< ((Main)Owner).receiptDGV.Rows[dgvRow.Index].Cells.Count; i++)
                            ((Main)Owner).receiptDGV.Rows[dgvRow.Index].Cells[i].Value = receiptDGV.Rows[0].Cells[i].Value;
                    else
                        ((Main)Owner).receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
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
    }
}
