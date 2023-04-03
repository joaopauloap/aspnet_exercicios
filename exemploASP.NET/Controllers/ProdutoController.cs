using exemploASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace exemploASP.NET.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Produto produto)         //public IActionResult Cadastrar(string nome, decimal preco, int quantidade)
        {
            ViewData["nome"] = produto.Nome;
            ViewBag.preco = produto.Preco;
            ViewBag.prod = produto;
            
            TempData["msg"] = "Produto cadastrado com sucesso!";
            TempData["nome"] = produto.Nome;

            //return Content($"Nome do produto: {produto.Nome}, Preço: {produto.Preco}, Quantidade: {produto.Quantidade}");
            //return View(produto);
            return RedirectToAction("Cadastrar");   //sempre usar no final de um post para evitar reenvio de formulario.. redirectoaction sempre redireciona pra um get
        }


    }
}
