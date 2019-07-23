using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Dominio
    {
        public int iddominio { get; set; }
        public string dominio { get; set; }
        public string smtp { get; set; }
        public int porta { get; set; }
        public int autenticacao { get; set; }

        public Dominio()
        {
            this.iddominio = 0;
            this.dominio = "";
            this.smtp = "";
            this.porta = 0;
            this.autenticacao = 0;
        }

        public Dominio(int id)
        {
            this.iddominio = id;
            this.dominio = "";
            this.smtp = "";
            this.porta = 0;
            this.autenticacao = 0;
        }

        public Dominio(int id, string dominio, string smtp, int porta, int autenticacao)
        {
            this.iddominio = id;
            this.dominio = dominio;
            this.smtp = smtp;
            this.porta = porta;
            this.autenticacao = autenticacao;
        }
    }
}
