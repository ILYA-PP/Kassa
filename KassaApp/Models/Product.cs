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
    /// ����� ����������� ������� Product ���� ������
    /// � ������������� ���������� ��� ������ � ���.
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
                //    MessageBox.Show("���� �� ����� ���� ������ 0!");
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
                    MessageBox.Show("��� �� ����� ���� ������ 100%");
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
                    MessageBox.Show("������ �� ����� ���� ������ 100%");
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
		/// ����� ��������� ������ ������ Product �� ������ DataGridView.
		/// </summary>
        /// <param name="row">������ � �������.</param>
        /// <param name="receipt">������� ���.</param>
        /// <returns>�������������� �������.</returns>
        public static Product ProductFromRow(DataGridViewRow row, Receipt receipt)
        {
            try
            {
                Product product;
                //���� ������� ��� ���� � ������� ����
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
		/// ����� ��������� ������ DataGridView �� ������� ������ Product.
		/// </summary>
        /// <param name="product">������� �� �������� ����� ������������ ������.</param>
        /// <param name="dgv">DataGridView � ������� ����� ��������� ������.</param>
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
		/// ����� ���������� ������ ����� �� �������.
		/// </summary>
        private void RowSummCalculate()
        {
            Row_Summ = (Price - Math.Round(Price * (decimal)Discount / 100, 2)) * Quantity;
        }
        /// <summary>
		/// ����� ������� ������.
		/// </summary>
        /// <returns>������� ������.</returns>
        public int GetBalance()
        {
            try
            {
                using (var db = ConnectionFactory.GetConnection())
                {
                    
                    var product = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {Id}")).FirstOrDefault();
                    Log.Logger.Info($"��������� ������� ������ (ID = {product.Id})");
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
