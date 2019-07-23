using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Disciplina
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public Curso curso { get; set; }
        public int modulo { get; set; }
        public int professor { get; set; }
        public int professor1 { get; set; }
        public int professor2 { get; set; }
        public string titulo { get; set; }
        public string titulo1 { get; set; }
        public string texto { get; set; }
        public string obs { get; set; }
        public int ativo { get; set; }
        public int vinculado { get; set; }
        public string titulo_certificadora { get; set; }
        public int disciplina_professor { get; set; }

        public Disciplina()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.curso = new Curso() { codigo = 0 };
            this.modulo = 0;
            this.professor = 0;
            this.professor1 = 0;
            this.professor2 = 0;
            this.titulo = "";
            this.titulo1 = "";
            this.texto = "";
            this.obs = "";
            this.ativo = 0;
            this.vinculado = 0;
            this.titulo_certificadora = "";
            this.disciplina_professor = 0;
        }

        public Disciplina(int codigo, DateTime data, Painel painel, Curso curso, int modulo, int professor, int professor1, int professor2, string titulo, string titulo1, string texto, string obs, int ativo, int vinculado, string titulo_certificadora, int disciplina_professor)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.curso = curso;
            this.modulo = modulo;
            this.professor = professor;
            this.professor1 = professor1;
            this.professor2 = professor2;
            this.titulo = titulo;
            this.titulo1 = titulo1;
            this.texto = texto;
            this.obs = obs;
            this.ativo = ativo;
            this.vinculado = vinculado;
            this.titulo_certificadora = titulo_certificadora;
            this.disciplina_professor = disciplina_professor;
        }
    }
}
