using Microsoft.AspNetCore.Mvc;
using Home.Models;

namespace Home.Controllers
{
    public class SessaoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            if (Sessao.ValidaUsuario(u, this) == true)
                return RedirectToAction("Principal", "Home");

            else
            {
                ViewBag.Msg = "Tente novamente!";

                return View("Login");
            }
        }

        public IActionResult Logout()
        {
            Sessao.LimpaUsuario(this);

            ViewBag.Msg = "Até logo!";

            return View("Login");
        }

        public IActionResult UsrObgt()
        {
            ViewBag.Msg = "Faça login para continuar!";

            return View("Login");
        }
    }
}