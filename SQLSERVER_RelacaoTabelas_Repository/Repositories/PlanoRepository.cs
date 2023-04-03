using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private PetShopContext _context;

        public PlanoRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Cadastrar(Plano plano)
        {
            _context.Planos.Add(plano);
        }

        public IList<Plano> Listar()
        {
            return _context.Planos.ToList();
        }

        public IList<Plano> BuscarPor(Expression<Func<Plano, bool>> filtro)
        {
            return _context.Planos.Where(filtro).OrderBy(p=>p.Nome).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
