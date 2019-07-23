using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Documentos_alunos
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public Aluno aluno { get; set; }
        public Documentos documentos { get; set; }
        public DateTime data { get; set; }

        public Documentos_alunos()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.documentos = new Documentos() { codigo = 0 };
            this.data = DateTime.Now;
        }

        public Documentos_alunos(int codigo)
        {
            this.codigo = codigo;
            this.curso = new Curso() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.documentos = new Documentos() { codigo = 0 };
            this.data = DateTime.Now;
        }

        public Documentos_alunos(int codigo, Curso curso, Aluno aluno, Documentos documentos, DateTime data)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.aluno = aluno;
            this.documentos = documentos;
            this.data = data;
        }

        public void Salvar()
        {
            new Documentos_alunosDB().Salvar(this);
        }

        public void Alterar()
        {
            new Documentos_alunosDB().Alterar(this);
        }

        public void Excluir()
        {
            new Documentos_alunosDB().Excluir(this);
        }

    }
}
