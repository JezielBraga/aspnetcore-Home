using System.Linq;
using System.Collections.Generic;
using System;

namespace Home.Models
{
    public class ContaService
    {
        /**************  AÇÕES  ***********/
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

        /**************  LISTAS  ************/
        public List<Conta> LstReceita(Conta cnt)
        {
            using (var context = new HomeContext())
            {
                List<Conta> lstContas;

                var result = context.Contas
                        .Where(c => c.Dest == 'r');

                if (cnt.UsuarioId > 0)
                    result = result
                        .Where(c => c.UsuarioId == cnt.UsuarioId);

                if (cnt.Venc.Year > 1)
                    result = result
                        .Where(c => c.Venc <= cnt.Venc);

                lstContas = result.ToList();

                return lstContas;
            }
        }

        public List<Conta> LstDespesas()
        {
            using (var context = new HomeContext())
            {
                List<Conta> lstContas;

                var result = context.Contas
                        .Where(c => c.Dest == 'd')
                        .OrderBy(c => c.Venc);
                
                /*if (cnt.UsuarioId > 0)
                    result = result
                        .Where(c => c.UsuarioId == cnt.UsuarioId);

                if (cnt.Venc.Year > 1)
                    result = result
                        .Where(c => c.Venc <= cnt.Venc);*/

                lstContas = result.ToList();

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
                List<double> lstValorR;

                var resultR = context.Contas
                    .Where(c => c.Dest == 'r' && c.Quit == true);

                if (usr > 0)
                    resultR = resultR
                        .Where(c => c.UsuarioId == usr);

                lstValorR = resultR
                    .Select(c => c.Valor)
                    .ToList();

                foreach (var valor in lstValorR)
                {
                    receita += valor;
                }

                //Totaliza Contas a Pagar quitadas
                List<double> lstValorP;

                var resultP = context.Contas
                    .Where(c => c.Dest == 'd' && c.Quit == true);

                if (usr > 0)
                    resultP = resultP
                        .Where(c => c.UsuarioId == usr);

                lstValorP = resultP
                    .Select(c => c.Valor)
                    .ToList();

                foreach (var valor in lstValorP)
                {
                    despesas += valor;
                }

                saldo = receita - despesas;

                return saldo;
            }
        }

        public double TotReceita(Conta cnt)
        {
            using (var context = new HomeContext())
            {
                double total = 0;
                List<double> lstValor;

                var result = context.Contas
                    .Where(c => c.Dest == 'r' && c.Quit == false);

                if (cnt.UsuarioId > 0)
                    result = result
                        .Where(c => c.UsuarioId == cnt.UsuarioId);

                if (cnt.Venc.Year > 1)
                    result = result
                        .Where(c => c.Venc <= cnt.Venc);

                lstValor = result
                    .Select(c => c.Valor)
                    .ToList();

                foreach (var valor in lstValor)
                {
                    total += valor;
                }

                return total;
            }
        }

        public double TotDespesas(Conta cnt)
        {
            using (var context = new HomeContext())
            {
                double total = 0;
                List<double> lstValor;

                var result = context.Contas
                    .Where(c => c.Dest == 'd' && c.Quit == false);

                if (cnt.UsuarioId > 0)
                    result = result
                        .Where(c => c.UsuarioId == cnt.UsuarioId);

                if (cnt.Venc.Year > 1)
                    result = result
                        .Where(c => c.Venc <= cnt.Venc);

                lstValor = result
                    .Select(c => c.Valor)
                    .ToList();

                foreach (var valor in lstValor)
                {
                    total += valor;
                }

                return total;
            }
        }

    }
}