using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Cidade_banner
    {
        public Cidade cidade { get; set; }
        public string imagem { get; set; }

        public Cidade_banner()
        {
            this.cidade = new Cidade();
            this.imagem = "";
        }

        public Cidade_banner(Cidade cidade, string imagem)
        {
            this.cidade = cidade;
            this.imagem = imagem;
        }
    }
}
