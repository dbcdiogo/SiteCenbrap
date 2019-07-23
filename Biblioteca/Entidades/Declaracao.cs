using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Declaracao
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }

        public Declaracao()
        {
            this.codigo = 0;
            this.data = Convert.ToDateTime("01/01/1900");
            this.titulo = "";
            this.texto = "";
        }

        public Declaracao(int codigo, DateTime data, string titulo, string texto)
        {
            this.codigo = codigo;
            this.data = data;
            this.titulo = titulo;
            this.texto = texto;
        }
    }
}
