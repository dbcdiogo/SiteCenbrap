using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Grupo_tarefas
    {
        public int grupo_tarefas_id { get; set; }
        public string titulo { get; set; }
        public string cor { get; set; }

        public Grupo_tarefas()
        {
            this.grupo_tarefas_id = 0;
            this.titulo = "";
            this.cor = "";
        }

        public Grupo_tarefas(int id)
        {
            this.grupo_tarefas_id = id;
        }

        public Grupo_tarefas(int grupo_tarefas_id, string titulo, string cor)
        {
            this.grupo_tarefas_id = grupo_tarefas_id;
            this.titulo = titulo;
            this.cor = cor;
        }

        public void Salvar()
        {
            this.grupo_tarefas_id = new Grupo_tarefasDB().Salvar(this.titulo, this.cor);
        }

        public void Alterar()
        {
            new Grupo_tarefasDB().Alterar(this);
        }

        public void Excluir()
        {
            new Grupo_tarefasDB().Excluir(this);
        }

    }
}
