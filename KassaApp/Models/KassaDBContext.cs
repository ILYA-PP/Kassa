namespace KassaApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using KassaApp.Models;

    public partial class KassaDBContext : DbContext
    {
        public KassaDBContext()
            : base("name=KassaDBContext")
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Receipt> Receipt{ get; set; }
        public virtual DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
            modelBuilder.Entity<Purchase>()
                .Property(e => e.Summa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Summa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Report>()
                .Property(e => e.ReportData)
                .IsFixedLength();
        }
    }
}
