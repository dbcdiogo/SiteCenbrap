using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Sites
    {
        public int idsite { get; set; }
        public string txsite { get; set; }

        public Sites()
        {
            this.idsite = 0;
            this.txsite = "";
        }

        public Sites(int id)
        {
            this.idsite = id;
            this.txsite = "";
        }

        public Sites(int id, string site)
        {
            this.idsite = id;
            this.txsite = site;
        }
    }
}
