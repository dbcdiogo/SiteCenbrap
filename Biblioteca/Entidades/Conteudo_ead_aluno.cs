using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Conteudo_ead_aluno
    {
        public int conteudo_ead_aluno_id { get; set; }
        public Conteudo_ead conteudo_ead_id { get; set; }
        public DateTime data { get; set; }
        public Aluno aluno { get; set; }

        public Conteudo_ead_aluno()
        {
            this.conteudo_ead_aluno_id = 0;
            this.conteudo_ead_id = new Conteudo_ead() { conteudo_ead_id = 0 };
            this.data = DateTime.Now;
            this.aluno = new Aluno() { codigo = 0 };
        }

        public Conteudo_ead_aluno(int conteudo_ead_aluno_id, Conteudo_ead conteudo_ead_id, DateTime data, Aluno aluno)
        {
            this.conteudo_ead_aluno_id = conteudo_ead_aluno_id;
            this.conteudo_ead_id = conteudo_ead_id;
            this.data = data;
            this.aluno = aluno;
        }
    }
}
