
using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class Paginas
    {
        public int paginas_id { get; set; }
        public string dominio { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }

        public Paginas()
        {
            this.paginas_id = 0;
            this.dominio = "";
            this.titulo = "";
            this.texto = "";
        }

        public Paginas(int id)
        {
            this.paginas_id = id;
            this.dominio = "";
            this.titulo = "";
            this.texto = "";
        }
        
        public Paginas(int id, string titulo, string texto, string dominio)
        {
            this.paginas_id = id;
            this.dominio = dominio;
            this.titulo = titulo;
            this.texto = texto;
        }

        public void Salvar()
        {
            new PaginasDB().Salvar(this);
        }

        public void Alterar()
        {
            new PaginasDB().Alterar(this);
        }

        public void Excluir()
        {
            new PaginasDB().Excluir(this);
        }

        public string Texto()
        {
            bool decode = true;
            string txt = this.texto;

            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            txt = reg.Replace(txt, "");
            txt = decode ? HttpUtility.HtmlDecode(txt) : txt;

            if (txt.Length > 200)
                txt = txt.Substring(0, 200) + "...";

            return txt;
        }

    }
}
