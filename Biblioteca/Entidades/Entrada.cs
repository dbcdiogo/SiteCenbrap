using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Entrada
    {
        public int codigo { get; set; }
        public Cliente cliente { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public Conta conta { get; set; }
        public Conta conta_devolucao { get; set; }
        public double valor { get; set; }
        public DateTime vencimento { get; set; }
        public int situacao { get; set; }
        public double multa { get; set; }
        public double juros { get; set; }
        public double desconto { get; set; }
        public Tipo_entrada tipo_entrada { get; set; }
        public string identificacao { get; set; }
        public DateTime data_quitado { get; set; }
        public DateTime data_recebimento { get; set; }
        public DateTime data_devolucao { get; set; }
        public string nota_fiscal { get; set; }
        public DateTime data_nota_fiscal { get; set; }
        public string tipo_pgto { get; set; }
        public string boleto { get; set; }
        public string parcela { get; set; }
        public string xml_envio { get; set; }
        public string cod_verificacao { get; set; }
        public string xml_retorno { get; set; }
        public string arquivo_xml { get; set; }
        public string obs_cancelado { get; set; }
        public int negociacao { get; set; }
        public string emolumento { get; set; }
        public int negativado { get; set; }
        public DateTime negativado_data { get; set; }
        public DateTime negativado_data_removido { get; set; }
        public int codboleto { get; set; }

        public string contrato { get; set; }
        public string info { get; set; }
        public Boleto boletoCodigo { get; set; }

        public int qtdEmAberto { get; set; }
        public int qtdAtrasado { get; set; }
        public int qtdPagos { get; set; }

        public string negociacao_txt { get; set; }
        public string negativado_txt { get; set; }

        public double valor_parcela1 { get; set; }
        public double valor_parcela2 { get; set; }
        public double valor_parcela3 { get; set; }
        public double valor_parcela4 { get; set; }
        public double valor_parcela5 { get; set; }
        public double valor_parcela6 { get; set; }

        public DateTime data_recebimento2 { get; set; }
        public DateTime data_recebimento3 { get; set; }
        public DateTime data_recebimento4 { get; set; }
        public DateTime data_recebimento5 { get; set; }
        public DateTime data_recebimento6 { get; set; }

        public Entrada()
        {
            this.codigo = 0;
            this.cliente = new Cliente() { codigo = 0 };
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
            this.conta = new Conta() { codigo = 0 };
            this.conta_devolucao = new Conta() { codigo = 0 };
            this.valor = 0;
            this.vencimento = DateTime.Now;
            this.situacao = 0;
            this.multa = 0;
            this.juros = 0;
            this.desconto = 0;
            this.tipo_entrada = new Tipo_entrada() { codigo = 0 };
            this.identificacao = "";
            this.data_quitado = DateTime.Now;
            this.data_recebimento = DateTime.Now;
            this.data_devolucao = DateTime.Now;
            this.nota_fiscal = "";
            this.data_nota_fiscal = DateTime.Now;
            this.tipo_pgto = "";
            this.boleto = "";
            this.parcela = "";
            this.xml_envio = "";
            this.cod_verificacao = "";
            this.xml_retorno = "";
            this.arquivo_xml = "";
            this.obs_cancelado = "";
            this.negociacao = 0;
            this.emolumento = "";
            this.negativado = 0;
            this.negativado_data = DateTime.Now;
            this.negativado_data_removido = DateTime.Now;
            this.codboleto = 0;

            this.contrato = "";
            this.info = "";
            this.boletoCodigo = null;

            this.qtdAtrasado = 0;
            this.qtdEmAberto = 0;
            this.qtdPagos = 0;

            this.negociacao_txt = "";
            this.negativado_txt = "";

            this.valor_parcela1 = 0;
            this.valor_parcela2 = 0;
            this.valor_parcela3 = 0;
            this.valor_parcela4 = 0;
            this.valor_parcela5 = 0;
            this.valor_parcela6 = 0;

            this.data_recebimento2 = DateTime.Now;
            this.data_recebimento3 = DateTime.Now;
            this.data_recebimento4 = DateTime.Now;
            this.data_recebimento5 = DateTime.Now;
            this.data_recebimento6 = DateTime.Now;
        }

        public Entrada(int codigo, Cliente cliente, Painel painel, DateTime data, Conta conta, Conta conta_devolucao, double valor, DateTime vencimento, int situacao, double multa, double juros, double desconto, Tipo_entrada tipo_entrada, string identificacao, DateTime data_quitado, DateTime data_recebimento, DateTime data_devolucao, string nota_fiscal, DateTime data_nota_fiscal, string tipo_pgto, string boleto, string parcela, string xml_envio, string cod_verificacao, string xml_retorno, string arquivo_xml, string obs_cancelado, int negociacao, string emolumento, int negativado, DateTime negativado_data, DateTime negativado_data_removido, int codboleto = 0, string contrato = "", string info = "", Boleto boletoCod = null, int qtdAtrasado = 0, int qtdEmAberto = 0, int qtdPagos = 0, string negociacao_txt = "", string negativado_txt = "")
        {
            this.codigo = codigo;
            this.cliente = cliente;
            this.painel = painel;
            this.data = data;
            this.conta = conta;
            this.conta_devolucao = conta_devolucao;
            this.valor = valor;
            this.vencimento = vencimento;
            this.situacao = situacao;
            this.multa = multa;
            this.juros = juros;
            this.desconto = desconto;
            this.tipo_entrada = tipo_entrada;
            this.identificacao = identificacao;
            this.data_quitado = data_quitado;
            this.data_recebimento = data_recebimento;
            this.data_devolucao = data_devolucao;
            this.nota_fiscal = nota_fiscal;
            this.data_nota_fiscal = data_nota_fiscal;
            this.tipo_pgto = tipo_pgto;
            this.boleto = boleto;
            this.parcela = parcela;
            this.xml_envio = xml_envio;
            this.cod_verificacao = cod_verificacao;
            this.xml_retorno = xml_retorno;
            this.arquivo_xml = arquivo_xml;
            this.obs_cancelado = obs_cancelado;
            this.negociacao = negociacao;
            this.emolumento = emolumento;
            this.negativado = negativado;
            this.negativado_data = negativado_data;
            this.negativado_data_removido = negativado_data_removido;
            this.codboleto = codboleto;

            this.contrato = contrato;
            this.info = info;
            this.boletoCodigo = boletoCod;

            this.qtdAtrasado = qtdAtrasado;
            this.qtdEmAberto = qtdEmAberto;
            this.qtdPagos = qtdPagos;

            this.negociacao_txt = negociacao_txt;
            this.negativado_txt = negativado_txt;
        }
    }
}
