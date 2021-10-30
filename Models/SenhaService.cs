using System.Linq;
using System.Collections.Generic;

namespace Home.Models
{
    public class SenhaService
    {
        public int Cadastra(Senha s)
        {
            using (var context = new HomeContext())
            {
                context.Add(s);
                context.SaveChanges();

                return s.Id;
            }
        }

        public Senha Detalha(int id)
        {
            using (var context = new HomeContext())
            {
                Senha s = context.Senhas.Where(s => s.Id == id).FirstOrDefault();

                return s;
            }
        }

        public List<Senha> Lista(int id = 0)
        {
            using (var context = new HomeContext())
            {
                List<Senha> lstSenhas = context.Senhas.Where(ls => ls.UsuarioId == id).ToList();

                return lstSenhas;
            }
        }

        public void Atualiza(Senha s)
        {
            using (var context = new HomeContext())
            {
                Senha snh = context.Senhas.Find(s.Id);

                snh.Desc = s.Desc;
                snh.Valor = s.Valor;

                context.SaveChanges();
            }
        }

        public void Exclui(int id)
        {
            using (var context = new HomeContext())
            {
                Senha s = context.Senhas.Find(id);

                context.Senhas.Remove(s);
                context.SaveChanges();
            }
        }
    }
}