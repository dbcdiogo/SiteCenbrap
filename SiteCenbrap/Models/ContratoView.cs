using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Entidades;
using Biblioteca.DB;
using Biblioteca.Funcoes;

namespace SiteCenbrap.Models
{
    public class ContratoView
    {
        public Aluno aluno { get; set; }
        public Curso curso { get; set; }

        public ContratoView()
        {
            this.aluno = new Aluno();
            this.curso = new Curso();
        }

        public ContratoView(int aluno, int curso)
        {
            this.aluno = new AlunoDB().Buscar(aluno);
            this.curso = new CursoDB().Buscar(curso);

            //aluno curso
            new Inclusao().PreMatricula(this.curso, this.aluno);
        }
    }
}