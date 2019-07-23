using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Video_tagsDB
    {
        public void Salvar(Video_tags variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO video_tags (video_id, tag) VALUES (@video_id, @tag) ");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("tag", variavel.tag);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        public void Excluir(Video_tags variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM video_tags WHERE video_id = @video_id AND tag = @tag;");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("tag", variavel.tag);
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
                Query query = session.CreateQuery("DELETE FROM video_tags WHERE video_id = @video_id");
                query.SetParameter("video_id", variavel.video_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Video_tags> Listar()
        {
            try
            {
                List<Video_tags> video_tags = new List<Video_tags>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(tag, '') as tag FROM video_tags ORDER BY tag");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_tags.Add(new Video_tags(new Video(Convert.ToInt32(reader["video_id"])), Convert.ToString(reader["tag"])));
                }
                reader.Close();
                session.Close();

                return video_tags;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video_tags> Listar(int id)
        {
            try
            {
                List<Video_tags> video_tags = new List<Video_tags>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(tag, '') as tag FROM video_tags WHERE video_id = @id ORDER BY tag");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video_tags.Add(new Video_tags(new Video(Convert.ToInt32(reader["video_id"])), Convert.ToString(reader["tag"])));
                }
                reader.Close();
                session.Close();

                return video_tags;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
