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
    public partial class FormCadastroConta : Form
    {

        private Form1 formPrincipal;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            Conta novaConta;

            if (ComboTipoConta.SelectedText == "Conta Poupança")
            { novaConta = new ContaPoupanca(); }
            else
            { novaConta = new ContaCorrente(); }

            novaConta.Titular = new Cliente(textoTitular.Text);

            this.formPrincipal.AdcionaConta(novaConta);
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximoNumero);
        }

        
    }
}
