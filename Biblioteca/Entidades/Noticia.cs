using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Noticia
    {
        public int noticia_id { get; set; }
        public string dominio { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public int ordem { get; set; }

        public Noticia()
        {
            this.noticia_id = 0;
            this.dominio = "";
            this.data = DateTime.Now;
            this.titulo = "";
            this.ordem = 0;
        }

        public Noticia(int id)
        {
            this.noticia_id = id;
            this.dominio = "";
            this.data = DateTime.Now;
            this.titulo = "";
            this.ordem = 0;
        }

        public Noticia(string dominio, string titulo, int ordem)
        {
            this.noticia_id = 0;
            this.dominio = dominio;
            this.data = DateTime.Now;
            this.titulo = titulo;
            this.ordem = ordem;
        }

        public Noticia(int id, string dominio, DateTime data, string titulo, int ordem)
        {
            this.noticia_id = id;
            this.dominio = dominio;
            this.data = data;
            this.titulo = titulo;
            this.ordem = ordem;
        }
    }
}
