namespace KassaApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Forms;

    [Table("Product")]
    public partial class Product
    {
        private double discount, nds, sum;
        private decimal price;
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price
        {
            get
            {
                if (price == 0)
                {
                    MessageBox.Show("Скидка не может быть больше 100%");
                    price = 0.01M;
                }
                return price;
            }
            set { price = Math.Round(value, 2); }
        }

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
        [NotMapped]
        public double Row_Summ { get { return sum; } set { sum = Math.Round(value, 2); } }

        public int Department { get; set; }

        public int Type { get; set; }
        public int Quantity { get; set; }
        public static Product ProductFromRow(DataGridViewRow row)
        {
            try
            {
                Product product = new Product()
                {
                    Name = row.Cells["nameCol"].Value.ToString(),
                    Quantity = int.Parse(row.Cells["countCol"].Value.ToString()),
                    Price = decimal.Parse(row.Cells["priceCol"].Value.ToString()),
                    Discount = double.Parse(row.Cells["discountCol"].Value.ToString()),
                    NDS = double.Parse(row.Cells["ndsCol"].Value.ToString())
                };
                if(row.Cells["sumCol"].Value != null)
                    product.Row_Summ = double.Parse(row.Cells["sumCol"].Value.ToString());
                product.RowSummCalculate();
                return product;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void RowSummCalculate()
        {
            Row_Summ = (double)(Quantity * Price); //расчёт суммы
            Row_Summ -= Row_Summ * Discount / 100;//расчёт суммы с учётом скидки
        }
    }
}
