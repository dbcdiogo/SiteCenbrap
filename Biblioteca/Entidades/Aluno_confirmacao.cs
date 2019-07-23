using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_confirmacao
    {
        public int idconfirmacao { get; set; }
        public int idaluno_curso { get; set; }
        public DateTime dtconfirmacao { get; set; }
        public string txobs { get; set; }
        public string txaluno { get; set; }
        public string txtelefone { get; set; }
        public string txcurso { get; set; }

        public Aluno_confirmacao()
        {
            this.idconfirmacao = 0;
            this.idaluno_curso = 0;
            this.dtconfirmacao = Convert.ToDateTime("1900-01-01");
            this.txobs = "";
            this.txaluno = "";
            this.txcurso = "";
        }

        public Aluno_confirmacao(int idconfirmacao, int idaluno_curso, DateTime dtconfirmacao, string txobs)
        {
            this.idconfirmacao = idconfirmacao;
            this.idaluno_curso = idaluno_curso;
            this.dtconfirmacao = dtconfirmacao;
            this.txobs = txobs;
        }

        public Aluno_confirmacao(int idconfirmacao, int idaluno_curso, DateTime dtconfirmacao, string txobs, string txaluno, string txtelefone, string txcurso)
        {
            this.idconfirmacao = idconfirmacao;
            this.idaluno_curso = idaluno_curso;
            this.dtconfirmacao = dtconfirmacao;
            this.txobs = txobs;
            this.txaluno = txaluno;
            this.txtelefone = txtelefone;
            this.txcurso = txcurso;
        }
    }
}
