using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineVendas
    {
        public int idusuario { get; set; }
        public string txnome { get; set; }
        public DateTime data { get; set; }
        public int alunos { get; set; }
        public int whatsapp { get; set; }
        public int telefone { get; set; }
        public int email { get; set; }
        public int observacao { get; set; }
        public int boleto { get; set; }
        public int inativo { get; set; }
        public int contato { get; set; }

        public TimelineVendas()
        {
            this.idusuario = 0;
            this.txnome = "";
            this.data = Convert.ToDateTime("01/01/1900");
            this.alunos = 0;
            this.whatsapp = 0;
            this.telefone = 0;
            this.email = 0;
            this.observacao = 0;
            this.boleto = 0;
            this.inativo = 0;
            this.contato = 0;
        }

        public TimelineVendas(int idusuario, string txnome, DateTime data, int alunos, int whatsapp, int telefone, int email, int observacao, int boleto, int inativo, int contato)
        {
            this.idusuario = idusuario;
            this.txnome = txnome;
            this.data = data;
            this.alunos = alunos;
            this.whatsapp = whatsapp;
            this.telefone = telefone;
            this.email = email;
            this.observacao = observacao;
            this.boleto = boleto;
            this.inativo = inativo;
            this.contato = contato;
        }

    }

    public class TimelineVendasBoleto
    {
        public string nome { get; set; }
        public string turma { get; set; }
        public string datas { get; set; }

        public TimelineVendasBoleto(string nome, string turma, string datas)
        {
            this.nome = nome;
            this.turma = turma;
            this.datas = datas;
        }
    }
}
