using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace SiteCenbrap.Models
{
    public class CidadeView
    {
        private List<Cidade> list;

        public Cidade cidade { get; set; }
        public List<Cursos> posgraduacao { get; set; }
        public List<Cursos> workshop { get; set; }
        public List<Cursos> ead { get; set; }
        public List<Curso> turmas { get; set; }

        public CidadeView()
        {
            this.cidade = new Cidade();
            this.posgraduacao = new List<Cursos>();
            this.workshop = new List<Cursos>();
            this.ead = new List<Cursos>();
            this.turmas = new List<Curso>();
        }

        public CidadeView(Cidade cidade)
        {
            this.cidade = cidade;
            this.posgraduacao = new CursoDB().TituloCursos(cidade, TipoCurso.PosGraduacao);
            this.workshop = new CursoDB().TituloCursos(cidade, TipoCurso.WorkShop);
            this.ead = new CursoDB().TituloCursos(TipoCurso.EaD);
            this.turmas = new CursoDB().Proximos(cidade, TipoCurso.PosGraduacao, 3);
        }

        public CidadeView(List<Cidade> list)
        {
            this.list = list;
        }
    }
}