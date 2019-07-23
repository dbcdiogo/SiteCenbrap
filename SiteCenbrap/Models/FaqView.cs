using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace SiteCenbrap.Models
{
    public class FaqView
    {
        public List<InscrevaViewCidade> faqs { get; set; }
        public List<Cursos> cursos { get; set; }  

        public FaqView()
        {
            this.faqs = new List<InscrevaViewCidade>();
            this.cursos = new CursoDB().TituloCursos(TipoCurso.PosGraduacao, 100);

            foreach (var i in new FaqDB().Cursos("cenbrap.com.br"))
            {
                this.faqs.Add(new InscrevaViewCidade(i));
            }
        }
    }
    public class InscrevaViewCidade
    {
        public string titulo { get; set; }
        public List<Faq> faqs { get; set; }

        public InscrevaViewCidade()
        {
            this.titulo = "";
            this.faqs = new List<Faq>();
        }

        public InscrevaViewCidade(int id)
        {
            Titulo_curso titulos = new Titulo_cursoDB().Buscar(id);

            if(titulos != null)
            {
                this.titulo = titulos.titulo;
                this.faqs = new FaqDB().Listar(id, "cenbrap.com.br");
            }
            else
            {
                this.titulo = "Por que fazer uma pós?";
                this.faqs = new FaqDB().Listar(0, "cenbrap.com.br");
            }
        }
    }
}