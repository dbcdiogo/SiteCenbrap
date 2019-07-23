using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Banners
    {
        public int idbanner { get; set; }
        public int idsite { get; set; }
        public string txfoto { get; set; }
        public string txlink { get; set; }
        public int nrordem { get; set; }
        public int flativo { get; set; }
        public DateTime dtinicio { get; set; }
        public DateTime dtfim { get; set; }
        public Sites site { get; set; }

        public Banners()
        {
            this.idbanner = 0;
            this.idsite = 0;
            this.txfoto = "";
            this.txlink = "";
            this.nrordem = 0;
            this.flativo = 1;
            this.dtinicio = Convert.ToDateTime("01/01/1900");
            this.dtfim = Convert.ToDateTime("01/01/1900");
        }

        public Banners(int idbanner)
        {
            this.idbanner = idbanner;
        }

        public Banners(int idbanner, int idsite, string txfoto, string txlink, int nrordem, int flativo, DateTime dtinicio, DateTime dtfim)
        {
            this.idbanner = idbanner;
            this.idsite = idsite;
            this.txfoto = txfoto;
            this.txlink = txlink;
            this.nrordem = nrordem;
            this.flativo = flativo;
            this.dtinicio = dtinicio;
            this.dtfim = dtfim;
            this.site = new SitesDB().Buscar(idsite);
        }

        public Banners(int idbanner, string txlink)
        {
            this.idbanner = idbanner;
            this.txlink = txlink;
        }

        public void Salvar()
        {
            this.idbanner = new BannersDB().Salvar(this);
        }

        public void Alterar()
        {
            new BannersDB().Alterar(this);
        }
    }
}
