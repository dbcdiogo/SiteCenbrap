using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Titulo_curso_professor
    {
        public int Titulo_curso_professor_id { get; set; }
        public Titulo_curso titulo_curso { get; set; }
        public string foto { get; set; }
        public string professor { get; set; }
        public string especializacao { get; set; }
        public string curriculo { get; set; }
        public int ordem { get; set; }

        public Titulo_curso_professor()
        {
            this.Titulo_curso_professor_id = 0;
            this.titulo_curso = new Titulo_curso();
            this.ordem = 0;
            this.foto = "";
            this.professor = "";
            this.curriculo = "";
            this.especializacao = "";
        }

        public Titulo_curso_professor(int Titulo_curso_professor_id, Titulo_curso titulo_curso, string foto, string professor, string especializacao, string curriculo, int ordem)
        {
            this.Titulo_curso_professor_id = Titulo_curso_professor_id;
            this.titulo_curso = titulo_curso;
            this.foto = foto;
            this.professor = professor;
            this.especializacao = especializacao;
            this.curriculo = curriculo;
            this.ordem = ordem;
        }

        public void Salvar()
        {
            this.Titulo_curso_professor_id = new Titulo_curso_professorDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new Titulo_curso_professorDB().Alterar(this);
        }

        public void Excluir()
        {
            new Titulo_curso_professorDB().Excluir(this);
        }
    }
}
