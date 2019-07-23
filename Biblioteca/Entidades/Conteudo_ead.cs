using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Conteudo_ead
    {
        public int conteudo_ead_id { get; set; }
        public Curso curso { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public bool ativo { get; set; }
        public DateTime data_ativo { get; set; }
        public DateTime data_ativo_fim { get; set; }
        public string categoria { get; set; }

        public Conteudo_ead()
        {
            this.conteudo_ead_id = 0;
            this.curso = new Curso() { codigo = 0 };
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.titulo = "";
            this.conteudo = "";
            this.ativo = false;
            this.data_ativo = DateTime.Now;
            this.data_ativo_fim = DateTime.Now;
            this.categoria = "";
        }

        public Conteudo_ead(int conteudo_ead_id, Curso curso, DateTime data, Painel painel, string titulo, string conteudo, bool ativo, DateTime data_ativo, DateTime data_ativo_fim, string categoria)
        {
            this.conteudo_ead_id = conteudo_ead_id;
            this.curso = curso;
            this.data = data;
            this.painel = painel;
            this.titulo = titulo;
            this.conteudo = conteudo;
            this.ativo = ativo;
            this.data_ativo = data_ativo;
            this.data_ativo_fim = data_ativo_fim;
            this.categoria = categoria;
        }

    }
}
