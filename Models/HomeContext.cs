using Microsoft.EntityFrameworkCore;

namespace Home.Models
{
    public class HomeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strConection = "Server=localhost;Database=Home;Uid=root;Pwd=;";
            optionsBuilder.UseMySql(strConection, ServerVersion.AutoDetect(strConection));
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Senha> Senhas { get; set; }
        public DbSet<Conta> Contas { get; set; }
    }
}