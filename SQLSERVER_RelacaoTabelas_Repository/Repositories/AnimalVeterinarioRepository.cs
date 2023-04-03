using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public class AnimalVeterinarioRepository : IAnimalVeterinarioRepository
    {
        private PetShopContext _context;

        public AnimalVeterinarioRepository(PetShopContext context)
        {
            _context = context;
        }

        public IList<AnimalVeterinario> BuscarPor(Expression<Func<AnimalVeterinario, bool>> filtro)
        {
            return _context.AnimaisVeterinarios.Where(filtro).Include(av => av.Veterinario).ToList();
        }

        public void Cadastrar(AnimalVeterinario animalVeterinario)
        {
            _context.AnimaisVeterinarios.Add(animalVeterinario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
