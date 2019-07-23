using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Tarefa
    {
        public int tarefa_id { get; set; }
        public DateTime? data { get; set; }
        public DateTime? vencimento { get; set; }
        public bool concluido { get; set; }
        public string texto { get; set; }

        public Tarefa()
        {
            this.tarefa_id = 0;
            this.data = null;
            this.vencimento = null;
            this.concluido = false;
            this.texto = "";
        }

        public Tarefa(int id)
        {
            this.tarefa_id = id;
        }

        public Tarefa(int id, DateTime? data, DateTime? vencimento, bool concluido, string texto)
        {
            this.tarefa_id = id;
            this.data = data;
            this.vencimento = vencimento;
            this.concluido = concluido;
            this.texto = texto;
        }

        public void Salvar()
        {
            this.tarefa_id = new TarefaDB().Salvar(this.data, this.vencimento, this.concluido, this.texto);
        }

        public void Alterar()
        {
            new TarefaDB().Alterar(this);
        }

        public void Excluir()
        {
            new TarefaDB().Excluir(this);
        }

        public void Concluir(Painel painel)
        {
            if(this.concluido == false)
            {
                this.concluido = true;
                Alterar();
                new Tarefa_concluido(this, painel, DateTime.Now).Salvar();
            }
        }

        public void Retornar()
        {
            if (this.concluido == true)
            {
                this.concluido = false;
                Alterar();
                new Tarefa_concluidoDB().Excluir(this);
            }
        }

        public void Adiar(Painel painel, DateTime para)
        {
            new Tarefa_adiada(this, painel, DateTime.Now, Convert.ToDateTime(this.vencimento), para).Salvar();
            this.vencimento = para;
            Alterar();
        }
    }
}
