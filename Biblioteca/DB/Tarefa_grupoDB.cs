using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Tarefa_grupoDB
    {
        public void Salvar(Tarefa_grupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa_grupo (tarefa_id, grupo_tarefas_id) VALUES (@tarefa_id, @grupo_tarefas_id) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id.grupo_tarefas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Tarefa_grupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Tarefa_grupo WHERE tarefa_id = @tarefa_id AND grupo_tarefas_id = @grupo_tarefas_id");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id.grupo_tarefas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Tarefa_grupo> Listar(Tarefa tarefa)
        {
            try
            {
                List<Tarefa_grupo> retorno = new List<Tarefa_grupo>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Tarefa_grupo WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", tarefa.tarefa_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Tarefa_grupo(new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"])), tarefa));
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

        public List<Tarefa_grupo> Listar(Grupo_tarefas grupo_tarefas)
        {
            try
            {
                List<Tarefa_grupo> retorno = new List<Tarefa_grupo>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Tarefa_grupo WHERE grupo_tarefas_id = @grupo_tarefas_id");
                query.SetParameter("grupo_tarefas_id", grupo_tarefas.grupo_tarefas_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Tarefa_grupo(grupo_tarefas, new Tarefa(Convert.ToInt32(reader["tarefa_id"]))));
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
