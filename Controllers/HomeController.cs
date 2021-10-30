using Microsoft.AspNetCore.Mvc;

namespace Home.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Principal()
        {
            Sessao.ChecaStatus(this);

            return View();
        }
    }
}