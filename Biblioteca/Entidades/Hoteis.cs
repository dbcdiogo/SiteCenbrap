using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Hoteis
    {
        public int idhotel { get; set; }
        public string txhotel { get; set; }
        public string txendereco { get; set; }
        public string txemail { get; set; }
        public string txtelefone { get; set; }
        public string txlink { get; set; }
        public int fllocalaula { get; set; }
        public int flhospedagem { get; set; }

        public Hoteis()
        {
            this.idhotel = 0;
            this.txhotel = "";
            this.txendereco = "";
            this.txemail = "";
            this.txtelefone = "";
            this.txlink = "";
            this.fllocalaula = 0;
            this.flhospedagem = 0;
        }

        public Hoteis(int idhotel, string txhotel, string txendereco, string txemail, string txtelefone, string txlink, int fllocalaula, int flhospedagem)
        {
            this.idhotel = idhotel;
            this.txhotel = txhotel;
            this.txendereco = txendereco;
            this.txemail = txemail;
            this.txtelefone = txtelefone;
            this.txlink = txlink;
            this.fllocalaula = fllocalaula;
            this.flhospedagem = flhospedagem;
        }
    }
}
