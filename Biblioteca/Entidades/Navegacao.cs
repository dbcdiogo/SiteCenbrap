using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Navegacao
    {
        public int navegacao_id { get; set; }
        public string url { get; set; }
        public string _ga { get; set; }
        public DateTime data { get; set; }

        public Navegacao()
        {
            this.navegacao_id = 0;
            this.url = "";
            this._ga = "";
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Navegacao(int id, string url, string _ga, DateTime data)
        {
            this.navegacao_id = id;
            this.url = url;
            this._ga = _ga;
            this.data = data;
        }

        public Navegacao(string url, string _ga, DateTime data)
        {
            url = Tratar(url);
            this.url = url;
            this._ga = _ga;
            this.data = data;

            if(Validar(url) && url != "")
                new NavegacaoDB().Salvar(this);
        }

        public bool Validar(string url)
        {
            url = url.ToLower();
            bool continuar = true;

            if (url.IndexOf("/mapa") > -1)
                continuar = false;
            if (url.IndexOf("/cursos/banner") > -1)
                continuar = false;
            if (url.IndexOf("/cursos/foto") > -1)
                continuar = false;
            if (url.IndexOf("/home/form") > -1)
                continuar = false;
            if (url.IndexOf("/faq/cidades") > -1)
                continuar = false;
            if (url.IndexOf("/acesso/login") > -1)
                continuar = false;
            if (url.IndexOf("/acesso/login") > -1)
                continuar = false;
            if (url.IndexOf("/blog/img") > -1)
                continuar = false;

            return continuar;
        }

        public string Tratar(string url)
        {
            url = url.ToLower();

            if (url.IndexOf("localhost") > -1)
                url = "";

            if (url.IndexOf("http://") > -1)
                url = url.Replace("http://", "https://");

            if (url.IndexOf("https://www.cenbrap") > -1)
                url = url.Replace("https://www.cenbrap", "https://cenbrap");

            return url;
        }
    }
}
