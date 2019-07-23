using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Entidades;
using Biblioteca.Funcoes;
using Biblioteca.DB;
using SiteCenbrap.Models;

namespace SiteCenbrap.Controllers
{
    public class PagseguroController : Controller
    {
        public ActionResult Pagamento(int id)
        {
            PagamentoPagseguroCenbrap pagamento = new PagamentoPagseguroCenbrap();
            Aluno_pgto aluno_pgto = new Aluno_pgtoDB().Buscar(id);

            if(aluno_pgto == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Aluno_pgto aluno_pgto1 = pagamento.Pagar(aluno_pgto);

            return Redirect(aluno_pgto1.obs);
        }

        [Route("Pagseguro/Retorno/")]
        public ActionResult Retorno(string code = "")
        {

            Aluno_pgto ap = new PagamentoPagseguroCenbrap().ConsultarAssinaturaCode(code);
            
            return View(ap);
        }

        [Route("Pagseguro/Revisao/")]
        public ActionResult Revisao(string code = "")
        {
            Aluno_pgto ap = new PagamentoPagseguroCenbrap().ConsultarCode(code);
            
            return View(ap);
        }

        [Route("Pagseguro/Notificacao/")]
        [HttpPost]
        [NotificacaoPagseguro]
        public JsonResult Notificacao(string notificationCode, string notificationType)
        {
            if (notificationType == "preApproval")
            {
                new PagamentoPagseguroCenbrap().AssinaturaNotificacao(notificationCode);
            }

            if (notificationType == "transaction")
            {
                new PagamentoPagseguroCenbrap().Notificacao(notificationCode);
            }

            return Json("");
        }

        public ActionResult Teste()
        {
            return RedirectToAction("Pagamento", "Pagseguro", new { id = 442559 });
        }

    }
}