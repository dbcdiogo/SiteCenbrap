using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class UrlOrigem
    {
        public int urlOrigem_id { get; set; }
        public string url { get; set; }
        public string urlEntrou { get; set; }
        public string parametros { get; set; }
        public string ip { get; set; }
        public DateTime data { get; set; }
        public string _ga { get; set; }
        public string identificador { get; set; }

        public UrlOrigem()
        {
            this.urlOrigem_id = 0;
            this.url = "";
            this.urlEntrou = "";
            this.parametros = "";
            this.ip = "";
            this.data = DateTime.Now;
            this._ga = "";
            this.identificador = "";
        }

        public UrlOrigem(int id)
        {
            this.urlOrigem_id = id;
            this.url = "";
            this.urlEntrou = "";
            this.parametros = "";
            this.ip = "";
            this.data = DateTime.Now;
            this._ga = "";
            this.identificador = "";
        }

        public UrlOrigem(string url)
        {
            this.urlOrigem_id = 0;
            this.url = url;
            this.parametros = "";
            this.urlEntrou = "";
            this.ip = "";
            this.data = DateTime.Now;
            this._ga = "";
            this.identificador = "";
        }

        public UrlOrigem(string url, string parametros, string urlEntrou, string ip, string _ga, string identificador = "")
        {
            this.urlOrigem_id = 0;
            this.url = url;
            this.parametros = parametros;
            this.urlEntrou = urlEntrou;
            this.ip = ip;
            this.data = DateTime.Now;
            this._ga = _ga;
            this.identificador = identificador;
        }

        public UrlOrigem(int id, string url, string parametros, string urlEntrou, string ip, DateTime data, string _ga, string identificador = "")
        {
            this.urlOrigem_id = id;
            this.url = url;
            this.urlEntrou = urlEntrou;
            this.parametros = parametros;
            this.data = data;
            this._ga = _ga;
            this.identificador = identificador;
        }

        public void Salvar()
        {
            this.urlEntrou = this.urlEntrou.Replace(":443", "");
            if(this.url != "localhost" && this.ip != "177.159.146.5" && !NaoContemUrl())
            {
                this.urlOrigem_id = new UrlOrigemDB().Salvar(this);
                GravaCookies();
            }
        }

        public bool NaoContemUrl()
        {
            bool retorno = false;

            List<string> array = new List<string>();

            if(this.urlEntrou.ToLower().IndexOf("cenbrap") > 0)
            {
                array.Add("/Home/Formulario");
                array.Add("/Home/Form");
                array.Add("/Home/Ligamos");
                array.Add("/Home/Contato");
                array.Add("/Home/Newsletter");
                array.Add("/Home/FaleConoscoEnviar");
                array.Add("/Home/Mapa");
                array.Add("/Conheca/TrabalheConoscoEnviar");
                array.Add("/Acesso/Login");
                array.Add("/Cursos/banner");
                array.Add("/Cursos/foto");
                array.Add("/Inscreva/TipoCursos");
                array.Add("/Inscreva/Cidades");
                array.Add("/Inscreva/Cursos");
                array.Add("/Inscreva/Login");
                array.Add("/Inscreva/Esqueceu");
                array.Add("/Inscreva/Cadastro");
                array.Add("/Inscreva/CEP");
                array.Add("/Inscreva/Boleto");
                array.Add("/Inscreva/Cartao");
            }
            
            if(this.urlEntrou.ToLower().IndexOf("psiquiatriaocupacional") > 0)
            {
                array.Add("/Blog/Img");
                array.Add("/Inscricao/CPF");
                array.Add("/Inscricao/CEP");
                array.Add("/Inscricao/CupomDesconto");
                array.Add("/Inscricao/Cadastro");
                array.Add("/Inscricao/Boleto");
                array.Add("/Inscricao/Cartao");
            }

            if (this.urlEntrou.ToLower().IndexOf("medtv") > 0)
            {
                array.Add("/Home/Botoes");
                array.Add("/Home/Login");
                array.Add("/Home/Esqueceu");
                array.Add("/Home/Cadastro");
                array.Add("/Home/CEP");
                array.Add("/Home/CPF");
                array.Add("/Home/Notificacao");
                array.Add("/Notificacao");
                array.Add("/Home/ContatoEnviar");
                array.Add("/Painel/Categorias");
                array.Add("/Painel/Usuario");
                array.Add("/Painel/VideoTempo");
                array.Add("/Painel/Imagem");
            }

            foreach (var a in array)
            {
                if (this.urlEntrou.ToLower().IndexOf(a.ToLower()) > -1)
                    retorno = true;
            }
            
            return retorno;
        }

        public void GravaCookies()
        {
            string s_cookies = "cenbrap_origem";
            string dominio = "*.cenbrap.com.br";

            if(this.urlEntrou.ToLower().IndexOf("psiquiatriaocupacional") > 0)
            {
                s_cookies = "psiquiatriaocupacional_origem";
                dominio = "*.psiquiatriaocupacional.com.br";
            }
            if (this.urlEntrou.ToLower().IndexOf("medtv") > 0)
            {
                s_cookies = "medtv_origem";
                dominio = "*.medtv.com.br";
            }

            //salva o cookies com o codigo do acesso_cookies
            HttpCookie cookieOrigem = new HttpCookie(s_cookies);
            cookieOrigem.Domain = dominio;
            cookieOrigem = HttpContext.Current.Request.Cookies[s_cookies];
            if (cookieOrigem == null)
            {
                cookieOrigem = new HttpCookie(s_cookies);
                cookieOrigem.Domain = dominio;
            }

            cookieOrigem.Value = Convert.ToString(this.urlOrigem_id);
            cookieOrigem.Expires = DateTime.Now.AddMonths(6);

            HttpContext.Current.Response.Cookies.Add(cookieOrigem);
        }
        
        public int RetornaCookies()
        {
            int id = 0;
            string s_cookies = "cenbrap_origem";
            string dominio = "*.cenbrap.com.br";

            if (this.urlEntrou.ToLower().IndexOf("psiquiatriaocupacional") > 0)
            {
                s_cookies = "psiquiatriaocupacional_origem";
                dominio = "*.psiquiatriaocupacional.com.br";
            }
            if (this.urlEntrou.ToLower().IndexOf("medtv") > 0)
            {
                s_cookies = "medtv_origem";
                dominio = "*.medtv.com.br";
            }

            HttpCookie cookieOrigem = new HttpCookie(s_cookies);
            cookieOrigem.Domain = dominio;
            cookieOrigem = HttpContext.Current.Request.Cookies[s_cookies];

            if (cookieOrigem != null)
            {
                id = Convert.ToInt32(cookieOrigem.Value);
            }

            return id;
        }
    }
}
