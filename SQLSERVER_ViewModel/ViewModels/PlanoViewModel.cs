using CRUD_SQLSERVER.Models;

namespace CRUD_SQLSERVER.ViewModels
{
    public class PlanoViewModel
    {
        public Plano Plano { get; set; }
        public IList<Plano> Lista { get; set; }
    }
}
