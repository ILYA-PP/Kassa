﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KassaApp.Models
{
    [Table("Receipt")]
    public partial class Receipt
    {
        private string phone;
        public int Id { get; set; }
        [StringLength(12)]
        public string Phone
        {
            get
            {
                if (phone != null && phone[0] == '8')
                    phone = "+7" + phone.Remove(0, 1);
                return phone;
            }
            set { phone = value; }
        }
        [StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "money")]
        public decimal Summa { get; set; }
        public double Discount { get; set; }
        public int Payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Receipt()
        {
            Purchases = new List<Purchase>();
            Products = new List<Product>();
        }
        [NotMapped]
        public List<Product> Products { get; set; }

        public void CalculateSumm()
        {
            Summa = 0;
            if (Products != null)
                foreach (var p in Products)
                    Summa += (decimal)p.Row_Summ;
        }

    }
}
