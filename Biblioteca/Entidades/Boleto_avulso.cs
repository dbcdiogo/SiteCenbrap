using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Boleto_avulso
    {
        public int codigo { get; set; }
        public Aluno_pgto aluno_pgto { get; set; }
        public Cliente cliente { get; set; }
        public DateTime data { get; set; }
        public DateTime vencimento { get; set; }
        public DateTime data_pgto { get; set; }
        public double valor { get; set; }
        public int situacao { get; set; }
        public string obs { get; set; }
        public string descricao { get; set; }

        public Boleto boleto { get; set; }

        public Boleto_avulso()
        {
            this.codigo = 0;
            this.aluno_pgto = new Aluno_pgto() { codigo = 0 };
            this.cliente = new Cliente() { codigo = 0 };
            this.data = DateTime.Now;
            this.vencimento = DateTime.Now;
            this.data_pgto = DateTime.Now;
            this.valor = 0;
            this.situacao = 0;
            this.obs = "";
            this.descricao = "";

        }

        public Boleto_avulso(int codigo, Aluno_pgto aluno_pgto, Cliente cliente, DateTime data, DateTime vencimento, DateTime data_pgto, double valor, int situacao, string obs, string descricao)
        {
            this.codigo = codigo;
            this.aluno_pgto = aluno_pgto;
            this.cliente = cliente;
            this.data = data;
            this.vencimento = vencimento;
            this.data_pgto = data_pgto;
            this.valor = valor;
            this.situacao = situacao;
            this.obs = obs;
            this.descricao = descricao;
        }

        public Boleto_avulso(int codigo, Aluno_pgto aluno_pgto, Cliente cliente, DateTime data, DateTime vencimento, DateTime data_pgto, double valor, int situacao, string obs, string descricao, int boleto_codigo)
        {
            this.codigo = codigo;
            this.aluno_pgto = aluno_pgto;
            this.cliente = cliente;
            this.data = data;
            this.vencimento = vencimento;
            this.data_pgto = data_pgto;
            this.valor = valor;
            this.situacao = situacao;
            this.obs = obs;
            this.descricao = descricao;
            this.boleto = new Boleto() { codigo = boleto_codigo };
        }

        public void Salvar()
        {
            this.codigo = new Boleto_avulsoDB().SalvarRetornar(this);
        }

        public void GerarBoleto()
        {
            this.boleto = new Boleto()
            {
                //conta = 6,
                conta = 8,
                data = DateTime.Now,
                valor = this.valor,
                vencimento = this.vencimento,
                instrucoes = "Sr(a). Caixa nao receber apos o vencimento<br><br>" + this.descricao,
                boleto_avulso = this
            };
            this.boleto.Salvar();
        }
    }
}
