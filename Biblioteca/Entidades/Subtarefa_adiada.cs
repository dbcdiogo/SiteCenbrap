using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Subtarefa_adiada
    {
        public Subtarefa subtarefa_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public DateTime de { get; set; }
        public DateTime para { get; set; }

        public Subtarefa_adiada()
        {
            this.subtarefa_id = new Subtarefa();
            this.painel = new Painel();
            this.data = DateTime.Now;
            this.de = DateTime.Now;
            this.para = DateTime.Now;
        }

        public Subtarefa_adiada(Subtarefa subtarefa, Painel painel, DateTime data, DateTime de, DateTime para)
        {
            this.subtarefa_id = subtarefa;
            this.painel = painel;
            this.data = data;
            this.de = de;
            this.para = para;
        }

        public void Salvar()
        {
            new Subtarefa_adiadaDB().Salvar(this);
        }

        public void Excluir()
        {
            new Subtarefa_adiadaDB().Excluir(this);
        }
    }
}
