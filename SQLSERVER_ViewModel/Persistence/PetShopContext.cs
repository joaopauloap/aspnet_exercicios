using CRUD_SQLSERVER.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQLSERVER.Persistence
{
    public class PetShopContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<ContratoTrabalho> ContratosTrabalhos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<AnimalVeterinario> AnimaisVeterinarios { get; set; }


        public PetShopContext(DbContextOptions op) : base(op)
        {
        }


        //Necessario para quando usar relação N:M
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<AnimalVeterinario>().HasKey(av => new { av.AnimalId, av.VeterinarioId, av.DataHora });

            //Configurar o relacionamento da associativa com o animal
            modelBuilder.Entity<AnimalVeterinario>()
                .HasOne(av => av.Animal)
                .WithMany(a => a.AnimaisVeterinarios)
                .HasForeignKey(av => av.AnimalId);

            //Configurar o relacionamento da associativa com o veterinario
            modelBuilder.Entity<AnimalVeterinario>()
                .HasOne(av => av.Veterinario)
                .WithMany(v => v.AnimaisVeterinarios)
                .HasForeignKey(av => av.VeterinarioId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
