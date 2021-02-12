namespace KassaApp
{
    using KassaApp.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Класс преставляет таблицу Purchase базы данных
    /// и предоставляет функционал для работы с ним.
    /// </summary>
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
        [NotMapped]
        public virtual Receipt Receipt { get; set; }
    }
}
