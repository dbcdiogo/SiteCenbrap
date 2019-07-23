using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class TimelineCursosDashboard
    {
        public int modulo { get; set; }
        public int numero { get; set; }
        public string curso { get; set; }
        public DateTime data1 { get; set; }
        public DateTime data2 { get; set; }
        public string disciplina { get; set; }
        public string professor { get; set; }
        public string representante { get; set; }
        public string telefone { get; set; }
        public int codigo_curso { get; set; }
        public int codigo_encontro { get; set; }
        public string chave { get; set; }

        public TimelineCursosDashboard()
        {            
            this.modulo = modulo;
            this.numero = numero;
            this.curso = curso;
            this.data1 = data1;
            this.data2 = data2;
            this.disciplina = disciplina;
            this.professor = professor;
            this.telefone = telefone;
            this.representante = representante;
            this.codigo_curso = codigo_curso;
            this.codigo_encontro = codigo_encontro;
            this.chave = chave;
        }

    }
}
