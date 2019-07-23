using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Blog_tag
    {
        public Blog blog_id { get; set; }
        public string tag { get; set; }

        public Blog_tag()
        {
            this.blog_id = new Blog();
            this.tag = "";
        }

        public Blog_tag(Blog blog_id, string tag)
        {
            this.blog_id = blog_id;
            this.tag = tag;
        }

        public void Salvar()
        {
            Blog_tagDB db = new Blog_tagDB();
            if (db.Buscar(this.blog_id.blog_id, this.tag) == null)
            {
                db.Salvar(this);
            }
        }

        public void Excluir()
        {
            new Blog_tagDB().Excluir(this);
        }
    }
}
