using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco_Exemplo_Caelum_C_Sharp.Contas;


namespace Banco_Exemplo_Caelum_C_Sharp
{
    public partial class Form1 : Form
    {
        private IList<Conta> contas;
        private IList<Conta> contasTransferencia;
        private Dictionary<string, Conta> dicionario;


        public Form1()
        {
            InitializeComponent();
        }

        public void AdcionaConta(Conta conta)
        {
            contas.Add(conta);
            comboContas.Items.Add(conta);
            this.dicionario.Add(conta.Titular.Nome, conta);

        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dicionario = new Dictionary<string, Conta>();
            contas = new List<Conta>();

            Conta c1 = new ContaCorrente();
            c1.Titular = new Cliente("Victor");
            this.AdcionaConta(c1);

            Conta c2 = new ContaCorrente();
            c2.Titular = new Cliente("Mauricio");
            this.AdcionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("Osni");
            this.AdcionaConta(c3);

            comboContas.DisplayMember = "Titular";

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


            Conta selecionada = (Conta)comboContas.SelectedItem;

            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            selecionada.Deposita(valorOperacao);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            MessageBox.Show("Sucesso");
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {

            Conta selecionada = (Conta) comboContas.SelectedItem;

            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            try
            {
                selecionada.Saca(valorOperacao);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                MessageBox.Show("Sucesso");
            }
            catch (SaldoInsulficienteException ex)
            {

                MessageBox.Show("Saldo insuficiente");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não é possivel sacar um valor negativo");
            }
            
        }


        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            contasTransferencia = new List<Conta>();

          

            foreach (Conta conta in contas)
            {
                if (!Convert.ToString(comboContas.SelectedItem).Contains(conta.Titular.Nome))
                { comboTransferencia.Items.Add(conta); }
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

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            TotalizadorDeTributos totalizador = new TotalizadorDeTributos();

            foreach  (Conta conta in contas)
            {
                if (conta is ITributavel)
                { 
                    ContaCorrente corrente = (ContaCorrente)conta;
                    totalizador.Adiciona(corrente);                    
                }
            }
            MessageBox.Show("Total de tributos = " + totalizador.Total);

        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeTitular = textoBuscaTitular.Text;
                Conta conta = dicionario[nomeTitular];

                textoTitular.Text = conta.Titular.Nome;
                textoNumero.Text = Convert.ToString(conta.Numero);
                textoSaldo.Text = Convert.ToString(conta.Saldo);
                comboContas.SelectedItem = conta;
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel encontrar esse titular"); ;
            }
            
        }

  

       
    }
}
