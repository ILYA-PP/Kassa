﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassaApp.Models
{
    /// <summary>
    /// Класс преставляет таблицу Receipt базы данных
    /// и предоставляет функционал для работы с ним.
    /// </summary>
    [Table("Receipt")]
    public partial class Receipt
    {
        public Receipt()
        {
            Purchase = new HashSet<Purchase>();
            Products = new List<Product>();
        }
        [NotMapped]
        public decimal DiscountSum { get; set; }
        [NotMapped]
        public decimal DiscountedSum { get; set; }
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
        //признак оплаты чека
        [Column(TypeName = "bit")]
        public bool Paid { get; set; }
        public int Payment { get; set; }
        [StringLength(11)]
        public string DiscountCard { get; set; }
        //связанные с чеков продажи
        public virtual ICollection<Purchase> Purchase { get; set; }
        //продукты в чеке
        [NotMapped]
        public List<Product> Products { get; set; }
        /// <summary>
		/// Метод производит расчёт суммы по чеку.
		/// </summary>
        public void CalculateSumm()
        {
            Summa = 0;
            if (Products != null)
                foreach (var p in Products)
                    Summa += p.Row_Summ;
            DiscountSum = Math.Round(Summa * (decimal)Discount / 100, 2);
            Summa -= DiscountSum;
        }
    }
}
