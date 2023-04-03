using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Models;

namespace UsuarioAPI.Persistence
{
    public class UsuarioDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {   
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> op) : base(op)
        {

        }
    }
}
