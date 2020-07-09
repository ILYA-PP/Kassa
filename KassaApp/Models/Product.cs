namespace KassaApp
{
    using KassaApp.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
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
                    MessageBox.Show("Цена не может быть равной 0!");
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
        public static Product ProductFromRow(DataGridViewRow row, Receipt r)
        {
            try
            {
                Product product;
                if (r != null)
                    product = r.Products.Where(p => p.Name == row.Cells["nameCol"].Value.ToString()).FirstOrDefault();
                else
                {
                    var db = new KassaDBContext();
                    string name = row.Cells["nameCol"].Value.ToString();
                    int count = int.Parse(row.Cells["countCol"].Value.ToString());
                    product = db.Product.Where(p => p.Name == name).FirstOrDefault();
                    product.Quantity = count;
                    product.RowSummCalculate();
                }
                return product;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void RowFromProduct(Product p, DataGridView dgv)
        {
            try
            {
                dgv.Rows.Add(p.Name, p.Quantity, p.Price, p.Discount, p.NDS, p.Row_Summ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RowSummCalculate()
        {
            Row_Summ = (double)(Quantity * Price); //расчёт суммы
            Row_Summ -= Row_Summ * Discount / 100;//расчёт суммы с учётом скидки
        }
    }
}
