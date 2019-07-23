using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia_titulo_curso
    {
        public Midia midia_id { get; set; }
        public Titulo_curso titulo_curso { get; set; }

        public Midia_titulo_curso()
        {
            this.midia_id = new Midia();
            this.titulo_curso = new Titulo_curso();
        }

        public Midia_titulo_curso(Midia midia, Titulo_curso titulo_curso)
        {
            this.midia_id = midia;
            this.titulo_curso = titulo_curso;
        }

        public void Salvar()
        {
            new Midia_titulo_cursoDB().Salvar(this);
        }
    }
}
