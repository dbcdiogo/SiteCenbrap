using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Entidades;
using Biblioteca.DB;
using SiteCenbrap.Models;
using Biblioteca.Filters;
using System.IO;
using System.Drawing;
using Biblioteca.Funcoes;

namespace SiteCenbrap.Controllers
{
    public class PPP2019Controller : OrigemController
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}