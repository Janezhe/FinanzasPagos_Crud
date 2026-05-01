using Microsoft.EntityFrameworkCore;
using FinanzasPagos_Crud.Models;

namespace FinanzasPagos_Crud.Data
{
    public class FinanzasDb : DbContext
    {
        public FinanzasDb(DbContextOptions<FinanzasDb> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>()
                        .Property(p => p.Estado)
                        .HasConversion<string>()
                        .HasMaxLength(20);
        }
    }
}