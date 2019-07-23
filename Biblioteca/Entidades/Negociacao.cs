using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Negociacao
    {
        public int negociacao_id { get; set; }
        public Cliente cliente { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public double subtotal { get; set; }
        public double desconto { get; set; }
        public double total { get; set; }
        public int parcelas { get; set; }
        public DateTime vencimento { get; set; }

        //cliente, painel, data, subtotal, desconto, total, parcelas, vencimento

        public List<Negociacao_entrada> entradas { get; set; }
        public List<Entrada> list_entradas { get; set; }
        public List<Negociacao_Boleto_avulso> boleto_avulsos { get; set; }
        public List<Boleto_avulso> list_boletos { get; set; }
        public string situacao { get; set; }
        public DateTime proximoVencimento { get; set; }
        public string txtEntradas { get; set; }

        public Negociacao()
        {
            this.negociacao_id = 0;
            this.cliente = new Cliente();
            this.painel = new Painel();
            this.data = Convert.ToDateTime("01/01/1900");
            this.subtotal = 0;
            this.desconto = 0;
            this.total = 0;
            this.parcelas = 0;
            this.vencimento = DateTime.Now;

            this.entradas = new List<Negociacao_entrada>();
            this.boleto_avulsos = new List<Negociacao_Boleto_avulso>();
            this.situacao = "";
            this.proximoVencimento = Convert.ToDateTime("01/01/1900");
            this.txtEntradas = "";
            this.list_boletos = new List<Boleto_avulso>();
            this.list_entradas = new List<Entrada>();
        }

        public Negociacao(int id)
        {
            this.negociacao_id = id;
        }

        public Negociacao(int id, Cliente cliente, Painel painel, DateTime data, double subtotal, double desconto, double total, int parcelas, DateTime vencimento)
        {
            this.negociacao_id = id;
            this.cliente = cliente;
            this.painel = painel;
            this.data = data;
            this.subtotal = subtotal;
            this.desconto = desconto;
            this.total = total;
            this.parcelas = parcelas;
            this.vencimento = vencimento;
            this.proximoVencimento = Convert.ToDateTime("01/01/1900");
        }

        public void Salvar()
        {
            this.negociacao_id = new NegociacaoDB().Salvar(this);
        }
        
        public void Alterar()
        {
            new NegociacaoDB().Alterar(this);
        }

        public void Excluir()
        {
            new NegociacaoDB().Excluir(this);
        }

        public void Completar()
        {
            this.entradas = new Negociacao_entradaDB().Listar(this);
            this.boleto_avulsos = new Negociacao_Boleto_avulsoDB().Listar(this);

            int quitado = 0;
            int avencer = 0;
            int vencido = 0;

            foreach(var e in this.entradas)
            {
                this.txtEntradas += "Venc.: " + e.entrada.vencimento.ToShortDateString() + " => R$ " + e.entrada.valor.ToString("N2") + " \n";
            }

            foreach(var b in this.boleto_avulsos)
            {
                if (b.boleto_avulso.data_pgto == Convert.ToDateTime("01/01/1900") && b.boleto_avulso.vencimento < DateTime.Now)
                {
                    vencido++;
                }
                if (b.boleto_avulso.data_pgto == Convert.ToDateTime("01/01/1900") && b.boleto_avulso.vencimento > DateTime.Now)
                {
                    avencer++;
                }
                if (b.boleto_avulso.data_pgto > Convert.ToDateTime("01/01/1900"))
                {
                    quitado++;
                }

                if (b.boleto_avulso.data_pgto == Convert.ToDateTime("01/01/1900") && this.proximoVencimento <= Convert.ToDateTime("01/01/1900"))
                {
                    this.proximoVencimento = b.boleto_avulso.vencimento;
                }
            }

            if (vencido == 0 && avencer == 0 && quitado > 0)
            {
                this.situacao = "Quitada";
            }

            if (vencido > 0)
            {
                this.situacao = "Vencida a " + (DateTime.Now - this.proximoVencimento).Days + " dias";
            }
            else
            {
                if (avencer > 0)
                {
                    if (quitado == 0)
                    {
                        this.situacao = "Aguardando Pgto 1 parcela";
                    }
                    else
                    {
                        this.situacao = "Em andamento";
                    } 
                }       
            }
                
        }

        public void PrepararJson()
        {
            this.list_entradas = new List<Entrada>();

            foreach(var e in this.entradas)
            {
                this.list_entradas.Add(e.entrada);
            }

            this.entradas = new List<Negociacao_entrada>();

            this.list_boletos = new List<Boleto_avulso>();

            foreach (var b in this.boleto_avulsos)
            {
                this.list_boletos.Add(b.boleto_avulso);
            }

            this.boleto_avulsos = new List<Negociacao_Boleto_avulso>();
        }
    }

    public class Negociacao_entrada
    {
        public Negociacao negociacao_id { get; set; }
        public Entrada entrada { get; set; }

        public Negociacao_entrada()
        {
            this.negociacao_id = new Negociacao();
            this.entrada = new Entrada();
        }

        public Negociacao_entrada(Negociacao negociacao, Entrada entrada)
        {
            this.negociacao_id = negociacao;
            this.entrada = entrada;
        }
        
        public void Salvar()
        {
            new Negociacao_entradaDB().Salvar(this);
        }
        
        public void Excluir()
        {
            new Negociacao_entradaDB().Excluir(this);
        }

    }

    public class Negociacao_Boleto_avulso
    {
        public Negociacao negociacao_id { get; set; }
        public Boleto_avulso boleto_avulso { get; set; }

        public Negociacao_Boleto_avulso()
        {
            this.negociacao_id = negociacao_id;
            this.boleto_avulso = boleto_avulso;
        }

        public Negociacao_Boleto_avulso(Negociacao negociacao, Boleto_avulso boleto)
        {
            this.negociacao_id = negociacao;
            this.boleto_avulso = boleto;
        }

        public void Salvar()
        {
            new Negociacao_Boleto_avulsoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Negociacao_Boleto_avulsoDB().Excluir(this);
        }

    }
}
