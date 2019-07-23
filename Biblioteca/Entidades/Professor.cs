using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Professor
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string obs { get; set; }
        public string graduacao { get; set; }
        public string titulacao { get; set; }
        public string instituicao { get; set; }
        public string graduacao_data { get; set; }
        public string rg { get; set; }
        public string rg_emissor { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string telefone1 { get; set; }
        public int rg_2via { get; set; }
        public DateTime nascimento { get; set; }
        public string banco { get; set; }
        public string agencia { get; set; }
        public string conta { get; set; }
        public string endereco1 { get; set; }
        public string bairro1 { get; set; }
        public string cidade1 { get; set; }
        public string estado1 { get; set; }
        public string cep1 { get; set; }
        public string lates { get; set; }
        public string banco1 { get; set; }
        public string agencia1 { get; set; }
        public string conta1 { get; set; }
        public string titular { get; set; }
        public string titular1 { get; set; }
        public string especialidade { get; set; }

        public Professor()
        {
            this.codigo = 0;
            this.data = Convert.ToDateTime("01/01/1900");
            this.painel = new Painel();
            this.nome = "";
            this.email = "";
            this.obs = "";
            this.graduacao = "";
            this.titulacao = "";
            this.instituicao = "";
            this.graduacao_data = "";
            this.rg = "";
            this.rg_emissor = "";
            this.rg_2via = 0;
            this.cpf = "";
            this.endereco = "";
            this.bairro = "";
            this.cidade = "";
            this.estado = "";
            this.cep = "";
            this.telefone = "";
            this.telefone1 = "";
            this.nascimento = Convert.ToDateTime("01/01/1900");
            this.banco = "";
            this.agencia = "";
            this.conta = "";
            this.endereco1 = "";
            this.bairro1 = "";
            this.cidade1 = "";
            this.estado1 = "";
            this.cep1 = "";
            this.lates = "";
            this.banco1 = "";
            this.agencia1 = "";
            this.conta1 = "";
            this.titular = "";
            this.titular1 = "";
            this.especialidade = "";
        }

        public Professor(int codigo, DateTime data, Painel painel, string nome, string email, string obs, string graduacao, string titulacao, string instituicao, string graduacao_data, string rg, string rg_emissor, string cpf, string endereco, string bairro, string cidade, string estado, string cep, string telefone, string telefone1, int rg_2via, DateTime nascimento, string banco, string agencia, string conta, string endereco1, string bairro1, string cidade1, string estado1, string cep1, string lates, string banco1, string agencia1, string conta1, string titular, string titular1, string especialidade)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.nome = nome;
            this.email = email;
            this.obs = obs;
            this.graduacao = graduacao;
            this.titulacao = titulacao;
            this.instituicao = instituicao;
            this.graduacao_data = graduacao_data;
            this.rg = rg;
            this.rg_emissor = rg_emissor;
            this.rg_2via =rg_2via;
            this.cpf = cpf;
            this.endereco = endereco;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.telefone = telefone;
            this.telefone1 = telefone1;
            this.nascimento = nascimento;
            this.banco = banco;
            this.agencia = agencia;
            this.conta = conta;
            this.endereco1 = endereco1;
            this.bairro1 = bairro1;
            this.cidade1 = cidade1;
            this.estado1 = estado1;
            this.cep1 = cep1;
            this.lates = lates;
            this.banco1 = banco1;
            this.agencia1 = agencia1;
            this.conta1 = conta1;
            this.titular = titular;
            this.titular1 = titular1;
            this.especialidade = especialidade;
        }

        public void Salvar()
        {
            new ProfessorDB().Salvar(this);
        }

        public void Alterar()
        {
            new ProfessorDB().Alterar(this);
        }

        public void Excluir()
        {
            new ProfessorDB().Excluir(this);
        }
    }
}
