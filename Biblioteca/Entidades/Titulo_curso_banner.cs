using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Titulo_curso_banner
    {
        public Titulo_curso titulo_curso { get; set; }
        public string imagem { get; set; }

        public Titulo_curso_banner()
        {
            this.titulo_curso = new Titulo_curso();
            this.imagem = "";
        }

        public Titulo_curso_banner(Titulo_curso titulo_curso, string imagem)
        {
            this.titulo_curso = titulo_curso;
            this.imagem = imagem;
        }

        public void Salvar()
        {
            new Titulo_curso_bannerDB().Salvar(this);
        }

        public void Alterar()
        {
            new Titulo_curso_bannerDB().Alterar(this);
        }

        public void Excluir()
        {
            new Titulo_curso_bannerDB().Excluir(this);
        }
    }
}
