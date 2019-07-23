using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class CategoriaDB
    {
        public void Salvar(Categoria variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO categoria (titulo) VALUES (@titulo) ");
                query.SetParameter("titulo", variavel.titulo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Categoria variavel)
        {
            try
            {
                Salvar(variavel);

                return Buscar(variavel.titulo).categoria_id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Categoria variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE categoria SET titulo = @titulo WHERE categoria_id = @categoria_id");
                query.SetParameter("titulo", variavel.titulo)
                .SetParameter("categoria_id", variavel.categoria_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Categoria variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM categoria WHERE categoria_id = @categoria_id; DELETE FROM video_categoria WHERE categoria_id = @categoria_id;");
                query.SetParameter("categoria_id", variavel.categoria_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Categoria> Listar()
        {
            try
            {
                List<Categoria> categoria = new List<Categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(categoria_id, 0) as categoria_id, isnull(titulo, '') as titulo FROM categoria ORDER BY titulo");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    categoria.Add(new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"])));
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Categoria> ListarComVideo()
        {
            try
            {
                List<Categoria> categoria = new List<Categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(categoria_id, 0) as categoria_id, isnull(titulo, '') as titulo FROM categoria WHERE EXISTS (SELECT * FROM video_categoria WHERE categoria.categoria_id = video_categoria.categoria_id) ORDER BY titulo");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    categoria.Add(new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"])));
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Categoria> Listar(Video video)
        {
            try
            {
                List<Categoria> categoria = new List<Categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(c.categoria_id, 0) as categoria_id, isnull(c.titulo, '') as titulo FROM categoria as c INNER JOIN video_categoria as vc ON c.categoria_id = vc.categoria_id WHERE vc.video_id = @video_id ORDER BY c.titulo").SetParameter("video_id", video.video_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    categoria.Add(new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"])));
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Categoria Buscar(int id)
        {
            try
            {
                Categoria categoria = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(categoria_id, 0) as categoria_id, isnull(titulo, '') as titulo FROM categoria WHERE categoria_id = @categoria_id ORDER BY titulo");
                query.SetParameter("categoria_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    categoria = new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"]));
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Categoria Buscar(string titulo)
        {
            try
            {
                Categoria categoria = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(categoria_id, 0) as categoria_id, isnull(titulo, '') as titulo FROM categoria WHERE titulo = @titulo ORDER BY titulo");
                query.SetParameter("titulo", titulo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    categoria = new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"]));
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public int ListarAleatorio()
        {
            try
            {
                int retorno = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select TOP 1 categoria_id from categoria where categoria_id <> 12 ORDER BY NEWID()");
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["categoria_id"]);
                }
                reader.Close();
                session.Close();

                return retorno;

                
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Categoria> ListarTimeline(int pagina = 1)
        {
            try
            {
                List<Categoria> dataLote = new List<Categoria>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM categoria ORDER BY titulo OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"])));
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

        public List<Categoria> ListarTimeline(int pagina = 1, string titulo = "")
        {
            try
            {
                List<Categoria> dataLote = new List<Categoria>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM categoria WHERE titulo like '%" + titulo.Replace(" ", "%") + "%' ORDER BY titulo OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("titulo", titulo);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Categoria(Convert.ToInt32(reader["categoria_id"]), Convert.ToString(reader["titulo"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM categoria");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string titulo = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM categoria WHERE titulo like '%" + titulo.Replace(" ", "%") + "%'");
            quey.SetParameter("titulo", titulo);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public void ExcluirCategoriasBlog(int id)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM blog_categoria WHERE idblog = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarCategoriaBlog(int id, string categoria)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO blog_categoria (idblog, txcategoria) VALUES (@id, @categoria) ");
                query.SetParameter("id", id);
                query.SetParameter("categoria", categoria);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
    
}
