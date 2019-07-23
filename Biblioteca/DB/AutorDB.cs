using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AutorDB
    {
        public void Salvar(Autor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO autor (nome) VALUES (@nome) ");
                query.SetParameter("nome", variavel.nome);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Autor variavel)
        {
            try
            {
                Salvar(variavel);

                return Buscar(variavel.nome).autor_id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Autor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE autor SET nome = @nome WHERE autor_id = @autor_id");
                query.SetParameter("nome", variavel.nome)
                .SetParameter("autor_id", variavel.autor_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Autor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM autor WHERE autor_id = @autor_id; DELETE FROM video_autor WHERE autor_id = @autor_id;");
                query.SetParameter("autor_id", variavel.autor_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Autor> Listar()
        {
            try
            {
                List<Autor> autor = new List<Autor>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(autor_id, 0) as autor_id, isnull(nome, '') as nome FROM autor ORDER BY nome");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    autor.Add(new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Autor> Listar(Video video)
        {
            try
            {
                List<Autor> autor = new List<Autor>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(a.autor_id, 0) as autor_id, isnull(a.nome, '') as nome FROM autor AS a INNER JOIN video_autor AS va ON a.autor_id = va.autor_id WHERE va.video_id = @video_id ORDER BY a.nome")
                    .SetParameter("video_id", video.video_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    autor.Add(new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Autor Buscar(int id)
        {
            try
            {
                Autor autor = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(autor_id, 0) as autor_id, isnull(nome, '') as nome FROM autor WHERE autor_id = @autor_id ORDER BY nome");
                query.SetParameter("autor_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    autor = new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"]));
                }
                reader.Close();
                session.Close();

                return autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Autor Buscar(string nome)
        {
            try
            {
                Autor autor = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(autor_id, 0) as autor_id, isnull(nome, '') as nome FROM autor WHERE nome = @nome ORDER BY nome");
                query.SetParameter("nome", nome);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    autor = new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"]));
                }
                reader.Close();
                session.Close();

                return autor;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Autor> ListarTimeline(int pagina = 1)
        {
            try
            {
                List<Autor> dataLote = new List<Autor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM autor ORDER BY nome OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"])));
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

        public List<Autor> ListarTimeline(int pagina = 1, string titulo = "")
        {
            try
            {
                List<Autor> dataLote = new List<Autor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM autor WHERE nome like '%" + titulo.Replace(" ", "%") + "%' ORDER BY nome OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("titulo", titulo);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Autor(Convert.ToInt32(reader["autor_id"]), Convert.ToString(reader["nome"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM autor");
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM autor WHERE nome like '%" + titulo.Replace(" ", "%") + "%'");
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
