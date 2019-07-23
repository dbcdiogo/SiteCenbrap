using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Funcoes
{
    public class MarcarCartaz
    {
        public void Marcar(string cidade, string ip)
        {
            new Cartaz(0, cidade, DateTime.Now, ip).Salvar();

            new Envio_email() { para = "filipe@cenbrap.com.br", assunto = "Acesso Cartaz", texto = "ACESSO PELO CIDADE: " + cidade + "<BR>IP: " + ip + "<BR>Data: " + DateTime.Now }.Salvar();

        }
    }
}
