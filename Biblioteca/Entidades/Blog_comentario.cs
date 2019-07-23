using System;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Blog_comentario
    {
        public int blog_comentario_id { get; set; }
        public Blog blog_id { get; set; }
        public bool visualizar { get; set; }
        public Blog_comentario replica { get; set; }
        public DateTime data { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string texto { get; set; }

        public Blog_comentario()
        {
            this.blog_comentario_id = 0;
            this.blog_id = new Blog(0);
            this.replica = new Blog_comentario(0);
            this.data = DateTime.Now;
            this.visualizar = false;
            this.nome = "";
            this.nome = "";
            this.email = "";
            this.texto = "";
        }

        public Blog_comentario(int id)
        {
            this.blog_comentario_id = id;
            this.blog_id = new Blog(0);
            this.replica = new Blog_comentario(0);
            this.data = DateTime.Now;
            this.nome = "";
            this.visualizar = false;
            this.email = "";
            this.texto = "";
        }

        public Blog_comentario(int blog_comentario_id, Blog blog_id, bool visualizar, Blog_comentario replica, DateTime data, string nome, string email, string texto)
        {
            this.blog_comentario_id = blog_comentario_id;
            this.blog_id = blog_id;
            this.visualizar = visualizar;
            this.replica = replica;
            this.data = data;
            this.nome = nome;
            this.email = email;
            this.texto = texto;
        }

        public void Salvar()
        {
            this.blog_comentario_id = new Blog_comentarioDB().Salvar(this);
        }

        public void Alterar()
        {
            new Blog_comentarioDB().Alterar(this);
        }

        public void Excluir()
        {
            new Blog_comentarioDB().Excluir(this);
        }
    }
}
