using System.ComponentModel.DataAnnotations;

namespace Home.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [StringLength(40)]
        public string Nome { get; set; }
        
        [StringLength(10)]
        public string Login { get; set; }
        
        [StringLength(64)]
        public string Senha { get; set; }
    }
}