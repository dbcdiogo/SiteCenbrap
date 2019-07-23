using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class WhatsappMsgs
    {
        public string de { get; set; }
        public string para { get; set; }
        public string telefone { get; set; }
        public DateTime data { get; set; }
        public string texto { get; set; }
        public string arquivo { get; set; }

        public WhatsappMsgs()
        {
            this.de = de;
            this.para = para;
            this.telefone = telefone;
            this.data = data;
            this.texto = texto;
            this.arquivo = arquivo;
        }

    }
}
