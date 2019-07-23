using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Programacao
    {
        public int programacao_id { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public string texto { get; set; }
        public string dominio { get; set; }
        public string imagem { get; set; }

        public List<Palestrante> palestrantes { get; set; }

        public Programacao()
        {
            this.programacao_id = 0;
            this.inicio = DateTime.Now;
            this.fim = DateTime.Now;
            this.texto = "";
            this.dominio = "";
            this.imagem = "";
        }

        public Programacao(int id, DateTime inicio, DateTime fim, string texto, string dominio, string imagem)
        {
            this.programacao_id = id;
            this.inicio = inicio;
            this.fim = fim;
            this.texto = texto;
            this.dominio = dominio;
            this.imagem = imagem;
        }

        public string Texto()
        {
            return this.texto;
            //return "<strong>" + this.inicio.Hour.ToString("00") + ":" + this.inicio.Minute.ToString("00") + " - " + this.fim.Hour.ToString("00") + ":" + this.fim.Minute.ToString("00") + "</strong> &nbsp;&nbsp;&nbsp;&nbsp; " + this.texto;        }
        }
    }
}
