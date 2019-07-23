using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Retorno
    {
        public bool erro { get; set; } = false;
        public int id { get; set; } = 0;
        public string mensagem { get; set; } = "";
        public double valor { get; set; } = 0;
        public string link { get; set; } = "";
        public int retorno { get; set; } = 0;
    }

    public class RetornoCEP
    {
        public string codibge { get; set; } = "";
        public string cidade { get; set; } = "";
        public string estado { get; set; } = "";
        public string ddd { get; set; } = "";
        public string bairro { get; set; } = "";
        public string endereco { get; set; } = "";
    }
}
