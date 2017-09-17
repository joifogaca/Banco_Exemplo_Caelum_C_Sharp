using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banco_Exemplo_Caelum_C_Sharp.Contas
{
    public class ContaPoupanca : Conta
    {
        public override void Saca(double valor)
        {
            if (valor + 0.10 > this.Saldo)
            {
                throw new SaldoInsulficienteException();
            }
            else
            {
                this.Saldo -= valor + 0.10;
            }
        }

        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        
    }
}
