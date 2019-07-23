using System;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using Biblioteca.DB;
using Biblioteca.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Funcoes
{
    public class EnviarCampanhasEmail
    {
        public void Enviar()
        {
            //Percorre as Contas com e-mail para enviar
            List<Contas> contas = new EnviadoDB().ContasParaEnviar();
            StringBuilder erros = new StringBuilder();

            foreach (var c in contas)
            {
                List<Enviado> emails = new EnviadoDB().ParaEnviar(c);
                //Percorre os e-mails para enviar
                foreach (var e in emails)
                {
                    string txt = EnviaMensagemEmail(e.txpara, e.txtitulo, e.txtexto, e.idemail, e.idenviado, e.responder);
                    if (txt == "enviado")
                    {
                        e.Finalizar();
                    }
                    else
                    {
                        erros.Append("<p>Conta: "+e.idemail.usuario+"<BR>para: " + e.txpara + "<BR>assunto: " + e.txtitulo + "<BR>"+txt+"</p>");
                    }
                    
                }
            }

            if(erros.Length > 0)
            {
                List<string> responder = new List<string>();
                responder.Add("contato@cenbrap.com.br");

                Contas c1 = new ContasEmailDB().Buscar(6);

                c1.dominio = new DominioDB().Buscar(c1.dominio.iddominio);

                //EnviaMensagemEmail("dbcdiogo@gmail.com", "Erros Envio Campanha", erros.ToString(), c1, 0, responder);
            }
        }

        public string EnviaMensagemEmail(string para, string assunto, string texto, Contas contas, int id, List<string> responder)
        {
            try
            {
                // valida o email
                //bool bValidaEmail = EnviarEmail.ValidaEnderecoEmail(para);

                //// Se o email não é validao retorna uma mensagem
                //if (bValidaEmail == false)
                //    return "Email do destinatário inválido: " + para;

                byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(para);
                para = System.Text.Encoding.ASCII.GetString(bytes);

                if (id != 0)
                {
                    string incluir = "<img src='https://sistema.cenbrap.com.br/ImagemCampanha/" + id + "/' width='1' hight='1' />";
                    if (texto.IndexOf("</body>") > -1)
                    {
                        texto = texto.Replace("</body>", incluir + "</body>");
                    }
                    else
                    {
                        texto += incluir;
                    }
                }

                SmtpClient smtp = new SmtpClient();
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress(contas.usuario, "");

                smtp.Host = contas.dominio.smtp;
                smtp.EnableSsl = true;
                smtp.Port = contas.dominio.porta;
                if(contas.dominio.autenticacao == 0)
                {
                    smtp.UseDefaultCredentials = true;

                }
                else
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(contas.usuario, contas.senha);
                }

                msg.From = from;
                if(responder.Count > 0)
                {
                    foreach(var r in responder)
                    {
                        msg.ReplyToList.Add(new MailAddress(r));
                    }
                    msg.ReplyTo = new MailAddress(responder.First());
                }

                msg.Subject = assunto;
                msg.IsBodyHtml = true;
                msg.Body = texto;
                msg.To.Add(para);

                smtp.Send(msg);
                
                return "enviado";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
