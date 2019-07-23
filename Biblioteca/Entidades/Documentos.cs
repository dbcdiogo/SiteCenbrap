using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Documentos
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public string documentos { get; set; }
        public string documentos1 { get; set; }

        public Documentos()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.documentos = "";
            this.documentos1 = "";
        }

        public Documentos(int codigo)
        {
            this.codigo = codigo;
            this.curso = new Curso() { codigo = 0 };
            this.documentos = "";
            this.documentos1 = "";
        }

        public Documentos(int codigo, Curso curso, string documentos, string documentos1)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.documentos = documentos;
            this.documentos1 = documentos1;
        }

        public void Salvar()
        {
            new DocumentosDB().Salvar(this);
        }

        public void Alterar()
        {
            new DocumentosDB().Alterar(this);
        }

        public void Excluir()
        {
            new DocumentosDB().Excluir(this);
        }
    }
}
