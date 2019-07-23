using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Boleto_movimento
    {
        public int codigo { get; set; }
        public Boleto boleto { get; set; }
        public string movimento_codigo { get; set; }
        public string movimento_descricao { get; set; }
        public DateTime data { get; set; }
        public int retorno { get; set; }

        public Boleto_movimento()
        {
            this.codigo = 0;
            this.boleto = new Boleto();
            this.movimento_codigo = "";
            this.movimento_descricao = "";
            this.data = DateTime.Now;
            this.retorno = 0;
        }

        public Boleto_movimento(int codigo, Boleto boleto, string movimento_codigo, string movimento_descricao, DateTime data, int retorno)
        {
            this.codigo = codigo;
            this.boleto = boleto;
            this.movimento_codigo = movimento_codigo;
            this.movimento_descricao = movimento_descricao;
            this.data = data;
            this.retorno = retorno;
        }
    }
}
