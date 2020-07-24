namespace KassaApp
{
    using KassaApp.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Windows.Forms;

    //класс представляющий таблицу БД Product
    //имеющиеся товары
    [Table("Product")]
    public partial class Product
    {
        private double discount, nds;
        private decimal price, sum;
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
        public decimal Row_Summ { get { return sum; } set { sum = Math.Round(value, 2); } }

        public int Department { get; set; }

        public int Type { get; set; }
        public int Quantity { get; set; }
        //метод для формирования объекта класса из строки DataGridView
        public static Product ProductFromRow(DataGridViewRow row, Receipt r)
        {
            try
            {
                Product product;
                //если продукт уже есть в составе чека
                if (r != null)
                    product = r.Products.Where(p => p.Name == row.Cells["nameCol"].Value.ToString()).FirstOrDefault();
                else
                {
                    using (var db = new KassaDBContext())
                    {
                        string name = row.Cells["nameCol"].Value.ToString();
                        int count = int.Parse(row.Cells["countCol"].Value.ToString());
                        product = db.Product.Where(p => p.Name == name).FirstOrDefault();
                        product.Quantity = count;
                        product.RowSummCalculate();
                    }
                }
                return product;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //метод для формирования строки DataGridView из объекта класса
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
        //метод для расчёта суммы по позиции
        public void RowSummCalculate()
        {
            Row_Summ = (Price - Math.Round(Price * (decimal)Discount / 100, 2)) * Quantity;
        }
    }
}
