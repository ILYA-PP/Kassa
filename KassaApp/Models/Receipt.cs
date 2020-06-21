using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KassaApp.Models
{
    class Receipt
    {
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
        public int Payment { get; set; }
        public Product[] Products { get; set; }
    }
}
