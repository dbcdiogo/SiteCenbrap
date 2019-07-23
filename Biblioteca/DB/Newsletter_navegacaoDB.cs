using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Newsletter_navegacaoDB
    {
        public void Salvar(Newsletter_navegacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("IF NOT EXISTS (SELECT * FROM newsletter_navegacao WHERE newsletter = @newsletter AND _ga = @_ga) BEGIN INSERT INTO newsletter_navegacao (newsletter, _ga, data) VALUES (@newsletter, @_ga, @data) END");
                query.SetParameter("newsletter", variavel.newsletter.codigo)
                    .SetParameter("_ga", variavel._ga)
                    .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Newsletter_navegacao> Listar(string _ga)
        {
            try
            {
                List<Newsletter_navegacao> retorno = new List<Newsletter_navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Newsletter_navegacao WHERE _ga = @_ga ORDER BY data DESC")
                    .SetParameter("_ga", _ga);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Newsletter_navegacao(new Newsletter(Convert.ToInt32(reader["newsletter"])), Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public List<Newsletter_navegacao> Listar(Newsletter newsletter)
        {
            try
            {
                List<Newsletter_navegacao> retorno = new List<Newsletter_navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Newsletter_navegacao WHERE newsletter = @newsletter ORDER BY data DESC")
                    .SetParameter("newsletter", newsletter.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Newsletter_navegacao(newsletter, Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public List<Newsletter_navegacao> ListarEmail(string email)
        {
            try
            {
                List<Newsletter_navegacao> retorno = new List<Newsletter_navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT Newsletter_navegacao.newsletter, Newsletter_navegacao._ga, Newsletter_navegacao.data FROM Newsletter_navegacao inner join newsletter on Newsletter_navegacao.newsletter = newsletter.codigo WHERE newsletter.email = @email ORDER BY data DESC")
                    .SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Newsletter_navegacao(new Newsletter(Convert.ToInt32(reader["newsletter"])), Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public void Existe(Newsletter newsletter, string _ga)
        {
            try
            {
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Newsletter_navegacao WHERE _ga = @_ga and newsletter = @newsletter ORDER BY data DESC")
                    .SetParameter("_ga", _ga)
                    .SetParameter("newsletter", newsletter.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (!reader.Read())
                {
                    Salvar(new Newsletter_navegacao(newsletter, _ga, DateTime.Now));
                }
                reader.Close();
                session.Close();

            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
