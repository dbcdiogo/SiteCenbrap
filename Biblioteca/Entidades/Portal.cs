using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Portal
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public int aluno { get; set; }

        public Portal()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.aluno = 0;
        }

        public Portal(int codigo, DateTime data, int aluno)
        {
            this.codigo = codigo;
            this.data = data;
            this.aluno = aluno;

        }
    }
}
