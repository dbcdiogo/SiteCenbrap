using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Conta
    {
        public int codigo { get; set; }
        public string conta { get; set; }
        public int entrada { get; set; }
        public int saida { get; set; }
        public string banco { get; set; }
        public string cc { get; set; }
        public string convenio { get; set; }
        public string carteira { get; set; }
        public string agencia { get; set; }
        public string contrato { get; set; }
        public string cnpj { get; set; }
        public string nome { get; set; }

        public Conta()
        {
            this.codigo = 0;
            this.conta = "";
            this.entrada = 0;
            this.saida = 0;
            this.banco = "";
            this.cc = "";
            this.convenio = "";
            this.carteira = "";
            this.agencia = "";
            this.contrato = "";
            this.cnpj = "";
            this.nome = "";
        }

        public Conta(int codigo, string conta, int entrada, int saida, string banco, string cc, string convenio, string carteira, string agencia, string contrato, string cnpj, string nome)
        {
            this.codigo = codigo;
            this.conta = conta;
            this.entrada = entrada;
            this.saida = saida;
            this.banco = banco;
            this.cc = cc;
            this.convenio = convenio;
            this.carteira = carteira;
            this.agencia = agencia;
            this.contrato = contrato;
            this.cnpj = cnpj;
            this.nome = nome;
        }
    }
}
