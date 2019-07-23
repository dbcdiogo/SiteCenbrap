using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Controllers
{
    public class ConhecaController : OrigemController
    {
        // GET: Conheca
        // A Instituicao
        public ActionResult Index()
        {
            return View(new PaginasDB().Buscar(1));
        }

        // Legislacao
        public ActionResult Legislacao()
        {
            return View(new PaginasDB().Buscar(2));
        }

        // Parceiros
        public ActionResult Parceiros()
        {
            return View(new PaginasDB().Buscar(3));
        }

        // CNA-AMB
        public ActionResult CNAAMB()
        {
            return View(new PaginasDB().Buscar(4));
        }

        // PoliticaPrivacidade
        [Route("PoliticaPrivacidade/")]
        public ActionResult PoliticaPrivacidade()
        {
            return View(new PaginasDB().Buscar(5));
        }

        // TrabalheConosco
        public ActionResult TrabalheConosco()
        {
            return View(new PaginasDB().Buscar(6));
        }

        public JsonResult TrabalheConoscoEnviar(string nome, string email, string telefone, string estado, string cidade, string funcao, string escolaridade, string graduado, string objetivo)
        {
            string texto = "<p><strong>Nome: </strong> " + nome + "</p>";
            texto += "<p><strong>E-mail: </strong> " + email + "</p>";
            texto += "<p><strong>Telefone: </strong> " + telefone + "</p>";
            texto += "<p><strong>Cidade: </strong> " + cidade + "/" + estado + "</p>";
            texto += "<p><strong>Função: </strong> " + funcao + "</p>";
            texto += "<p><strong>Escolaridade: </strong> " + escolaridade + "</p>";
            texto += "<p><strong>Graduado: </strong> " + graduado + "</p>";
            texto += "<p><strong>Objetivo: </strong> " + objetivo + "</p>";

            new Envio_email() {
                para = "contato@cenbrap.com.br",
                assunto = "Trabalhe Conosco - Site Cenbrap",
                texto = texto,
                data = DateTime.Now
            }.Salvar();

            return Json(new Retorno());
        }
    }
}