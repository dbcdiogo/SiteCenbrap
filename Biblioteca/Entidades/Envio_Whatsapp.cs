using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Envio_Whatsapp
    {
        public int idmensagem { get; set; }
        public int idaluno { get; set; }
        public string txcelular { get; set; }
        public DateTime dtcadastro { get; set; }
        public DateTime dtenvio { get; set; }
        public Nullable<DateTime> dtenviado { get; set; }
        public string txmensagem { get; set; }
        public string txarquivo { get; set; }

        public Envio_Whatsapp()
        {
            this.idmensagem = 0;
            this.idaluno = 0;
            this.txcelular = "";
            this.dtcadastro = DateTime.Now;
            this.dtenvio = DateTime.Now;
            this.dtenviado = null;
            this.txmensagem = "";
        }

        public Envio_Whatsapp(int idmensagem, string txcelular, string txmensagem)
        {
            this.idmensagem = idmensagem;
            this.txcelular = txcelular;
            this.txmensagem = txmensagem;
        }

        public Envio_Whatsapp(int idmensagem, int idaluno, string txcelular, DateTime dtcadastro, DateTime dtenvio, DateTime dtenviado, string txmensagem, string txarquivo)
        {
            this.idmensagem = idmensagem;
            this.idaluno = idaluno;
            this.txcelular = txcelular;
            this.dtcadastro = dtcadastro;
            this.dtenvio = dtenvio;
            this.dtenviado = dtenviado;
            this.txmensagem = txmensagem;
            this.txarquivo = txarquivo;
        }

        public void Salvar()
        {
            new WhatsappDB().Salvar(this);
        }

        public void AlterarEnviado()
        {
            new WhatsappDB().AlterarEnviado(this);
        }

    }
}
