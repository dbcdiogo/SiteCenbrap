using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;
using System.Web;

namespace Biblioteca.DB
{
    public class VideoDB
    {
        public void Salvar(Video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO video (link, titulo, descricao, imagem, data, tempo, gratuito, trailer_id,codigo,exibir) VALUES (@link, @titulo, @descricao, @imagem, @data, @tempo, @gratuito, @trailer_id,@codigo,@exibir) ");
                query.SetParameter("link", variavel.link)
                .SetParameter("titulo", variavel.titulo)
                .SetParameter("descricao", variavel.descricao)
                .SetParameter("imagem", variavel.imagem)
                .SetParameter("data", variavel.data)
                .SetParameter("tempo", variavel.tempo)
                .SetParameter("gratuito", variavel.gratuito)
                .SetParameter("codigo", variavel.codigo)
                .SetParameter("exibir", variavel.exibir)
                .SetParameter("trailer_id", variavel.trailer_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Video variavel)
        {
            try
            {
                Salvar(variavel);

                return Buscar(variavel.titulo, variavel.link).video_id;
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Video variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE video SET link = @link, titulo = @titulo, descricao = @descricao, data = @data, imagem = @imagem, tempo = @tempo, gratuito = @gratuito, trailer_id = @trailer_id, codigo = @codigo, exibir = @exibir WHERE video_id = @video_id");
                query.SetParameter("link", variavel.link)
                .SetParameter("titulo", variavel.titulo)
                .SetParameter("imagem", variavel.imagem)
                .SetParameter("descricao", variavel.descricao)
                .SetParameter("data", variavel.data)
                .SetParameter("tempo", variavel.tempo)
                .SetParameter("gratuito", variavel.gratuito)
                .SetParameter("video_id", variavel.video_id)
                .SetParameter("codigo", variavel.codigo)
                .SetParameter("exibir", variavel.exibir)
                .SetParameter("trailer_id", variavel.trailer_id);
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
                Query query = session.CreateQuery("DELETE FROM video WHERE video_id = @video_id; DELETE FROM video_tags WHERE video_id = @video_id; DELETE FROM video_autor WHERE video_id = @video_id; DELETE FROM video_categoria WHERE video_id = @video_id; DELETE FROM aluno_video WHERE video_id = @video_id;");
                query.SetParameter("video_id", variavel.video_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Video> Tudo()
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v ORDER BY v.data DESC"); 
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Listar()
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v left join video_categoria vc on vc.video_id = v.video_id where vc.categoria_id <> 12 AND v.exibir = 1 ORDER BY v.data DESC");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]),Convert.ToDateTime(reader["tempo"]),Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Trailers()
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v left join video_categoria vc on vc.video_id = v.video_id where vc.categoria_id = 12 and v.exibir = 1 ORDER BY v.data DESC");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Gratuitos(int qtd = 18)
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select TOP " + qtd + " isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE gratuito = 1 AND exibir = 1 ORDER BY data DESC");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> UltimosLancamentos(int qtd = 6)
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top "+qtd+ " isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE exibir = 1 ORDER BY data DESC");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> MinhaLista(int qtd = 12)
        {
            try
            {
                List<Video> video = new List<Video>();
                HttpCookie cookie = HttpContext.Current.Request.Cookies["medtv_id"];

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top " + qtd + " isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir from video v where v.exibir = 1 AND v.video_id in (select top " + qtd + " video_id from aluno_video where aluno = " + Convert.ToInt32(cookie.Value) + " group by video_id order by max(data) desc) ORDER BY v.data DESC");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> ListarAleatorio(int qtd = 12)
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top " + qtd + " isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir from video v inner join video_categoria vc on vc.video_id = v.video_id where vc.categoria_id = (select TOP 1 categoria_id from categoria where categoria_id <> 12 ORDER BY NEWID())");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Listar(string busca)
        {
            try
            {
                string b_titulo = "titulo LIKE @busca";
                string b_descricao = "descricao LIKE @busca";
                string b_categoria = "categoria.titulo LIKE @busca";
                string b_autor = "autor.nome LIKE @busca";
                string b_tags = "video_tags.tag LIKE @busca";
                string b_tag = "";

                if (busca.IndexOf(" ") > -1)
                {
                    b_titulo += " OR (";
                    b_descricao += " OR (";
                    b_categoria += " OR (";
                    b_autor += " OR (";
                    b_tags += " OR (";
                    b_tag = " OR (";
                    var a_busca = busca.Split(' ');
                    for(int i = 0; i < a_busca.Length; i++)
                    {
                        if(i > 0)
                        {
                            b_titulo += " AND ";
                            b_descricao += " AND ";
                            b_categoria += " AND ";
                            b_autor += " AND ";
                            b_tags += " AND ";
                            b_tag += " AND ";
                        }
                        b_titulo += "titulo LIKE '%"+a_busca[i]+"%'";
                        b_descricao += "descricao LIKE '%" + a_busca[i] + "%'";
                        b_categoria += "categoria.titulo LIKE '%" + a_busca[i] + "%'";
                        b_autor += "autor.nome LIKE '%" + a_busca[i] + "%'";
                        b_tags += "video_tags.tag LIKE '%" + a_busca[i] + "%'";
                        b_tag += "EXISTS (SELECT video_tags.tag FROM video_tags WHERE video_tags.video_id = video.video_id AND video_tags.tag LIKE '%" + a_busca[i] + "%')";
                    }
                    b_titulo += ")";
                    b_descricao += ")";
                    b_categoria += ")";
                    b_autor += ")";
                    b_tags += ")";
                    b_tag += ")";

                }

                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE exibir = 1 AND ((" + b_titulo + ") OR (" + b_descricao + ") OR EXISTS (SELECT video_categoria.categoria_id FROM video_categoria INNER JOIN categoria ON video_categoria.categoria_id = categoria.categoria_id WHERE video_categoria.video_id = video.video_id AND (" + b_categoria + ")) OR EXISTS (SELECT video_autor.autor_id FROM video_autor INNER JOIN autor ON video_autor.autor_id = autor.autor_id WHERE video_autor.video_id = video.video_id AND (" + b_autor + ")) OR EXISTS (SELECT video_tags.tag FROM video_tags WHERE video_tags.video_id = video.video_id AND (" + b_tags + ")) " + b_tag + ") ORDER BY data DESC");
                query.SetParameter("busca", "%" + busca + "%");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Listar(int categoria_id)
        {
            try
            {
                List<Video> video = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE exibir = 1 AND EXISTS (SELECT video_categoria.categoria_id FROM video_categoria INNER JOIN categoria ON video_categoria.categoria_id = categoria.categoria_id WHERE video_categoria.video_id = video.video_id AND categoria.categoria_id = @categoria_id) ORDER BY data DESC");
                query.SetParameter("categoria_id", categoria_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> Listar(Video video)
        {
            try
            {
                List<Video> videos = new List<Video>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top 5 isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE video_id != @video_id AND exibir = 1 AND EXISTS (SELECT video_categoria.categoria_id FROM video_categoria INNER JOIN video_categoria AS vc ON video_categoria.categoria_id = vc.categoria_id WHERE video_categoria.video_id = video.video_id AND vc.video_id = @video_id) ORDER BY data DESC");
                query.SetParameter("video_id", video.video_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    videos.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return videos;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Video Buscar(int id)
        {
            try
            {
                Video video = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE video_id = @video_id ORDER BY data DESC");
                query.SetParameter("video_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    video = (new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Video Gratuito(int id)
        {
            try
            {
                Video video = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE video_id = @video_id and gratuito = 1 ORDER BY data DESC");
                query.SetParameter("video_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    video = (new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Video Buscar(string codigo)
        {
            try
            {
                Video video = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE codigo = @codigo ORDER BY data DESC");
                query.SetParameter("codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    video = (new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Video Gratuito(string codigo)
        {
            try
            {
                Video video = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE codigo = @codigo and gratuito = 1 ORDER BY data DESC");
                query.SetParameter("codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    video = (new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Video Buscar(string titulo, string link)
        {
            try
            {
                Video video = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(video_id, 0) as video_id, isnull(link, '') as link, isnull(titulo, '') as titulo, isnull(descricao, '') as descricao, isnull(imagem, '') as imagem, isnull(data, '01/01/1900') as data, isnull(tempo, '01/01/1900 00:00:00') as tempo, isnull(gratuito, 0) as gratuito, isnull(trailer_id, 0) as trailer_id, isnull(codigo, '') as codigo, isnull(exibir, 0) as exibir FROM video WHERE titulo = @titulo AND link = @link ORDER BY data DESC");
                query.SetParameter("titulo", titulo)
                    .SetParameter("link", link);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    video = (new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Select> Tags(int id)
        {
            try
            {
                List<Select> video = new List<Select>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select DISTINCT tag as value, tag as text, case when video_id = @id then 1 else 0 end as selected from video_tags ORDER BY tag;").SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Select(Convert.ToString(reader["value"]), Convert.ToString(reader["text"]), Convert.ToBoolean(reader["selected"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Select> Categorias(int id)
        {
            try
            {
                List<Select> video = new List<Select>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select categoria_id as value, titulo as text, cast((case when (select count(*) from video_categoria where video_categoria.categoria_id = categoria.categoria_id and video_categoria.video_id = @id) > 0 then 1 else 0 end) as bit) as selected from categoria ORDER BY titulo").SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Select(Convert.ToString(reader["value"]), Convert.ToString(reader["text"]), Convert.ToBoolean(reader["selected"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Select> Autores(int id)
        {
            try
            {
                List<Select> video = new List<Select>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select autor_id as value, nome as text, case when (select count(*) from video_autor where video_autor.autor_id = autor.autor_id and video_autor.video_id = @id) > 0 then 1 else 0 end as selected from autor ORDER BY nome").SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new Select(Convert.ToString(reader["value"]), Convert.ToString(reader["text"]), Convert.ToBoolean(reader["selected"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<VideoRelatorio> RelatorioVideoCategoria()
        {
            try
            {
                List<VideoRelatorio> video = new List<VideoRelatorio>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("Select c.titulo as categoria, v.titulo as video from video as v INNER JOIN video_categoria as vc ON v.video_id = vc.video_id INNER JOIN categoria as c ON vc.categoria_id = c.categoria_id ORDER BY categoria");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    video.Add(new VideoRelatorio(Convert.ToString(reader["categoria"]), Convert.ToString(reader["video"])));
                }
                reader.Close();
                session.Close();

                return video;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Video> ListarTimeline(int pagina = 1)
        {
            try
            {
                List<Video> dataLote = new List<Video>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v ORDER BY v.data DESC OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
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

        public List<Video> ListarTimeline(int pagina = 1, string titulo = "")
        {
            try
            {
                List<Video> dataLote = new List<Video>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v WHERE titulo like '%" + titulo.Replace(" ", "%") + "%' ORDER BY v.data DESC OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("titulo", titulo);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM video");
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM video WHERE titulo like '%" + titulo.Replace(" ", "%") + "%'");
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

    }
}





//public List<Video> Tudo()
//{
//    try
//    {
//        List<Video> video = new List<Video>();

//        DBSession session = new DBSession();
//        Query query = session.CreateQuery("select isnull(v.video_id, 0) as video_id, isnull(v.link, '') as link, isnull(v.titulo, '') as titulo, isnull(v.descricao, '') as descricao, isnull(v.imagem, '') as imagem, isnull(v.data, '01/01/1900') as data, isnull(v.tempo, '01/01/1900 00:00:00') as tempo, isnull(v.gratuito, 0) as gratuito, isnull(v.trailer_id, 0) as trailer_id, isnull(v.codigo, '') as codigo, isnull(v.exibir, 0) as exibir FROM video v ORDER BY v.data DESC");
//        IDataReader reader = query.ExecuteQuery();

//        while (reader.Read())
//        {
//            video.Add(new Video(Convert.ToInt32(reader["video_id"]), Convert.ToString(reader["link"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToString(reader["imagem"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["tempo"]), Convert.ToBoolean(reader["gratuito"]), Convert.ToInt32(reader["trailer_id"]), Convert.ToString(reader["codigo"]), Convert.ToBoolean(reader["exibir"])));
//        }
//        reader.Close();
//        session.Close();

//        return video;
//    }
//    catch (Exception error)
//    {
//        throw error;
//    }

//}