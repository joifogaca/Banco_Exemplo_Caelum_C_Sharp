using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public class Conta
    {
        public Conta()
        {

        }

        public int Numero { get; set; }
        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }

        public virtual void Deposita(double valor)
        {
            this.Saldo += valor;
        }

       public virtual void Saca(double valor)
        {
            this.Saldo -= valor;
        }
    }
}
