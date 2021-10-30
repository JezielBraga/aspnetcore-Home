using System.ComponentModel.DataAnnotations;
using System;

namespace Home.Models
{
    public class Conta
    {
        public int Id { get; set; }
        
        [StringLength(25)]
        public string Desc { get; set; }
        public char Dest { get; set; }
        public double Valor { get; set; }
        public DateTime Venc {get; set; }
        public bool Quit { get; set; }
        public DateTime DataQuit { get; set; }
        public int UsuarioId { get; set; }
    }
}