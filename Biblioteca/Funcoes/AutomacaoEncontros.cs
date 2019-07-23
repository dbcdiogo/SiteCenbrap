using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class AutomacaoEncontros
    {
        public static void Enviar()
        {
            List<EncontroEmail> lista = new EncontroDB().ListaParaEmail();
            string html = "";

            foreach(var a in lista)
            {
                html += "Data: <b>" + a.data + "</b><br>Turma: <b>" + a.turma + "</b><br>Disciplina: <b>" + a.titulo + "</b><br>Professor: <b>" + a.professor + "</b><br>Gabarito postado: <b>" + (a.gabarito == 1 ? "<font color='green'>Sim</font>" : "<font color='red'>Não</font>") + "</b>";
                if (a.obs != "")
                {
                    html += "<br>Observações: <b>" + a.obs + "</b>";
                }
                html += "<br><Br>";
            }

            new Envio_emailDB().Salvar(new Envio_email()
            {
                para = "marcos@cenbrap.com.br",
                assunto = "Relatório de encontros do final de semana",
                texto = html,
                data = DateTime.Now
            });

            new Envio_emailDB().Salvar(new Envio_email()
            {
                para = "pedagogico@cenbrap.com.br",
                assunto = "Relatório de encontros do final de semana",
                texto = html,
                data = DateTime.Now
            });

            new Envio_emailDB().Salvar(new Envio_email()
            {
                para = "filipe@cenbrap.com.br",
                assunto = "Relatório de encontros do final de semana",
                texto = html,
                data = DateTime.Now
            });
        }

    }
}
