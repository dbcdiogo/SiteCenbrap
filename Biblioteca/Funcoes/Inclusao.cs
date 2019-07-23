using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.Funcoes;
using Biblioteca.DB;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace Biblioteca.Funcoes
{
    public class Inclusao
    {
        public Retorno Incluir(Curso curso, Aluno aluno, int forma_pgto = 3, bool enviar = true, string cupom = "", bool pagImprimirBoleto = false)
        {
            Retorno retorno = new Retorno();

            Aluno_cursoDB db = new Aluno_cursoDB();
            
            int qtd = db.Qtd(curso);

            if(qtd > curso.total_alunos)
            {
                retorno.erro = true;
                retorno.mensagem = "Todas as vagas foram preenchidas.";
            }
            else
            {
                Aluno_curso ac = new Aluno_curso();
                ac = db.Buscar(curso, aluno);
                if(ac == null)
                {
                    ac = new Aluno_curso()
                    {
                        aluno = aluno,
                        curso = curso,
                        adesao = DateTime.Now
                    };
                    ac.Salvar();
                }

                bool possuiCupom = false;

                if(cupom.Length >= 6)
                {
                    CupomDesconto cd = new CupomDescontoDB().Buscar(cupom);
                    if(cd != null)
                    {
                        possuiCupom = true;
                        CupomDesconto_utilizacao cdu = new CupomDesconto_utilizacao(0, cd, aluno, DateTime.Now, curso.codigo);
                        cdu.Salvar();
                    }
                }

                //verifica se tem data limite e se tiver, pega o valor da matricula1
                if (curso.data_limite1 > Convert.ToDateTime("01/01/2000"))
                {
                    if (curso.data_limite1 >= DateTime.Now)
                        curso.matricula = curso.matricula1;
                }

                //Verifica se é para adicionar a primeira mensalidade
                if (curso.pgto_1parcela == 1)
                    curso.matricula += curso.valor / curso.qtd_parcelas;

                if (curso.matricula == 0)
                    curso.matricula = curso.valor;

                //se for jornada e assinante MEDTV
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                if ((url.IndexOf("psiquiatriaocupacional") > -1) || (url.IndexOf("congressomedicina") > -1))
                {
                    //verifica se tem cupom de desconto
                    if (possuiCupom && DateTime.Now <= Convert.ToDateTime("25/06/2018"))
                    {
                        curso.matricula = 770;
                    }

                    if (new Aluno_MedTVDB().Ativo(aluno))
                    {
                        curso.matricula = Convert.ToDecimal(Convert.ToDouble(curso.matricula) * 0.95);
                        curso.matricula1 = Convert.ToDecimal(Convert.ToDouble(curso.matricula1) * 0.95);
                    }
                }

                //verifica se tem cupom de desconto para pos
                if (possuiCupom && curso.tipo == 0)
                {                    
                    curso.matricula = Convert.ToDecimal(Convert.ToDouble(curso.matricula) * 0.80);
                }

                Aluno_pgto ap = new Aluno_pgto();

                ap = new Aluno_pgtoDB().Buscar(ac);

                if(ap == null)
                {
                    ap = new Aluno_pgto()
                    {
                        aluno = aluno,
                        curso = curso,
                        aluno_curso = ac,
                        data = DateTime.Now,
                        data_gerado = DateTime.Now,
                        forma_pgto = forma_pgto,
                        total = (double)curso.matricula,
                        total_parcelas = curso.qtd_parcelas,
                        matricula = (double)curso.matricula,
                        vencimento = Vencimento(DateTime.Now.AddDays(2)),
                        parcela = 1
                    };

                    ap.Salvar();
                    ap.codigo = new Aluno_pgtoDB().Buscar(ac).codigo;
                }
                else
                {
                    if(ap.vencimento < DateTime.Now && pagImprimirBoleto)
                    {
                        retorno.link = "https://www.cenbrap.com.br/Inscreva/Contrato/"+curso.codigo+"/"+aluno.codigo;
                        return retorno;
                    }

                    ap.data = DateTime.Now;
                    ap.data_gerado = DateTime.Now;
                    ap.total = (double)curso.matricula;
                    ap.total_parcelas = curso.qtd_parcelas;
                    ap.matricula = (double)curso.matricula;
                    ap.vencimento = Vencimento(DateTime.Now.AddDays(2));
                    ap.forma_pgto = forma_pgto;

                    ap.Alterar();
                }
                
                retorno.valor = ap.matricula;
                retorno.id = ap.codigo;

                #region "Boleto Bancário"
                if (forma_pgto == 3)
                {
                    Boleto boleto = new Boleto()
                    {
                        //conta = 6,
                        conta = 8,
                        data = DateTime.Now,
                        valor = ap.matricula,
                        vencimento = ap.vencimento,
                        instrucoes = "Sr(a). Caixa nao receber apos o vencimento<br><br>Inscricao: " + curso.titulo + "",
                        aluno_pgto = ap
                    };

                    //Verifica se tem boleto e se ele ainda está dentro da data de vencimento se tiver utiliza o mesmo número
                    int boleto_codigo = new BoletoDB().BuscarVencimento(ap);
                    if (boleto_codigo == 0)
                    {
                        boleto.Salvar();
                    }
                    else
                    {
                        boleto.codigo = boleto_codigo;
                        //boleto.Salvar();
                    }

                    retorno.link = "https://boleto.cenbrap.com.br/boleto/?id=" + boleto.codigo;

                    if ((enviar) && (!possuiCupom))
                    {
                        Email_tipo et = new Email_tipoDB().Buscar(curso.tipo, "Inscricao-boleto");

                        string txt = "";
                        string assunto = "";
                        string link_boleto = "";

                        //se for o pre-curso
                        if (curso.codigo == 355)
                        {
                            assunto = "Boleto - " + curso.titulo;
                            txt = "<strong>Ol&aacute; " + aluno.nome + "</strong><BR><BR>Ser&aacute; um prazer receb&ecirc;-lo(a) no nosso curso Pré-Congresso sobre 'Transtornos Mentais Relacionados ao Trabalho'.<BR><BR>Forma de Pagamento:Boleto Banc&aacute;rio<BR><BR><a href='https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/'><span style='color:#006;'>Clique aqui</span> para gerar o boleto bancário com vencimento em " + ap.vencimento.ToShortDateString() + ".</a><BR><BR>Lembramos que sua inscri&ccedil;&atilde;o somente ser&aacute; confirmada  ap&oacute;s realiza&ccedil;&atilde;o do pagamento.<BR><BR>Estamos &agrave; disposi&ccedil;&atilde;o para eventuais esclarecimentos.<BR><BR>Atenciosamente,<BR><BR>Congresso Brasileiro de Medicina do Trabalho e Perícias Médicas<br /><br /><span style='font-size: 8pt;'><span style='color: #808080;'><strong>Fernando Silva Tiago |&nbsp; </strong></span><span style='color: #808080;'><span style='color: #888888;'><em>Assessoria de Comunicação</em></span></span></span><br /> <span style='margin-top: 0px; margin-bottom: 0px;'><span style='font-size: 8pt;'><span style='color: #888888;'>0300 313 1538</span>";
                            link_boleto = "https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/";
                        }
                        else
                        {
                            if (curso.codigo == 391)
                            {
                                assunto = "Boleto - www.psiquiatriaocupacional.com.br";
                                txt = "<strong>Ol&aacute; " + aluno.nome + "</strong><BR><BR>Ser&aacute; um prazer receb&ecirc;-lo(a) no nosso curso Pré-Congresso sobre 'Exame Psíquico'.<BR><BR>Forma de Pagamento:Boleto Banc&aacute;rio<BR><BR><a href='https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/'><span style='color:#006;'>Clique aqui</span> para gerar o boleto bancário com vencimento em " + ap.vencimento.ToShortDateString() + ".</a><BR><BR>Lembramos que sua inscri&ccedil;&atilde;o somente ser&aacute; confirmada  ap&oacute;s realiza&ccedil;&atilde;o do pagamento.<BR><BR>Estamos &agrave; disposi&ccedil;&atilde;o para eventuais esclarecimentos.<BR><BR>Atenciosamente,<BR><BR>Congresso Brasileiro de Medicina do Trabalho e Perícias Médicas<br /><br /><span style='font-size: 8pt;'><span style='color: #808080;'><strong>Fernando Silva Tiago |&nbsp; </strong></span><span style='color: #808080;'><span style='color: #888888;'><em>Assessoria de Comunicação</em></span></span></span><br /> <span style='margin-top: 0px; margin-bottom: 0px;'><span style='font-size: 8pt;'><span style='color: #888888;'>0300 313 1538</span>";
                                link_boleto = "https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/";
                            }
                            else
                            {
                                if (et == null)
                                {
                                    assunto = "Boleto - " + curso.titulo;
                                    txt = "<strong>Ol&aacute; " + aluno.nome + "</strong><BR><BR>Ser&aacute; um prazer receb&ecirc;-lo(a) no " + curso.titulo + ".<BR><BR>Forma de Pagamento:Boleto Banc&aacute;rio<BR><BR><a href='https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/'><span style='color:#006;'>Clique aqui</span> para gerar o boleto bancário com vencimento em " + ap.vencimento.ToShortDateString() + ".</a><BR><BR>Lembramos que sua inscri&ccedil;&atilde;o somente ser&aacute; confirmada  ap&oacute;s realiza&ccedil;&atilde;o do pagamento.<BR><BR>Estamos &agrave; disposi&ccedil;&atilde;o para eventuais esclarecimentos.<BR><BR>Atenciosamente,<BR><BR>" + curso.titulo + "<br /><br /><span style='font-size: 8pt;'><span style='color: #808080;'><strong>Fernando Silva Tiago |&nbsp; </strong></span><span style='color: #808080;'><span style='color: #888888;'><em>Assessoria de Comunicação</em></span></span></span><br /> <span style='margin-top: 0px; margin-bottom: 0px;'><span style='font-size: 8pt;'><span style='color: #888888;'>0300 313 1538</span>";
                                    link_boleto = "https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/";
                                }
                                else
                                {
                                    assunto = et.assunto;
                                    txt = et.texto;

                                    if (curso.codigo == 374)
                                    {
                                        assunto = assunto.Replace("congressomedicina", "psiquiatriaocupacional");
                                        txt = txt.Replace("congressomedicina", "psiquiatriaocupacional");
                                        //txt = txt.Replace("nosso Congresso", "nossa Jornada");
                                        txt = txt.Replace("Medicina do Trabalho e Perícias Médicas", "Psiquiatria Ocupacional");
                                    }

                                    if (txt.IndexOf("#TITULOCURSO#") > 0)
                                        txt = txt.Replace("#TITULOCURSO#", curso.titulo);

                                    if (txt.IndexOf("#NOMEALUNO#") > 0)
                                        txt = txt.Replace("#NOMEALUNO#", aluno.nome);

                                    if (txt.IndexOf("#VENCIMENTOBOLETO#") > 0)
                                        txt = txt.Replace("#VENCIMENTOBOLETO#", ap.vencimento.ToShortDateString());

                                    if (txt.IndexOf("#URLBOLETO#") > 0)
                                        txt = txt.Replace("#URLBOLETO#", "https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/");
                                    link_boleto = "https://www.cenbrap.com.br/ImprimirBoleto/" + curso.codigo + "/" + aluno.codigo + "/";
                                }
                            }
                        }

                        
                        //Verificar primeiro se já foi enviado esse e-mail para o aluno nas últimas 24h
                        if(!new Envio_emailDB().Existe(aluno.email, assunto, link_boleto))
                        {
                            new Envio_emailDB().Salvar(new Envio_email()
                            {
                                data = DateTime.Now,
                                assunto = assunto,
                                texto = txt,
                                para = aluno.email
                            });
                        }
                        
                    }
                    else
                    {
                        retorno.id = boleto.codigo;
                    }
                }
                #endregion

                #region "Cartão Cielo"
                if (forma_pgto == 5)
                {
                    ap.curso = new CursoDB().Buscar(ap.curso.codigo);
                    ap.aluno = new AlunoDB().Buscar(ap.aluno.codigo);

                    string txt_curso = ap.curso.Tipo() + ": " + ap.curso.titulo;

                    if (txt_curso.Length > 128)
                        txt_curso = txt_curso.Substring(0, 128);

                    string telefone = ap.aluno.ddd + ap.aluno.telefone;
                    telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace(",", "").Replace("(", "");

                    if (telefone.Length > 11)
                        telefone = telefone.Substring(0, 11);

                    while (telefone.Length < 10)
                        telefone = "0" + telefone;

                    ap.aluno_curso.AbriuCartao();

                    retorno.link = new IntegrarCielo().Gerar(ap.codigo, ap.matricula, txt_curso, ap.aluno.nome, ap.aluno.cpf, ap.aluno.email, telefone);
                }
                #endregion

                #region "Recorrencia Cielo"
                if (forma_pgto == 9)
                {
                    ap.curso = new CursoDB().Buscar(ap.curso.codigo);
                    ap.aluno = new AlunoDB().Buscar(ap.aluno.codigo);

                    string txt_curso = ap.curso.Tipo() + ": " + ap.curso.titulo;

                    if (txt_curso.Length > 128)
                        txt_curso = txt_curso.Substring(0, 128);

                    string telefone = ap.aluno.ddd + ap.aluno.telefone;
                    telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace(",", "").Replace("(", "");

                    if (telefone.Length > 11)
                        telefone = telefone.Substring(0, 11);

                    while (telefone.Length < 10)
                        telefone = "0" + telefone;

                    ap.aluno_curso.AbriuCartao();

                    retorno.link = new PagamentoPagseguroCenbrap().Pagamento(ap);
                }
                #endregion

            }

            return retorno;
        }

        public void PreMatricula(Curso curso, Aluno aluno)
        {
            Aluno_cursoDB db = new Aluno_cursoDB();

            Aluno_curso ac = db.Buscar(curso, aluno);
            if (ac == null)
            {
                ac = new Aluno_curso()
                {
                    aluno = aluno,
                    curso = curso,
                    adesao = DateTime.Now
                };
                ac.Salvar();
            }
        }

        public Retorno Login(string login, string senha, bool entrar = false)
        {
            Retorno retorno = new Retorno();

            if(login.Length > 2 && senha.Length > 2)
            {
                Aluno aluno = new AlunoDB().Buscar(login, senha);

                if (aluno == null)
                {
                    retorno.retorno = 0;
                    retorno.mensagem = "Dados incorretos.";
                }
                else
                {
                    if (entrar)
                        CookiesPortal(aluno.codigo);

                    if(aluno.cep == "" || aluno.endereco == "" || aluno.cidade == "" || aluno.estado == "" || aluno.flcorrecao == 0)
                    {
                        retorno.retorno = 2;
                        retorno.id = aluno.codigo;
                        retorno.link = aluno.email;
                    }
                    else
                    {
                        retorno.retorno = 1;
                        retorno.id = aluno.codigo;
                        retorno.link = aluno.email;
                    }
                    retorno.mensagem = "Redirecionando...";

                    string _ga = Cookies_ga();
                    if(_ga != null && _ga != "")
                    {
                        new Aluno_navegacaoDB().Existe(aluno, _ga);
                    }
                        
                }
            }
            else
            {
                retorno.retorno = 0;
                retorno.mensagem = "Dados incorretos.";
            }
            
            return retorno;

        }

        public Retorno LoginMedTV(string email, string senha, int lembrar, bool entrar = false)
        {
            Retorno retorno = new Retorno();

            if (email.Length > 2 && senha.Length > 2)
            {
                Aluno aluno = new AlunoDB().BuscarMedTV(email, senha);

                if (aluno == null)
                {
                    retorno.retorno = 0;
                    retorno.mensagem = "Dados incorretos.";
                }
                else
                {
                    if(new Aluno_MedTVDB().Ativo(aluno))
                    {
                        if (entrar)
                            CookiesMedTV(aluno.codigo, lembrar);

                        retorno.retorno = 1;
                        retorno.id = aluno.codigo;
                        retorno.mensagem = "Redirecionando...";

                        string _ga = Cookies_ga();
                        if (_ga != null && _ga != "")
                            new Aluno_navegacaoDB().Existe(aluno, _ga);
                    }
                    else
                    {
                        if (entrar)
                            CookiesMedTVAtivar(aluno.codigo);

                        retorno.retorno = 2;
                        retorno.id = aluno.codigo;
                        retorno.mensagem = "Ativar";
                    }
                    
                }
            }
            else
            {
                retorno.retorno = 0;
                retorno.mensagem = "Dados incorretos.";
            }

            return retorno;

        }

        public Retorno Esqueceu(string esqueceu)
        {
            Retorno retorno = new Retorno();

            if (esqueceu.Length > 2)
            {
                Aluno aluno = new AlunoDB().Email(esqueceu);

                if (aluno == null)
                {
                    retorno.retorno = 0;
                    retorno.mensagem = "Dados incorretos.";
                }
                else
                {
                    retorno.retorno = 1;
                    retorno.id = aluno.codigo;
                    new Envio_email() {
                        para = aluno.email,
                        assunto = "Dados de acesso - Cenbrap",
                        texto = "Segue os dados de acceso conforme solicitado.<BR>Usuário: " + aluno.email + "<BR>Senha: " + aluno.senha
                    }.Salvar();
                    retorno.mensagem = "Dados enviados com sucesso.";
                }
            }
            else
            {
                retorno.retorno = 0;
                retorno.mensagem = "Dados incorretos.";
            }

            return retorno;

        }

        public Retorno EsqueceuMedTV(string esqueceu)
        {
            Retorno retorno = new Retorno();

            if (esqueceu.Length > 2)
            {
                Aluno aluno = new AlunoDB().Email(esqueceu);

                if (aluno == null)
                {
                    retorno.retorno = 0;
                    retorno.mensagem = "Dados incorretos.";
                }
                else
                {
                    retorno.retorno = 1;
                    retorno.id = aluno.codigo;
                    string senha = aluno.senha;

                    Aluno_MedTV am = new Aluno_MedTVDB().Buscar(aluno);
                    if (am != null)
                        senha = am.senha;

                    new Envio_email()
                    {
                        para = aluno.email,
                        assunto = "Dados de acesso - MedTV",
                        texto = "Segue os dados de acceso conforme solicitado.<BR>Usuário: " + aluno.email + "<BR>Senha: " + senha
                    }.Salvar();
                    retorno.mensagem = "Dados enviados com sucesso.";
                }
            }
            else
            {
                retorno.retorno = 0;
                retorno.mensagem = "Dados incorretos.";
            }

            return retorno;

        }

        public Retorno Cadastro(AlunoCadastrar alunoview)
        {
            Retorno retorno = new Retorno();
            if (alunoview != null)
            {
                alunoview.cpf = alunoview.cpf.TrimStart().TrimEnd();
                alunoview.email = alunoview.email.TrimStart().TrimEnd();

                if (new AlunoDB().ExisteEmail(alunoview.email) && alunoview.codigo == 0)
                {
                    retorno.erro = true;
                    retorno.mensagem = "E-mail já cadastrado";
                }
                else
                {
                    Aluno aluno = new Aluno();
                    if (alunoview.codigo == 0)
                    {
                        Aluno alunoCPF = new AlunoDB().CPF(alunoview.cpf);
                        if (alunoCPF != null)
                        {
                            aluno = alunoview.Atualizar(alunoCPF);
                            aluno.Alterar();
                        }
                        else
                        {
                            aluno = alunoview.Retornar();
                            aluno.Salvar();
                        }

                    }
                    else
                    {
                        aluno = alunoview.Atualizar(new AlunoDB().Buscar(alunoview.codigo));
                        aluno.Alterar();
                    }

                    retorno.erro = false;
                    retorno.mensagem = "Redirecionando...";
                    retorno.id = new AlunoDB().CPF(alunoview.cpf).codigo;

                    string _ga = Cookies_ga();
                    if (_ga != null && _ga != "")
                    {
                        new Aluno_navegacaoDB().Existe(aluno, _ga);

                        //seleciona dos os _ga do periodo de lead (newsletter)
                        foreach(var n in new Newsletter_navegacaoDB().ListarEmail(aluno.email))
                        {
                            new Aluno_navegacaoDB().Existe(aluno, n._ga);
                        }
                    }
                }
            }
            else
            {
                retorno.erro = true;
                retorno.mensagem = "Conteúdo vazio";
            }
            return retorno;

        }

        public Retorno CadastroMedTV(string nome, string email, string senha, string cpf, string ddd, string telefone, string cep, string endereco, string bairro, string cidade, string estado, string numero, string complemento)
        {
            Retorno retorno = new Retorno();
            if (nome != null && email != null && senha != null && cpf != null && nome != "" && email != "" && senha != "" && cpf != "")
            {
                cpf = cpf.TrimStart().TrimEnd();
                email = email.TrimStart().TrimEnd();

                AlunoDB db = new AlunoDB();
                Aluno a_cpf = db.CPF(cpf);

                if(a_cpf != null)
                {
                    a_cpf.cep = cep;
                    a_cpf.numero = numero;
                    a_cpf.complemento = complemento;
                    a_cpf.endereco = endereco;
                    a_cpf.bairro = bairro;
                    a_cpf.cidade = cidade;
                    a_cpf.estado = estado;
                    a_cpf.ddd = ddd;
                    a_cpf.telefone = telefone;
                    a_cpf.flcorrecao = 1;

                    a_cpf.Alterar();

                    Aluno_MedTV am = new Aluno_MedTVDB().Buscar(a_cpf);
                    if(am != null)
                    {
                        am.senha = senha;
                        am.Alterar();
                    }
                    else
                    {
                        am = new Aluno_MedTV()
                        {
                            aluno = a_cpf,
                            senha = senha
                        };
                        am.Salvar();
                    }
                    retorno.erro = false;
                    retorno.mensagem = "Redirecionando...";
                    retorno.id = a_cpf.codigo;
                    CookiesMedTVAtivar(retorno.id);
                }
                else
                {
                    if (new AlunoDB().ExisteEmail(email))
                    {
                        retorno.erro = true;
                        retorno.mensagem = "E-mail já cadastrado";
                    }
                    else
                    {
                        Aluno aluno = new Aluno()
                        {
                            nome = nome,
                            senha = senha,
                            cpf = cpf,
                            email = email,
                            ddd = ddd,
                            telefone = telefone,
                            cep = cep,
                            endereco = endereco,
                            bairro = bairro,
                            cidade = cidade,
                            estado = estado,
                            numero = numero,
                            complemento = complemento,
                            flcorrecao = 1
                        };
                        aluno.Salvar();

                        Aluno_MedTV am = new Aluno_MedTV()
                        {
                            aluno = aluno,
                            senha = senha
                        };
                        am.Salvar();

                        retorno.erro = false;
                        retorno.mensagem = "Redirecionando...";
                        retorno.id = aluno.codigo;
                        CookiesMedTVAtivar(retorno.id);
                    }
                }
            }
            else
            {
                retorno.erro = true;
                retorno.mensagem = "Conteúdo vazio";
            }
            return retorno;

        }

        public Retorno Completar(int aluno, string cep, string endereco, string bairro, string cidade, string estado, string numero, string complemento)
        {
            Retorno retorno = new Retorno();
            if (aluno != 0)
            {
                AlunoDB db = new AlunoDB();
                Aluno alun = db.Buscar(aluno);


                if (alun != null)
                {
                    alun.cep = cep;
                    alun.endereco = endereco;
                    alun.bairro = bairro;
                    alun.cidade = cidade;
                    alun.estado = estado;
                    alun.numero = numero;
                    alun.complemento = complemento;
                    alun.flcorrecao = 1;
                    alun.Alterar();

                    retorno.erro = false;
                    retorno.mensagem = "Redirecionando...";
                    retorno.id = alun.codigo;
                }
            }
            else
            {
                retorno.erro = true;
                retorno.mensagem = "Conteúdo vazio";
            }
            return retorno;

        }

        public RetornoCEP CEP(string cep)
        {
            RetornoCEP retorno = new RetornoCEP();

            cep = cep.Replace(".", "").Replace("-", "");

            if (cep.Length == 8)
            {
                HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create(String.Format("https://viacep.com.br/ws/{0}/json/unicode", cep));
                HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
                int cont;
                byte[] buffer = new byte[1000];
                StringBuilder sb = new StringBuilder();
                string temp;
                Stream stream = resposta.GetResponseStream();
                do
                {
                    cont = stream.Read(buffer, 0, buffer.Length);
                    temp = Encoding.Default.GetString(buffer, 0, cont).Trim();
                    sb.Append(temp);
                } while (cont > 0);

                if (sb.ToString().IndexOf("\"erro\": true") == -1)
                {
                    JsonTextReader reader = new JsonTextReader(new StringReader(sb.ToString()));
                    string titulo = "";
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            if (reader.TokenType.ToString() == "PropertyName")
                                titulo = reader.Value.ToString();

                            if (reader.TokenType.ToString() == "String")
                            {
                                if (titulo == "logradouro")
                                    retorno.endereco = reader.Value.ToString();
                                if (titulo == "bairro")
                                    retorno.bairro = reader.Value.ToString();
                                if (titulo == "localidade")
                                    retorno.cidade = reader.Value.ToString();
                                if (titulo == "uf")
                                    retorno.estado = reader.Value.ToString();
                                if (titulo == "ibge")
                                    retorno.codibge = reader.Value.ToString();
                            }
                        }
                    }
                }
            }


            return retorno;
        }

        public Retorno CupomDesconto(string cupom)
        {
            Retorno retorno = new Retorno();

            retorno.erro = new CupomDescontoDB().Existe(cupom);
            
            return retorno;
        }

        public Aluno CPF(string cpf)
        {
            Aluno retorno = null;

            cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");

            if (cpf.Length == 11)
            {
                retorno = new AlunoDB().CPF(cpf);

                if (retorno != null)
                    retorno.senha = "";
            }
            return retorno;
        }

        public void CookiesPortal(int codigo)
        {
            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookie = new HttpCookie("cenbrap_aluno");
            cookie.Domain = ".cenbrap.com.br";
            cookie = HttpContext.Current.Request.Cookies["cenbrap_aluno"];
            if(cookie == null)
                cookie = new HttpCookie("cenbrap_aluno");
            cookie.Domain = ".cenbrap.com.br";
            cookie.Value = Convert.ToString(codigo);

            HttpContext.Current.Response.Cookies.Add(cookie);


            //remove o cookies curso
            cookie = new HttpCookie("curso");
            cookie.Domain = ".cenbrap.com.br";
            cookie = HttpContext.Current.Request.Cookies["curso"];
            if (cookie == null)
                cookie = new HttpCookie("curso");
            cookie.Domain = ".cenbrap.com.br";
            cookie.Value = "";
            cookie.Expires = DateTime.Now.AddDays(-1);

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public void CookiesMedTV(int codigo, int lembrar)
        {
            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookie = new HttpCookie("medtv_id");
            //cookie.Domain = ".medtv.com.br";
            cookie = HttpContext.Current.Request.Cookies["medtv_id"];
            if (cookie == null)
                cookie = new HttpCookie("medtv_id");
            //cookie.Domain = ".medtv.com.br";
            cookie.Value = Convert.ToString(codigo);
            if (lembrar == 1)
                cookie.Expires = DateTime.Now.AddYears(1);

            HttpContext.Current.Response.Cookies.Add(cookie);
            
        }

        public void CookiesMedTVAtivar(int codigo)
        {
            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookie = new HttpCookie("medtv_ativar");
            //cookie.Domain = ".medtv.com.br";
            cookie = HttpContext.Current.Request.Cookies["medtv_ativar"];
            if (cookie == null)
                cookie = new HttpCookie("medtv_ativar");
            //cookie.Domain = ".medtv.com.br";
            cookie.Value = Convert.ToString(codigo);

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public string Cookies_ga()
        {
            string _ga = "";

            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookie = new HttpCookie("_ga");
            //if (HttpContext.Current.Request.Url.Host != "localhost")
            //{
            //    cookie.Domain = ".cenbrap.com.br";
            //}
            cookie = HttpContext.Current.Request.Cookies["_ga"];

            //verifica se o cookie possui valor
            if (cookie != null)
            {
                //pega o valor do cookie
                _ga = Convert.ToString(cookie.Value);
            }

            return _ga;
        }

        public RetornoCEP CEPNovo(string cep)
        {
            RetornoCEP retorno = new RetornoCEP();

            cep = cep.Replace(".", "");

            Enderecos end = new EnderecosDB().Buscar(cep);
            if (end == null)
            {
                retorno.endereco = "";
                retorno.bairro = "";
                retorno.cidade = "";
                retorno.estado = "";
                retorno.codibge = "";
            }
            else
            {
                retorno.endereco = end.logradouro.ToString();
                retorno.bairro = end.bairro.ToString();
                retorno.cidade = end.cidade.ToString();
                retorno.estado = end.uf.ToString();
                retorno.codibge = end.ibge_cod_cidade.ToString();
            }
            

            return retorno;
        }

        public DateTime Vencimento(DateTime data)
        {
            if (data.DayOfWeek.ToString() == "Saturday")
            {
                data = data.AddDays(2);
            }
            if (data.DayOfWeek.ToString() == "Sunday")
            {
                data = data.AddDays(1);
            }

            // Verifica se é feriado
            if (new FeriadosDB().Validar(data.Day, data.Month))
            {
                data = data.AddDays(1);
            }

            // Verifica novamente se é final de semana
            if (data.DayOfWeek.ToString() == "Saturday")
            {
                data = data.AddDays(2);
            }
            if (data.DayOfWeek.ToString() == "Sunday")
            {
                data = data.AddDays(1);
            }
            return data;
        }

    }
}
