using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TarefaDB
    {
        public void Salvar(Tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa (data, vencimento, concluido, texto) VALUES (@data, @vencimento, @concluido, @texto) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("concluido", variavel.concluido)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Salvar(DateTime? data, DateTime? vencimento, bool concluido, string texto)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa (data, vencimento, concluido, texto) VALUES (@data, @vencimento, @concluido, @texto) ");
                query.SetParameter("data", data)
                    .SetParameter("vencimento", vencimento)
                    .SetParameter("concluido", concluido)
                    .SetParameter("texto", texto);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT tarefa_id FROM tarefa WHERE data = @data AND vencimento = @vencimento AND concluido = @concluido ORDER BY tarefa_id DESC");
                query.SetParameter("data", data)
                    .SetParameter("vencimento", vencimento)
                    .SetParameter("concluido", concluido);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["tarefa_id"]);
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE tarefa SET vencimento = @vencimento, concluido = @concluido, texto = @texto WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", variavel.tarefa_id)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("concluido", variavel.concluido)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM tarefa WHERE tarefa_id = @tarefa_id; DELETE FROM tarefa_painel WHERE tarefa_id = @tarefa_id; DELETE FROM tarefa_concluido WHERE tarefa_id = @tarefa_id; DELETE FROM tarefa_curso WHERE tarefa_id = @tarefa_id; DELETE FROM tarefa_adiada WHERE tarefa_id = @tarefa_id; DELETE FROM subtarefa_adiada WHERE subtarefa_id IN (SELECT subtarefa_id FROM subtarefa WHERE tarefa_id = @tarefa_id); DELETE FROM subtarefa_concluido WHERE subtarefa_id IN (SELECT subtarefa_id FROM subtarefa WHERE tarefa_id = @tarefa_id); DELETE FROM subtarefa WHERE tarefa_id = @tarefa_id;");
                query.SetParameter("tarefa_id", variavel.tarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Tarefa Buscar(int id)
        {
            try
            {
                Tarefa retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Tarefa WHERE tarefa_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Tarefa(Convert.ToInt32(reader["tarefa_id"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToBoolean(reader["concluido"]), Convert.ToString(reader["texto"]));
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

        public List<Tarefa> Listar()
        {
            try
            {
                List<Tarefa> retorno = new List<Tarefa>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Tarefa");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Tarefa(Convert.ToInt32(reader["tarefa_id"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToBoolean(reader["concluido"]), Convert.ToString(reader["texto"])));
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
