using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Aluno_navegacaoDB
    {
        public void Salvar(Aluno_navegacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("IF NOT EXISTS (SELECT * FROM aluno_navegacao WHERE aluno = @aluno AND _ga = @_ga) BEGIN INSERT INTO aluno_navegacao (aluno, _ga, data) VALUES (@aluno, @_ga, @data) END");
                query.SetParameter("aluno", variavel.aluno.codigo)
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

        public List<Aluno_navegacao> Listar(string _ga)
        {
            try
            {
                List<Aluno_navegacao> retorno = new List<Aluno_navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Aluno_navegacao WHERE _ga = @_ga ORDER BY data DESC")
                    .SetParameter("_ga", _ga);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Aluno_navegacao(new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public List<Aluno_navegacao> Listar(Aluno aluno)
        {
            try
            {
                List<Aluno_navegacao> retorno = new List<Aluno_navegacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Aluno_navegacao WHERE aluno = @aluno ORDER BY data DESC")
                    .SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Aluno_navegacao(aluno, Convert.ToString(reader["_ga"]), Convert.ToDateTime(reader["data"])));
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

        public void Existe(Aluno aluno, string _ga)
        {
            try
            {
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Aluno_navegacao WHERE _ga = @_ga and aluno = @aluno ORDER BY data DESC")
                    .SetParameter("_ga", _ga)
                    .SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (!reader.Read())
                {
                    Salvar(new Aluno_navegacao(aluno, _ga, DateTime.Now));
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
