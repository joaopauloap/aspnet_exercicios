using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private PetShopContext _context;

        public AnimalRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Atualizar(Animal animal)
        {
            _context.Animais.Update(animal);
        }

        public IList<Animal> BuscarPor(Expression<Func<Animal, bool>> filtro)
        {
            return _context.Animais.Where(filtro).Include(a => a.Plano).ToList();
        }

        public Animal BuscarPorId(int id)
        {
            return _context.Animais.Include(a=>a.Plano).Where(a=>a.AnimalId == id).FirstOrDefault();
        }

        public void Cadastrar(Animal animal)
        {
            _context.Animais.Add(animal);
        }

        public IList<Animal> Listar()
        {
            return _context.Animais.ToList();
        }

        public void Remover(int id)
        {
            Animal animal = _context.Animais.Find(id);
            _context.Animais.Remove(animal);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
