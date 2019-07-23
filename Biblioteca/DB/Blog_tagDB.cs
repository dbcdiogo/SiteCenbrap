using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Blog_tagDB
    {
        public void Salvar(Blog_tag variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Blog_tag (blog_id, tag) VALUES (@blog_id, @tag) ");
                query.SetParameter("blog_id", variavel.blog_id.blog_id)
                    .SetParameter("tag", variavel.tag);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Blog_tag variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_tag WHERE blog_id = @blog_id AND tag = @tag");
                query.SetParameter("blog_id", variavel.blog_id.blog_id)
                    .SetParameter("tag", variavel.tag);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Limpar(Blog variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_tag WHERE blog_id = @blog_id");
                query.SetParameter("blog_id", variavel.blog_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Limpar(Blog variavel, string tags)
        {
            try
            {
                string s_tag = "";

                if(tags.IndexOf(",") > -1)
                {
                    int cont = 0;
                    foreach(var t in tags.Split(','))
                    {
                        cont++;
                        if (cont > 1)
                            s_tag += ",";
                        s_tag += "'" + t.TrimStart().TrimEnd() + "'";
                    }
                }
                else
                {
                    s_tag = "'" + tags + "'";
                }

                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_tag WHERE blog_id = @blog_id and tag not in (" + s_tag + ")");
                query.SetParameter("blog_id", variavel.blog_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        public Blog_tag Buscar(int id, string tag)
        {
            try
            {
                Blog_tag Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(tag, '') AS tag FROM Blog_tag WHERE blog_id = @blog_id and tag = @tag");
                quey.SetParameter("blog_id", id)
                    .SetParameter("tag", tag);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog_tag(new Blog(Convert.ToInt32(reader["blog_id"])), Convert.ToString(reader["tag"]));
                }
                reader.Close();
                session.Close();

                return Blog;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Blog_tag> Listar(Blog blog)
        {
            try
            {
                List<Blog_tag> list = new List<Blog_tag>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(tag, '') AS tag FROM Blog_tag WHERE blog_id = @blog_id");
                quey.SetParameter("blog_id", blog.blog_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new Blog_tag(blog, Convert.ToString(reader["tag"])));
                }
                reader.Close();
                session.Close();

                return list;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
