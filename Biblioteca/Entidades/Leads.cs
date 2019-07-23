using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Leads
    {
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime data { get; set; }
        public string telefone { get; set; }
        public int landingpage { get; set; }
        public int aluno { get; set; }
        public string nome_aluno { get; set; }

        public Leads()
        {
            this.nome = "";
            this.email = "";
            this.data = Convert.ToDateTime("1900-01-01");
            this.telefone = "";
            this.landingpage = 0;
            this.aluno = 0;
            this.nome_aluno = "";
        }

        public Leads(string nome, string email, DateTime data, string telefone, int landingpage, int aluno, string nome_aluno)
        {
            this.nome = nome;
            this.email = email;
            this.data = data;
            this.telefone = telefone;
            this.landingpage = landingpage;
            this.aluno = aluno;
            this.nome_aluno = nome_aluno;
        }

    }
}
