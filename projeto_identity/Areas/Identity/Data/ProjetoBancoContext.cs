using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projeto_identity.Areas.Identity.Data;

namespace projeto_identity.Areas.Identity.Data;

public class ProjetoBancoContext : IdentityDbContext<Cliente>
{
    public DbSet<Cliente> Clientes { get; set; }
    public ProjetoBancoContext(DbContextOptions<ProjetoBancoContext> options) : base(options)
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
