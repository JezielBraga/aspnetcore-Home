using Microsoft.AspNetCore.Mvc;
using Home.Models;
using Microsoft.AspNetCore.Http;

namespace Home.Controllers
{
    public class ContaController : Controller
    {
        ViewContas vc = new ViewContas();
        UsuarioService us = new UsuarioService();
        ContaService cs = new ContaService();

        public IActionResult Resumo()
        {
            Sessao.ChecaStatus(this);

            vc.LstUsuarios = us.Lista();
            vc.TotSaldo = cs.TotSaldo();
            vc.TotReceita = cs.TotReceita();
            vc.TotDespesas = cs.TotDespesas();

            return View(vc);
        }

        public IActionResult Receita(int id = 0)
        {
            Sessao.ChecaStatus(this);

            vc.LstContas = cs.LstReceita(id);
            //Lista de Usuarios

            ViewBag.CadEdit = "Nova Conta";

            return View(vc);
        }

        public IActionResult Despesas(int id = 0)
        {
            Sessao.ChecaStatus(this);

            vc.LstContas = cs.LstDespesas(id);
            //Lista de Usuarios

            ViewBag.CadEdit = "Nova Conta";

            return View(vc);
        }

        [HttpPost]
        public IActionResult Cadastrar(ViewContas vc)
        {
            Sessao.ChecaStatus(this);

            if (vc.Conta.Id > 0)
                cs.Atualiza(vc.Conta);

            else
                cs.Cadastra(vc.Conta);

            string view =
                (HttpContext.Session.GetString("pg") == "r") ? "Receita" : "Despesas";

            return Redirect(view);
        }

        public IActionResult Detalhes(int id)
        {
            Sessao.ChecaStatus(this);

            vc.Conta = cs.Detalha(id);

            return View(vc);
        }






        public IActionResult Alterar(int id)
        {
            Sessao.ChecaStatus(this);

            return View("Contas");
        }

        public IActionResult Excluir(int id)
        {
            Sessao.ChecaStatus(this);

            return Redirect("Contas");
        }
    }
}