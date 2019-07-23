using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;
using System.Text.RegularExpressions;
using System.Web;

namespace Biblioteca.Entidades
{
    public class Faq
    {
        public int faq_id { get; set; }
        public Titulo_curso titulo_curso { get; set; }
        public string pergunta { get; set; }
        public string resposta { get; set; }
        public int ordem { get; set; }
        public string dominio { get; set; }

        public Faq()
        {
            this.faq_id = 0;
            this.titulo_curso = new Titulo_curso();
            this.pergunta = "";
            this.resposta = "";
            this.ordem = 0;
            this.dominio = "cenbrap.com.br";
        }

        public Faq(int id)
        {
            this.faq_id = id;
            this.titulo_curso = new Titulo_curso();
            this.pergunta = "";
            this.resposta = "";
            this.ordem = 0;
            this.dominio = "cenbrap.com.br";
        }

        public Faq(int id, Titulo_curso titulo_curso, string pergunta, string resposta, int ordem, string dominio = "cenbrap.com.br")
        {
            this.faq_id = id;
            this.titulo_curso = titulo_curso;
            this.pergunta = pergunta;
            this.resposta = resposta;
            this.ordem = ordem;
            this.dominio = dominio;
        }

        public void Salvar()
        {
            new FaqDB().Salvar(this);
        }

        public void Alterar()
        {
            new FaqDB().Alterar(this);
        }
        
        public void Excluir()
        {
            new FaqDB().Excluir(this);
        }

        public string Resposta()
        {
            bool decode = true;
            string txt = this.resposta;

            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            txt = reg.Replace(txt, "");
            txt = decode ? HttpUtility.HtmlDecode(txt) : txt;

            if (txt.Length > 200)
                txt = txt.Substring(0, 200) + "...";

            return txt;
        }
    }
}
