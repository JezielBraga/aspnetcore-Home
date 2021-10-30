using System.Linq;
using System.Collections.Generic;

namespace Home.Models
{
    public class UsuarioService
    {
        public int Cadastra(Usuario u)
        {
            using (var context = new HomeContext())
            {
                u.Senha = Hashing.ToSHA256(u.Senha);

                context.Add(u);
                context.SaveChanges();
                
                return u.Id;
            }
        }

        public List<Usuario> Lista()
        {
            using (var context = new HomeContext())
            {
                List<Usuario> lstUsuarios =
                    context.Usuarios.ToList();
                
                return lstUsuarios;
            }
        }

        public Usuario Detalha(int id)
        {
            using (var hc = new HomeContext())
            {
                Usuario u = hc.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                return u;
            }
        }

        public void Atualiza(Usuario u)
        {
            using (var context = new HomeContext())
            {
                Usuario usr = context.Usuarios.Find(u.Id);

                usr.Login = u.Login;
                usr.Nome = u.Nome;
                usr.Senha = Hashing.ToSHA256(u.Senha);

                context.SaveChanges();
            }
        }

        public void Exclui(int id)
        {
            using (var context = new HomeContext())
            {
                Usuario u = context.Usuarios.Find(id);

                context.Usuarios.Remove(u);
                context.SaveChanges();
            }
        }
    }
}