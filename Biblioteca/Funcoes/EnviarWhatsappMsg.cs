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
using System.Threading.Tasks;

namespace Biblioteca.Funcoes
{
    public class EnviarWhatsappMsg
    {
        public void Enviar()
        {
            // Lista todas as mensagens a serem enviadas
            List<Envio_Whatsapp> mensagens = new WhatsappDB().Listar();            

            foreach (var m in mensagens)
            {
                // Se foi enviado com sucesso, atualiza data de envio
                if (Whatsapp.EnviarMensagem(m.txcelular, m.txmensagem, "").Result)
                {
                    Envio_Whatsapp whatsapp = new Envio_Whatsapp();
                    whatsapp.idmensagem = m.idmensagem;
                    whatsapp.dtenviado = DateTime.Now;
                    whatsapp.AlterarEnviado();
                }
            }            
        }
    }
}
