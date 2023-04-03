using CRUD_SQLSERVER.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQLSERVER.Persistence
{
    public class PetShopContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public PetShopContext(DbContextOptions op) : base(op)
        {

        }
    }
}
