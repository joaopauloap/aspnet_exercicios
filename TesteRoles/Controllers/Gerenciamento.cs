using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TesteRoles.Areas.Identity.Data;

namespace TesteRoles.Controllers
{
    public class Gerenciamento : Controller
    {
        private TesteRolesContext _context;
        private UserManager<Usuario> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public Gerenciamento(TesteRolesContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Cadastrar(string Email, string Password)
        {
            var user = new Usuario { UserName = Email, Email = Email };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                var adminRole = _roleManager.FindByNameAsync("Admin").Result;
                if (adminRole != null)
                {
                    await _userManager.AddToRoleAsync(user, adminRole.Name);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
