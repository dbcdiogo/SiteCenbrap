using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class SubtarefaDB
    {
        public void Salvar(Subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Subtarefa (tarefa_id, painel, data, vencimento, concluido, texto) VALUES (@tarefa_id, @painel, @data, @vencimento, @concluido, @texto) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
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

        public int Salvar(Tarefa tarefa, Painel painel, DateTime data, DateTime? vencimento, bool concluido, string texto)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Subtarefa(tarefa_id, painel, data, vencimento, concluido, texto) VALUES(@tarefa_id, @painel, @data, @vencimento, @concluido, @texto) ");
                query.SetParameter("tarefa_id", tarefa.tarefa_id)
                    .SetParameter("painel", painel.codigo)
                    .SetParameter("data", data)
                    .SetParameter("vencimento", vencimento)
                    .SetParameter("concluido", concluido)
                    .SetParameter("texto", texto);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT subtarefa_id FROM subtarefa WHERE tarefa_id = @tarefa_id AND painel = @painel AND data = @data AND vencimento = @vencimento AND concluido = @concluido ORDER BY tarefa_id DESC");
                query.SetParameter("tarefa_id", tarefa.tarefa_id)
                    .SetParameter("painel", painel.codigo)
                    .SetParameter("data", data)
                    .SetParameter("vencimento", vencimento)
                    .SetParameter("concluido", concluido);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["subtarefa_id"]);
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

        public void Alterar(Subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Subtarefa SET tarefa_id = @tarefa_id, painel = @painel, data = @data, vencimento = @vencimento, concluido = @concluido, texto = @texto WHERE subtarefa_id = @subtarefa_id");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("concluido", variavel.concluido)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("subtarefa_id", variavel.subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE Subtarefa WHERE subtarefa_id = @subtarefa_id; DELETE Subtarefa_adiada WHERE subtarefa_id = @subtarefa_id; DELETE Subtarefa_concluido WHERE subtarefa_id = @subtarefa_id;");
                query.SetParameter("subtarefa_id", variavel.subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Subtarefa Buscar(int id)
        {
            try
            {
                Subtarefa retorno = null;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM subtarefa WHERE subtarefa_id = @subtarefa_id");
                query.SetParameter("subtarefa_id", id);

                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Subtarefa(Convert.ToInt32(reader["subtarefa_id"]), new Tarefa(Convert.ToInt32(reader["tarefa_id"])), new Painel(Convert.ToInt32(reader["painel"])), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToBoolean(reader["concluido"]));
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

        public List<Subtarefa> Listar(Tarefa tarefa)
        {
            try
            {
                List<Subtarefa> retorno = new List<Subtarefa>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM subtarefa WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", tarefa.tarefa_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Subtarefa(Convert.ToInt32(reader["subtarefa_id"]), tarefa, new Painel(Convert.ToInt32(reader["painel"])), Convert.ToString(reader["texto"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToBoolean(reader["concluido"])));
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
    }
}
