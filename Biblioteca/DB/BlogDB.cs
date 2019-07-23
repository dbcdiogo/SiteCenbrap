using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class BlogDB
    {
        public int Salvar(Blog variavel)
        {
            try
            {
                int retorno = 0;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Blog (painel,data,publicarEm,publicado,autor,imagem,titulo,tituloUrl,subtitulo,texto,categoria,fonteOrigem,dominio,tituloseo,descricaoseo,titulofacebook,descricaofacebook,titulotwitter,descricaotwitter,keyword,pontos) VALUES (@painel,@data,@publicarEm,@publicado,@autor,@imagem,@titulo,@tituloUrl,@subtitulo,@texto,@categoria,@fonteOrigem,@dominio,@tituloseo,@descricaoseo,@titulofacebook,@descricaofacebook,@titulotwitter,@descricaotwitter,@keyword,@pontos) ");
                query.SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("publicarEm", variavel.publicarEm)
                    .SetParameter("publicado", variavel.publicado)
                    .SetParameter("autor", variavel.autor)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("tituloUrl", variavel.tituloUrl)
                    .SetParameter("subtitulo", variavel.subtitulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("categoria", variavel.categoria)
                    .SetParameter("fonteOrigem", variavel.fonteOrigem)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("tituloseo", variavel.tituloseo)
                    .SetParameter("descricaoseo", variavel.descricaoseo)
                    .SetParameter("titulofacebook", variavel.titulofacebook)
                    .SetParameter("descricaofacebook", variavel.descricaofacebook)
                    .SetParameter("titulotwitter", variavel.titulotwitter)
                    .SetParameter("descricaotwitter", variavel.descricaotwitter)
                    .SetParameter("keyword", variavel.keyword)
                    .SetParameter("pontos", variavel.pontos);
                query.ExecuteUpdate();
                session.Close();

                DBSession sessionBusca = new DBSession();
                query = sessionBusca.CreateQuery("SELECT blog_id FROM Blog WHERE painel = @painel AND data = @data AND publicarEm = @publicarEm AND autor = @autor AND imagem = @imagem AND titulo = @titulo AND titulourl = @titulourl AND subtitulo = @subtitulo AND categoria = @categoria AND fonteOrigem = @fonteOrigem ORDER BY blog_id DESC");
                query.SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("publicarEm", variavel.publicarEm)
                    .SetParameter("publicado", variavel.publicado)
                    .SetParameter("autor", variavel.autor)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("tituloUrl", variavel.tituloUrl)
                    .SetParameter("subtitulo", variavel.subtitulo)
                    .SetParameter("categoria", variavel.categoria)
                    .SetParameter("fonteOrigem", variavel.fonteOrigem);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["blog_id"]);
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

        public void Alterar(Blog variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE blog SET painel = @painel, data = @data, publicarEm = @publicarEm, publicado = @publicado, autor = @autor, imagem = @imagem, titulo = @titulo, tituloUrl = @tituloUrl, subtitulo = @subtitulo, texto = @texto, categoria = @categoria, fonteOrigem = @fonteOrigem, dominio = @dominio, tituloseo = @tituloseo, descricaoseo = @descricaoseo, titulofacebook = @titulofacebook, descricaofacebook = @descricaofacebook, titulotwitter = @titulotwitter, descricaotwitter = @descricaotwitter, keyword = @keyword, pontos = @pontos WHERE blog_id = @blog_id");
                query.SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("publicarEm", variavel.publicarEm)
                    .SetParameter("publicado", variavel.publicado)
                    .SetParameter("autor", variavel.autor)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("tituloUrl", variavel.tituloUrl)
                    .SetParameter("subtitulo", variavel.subtitulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("categoria", variavel.categoria)
                    .SetParameter("blog_id", variavel.blog_id)
                    .SetParameter("fonteOrigem", variavel.fonteOrigem)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("tituloseo", variavel.tituloseo)
                    .SetParameter("descricaoseo", variavel.descricaoseo)
                    .SetParameter("titulofacebook", variavel.titulofacebook)
                    .SetParameter("descricaofacebook", variavel.descricaofacebook)
                    .SetParameter("titulotwitter", variavel.titulotwitter)
                    .SetParameter("descricaotwitter", variavel.descricaotwitter)
                    .SetParameter("keyword", variavel.keyword)
                    .SetParameter("pontos", variavel.pontos);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Blog variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_comentario WHERE blog_id = @blog_id; DELETE FROM blog_tag WHERE blog_id = @blog_id; DELETE FROM blog WHERE blog_id = @blog_id; ");
                query.SetParameter("blog_id", variavel.blog_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Blog Buscar(int id)
        {
            try
            {
                Blog Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE blog_id = @blog_id");
                quey.SetParameter("blog_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]));
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

        public Blog BuscarCompleto(int id)
        {
            try
            {
                Blog Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio, isnull(tituloseo, '') AS tituloseo, isnull(descricaoseo, '') AS descricaoseo, isnull(titulofacebook, '') AS titulofacebook, isnull(descricaofacebook, '') AS descricaofacebook, isnull(titulotwitter, '') AS titulotwitter, isnull(descricaotwitter, '') AS descricaotwitter, isnull(keyword, '') as keyword, isnull(pontos,0) as pontos FROM Blog WHERE blog_id = @blog_id");
                quey.SetParameter("blog_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["tituloseo"]), Convert.ToString(reader["descricaoseo"]), Convert.ToString(reader["titulofacebook"]), Convert.ToString(reader["descricaofacebook"]), Convert.ToString(reader["titulotwitter"]), Convert.ToString(reader["descricaotwitter"]), Convert.ToString(reader["keyword"]), Convert.ToInt32(reader["pontos"]));
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

        public Blog Buscar(string tituloUrl = "", string dominio = "cenbrap.com.br")
        {
            try
            {
                Blog Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE tituloUrl = @tituloUrl AND dominio = @dominio");
                quey.SetParameter("dominio", dominio);
                quey.SetParameter("tituloUrl", tituloUrl);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]));
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

        public Blog Buscar(string tituloUrl)
        {
            try
            {
                Blog Blog = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE tituloUrl = @tituloUrl");
                quey.SetParameter("tituloUrl", tituloUrl);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Blog = new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]));
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

        public List<Blog> ListarSistema(string dominio = "")
        {
            try
            {
                List<Blog> Blog = new List<Blog>();

                string executar = "SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio, isnull(pontos, 0) as pontos FROM Blog";
                if (dominio != "")
                    executar += " WHERE dominio = '" + dominio + "'";
                executar += " ORDER BY publicarEm DESC";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]), Convert.ToInt32(reader["pontos"])));
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

        public List<Blog> Listar(string dominio = "cenbrap.com.br")
        {
            try
            {
                List<Blog> Blog = new List<Blog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE dominio = @dominio ORDER BY publicarEm DESC");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"])));
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

        public List<Blog> Publicados(string categoria = "", string busca = "", string dominio = "cenbrap.com.br")
        {
            try
            {
                string query = "SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE publicarEm <= getdate() AND dominio = @dominio";
                if(categoria != "")
                {
                    query += " AND categoria = @categoria";

                }
                if (busca != "")
                {
                    string queryTitulo = " (titulo LIKE '%" + busca + "%'";
                    string querySubtitulo = " (subtitulo LIKE '%" + busca + "%'";
                    string queryTexto = " (texto LIKE '%" + busca + "%'";
                    char ch = ' ';
                    if (busca.IndexOf(ch) > 0)
                    {
                        queryTitulo += (" OR (");
                        querySubtitulo += (" OR (");
                        queryTexto += (" OR (");
                        char[] separator = new char[] { ch };
                        string[] strArray = busca.Split(separator);
                        int num = 0;
                        foreach (string str in strArray)
                        {
                            if (num > 0)
                            {
                                queryTitulo += (" AND ");
                                querySubtitulo += (" AND ");
                                queryTexto += (" AND ");
                            }
                            queryTitulo += ("titulo LIKE '%" + str + "%'");
                            querySubtitulo += ("titulo LIKE '%" + str + "%'");
                            queryTexto += ("titulo LIKE '%" + str + "%'");
                            num = 1;
                        }
                        queryTitulo += (")");
                        querySubtitulo += (")");
                        queryTexto += (")");
                    }
                    queryTitulo += (")");
                    querySubtitulo += (")");
                    queryTexto += (")");

                    query += " AND (" + queryTitulo + " OR " + querySubtitulo + " OR " + queryTexto + ")";
                }

                List<Blog> Blog = new List<Blog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(query + " ORDER BY publicarEm DESC");
                quey.SetParameter("dominio", dominio);
                if (categoria != "")
                    quey.SetParameter("categoria", categoria);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"])));
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

        public int TotalPublicados(string categoria = "", string busca = "", string dominio = "cenbrap.com.br")
        {
            try
            {
                string query = "SELECT count(blog_id) as total FROM Blog WHERE publicarEm <= getdate() AND dominio = @dominio";
                if (categoria != "")
                {
                    query += " AND categoria = @categoria";

                }
                if (busca != "")
                {
                    string queryTitulo = " (titulo LIKE '%" + busca + "%'";
                    string querySubtitulo = " (subtitulo LIKE '%" + busca + "%'";
                    string queryTexto = " (texto LIKE '%" + busca + "%'";
                    char ch = ' ';
                    if (busca.IndexOf(ch) > 0)
                    {
                        queryTitulo += (" OR (");
                        querySubtitulo += (" OR (");
                        queryTexto += (" OR (");
                        char[] separator = new char[] { ch };
                        string[] strArray = busca.Split(separator);
                        int num = 0;
                        foreach (string str in strArray)
                        {
                            if (num > 0)
                            {
                                queryTitulo += (" AND ");
                                querySubtitulo += (" AND ");
                                queryTexto += (" AND ");
                            }
                            queryTitulo += ("titulo LIKE '%" + str + "%'");
                            querySubtitulo += ("titulo LIKE '%" + str + "%'");
                            queryTexto += ("titulo LIKE '%" + str + "%'");
                            num = 1;
                        }
                        queryTitulo += (")");
                        querySubtitulo += (")");
                        queryTexto += (")");
                    }
                    queryTitulo += (")");
                    querySubtitulo += (")");
                    queryTexto += (")");

                    query += " AND (" + queryTitulo + " OR " + querySubtitulo + " OR " + queryTexto + ")";
                }

                int total = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(query);
                quey.SetParameter("dominio", dominio);
                if (categoria != "")
                    quey.SetParameter("categoria", categoria);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader["total"]);
                }

                reader.Close();
                session.Close();

                return total;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Blog> Publicados(string categoria = "", string busca = "", string dominio = "cenbrap.com.br", int pagina = 1, int qtdade = 6)
        {
            try
            {
                string query = "SELECT isnull(blog_id, 0) AS blog_id, isnull(painel,   0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio FROM Blog WHERE publicarEm <= getdate() AND dominio = @dominio";
                if (categoria != "")
                {
                    query += " AND categoria = @categoria";

                }
                if (busca != "")
                {
                    string queryTitulo = " (titulo LIKE '%" + busca + "%'";
                    string querySubtitulo = " (subtitulo LIKE '%" + busca + "%'";
                    string queryTexto = " (texto LIKE '%" + busca + "%'";
                    char ch = ' ';
                    if (busca.IndexOf(ch) > 0)
                    {
                        queryTitulo += (" OR (");
                        querySubtitulo += (" OR (");
                        queryTexto += (" OR (");
                        char[] separator = new char[] { ch };
                        string[] strArray = busca.Split(separator);
                        int num = 0;
                        foreach (string str in strArray)
                        {
                            if (num > 0)
                            {
                                queryTitulo += (" AND ");
                                querySubtitulo += (" AND ");
                                queryTexto += (" AND ");
                            }
                            queryTitulo += ("titulo LIKE '%" + str + "%'");
                            querySubtitulo += ("titulo LIKE '%" + str + "%'");
                            queryTexto += ("titulo LIKE '%" + str + "%'");
                            num = 1;
                        }
                        queryTitulo += (")");
                        querySubtitulo += (")");
                        queryTexto += (")");
                    }
                    queryTitulo += (")");
                    querySubtitulo += (")");
                    queryTexto += (")");

                    query += " AND (" + queryTitulo + " OR " + querySubtitulo + " OR " + queryTexto + ")";
                }

                List<Blog> Blog = new List<Blog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(query + " ORDER BY publicarEm DESC OFFSET @qtdade * (@pagina - 1) ROWS FETCH NEXT @qtdade ROWS ONLY");
                quey.SetParameter("dominio", dominio);
                quey.SetParameter("qtdade", qtdade);
                quey.SetParameter("pagina", pagina);
                if (categoria != "")
                    quey.SetParameter("categoria", categoria);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Blog.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"])));
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

        public List<string> Categorias(string dominio = "cenbrap.com.br")
        {
            try
            {
                string query = "SELECT DISTINCT isnull(categoria, '') AS categoria FROM Blog WHERE dominio = @dominio GROUP BY categoria ORDER BY categoria";
                
                List<string> categorias = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(query);
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    categorias.Add(Convert.ToString(reader["categoria"]));
                }
                reader.Close();
                session.Close();

                return categorias;
            }
            catch (Exception error)
            {
               throw error;
            }
        }

        public void GravaAcesso(int id)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Blog_Acessos(blog_id, data) VALUES(@ident, getdate())");
                query.SetParameter("ident", id);                   
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Blog> MaisLidas(int id)
        {
            try
            {
                List<Blog> blog = new List<Blog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT TOP 3 isnull(ba.blog_id, 0) AS blog_id, isnull(b.titulo, '') AS titulo, isnull(b.tituloUrl, '') AS tituloUrl FROM Blog_Acessos ba INNER JOIN Blog b ON b.blog_id = ba.blog_id WHERE ba.blog_id <> @ident GROUP BY ba.blog_id, b.titulo, b.tituloUrl ORDER BY count(ba.blog_id) desc");
                quey.SetParameter("ident", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    blog.Add(new Blog(Convert.ToInt32(reader["blog_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"])));
                }
                reader.Close();
                session.Close();

                return blog;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int VerificaKeyword(int id, string key)
        {
            try
            {
                int cont = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT count(*) as total FROM Blog WHERE lower(keyword) = lower(@keyword) AND blog_id <> @blog_id ");
                quey.SetParameter("keyword", key)
                    .SetParameter("blog_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cont = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
                session.Close();

                return cont;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Blog> Listar(int pagina = 1)
        {
            try
            {
                List<Blog> dataLote = new List<Blog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(blog_id, 0) AS blog_id, isnull(painel, 0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio, isnull(pontos, 0) as pontos FROM blog ORDER BY publicarEm DESC OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]), Convert.ToInt32(reader["pontos"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Blog> Listar(int pagina = 1, string dominio = "", string titulo = "")
        {
            try
            {
                List<Blog> dataLote = new List<Blog>();

                DBSession session = new DBSession();
                string cmdtxt = "SELECT isnull(blog_id, 0) AS blog_id, isnull(painel, 0) AS painel, isnull(data, '1900-01-01') AS data, isnull(publicarEm, '1900-01-01') AS publicarEm, isnull(publicado,  0) AS publicado, isnull(autor, '') AS autor, isnull(imagem, '') AS imagem, isnull(titulo, '') AS titulo, isnull(tituloUrl, '') AS tituloUrl, isnull(subtitulo, '') AS subtitulo, isnull(texto, '') AS texto, isnull(categoria, '') AS categoria, isnull(fonteOrigem, '') AS fonteOrigem, isnull(dominio, '') AS dominio, isnull(pontos, 0) as pontos FROM blog WHERE 1=1 ";
                if (dominio != "") { cmdtxt += "AND dominio = '" + dominio + "' "; }
                if (titulo != "") { cmdtxt += "AND titulo like '%" + titulo.Replace(" ", "%") + "%' "; }
                cmdtxt += "ORDER BY publicarEm DESC OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY";
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Blog(Convert.ToInt32(reader["blog_id"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["publicarEm"]), Convert.ToBoolean(reader["publicado"]), Convert.ToString(reader["autor"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["tituloUrl"]), Convert.ToString(reader["subtitulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["categoria"]), Convert.ToString(reader["fonteOrigem"]), Convert.ToString(reader["dominio"]), Convert.ToInt32(reader["pontos"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM blog");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string dominio = "", string titulo = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            string cmdtxt = "SELECT count(*) as total FROM blog WHERE 1=1";
            if (dominio != "") { cmdtxt += "AND dominio = '" + dominio + "'";  }
            if (titulo != "") { cmdtxt += "AND titulo like '%" + titulo.Replace(" ","%") + "%'"; }
            Query quey = session.CreateQuery(cmdtxt);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

    }
}
