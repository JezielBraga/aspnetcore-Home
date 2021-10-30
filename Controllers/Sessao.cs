using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Home.Models;
using System.Linq;

namespace Home.Controllers
{
    public static class Sessao
    {
        public static void ChecaStatus(Controller c)
        {
            if (c.HttpContext.Session.GetString("nome") == null)
                c.Request.HttpContext.Response.Redirect("/Sessao/UsrObgt");
        }

        public static bool ValidaUsuario(Usuario u, Controller c)
        {
            using (HomeContext hc = new HomeContext())
            {
                u.Senha = Hashing.ToSHA256(u.Senha);

                Usuario usrEncotrado =
                    hc.Usuarios.Where(usr => usr.Login == u.Login && usr.Senha == u.Senha).FirstOrDefault();

                if (usrEncotrado != null)
                {
                    c.HttpContext.Session.SetInt32("id", usrEncotrado.Id);
                    c.HttpContext.Session.SetString("nome", usrEncotrado.Nome);

                    return true;
                }

                else
                    return false;
            }
        }

        public static void LimpaUsuario(Controller c)
        {
            c.HttpContext.Session.Clear();
        }
    }
}