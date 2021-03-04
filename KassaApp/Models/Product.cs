namespace KassaApp
{
    using Dapper;
    using KassaApp.Models;
    using KassaApp.Models.Connection;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Класс преставляет таблицу Product базы данных
    /// и предоставляет функционал для работы с ним.
    /// </summary>
    [Table("Product")]
    public partial class Product
    {
        private int quantity;
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
                //if (price == 0)
                //{
                //    MessageBox.Show("Цена не может быть равной 0!");
                //    price = 0.01M;
                //}
                return price;
            }
            set 
            {
                RowSummCalculate();
                price = Math.Round(value, 2); 
            }
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
            set 
            {
                RowSummCalculate();
                discount = Math.Round(value, 2); 
            }
        }
        [NotMapped]
        public decimal Row_Summ { get { return sum; } set { sum = Math.Round(value, 2); } }

        public int Department { get; set; }

        public int Type { get; set; }
        public int Quantity 
        {
            get { return quantity; }
            set 
            {
                RowSummCalculate();
                quantity = value; 
            } 
        }
        [StringLength(100)]
        public string BarCode { get; set; }
        public DateTime? ShelfLife { get; set; }
        [Required]
        [StringLength(100)]
        public string MarkingCode { get; set; }
        public bool IsPrescription { get; set; }
        /// <summary>
		/// Метод формирует объект класса Product из строки DataGridView.
		/// </summary>
        /// <param name="row">Строка с данными.</param>
        /// <param name="receipt">Текущий чек.</param>
        /// <returns>Сформированный продукт.</returns>
        public static Product ProductFromRow(DataGridViewRow row, Receipt receipt)
        {
            try
            {
                Product product;
                //если продукт уже есть в составе чека
                if (receipt != null)
                    product = receipt.Products.Where(p => p.Id == (int)row.Cells["idCol"].Value).FirstOrDefault();
                else
                {
                    using (var db = ConnectionFactory.GetConnection())
                    {
                        int id = (int)row.Cells["idCol"].Value;
                        int count = int.Parse(row.Cells["countCol"].Value.ToString());
                        product = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {id}")).FirstOrDefault();
                        product.Quantity = count;
                        product.RowSummCalculate();
                    }
                }
                return product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
                return null;
            }
        }
        /// <summary>
		/// Метод формирует строку DataGridView из объекта класса Product.
		/// </summary>
        /// <param name="product">Продукт из которого будет сформирована строка.</param>
        /// <param name="dgv">DataGridView в который будет добавлена строка.</param>
        public static void RowFromProduct(Product product, DataGridView dgv)
        {
            try
            {
                dgv.Rows.Add(product.Id, product.Name, product.Quantity, product.Price, product.Discount, product.NDS, product.Row_Summ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
        }
        /// <summary>
		/// Метод производит расчёт суммы по позиции.
		/// </summary>
        private void RowSummCalculate()
        {
            Row_Summ = (Price - Math.Round(Price * (decimal)Discount / 100, 2)) * Quantity;
        }
        /// <summary>
		/// Метод остаток товара.
		/// </summary>
        /// <returns>Остаток товара.</returns>
        public int GetBalance()
        {
            try
            {
                using (var db = ConnectionFactory.GetConnection())
                {
                    
                    var product = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {Id}")).FirstOrDefault();
                    Log.Logger.Info($"Получение остатка товара (ID = {product.Id})");
                    return product.Quantity;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextFormat.GetExceptionMessage(ex));
            }
            return -1;
        }
    }
}
