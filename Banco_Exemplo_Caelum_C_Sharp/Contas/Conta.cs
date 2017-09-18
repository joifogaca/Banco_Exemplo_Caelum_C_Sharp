using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco_Exemplo_Caelum_C_Sharp.Contas
{
    public abstract class Conta
    {
        private static int numeroDeContas;
        public static int ProximoNumero { get; protected set; }

        

        public Conta()
        {
            Conta.numeroDeContas++;
            this.Numero = Conta.numeroDeContas;
            Conta.ProximoNumero = Conta.numeroDeContas + 1;
        }

        public override string ToString()
        {
            return "Titular : " + this.Titular.Nome;
        }

        public int Numero { get; protected set; }
        public double Saldo { get ; protected set; }

        public Cliente Titular { get; set; }

        public abstract void Deposita(double valor);
        

        public abstract void Saca(double valor);
  
    }
}
