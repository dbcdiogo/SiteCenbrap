using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Municipio
    {
        public int codigo { get; set; }
        public string id { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }

        public Municipio()
        {
            this.codigo = 0;
            this.id = "";
            this.municipio = "";
            this.uf = "";
        }

        public Municipio(int codigo, string id, string municipio, string uf)
        {
            this.codigo = codigo;
            this.id = id;
            this.municipio = municipio;
            this.uf = uf;
        }
    }
}
