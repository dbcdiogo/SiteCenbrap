using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class DadosIR
    {
        public int codigo { get; set; }
        public int ano { get; set; }
        public string nome { get; set; }
        public string cpf_cnpj { get; set; }
        public string email { get; set; }
        public double total { get; set; }
        public int certificadora { get; set; }

        public DadosIR()
        {
            this.codigo = 0;
            this.ano = 0;
            this.nome = "";
            this.cpf_cnpj = "";
            this.email = "";
            this.total = 0;
            this.certificadora = 0;
        }

        public DadosIR(int codigo, int ano, string nome, string cpf_cnpj, string email, double total)
        {
            this.codigo = codigo;
            this.ano = ano;
            this.nome = nome;
            this.cpf_cnpj = cpf_cnpj;
            this.email = email;
            this.total = total;
        }

        public DadosIR(int codigo, int ano, string nome, string cpf_cnpj, string email, double total, int certificadora)
        {
            this.codigo = codigo;
            this.ano = ano;
            this.nome = nome;
            this.cpf_cnpj = cpf_cnpj;
            this.email = email;
            this.total = total;
            this.certificadora = certificadora;
        }

        public string Email()
        {
            string txt = "<p><strong>Prezado(a) Doutor(a) " + this.nome + " (" + this.cpf_cnpj + ").</strong></p><p>Conforme mensagem colocada em seu carnê de pagamento, lembramos que, para fins de declaração de Imposto de Renda de " + this.ano + ", os custos com sua pós-graduação devem ser declarados usando os dados abaixo:</p><p>Nome empresarial da instituição responsável pelo curso: <strong>ASSOCIAÇÃO EDUCATIVA DO BRASIL - SOEBRAS</strong></p><p>CNPJ da instituição responsável pelo curso: <strong>22.669.915/0060-87</strong></p><p>Valor: <strong>R$ " + this.total.ToString("N2") + "</strong></p><p>Qualquer dúvida, entre em contato com nossa Central de Atendimento.</p><p>Atenciosamente,</p><p>Rakel Mendes |  Coordenadora Financeira<BR>pagamento @cenbrap.com.br<BR>0300 313 1538<BR>Cenbrap - Centro Brasileiro de Pós - Graduações </p>";

            return txt;
        }

        public string EmailNovo()
        {
            string txt = "<p><strong>Prezado(a) Doutor(a) " + this.nome + " (" + this.cpf_cnpj + ").</strong></p>";
            txt += "<p>Conforme mensagem colocada em seu carnê de pagamento, lembramos que, para fins de declaração de Imposto de Renda de " + this.ano + ", os custos com sua pós-graduação devem ser declarados usando os dados abaixo:</p>";

            if (this.certificadora == 1)
            {
                txt += "<p>Nome empresarial da instituição responsável pelo curso: <strong>ASSOCIAÇÃO EDUCATIVA DO BRASIL - SOEBRAS</strong></p>";
                txt += "<p>CNPJ da instituição responsável pelo curso: <strong>22.669.915/0060-87</strong></p>";
            }

            if (this.certificadora == 6)
            {
                txt += "<p>Nome empresarial da instituição responsável pelo curso: <strong>FACULDADE CENBRAP</strong></p>";
                txt += "<p>CNPJ da instituição responsável pelo curso: <strong>10.660.800/0001-92</strong></p>";
            }
            txt += "<p>Valor: <strong>R$ " + this.total.ToString("N2") + "</strong></p>";
            txt += "<p>Qualquer dúvida, entre em contato com nossa Central de Atendimento.</p>";
            txt += "<p>Atenciosamente,</p>";
            txt += "<p>Rakel Mendes |  Coordenadora Financeira<BR>pagamento@cenbrap.com.br<BR>0300 313 1538<BR>Cenbrap - Centro Brasileiro de Pós - Graduações </p>";

            return txt;
        }

    }
}
