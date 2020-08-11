namespace KassaApp
{
    using KassaApp.Models;
    using System.Data.Entity;

    /// <summary>
	/// Класс представляющий контект базы данных.
	/// </summary>
    public partial class KassaDBContext : DbContext
    {
        /// <summary>
        /// Конструктор класса.
        /// Выполняет подключение к базе данных по указанной строке подкючения.
        /// </summary>
        public KassaDBContext()
            : base("name=KassaDBContext")
        {
        }

        //наборы данных представляющие таблицы БД
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Receipt> Receipt{ get; set; }
        public virtual DbSet<Report> Report { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<KassaDBContext>(null);
            base.OnModelCreating(modelBuilder);
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
