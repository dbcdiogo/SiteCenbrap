using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Models
{
    public class NotificacaoPagseguroAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "https://sandbox.pagseguro.uol.com.br");
            base.OnActionExecuting(filterContext);
        }
    }
}