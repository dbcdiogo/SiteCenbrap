using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Entidades;
using Biblioteca.DB;
using Biblioteca.Funcoes;

namespace SiteCenbrap.Controllers
{
    public class OrigemController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string _ga = Cookies_ga();
            string identificador = "";

            if (Request.QueryString["identificador"] != null)
            {
                if (Request.QueryString["identificador"] != "")
                {
                    identificador = Request.QueryString["identificador"];
                }
            }
            if (Request.QueryString["_identificador"] != null)
            {
                if (Request.QueryString["_identificador"] != "")
                {
                    identificador = Request.QueryString["_identificador"];
                }
            }
            if (Request.QueryString["_id"] != null)
            {
                if (Request.QueryString["_id"] != "")
                {
                    identificador = Request.QueryString["_id"];
                }
            }

            if (identificador != "")
            {
                //Verifica se já tem Mídia
                MidiaDB midiaDB = new MidiaDB();
                if (!midiaDB.Existe(identificador))
                {
                    new Midia(0, new Midia_tipo(8, ""), new Painel(0), DateTime.Now, "Identificador " + identificador, "", 0, "", 0, 0, 0, 0, 0, 0, false, identificador).Salvar();
                }
            }

            //Se teve url de origem
            Uri uri = Request.UrlReferrer;
            if (uri != null)
            {
                new UrlOrigem(uri.Host, uri.PathAndQuery, Request.Url.OriginalString, Request.UserHostAddress, _ga, identificador).Salvar();
            }

            //Se recebeu o Cartaz
            string cartaz = Request.QueryString["cartaz"];
            if(cartaz != null)
                if(cartaz != "")
                    new MarcarCartaz().Marcar(cartaz, Request.UserHostAddress);

            //Se veio por email
            int idenviado = 0;
            int i_idenviado = 0;

            if (Request.QueryString["idenviado"] != null)
            {
                if(Request.QueryString["idenviado"] != "")
                {
                    if (int.TryParse(Request.QueryString["idenviado"], out i_idenviado))
                    {
                        idenviado = i_idenviado;
                    }

                    int cont = 0;
                    int i_cont = 0;
                    if (Request.QueryString["cont"] != null)
                    {
                        if (int.TryParse(Request.QueryString["cont"], out i_cont))
                        {
                            cont = i_cont;
                        }
                    }

                    if(idenviado != 0)
                    {
                        new Clicou(idenviado, cont);

                        //retorna o email do envio
                        if(_ga != null && _ga != "")
                        {
                            string email = new EnviadoDB().Email(idenviado);
                            if (email != "")
                            {
                                //Verifica se já é aluno e se o _ga está salvo para o aluno_navegacao
                                Aluno aluno = new AlunoDB().Email(email);
                                if (aluno != null)
                                {
                                    new Aluno_navegacaoDB().Existe(aluno, _ga);
                                }
                            }
                            else
                            {
                                Newsletter newsletter = new NewsletterDB().Buscar(email);
                                if (newsletter != null)
                                {
                                    new Newsletter_navegacaoDB().Existe(newsletter, _ga);
                                }
                            }
                        }
                    }
                }
            }

            //se _ga for diferente de ""
            if(_ga != null && _ga != "")
            {
                new Navegacao(Request.Url.AbsoluteUri, _ga, DateTime.Now);
            }

            return base.BeginExecuteCore(callback, state);
        }

        public string Cookies_ga()
        {
            string _ga = "";

            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookie = new HttpCookie("_ga");
            if (Request.Url.Host != "localhost")
            {
                cookie.Domain = ".cenbrap.com.br";
            }
            cookie = Request.Cookies["_ga"];

            //verifica se o cookie possui valor
            if (cookie != null)
            {
                //pega o valor do cookie
                _ga = Convert.ToString(cookie.Value);
            }

            return _ga;
        }
    }
}