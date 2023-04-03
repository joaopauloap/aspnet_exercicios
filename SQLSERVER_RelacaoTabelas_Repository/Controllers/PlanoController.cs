using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_SQLSERVER.Controllers
{
    public class PlanoController : Controller
    {
        private IPlanoRepository _planoRepository;
        public PlanoController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public IActionResult Index()
        {
            ViewBag.planos = _planoRepository.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Plano plano)
        {
            _planoRepository.Cadastrar(plano);
            _planoRepository.Salvar();
            TempData["msg"] = "Plano cadastrado com sucesso";
            return RedirectToAction("Index");
        }

    }
}
