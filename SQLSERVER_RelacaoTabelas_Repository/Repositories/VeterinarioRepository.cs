using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQLSERVER.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private PetShopContext _context;

        public VeterinarioRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Cadastrar(Veterinario veterinario)
        {
            _context.Veterinarios.Add(veterinario);
        }

        public IList<Veterinario> Listar()
        {
            return _context.Veterinarios.Include(v=>v.ContratoTrabalho).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
