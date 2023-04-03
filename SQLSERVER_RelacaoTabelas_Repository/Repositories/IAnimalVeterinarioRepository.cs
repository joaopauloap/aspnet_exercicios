using CRUD_SQLSERVER.Models;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public interface IAnimalVeterinarioRepository
    {
        IList<AnimalVeterinario> BuscarPor(Expression<Func<AnimalVeterinario, bool>> filtro);
        void Cadastrar(AnimalVeterinario animalVeterinario);
        void Salvar();
    }
}
