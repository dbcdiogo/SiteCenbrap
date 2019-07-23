using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class NavegacaoDB
    {
        public void Salvar(Navegacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Navegacao (url, _ga, data) VALUES (@url, @_ga, @data) ");
                query.SetParameter("url", variavel.url)
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

        public List<Navegacao> Listar(string _ga)
        {
            try
            {
                List<Navegacao> retorno = new List<Navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Navegacao WHERE _ga = @_ga ORDER BY data DESC")
                    .SetParameter("_ga", _ga);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Navegacao(Convert.ToInt32(reader["navegacao_id"]), Convert.ToString(reader["url"]), Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public List<Navegacao> Listar(Aluno aluno, int qtd = 10)
        {
            try
            {
                List<Navegacao> retorno = new List<Navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top " + qtd + " n.navegacao_id, n.url, n._ga, n.data from navegacao as n inner join aluno_navegacao as an ON n._ga = an._ga where an.aluno = @aluno ORDER BY data DESC")
                    .SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Navegacao(Convert.ToInt32(reader["navegacao_id"]), Convert.ToString(reader["url"]), Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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
    }
}
