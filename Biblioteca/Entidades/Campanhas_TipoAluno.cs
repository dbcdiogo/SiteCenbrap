using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Campanhas_TipoAluno
    {
        public int idcampanha { get; set; }
        public int flnovos { get; set; }
        public int flantigos { get; set; }
        public string txstatus { get; set; }

        public Campanhas_TipoAluno()
        {
            this.idcampanha = 0;
            this.flnovos = 0;
            this.flantigos = 0;
            this.txstatus = "";
        }


        public Campanhas_TipoAluno(int id, int novos, int antigos, string status)
        {
            this.idcampanha = id;
            this.flnovos = novos;
            this.flantigos = antigos;
            this.txstatus = status;
        }

        public int Existe(int id)
        {
            return new Campanhas_TipoAlunoDB().Existe(id);
        }

    }

}
