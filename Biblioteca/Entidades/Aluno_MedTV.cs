using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_MedTV
    {
        public int aluno_MedTV_id { get; set; }
        public Aluno aluno { get; set; }
        public string senha { get; set; }
        public DateTime data { get; set; }
        public bool ativo { get; set; }
        public DateTime ativoEm { get; set; }
        public DateTime ativoAte { get; set; }
        public bool desativado { get; set; }
        public DateTime desativadoEm { get; set; }
        public string urlPagseguro { get; set; }
        public string msgPagseguro { get; set; }
        public bool pagseguro { get; set; }
        public string codePagseguro { get; set; }

        public List<Aluno_MedTV_Transacao> transacoes { get; set; }
        public List<Aluno_MedTV_Notificacao> notificacoes { get; set; }

        public Aluno_MedTV()
        {
            this.aluno_MedTV_id = 0;
            this.aluno = new Aluno() { codigo = 0 };
            this.senha = "";
            this.data = Convert.ToDateTime("01/01/1900");
            this.ativo = false;
            this.ativoEm = Convert.ToDateTime("01/01/1900");
            this.ativoAte = Convert.ToDateTime("01/01/1900");
            this.desativado = false;
            this.desativadoEm = Convert.ToDateTime("01/01/1900");
            this.urlPagseguro = "";
            this.msgPagseguro = "";
            this.pagseguro = false;
            this.codePagseguro = "";
            this.transacoes = new List<Aluno_MedTV_Transacao>();
            this.notificacoes = new List<Aluno_MedTV_Notificacao>();
        }

        public Aluno_MedTV(int id)
        {
            this.aluno_MedTV_id = id;
            this.aluno = new Aluno() { codigo = 0 };
            this.senha = "";
            this.data = Convert.ToDateTime("01/01/1900");
            this.ativo = false;
            this.ativoEm = Convert.ToDateTime("01/01/1900");
            this.ativoAte = Convert.ToDateTime("01/01/1900");
            this.desativado = false;
            this.desativadoEm = Convert.ToDateTime("01/01/1900");
            this.urlPagseguro = "";
            this.msgPagseguro = "";
            this.pagseguro = false;
            this.codePagseguro = "";
            this.transacoes = new List<Aluno_MedTV_Transacao>();
            this.notificacoes = new List<Aluno_MedTV_Notificacao>();
        }

        public Aluno_MedTV(int id, Aluno aluno, string senha, DateTime data, bool ativo, DateTime ativoEm, DateTime ativoAte, bool desativado, DateTime desativadoEm, string urlPagseguro, string msgPagseguro, bool pagseguro, string codePagseguro)
        {
            this.aluno_MedTV_id = id;
            this.aluno = aluno;
            this.senha = senha;
            this.data = data;
            this.ativo = ativo;
            this.ativoEm = ativoEm;
            this.ativoAte = ativoAte;
            this.desativado = desativado;
            this.desativadoEm = desativadoEm;
            this.urlPagseguro = urlPagseguro;
            this.msgPagseguro = msgPagseguro;
            this.pagseguro = pagseguro;
            this.codePagseguro = codePagseguro;

            if (this.ativo && this.ativoAte < DateTime.Now)
            {
                this.ativo = false;
                this.desativado = true;
                this.desativadoEm = this.ativoAte;

                Alterar();
            }
        }

        public void Salvar()
        {
            this.aluno_MedTV_id = new Aluno_MedTVDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new Aluno_MedTVDB().Alterar(this);
        }

        public void Excluir()
        {
            new Aluno_MedTVDB().Excluir(this);
        }

        public void Ativar()
        {
            this.ativo = true;
            this.desativado = false;
            this.data = DateTime.Now;
            this.ativoEm = DateTime.Now;
            this.ativoAte = DateTime.Now.AddMonths(60);
            new Aluno_MedTVDB().Alterar(this);

            EnviarEmail();
        }

        public void Desativar()
        {
            //verifica o última transação
            Aluno_MedTV_Transacao ultima_transacao = new Aluno_MedTV_TransacaoDB().Buscar(this, 3);
            if (ultima_transacao != null)
            {
                this.ativoAte = ultima_transacao.data.AddDays(30);
            }
            else
            {
                this.ativo = false;
                this.desativado = true;
                this.desativadoEm = DateTime.Now;
            }
            new Aluno_MedTVDB().Alterar(this);
        }

        public void EnviarEmail()
        {
            string assunto = "Assinatura MEDTV";
            string texto = "<p>Prezado(a). #NOMEALUNO#<br /><br />Constatamos o pagamento da sua assinatura no medtv.com.br.</p><p>Em nome de toda nossa equipe, desejamos boas-vindas! <br /><br />Segue abaixo os dados de acesso: <br /><br /> 1.&nbsp;&nbsp;Acesse: <em><a style='color: #336699; font-weight: normal; text-decoration: underline;' href='http://www.medtv.com.br'>www.medtv.com.br</a>;</em><br /> 2.&nbsp;&nbsp;Clique em <em>Entrar</em>;<br /> 3.&nbsp;&nbsp;Informe seu e-mail: #EMAIL#;<br /> 4.&nbsp;&nbsp;Digite a senha: #SENHAMEDTV# ;<br /> 5.&nbsp;&nbsp;Clique em &ldquo;Entrar&rdquo;<br /><br /> <strong>Importante!</strong><br /> &gt;&gt; o acesso ao portal ser&aacute; livre at&eacute; a data do fim da sua assinatura;<br /> &gt;&gt; o assinante declara ci&ecirc;ncia de que o presente acesso &eacute; de direito personal&iacute;ssimo, indeleg&aacute;vel, inoutorg&aacute;vel e intransfer&iacute;vel. Qualquer suspeita de fraude implicar&aacute; em perda imediata de acesso ao portal e todas as suas ferramentas, sem restitui&ccedil;&atilde;o do valor da assinatura;<br />&gt;&gt; o Medtv se compromete, caso haja qualquer problema t&eacute;cnico confirmado nos acessos, a fornecer ao assinante outras vias de acesso, garantindo visualiza&ccedil;&atilde;o extra no mesmo per&iacute;odo de vig&ecirc;ncia do problema t&eacute;cnico identificado;<br /> &gt;&gt; com o intuito de melhorar o material audiovisual, estaremos em constante aten&ccedil;&atilde;o o que poder&aacute; causar suspens&atilde;o tempor&aacute;ria de algum dos materiais referidos por causa da substitui&ccedil;&atilde;o do(s) arquivo(s). <br /><br />Esclarecimentos de d&uacute;vidas: 0300-313-1538 ou contato@medtv.com.br.<br /><br /> Atenciosamente, <br /><br />Rakel Mendes | Coordenadora Financeira";

            if (this.aluno.email == "")
                this.aluno = new AlunoDB().Buscar(this.aluno.codigo);

            texto = texto.Replace("#SENHAMEDTV#", this.senha);
            texto = texto.Replace("#EMAIL#", this.aluno.email);
            texto = texto.Replace("#NOMEALUNO#", this.aluno.nome);

            new Envio_emailDB().Salvar(new Envio_email()
            {
                data = DateTime.Now,
                assunto = assunto,
                texto = texto,
                para = aluno.email
            });
        }
    }
}
