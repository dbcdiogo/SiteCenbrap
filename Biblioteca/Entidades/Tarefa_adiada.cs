using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Tarefa_adiada
    {
        public Tarefa tarefa_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public DateTime de { get; set; }
        public DateTime para { get; set; }

        public Tarefa_adiada()
        {
            this.tarefa_id = new Tarefa();
            this.painel = new Painel();
            this.data = DateTime.Now;
            this.de = DateTime.Now;
            this.para = DateTime.Now;
        }

        public Tarefa_adiada(Tarefa tarefa, Painel painel, DateTime data, DateTime de, DateTime para)
        {
            this.tarefa_id = tarefa;
            this.painel = painel;
            this.data = data;
            this.de = de;
            this.para = para;
        }

        public void Salvar()
        {
            new Tarefa_adiadaDB().Salvar(this);
        }

        public void Excluir()
        {
            new Tarefa_adiadaDB().Excluir(this);
        }
    }
}
