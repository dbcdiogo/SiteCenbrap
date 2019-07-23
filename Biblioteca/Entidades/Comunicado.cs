using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Comunicado
    {
        public int ident { get; set; }
        public string turma { get; set; }
        public int aluno { get; set; }
        public int tipo { get; set; }
        public int novocurso { get; set; }
        public string dados { get; set; }

        public Comunicado()
        {
            this.ident = 0;
            this.turma = "";
            this.aluno = 0;
            this.tipo = 0;
            this.novocurso = 0;
            this.dados = "";
        }

        public Comunicado(int id, string nome)
        {
            this.ident = 0;
            this.turma = "";
            this.aluno = 0;
            this.tipo = 0;
            this.novocurso = 0;
            this.dados = "";
        }

        public Comunicado(int id, string turma, int aluno, int tipo, int novocurso, string dados)
        {
            this.ident = id;
            this.turma = turma;
            this.aluno = aluno;
            this.tipo = tipo;
            this.novocurso = novocurso;
            this.dados = dados;
        }

        public void Salvar()
        {
            new ComunicadoDB().Salvar(this);
        }

    }
}
