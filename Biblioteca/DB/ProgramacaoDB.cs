using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ProgramacaoDB
    {
        public void Salvar(Programacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Programacao (inicio, fim, texto, dominio, imagem) VALUES (@inicio, @fim, @texto, @dominio, @imagem) ");
                query.SetParameter("inicio", variavel.inicio)
                    .SetParameter("fim", variavel.fim)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Programacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Programacao SET dominio = @dominio, inicio = @inicio, fim = @fim, texto = @texto, imagem = @imagem WHERE programacao_id = @id");
                query.SetParameter("inicio", variavel.inicio)
                    .SetParameter("fim", variavel.fim)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("id", variavel.programacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Programacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Programacao WHERE Programacao_id = @id; DELETE FROM Programacao_palestrante WHERE Programacao_id = @id;");
                query.SetParameter("id", variavel.programacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Programacao Buscar(int id)
        {
            try
            {
                Programacao programacao = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao WHERE Programacao_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    programacao = new Programacao(Convert.ToInt32(reader["Programacao_id"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"]));
                }
                reader.Close();
                session.Close();

                return programacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao> Listar()
        {
            try
            {
                List<Programacao> programacao = new List<Programacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao ORDER BY dominio, inicio, fim");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    programacao.Add(new Programacao(Convert.ToInt32(reader["Programacao_id"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"])));
                }
                reader.Close();
                session.Close();

                return programacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao> Listar(string dominio)
        {
            try
            {
                List<Programacao> programacao = new List<Programacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao WHERE dominio = @dominio ORDER BY dominio, inicio, fim");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    programacao.Add(new Programacao(Convert.ToInt32(reader["Programacao_id"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"])));
                }
                reader.Close();
                session.Close();

                return programacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<DateTime> Dias(string dominio)
        {
            try
            {
                List<DateTime> programacao = new List<DateTime>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select concat(day(inicio), '/', month(inicio), '/', year(inicio)) AS data from programacao where dominio = @dominio group by concat(day(inicio), '/', month(inicio), '/', year(inicio)) ORDER BY concat(day(inicio), '/', month(inicio), '/', year(inicio))");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    programacao.Add(Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return programacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao> Listar(DateTime data, string dominio)
        {
            try
            {
                List<Programacao> programacao = new List<Programacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao WHERE dominio = @dominio AND inicio between @inicio AND @fim ORDER BY dominio, inicio, fim");
                quey.SetParameter("dominio", dominio)
                    .SetParameter("inicio", data)
                    .SetParameter("fim", data.AddDays(1).AddSeconds(-1));
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    programacao.Add(new Programacao(Convert.ToInt32(reader["Programacao_id"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"])));
                }
                reader.Close();
                session.Close();

                return programacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
