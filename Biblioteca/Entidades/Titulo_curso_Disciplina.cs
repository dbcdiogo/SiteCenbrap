using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Titulo_curso_Disciplina
    {
        public int Titulo_curso_Disciplina_id { get; set; }
        public Titulo_curso titulo_curso { get; set; }
        public string disciplina { get; set; }
        public int ordem { get; set; }

        public Titulo_curso_Disciplina()
        {
            this.Titulo_curso_Disciplina_id = 0;
            this.titulo_curso = new Titulo_curso();
            this.ordem = 0;
            this.disciplina = "";
        }

        public Titulo_curso_Disciplina(int Titulo_curso_Disciplina_id, Titulo_curso titulo_curso, string disciplina, int ordem)
        {
            this.Titulo_curso_Disciplina_id = Titulo_curso_Disciplina_id;
            this.titulo_curso = titulo_curso;
            this.disciplina = disciplina;
            this.ordem = ordem;
        }

        public void Salvar()
        {
            new Titulo_curso_DisciplinaDB().Salvar(this);
        }

        public void Alterar()
        {
            new Titulo_curso_DisciplinaDB().Alterar(this);
        }

        public void Excluir()
        {
            new Titulo_curso_DisciplinaDB().Excluir(this);
        }
    }
}
