using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteCenbrap.Models;
using Biblioteca.Filters;
using System.IO;
using System.Drawing;
using Biblioteca.Funcoes;

namespace SiteCenbrap.Controllers
{
    public class CursosController : OrigemController
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("PosGraduacoes/")]
        [Route("Cursos/PosGraduacoes/")]
        public ActionResult PosGraduacoes()
        {
            return View(new PosGraduacoesView());
        }
        
        [Route("Workshops/")]
        [Route("Cursos/Workshops/")]
        public ActionResult Workshops()
        {
            return View(new WorkshopView());
        }

        [Route("Ead/")]
        [Route("Cursos/Ead/")]
        public ActionResult Ead()
        {
            return View(new EadView());
        }

        //Curso especifico ..... exemplo Psiquiatria / MedicinadoTrabalho
        [Route("Cursos/{link}/")]
        public ActionResult Cursos(string link)
        {
            return View(new CursosView(link));
        }

        [Route("Turma/{link}/")]
        [Route("Curso/{id}/")]
        public ActionResult Curso(string link = "", int id = 0)
        {
            Curso curso = null;

            if (link != "")
                curso = new CursoDB().Buscar(link);

            if (id != 0)
                curso = new CursoDB().Buscar(id);

            if (curso != null)
                return View(new CursoView(curso));
            else
                return RedirectToAction("Index", "Home");
        }

        [Route("Cidades/{link}/")]
        [Route("Cidade/{id}/")]
        public ActionResult Cidade(int id = 0, string link = "")
        {
            if(link != "")
                return View(new CidadeView(new CidadeDB().Buscar(link)));
            else
                return View(new CidadeView(new CidadeDB().Buscar(id)));
        }

        [Route("Professor/{id}/")]
        public ActionResult Professor(int id = 0)
        {
            return PartialView(new Titulo_curso_professorDB().Buscar(id));
        }
        
        [Compress]
        public ActionResult foto(int id, int tamanho = 500)
        {
            Titulo_curso_professor t = new Titulo_curso_professorDB().Buscar(id);
            if (t != null)
            {
                if (t.foto.IndexOf(".") > 0)
                {
                    var path = Path.Combine(t.foto);

                    Image i = Image.FromFile(path);
                    return new ImageResult(i, tamanho);
                }

            }
            return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
        }

        [Compress]
        public ActionResult banner(int id, int tamanho = 500)
        {
            Titulo_curso_banner t = new Titulo_curso_bannerDB().Buscar(id);
            if (t != null)
            {
                var path = Path.Combine(t.imagem);

                if (System.IO.File.Exists(path))
                {
                    Image i = Image.FromFile(path);
                    return new ImageResult(i, tamanho);
                }
                else
                {
                    return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
                }
                    
            }
            else
            {
                return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
            }
        }

        //ALTERAÇÕES PARA NOVO PADRÃO DE LINK

        [Route("Turma/{id}/Inscreva")]
        [Route("Curso/{id}/Inscreva")]
        public ActionResult Inscreva(string id)
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

        [Route("Turma/{curso}/Contrato/{aluno}")]
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
                return RedirectToAction("Turma/" + curso + "/Matriculado/" + aluno);
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
                    return RedirectToAction("Turma/" + curso + "/PreMatricula/" + aluno);
                }
                else
                {
                    if (c.vagas_esgotadas == 1)
                    {
                        new Inclusao().PreMatricula(c, a);
                        return RedirectToAction("Turma/" + curso + "/ListaEspera/" + aluno);
                    }
                    else
                    {
                        if (a.cep == "" || a.endereco == "")
                        {
                            return RedirectToAction("Turma/" + curso + "/Completar /" + aluno);
                        }
                    }

                    if (qtd >= c.total_alunos)
                    {
                        new Inclusao().PreMatricula(c, a);
                        return RedirectToAction("Turma/" + curso + "/ListaEspera/" + aluno);
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

        [Route("Turma/{curso}/Completar/{aluno}")]
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

        [Route("Turma/{curso}/Matriculado/{aluno}")]
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

        [Route("Turma/{curso}/PreMatricula/{aluno}")]
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

        [Route("Turma/{curso}/ListaEspera/{aluno}")]
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

    }
}