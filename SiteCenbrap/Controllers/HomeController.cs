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
    public class HomeController : OrigemController
    {
        public ActionResult Index()
        {
            ViewBag.description = "Não deixe o futuro simplesmente passar por você. Reconhecido pelo MEC · Professores renomados · Ligamos para você";
            return View(new InicialView());
        }

        public ActionResult Formulario()
        {
            return PartialView();
        }

        public ActionResult Noticias()
        {
            return View(new NoticiaDB().Listar("cenbrap.com.br", 50));
        }

        public JsonResult Newsletter(string email)
        {
            NewsletterDB db = new NewsletterDB();
            Biblioteca.Entidades.Newsletter news = db.Buscar(email);
            if (news == null)
            {
                new Newsletter() { email = email }.Salvar();
                news = db.Buscar(email);
            }

            new Newsletter_navegacao(news, Cookies_ga(), DateTime.Now).Salvar();

            return Json(new Retorno());
        }

        public JsonResult Ligamos(string nome, string email, string telefone)
        {
            new Envio_email() { para = "marcia@cenbrap.com.br", assunto = "Solicitou ligação - Cenbrap", texto = "Nome: " + nome + "<BR>E-mail: " + email + "<BR>Telefone: " + telefone + "<BR><BR>Solicitou entrar em contato por telefone." }.Salvar();

            NewsletterDB db = new NewsletterDB();
            Biblioteca.Entidades.Newsletter news = db.Buscar(email);
            if (news == null)
            {
                new Newsletter() { email = email, nome = nome, telefone = telefone }.Salvar();
                news = db.Buscar(email);
            }

            new Newsletter_navegacao(news, Cookies_ga(), DateTime.Now).Salvar();

            return Json(new Retorno());
        }

        public JsonResult Contato(string nome, string email, string telefone, string mensagem)
        {
            new Envio_email() { para = "marcia@cenbrap.com.br", assunto = "Solicitou ligação - Cenbrap", texto = "Nome: " + nome + "<BR>E-mail: " + email + "<BR>Telefone: " + telefone + "<BR>Mensagem: " + mensagem + "<BR><BR>Solicitou entrar em contato por telefone." }.Salvar();
            return Json(new Retorno());
        }

        [Route("Descadastrar/")]
        [Route("Descadastrar/{key}/")]
        public ActionResult Descadastrar(string key)
        {
            /*key = "NVSW4ZDBNZUGCQDIN52G2YLJNQXGG33NEM2TE"; Chave aluno Marcello (Teste)*/
            string decrypt = "";
            string email = "";
            int campanha = 0;
            if (key != null)
            {
                decrypt = System.Text.Encoding.Default.GetString(Crypt.Decode(key));
                if (decrypt.LastIndexOf("#") > 0)
                {
                    email = decrypt.Substring(0, decrypt.LastIndexOf("#"));
                    campanha = Convert.ToInt32(decrypt.Substring(decrypt.LastIndexOf("#") + 1));
                }

            }
            return View(new DescadastrarView(campanha, email));
        }

        [HttpPost]
        //[Compress]
        public JsonResult DescadastrarGravar(FormCollection collection)
        {
            int idcampanha = Convert.ToInt32(collection["idcampanha"]);
            int idaluno = Convert.ToInt32(collection["idaluno"]);
            foreach (var s in collection)
            {
                if (Convert.ToString(s) == "mail_todos")
                {
                    Aluno aluno = new AlunoDB().Buscar(idaluno);
                    aluno.envio_email = Convert.ToInt32(collection["mail_todos"]);
                    aluno.Alterar();
                }
                else
                {
                    if (Convert.ToString(s).Substring(0, 4) == "chk_")
                    {
                        Aluno_curso aluno_curso = new Aluno_cursoDB().Buscar(Convert.ToInt32(Convert.ToString(s).Replace("chk_", "")));
                        aluno_curso.envio_email = Convert.ToInt32(collection[Convert.ToString(s)]);
                        aluno_curso.Alterar();
                    }
                }
            }

            //Verifica se já existe gravado o descadastramento para este aluno/curso
            bool existe = false;
            existe = new CampanhasDB().DescadastrarBusca(idcampanha, idaluno);
            if (!existe)
            {
                new CampanhasDB().Descadastrar(idcampanha, idaluno);
            }

            return Json(new Retorno());
        }

        public JsonResult Form(int tipo = 0, int cidade = 0, int curso = 0)
        {
            return Json(new Busca(tipo, cidade, curso));
        }

        [Route("FaleConosco/")]
        [Route("Home/FaleConosco/")]
        public ActionResult FaleConosco()
        {
            List<string> Cursos = new List<string>();
            foreach(var c in new Titulo_cursoDB().Listar())
            {
                Cursos.Add(c.titulo);
            }
            ViewBag.Cursos = Cursos;

            return View(new PaginasDB().Buscar(7));
        }

        public JsonResult FaleConoscoEnviar(string nome, string email, string telefone, string curso, string cidade, string assunto, string texto)
        {
            new Envio_email() { para = "contato@cenbrap.com.br", assunto = "Contato pelo Site - Cenbrap", texto = "Nome: " + nome + "<BR>E-mail: " + email + "<BR>Telefone: " + telefone + "<BR>Curso: " + curso + "<BR>Cidade: " + cidade + "<BR>Assunto: " + assunto + "<BR>Texto: " + texto + "<BR><BR>Solicitou entrar em contato por telefone." }.Salvar();
            return Json(new Retorno());
        }

        [Route("Localizacao/")]
        [Route("Home/Localizacao/")]
        public ActionResult Localizacao()
        {
            return View(new InicialView());
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Recesso()
        {
            return View();
        }

        [Route("Comunicado/")]
        [Route("Home/Comunicado/")]
        public ActionResult Comunicado(string turma = "", int aluno = 0)
        {
            Aluno al = new AlunoDB().Buscar(aluno);
            Curso curso = new CursoDB().Buscar(turma);
            Comunicado comunicado = new ComunicadoDB().Buscar(curso.codigo, aluno);

            ViewBag.form = comunicado;

            if ((al != null) && (curso != null))
            {
                Aluno_curso aluno_curso = new Aluno_cursoDB().Buscar(curso, al);
                Curso_adiamento adiamento = new Curso_adiamentoDB().Ultimo(curso);
                Titulo_curso titulo = new Titulo_cursoDB().Buscar(curso.titulo_curso.codigo);

                if (aluno_curso != null) {
                    ViewBag.turma = curso.titulo;
                    ViewBag.codturma = curso.codigo;
                    ViewBag.aluno = al.nome;
                    ViewBag.codaluno = aluno;
                    ViewBag.adiamento = adiamento.para;
                    ViewBag.titulo = titulo.titulo;
                    ViewBag.cursos = new CursoDB().CursosHome(0, 0, 0);
                }
            }

            return View();
        }

        [Compress]
        [Route("Home/ComunicadoFinalizar")]
        public JsonResult ComunicadoFinalizar(int tipo, int curso, string dados, string turma, int aluno)
        {
            Comunicado comunicado = new Comunicado();
            comunicado.turma = turma;
            comunicado.aluno = aluno;
            comunicado.tipo = tipo;
            comunicado.novocurso = curso;
            comunicado.dados = dados;
            comunicado.Salvar();
            string result = "Informações gravadas com sucesso";

            Aluno al = new AlunoDB().Buscar(aluno);
            Curso cur = new CursoDB().Buscar(curso);
            Curso cur2 = new CursoDB().Buscar(Convert.ToInt32(turma));
            Curso_adiamento adiamento = new Curso_adiamentoDB().Ultimo(cur2);

            ContaEnvio contaEnvio = new ContaEnvio(1, "Cenbrap", "contato@cenbrap.com.br", "contato@cenbrap.com.br", "databenq206");
            EnviarEmail e = new EnviarEmail();
            string para = "contato@cenbrap.com.br";
            string assunto = "Comunicado CENBRAP - Formulário de adiamento de turma";
            string msg = "";

            msg += "Comunicado CENBRAP - Envio automático do formulário de adiamento de turma<br><br>Prezado(a) Aluno(a);<br><br>A Coordenação Pedagógica do Cenbrap procederá à seguinte alteração no seu cadastro, conforme sua autorização descrita abaixo.<br><br><strong>";
            msg += "TURMA: " + cur2.titulo + " - " + cur2.titulo1;
            msg += "<br>ALUNO: " + al.nome;
            msg += "<br>E-MAIL: " + al.email;
            if (tipo == 1)
            {
                msg += "<br>OPÇÃO: Quero continuar";
                msg += "<br><span style='background-color: yellow;'>NOVA DATA PREVISTA: " + adiamento.para.ToShortDateString() + "</span>";
            }
            if (tipo == 2)
            {
                msg += "<br>OPÇÃO: Quero mudar de turma/curso";
                msg += "<br>NOVA TURMA: " + cur.titulo + " - " + cur.titulo1;
            }
            if (tipo == 3)
            {
                msg += "<br>OPÇÃO: Quero meu dinheiro de volta";
                msg += "<br>DADOS: " + dados;
            }
            if (tipo == 4)
            {
                msg += "<br>OPÇÃO: Quero converter minha matrícula em assinatura do Medtv por 18 meses";
            }
            msg += "</strong><br><Br>Qualquer dúvida, entre em contato conosco.<br>Att,<br>Márcia Barros<br>Assessoria de Comunicação";

            string r = e.EnviaMensagemEmail(para, assunto, msg, 0, contaEnvio, false);
            string r2 = e.EnviaMensagemEmail(al.email, assunto, msg, 0, contaEnvio, false);

            return Json(result);
        }

        [Route("Cancelamento/")]
        [Route("Home/Cancelamento/")]
        public ActionResult Cancelamento(string turma = "", int aluno = 0)
        {
            Aluno al = new AlunoDB().Buscar(aluno);
            Curso curso = new CursoDB().Buscar(turma);
            Comunicado comunicado = new ComunicadoDB().Buscar(curso.codigo, aluno);

            ViewBag.form = comunicado;

            if ((al != null) && (curso != null))
            {
                Aluno_curso aluno_curso = new Aluno_cursoDB().Buscar(curso, al);
                Curso_adiamento adiamento = new Curso_adiamentoDB().Ultimo(curso);
                Titulo_curso titulo = new Titulo_cursoDB().Buscar(curso.titulo_curso.codigo);

                if (aluno_curso != null)
                {
                    ViewBag.turma = curso.titulo;
                    ViewBag.codturma = curso.codigo;
                    ViewBag.aluno = al.nome;
                    ViewBag.codaluno = aluno;
                    if (adiamento != null)
                    {
                        ViewBag.adiamento = adiamento.para;
                    }
                    ViewBag.titulo = titulo.titulo;
                    ViewBag.cursos = new CursoDB().CursosHome(0, 0, 0);
                }
            }

            return View();
        }

        [Compress]
        [Route("Home/CancelamentoFinalizar")]
        public JsonResult CancelamentoFinalizar(int tipo, int curso, string dados, string turma, int aluno)
        {
            Comunicado comunicado = new Comunicado();
            comunicado.turma = turma;
            comunicado.aluno = aluno;
            comunicado.tipo = tipo;
            comunicado.novocurso = curso;
            comunicado.dados = dados;
            comunicado.Salvar();
            string result = "Informações gravadas com sucesso";

            Aluno al = new AlunoDB().Buscar(aluno);
            Curso cur = new CursoDB().Buscar(curso);
            Curso cur2 = new CursoDB().Buscar(Convert.ToInt32(turma));

            ContaEnvio contaEnvio = new ContaEnvio(1, "Cenbrap", "contato@cenbrap.com.br", "contato@cenbrap.com.br", "databenq206");
            EnviarEmail e = new EnviarEmail();
            string para = "contato@cenbrap.com.br";
            string assunto = "Comunicado CENBRAP - Formulário de cancelamento de turma";
            string msg = "";

            msg += "Comunicado CENBRAP - Envio automático do formulário de cancelamento de turma<br><br>Prezado(a) Aluno(a);<br><br>A Coordenação Pedagógica do Cenbrap procederá à seguinte alteração no seu cadastro, conforme sua autorização descrita abaixo.<br><br><strong>";
            msg += "TURMA: " + cur2.titulo + " - " + cur2.titulo1;
            msg += "<br>ALUNO: " + al.nome;
            if (tipo == 2)
            {
                msg += "<br>OPÇÃO: Quero mudar de turma/curso";
                msg += "<br>NOVA TURMA: " + cur.titulo + " - " + cur.titulo1;
            }
            if (tipo == 3)
            {
                msg += "<br>OPÇÃO: Quero meu dinheiro de volta";
                msg += "<br>DADOS: " + dados;
            }
            if (tipo == 4)
            {
                msg += "<br>OPÇÃO: Quero converter minha matrícula em assinatura do Medtv por 18 meses";
            }
            msg += "</strong><br><Br>Qualquer dúvida, entre em contato conosco.<br>Att,<br>Márcia Barros<br>Assessoria de Comunicação";

            string r = e.EnviaMensagemEmail(para, assunto, msg, 0, contaEnvio, false);
            string r2 = e.EnviaMensagemEmail(al.email, assunto, msg, 0, contaEnvio, false);

            return Json(result);
        }

        [Compress]
        public ActionResult Mapa(int tamanho = 500)
        {
            ConfigSite config = new ConfigSiteDB().Buscar("cenbrap.com.br");
            if (config != null)
            {
                var path = Path.Combine(config.imagem);

                Image i = Image.FromFile(path);
                return new ImageResult(i, tamanho);
            }
            else
            {
                return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
            }
        }

        [Compress]
        [Route("ComunicadoUrgente/")]
        public ActionResult ComunicadoUrgente()
        {
            ViewBag.description = "Não deixe o futuro simplesmente passar por você. Reconhecido pelo MEC · Professores renomados · Ligamos para você";
            return View();
        }

        [Compress]
        public ActionResult BannerImg(int id)
        {
            if (HttpContext.Request.Url.Host == "localhost")
            {
                return null;
            }
            else
            {

                Banners banner = new BannersDB().Buscar(id);

                if (banner != null)
                {
                    var path = Path.Combine(@"C:\inetpub\wwwroot\sistema.cenbrap.com.br\App_Data\", banner.txfoto);

                    Image i = Image.FromFile(path);
                    return new ImageResult(i);
                }
                else
                {
                    return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
                }
            }
        }

        [Route("Visualizar/")]
        [Route("Visualizar/{key}/")]
        public ActionResult Visualizar(string key)
        {
            Curso curso = null;
            curso = new CursoDB().Buscar(key);
            if (curso != null)
            {
                return View(new CursoView(curso));
            }
            else
            {
                return RedirectToAction("Index");
            }           

        }

    }
}