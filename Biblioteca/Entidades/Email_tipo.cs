using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Email_tipo
    {
        public int codigo { get; set; }
        public int tipo { get; set; }
        public string texto { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public string assunto { get; set; }

        public Email_tipo()
        {
            this.codigo = 0;
            this.tipo = 0;
            this.texto = "";
            this.titulo = "";
            this.assunto = "";
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
        }

        public Email_tipo(int codigo, int tipo, string texto, string titulo, string assunto, Painel painel, DateTime data)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.texto = texto;
            this.titulo = titulo;
            this.assunto = assunto;
            this.painel = painel;
            this.data = data;
        }


    }
}
