using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Newsletter
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string curso { get; set; }
        public DateTime data { get; set; }
        public string cidade { get; set; }
        public string profissao { get; set; }
        public int envio_email { get; set; }
        public string telefone { get; set; }
        public int idlandingpage { get; set; }

        public Newsletter()
        {
            this.codigo = 0;
            this.nome = "";
            this.email = "";
            this.curso = "";
            this.data = DateTime.Now;
            this.cidade = "";
            this.profissao = "";
            this.telefone = "";
            this.envio_email = 1;
            this.idlandingpage = 0;
        }

        public Newsletter(int codigo)
        {
            this.codigo = codigo;
            this.nome = "";
            this.email = "";
            this.curso = "";
            this.data = DateTime.Now;
            this.cidade = "";
            this.profissao = "";
            this.telefone = "";
            this.envio_email = 1;
        }

        public Newsletter(int codigo, string nome, string email, string curso, DateTime data, string cidade, string profissao, int envio_email, string telefone)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.email = email;
            this.curso = curso;
            this.data = data;
            this.cidade = cidade;
            this.profissao = profissao;
            this.envio_email = envio_email;
            this.telefone = telefone;
        }

        public Newsletter(int codigo, string nome, string email, string curso, DateTime data, string cidade, string profissao, int envio_email, string telefone, int idlandingpage)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.email = email;
            this.curso = curso;
            this.data = data;
            this.cidade = cidade;
            this.profissao = profissao;
            this.envio_email = envio_email;
            this.telefone = telefone;
            this.idlandingpage = idlandingpage;
        }

        public void Salvar()
        {
            new NewsletterDB().Salvar(this);
        }

        public void Alterar()
        {
            new NewsletterDB().Alterar(this);
        }

        public void Excluir()
        {
            new NewsletterDB().Excluir(this);
        }

        public int SalvarRetornar()
        {
            return this.codigo = new NewsletterDB().SalvarRetornar(this);
        }
    }

    public class NewsletterFormulario
    {
        public int codigo { get; set; }
        public int formulario { get; set; }
        public string resposta { get; set; }

        public NewsletterFormulario()
        {
            this.codigo = 0;
            this.formulario = 0;
            this.resposta = "";
        }

        public NewsletterFormulario(int codigo, int formulario, string resposta)
        {
            this.codigo = codigo;
            this.formulario = formulario;
            this.resposta = resposta;
        }

        public void Salvar()
        {
            new NewsletterDB().SalvarFormulario(this);
        }
    }

}