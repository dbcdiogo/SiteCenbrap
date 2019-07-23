using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class ConfigSite
    {
        public string dominio { get; set; }
        public string imagem { get; set; }

        public ConfigSite()
        {
            this.dominio = "";
            this.imagem = "";
        }

        public ConfigSite(string dominio, string imagem)
        {
            this.dominio = dominio;
            this.imagem = imagem;
        }
    }
}
