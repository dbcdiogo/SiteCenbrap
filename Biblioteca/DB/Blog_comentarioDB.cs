using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DB
{
    public class Blog_comentarioDB
    {
        public int Salvar(Blog_comentario variavel)
        {
            try
            {
                int retorno = 0;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Blog_comentario (blog_id,replica,data,nome,email,texto,visualizar) VALUES (@blog_id,@replica,@data,@nome,@email,@texto,@visualizar) ");
                query.SetParameter("blog_id", variavel.blog_id.blog_id)
                    .SetParameter("replica", variavel.replica.blog_comentario_id)
                    .SetParameter("visualizar", variavel.visualizar)
                    .SetParameter("data", variavel.data)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();

                DBSession sessionBusca = new DBSession();
                query = sessionBusca.CreateQuery("SELECT blog_comentario_id FROM Blog WHERE blog_id = @blog_id AND replica = @replica AND data = @data AND nome = @nome AND email = @email AND texto = @texto AND visualizar = @visualizar ORDER BY blog_comentario_id DESC");
                query.SetParameter("blog_id", variavel.blog_id.blog_id)
                    .SetParameter("replica", variavel.replica.blog_comentario_id)
                    .SetParameter("visualizar", variavel.visualizar)
                    .SetParameter("data", variavel.data)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("texto", variavel.texto);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["blog_comentario_id"]);
                }
                reader.Close();
                sessionBusca.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Blog_comentario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Blog_comentario SET blog_id = @blog_id, visualizar = @visualizar, replica = @replica, data = @data, nome = @nome, email = @email, texto = @texto WHERE blog_comentario_id = @blog_comentario_id");
                query.SetParameter("blog_id", variavel.blog_id.blog_id)
                    .SetParameter("replica", variavel.replica.blog_comentario_id)
                    .SetParameter("visualizar", variavel.visualizar)
                    .SetParameter("data", variavel.data)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("blog_comentario_id", variavel.blog_comentario_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Blog_comentario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_comentario WHERE blog_comentario_id = @blog_comentario_id;");
                query.SetParameter("blog_comentario_id", variavel.blog_comentario_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Blog_comentario Buscar(int id)
        {
            try
            {
                Blog_comentario Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_comentario_id, 0) AS blog_comentario_id, isnull(blog_id,   0) AS blog_id, isnull(visualizar, 0) AS visualizar, isnull(replica,  0) AS replica, isnull(data, '1900-01-01') AS data, isnull(nome, '') AS nome, isnull(email, '') AS email, isnull(texto, '') AS texto FROM blog_comentario WHERE blog_comentario_id = @blog_comentario_id");
                quey.SetParameter("blog_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog_comentario(Convert.ToInt32(reader["blog_comentario_id"]), new Blog(Convert.ToInt32(reader["blog_id"])), Convert.ToBoolean(reader["visualizar"]), new Blog_comentario(Convert.ToInt32(reader["replica"])), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["texto"]));
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

        public List<Blog_comentario> Listar()
        {
            try
            {
                List<Blog_comentario> Blog = new List<Blog_comentario>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_comentario_id, 0) AS blog_comentario_id, isnull(blog_id,   0) AS blog_id, isnull(visualizar, 0) AS visualizar, isnull(replica,  0) AS replica, isnull(data, '1900-01-01') AS data, isnull(nome, '') AS nome, isnull(email, '') AS email, isnull(texto, '') AS texto FROM blog_comentario ORDER BY data");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog_comentario(Convert.ToInt32(reader["blog_comentario_id"]), new Blog(Convert.ToInt32(reader["blog_id"])), Convert.ToBoolean(reader["visualizar"]), new Blog_comentario(Convert.ToInt32(reader["replica"])), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["texto"])));
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

        public List<Blog_comentario> Aguardando()
        {
            try
            {
                List<Blog_comentario> Blog = new List<Blog_comentario>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_comentario_id, 0) AS blog_comentario_id, isnull(blog_id,   0) AS blog_id, isnull(visualizar, 0) AS visualizar, isnull(replica,  0) AS replica, isnull(data, '1900-01-01') AS data, isnull(nome, '') AS nome, isnull(email, '') AS email, isnull(texto, '') AS texto FROM blog_comentario WHERE visualizar = 0 ORDER BY data");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog_comentario(Convert.ToInt32(reader["blog_comentario_id"]), new Blog(Convert.ToInt32(reader["blog_id"])), Convert.ToBoolean(reader["visualizar"]), new Blog_comentario(Convert.ToInt32(reader["replica"])), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["texto"])));
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

        public List<Blog_comentario> Ativos(Blog blog)
        {
            try
            {
                List<Blog_comentario> Blog = new List<Blog_comentario>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_comentario_id, 0) AS blog_comentario_id, isnull(blog_id,   0) AS blog_id, isnull(visualizar, 0) AS visualizar, isnull(replica,  0) AS replica, isnull(data, '1900-01-01') AS data, isnull(nome, '') AS nome, isnull(email, '') AS email, isnull(texto, '') AS texto FROM blog_comentario WHERE visualizar = 1 AND blog = @blog_id ORDER BY data");
                quey.SetParameter("blog_id", blog.blog_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog_comentario(Convert.ToInt32(reader["blog_comentario_id"]), new Blog(Convert.ToInt32(reader["blog_id"])), Convert.ToBoolean(reader["visualizar"]), new Blog_comentario(Convert.ToInt32(reader["replica"])), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["texto"])));
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

    }
}
