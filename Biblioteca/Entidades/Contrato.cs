using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Contrato
    {
        public int idcontrato { get; set; }
        public string txcontrato { get; set; }
        public string txtexto { get; set; }

        public Contrato()
        {
            this.idcontrato = 0;
            this.txcontrato = "";
            this.txtexto = "";
        }

        public Contrato(int id)
        {
            this.idcontrato = id;
            this.txcontrato = "";
            this.txtexto = "";
        }

        public Contrato(int idcontrato, string txcontrato, string txtexto)
        {
            this.idcontrato = idcontrato;
            this.txcontrato = txcontrato;
            this.txtexto = txtexto;
        }
    }
}
