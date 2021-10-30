using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Home.Models;
using System.Collections.Generic;

namespace Home.Controllers
{
    public class SenhaController : Controller
    {
        SenhaService ss = new SenhaService();
        ViewSenhas vs = new ViewSenhas();
            
        public IActionResult Senhas()
        {
            Sessao.ChecaStatus(this);

            vs.LstSenhas = new List<Senha>();
            
            if (HttpContext.Session.GetInt32("id") != null)
                vs.LstSenhas =
                    ss.Lista((int)HttpContext.Session.GetInt32("id"));
            
            ViewBag.CadEdit = "Nova Senha";

            return View(vs);
        }

        [HttpPost]
        public IActionResult Cadastrar(ViewSenhas vs)
        {
            if (vs.Senha.Id > 0)
                ss.Atualiza(vs.Senha);

            else
                ss.Cadastra(vs.Senha);

            return Redirect("Senhas");
        }

        public IActionResult Alterar(int id)
        {
            Sessao.ChecaStatus(this);

            vs.LstSenhas = new List<Senha>();
            vs.Senha = ss.Detalha(id);
            
            if (HttpContext.Session.GetInt32("id") != null)
                vs.LstSenhas =
                    ss.Lista((int)HttpContext.Session.GetInt32("id"));
            
            ViewBag.CadEdit = "Alterando";

            return View("Senhas", vs);
        }

        public IActionResult Excluir(int id)
        {
            Sessao.ChecaStatus(this);

            ss.Exclui(id);

            return Redirect("Senhas");
        }
    }
}