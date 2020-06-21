using KassaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KassaApp
{
    public partial class AddEditProduct : Form
    {
        public AddEditProduct()
        {
            InitializeComponent();
        }
        public AddEditProduct(Product product)
        {
            InitializeComponent();
            try
            {
                receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
                        Price = double.Parse(priceTB.Text),
                        Discount = double.Parse(discountTB.Text),
                        NDS = double.Parse(ndsTB.Text),
                    };
                    product.Row_Summ = product.Quantity * product.Price;
                    product.Row_Summ -= product.Row_Summ * product.Discount / 100;
                    receiptDGV.Rows.Add(product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
                    ClearContent();
                }
                else
                    MessageBox.Show("Заполните все данные о товаре!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearContent()
        {
            nameTB.Text = "";
            countNUD.Value = 1;
            priceTB.Text = "";
            discountTB.Text = "";
            ndsTB.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
