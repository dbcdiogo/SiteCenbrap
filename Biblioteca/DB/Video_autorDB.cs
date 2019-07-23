using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Video_autorDB
    {
        public void Salvar(Video_autor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO video_autor (video_id, autor_id) VALUES (@video_id, @autor_id) ");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("autor_id", variavel.autor_id.autor_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Video_autor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM video_autor WHERE video_id = @video_id AND autor_id = @autor_id;");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("autor_id", variavel.autor_id.autor_id);
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
                Query query = session.CreateQuery("DELETE FROM video_autor WHERE video_id = @video_id");
                query.SetParameter("video_id", variavel.video_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Video_autor> Listar()
        {
            try
            {
                List<Video_autor> video_autor = new List<Video_autor>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(autor_id, 0) as autor_id FROM video_autor ORDER BY autor_id");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_autor.Add(new Video_autor(new Video(Convert.ToInt32(reader["video_id"])), new Autor(Convert.ToInt32(reader["autor_id"]))));
                }
                reader.Close();
                session.Close();

                return video_autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video_autor> Listar(Autor autor)
        {
            try
            {
                List<Video_autor> video_autor = new List<Video_autor>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(autor_id, 0) as autor_id FROM video_autor WHERE autor_id = @autor_id ORDER BY autor_id");
                query.SetParameter("autor_id", autor.autor_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_autor.Add(new Video_autor(new Video(Convert.ToInt32(reader["video_id"])), autor));
                }
                reader.Close();
                session.Close();

                return video_autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video_autor> Listar(Video video)
        {
            try
            {
                List<Video_autor> video_autor = new List<Video_autor>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(autor_id, 0) as autor_id FROM video_autor WHERE video_id = @video_id ORDER BY autor_id");
                query.SetParameter("video_id", video.video_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_autor.Add(new Video_autor(video, new Autor(Convert.ToInt32(reader["autor_id"]))));
                }
                reader.Close();
                session.Close();

                return video_autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
