using CRUD_SQLSERVER.Models;

namespace CRUD_SQLSERVER.Repositories
{
    public interface IVeterinarioRepository
    {
        IList<Veterinario> Listar();
        void Cadastrar(Veterinario veterinario);
        void Salvar();
    }
}
