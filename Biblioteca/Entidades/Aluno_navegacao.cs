using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_navegacao
    {
        public Aluno aluno { get; set; }
        public string _ga { get;set; }
        public DateTime data { get; set; }

        public Aluno_navegacao()
        {
            this.aluno = new Aluno();
            this._ga = "";
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Aluno_navegacao(Aluno aluno, string _ga, DateTime data)
        {
            this.aluno = aluno;
            this._ga = _ga;
            this.data = data;
        }

        public void Salvar()
        {
            new Aluno_navegacaoDB().Salvar(this);
        }
    }
}
