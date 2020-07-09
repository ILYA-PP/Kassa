namespace KassaApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;

    [Table("Purchase")]
    public partial class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "money")]
        public decimal Summa { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "bit")]
        public bool Paid { get; set; }
    }
}
