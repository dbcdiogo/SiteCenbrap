using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class AlunoCadastrar
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
        public string numero { get; set; } = "";
        public string complemento { get; set; } = "";
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

        public AlunoCadastrar()
        {
            this.codigo = 0;
        }

        public AlunoCadastrar(Aluno aluno)
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
            if (isDate(datanascimento))
                aluno.data_nascimento = Convert.ToDateTime(datanascimento);
            else
                datanascimento = DateTime.Now.AddYears(-30).ToShortDateString();
            aluno.pne = this.pne;
            if (this.pne_qual == null)
                this.pne_qual = "";
            aluno.pne_qual = this.pne_qual;
            aluno.endereco = this.endereco;
            aluno.bairro = this.bairro;
            aluno.cidade = this.cidade;
            aluno.estado = this.estado;
            aluno.cep = this.cep;
            if (this.ddd != null)
                aluno.ddd = this.ddd.Replace("(", "").Replace(")", "");
            else
                aluno.ddd = "";
            if (this.telefone != null)
                aluno.telefone = this.telefone;
            else
                aluno.telefone = "";
            if (this.ddd_celular != null)
                aluno.ddd_celular = this.ddd_celular.Replace("(", "").Replace(")", "");
            else
                aluno.ddd_celular = "";
            if (this.celular != null)
                aluno.celular = this.celular;
            else
                aluno.celular = "";
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
            if (!isDate(datanascimento))
                datanascimento = DateTime.Now.AddYears(-30).ToShortDateString();

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
                    new Envio_emailDB().Salvar(new Envio_email() { para = "secretaria@cenbrap.com.br", assunto = "Alteração de dados - www.cenbrap.com.br", texto = txt, data = DateTime.Now });
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

            if (this.numero != null && this.numero != "")
                aluno.endereco += ", " + this.numero;

            if (this.complemento != null && this.complemento != "")
                aluno.endereco += ", " + this.complemento;

            aluno.bairro = this.bairro;
            aluno.cidade = this.cidade;
            aluno.estado = this.estado;
            aluno.cep = this.cep;

            if (this.ddd != null)
                aluno.ddd = this.ddd.Replace("(", "").Replace(")", "");
            else
                aluno.ddd = "";

            aluno.telefone = this.telefone;

            if (this.ddd_celular != null)
                aluno.ddd_celular = this.ddd_celular.Replace("(", "").Replace(")", "");
            else
                aluno.ddd_celular = "";

            aluno.celular = this.celular;

            if (this.profissao == null)
                this.profissao = "";
            else
                aluno.profissao = this.profissao;

            aluno.email = this.email;
            aluno.nome_cracha = this.nome_cracha;

            return aluno;
        }

        public static bool isDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
