using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class SitesDB
    {
        public void Salvar(Sites variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_sites (txsite) VALUES (@site) ");
                query.SetParameter("site", variavel.txsite);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Sites variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_sites SET txsite = @site WHERE idsite = @id");
                query.SetParameter("site", variavel.txsite)
                    .SetParameter("id", variavel.idsite);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Sites variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_sites WHERE idsite = @id");
                query.SetParameter("id", variavel.idsite);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Sites Buscar(int id)
        {
            try
            {
                Sites site = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_sites WHERE idsite = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    site = new Sites(Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txsite"]));
                }
                reader.Close();
                session.Close();

                return site;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Sites Buscar(string busca)
        {
            try
            {
                Sites site = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_sites WHERE txsite = @site");
                quey.SetParameter("site", busca);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    site = new Sites(Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txsite"]));
                }
                reader.Close();
                session.Close();

                return site;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Sites> Listar()
        {
            try
            {
                List<Sites> dataLote = new List<Sites>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_sites ORDER BY txsite");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Sites(Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txsite"])));
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

        public List<Sites> Listar(int pagina = 1)
        {
            try
            {
                List<Sites> dataLote = new List<Sites>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_sites ORDER BY txsite OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Sites(Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txsite"])));
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

        public List<Sites> Listar(int pagina = 1, string site = "")
        {
            try
            {
                List<Sites> dataLote = new List<Sites>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_sites WHERE txsite = @site ORDER BY txsite OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("site", site);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Sites(Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txsite"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_sites");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string site = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_sites WHERE txsite = @site");
            quey.SetParameter("site", site);
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
