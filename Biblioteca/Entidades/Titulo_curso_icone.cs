using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Titulo_curso_icone
    {
        public Titulo_curso titulo_curso { get; set; }
        public string imagem { get; set; }

        public Titulo_curso_icone()
        {
            this.titulo_curso = new Titulo_curso(0);
            this.imagem = "";
        }

        public Titulo_curso_icone(Titulo_curso titulo_curso, string imagem)
        {
            this.titulo_curso = titulo_curso;
            this.imagem = imagem;
        }
    }
}
