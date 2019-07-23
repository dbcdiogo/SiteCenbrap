using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia_arquivo
    {
        public int midia_arquivo_id { get; set; }
        public Midia midia_id { get; set; }
        public string arquivo { get; set; }
        public string texto { get; set; }

        public Midia_arquivo()
        {
            this.midia_arquivo_id = 0;
            this.midia_id = new Midia();
            this.arquivo = "";
            this.texto = "";
        }

        public Midia_arquivo(int id, Midia midia, string arquivo, string texto)
        {
            this.midia_arquivo_id = id;
            this.midia_id = midia;
            this.arquivo = arquivo;
            this.texto = texto;
        }
    }
}
