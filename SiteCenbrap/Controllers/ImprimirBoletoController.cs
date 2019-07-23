using Biblioteca.DB;
using Biblioteca.Entidades;
using Biblioteca.Filters;
using Biblioteca.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Controllers
{
    public class ImprimirBoletoController : OrigemController
    {
        // GET: Boleto
        [Compress]
        [Route("ImprimirBoleto/{curso}/{aluno}")]
        public ActionResult Index(int aluno = 0, int curso = 0)
        {
            Retorno retorno = new Retorno();

            Curso c = new CursoDB().Buscar(curso);

            if (c == null || c.ativo == 0)
            {
                retorno.erro = true;
                if (c.ativo == 0)
                    retorno.mensagem = "Curso com matrículas encerradas.";
                else
                    retorno.mensagem = "Ocorreu, tente novamente no site";
            }
            else
            {
                Aluno a = new AlunoDB().Buscar(aluno);

                if (a == null)
                {
                    retorno.erro = true;
                    retorno.mensagem = "Não foi possível localizar o aluno.";
                }
                else
                {
                    retorno = new Inclusao().Incluir(c, a, 3, pagImprimirBoleto: true);
                }
            }

            if (retorno.erro)
            {
                return View(retorno);
            }
            else
            {
                return Redirect(retorno.link);
            }
        }

    }
}