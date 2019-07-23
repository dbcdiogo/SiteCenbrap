using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Avisos
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public int aluno { get; set; }
        public int visualizado { get; set; }
        public string titulo { get; set; }
        public string arquivo { get; set; }
        public string texto { get; set; }
        public int urgente { get; set; }
        public DateTime data_visualizado { get; set; }

        public Avisos()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.aluno = 0;
            this.visualizado = 0;
            this.titulo = "";
            this.arquivo = "";
            this.texto = "";
            this.urgente = 0;
            this.data_visualizado = DateTime.Now;
        }

        public Avisos(int codigo, DateTime data, int aluno, int visualizado, string titulo, string arquivo, string texto, int urgente, DateTime data_visualizado)
        {
            this.codigo = codigo;
            this.data = data;
            this.aluno = aluno;
            this.visualizado = visualizado;
            this.titulo = titulo;
            this.arquivo = arquivo;
            this.texto = texto;
            this.urgente = urgente;
            this.data_visualizado = data_visualizado;
        }
    }
}
