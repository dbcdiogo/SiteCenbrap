using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Enviado
    {
        public int idenviado { get; set; }
        public Campanhas idcampanha { get; set; }
        public string txtitulo { get; set; }
        public string txtexto { get; set; }
        public string txpara { get; set; }
        public DateTime dtdata { get; set; }
        public DateTime dtenviarapartir { get; set; }
        public Contas idemail { get; set; }
        public bool flenviado { get; set; }
        public DateTime dtenviado { get; set; }
        public int nrprioridade { get; set; }
        public List<string> responder { get; set; }

        public Enviado()
        {
            this.idenviado = 0;
            this.idcampanha = new Campanhas() { idcampanha = 0 };
            this.txtitulo = "";
            this.txtexto = "";
            this.txpara = "";
            this.dtdata = Convert.ToDateTime("01/01/1900");
            this.dtenviarapartir = Convert.ToDateTime("01/01/1900");
            this.idemail = new Contas() { idemail = 0 };
            this.flenviado = false;
            this.dtenviado = Convert.ToDateTime("01/01/1900");
            this.nrprioridade = 0;
            this.responder = new List<string>();
        }

        public Enviado(int id, Campanhas campanha, string titulo, string texto, string para, DateTime data, Contas conta, DateTime dtenviarapartir, bool enviado, DateTime dtenviado, int prioridade, string responder = "")
        {
            this.idenviado = id;
            this.idcampanha = campanha;
            this.txtitulo = titulo;
            this.txtexto = texto;
            this.txpara = para;
            this.dtdata = data;
            this.idemail = conta;
            this.dtenviarapartir = dtenviarapartir;
            this.flenviado = enviado;
            this.dtenviado = dtenviado;
            this.nrprioridade = prioridade;
            if (responder != "")
                this.responder.Add(responder);
        }

        public Enviado(int id, Campanhas campanha, string titulo, string texto, string para, DateTime data, Contas conta, DateTime dtenviarapartir, bool enviado, DateTime dtenviado, int prioridade, List<string> responder)
        {
            this.idenviado = id;
            this.idcampanha = campanha;
            this.txtitulo = titulo;
            this.txtexto = texto;
            this.txpara = para;
            this.dtdata = data;
            this.idemail = conta;
            this.dtenviarapartir = dtenviarapartir;
            this.flenviado = enviado;
            this.dtenviado = dtenviado;
            this.nrprioridade = prioridade;
            this.responder = responder;
        }

        public void Salvar()
        {
            new EnviadoDB().Salvar(this);
        }

        public void SalvarRetornar()
        {
            this.idenviado = new EnviadoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new EnviadoDB().Alterar(this);
        }

        public void AlterarTexto()
        {
            new EnviadoDB().AlterarTexto(this);
        }

        public void Finalizar()
        {
            new EnviadoDB().Enviado(this.idenviado, this.idemail.idemail);
        }

        public void Excluir()
        {
            new EnviadoDB().Excluir(this);
        }

        public void Link()
        {
            //Verifica se a campanha tem o txcodigo
            if (this.idcampanha.txcodigo != null)
            {
                string texto = this.txtexto;

                texto = Tratar(texto, "cenbrap.com.br");
                texto = Tratar(texto, "medtv.com.br");
                texto = Tratar(texto, "congressomedicina.com.br");
                texto = Tratar(texto, "psiquiatriaocupacional.com.br");

                this.txtexto = texto;

                AlterarTexto();
            }
        }

        public string Tratar(string texto, string url)
        {
            //substitui todos os www.{url} para {url} e todos http://{url} para https://{url}
            texto = texto.Replace("www." + url, url).Replace("http://" + url, "https://" + url);

            int posicao = 0;
            int cont = 0;

            while (posicao < texto.Length)
            {
                if (texto.IndexOf("https://" + url, posicao) > -1)
                {
                    cont++;

                    posicao = texto.IndexOf("https://" + url, posicao);

                    int aspas = texto.IndexOf("\"", posicao);
                    int aspas_simples = texto.IndexOf("'", posicao);

                    if (aspas == -1)
                        aspas = posicao + 1000;
                    if (aspas_simples == -1)
                        aspas_simples = posicao + 1000;

                    if (aspas > aspas_simples)
                        aspas = aspas_simples;

                    string link = texto.Substring(posicao, aspas - posicao);
                    string link_novo = link;
                    if (link.IndexOf('?') == -1)
                    {
                        link_novo += "?";
                    }
                    else
                    {
                        link_novo += "&";
                    }
                    link_novo += "idenviado=" + this.idenviado.ToString() + "&cont=" + cont.ToString();

                    texto = texto.Substring(0, posicao) + link_novo + texto.Substring(aspas);

                    posicao++;
                }
                else
                {
                    posicao = texto.Length;
                }
            }
            return texto;
        }
    }
}
