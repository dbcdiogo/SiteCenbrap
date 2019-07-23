using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Biblioteca.Filters
{
    public class AutenticacaoMedTVAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //pega o cookies painel
            HttpCookie cookie = HttpContext.Current.Request.Cookies["medtv_id"];

            if (cookie != null)
            {
                //pega o valor do cookie
                int codigo = Convert.ToInt32(cookie.Value);

                //abre o cliente e pesquisa no db
                AlunoDB db = new AlunoDB();
                Aluno user = db.Buscar(codigo);

                //verifica se o usuário existe
                if (user != null)
                {
                    if (new Aluno_MedTVDB().Ativo(user))
                    {
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        //se não existe, redireciona para o index.
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Ativar" }));
                    }

                }
                else
                {
                    //se não existe, redireciona para o index.
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Entrar" }));
                }

            }
            else
            {
                //se foi enviado para um vídeo, verificar se tem trailer
                if (filterContext.HttpContext.Request.RawUrl.ToLower().IndexOf("video") > -1 && (filterContext.ActionParameters["id"] != null))
                {
                    Video video = new VideoDB().Buscar((int)filterContext.ActionParameters["id"]);

                    if (video != null)
                    {
                        if (video.trailer_id != 0)
                        {
                            //se não existe, redireciona para o index.
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Entrar", id = video.trailer_id }));
                            return;
                        }
                    }
                }
                //se os cookeis não existem, redireciona para o index
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Entrar" }));
            }

        }
    }

    public class AutenticacaoMedTVAtivarAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //pega o cookies painel
            HttpCookie cookie = HttpContext.Current.Request.Cookies["medtv_ativar"];

            //verifica se o cookie possui valor
            if (cookie != null)
            {
                //pega o valor do cookie
                int codigo = Convert.ToInt32(cookie.Value);

                //abre o cliente e pesquisa no db
                AlunoDB db = new AlunoDB();
                Aluno user = db.Buscar(codigo);

                //verifica se o usuário existe
                if (user != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    //se não existe, redireciona para o index.
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Entrar" }));
                }

            }
            else
            {
                //se os cookeis não existem, redireciona para o index
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Entrar" }));
            }

        }
    }

}
