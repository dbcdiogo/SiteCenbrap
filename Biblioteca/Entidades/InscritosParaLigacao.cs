using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class InscritosParaLigacao
    {
        public string nome { get; set; }
        public string curso { get; set; }
        public string link { get; set; }
        public string obs { get; set; }

        public InscritosParaLigacao()
        {
            this.nome = "";
            this.curso = "";
            this.link = "";
            this.obs = "";
        }

        public InscritosParaLigacao(string nome, string curso, string link, string obs)
        {
            this.nome = nome;
            this.curso = curso;
            this.link = link;
            this.obs = obs;
        }

        public string Texto()
        {
            return "<tr><td>" + this.nome + "</td><td>" + this.curso + "</td><td>" + this.obs + "</td><td>" + this.link + "</td></tr>";
        }
    }
}
