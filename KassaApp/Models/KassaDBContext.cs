namespace KassaApp
{
    using KassaApp.Models;
    using System.Configuration;
    using System.Data.Entity;
    using System.Windows.Forms;

    /// <summary>
    /// ����� �������������� ������� ���� ������.
    /// </summary>
    public partial class KassaDBContext : DbContext
    {
        /// <summary>
        /// ����������� ������.
        /// ��������� ����������� � ���� ������ �� ��������� ������ ����������.
        /// </summary>
        public KassaDBContext()
            : base("name=KassaDBContext")
        {
            Log.Logger.Info($"����������� � ���� ������: " +
                $"{ConfigurationManager.ConnectionStrings["KassaDBContext"].ToString().Replace("|DataDirectory|", Application.StartupPath)}");
        }

        //������ ������ �������������� ������� ��
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
