using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Video_categoriaDB
    {
        public void Salvar(Video_categoria variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO video_categoria (video_id, categoria_id) VALUES (@video_id, @categoria_id) ");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("categoria_id", variavel.categoria_id.categoria_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Video_categoria variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM video_categoria WHERE video_id = @video_id AND categoria_id = @categoria_id;");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("categoria_id", variavel.categoria_id.categoria_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM video_categoria WHERE video_id = @video_id");
                query.SetParameter("video_id", variavel.video_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Video_categoria> Listar()
        {
            try
            {
                List<Video_categoria> video_categoria = new List<Video_categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(categoria_id, 0) as categoria_id FROM video_categoria ORDER BY categoria_id");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_categoria.Add(new Video_categoria(new Video(Convert.ToInt32(reader["video_id"])), new Categoria(Convert.ToInt32(reader["categoria_id"]))));
                }
                reader.Close();
                session.Close();

                return video_categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video_categoria> Listar(Categoria categoria)
        {
            try
            {
                List<Video_categoria> video_categoria = new List<Video_categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(categoria_id, 0) as categoria_id FROM video_categoria WHERE categoria_id = @categoria_id ORDER BY categoria_id");
                query.SetParameter("categoria_id", categoria.categoria_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_categoria.Add(new Video_categoria(new Video(Convert.ToInt32(reader["video_id"])), categoria));
                }
                reader.Close();
                session.Close();

                return video_categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video_categoria> Listar(Video video)
        {
            try
            {
                List<Video_categoria> video_categoria = new List<Video_categoria>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(categoria_id, 0) as categoria_id FROM video_categoria WHERE video_id = @video_id ORDER BY categoria_id");
                query.SetParameter("video_id", video.video_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_categoria.Add(new Video_categoria(video, new Categoria(Convert.ToInt32(reader["categoria_id"]))));
                }
                reader.Close();
                session.Close();

                return video_categoria;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
