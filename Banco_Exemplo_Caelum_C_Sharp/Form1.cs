using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public partial class Form1 : Form
    {
        private Conta conta;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.conta = new ContaCorrente();
            this.conta.Numero = 1;
            Cliente cliente = new Cliente("Victor");
            this.conta.Titular = cliente;


            //Exercicio 8 - capítulo 9
          /*  this.conta.Deposita(90);
            TotalizadorDeContas totalizador = new TotalizadorDeContas();
            totalizador.Adiciona(conta);
            MessageBox.Show(Convert.ToString(totalizador.SaldoTotal));
            Conta cp = new ContaPoupanca();
            cp.Deposita(30);
            totalizador.Adiciona(cp);
            MessageBox.Show(Convert.ToString(totalizador.SaldoTotal)); */

            textoTitular.Text = conta.Titular.Nome;
            textoNumero.Text = Convert.ToString(conta.Saldo);
            textoSaldo.Text = Convert.ToString(conta.Saldo);

        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            this.conta.Deposita(valorOperacao);
            textoSaldo.Text = Convert.ToString(this.conta.Saldo);
            MessageBox.Show("Sucesso");
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            this.conta.Saca(valorOperacao);
            textoSaldo.Text = Convert.ToString(this.conta.Saldo);
            MessageBox.Show("Sucesso");
        }

       
    }
}
