using Microsoft.EntityFrameworkCore;
using PetShopApi.Models;

namespace PetShopApi.Persistence
{
    public class PetShopContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<ContratoTrabalho> ContratosTrabalhos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>().HasKey(c => new { c.AnimalId, c.VeterinarioId, c.DataHora });
            
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Animal)
                .WithMany(c => c.Consultas)
                .HasForeignKey(c => c.AnimalId);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Veterinario)
                .WithMany(c => c.Consultas)
                .HasForeignKey(c => c.VeterinarioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
