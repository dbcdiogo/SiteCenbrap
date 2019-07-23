using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Reposicao
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public Curso curso { get; set; }
        public Aluno aluno { get; set; }
        public Disciplina disciplina { get; set; }
        public Curso curso_reposicao { get; set; }
        public Encontro encontro_reposicao { get; set; }
        public DateTime data1 { get; set; }
        public int confirmada { get; set; }
        public int cancelada { get; set; }
        public string obs { get; set; }
        public int cor { get; set; }
        public string endereco_local { get; set; }
        public string obs_local { get; set; }
        public string arquivo_mapa { get; set; }
        public string arquivo_material { get; set; }
        public int codigo_encontro_reposicao { get; set; }
        public int codigo_aluno { get; set; }

        public Reposicao()
        {
            this.codigo = 0;
            this.data = Convert.ToDateTime("01/01/1900");
            this.painel = new Painel();
            this.curso = new Curso();
            this.aluno = new Aluno();
            this.disciplina = new Disciplina();
            this.curso_reposicao = new Curso();
            this.encontro_reposicao = new Encontro();
            this.data1 = Convert.ToDateTime("01/01/1900");
            this.confirmada = 0;
            this.cancelada = 0;
            this.obs = "";
            this.cor = 0;
            this.endereco_local = "";
            this.obs_local = "";
            this.arquivo_mapa = "";
            this.arquivo_material = "";
            this.codigo_encontro_reposicao = 0;
            this.codigo_aluno = 0;
        }

        public Reposicao(int codigo, DateTime data, Curso curso, Aluno aluno, Disciplina disciplina, Curso curso_reposicao, Encontro encontro_reposicao, DateTime data1, int confirmada, int cancelada, string obs, int cor, string endereco_local, string obs_local, string arquivo_mapa, string arquivo_material)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.curso = curso;
            this.aluno = aluno;
            this.disciplina = disciplina;
            this.curso_reposicao = curso_reposicao;
            this.encontro_reposicao = encontro_reposicao;
            this.data1 = data1;
            this.confirmada = confirmada;
            this.cancelada = cancelada;
            this.obs = obs;
            this.cor = cor;
            this.endereco_local = endereco_local;
            this.obs_local = obs_local;
            this.arquivo_mapa = arquivo_mapa;
            this.arquivo_material = arquivo_material;
        }

        public Reposicao(int disciplina, int encontro, string nome, string email, string telefone, Aluno aluno, Curso curso)
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.painel = new Painel();
            this.curso = curso;
            this.aluno = aluno;
            this.disciplina = new DisciplinaDB().Buscar(disciplina);
            this.encontro_reposicao = new EncontroDB().Buscar(encontro);
            this.curso_reposicao = this.encontro_reposicao.curso;
            this.data1 = DateTime.Now;
            this.confirmada = 1;
            this.cancelada = 0;
            this.obs = "";
            this.cor = 0;
            this.endereco_local = "";
            this.obs_local = "";
            this.arquivo_mapa = "";
            this.arquivo_material = "";

            if(!new ReposicaoDB().Existe(this))
            {
                this.codigo = new ReposicaoDB().SalvarRetornar(this);
            }

            this.curso_reposicao = new CursoDB().Buscar(this.curso_reposicao.codigo);

            //Avisa o Fernando sobre a reposicao
            string texto = "O Aluno <strong>" + aluno.nome + "</strong> do curso <strong>" + curso.titulo + "</strong>, esta remarcando a disciplina <strong>" + this.disciplina.titulo + "</strong> para ser realizada dia <strong>" + this.encontro_reposicao.data_encontro.ToShortDateString() + "</strong> juntamente com o curso <strong>" + this.curso_reposicao.titulo + "</strong><BR><BR>Nome: " + nome + "<br>E-mail: " + email + "<BR>Telefone: " + telefone + "";

            new Funcoes.EnviarEmail().EnviaMensagemEmail("pedagogico@cenbrap.com.br", "Remarcacao de disciplina - www.cenbrap.com.br", texto, 0);

            //Se a reposicao está confirmada, avisa o aluno
            if(this.confirmada == 1)
            {
                texto = "<p>Prezado(a) Dr(a). <strong>" + nome + "</strong>, bom dia.</p><p>A Disciplina ( <strong>" + this.disciplina.titulo + "</strong> do curso <strong>" + curso.titulo + "</strong>, esta remarcada para ser realizada dia(s) <strong>" + this.encontro_reposicao.data_encontro.ToShortDateString() + " e " + this.encontro_reposicao.data_encontro1.ToShortDateString() + "</strong> juntamente com o curso <strong>" + this.curso_reposicao.titulo + "</strong>.</p>";

                Cidade_local cidade = new Cidade_localDB().BuscarCidade(this.curso_reposicao.cidade_codigo.codigo);
                if(cidade != null)
                {
                    texto += "<p>Segue o endereço do local de aula: ";
                    texto += "<strong>" + cidade.nome + " - " + cidade.endereco + " - Fone: " + cidade.telefone + "</strong>";
                    if (cidade.link_google_maps.Length > 0)
                        texto += " - <a href='" + cidade.link_google_maps + "'> Google Maps</a>";
                    texto += "</p>";
                }
                texto += "<p>Os horários são os mesmos praticados em sua turma.</p>";
                texto += "<p>Sobre material didático do encontro, na semana de ocorrência o(a) Senhor(a) receberá um e-mail informativo com o contato da copiadora local para solicitação do material impresso, caso queira.</p>";
                texto += "<p><strong>Ratificamos que o cronograma acima pode sofrer alterações sem aviso prévio, por motivo de força maior os quais fogem ao controle do CENBRAP.</strong></p>";
                texto += "<p>Lembramos ainda que estamos de plantão em todos os finais de semana de aulas no CENBRAP através dos telefones: (62) 98164-4645 - falar com Fernando Silva.</p>";
                texto += "<p>Estamos à disposição para maiores esclarecimentos por e-mail, pela Central de Atendimento 0300-31-31-538.";
                //texto += "<p>Estamos à disposição para maiores esclarecimentos por e-mail, pela Central de Atendimento 0300-31-31-538 ou  pelos telefones divulgados em nosso site(<a href='http://www.cenbrap.com.br'>www.cenbrap.com.br</a>), todos caem na Central de Atendimento</p>";
                texto += "<p>Obrigado</p>";
                texto += "<BR><BR>Atenciosamente,<BR><img src='http://dl.dropbox.com/u/52400084/mailing/images/header_shadow.png' width='725' height='11' /><br /><table style='float: none; height: 100px; width: 570px;' border='0' width='570' height='100' align='left'><tbody><tr valign='top'><td width='200'><span style='font-size: small;'> <a style='color: #336699; font-weight: normal; text-decoration: underline;'><img style='border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='http://dl.dropbox.com/u/52400084/mailing/images/logo_menor.jpg' alt='Logomarca Cenbrap' align='none' /></a> </span></td><td style='text-align: left;' width='350'><span style='font-size: 8pt;'><span style='color: #808080;'><strong>Fernando Silva Tiago |&nbsp; </strong></span><span style='color: #808080;'><span style='color: #888888;'><em>Coordena&ccedil;&atilde;o Pedag&oacute;gica Adjunta</em></span></span></span><br /> <span style='margin-top: 0px; margin-bottom: 0px;'><span style='font-size: 8pt;'><span style='color: #ff6600;'><span style='color: #888888;'>pedagogico@cenbrap.com.br</span><br /></span><span style='color: #888888;'>0300-31-31-538<BR>(62) 3255-1404 <br />Cenbrap - Centro Brasileiro de P&oacute;s-Gradua&ccedil;&otilde;es</span></span><br /><br /><div style='color: #707070; font-family: Arial; font-size: 10px; line-height: 125%; text-align: left;'><a style='color: #336699; font-weight: normal; text-decoration: underline;' href='http://www.cenbrap.com.br'><img style='width: 20px; height: 20px; border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='http://dl.dropbox.com/u/52400084/mailing/images/CPlogo.gif' alt='www.cenbrap.com.br' width='20' height='20' align='none' /></a> |&nbsp;<a style='color: #336699; font-weight: normal; text-decoration: underline;' href='http://www.facebook.com/cenbrap'><img style='width: 20px; height: 20px; border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='http://dl.dropbox.com/u/52400084/mailing/images/facebook.png' alt='' width='20' height='20' align='none' /></a> |&nbsp;<a style='color: #336699; font-weight: normal; text-decoration: underline;' href='http://www.twitter.com/cenbrap'><img style='width: 20px; height: 20px; border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='http://dl.dropbox.com/u/52400084/mailing/images/twitter.png' alt='' width='20' height='20' align='none' /></a></div></span> <span style='font-size: 10pt; font-family: arial,helvetica,sans-serif;'> </span></td></tr></tbody></table><div style='float: none'><a style='color: #336699; font-weight: normal; text-decoration: underline;' href='http://www.cenbrap.com.br/FaleConosco'><img style='width: 750px; height: 100px; border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='http://dl.dropbox.com/u/52400084/mailing/images/telefones748px.jpg' alt='' width='20' height='20' align='none' /></a></div>";

                new Envio_email() {
                    assunto = "Confirmação de agendamento de reposição",
                    texto = texto,
                    data = DateTime.Now,
                    para = email
                }.Salvar();

                EnvioConfirmacao();
            }
        }

        public void EnvioConfirmacao()
        {
            new ReposicaoDB().EnvioConfirmacao(this.codigo);
        }
    }
}
