using ProjetoBanco.Models;
using ProjetoBanco.Areas.Identity.Data;

namespace ProjetoBanco.Repositories
{
    public class ChavePixRepository : IChavePixRepository
    {
        private BancoContext _context;

        public ChavePixRepository(BancoContext context)
        {
            _context = context;
        }

        public List<ChavePix> BuscarTodasPorContaId(int id)
        {
           return _context.ChavesPix.Where(cp => cp.ContaId == id).OrderBy(cp => cp.Tipo).ToList();
        }

        public void Cadastrar(ChavePix chavePix)
        {
            _context.ChavesPix.Add(chavePix);
            
        }

        public void Remover(int id)
        {
            ChavePix chavePix = _context.ChavesPix.Find(id);
            _context.ChavesPix.Remove(chavePix);
            
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public bool VerificarExistencia(string chavePix)
        {
            return _context.ChavesPix.Any(cp=>cp.Chave==chavePix);
        }
    }
}
