using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DataLoteDB
    {
        public void Salvar(DataLote variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO DataLote (titulo, dominio, inicio, fim, valor) VALUES (@titulo, @dominio, @inicio, @fim, @valor) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("inicio", variavel.inicio)
                    .SetParameter("fim", variavel.fim)
                    .SetParameter("valor", variavel.valor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(DataLote variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE DataLote SET dominio = @dominio, titulo = @titulo, inicio = @inicio, fim = @fim, valor = @valor WHERE dataLote_id = @id");
                query.SetParameter("id", variavel.dataLote_id)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("inicio", variavel.inicio)
                    .SetParameter("fim", variavel.fim)
                    .SetParameter("valor", variavel.valor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(DataLote variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM DataLote WHERE dataLote_id = @id");
                query.SetParameter("id", variavel.dataLote_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DataLote Buscar(int id)
        {
            try
            {
                DataLote dataLote = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM DataLote WHERE dataLote_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dataLote = new DataLote(Convert.ToInt32(reader["dataLote_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToDouble(reader["valor"]));
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

        public List<DataLote> Listar()
        {
            try
            {
                List<DataLote> dataLote = new List<DataLote>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM DataLote ORDER BY dominio, inicio");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new DataLote(Convert.ToInt32(reader["dataLote_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToDouble(reader["valor"])));
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

        public List<DataLote> Listar(string dominio)
        {
            try
            {
                List<DataLote> dataLote = new List<DataLote>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM DataLote WHERE dominio = @dominio ORDER BY inicio");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new DataLote(Convert.ToInt32(reader["dataLote_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["fim"]), Convert.ToDouble(reader["valor"])));
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
    }
}
