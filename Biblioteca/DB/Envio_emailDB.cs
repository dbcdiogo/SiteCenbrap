using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Envio_emailDB
    {
        public void Salvar(Envio_email variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Envio_email (para, assunto, texto, data, envio, data_envio, agendado, data_agendado, encontro, prioridade, envio_email) VALUES (@para, @assunto, @texto, @data, @envio, @data_envio, @agendado, @data_agendado, @encontro, @prioridade, @envio_email) ");
                query.SetParameter("para", variavel.para)
                    .SetParameter("assunto", variavel.assunto)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("data", variavel.data)
                    .SetParameter("envio", variavel.envio)
                    .SetParameter("data_envio", variavel.data_envio)
                    .SetParameter("agendado", variavel.agendado)
                    .SetParameter("data_agendado", variavel.data_agendado)
                    .SetParameter("encontro", variavel.encontro)
                    .SetParameter("prioridade", variavel.prioridade)
                    .SetParameter("envio_email", variavel.envio_email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Envio_email variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Envio_email SET para = @para, assunto = @assunto, texto = @texto, data = @data, envio = @envio, data_envio = @data_envio, agendado = @agendado, data_agendado = @data_agendado, encontro = @encontro, prioridade = @prioridade, envio_email = @envio_email WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("para", variavel.para)
                    .SetParameter("assunto", variavel.assunto)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("data", variavel.data)
                    .SetParameter("envio", variavel.envio)
                    .SetParameter("data_envio", variavel.data_envio)
                    .SetParameter("agendado", variavel.agendado)
                    .SetParameter("data_agendado", variavel.data_agendado)
                    .SetParameter("encontro", variavel.encontro)
                    .SetParameter("prioridade", variavel.prioridade)
                    .SetParameter("envio_email", variavel.envio_email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Envio_email variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Envio_email WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Envio_email Buscar(int codigo)
        {
            try
            {
                Envio_email retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, para, assunto, texto, isnull(data, '1900-01-01') as data, envio, isnull(data_envio, '1900-01-01') as data_envio, envio_email FROM Envio_email WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Envio_email(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["para"]), Convert.ToString(reader["assunto"]), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["envio"]), Convert.ToDateTime(reader["data_envio"]), Convert.ToString(reader["envio_email"]), new Envio_email_abriuDB().Buscar(new Envio_email() { codigo = Convert.ToInt32(reader["codigo"]) }));
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

        public List<Envio_email> Listar()
        {
            try
            {
                List<Envio_email> retorno = new List<Envio_email>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, para, assunto, texto, isnull(data, '1900-01-01') as data, envio, isnull(data_envio, '1900-01-01') as data_envio, isnull(hora_envio, '1900-01-01') as hora_envio, agendado, isnull(data_agendado, '1900-01-01') as data_agendado, isnull(hora_agendado, '1900-01-01') as hora_agendado, encontro, prioridade, envio_email FROM Envio_email");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Envio_email(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["para"]), Convert.ToString(reader["assunto"]), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["envio"]), Convert.ToDateTime(reader["data_envio"]), Convert.ToDateTime(reader["hora_envio"]), Convert.ToInt32(reader["agendado"]), Convert.ToDateTime(reader["data_agendado"]), Convert.ToDateTime(reader["hora_agendado"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["prioridade"]), Convert.ToString(reader["envio_email"])));
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

        public List<Envio_email> Listar(string inicio, string fim, string assunto, string email)
        {
            try
            {
                string query = "SELECT codigo, para, assunto, texto, isnull(data, '1900-01-01') as data, envio, isnull(data_envio, '1900-01-01') as data_envio, envio_email FROM Envio_email WHERE codigo > 0";

                DateTime ini = DateTime.Now;
                DateTime fi = DateTime.Now;

                if ((assunto != "" && assunto != null) || (email != "" && email != null))
                {

                }
                
                if((inicio != "" && inicio != null) && (fim != "" && fim != null))
                {
                    ini = Convert.ToDateTime(inicio);
                    fi = Convert.ToDateTime(fim);
                    query += " AND data between @inicio AND @fim";
                }

                if (assunto != "" && assunto != null)
                {
                    query += " AND assunto LIKE '%" + assunto + "%'";
                }

                if (email != "" && email != null)
                {
                    query += " AND para LIKE '%" + email + "%'";
                }

                query += " ORDER BY data DESC";

                List<Envio_email> retorno = new List<Envio_email>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(query);

                if ((inicio != "" && inicio != null) && (fim != "" && fim != null))
                {
                    quey.SetParameter("inicio", ini).SetParameter("fim", fi);
                }

                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Envio_email(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["para"]), Convert.ToString(reader["assunto"]), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["envio"]), Convert.ToDateTime(reader["data_envio"]), Convert.ToString(reader["envio_email"]), new Envio_email_abriuDB().Buscar(new Envio_email() { codigo = Convert.ToInt32(reader["codigo"]) })));
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

        public List<Envio_email> Enviar()
        {
            try
            {
                List<Envio_email> retorno = new List<Envio_email>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT top 20 codigo, para, assunto, texto, isnull(data, '1900-01-01') as data, envio, isnull(data_envio, '1900-01-01') as data_envio, agendado, isnull(data_agendado, '1900-01-01') as data_agendado, encontro, prioridade, envio_email FROM Envio_email WHERE envio = 0 AND (agendado = 0 OR (agendado = 1 AND data_agendado <= @agora)) AND prioridade != 2 ORDER BY prioridade DESC");
                quey.SetParameter("agora", DateTime.Now);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Envio_email(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["para"]), Convert.ToString(reader["assunto"]), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["envio"]), Convert.ToDateTime(reader["data_envio"]), Convert.ToInt32(reader["agendado"]), Convert.ToDateTime(reader["data_agendado"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["prioridade"]), Convert.ToString(reader["envio_email"])));
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

        public bool Existe(string email, string assunto, string link)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo FROM Envio_email WHERE para = @email and assunto = @assunto and data >= dateadd(day, -1, getdate()) and texto like @link");
                quey.SetParameter("email", email)
                    .SetParameter("assunto", assunto)
                    .SetParameter("link", "%"+ link+"%");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = true;
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
