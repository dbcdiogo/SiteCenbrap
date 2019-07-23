using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCenbrap.Models
{
    public class AlunoView
    {
        public int codigo { get; set; } = 0;
        public string nome { get; set; } = "";
        public string cpf { get; set; } = "";
        public string rg { get; set; } = "";
        public string rg_emissor { get; set; } = "";
        public int rg_2via { get; set; } = 0;
        public string sexo { get; set; } = "";
        public string data_nascimento { get; set; } = DateTime.Now.AddYears(-30).ToShortDateString();
        public int pne { get; set; } = 0;
        public string pne_qual { get; set; } = "";
        public string endereco { get; set; } = "";
        public string bairro { get; set; } = "";
        public string cidade { get; set; } = "";
        public string estado { get; set; } = "";
        public string cep { get; set; } = "";
        public string ddd { get; set; } = "";
        public string telefone { get; set; } = "";
        public string ddd_celular { get; set; } = "";
        public string celular { get; set; } = "";
        public string profissao { get; set; } = "";
        public string email { get; set; } = "";
        public string nome_cracha { get; set; } = "";
        public int curso { get; set; } = 0;

        public AlunoView()
        {
            this.codigo = 0;
        }

        public AlunoView(Aluno aluno)
        {
            this.codigo = aluno.codigo;
            this.nome = aluno.nome;
            this.cpf = aluno.cpf;
            this.rg = aluno.rg;
            this.rg_emissor = aluno.rg_emissor;
            this.rg_2via = aluno.rg_2via;
            this.sexo = aluno.sexo;
            this.data_nascimento = aluno.data_nascimento.ToShortDateString();
            this.pne = aluno.pne;
            this.pne_qual = aluno.pne_qual;
            this.endereco = aluno.endereco;
            this.bairro = aluno.bairro;
            this.cidade = aluno.cidade;
            this.estado = aluno.estado;
            this.cep = aluno.cep;
            this.ddd = aluno.ddd;
            this.telefone = aluno.telefone;
            this.ddd_celular = aluno.ddd_celular;
            this.celular = aluno.celular;
            this.profissao = aluno.profissao;
            this.email = aluno.email;
            this.nome_cracha = aluno.nome_cracha;
        }

        public Aluno Retornar()
        {
            Aluno aluno = new Aluno();
            aluno.codigo = this.codigo;
            aluno.nome = this.nome;
            aluno.cpf = this.cpf.Replace("-", "").Replace(".", "").Replace(" ", "").Replace("/", "");
            aluno.rg = this.rg;
            aluno.rg_emissor = this.rg_emissor;
            aluno.rg_2via = this.rg_2via;
            aluno.sexo = this.sexo;
            string datanascimento = this.data_nascimento;
            if (datanascimento.Length != 10)
            {
                datanascimento = DateTime.Now.AddYears(-30).ToShortDateString();
            }
            aluno.data_nascimento = Convert.ToDateTime(datanascimento);
            aluno.pne = this.pne;
            if (this.pne_qual == null)
                this.pne_qual = "";
            aluno.pne_qual = this.pne_qual;
            aluno.endereco = this.endereco;
            aluno.bairro = this.bairro;
            aluno.cidade = this.cidade;
            aluno.estado = this.estado;
            aluno.cep = this.cep;
            aluno.ddd = this.ddd.Replace("(", "").Replace(")", "");
            aluno.telefone = this.telefone;
            aluno.ddd_celular = this.ddd_celular.Replace("(", "").Replace(")", "");
            aluno.celular = this.celular;
            aluno.profissao = this.profissao;
            aluno.email = this.email;
            aluno.nome_cracha = this.nome_cracha;

            return aluno;
        }

        public Aluno Atualizar(Aluno aluno)
        {
            if (this.profissao == null)
                this.profissao = "";

            if (this.nome == null)
                this.nome = "";

            if (this.cpf == null)
                this.cpf = "";

            if (this.rg == null)
                this.rg = "";

            if (this.rg_emissor == null)
                this.rg_emissor = "";

            if (this.sexo == null)
                this.sexo = "";

            if (this.data_nascimento == null)
                this.data_nascimento = "";

            if (this.endereco == null)
                this.endereco = "";

            if (this.bairro == null)
                this.bairro = "";

            if (this.cidade == null)
                this.cidade = "";

            if (this.estado == null)
                this.estado = "";

            if (this.cep == null)
                this.cep = "";

            if (this.ddd == null)
                this.ddd = "";

            if (this.ddd_celular == null)
                this.ddd_celular = "";

            if (this.telefone == null)
                this.telefone = "";

            if (this.celular == null)
                this.celular = "";

            if (this.email == null)
                this.email = "";

            if (this.nome_cracha == null)
                this.nome_cracha = "";

            aluno.cpf = this.cpf.Replace("-", "").Replace(".", "").Replace(" ", "").Replace("/", "");
            aluno.rg_2via = this.rg_2via;
            aluno.sexo = this.sexo;
            string datanascimento = this.data_nascimento;
            if (datanascimento.Length != 10)
            {
                datanascimento = DateTime.Now.AddYears(-30).ToShortDateString();
            }

            if (new Aluno_cursoDB().Matriculado(aluno))
            {
                string txt = "";
                if (aluno.nome != this.nome)
                    txt += "<p>Nome atual: (" + aluno.nome + ") - alterar para: (" + this.nome + ")</p>";
                if (aluno.rg != this.rg)
                    txt += "<p>RG atual: (" + aluno.rg + ") - alterar para: (" + this.rg + ")</p>";
                if (aluno.rg_emissor != this.rg_emissor)
                    txt += "<p>RG emissor atual: (" + aluno.rg_emissor + ") - alterar para: (" + this.rg_emissor + ")</p>";
                if (aluno.data_nascimento != Convert.ToDateTime(datanascimento))
                    txt += "<p>Data Nascimento atual: (" + aluno.data_nascimento.ToShortDateString() + ") - alterar para: (" + Convert.ToDateTime(datanascimento).ToShortDateString() + ")</p>";

                if (txt != "")
                {
                    txt = "<p>Aluno: " + aluno.nome + " </p><p>CPF : " + aluno.cpf + "</p>" + txt;
                    new Envio_emailDB().Salvar(new Envio_email() { para = "pedagogico@cenbrap.com.br", assunto = "Alteração de dados - www.cenbrap.com.br", texto = txt, data = DateTime.Now });
                }
            }
            else
            {
                aluno.nome = this.nome;
                aluno.rg = this.rg;
                aluno.rg_emissor = this.rg_emissor;
                aluno.data_nascimento = Convert.ToDateTime(datanascimento);
            }

            aluno.pne = this.pne;

            if (this.pne_qual == null)
                this.pne_qual = "";

            aluno.pne_qual = this.pne_qual;
            aluno.endereco = this.endereco;
            aluno.bairro = this.bairro;
            aluno.cidade = this.cidade;
            aluno.estado = this.estado;
            aluno.cep = this.cep;
            aluno.ddd = this.ddd.Replace("(", "").Replace(")", "");
            aluno.telefone = this.telefone;
            aluno.ddd_celular = this.ddd_celular.Replace("(", "").Replace(")", "");
            aluno.celular = this.celular;
            if (this.profissao == null)
                this.profissao = "";
            aluno.profissao = this.profissao;
            aluno.email = this.email;
            aluno.nome_cracha = this.nome_cracha;

            return aluno;
        }
    }
}