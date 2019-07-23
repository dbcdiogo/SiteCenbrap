using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Tarefa_concluido
    {
        public Tarefa tarefa_id { get; set; }
        public Painel painel { get;  set; }
        public DateTime data { get; set; }

        public Tarefa_concluido()
        {
            this.tarefa_id = new Tarefa();
            this.painel = new Painel();
            this.data = new DateTime();
        }

        public Tarefa_concluido(Tarefa tarefa, Painel painel, DateTime data)
        {
            this.tarefa_id = tarefa;
            this.painel = painel;
            this.data = data;
        }

        public void Salvar()
        {
            new Tarefa_concluidoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Tarefa_concluidoDB().Excluir(this.tarefa_id);
        }
    }
}
