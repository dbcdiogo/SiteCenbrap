using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_desistente
    {
        public int curso { get; set; }
        public string titulo { get; set; }
        public int aluno { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_desistente { get; set; }
        public string obs { get; set; }
        public string obs_financeiro { get; set; }
    }
}
