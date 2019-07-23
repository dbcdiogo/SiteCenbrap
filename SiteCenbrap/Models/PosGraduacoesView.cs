using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.DB;
using Biblioteca.Entidades;

namespace SiteCenbrap.Models
{
    public class PosGraduacoesView
    {
        public List<Cursos> cursos { get; set; }
        public List<Curso> curso { get; set; }

        public PosGraduacoesView()
        {
            this.cursos = new CursoDB().TituloCursos(TipoCurso.PosGraduacao);
            this.curso = new CursoDB().Proximos(TipoCurso.PosGraduacao, 3);
        }
    }

    public class WorkshopView
    {
        public List<Cursos> cursos { get; set; }
        public List<Curso> curso { get; set; }

        public WorkshopView()
        {
            this.cursos = new CursoDB().TituloCursos(TipoCurso.WorkShop);
            this.curso = new CursoDB().Proximos(TipoCurso.WorkShop, 3);
        }
    }

    public class EadView
    {
        public List<Cursos> cursos { get; set; }
        public List<Curso> curso { get; set; }

        public EadView()
        {
            this.cursos = new CursoDB().TituloCursos(TipoCurso.EaD);
            this.curso = new CursoDB().Proximos(TipoCurso.EaD, 3);
        }
    }
}