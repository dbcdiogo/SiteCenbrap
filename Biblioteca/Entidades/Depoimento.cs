using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Depoimento
    {
        public int depoimento_id { get; set; }
        public bool ativo { get; set; }
        public DateTime data { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string curso { get; set; }
        public string texto { get; set; }
        public string dominio { get; set; }

        public Depoimento()
        {
            this.depoimento_id = 0;
            this.ativo = false;
            this.data = DateTime.Now;
            this.nome = "";
            this.cidade = "";
            this.curso = "";
            this.texto = "";
            this.dominio = "";
        }

        public Depoimento(int depoimento_id, bool ativo, DateTime data, string nome, string cidade, string curso, string texto, string dominio)
        {
            this.depoimento_id = depoimento_id;
            this.ativo = ativo;
            this.data = data;
            this.nome = nome;
            this.cidade = cidade;
            this.curso = curso;
            this.texto = texto;
            this.dominio = dominio;
        }

        public string Nome()
        {
            string nome = "";
            if (this.nome != "" && this.nome != "-")
            {
                nome = this.nome;
            }
            if (this.curso != "" && this.curso != "-")
            {
                if (nome != "")
                    nome += " - ";
                nome += this.curso;
            }
            if (this.cidade != "" && this.cidade != "-")
            {
                if (nome != "")
                    nome += " - ";
                nome += this.cidade;
            }

            return nome;
            }
    }
}
