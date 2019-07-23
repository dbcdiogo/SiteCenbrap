using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCenbrap.Models
{
    public class DescadastrarView
    {
        public int campanha { get; set; } = 0;
        public string email { get; set; } = "";
        public Aluno aluno { get; set; } = null;
        public List<Aluno_curso> aluno_curso { get; set; } = null;

        public DescadastrarView(int campanha, string email)
        {
            if ((campanha > 0) && (email != ""))
            {
                this.campanha = campanha;
                this.email = email;
                this.aluno = new AlunoDB().Email(email);
                this.aluno_curso = new Aluno_cursoDB().ListarCurso(this.aluno);
                
            }
        }

    }
}