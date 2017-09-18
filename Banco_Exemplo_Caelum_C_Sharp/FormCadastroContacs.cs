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
using Banco_Exemplo_Caelum_C_Sharp.Busca;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public partial class FormCadastroConta : Form
    {
        private ICollection<string> devedores;
        private Form1 formPrincipal;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            GeradorDeDevedores gerador = new GeradorDeDevedores();
            this.devedores = gerador.GerarList();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            // Exercicio teste com List e Set
            //string titular = textoTitular.Text;

            //bool ehDevedor = this.devedores.Contains(titular);

            //for (int i = 0; i < 3000; i++)
            //{
            //    ehDevedor = this.devedores.Contains(titular);
            //}


           // if (!ehDevedor)
           // {

                Conta novaConta;

                if (ComboTipoConta.SelectedText == "Conta Poupança")
                { novaConta = new ContaPoupanca(); }
                else
                { novaConta = new ContaCorrente(); }

                novaConta.Titular = new Cliente(textoTitular.Text);

                this.formPrincipal.AdcionaConta(novaConta);

                MessageBox.Show("Nova Conta Criada");
            //}
         //   else
            //{
                MessageBox.Show("devedor");
           // }
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximoNumero);
        }

        
    }
}
