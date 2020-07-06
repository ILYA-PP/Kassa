﻿
using System;
using System.Windows.Forms;

namespace KassaApp.Models
{
    public class Product
    {
        private double discount, nds, price, sum;
        public string Name { get; set; }
        public int Department { get; set; }
        public double Price 
        {
            get
            {
                if (price == 0)
                {
                    MessageBox.Show("Скидка не может быть больше 100%");
                    price = 0.01;
                }
                return price;
            }
            set { price = Math.Round(value, 2); }
        }
        public double Discount 
        { 
            get 
            {
                if (discount > 100)
                {
                    MessageBox.Show("Скидка не может быть больше 100%");
                    discount = 100;
                }
                return discount;
            }
            set { discount = Math.Round(value, 2); } 
        }
        public int Quantity { get; set; }
        public double NDS
        {
            get
            {
                if (nds > 100)
                {
                    MessageBox.Show("НДС не может быть больше 100%");
                    nds = 100;
                }
                return nds;
            }
            set { nds = Math.Round(value, 2); }
        }
        public double NDS_Summ { get; set; }
        public int Row_Type { get; set; }
        public double Row_Summ { get { return sum; } set { sum = Math.Round(value, 2); } }

        public static Product ProductFromRow(DataGridViewRow row)
        {
            Product product = new Product()
            {
                Name = row.Cells["nameCol"].Value.ToString(),
                Quantity = int.Parse(row.Cells["countCol"].Value.ToString()),
                Price = double.Parse(row.Cells["priceCol"].Value.ToString()),
                Discount = double.Parse(row.Cells["saleCol"].Value.ToString()),
                NDS = double.Parse(row.Cells["ndsCol"].Value.ToString()),
                Row_Summ = double.Parse(row.Cells["sumCol"].Value.ToString())
            };
            product.RowSummCalculate();
            return product;
        }

        public void RowSummCalculate()
        {
            Row_Summ = Quantity * Price; //расчёт суммы
            Row_Summ -= Row_Summ * Discount / 100;//расчёт суммы с учётом скидки
        }
    }
}
