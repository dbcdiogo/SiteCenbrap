using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class EnviarEmailAgendados
    {
        public void Enviar()
        {
            List<Envio_email> list = new Envio_emailDB().Enviar();
            EnviarEmail e = new EnviarEmail();

            foreach (Envio_email l in list)
            {
                ContaEnvio contaEnvio = new ContaEnvioDB().Buscar(l.envio_email);

                if (contaEnvio == null)
                    contaEnvio = new ContaEnvio(1, "Cenbrap", "contato@cenbrap.com.br", "contato@cenbrap.com.br", "databenq206");

                string r = e.EnviaMensagemEmail(l.para, l.assunto, l.texto, l.codigo, contaEnvio, false);
                
                l.Enviado(r);
            }
        }    
    }
}
