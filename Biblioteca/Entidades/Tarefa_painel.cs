using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Tarefa_painel
    {
        public Tarefa tarefa_id { get; set; }
        public Painel painel { get; set; }

        public Tarefa_painel()
        {
            this.tarefa_id = new Tarefa();
            this.painel = new Painel();
        }

        public Tarefa_painel(Tarefa tarefa, Painel painel)
        {
            this.tarefa_id = tarefa;
            this.painel = painel;
        }
    }
}
