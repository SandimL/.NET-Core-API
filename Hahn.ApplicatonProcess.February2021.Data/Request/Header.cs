using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Request
{
    public class Header
    {
        public string chave { get; set; }
        public string valor { get; set; }

        public Header(string chave, string valor)
        {
            this.chave = chave;
            this.valor = valor;
        }
    }
}
