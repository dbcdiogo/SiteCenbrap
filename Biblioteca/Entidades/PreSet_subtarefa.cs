using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class PreSet_subtarefa
    {
        public int preset_subtarefa_id { get; set; }
        public PreSet_tarefa preset_tarefa_id { get; set; }
        public string texto { get; set; }
        public int prazo { get; set; }

        public PreSet_subtarefa()
        {
            this.preset_subtarefa_id = 0;
            this.preset_tarefa_id = new PreSet_tarefa();
            this.texto = "";
            this.prazo = 0;
        }

        public PreSet_subtarefa(int id)
        {
            this.preset_subtarefa_id = id;
            this.preset_tarefa_id = new PreSet_tarefa();
            this.texto = "";
            this.prazo = 0;
        }

        public PreSet_subtarefa(int id, PreSet_tarefa preset_tarefa, string texto, int prazo)
        {
            this.preset_subtarefa_id = id;
            this.preset_tarefa_id = preset_tarefa;
            this.texto = texto;
            this.prazo = prazo;
        }

        public void Salvar()
        {
            this.preset_subtarefa_id = new PreSet_subtarefaDB().Salvar(this.preset_tarefa_id, this.texto, this.prazo);
        }

        public void Alterar()
        {
            new PreSet_subtarefaDB().Alterar(this);
        }

        public void Excluir()
        {
            new PreSet_subtarefaDB().Excluir(this);
        }
    }
}
