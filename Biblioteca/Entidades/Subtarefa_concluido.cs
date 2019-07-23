using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Subtarefa_concluido
    {
        public Subtarefa subtarefa_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }

        public Subtarefa_concluido()
        {
            this.subtarefa_id = new Subtarefa();
            this.painel = new Painel();
            this.data = new DateTime();
        }

        public Subtarefa_concluido(Subtarefa subtarefa, Painel painel, DateTime data)
        {
            this.subtarefa_id = subtarefa;
            this.painel = painel;
            this.data = data;
        }

        public void Salvar()
        {
            new Subtarefa_concluidoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Subtarefa_concluidoDB().Excluir(this.subtarefa_id);
        }
    }
}
