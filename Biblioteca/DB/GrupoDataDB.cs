using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class GrupoDataDB
    {
        public void Salvar(GrupoData variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO GrupoData (grupo, data1, data2) VALUES (@grupo, @data1, @data2) ");
                query.SetParameter("grupo", variavel.grupo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("data2", variavel.data2);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(GrupoData variavel)
        {
            try
            {
                int id = 0;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO GrupoData (grupo, data1, data2) VALUES (@grupo, @data1, @data2) ");
                query.SetParameter("grupo", variavel.grupo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("data2", variavel.data2);
                query.ExecuteUpdate();
                session.Close();

                DBSession session1 = new DBSession();
                Query quey = session1.CreateQuery("SELECT GrupoData_id FROM GrupoData WHERE grupo = @grupo AND data1 = @data1 AND data2 = @data2 ORDER BY GrupoData_id DESC");
                quey.SetParameter("grupo", variavel.grupo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("data2", variavel.data2);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["GrupoData_id"]);
                }
                reader.Close();
                session1.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(GrupoData variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE GrupoData SET grupo = @grupo, data1 = @data1, data2 = @data2 WHERE GrupoData_id = @GrupoData_id");
                query.SetParameter("grupo", variavel.grupo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("data2", variavel.data2)
                    .SetParameter("GrupoData_id", variavel.grupoData_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(GrupoData variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM GrupoData WHERE GrupoData_id = @GrupoData_id");
                query.SetParameter("GrupoData_id", variavel.grupoData_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public GrupoData Buscar(int codigo)
        {
            try
            {
                GrupoData retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM GrupoData WHERE GrupoData_id = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new GrupoData(Convert.ToInt32(reader["GrupoData_id"]), Convert.ToInt32(reader["grupo"]), Convert.ToDateTime(reader["data1"]), Convert.ToDateTime(reader["data2"]));
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

        public List<GrupoData> Listar()
        {
            try
            {
                List<GrupoData> retorno = new List<GrupoData>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM GrupoData WHERE data1 > getdate() ORDER BY grupo, data1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new GrupoData(Convert.ToInt32(reader["GrupoData_id"]), Convert.ToInt32(reader["grupo"]), Convert.ToDateTime(reader["data1"]), Convert.ToDateTime(reader["data2"])));
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

        public List<GrupoData> Listar(int id)
        {
            try
            {
                List<GrupoData> retorno = new List<GrupoData>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM GrupoData WHERE data1 > getdate() AND grupo = @grupo ORDER BY grupo, data1");
                quey.SetParameter("grupo", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new GrupoData(Convert.ToInt32(reader["GrupoData_id"]), Convert.ToInt32(reader["grupo"]), Convert.ToDateTime(reader["data1"]), Convert.ToDateTime(reader["data2"])));
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

        public List<GrupoData> Listar(DateTime data)
        {
            try
            {
                List<GrupoData> retorno = new List<GrupoData>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM GrupoData WHERE data1 > getdate() AND grupo = (SELECT g.grupo FROM grupoData AS g WHERE g.data1 > getdate() AND g.data1 = @data) ORDER BY grupo, data1");
                quey.SetParameter("data", data);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new GrupoData(Convert.ToInt32(reader["GrupoData_id"]), Convert.ToInt32(reader["grupo"]), Convert.ToDateTime(reader["data1"]), Convert.ToDateTime(reader["data2"])));
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
