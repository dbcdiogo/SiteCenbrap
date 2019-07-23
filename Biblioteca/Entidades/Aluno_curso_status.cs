using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_curso_Status
    {
        public int aluno_curso { get; set; }
        public int status { get; set; }
        public DateTime dtstatus { get; set; }
        public int idusuario { get; set; }

        public Aluno_curso_Status()
        {
            this.aluno_curso = 0;
            this.status = 0;
            this.dtstatus = DateTime.Now;
            this.idusuario = 0;
        }

        public Aluno_curso_Status(int aluno_curso, int status, DateTime dtstatus, int idusuario)
        {
            this.aluno_curso = aluno_curso;
            this.status = status;
            this.dtstatus = dtstatus;
            this.idusuario = idusuario;
        }

        public void Salvar()
        {
            new Aluno_curso_StatusDB().Salvar(this);
        }

    }
}
