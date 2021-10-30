using System.ComponentModel.DataAnnotations;

namespace Home.Models
{
    public class Senha
    {
        public int Id { get; set; }
        
        [StringLength(20)]
        public string Desc { get; set; }
        
        [StringLength(20)]
        public string Valor { get; set; }
        public int UsuarioId { get; set; }
    }
}