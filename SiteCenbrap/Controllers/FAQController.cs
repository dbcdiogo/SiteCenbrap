using Biblioteca.DB;
using Biblioteca.Entidades;
using SiteCenbrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Controllers
{
    public class FAQController : OrigemController
    {
        // GET: FAQ
        public ActionResult Index()
        {
            return View(new FaqView());
        }

        public JsonResult Cidades(int curso = 0)
        {
            Titulo_curso titulo_curso = new Titulo_cursoDB().Buscar(curso);
            return Json(new CursoDB().CursosCidade(titulo_curso));
        }

    }
}