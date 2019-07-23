using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Funcoes
{
    public class BoasVindas
    {
        public void Enviar()
        {
            string assunto = "Boas Vindas #NOME# - Cenbrap";
            string msg = "Bom dia!<br><br>Fico feliz em ver seu recente cadastro em nosso site.<br><br>Meu nome é Marcia e escrevo-lhe apenas para me colocar à disposição no que precisar.<br><br>Qualquer informação, dúvida, etc., conte comigo, seja através deste e-mail, ou do telefone 0300 - 313 - 1538.<br><br>Receba minhas boas-vindas e também de toda nossa equipe!<br><br>Marcia Barros<br>marcia@cenbrap.com.br<br>0300 - 313 - 1538<br><br><img src='http://cenbrap.com.br/images/cenbrap_logo.png' width='150'>";
            //msg com o titulo do curso.
            msg = "Bom dia!<br><br>Fico feliz em ver seu recente cadastro em nosso site, e seu interesse no curso de #TITULOCURSO#.<br><br>Meu nome é Marcia e escrevo-lhe apenas para me colocar à disposição no que precisar.<br><br>Qualquer informação, dúvida, etc., conte comigo, seja através deste e-mail, ou do telefone 0300 - 313 - 1538.<br><br>Receba minhas boas-vindas e também de toda nossa equipe!<br><br>Marcia Barros<br>marcia@cenbrap.com.br<br>0300 - 313 - 1538<br><br><img src='http://cenbrap.com.br/images/cenbrap_logo.png' width='150'>";

              DateTime hoje = DateTime.Now;
            DateTime inicio = DateTime.Now.AddDays(-1);
            DateTime fim = DateTime.Now.AddDays(-1);

            if (hoje.DayOfWeek == DayOfWeek.Monday)
            {
                inicio = DateTime.Now.AddDays(-3);
            }
            
            List<Aluno> alunos = new AlunoDB().Listar(inicio.Date, fim.Date, "Boas Vindas%");

            foreach(var a in alunos)
            {
                string nome = "";
                if(a.sexo.ToLower().Substring(0, 1) == "F")
                {
                    nome = "Dra. ";
                }
                else
                {
                    nome = "Dr. ";
                }
                nome += a.nome;
                Envio_email ev = new Envio_email()
                {
                    para = a.email,
                    assunto = assunto.Replace("#NOME#", nome),
                    texto = msg.Replace("#TITULOCURSO#", a.endereco),
                    data = DateTime.Now,
                    envio_email = "marcia@cenbrap.com.br"
                };
                new Envio_emailDB().Salvar(ev);
            }
        }

        public void AvisoMarcia()
        {
            string assunto = "Inscritos com mais de 7 dias do vencimento";
            string msg = "<table border='1 cellpadding='0' cellspacing='0'><tr><td width='25%'>Nome</td><td width='25%'>Curso</td><td width='25%'>Obs</td><td width='25%'>Link</td></tr>###SUBSTITUIR###</table>";

            string txt = "";

            DateTime hoje = DateTime.Now;
            DateTime inicio = DateTime.Now.AddDays(-7);
            DateTime fim = DateTime.Now.AddDays(-7);

            if (hoje.DayOfWeek == DayOfWeek.Monday)
            {
                inicio = DateTime.Now.AddDays(-10);
            }

            foreach (var i in new AlunoDB().ListarInscritosParaLigar(inicio.Date, fim.Date))
            {
                txt += i.Texto();
                
            }

            if(txt != "")
            {
                new Envio_emailDB().Salvar(new Envio_email()
                {
                    para = "marcia@cenbrap.com.br",
                    assunto = assunto,
                    texto = msg.Replace("###SUBSTITUIR###", txt),
                    data = DateTime.Now
                });

                //new Envio_emailDB().Salvar(new Envio_email()
                //{
                //    para = "secretaria@cenbrap.com.br",
                //    assunto = assunto,
                //    texto = msg.Replace("###SUBSTITUIR###", txt),
                //    data = DateTime.Now
                //});
            }
            
        }

        public void AvisoFelipe()
        {
            string assunto = "Inscritos com de 7 a 14 dias do vencimento";
            string msg = "<table border='1 cellpadding='0' cellspacing='0'><tr><td width='25%'>Nome</td><td width='25%'>Curso</td><td width='25%'>Obs</td><td width='25%'>Link</td></tr>###SUBSTITUIR###</table>";

            string txt = "";

            DateTime hoje = DateTime.Now;
            DateTime inicio = DateTime.Now.AddDays(-14);
            DateTime fim = DateTime.Now.AddDays(-7);

            if (hoje.DayOfWeek == DayOfWeek.Monday)
            {
                inicio = DateTime.Now.AddDays(-10);
            }

            foreach (var i in new AlunoDB().ListarInscritosParaLigar(inicio.Date, fim.Date))
            {
                txt += i.Texto();

            }

            if (txt != "")
            {
                new Envio_emailDB().Salvar(new Envio_email()
                {
                    para = "publicidade@cenbrap.com.br",
                    assunto = assunto,
                    texto = msg.Replace("###SUBSTITUIR###", txt),
                    data = DateTime.Now
                });

                //new Envio_emailDB().Salvar(new Envio_email()
                //{
                //    para = "secretaria@cenbrap.com.br",
                //    assunto = assunto,
                //    texto = msg.Replace("###SUBSTITUIR###", txt),
                //    data = DateTime.Now
                //});
            }

        }
    }
}
