﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public class ContaCorrente : Conta
    {
        public override void Saca(double valor)
        {
            this.Saldo -= (valor - 0.05);
        }

        public override void Deposita(double valor)
        {
            this.Saldo += (valor - 0.1);
        }
    }
}