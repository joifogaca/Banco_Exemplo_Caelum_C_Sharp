using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco_Exemplo_Caelum_C_Sharp
{
    public class Cliente
    {
       

        public Cliente(string nome)
        {
            // TODO: Complete member initialization
            this.Nome = nome;
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public string Nome { get; set; }
    }
}
