using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Envio_email_abriu
    {
        public int envio_email_abriu_id { get; set; }
	    public Envio_email envio_email { get; set; }
        public DateTime data { get; set; }

        public Envio_email_abriu()
        {
            this.envio_email_abriu_id = 0;
            this.envio_email = new Envio_email();
            this.data = DateTime.Now;
        }

        public Envio_email_abriu(int envio_email)
        {
            this.envio_email_abriu_id = 0;
            this.envio_email = new Envio_email() { codigo = envio_email };
            this.data = DateTime.Now;

            Salvar();
        }

        public Envio_email_abriu(int id, Envio_email envio_email, DateTime data)
        {
            this.envio_email_abriu_id = envio_email_abriu_id;
            this.envio_email = envio_email;
            this.data = data;
        }

        public void Salvar()
        {
            new Envio_email_abriuDB().Salvar(this);
        }

        public void Excluir()
        {
            new Envio_email_abriuDB().Excluir(this);
        }
    }
}
