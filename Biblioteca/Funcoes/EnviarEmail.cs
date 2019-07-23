using System;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using Biblioteca.Entidades;

namespace Biblioteca.Funcoes
{
    public class EnviarEmail
    {  
        public string EnviaMensagemEmail(string destinatario, string assunto, string enviaMensagem, int id, bool assinar = true, string nome = "Cenbrap", string email = "contato@cenbrap.com.br")
        {

            try
            {
                // valida o email
                bool bValidaEmail = ValidaEnderecoEmail(destinatario);

                // Se o email não é validao retorna uma mensagem
                if (bValidaEmail == false)
                    return "Email do destinatário inválido: " + destinatario;

                if (assinar)
                {
                    //acrescenta a assinatura na msg
                    enviaMensagem = "<html><head><title>Cenbrap</title><style type='text/css'>body {font-family: Arial, Helvetica, sans-serif; font-size: 12px; margin: 5px;}a:link"
                    + "{text-decoration: none;}a:visited {text-decoration: none;}a:active {text-decoration: none;} a:hover {text-decoration: underline;}</style></head><body>" + enviaMensagem + "<BR><BR><BR>Atenciosamente, <BR><BR>";
                    if (nome == null)
                    {
                        enviaMensagem += "Cenbrap";
                    }
                    else
                    {
                        enviaMensagem += nome;
                    }
                    enviaMensagem += "</body></html>";
                }
                
                if(id != 0)
                {
                    string incluir = "<img src='https://sistema.cenbrap.com.br/Imagem/" + id + "/' width='1' hight='1' />";
                    if(enviaMensagem.IndexOf("</body>") > -1)
                    {
                        enviaMensagem = enviaMensagem.Replace("</body>", incluir + "</body>");
                    }
                    else
                    {
                        enviaMensagem += incluir;
                    }
                }

                SmtpClient smtp = new SmtpClient();
                NetworkCredential credenciais = new NetworkCredential("contato@cenbrap.com.br", "databenq206");
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress(email);

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;

                msg.From = from;
                msg.Subject = assunto;
                msg.IsBodyHtml = true;
                msg.Body = enviaMensagem;
                msg.To.Add(destinatario);

                smtp.Send(msg);


                return email;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string EnviaMensagemComAnexos(string destinatario, string assunto, string enviaMensagem, ArrayList anexos, string nome = "Cenbrap", string email = "contato@cenbrap.com.br")
        {
            try
            {
                // valida o email
                bool bValidaEmail = ValidaEnderecoEmail(destinatario);

                if (bValidaEmail == false)
                    return "Email do destinatário inválido:" + destinatario;

                //acrescenta a assinatura na msg
                enviaMensagem = "<html><head><title>Cenbrap</title><style type='text/css'>body {font-family: Arial, Helvetica, sans-serif; font-size: 12px; margin: 5px;}a:link"
                + "{text-decoration: none;}a:visited {text-decoration: none;}a:active {text-decoration: none;} a:hover {text-decoration: underline;}</style></head><body>" + enviaMensagem + "<BR><BR><BR>Atenciosamente, <BR><BR>";
                if (nome == null)
                {
                    enviaMensagem += "Cenbrap";
                }
                else
                {
                    enviaMensagem += nome;
                }

                SmtpClient smtp = new SmtpClient();
                NetworkCredential credenciais = new NetworkCredential("contato@cenbrap.com.br", "databenq206");
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress(email);

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;

                msg.From = from;
                msg.Subject = assunto;
                msg.IsBodyHtml = true;
                msg.Body = enviaMensagem;
                msg.To.Add(destinatario);

                foreach (string anexo in anexos)
                {
                    Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                    msg.Attachments.Add(anexado);
                }

                smtp.Send(msg);

                return email;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string EnviaMensagemEmail(string destinatario, string assunto, string enviaMensagem, int id, ContaEnvio conta, bool assinar = true)
        {

            try
            {
                // valida o email
                //bool bValidaEmail = ValidaEnderecoEmail(destinatario);

                // Se o email não é validao retorna uma mensagem
                //if (bValidaEmail == false)
                //    return "Email do destinatário inválido: " + destinatario;

                if (assinar)
                {
                    //acrescenta a assinatura na msg
                    enviaMensagem = "<html><head><title>Cenbrap</title><style type='text/css'>body {font-family: Arial, Helvetica, sans-serif; font-size: 12px; margin: 5px;}a:link"
                    + "{text-decoration: none;}a:visited {text-decoration: none;}a:active {text-decoration: none;} a:hover {text-decoration: underline;}</style></head><body>" + enviaMensagem + "<BR><BR><BR>Atenciosamente, <BR><BR>";
                    enviaMensagem += conta.titulo;
                    enviaMensagem += "</body></html>";
                }

                if (id != 0)
                {
                    string incluir = "<img src='https://sistema.cenbrap.com.br/Imagem/" + id + "/' width='1' hight='1' />";
                    if (enviaMensagem.IndexOf("</body>") > -1)
                    {
                        enviaMensagem = enviaMensagem.Replace("</body>", incluir + "</body>");
                    }
                    else
                    {
                        enviaMensagem += incluir;
                    }
                }

                SmtpClient smtp = new SmtpClient();
                NetworkCredential credenciais = new NetworkCredential(conta.usuario, conta.senha);
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress(conta.email);

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciais;

                msg.From = from;
                msg.Subject = assunto;
                msg.IsBodyHtml = true;
                msg.Body = enviaMensagem;
                msg.To.Add(destinatario);

                smtp.Send(msg);


                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

    }
}
