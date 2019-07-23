using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Envio_email
    {
        public int codigo { get; set; }
        public string para { get; set; }
        public string assunto { get; set; }
        public string texto { get; set; }
        public DateTime data { get; set; }
        public int envio { get; set; }
        public DateTime data_envio { get; set; }
        public DateTime hora_envio { get; set; }
        public int agendado { get; set; }
        public DateTime data_agendado { get; set; }
        public DateTime hora_agendado { get; set; }
        public string envio_email { get; set; }
        public ContaEnvio contaEnvio_id { get; set; }

        public int encontro { get; set; }

        public int prioridade { get; set; }

        public List<Envio_email_abriu> abriu { get; set; }
        
        public Envio_email()
        {
            this.codigo = 0;
            this.para = "";
            this.assunto = "";
            this.texto = "";
            this.data = DateTime.Now;
            this.envio = 0;
            this.data_envio = DateTime.Now;
            this.hora_envio = DateTime.Now;
            this.agendado = 0;
            this.data_agendado = DateTime.Now;
            this.hora_agendado = DateTime.Now;
            this.encontro = 0;
            this.prioridade = 0;
            this.envio_email = "";

            this.contaEnvio_id = new ContaEnvio();

            this.abriu = new List<Envio_email_abriu>();
        }

        public Envio_email(int codigo, string para, string assunto, string texto, DateTime data, int envio, DateTime data_envio, DateTime hora_envio, int agendado, DateTime data_agendado, DateTime hora_agendado, int encontro, int prioridade, string envio_email)
        {
            this.codigo = codigo;
            this.para = para;
            this.assunto = assunto;
            this.texto = texto;
            this.data = data;
            this.envio = envio;
            this.data_envio = data_envio;
            this.hora_envio = hora_envio;
            this.agendado = agendado;
            this.data_agendado = data_agendado;
            this.hora_agendado = hora_agendado;
            this.encontro = encontro;
            this.prioridade = prioridade;
            this.envio_email = envio_email;
        }

        public Envio_email(int codigo, string para, string assunto, string texto, DateTime data, int envio, DateTime data_envio, string envio_email, List<Envio_email_abriu> abriu)
        {
            this.codigo = codigo;
            this.para = para;
            this.assunto = assunto;
            this.texto = texto;
            this.data = data;
            this.envio = envio;
            this.data_envio = data_envio;
            this.envio_email = envio_email;
            this.abriu = abriu;
        }

        public Envio_email(int codigo, string para, string assunto, string texto, DateTime data, int envio, DateTime data_envio, int agendado, DateTime data_agendado, int encontro, int prioridade, string envio_email = "contato@cenbrap.com.br")
        {
            this.codigo = codigo;
            this.para = para;
            this.assunto = assunto;
            this.texto = texto;
            this.data = data;
            this.envio = envio;
            this.data_envio = data_envio;
            this.agendado = agendado;
            this.data_agendado = data_agendado;
            this.encontro = encontro;
            this.prioridade = prioridade;
            this.envio_email = envio_email;
        }

        public void Salvar()
        {
            new Envio_emailDB().Salvar(this);
        }

        public void Alterar()
        {
            new Envio_emailDB().Alterar(this);
        }
        
        public void Excluir()
        {
            new Envio_emailDB().Excluir(this);
        }

        public void Enviado(string envio_email)
        {
            this.envio = 1;
            this.data_envio = DateTime.Now;
            this.envio_email = envio_email;

            this.Alterar();
        }
    }
}
