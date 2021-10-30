using Microsoft.AspNetCore.Mvc;
using Home.Models;

namespace Home.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService us = new UsuarioService();

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario u)
        {
            if (u.Id != 0)
            {
                us.Atualiza(u);

                return Redirect("/Usuario/Detalhes");
            }

            else
            {
                us.Cadastra(u);

                ViewBag.Msg = "Cadastro realizado! Entre para Continuar...";

                return View("../Sessao/Login");
            }
        }
        
        public IActionResult Excluir(int id)
        {
            Sessao.ChecaStatus(this);

            return View("../Sessao/Login");
        }
    }
}