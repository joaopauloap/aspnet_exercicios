using ProjetoBanco.Models;

namespace ProjetoBanco.Repositories
{
    public interface IChavePixRepository
    {
        void Cadastrar(ChavePix chavePix);
        void Remover(int id);
        bool VerificarExistencia(string chavePix);
        List<ChavePix> BuscarTodasPorContaId(int id);
        void Salvar();
    }
}
