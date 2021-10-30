using System.Linq;
using System.Collections.Generic;

namespace Home.Models
{
    public class ContaService
    {
        public int Cadastra(Conta c)
        {
            using (var context = new HomeContext())
            {
                context.Add(c);
                context.SaveChanges();

                return c.Id;
            }
        }

        public Conta Detalha(int id)
        {
            using (var context = new HomeContext())
            {
                Conta c = context.Contas
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                return c;
            }
        }
        public void Atualiza(Conta c)
        {
            using (var context = new HomeContext())
            {
                Conta cnt = context.Contas.Find(c.Id);

                cnt.Desc = c.Desc;
                cnt.Valor = c.Valor;
                cnt.Venc = c.Venc;
                cnt.Quit = c.Quit;
                cnt.DataQuit = c.DataQuit;

                context.SaveChanges();
            }
        }

        public void Exclui(int id)
        {
            using (var context = new HomeContext())
            {
                Conta c = context.Contas.Find(id);

                context.Contas.Remove(c);
                context.SaveChanges();
            }
        }

        //TOTALIZADORES
        public List<Conta> LstReceita(int id)
        {
            using (var context = new HomeContext())
            {
                List<Conta> lstContas;

                if (id > 0)
                {
                    lstContas = context.Contas
                        .Where(c => c.Dest == 'r' && c.UsuarioId == id)
                        .ToList();
                }

                else
                {
                    lstContas = context.Contas
                        .Where(c => c.Dest == 'r')
                        .ToList();
                }

                return lstContas;
            }
        }

        public List<Conta> LstDespesas(int id)
        {
            using (var context = new HomeContext())
            {
                List<Conta> lstContas;

                if (id > 0)
                {
                    lstContas = context.Contas
                        .Where(c => c.Dest == 'd' && c.UsuarioId == id)
                        .ToList();
                }

                else
                {
                    lstContas = context.Contas
                        .Where(c => c.Dest == 'd')
                        .ToList();
                }

                return lstContas;
            }
        }

        /**************  TOTALIZADORES  **********/
        public double TotSaldo(int usr = 0)
        {
            using (var context = new HomeContext())
            {
                double saldo = 0, receita = 0, despesas = 0;

                //Totaliza Contas a Receber quitadas
                List<Conta> lstContaR;

                if (usr > 0)
                {
                    lstContaR = context.Contas
                        .Where(c => c.Dest == 'r' && c.Quit == true && c.UsuarioId == usr)
                        .ToList();
                }

                else
                {
                    lstContaR = context.Contas
                        .Where(c => c.Dest == 'r' && c.Quit == true)
                        .ToList();
                }

                foreach (Conta c in lstContaR)
                {
                    receita += c.Valor;
                }

                //Totaliza Contas a Pagar quitadas
                List<Conta> lstContaP;

                if (usr > 0)
                {
                    lstContaP = context.Contas
                        .Where(c => c.Dest == 'd' && c.Quit == true && c.UsuarioId == usr)
                        .ToList();
                }

                else
                {
                    lstContaP = context.Contas
                        .Where(c => c.Dest == 'd' && c.Quit == true)
                        .ToList();
                }

                foreach (Conta c in lstContaP)
                {
                    despesas += c.Valor;
                }

                saldo = receita - despesas;

                return saldo;
            }
        }

        public double TotReceita(int usr = 0)
        {
            using (var context = new HomeContext())
            {
                double total = 0;
                List<Conta> lstConta;

                if (usr > 0)
                {
                    lstConta = context.Contas
                        .Where(c => c.Dest == 'r' && c.Quit == false && c.UsuarioId == usr)
                        .ToList();
                }

                else
                {
                    lstConta = context.Contas
                        .Where(c => c.Dest == 'r' && c.Quit == false)
                        .ToList();
                }

                foreach (Conta c in lstConta)
                {
                    total += c.Valor;
                }

                return total;
            }
        }

        public double TotDespesas(int usr = 0)
        {
            using (var context = new HomeContext())
            {
                double total = 0;
                List<Conta> lstConta;

                if (usr > 0)
                {
                    lstConta = context.Contas
                        .Where(c => c.Dest == 'd' && c.Quit == false && c.UsuarioId == usr)
                        .ToList();
                }

                else
                {
                    lstConta = context.Contas
                        .Where(c => c.Dest == 'd' && c.Quit == false)
                        .ToList();
                }

                foreach (Conta c in lstConta)
                {
                    total += c.Valor;
                }

                return total;
            }
        }

    }
}