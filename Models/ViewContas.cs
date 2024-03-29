using System.Collections.Generic;

namespace Home.Models
{
    public class ViewContas
    {
        public double TotSaldo { get; set; }
        public double TotReceita { get; set; }
        public double TotDespesas { get; set; }
        public Conta Conta { get; set; }
        public List<Conta> LstContasR { get; set;}
        public List<Conta> LstContasD { get; set; }
        public List<Usuario> LstUsuarios { get; set; }
    }
}