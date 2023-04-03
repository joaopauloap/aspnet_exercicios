using CRUD_SQLSERVER.Models;
using System.Linq.Expressions;

namespace CRUD_SQLSERVER.Repositories
{
    public interface IPlanoRepository
    {
        IList<Plano> Listar();
        void Cadastrar(Plano plano);
        IList<Plano> BuscarPor(Expression<Func<Plano, bool>> filtro);
        void Salvar();
    }
}
