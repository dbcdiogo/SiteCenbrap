using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteCenbrap.Models;
using Biblioteca.Filters;
using Biblioteca.Entidades;
using Biblioteca.DB;
using Biblioteca.Funcoes;

namespace SiteCenbrap.Controllers
{
    public class InscrevaController : OrigemController
    {
        // GET: Inscreva
        public ActionResult Index()
        {
            return View(new InscrevaView(0, 0));
        }

        [Route("Inscreva/TipoCursos")]
        public JsonResult TipoCursos(int id = -1, int id2 = 0, int id3 = 0)
        {
            switch (id)
            {
                case 0:
                    return Json(new { cursos = Json(new CursoDB().TituloCursos(TipoCurso.PosGraduacao)), cidades = Json(new CursoDB().Cidades(id)), turmas = Json(new CursoDB().Cursos(id, 0, 0)) }, JsonRequestBehavior.AllowGet);
                case 1:
                    return Json(new { cursos = Json(new CursoDB().TituloCursos(TipoCurso.WorkShop)), cidades = Json(new CursoDB().Cidades(id)), turmas = Json(new CursoDB().Cursos(id, 0, 0)) }, JsonRequestBehavior.AllowGet);
                case 2:
                    return Json(new { cursos = Json(new CursoDB().TituloCursos(TipoCurso.EaD)), cidades = Json(new CursoDB().Cidades(id)), turmas = Json(new CursoDB().Cursos(id, 0, 0)) }, JsonRequestBehavior.AllowGet);
                default:
                    return Json(new { cursos = "", cidades = "" }, JsonRequestBehavior.AllowGet);
            }            
        }

        [Route("Inscreva/Cidades")]
        public JsonResult Cidades(int id = -1, int id2 = 0, int id3 = 0)
        {
            // Tipo não selecionado
            if (id == -1)
                return Json(new { cursos = Json(new CursoDB().TituloCursos(cidade: new CidadeDB().Buscar(id2))), turmas = Json(new CursoDB().Cursos(id2, 0)) }, JsonRequestBehavior.AllowGet);
            // Tipo selecionado
            else
                switch (id)
                {
                    case 0:
                        return Json(new { cursos = Json(new CursoDB().TituloCursos(cidade: new CidadeDB().Buscar(id2), tipo: TipoCurso.PosGraduacao)), turmas = Json(new CursoDB().Cursos(id, id2, 0)) }, JsonRequestBehavior.AllowGet);
                    case 1:
                        return Json(new { cursos = Json(new CursoDB().TituloCursos(cidade: new CidadeDB().Buscar(id2), tipo: TipoCurso.WorkShop)), turmas = Json(new CursoDB().Cursos(id, id2, 0)) }, JsonRequestBehavior.AllowGet);
                    case 2:
                        return Json(new { cursos = Json(new CursoDB().TituloCursos(cidade: new CidadeDB().Buscar(id2), tipo: TipoCurso.EaD)), turmas = Json(new CursoDB().Cursos(id, id2, 0)) }, JsonRequestBehavior.AllowGet);
                    default:
                        return Json(new { cursos = "", turmas = "" }, JsonRequestBehavior.AllowGet);
                }   
        }

        [Route("Inscreva/Cursos")]
        public JsonResult Cursos(int id = -1, int id2 = 0, int id3 = 0)
        {
            // Tipo e cidade não selecionados
            if ((id == -1) && (id2 == 0))
                return Json(new { turmas = Json(new CursoDB().Cursos(0, id3)) }, JsonRequestBehavior.AllowGet);
            // Tipo selecionado e cidade não selecionada
            else if ((id > -1) && (id2 == 0))
                return Json(new { turmas = Json(new CursoDB().Cursos(id, 0, id3)), cidades = Json(new CursoDB().CidadesTituloCursos(id, id3)) }, JsonRequestBehavior.AllowGet);
            // Tipo não selecionado e cidade selecionada
            else if ((id == -1) && (id2 > 0))
                return Json(new { turmas = Json(new CursoDB().Cursos(id2, id3)) }, JsonRequestBehavior.AllowGet);
            // Tipo e cidade selecionados
            else
                return Json(new { turmas = Json(new CursoDB().Cursos(id, id2, id3)) }, JsonRequestBehavior.AllowGet);
        }

        [Compress]
        [Route("Inscreva/Login")]
        public JsonResult Login(string login, string senha)
        {
            return Json(new Inclusao().Login(login, senha));
        }

        [Compress]
        [Route("Inscreva/Esqueceu")]
        public JsonResult Esqueceu(string esqueceu)
        {
            return Json(new Inclusao().Esqueceu(esqueceu));
        }

        [Compress]
        [Route("Inscreva/Cadastro")]
        public JsonResult Cadastro(AlunoCadastrar alunoview)
        {
            return Json(new Inclusao().Cadastro(alunoview));
        }

        [Compress]
        [Route("Inscreva/CEP")]
        public JsonResult CEP(string cep)
        {
            return Json(new Inclusao().CEPNovo(cep));
        }

        [Route("Inscreva/{id}")]
        public ActionResult Formulario(string id)
        {
            Curso curso = new Curso();
            if (id.All(char.IsDigit))
            {
                curso = new CursoDB().Buscar(Convert.ToInt32(id));
            } 
            else
            {
                curso = new CursoDB().Buscar(id);
            }
            
            if (curso == null)
            {
                return RedirectToAction("Index");
            }

            Aluno_cursoDB db = new Aluno_cursoDB();
            ViewBag.qtd = db.Qtd(curso);

            return View(curso);
        }

        [Route("Inscreva/Cidade/{id}")]
        [Route("Inscreva/Curso/{id2}")]
        public ActionResult Index(int id = 0, int id2 = 0)
        {
            return View(new InscrevaView(id, id2));
        }

        [Route("Inscreva/Completar/{curso}/{aluno}")]
        public ActionResult Completar(string curso, int aluno)
        {
            Curso c = new Curso();
            if (curso.All(char.IsDigit))
            {
                c = new CursoDB().Buscar(Convert.ToInt32(curso));
            }
            else
            {
                c = new CursoDB().Buscar(curso);
            }

            //Curso c = new CursoDB().Buscar(curso);
            Aluno a = new AlunoDB().Buscar(aluno);

            if (c == null || a == null)
            {
                return RedirectToAction("index");
            }

            return View(new ContratoView(aluno, c.codigo));
        }

        [Compress]
        [Route("Inscreva/CompletarFinalizar")]
        public JsonResult CompletarFinalizar(int aluno, string cep, string endereco, string bairro, string cidade, string estado, string numero, string complemento)
        {
            return Json(new Inclusao().Completar(aluno, cep, endereco, bairro, cidade, estado, numero, complemento));
        }


        [Route("Inscreva/Contrato/{curso}/{aluno}")]
        public ActionResult Contrato(string curso, int aluno)
        {
            Curso c = new Curso();
            if (curso.All(char.IsDigit))
            {
                c = new CursoDB().Buscar(Convert.ToInt32(curso));
            }
            else
            {
                c = new CursoDB().Buscar(curso);
            }

            //Curso c = new CursoDB().Buscar(curso);
            Aluno a = new AlunoDB().Buscar(aluno);

            Aluno_cursoDB db = new Aluno_cursoDB();
            int qtd = db.Qtd(c);

            bool matriculado = new Aluno_cursoDB().MatriculadoCurso(aluno, c.codigo);

            if (matriculado)
            {
                return RedirectToAction("Matriculado/" + curso + "/" + aluno);
            }
            else
            {
                if (c == null || a == null)
                {
                    return RedirectToAction("index");
                }

                //apenas pre-matricula
                if (c.ativo == 0)
                {
                    new Inclusao().PreMatricula(c, a);
                    return RedirectToAction("PreMatricula/" + curso + "/" + aluno);
                }
                else
                {
                    if (c.vagas_esgotadas == 1)
                    {
                        new Inclusao().PreMatricula(c, a);
                        return RedirectToAction("ListaEspera/" + curso + "/" + aluno);
                    }
                    else
                    {
                        if (a.cep == "" || a.endereco == "")
                        {
                            return RedirectToAction("Completar/" + curso + "/" + aluno);
                        }
                    }

                    if (qtd >= c.total_alunos)
                    {
                        new Inclusao().PreMatricula(c, a);
                        return RedirectToAction("ListaEspera/" + curso + "/" + aluno);
                    }
                    else
                    {
                        if ((qtd + 1) == c.total_alunos)
                        {
                            new Envio_emailDB().Salvar(new Envio_email()
                            {
                                para = "pedagogico@cenbrap.com.br;marcia@cenbrap.com.br;filipe@cenbrap.com.br",
                                assunto = "Turma " + c.titulo1 + " - Limite de alunos atingido",
                                texto = "A turma " + c.titulo1 + " teve seu limite de alunos (" + c.total_alunos + ") atingido em " + DateTime.Now + ".<br>Último cadastro realizado pelo aluno(a) " + a.nome,
                                data = DateTime.Now
                            });
                        }

                        return View(new ContratoView(aluno, c.codigo));
                    }
                    
                }
            }
        }

        [Route("Inscreva/Matriculado/{curso}/{aluno}")]
        public ActionResult Matriculado(string curso, int aluno)
        {
            Curso c = new Curso();
            if (curso.All(char.IsDigit))
            {
                c = new CursoDB().Buscar(Convert.ToInt32(curso));
            }
            else
            {
                c = new CursoDB().Buscar(curso);
            }

            //Curso c = new CursoDB().Buscar(curso);
            Aluno a = new AlunoDB().Buscar(aluno);

            if (c == null || a == null)
            {
                return RedirectToAction("index");
            }

            return View(new ContratoView(aluno, c.codigo));
        }

        [Route("Inscreva/PreMatricula/{curso}/{aluno}")]
        public ActionResult PreMatricula(string curso, int aluno)
        {
            Curso c = new Curso();
            if (curso.All(char.IsDigit))
            {
                c = new CursoDB().Buscar(Convert.ToInt32(curso));
            }
            else
            {
                c = new CursoDB().Buscar(curso);
            }
            //Curso c = new CursoDB().Buscar(curso);
            Aluno a = new AlunoDB().Buscar(aluno);

            if (c == null || a == null)
            {
                return RedirectToAction("index");
            }

            return View(new ContratoView(aluno, c.codigo));
        }

        [Route("Inscreva/ListaEspera/{curso}/{aluno}")]
        public ActionResult ListaEspera(string curso, int aluno)
        {
            Curso c = new Curso();
            if (curso.All(char.IsDigit))
            {
                c = new CursoDB().Buscar(Convert.ToInt32(curso));
            }
            else
            {
                c = new CursoDB().Buscar(curso);
            }

            //Curso c = new CursoDB().Buscar(curso);
            Aluno a = new AlunoDB().Buscar(aluno);

            if (c == null || a == null)
            {
                return RedirectToAction("index");
            }

            return View(new ContratoView(aluno, c.codigo));
        }

        [Compress]
        [HttpPost]
        [Route("Inscreva/Boleto")]
        public JsonResult Boleto(int id, int curso = 0, string cupom = "")
        {
            Retorno retorno = new Retorno();

            Curso c;

            if (curso == 0)
                c = new CursoDB().Buscar(300);
            else
                c = new CursoDB().Buscar(curso);

            Aluno aluno = new AlunoDB().Buscar(id);

            if (aluno == null)
            {
                retorno.erro = true;
                retorno.mensagem = "Não foi possível localizar o aluno.";
            }
            else
            {
                retorno = new Inclusao().Incluir(c, aluno, 3, cupom: cupom);
            }

            return Json(retorno);
        }

       [Compress]
        [HttpPost]
        [Route("Inscreva/Cartao")]
        public JsonResult Cartao(int id, int curso = 0)
        {
            Retorno retorno = new Retorno();

            Curso c;

            if (curso == 0)
                c = new CursoDB().Buscar(300);
            else
                c = new CursoDB().Buscar(curso);

            Aluno aluno = new AlunoDB().Buscar(id);

            if (aluno == null)
            {
                retorno.erro = true;
                retorno.mensagem = "Não foi possível localizar o aluno.";
            }
            else
            {
                retorno = new Inclusao().Incluir(c, aluno, 5);
            }

            return Json(retorno);
        }

        [Compress]
        [HttpPost]
        [Route("Inscreva/Pagseguro")]
        public JsonResult Pagseguro(int id, int curso = 0)
        {
            Retorno retorno = new Retorno();

            Curso c;

            if (curso == 0)
                c = new CursoDB().Buscar(300);
            else
                c = new CursoDB().Buscar(curso);

            Aluno aluno = new AlunoDB().Buscar(id);

            if (aluno == null)
            {
                retorno.erro = true;
                retorno.mensagem = "Não foi possível localizar o aluno.";
            }
            else
            {
                retorno = new Inclusao().Incluir(c, aluno, 9);
            }

            return Json(retorno);
        }

        [Compress]
        [Route("Inscreva/CupomDesconto")]
        public JsonResult CupomDesconto(string cupom = "", int aluno = 0)
        {
            int r = 0;
            if (cupom == "#PPP2019")
            {
                var b = new CupomDesconto_utilizacaoDB().CupomUtilizado(aluno, 145);
                if (b)
                {
                    r = 2;
                }
                else
                {
                    r = 1;
                }

            }
            return Json(r);
        }

    }
}
