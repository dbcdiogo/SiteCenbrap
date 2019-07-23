using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class PreSet_tarefa
    {
        public int preset_tarefa_id { get; set; }
        public PreSet preset_id { get; set; }
        public Grupo_tarefas grupo_tarefas_id { get; set; }
        public string texto { get; set; }
        public int prazo { get; set; } //prazo em dias para o vencimento da tarefa

        public PreSet_tarefa()
        {
            this.preset_tarefa_id = 0;
            this.preset_id = new PreSet();
            this.grupo_tarefas_id = new Grupo_tarefas();
            this.texto = "";
            this.prazo = 0;
        }

        public PreSet_tarefa(int id)
        {
            this.preset_tarefa_id = id;
            this.preset_id = new PreSet();
            this.grupo_tarefas_id = new Grupo_tarefas();
            this.texto = "";
            this.prazo = 0;
        }

        public PreSet_tarefa(int id, PreSet preset, Grupo_tarefas grupo, string texto, int prazo)
        {
            this.preset_tarefa_id = id;
            this.preset_id = preset;
            this.grupo_tarefas_id = grupo;
            this.texto = texto;
            this.prazo = prazo;
        }

        public void Salvar()
        {
            this.preset_tarefa_id = new PreSet_tarefaDB().Salvar(this.preset_id, this.grupo_tarefas_id, this.texto, this.prazo);
        }

        public void Alterar()
        {
            new PreSet_tarefaDB().Alterar(this);
        }

        public void Excluir()
        {
            new PreSet_tarefaDB().Excluir(this);
        }
    }
}
