using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Palestrante
    {
        public int palestrante_id { get; set; }
        public string dominio { get; set; }
        public string nome { get; set; }
        public string titulo { get; set; }
        public string trabalho { get; set; }
        public string foto { get; set; }
        public string curriculo { get; set; }
        public int ordem { get; set; }

        public Palestrante()
        {
            this.palestrante_id = 0;
            this.dominio = "";
            this.nome = "";
            this.titulo = "";
            this.trabalho = "";
            this.foto = "";
            this.curriculo = "";
            this.ordem = 0;
        }

        public Palestrante(int id, string dominio, string nome, string titulo, string trabalho, string foto, string curriculo, int ordem)
        {
            this.palestrante_id = id;
            this.dominio = dominio;
            this.nome = nome;
            this.titulo = titulo;
            this.trabalho = trabalho;
            this.foto = foto;
            this.curriculo = curriculo;
            this.ordem = ordem;
        }
    }
}
