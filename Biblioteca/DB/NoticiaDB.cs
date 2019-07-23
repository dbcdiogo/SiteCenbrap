using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class NoticiaDB
    {
        public void Salvar(Noticia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE noticia SET ordem = (ordem + 1) WHERE dominio = @dominio; INSERT INTO noticia (data, dominio, titulo, ordem) VALUES (@data, @dominio, @titulo, @ordem) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Noticia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE noticia SET dominio = @dominio, data = @data, titulo = @titulo, ordem = @ordem WHERE noticia_id = @noticia_id");
                query.SetParameter("noticia_id", variavel.noticia_id)
                    .SetParameter("data", variavel.data)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Noticia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM noticia WHERE noticia_id = @noticia_id");
                query.SetParameter("noticia_id", variavel.noticia_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Noticia Buscar(int id)
        {
            try
            {
                Noticia noticia = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Noticia WHERE noticia_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    noticia = new Noticia(Convert.ToInt32(reader["noticia_id"]), Convert.ToString(reader["dominio"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["ordem"]));
                }
                reader.Close();
                session.Close();

                return noticia;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Noticia> Listar()
        {
            try
            {
                string executar = "SELECT * FROM noticia ORDER BY dominio, ordem";

                List<Noticia> noticia = new List<Noticia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    noticia.Add(new Noticia(Convert.ToInt32(reader["noticia_id"]), Convert.ToString(reader["dominio"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["ordem"])));
                }
                reader.Close();
                session.Close();

                return noticia;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Noticia> Listar(string dominio, int qtd = 10)
        {
            try
            {
                string executar = "SELECT top " + qtd + " * FROM noticia WHERE dominio = @dominio ORDER BY cast(data as date) desc, ordem";

                List<Noticia> noticia = new List<Noticia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    noticia.Add(new Noticia(Convert.ToInt32(reader["noticia_id"]), Convert.ToString(reader["dominio"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["ordem"])));
                }
                reader.Close();
                session.Close();

                return noticia;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Noticia> Listar(int pagina = 1)
        {
            try
            {
                List<Noticia> dataLote = new List<Noticia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM noticia ORDER BY cast(data as date) desc, ordem OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Noticia(Convert.ToInt32(reader["noticia_id"]), Convert.ToString(reader["dominio"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Noticia> Listar(int pagina = 1, string dominio = "", string titulo = "")
        {
            try
            {
                List<Noticia> dataLote = new List<Noticia>();

                DBSession session = new DBSession();
                string cmdtxt = "SELECT * FROM noticia WHERE 1=1 ";
                if (dominio != "") { cmdtxt += "AND dominio = '" + dominio + "' "; }
                if (titulo != "") { cmdtxt += "AND titulo like '%" + titulo.Replace(" ", "%") + "%' "; }
                cmdtxt += "ORDER BY cast(data as date) desc, ordem OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY";
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Noticia(Convert.ToInt32(reader["noticia_id"]), Convert.ToString(reader["dominio"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["ordem"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM noticia");
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
            string cmdtxt = "SELECT count(*) as total FROM noticia WHERE 1=1";
            if (dominio != "") { cmdtxt += "AND dominio = '" + dominio + "'"; }
            if (titulo != "") { cmdtxt += "AND titulo like '%" + titulo.Replace(" ", "%") + "%'"; }
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
