using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Curso_adiamento
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public Painel painel { get; set; }
        public DateTime de { get; set; }
        public DateTime para { get; set; }
        public DateTime data { get; set; }

        public Curso_adiamento()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.painel = new Painel() { codigo = 0 };
            this.de = DateTime.Now;
            this.para = DateTime.Now;
            this.data = DateTime.Now;
        }

        public Curso_adiamento(int codigo, Curso curso, Painel painel, DateTime de, DateTime para, DateTime data)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.painel = painel;
            this.de = de;
            this.para = para;
            this.data = data;
        }
    }
}
