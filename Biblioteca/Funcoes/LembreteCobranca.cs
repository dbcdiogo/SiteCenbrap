using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class LembreteCobranca
    {
        private string assunto = "Lembrete de Vencimento - Cenbrap";
        private string texto = "Prezado(a) Dr(a). #NOME#.<BR><BR>Lembramos que seu boleto de R$ #VALOR# vence amanhã (#VENCIMENTO#).<BR><BR>Boleto: http://boleto.cenbrap.com.br/boleto/?id=#CODBOLETO# <BR><BR> Em caso de pagamento já realizado, gentileza desconsiderar esse aviso.<BR><BR> Qualquer dúvida, estamos à disposição pelo 0300-313-1538. <BR><BR> Atenciosamente,<BR> Coordenação Financeira.<BR><BR><BR><img src='http://www.cenbrap.com.br/site/images/cenbrap_logo.png'>";

        public void Enviar()
        {
            List<Entrada> entradas = new EntradaDB().VenceAmanha();

            Envio_email env = new Envio_email();

            foreach (var e in entradas)
            {
                string venc = e.vencimento.Day + "/" + e.vencimento.Month + "/" + e.vencimento.Year;
                env = new Envio_email() {
                    para = e.cliente.email,
                    assunto = assunto,
                    texto = texto.Replace("#NOME#", e.cliente.nome).Replace("#VALOR#", e.valor.ToString("N2")).Replace("#VENCIMENTO#", venc).Replace("#CODBOLETO#", e.codboleto.ToString()),
                    envio_email = "pagamento@cenbrap.com.br"
                };

                env.Salvar();
                
            }
        }
    }

    public class AgradecimentoPagamento
    {
        private string assunto = "Agradecimento - Cenbrap";
        private string texto = "Prezado(a) Dr(a). #NOME#.<BR><BR>Agradecemos o pagamento de R$ #VALOR# efetuado em #DATAPGTO# referente ao boleto com vencimento em #VENCIMENTO#. <BR><BR> Qualquer dúvida, estamos à disposição pelo 0300-313-1538. <BR><BR> Atenciosamente,<BR> Coordenação Financeira.<BR><BR><BR><img src='http://www.cenbrap.com.br/site/images/cenbrap_logo.png'>";

        public void Enviar()
        {
            List<Entrada> entradas = new EntradaDB().PgtoOntem();

            Envio_email env = new Envio_email();

            foreach (var e in entradas)
            {
                string venc = e.vencimento.Day + "/" + e.vencimento.Month + "/" + e.vencimento.Year;
                string pgt = e.data_quitado.Day + "/" + e.data_quitado.Month + "/" + e.data_quitado.Year;
                env = new Envio_email()
                {
                    para = e.cliente.email,
                    assunto = assunto,
                    texto = texto.Replace("#NOME#", e.cliente.nome).Replace("#VALOR#", e.valor.ToString("N2")).Replace("#DATAPGTO#", pgt).Replace("#VENCIMENTO#", venc),
                    envio_email = "pagamento@cenbrap.com.br"
                };

                env.Salvar();

            }
        }
    }
}
