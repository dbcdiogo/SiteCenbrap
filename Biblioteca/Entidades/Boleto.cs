using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Boleto
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public int conta { get; set; }
        public Entrada entrada { get; set; }
        public int cliente { get; set; }
        public int painel { get; set; }
        public double valor { get; set; }
        public double multa { get; set; }
        public double juros { get; set; }
        public int protesto { get; set; }
        public DateTime vencimento { get; set; }
        public int impresso { get; set; }
        public string instrucoes { get; set; }
        public DateTime impresso_data { get; set; }
        public int remessa { get; set; }
        public DateTime remessa_data { get; set; }
        public int retorno { get; set; }
        public DateTime retorno_data { get; set; }
        public string arquivo { get; set; }
        public int remessa_codigo { get; set; }
        public int retorno_codigo { get; set; }
        public string retorno_msg_erro { get; set; }
        public int entrada_confirmada { get; set; }
        public int pagamento_efetuado { get; set; }
        public int entrada_rejeitada { get; set; }
        public string movimento_codigo { get; set; }
        public string movimento_descricao { get; set; }
        public string rejeicao_codigo { get; set; }
        public string rejeicao_msg { get; set; }
        public int ticket { get; set; }
        public Aluno_pgto aluno_pgto { get; set; }
        public Boleto_avulso boleto_avulso { get; set; }

        public Boleto()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.conta = 0;
            this.entrada = new Entrada() { codigo = 0 };
            this.cliente = 0;
            this.painel = 0;
            this.valor = 0;
            this.multa = 0;
            this.juros = 0;
            this.protesto = 0;
            this.vencimento = DateTime.Now;
            this.impresso = 0;
            this.instrucoes = "";
            this.impresso_data = DateTime.Now;
            this.remessa = 0;
            this.remessa_data = DateTime.Now;
            this.retorno = 0;
            this.retorno_data = DateTime.Now;
            this.arquivo = "";
            this.remessa_codigo = 0;
            this.retorno_codigo = 0;
            this.retorno_msg_erro = "";
            this.entrada_confirmada = 0;
            this.pagamento_efetuado = 0;
            this.entrada_rejeitada = 0;
            this.movimento_codigo = "";
            this.movimento_descricao = "";
            this.rejeicao_codigo = "";
            this.rejeicao_msg = "";
            this.ticket = 0;
            this.aluno_pgto = new Aluno_pgto() { codigo = 0 };
            this.boleto_avulso = new Boleto_avulso() { codigo = 0 };
        }

        public Boleto(int codigo, DateTime data, int conta, Entrada entrada, int cliente, int painel, double valor, double multa, double juros, int protesto, DateTime vencimento, int impresso, string instrucoes, DateTime impresso_data, int remessa, DateTime remessa_data, int retorno, DateTime retorno_data, string arquivo, int remessa_codigo, int retorno_codigo, string retorno_msg_erro, int entrada_confirmada, int pagamento_efetuado, int entrada_rejeitada, string movimento_codigo, string movimento_descricao, string rejeicao_codigo, string rejeicao_msg, int ticket, Aluno_pgto aluno_pgto, Boleto_avulso boleto_avulso)
        {
            this.codigo = codigo;
            this.data = data;
            this.conta = conta;
            this.entrada = entrada;
            this.cliente = cliente;
            this.painel = painel;
            this.valor = valor;
            this.multa = multa;
            this.juros = juros;
            this.protesto = protesto;
            this.vencimento = vencimento;
            this.impresso = impresso;
            this.instrucoes = instrucoes;
            this.impresso_data = impresso_data;
            this.remessa = remessa;
            this.remessa_data = remessa_data;
            this.retorno = retorno;
            this.retorno_data = retorno_data;
            this.arquivo = arquivo;
            this.remessa_codigo = remessa_codigo;
            this.retorno_codigo = retorno_codigo;
            this.retorno_msg_erro = retorno_msg_erro;
            this.entrada_confirmada = entrada_confirmada;
            this.pagamento_efetuado = pagamento_efetuado;
            this.entrada_rejeitada = entrada_rejeitada;
            this.movimento_codigo = movimento_codigo;
            this.movimento_descricao = movimento_descricao;
            this.rejeicao_codigo = rejeicao_codigo;
            this.rejeicao_msg = rejeicao_msg;
            this.ticket = ticket;
            this.aluno_pgto = aluno_pgto;
            this.boleto_avulso = boleto_avulso;
        }

        public void Salvar()
        {
            this.codigo = new BoletoDB().SalvarRetornar(this);
            //if(this.aluno_pgto != null)
            //    if(this.aluno_pgto.codigo != 0)
            //        this.codigo = new BoletoDB().Buscar(this.aluno_pgto).codigo;
            //if (this.entrada != null)
            //    if (this.entrada.codigo != 0)
            //        this.codigo = new BoletoDB().Buscar(this.entrada).codigo;
            //if (this.boleto_avulso != null)
            //    if (this.boleto_avulso.codigo != 0)
            //        this.codigo = new BoletoDB().Buscar(this.boleto_avulso).codigo;
        }

        public void Alterar()
        {
            new BoletoDB().Alterar(this);
        }

        public void Excluir()
        {
            new BoletoDB().Excluir(this);
        }
    }

    public class BoletoAluno
    {
        public bool protesto { get; set; }
        public int codigo { get; set; }
        public double valor { get; set; }
        public DateTime vencimento { get; set; }
        public string descricao { get; set; }
        public bool pagamento_efetuado { get; set; }
        public string nome { get; set; }
        public bool remessa { get; set; }
        public DateTime remessa_data { get; set; }
        public int entrada_situacao { get; set; }
        public string curso { get; set; }

        public BoletoAluno()
        {
            this.protesto = false;
            this.codigo = 0;
            this.valor = 0;
            this.vencimento = Convert.ToDateTime("01/01/1900");
            this.descricao = "";
            this.pagamento_efetuado = false;
            this.nome = "";
            this.remessa = false;
            this.remessa_data = Convert.ToDateTime("01/01/1900");
            this.entrada_situacao = 0;
            this.curso = "";
        }

        public BoletoAluno(bool protesto, int codigo, double valor, DateTime vencimento, string descricao, bool pagamento_efetuado, string nome, bool remessa, DateTime remessa_data, int entrada_situacao, string curso)
        {
            this.protesto = protesto;
            this.codigo = codigo;
            this.valor = valor;
            this.vencimento = vencimento;
            this.descricao = descricao;
            this.pagamento_efetuado = pagamento_efetuado;
            this.nome = nome;
            this.remessa = remessa;
            this.remessa_data = remessa_data;
            this.entrada_situacao = entrada_situacao;
            this.curso = curso;
        }
    }
}
