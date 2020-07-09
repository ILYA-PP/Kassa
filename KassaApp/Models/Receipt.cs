using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KassaApp.Models
{
    public class Receipt
    {
        private List<Product> products = new List<Product>();
        private string phone;
        public int ID { get; set; }
        public string Phone
        {
            get
            {
                if (phone[0] == '8')
                    phone = "+7" + phone.Remove(0, 1);
                return phone;
            }
            set { phone = value; }
        }
        public string Email { get; set; }
        public double Summa { get; set; }
        public double Discount { get; set; }
        public int Payment { get; set; }
        public List<Product> Products { get { return products; } set { products = value; } }

        public void CalculateSumm()
        {
            Summa = 0;
            if (Products != null)
                foreach (var p in Products)
                    Summa += p.Row_Summ;
        }
    }
}
