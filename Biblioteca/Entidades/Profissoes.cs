using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Profissoes
    {
        public int idprofissao { get; set; }
        public string txprofissao { get; set; }
        

        public Profissoes()
        {
            this.idprofissao = 0;
            this.txprofissao = "";
        }

        public Profissoes(int idprofissao, string txprofissao)
        {
            this.idprofissao = idprofissao;
            this.txprofissao = txprofissao;
        }

    }
}
