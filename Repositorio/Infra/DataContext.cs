using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Infra
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaBancaria>().HasKey(p => p.Id);
            modelBuilder.Entity<Movimento>().HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}