using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_curso_encontro
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
        public Painel painel { get; set; }
        public Aluno aluno { get; set; }
        public Curso curso { get; set; }
        public Aluno_curso aluno_curso { get; set; }
        public int modulo { get; set; }
        public int encontro { get; set; }
        public int frequencia { get; set; }
        public double nota { get; set; }
        public int disciplina { get; set; }
        public int visualizar { get; set; }
        public bool reposicao { get; set; }

        public Aluno_curso_encontro()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.hora = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.curso = new Curso() { codigo = 0 };
            this.aluno_curso = new Aluno_curso() { codigo = 0 };
            this.modulo = 0;
            this.encontro = 0;
            this.frequencia = 0;
            this.nota = 0;
            this.disciplina = 0;
            this.visualizar = 0;
            this.reposicao = false;
        }

        public Aluno_curso_encontro(int codigo, DateTime data, DateTime hora, Painel painel, Aluno aluno, Curso curso, Aluno_curso aluno_curso, int modulo, int encontro, int frequencia, double nota, int disciplina, int visualizar, bool reposicao = false)
        {
            this.codigo = codigo;
            this.data = data;
            this.hora = hora;
            this.painel = painel;
            this.aluno = aluno;
            this.curso = curso;
            this.aluno_curso = aluno_curso;
            this.modulo = modulo;
            this.encontro = encontro;
            this.frequencia = frequencia;
            this.nota = nota;
            this.disciplina = disciplina;
            this.visualizar = visualizar;
            this.reposicao = reposicao;
        }
    }

    public class Aluno_curso_acompanhamento
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public int curso { get; set; }
        public List<Encontro> encontros { get; set; }

        public Aluno_curso_acompanhamento(int codigo, string titulo, int curso)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.curso = curso;
            this.encontros = new EncontroDB().ListarTodosAcompanhamento(curso);
        }
    }
}
