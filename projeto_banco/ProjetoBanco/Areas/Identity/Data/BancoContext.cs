using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;

namespace ProjetoBanco.Areas.Identity.Data;

public class BancoContext : IdentityDbContext<Cliente>
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ContaCorrente> ContasCorrentes { get; set; }
    public DbSet<ContaPoupanca> ContasPoupancas { get; set; }
    public DbSet<ChavePix> ChavesPix { get; set; }

    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
