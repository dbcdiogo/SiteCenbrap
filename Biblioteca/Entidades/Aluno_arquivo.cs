using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno_arquivo
    {
        public int codigo { get; set; }
        public Arquivo arquivo { get; set; }
        public Aluno aluno { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }

        public Aluno_arquivo()
        {
            this.codigo = 0;
            this.arquivo = new Arquivo();
            this.aluno = new Aluno();
            this.data = Convert.ToDateTime("01/01/1900");
            this.hora = Convert.ToDateTime("01/01/1900");
        }

        public Aluno_arquivo(int codigo, Arquivo arquivo, Aluno aluno, DateTime data, DateTime hora)
        {
            this.codigo = codigo;
            this.arquivo = arquivo;
            this.aluno = aluno;
            this.data = data;
            this.hora = hora;
        }
    }
}
