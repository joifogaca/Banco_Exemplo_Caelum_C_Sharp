﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Exemplo_Caelum_C_Sharp.Contas
{
    public class ContaCorrente : Conta, ITributavel
    {
        public override void Saca(double valor)
        {
            if (valor > this.Saldo + 0.05)
            { 
                throw new SaldoInsulficienteException();
            }
            else
            {
                this.Saldo -= (valor - 0.05);
            }
        }

        public override void Deposita(double valor)
        {
            this.Saldo += (valor - 0.1);
        }

        public double CalculaTributo()
        {
            return this.Saldo * 0.05;
        }
    }
}
