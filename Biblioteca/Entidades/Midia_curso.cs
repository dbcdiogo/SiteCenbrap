using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia_curso
    {
        public Midia midia_id { get; set; }
        public Curso curso { get; set; }

        public Midia_curso()
        {
            this.midia_id = new Midia();
            this.curso = new Curso();
        }

        public Midia_curso(Midia midia, Curso curso)
        {
            this.midia_id = midia;
            this.curso = curso;
        }

        public void Salvar()
        {
            new Midia_cursoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Midia_cursoDB().Excluir(this);
        }
    }
}
