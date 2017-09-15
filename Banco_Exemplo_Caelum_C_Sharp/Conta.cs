using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public abstract class Conta
    {
        public Conta()
        {

        }

        public int Numero { get; set; }
        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }

        public abstract void Deposita(double valor);
        

        public abstract void Saca(double valor);
  
    }
}
