using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCenbrap.Models
{
    public class ListBlogView
    {
        public List<Blog> blog { get; set; }
        public List<string> categorias { get; set; }
        public string categoria { get; set; }
        public string busca { get; set; }
        public List<Blog> lidas { get; set; }

        public ListBlogView(string categoria = "", string busca = "")
        {
            CursoDB db = new CursoDB();

            this.busca = busca;
            this.categoria = categoria;
            this.blog = new BlogDB().Publicados(categoria, busca, "cenbrap.com.br");
            this.categorias = new BlogDB().Categorias("cenbrap.com.br");
        }

    }

    public class BlogView
    {
        public Blog blog { get; set; }
        public List<Blog> lidas { get; set; }

        public BlogView(string tituloUrl)
        {
            this.blog = new BlogDB().Buscar(tituloUrl, "cenbrap.com.br");
            new BlogDB().GravaAcesso(this.blog.blog_id);
            this.lidas = new BlogDB().MaisLidas(this.blog.blog_id);
        }
    }
}