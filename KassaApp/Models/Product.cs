
using System.Windows.Forms;

namespace KassaApp.Models
{
    public class Product
    {
        private double sum;
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount 
        { 
            get 
            {
                if (Discount > 100)
                {
                    MessageBox.Show("Скидка не может быть больше 100%");
                    Discount = 100;
                }
                return Discount;
            }
            set { } 
        }
        public int Quantity { get; set; }
        public double NDS
        {
            get
            {
                if (Discount > 100)
                {
                    MessageBox.Show("НДС не может быть больше 100%");
                    Discount = 100;
                }
                return NDS;
            }
            set { }
        }
        public double NDS_Summ { get; set; }
        public int Row_Type { get; set; }
        public double Row_Summ { get; set; }
    }
}
