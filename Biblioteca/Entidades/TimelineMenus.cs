using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineMenus
    {
        public int idmenu { get; set; }
        public int idmenupai { get; set; }
        public string txicone { get; set; }
        public string txlink { get; set; }
        public string txmenu { get; set; }
        public int nrordem { get; set; }
        public string txmenupai {get; set; }
        public List<TimelineMenus> filhos { get; set; }

        public TimelineMenus()
        {
            this.idmenu = 0;
            this.idmenupai = 0;
            this.txicone = "";
            this.txlink = "";
            this.txmenu = "";
            this.nrordem = 0;
            this.txmenupai = "";
        }

        public TimelineMenus(int idmenu, string txicone, string txlink, string txmenu, int nrordem)
        {
            this.idmenu = idmenu;
            this.idmenupai = idmenupai;
            this.txicone = txicone;
            this.txlink = txlink;
            this.txmenu = txmenu;
            this.nrordem = nrordem;
            this.filhos = new TimelineMenusDB().ListarFilhos(idmenu);
        }

        public TimelineMenus(int idmenu, int idmenupai, string txicone, string txlink, string txmenu, int nrordem)
        {
            this.idmenu = idmenu;
            this.idmenupai = idmenupai;
            this.txicone = txicone;
            this.txlink = txlink;
            this.txmenu = txmenu;
            this.nrordem = nrordem;
            if (idmenupai > 0)
            {
                this.txmenupai = new TimelineMenusDB().Buscar(idmenupai).txmenu;
            }
        }

        public void Salvar()
        {
            new TimelineMenusDB().Salvar(this);
        }

        public void Alterar()
        {
            new TimelineMenusDB().Alterar(this);
        }

        public void Excluir()
        {
            new TimelineMenusDB().Excluir(this);
        }
    }

}
