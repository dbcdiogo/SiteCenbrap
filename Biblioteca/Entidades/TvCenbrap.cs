using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TvCenbrap
    {
        public DateTime data { get; set; }
        public int tipo { get; set; }
        public string nome { get; set; }
        public string curso { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public int turma { get; set; }
        public int total { get; set; }

        public TvCenbrap(DateTime data, int tipo, string aluno, string curso, string latitude, string longitude, string cidade, string estado, int turma, int total)
        {
            this.data = data;
            this.tipo = tipo;
            this.nome = aluno;
            this.curso = curso;
            this.latitude = latitude;
            this.longitude = longitude;
            this.cidade = cidade;
            this.estado = estado;
            this.turma = turma;
            this.total = total;
        }

        
    }
}
