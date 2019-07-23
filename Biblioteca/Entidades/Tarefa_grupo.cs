using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Tarefa_grupo
    {
        public Grupo_tarefas grupo_tarefas_id { get; set; }
        public Tarefa tarefa_id { get; set; }

        public Tarefa_grupo()
        {
            this.grupo_tarefas_id = new Grupo_tarefas();
            this.tarefa_id = new Tarefa();
        }

        public Tarefa_grupo(Grupo_tarefas grupo, Tarefa tarefa)
        {
            this.grupo_tarefas_id = grupo;
            this.tarefa_id = tarefa;
        }

        public void Salvar()
        {
            new Tarefa_grupoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Tarefa_grupoDB().Excluir(this);
        }
    }
}
