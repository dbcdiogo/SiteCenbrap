using Biblioteca.DB;
using System;
using System.Collections.Generic;

namespace Biblioteca.Entidades
{
    public class Blog
    {
        public int blog_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public DateTime publicarEm { get; set; }
        public bool publicado { get; set; }
        public string autor { get; set; }
        public string imagem { get; set; }
        public string titulo { get; set; }
        public string tituloUrl { get; set; }
        public string subtitulo { get; set; }
        public string categoria { get; set; }
        public string texto { get; set; }
        public string fonteOrigem { get; set; }
        public string dominio { get; set; }
        public string tituloseo { get; set; }
        public string descricaoseo { get; set; }
        public string titulofacebook { get; set; }
        public string descricaofacebook { get; set; }
        public string titulotwitter { get; set; }
        public string descricaotwitter { get; set; }
        public string keyword { get; set; }
        public int pontos { get; set; }

        public List<Blog_tag> tags { get; set; }

        public int qtdComentarios { get; set; } = 0;

        public Blog()
        {
            this.blog_id = 0;
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
            this.publicarEm = DateTime.Now;
            this.publicado = false;
            this.autor = "";
            this.imagem = "";
            this.titulo = "";
            this.tituloUrl = "";
            this.subtitulo = "";
            this.texto = "";
            this.categoria = "";
            this.dominio = "cenbrap.com.br";
            this.tituloseo = "";
            this.descricaoseo = "";
            this.titulofacebook = "";
            this.descricaofacebook = "";
            this.titulotwitter = "";
            this.descricaotwitter = "";
            this.keyword = "";
            this.pontos = 0;

            this.tags = new List<Blog_tag>();
        }

        public Blog(int id)
        {
            this.blog_id = id;
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
            this.publicarEm = DateTime.Now;
            this.publicado = false;
            this.autor = "";
            this.imagem = "";
            this.titulo = "";
            this.tituloUrl = "";
            this.subtitulo = "";
            this.texto = "";
            this.categoria = "";
            this.fonteOrigem = "";
            this.dominio = "cenbrap.com.br";
            this.tituloseo = "";
            this.descricaoseo = "";
            this.titulofacebook = "";
            this.descricaofacebook = "";
            this.titulotwitter = "";
            this.descricaotwitter = "";
            this.keyword = "";
            this.pontos = 0;

            this.tags = new List<Blog_tag>();

        }

        public Blog(int blog_id, Painel painel, DateTime data, DateTime publicarEm, bool publicado, string autor, string imagem, string titulo, string tituloUrl, string subtitulo, string texto, string categoria, string fonteOrigem, string dominio)
        {
            this.blog_id = blog_id;
            this.painel = painel;
            this.data = data;
            this.publicarEm = publicarEm;
            this.publicado = publicado;
            this.autor = autor;
            this.imagem = imagem;
            this.titulo = titulo;
            this.tituloUrl = tituloUrl;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.categoria = categoria;
            this.fonteOrigem = fonteOrigem;
            this.dominio = dominio;

            this.tags = new Blog_tagDB().Listar(this);
        }

        public Blog(int blog_id, Painel painel, DateTime data, DateTime publicarEm, bool publicado, string autor, string imagem, string titulo, string tituloUrl, string subtitulo, string texto, string categoria, string fonteOrigem, string dominio, int pontos)
        {
            this.blog_id = blog_id;
            this.painel = painel;
            this.data = data;
            this.publicarEm = publicarEm;
            this.publicado = publicado;
            this.autor = autor;
            this.imagem = imagem;
            this.titulo = titulo;
            this.tituloUrl = tituloUrl;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.categoria = categoria;
            this.fonteOrigem = fonteOrigem;
            this.dominio = dominio;
            this.pontos = pontos;

            this.tags = new Blog_tagDB().Listar(this);
        }

        public Blog(int blog_id, Painel painel, DateTime data, DateTime publicarEm, bool publicado, string autor, string imagem, string titulo, string tituloUrl, string subtitulo, string texto, string categoria, string fonteOrigem, string dominio, string tituloseo, string descricaoseo, string titulofacebook, string descricaofacebook, string titulotwitter, string descricaotwitter, string keyword, int pontos)
        {
            this.blog_id = blog_id;
            this.painel = painel;
            this.data = data;
            this.publicarEm = publicarEm;
            this.publicado = publicado;
            this.autor = autor;
            this.imagem = imagem;
            this.titulo = titulo;
            this.tituloUrl = tituloUrl;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.categoria = categoria;
            this.fonteOrigem = fonteOrigem;
            this.dominio = dominio;
            this.tituloseo = tituloseo;
            this.descricaoseo = descricaoseo;
            this.titulofacebook = titulofacebook;
            this.descricaofacebook = descricaofacebook;
            this.titulotwitter = titulotwitter;
            this.descricaotwitter = descricaotwitter;
            this.keyword = keyword;
            this.pontos = pontos;

            this.tags = new Blog_tagDB().Listar(this);
        }

        public Blog(int blog_id, string titulo, string tituloUrl)
        {
            this.blog_id = blog_id;
            this.titulo = titulo;
            this.tituloUrl = tituloUrl;
        }

        public void Salvar()
        {
            this.blog_id = new BlogDB().Salvar(this);
        }

        public void Alterar()
        {
            new BlogDB().Alterar(this);
        }

        public void Excluir()
        {
            new BlogDB().Excluir(this);
        }

        public string PublicarEmData()
        {
            //return this.publicarEm.Year + "-" + this.publicarEm.Month + "-" + this.publicarEm.Day;
            return this.publicarEm.ToShortDateString();
            //return this.publicarEm.Year + "-" + this.publicarEm.Month + "-" + this.publicarEm.Day + " " + this.publicarEm.Hour + ":" + this.publicarEm.Minute + ":" + this.publicarEm.Second;
        }
    }
}
