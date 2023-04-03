using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using CRUD_SQLSERVER.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_SQLSERVER.Controllers
{
    public class PlanoController : Controller
    {

        private PetShopContext _context;
        public PlanoController(PetShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.planos = _context.Planos.ToList();
            PlanoViewModel viewModel = new PlanoViewModel()
            {
                //Lista = _planoRepository.Listar()
            };
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Plano plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();
            TempData["msg"] = "Plano cadastrado com sucesso";
            return RedirectToAction("Index");
        }

    }
}
