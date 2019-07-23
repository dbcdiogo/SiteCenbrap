using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Tarefa_curso
    {
        public Tarefa tarefa_id { get; set; }
        public Curso curso { get; set; }

        public Tarefa_curso()
        {
            this.tarefa_id = new Tarefa();
            this.curso = new Curso();
        }

        public Tarefa_curso(Tarefa tarefa, Curso curso)
        {
            this.tarefa_id = tarefa;
            this.curso = curso;
        }

        public void Salvar()
        {
            new Tarefa_cursoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Tarefa_cursoDB().Excluir(this);
        }
    }
}
