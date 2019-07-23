using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_videoDB
    {
        public void Salvar(Aluno_video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_video (video_id, aluno, data, tempo) VALUES (@video_id, @aluno, @data, @tempo) ");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("tempo", variavel.tempo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Aluno_video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_video WHERE video_id = @video_id AND aluno = @aluno AND data = @data;");
                query.SetParameter("video_id", variavel.video_id.video_id)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void VerificaSeExiste(Aluno_video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select count(*) FROM aluno_video WHERE aluno = @aluno AND video = @video AND data >= @data")
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("video", variavel.video_id.video_id)
                    .SetParameter("data", variavel.data.AddDays(-7));
                IDataReader reader = query.ExecuteQuery();

                if (!reader.Read())
                {
                    Salvar(variavel);

                }
                reader.Close();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_video> Listar()
        {
            try
            {
                List<Aluno_video> aluno_video = new List<Aluno_video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data FROM aluno_video ORDER BY aluno");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_video.Add(new Aluno_video(new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Video(Convert.ToInt32(reader["video_id"])), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_video> Listar(Aluno aluno)
        {
            try
            {
                List<Aluno_video> aluno_video = new List<Aluno_video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(av.video_id, 0) as video_id, isnull(v.titulo, '') as titulo, isnull(av.aluno, 0) as aluno, isnull(av.data, '01/01/1900') as data FROM aluno_video AS av INNER JOIN video as v ON av.video_id = v.video_id WHERE av.aluno = @aluno ORDER BY av.data desc");
                query.SetParameter("aluno", aluno.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_video.Add(new Aluno_video(aluno, new Video() {video_id = Convert.ToInt32(reader["video_id"]) , titulo = Convert.ToString(reader["titulo"])}, Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_video> Listar(Video video)
        {
            try
            {
                List<Aluno_video> aluno_video = new List<Aluno_video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data FROM aluno_video ORDER BY aluno");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_video.Add(new Aluno_video(new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Video(Convert.ToInt32(reader["video_id"])), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public string Tempo(Aluno aluno, Video video)
        {
            try
            {
                string time = "0";

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top 1 isnull(tempo,0) as tempo from aluno_video where aluno = @aluno and video_id = @video order by data desc");
                query.SetParameter("aluno", aluno.codigo);
                query.SetParameter("video", video.video_id);
                IDataReader reader = query.ExecuteQuery();
                if (reader.Read())
                {
                    time = Convert.ToString(reader["tempo"]);
                }
                reader.Close();
                session.Close();

                return time;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void TempoGrava(Aluno aluno, int id, string seg)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE aluno_video SET tempo = @segundos FROM aluno_video where aluno = @aluno and video_id = @video and data = (select top(1) data from aluno_video where aluno = @aluno and video_id = @video order by data desc)");
                query.SetParameter("segundos", seg)
                    .SetParameter("aluno", aluno.codigo)
                    .SetParameter("video", id);
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
