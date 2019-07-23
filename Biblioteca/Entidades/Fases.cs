using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Fases
    {
        public int idfase { get; set; }
        public string fase { get; set; }

        public Fases()
        {
            this.idfase = 0;
            this.fase = "";
        }

        public Fases(int id)
        {
            this.idfase = id;
            this.fase = "";
        }

        public Fases(int id, string fase)
        {
            this.idfase = id;
            this.fase = fase;
        }
    }
}
