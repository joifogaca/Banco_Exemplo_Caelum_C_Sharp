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
        private IList<Conta> contas;
        private IList<Conta> contasTransferencia;


        public Form1()
        {
            InitializeComponent();
        }

        public void AdcionaConta(Conta conta)
        {
            contas.Add(conta);
            comboContas.Items.Add("Titular: " + conta.Titular.Nome);

        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            contas = new List<Conta>();

            Conta c1 = new ContaCorrente();
            c1.Numero = 1;
            c1.Titular = new Cliente("Victor");
            this.AdcionaConta(c1);

            Conta c2 = new ContaCorrente();
            c2.Numero = 2;
            c2.Titular = new Cliente("Mauricio");
            this.AdcionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Numero = 3;
            c3.Titular = new Cliente("Osni");
            this.AdcionaConta(c3);


            

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
            contasTransferencia = new List<Conta>();

          

            foreach (Conta conta in contas)
            {
                if (!Convert.ToString(comboContas.SelectedItem).Contains(conta.Titular.Nome))
                { comboTransferencia.Items.Add("Titular: " + conta.Titular.Nome); }
            }

            Conta selecionada;
            string nomeCombo = Convert.ToString(comboContas.SelectedItem);

            foreach (Conta conta in contas)
            {
                if (nomeCombo.Contains(conta.Titular.Nome))
                { selecionada = conta;
                textoTitular.Text = selecionada.Titular.Nome;
                textoNumero.Text = Convert.ToString(selecionada.Numero);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                
                }
                
            }

            

            
        }

        private void Transferir_Click(object sender, EventArgs e)
        {
            contas[comboContas.SelectedIndex].Saca(Convert.ToDouble(textoValor.Text));
            contasTransferencia[comboTransferencia.SelectedIndex].Deposita(Convert.ToDouble(textoValor.Text));
            MessageBox.Show("Transferência realizada com sucesso!");
            textoSaldo.Text = Convert.ToString(contas[comboContas.SelectedIndex].Saldo);
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

      

       
    }
}
