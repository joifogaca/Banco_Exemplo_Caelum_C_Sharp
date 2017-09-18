using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_Exemplo_Caelum_C_Sharp.Contas;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public class TotalizadorDeContas
    {
        public double SaldoTotal { get; protected set; }

        public void Adiciona(Conta conta)
        {
            this.SaldoTotal += conta.Saldo;
        }
    }
}
