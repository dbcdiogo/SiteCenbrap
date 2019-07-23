using Biblioteca.Filters;
using Biblioteca.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Controllers
{
    public class AcessoController : OrigemController
    {
        // GET: Portal
        public ActionResult Index()
        {
            return PartialView();
        }

        [Compress]
        public JsonResult Login(string login, string senha)
        {
            return Json(new Inclusao().Login(login, senha, true));
        }
    }
}