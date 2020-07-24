namespace KassaApp
{
    using KassaApp.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    //клас представляет таблицу БД Purchase
    //продажи конкретного продукта
    [Table("Purchase")]
    public partial class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "money")]
        public decimal Summa { get; set; }
        public DateTime Date { get; set; }

        public int? ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
