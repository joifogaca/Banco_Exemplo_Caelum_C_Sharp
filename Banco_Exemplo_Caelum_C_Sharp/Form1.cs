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
        private Conta[] contas;
        private Conta[] contasTransferencia;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            contas = new Conta[3];

            this.contas[0] = new ContaCorrente();
            this.contas[0].Numero = 1;
            this.contas[0].Titular = new Cliente("Victor");

            this.contas[1] = new ContaPoupanca();
            this.contas[1].Numero = 2;
            this.contas[1].Titular = new Cliente("mauricio");

            this.contas[2] = new ContaCorrente();
            this.contas[2].Numero = 3;
            this.contas[2].Titular = new Cliente("osni");


            foreach (Conta conta in contas)
            {
                comboContas.Items.Add("Titular: " + conta.Titular.Nome);
            }

            //Exercicio 8 - capítulo 9
          /*  this.conta.Deposita(90);
            TotalizadorDeContas totalizador = new TotalizadorDeContas();
            totalizador.Adiciona(conta);
            MessageBox.Show(Convert.ToString(totalizador.SaldoTotal));
            Conta cp = new ContaPoupanca();
            cp.Deposita(30);
            totalizador.Adiciona(cp);
            MessageBox.Show(Convert.ToString(totalizador.SaldoTotal)); */


        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;

            Conta selecionada = contas[indice];

            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            selecionada.Deposita(valorOperacao);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            MessageBox.Show("Sucesso");
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;

            Conta selecionada = contas[indice];

            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            selecionada.Saca(valorOperacao);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            MessageBox.Show("Sucesso");
        }


        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            contasTransferencia = new Conta [3];

            for (int i = 0; i < 3; i++)
            {
                if (i == comboContas.SelectedIndex)
                {
                    if (i != contas.Length - 1)
                    { contasTransferencia[i] = contas[++i]; }
                }
                else
                {
                    contasTransferencia[i] = contas[i];
                }
                
            }

            foreach (Conta conta in contasTransferencia)
            {
                if (conta != null)
                { comboTransferencia.Items.Add("Titular: " + conta.Titular.Nome); }
            }

            

            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void Transferir_Click(object sender, EventArgs e)
        {
            contas[comboContas.SelectedIndex].Saca(Convert.ToDouble(textoValor.Text));
            contasTransferencia[comboTransferencia.SelectedIndex].Deposita(Convert.ToDouble(textoValor.Text));
            MessageBox.Show("Transferência realizada com sucesso!");
            textoSaldo.Text = Convert.ToString(contas[comboContas.SelectedIndex].Saldo);
        }

      

       
    }
}
