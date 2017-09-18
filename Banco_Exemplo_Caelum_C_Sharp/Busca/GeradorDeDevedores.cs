using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Exemplo_Caelum_C_Sharp.Busca
{
    public class GeradorDeDevedores
    {
        public ICollection<string> GerarList()
        {
            HashSet<string> nomes = new HashSet<string>();
            for (int i = 0; i < 3000; i++)
            {
                nomes.Add("devedor " + i);  
            }
            return nomes;
        }
    }
}
