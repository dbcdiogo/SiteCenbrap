using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Grupo_tarefas_painel
    {
        public Grupo_tarefas grupo_tarefas_id { get; set; }
        public Painel painel { get; set; }

        public Grupo_tarefas_painel()
        {
            this.grupo_tarefas_id = new Grupo_tarefas();
            this.painel = new Painel();
        }

        public Grupo_tarefas_painel(Grupo_tarefas grupo_tarefas_id, Painel painel)
        {
            this.grupo_tarefas_id = grupo_tarefas_id;
            this.painel = painel;
        }

        public void Salvar()
        {
            new Grupo_tarefas_painelDB().Salvar(this);
        }

        public void Excluir()
        {
            new Grupo_tarefas_painelDB().Excluir(this);
        }

    }
}
