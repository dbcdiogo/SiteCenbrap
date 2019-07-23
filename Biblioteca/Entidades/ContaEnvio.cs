using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class ContaEnvio
    {
        public int contaEnvio_id { get; set; }
        public string titulo { get; set; }
        public string email { get; set; }
        public string email_resposta { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public ContaEnvio()
        {
            this.contaEnvio_id = 1;
            this.titulo = "";
            this.email = "";
            this.email_resposta = "";
            this.usuario = "";
            this.senha = "";
        }

        public ContaEnvio(int id, string titulo, string email, string usuario, string senha)
        {
            this.contaEnvio_id = id;
            this.titulo = titulo;
            this.email = email;
            this.email_resposta = "";
            this.usuario = usuario;
            this.senha = senha;
        }

        public ContaEnvio(int id, string titulo, string email, string email_resposta, string usuario, string senha)
        {
            this.contaEnvio_id = id;
            this.titulo = titulo;
            this.email = email;
            this.email_resposta = email_resposta;
            this.usuario = usuario;
            this.senha = senha;
        }
    }
}
