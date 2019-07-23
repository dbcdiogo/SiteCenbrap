using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Subtarefa
    {
        public int subtarefa_id { get; set; }
        public Tarefa tarefa_id { get; set; }
        public Painel painel { get; set; }
        public string texto { get; set; }
        public DateTime data { get; set; }
        public DateTime? vencimento { get; set; }
        public bool concluido { get; set; }

        public Subtarefa()
        {
            this.subtarefa_id = 0;
            this.tarefa_id = new Tarefa();
            this.painel = new Painel();
            this.texto = "";
            this.data = DateTime.Now;
            this.vencimento = null;
            this.concluido = false;
        }

        public Subtarefa(int id)
        {
            this.subtarefa_id = id;
        }

        public Subtarefa(int id, Tarefa tarefa, Painel painel, string texto, DateTime data, DateTime? vencimento, bool concluido)
        {
            this.subtarefa_id = id;
            this.tarefa_id = tarefa;
            this.painel = painel;
            this.texto = texto;
            this.data = data;
            this.vencimento = vencimento;
            this.concluido = concluido;
        }

        public void Salvar()
        {
            this.subtarefa_id = new SubtarefaDB().Salvar(this.tarefa_id, this.painel, this.data, this.vencimento, this.concluido, this.texto);
        }

        public void Alterar()
        {
            new SubtarefaDB().Alterar(this);
        }

        public void Excluir()
        {
            new SubtarefaDB().Excluir(this);
        }

        public void Concluir(Painel painel)
        {
            if (this.concluido == false)
            {
                this.concluido = true;
                Alterar();
                new Subtarefa_concluido(this, painel, DateTime.Now).Salvar();
            }
        }

        public void Retornar()
        {
            if (this.concluido == true)
            {
                this.concluido = false;
                Alterar();
                new Subtarefa_concluidoDB().Excluir(this);
            }
        }

        public void Adiar(Painel painel, DateTime para)
        {
            new Subtarefa_adiada(this, painel, DateTime.Now, Convert.ToDateTime(this.vencimento), para).Salvar();
            this.vencimento = para;
            Alterar();
        }
    }
}
