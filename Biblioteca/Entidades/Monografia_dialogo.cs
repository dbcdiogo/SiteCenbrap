using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Monografia_dialogo
    {
        public int codigo { get; set; }
        public Monografia monografia { get; set; }
        public Curso curso { get; set; }
        public int de { get; set; }
        public DateTime data { get; set; }
        public string texto { get; set; }

        public Monografia_dialogo()
        {
            this.codigo = 0;
            this.monografia = new Monografia() { codigo = 0 };
            this.curso = new Curso() { codigo = 0 };
            this.de = 0;
            this.data = DateTime.Now;
            this.texto = "";
        }

        public Monografia_dialogo(int codigo, Monografia monografia, Curso curso, int de, DateTime data, string texto)
        {
            this.codigo = codigo;
            this.monografia = monografia;
            this.curso = curso;
            this.de = de;
            this.data = data;
            this.texto = texto;
        }

        public Monografia_dialogo(Monografia monografia, Curso curso, int de, string texto)
        {
            this.codigo = 0;
            this.monografia = monografia;
            this.curso = curso;
            this.de = de;
            this.data = DateTime.Now;
            this.texto = texto;
        }

    }
}
