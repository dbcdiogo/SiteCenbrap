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
    public class TimelineKanban
    {
        public int codigo { get; set; }
        public string aluno { get; set; }

        public TimelineKanban(int codigo, string aluno)
        {
            this.codigo = codigo;
            this.aluno = aluno;
        }
    }
}
