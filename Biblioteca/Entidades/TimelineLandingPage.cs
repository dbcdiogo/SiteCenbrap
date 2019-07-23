using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Biblioteca.Entidades
{
    
    public class TimelineLandingPage
    {
        public int idlandingpage { get; set; }
        public string acao_form { get; set; }
        public string acao_form_url { get; set; }
        public int agradecimento { get; set; }
        public string agradecimento_msg { get; set; }
        public string link_permanente { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int notificar { get; set; }
        public int notificar_email { get; set; }
        public int enviar_email { get; set; }
        public string remetente { get; set; }
        public int email_remetente { get; set; }
        public string assunto { get; set; }
        public int mensagem { get; set; }
        public string titulo_redes { get; set; }
        public string descricao_redes { get; set; }
        public string tximagem { get; set; }
        public string txdownload { get; set; }
        [AllowHtml]
        public string txhtml { get; set; }

        public TimelineLandingPage()
        {
            this.idlandingpage = 0;
            this.acao_form = "";
            this.acao_form_url = "";
            this.agradecimento = 0;
            this.agradecimento_msg = "";
            this.link_permanente = "";
            this.titulo = "";
            this.descricao = "";
            this.notificar = 0;
            this.notificar_email = 0;
            this.enviar_email = 0;
            this.remetente = "";
            this.email_remetente = 0;
            this.assunto = "";
            this.mensagem = 0;
            this.titulo_redes = "";
            this.descricao_redes = "";
            this.tximagem = "";
            this.txdownload = "";
            this.txhtml = "";
        }

        public TimelineLandingPage(int idlandingpage, string titulo, string link_permanente)
        {
            this.idlandingpage = idlandingpage;
            this.titulo = titulo;
            this.link_permanente = link_permanente;
        }

        public TimelineLandingPage(int idlandingpage, string acao_form, string acao_form_url, string txdownload, int agradecimento, string agradecimento_msg, string link_permanente, string titulo, string descricao, int notificar, int notificar_email, int enviar_email, string remetente, int email_remetente, string assunto, int mensagem, string tximagem, string titulo_redes, string descricao_redes, string txhtml)
        {
            this.idlandingpage = idlandingpage;
            this.acao_form = acao_form;
            this.acao_form_url = acao_form_url;
            this.agradecimento = agradecimento;
            this.agradecimento_msg = agradecimento_msg;
            this.link_permanente = link_permanente;
            this.titulo = titulo;
            this.descricao = descricao;
            this.notificar = notificar;
            this.notificar_email = notificar_email;
            this.enviar_email = enviar_email;
            this.remetente = remetente;
            this.email_remetente = email_remetente;
            this.assunto = assunto;
            this.mensagem = mensagem;
            this.titulo_redes = titulo_redes;
            this.descricao_redes = descricao_redes;
            this.txhtml = txhtml;
            this.txdownload = txdownload;
            this.tximagem = tximagem;
        }

        public int Salvar()
        {
            return this.idlandingpage = new TimelineLandingPageDB().Salvar(this);
        }

        public void Alterar()
        {
            new TimelineLandingPageDB().Alterar(this);
        }
    }

    public class LandingPageTemplate
    {
        public int idtemplate { get; set; }
        public string txtemplate { get; set; }
        [AllowHtml]
        public string txhtml { get; set; }
        
        public LandingPageTemplate(int idtemplate, string txtemplate, string txhtml)
        {
            this.idtemplate = idtemplate;
            this.txtemplate = txtemplate;
            this.txhtml = txhtml;
        }
    }

    public class LandingPageFormulario
    {
        public int idform { get; set; }
        public int idlandingpage { get; set; }
        public string txform { get; set; }
        public int fltipo { get; set; }
        public int nrordem { get; set; }

        public LandingPageFormulario()
        {
            this.idform = 0;
            this.idlandingpage = 0;
            this.txform = "";
            this.fltipo = 0;
            this.nrordem = 0;
        }

        public LandingPageFormulario(int idform, int idlandingpage, string txform, int fltipo, int nrordem)
        {
            this.idform = idform;
            this.idlandingpage = idlandingpage;
            this.txform = txform;
            this.fltipo = fltipo;
            this.nrordem = nrordem;
        }
    }
}
