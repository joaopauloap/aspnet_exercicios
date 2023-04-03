using CRUD_SQLSERVER.Models;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public interface IAnimalRepository
    {
        void Atualizar(Animal animal);
        IList<Animal> BuscarPor(Expression<Func<Animal, bool>> filtro);
        void Cadastrar(Animal animal);
        Animal BuscarPorId(int id);
        IList<Animal> Listar();
        void Remover(int id);
        void Salvar();


    }
}
