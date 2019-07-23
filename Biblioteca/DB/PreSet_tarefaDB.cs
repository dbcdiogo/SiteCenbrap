using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PreSet_tarefaDB
    {
        public void Salvar(PreSet_tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_tarefa (preset_id, grupo_tarefas_id, texto, prazo) VALUES (@preset_id, @grupo_tarefas_id, @texto, @prazo) ");
                query.SetParameter("preset_id", variavel.preset_id.preset_id)
                    .SetParameter("painel", variavel.grupo_tarefas_id.grupo_tarefas_id)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("prazo", variavel.prazo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Salvar(PreSet preset, Grupo_tarefas grupo_tarefas, string texto, int prazo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_tarefa (preset_id, grupo_tarefas_id, texto, prazo) VALUES (@preset_id, @grupo_tarefas_id, @texto, @prazo) ");
                query.SetParameter("preset_id", preset.preset_id)
                    .SetParameter("grupo_tarefas_id", grupo_tarefas.grupo_tarefas_id)
                    .SetParameter("texto", texto)
                    .SetParameter("prazo", prazo);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT PreSet_tarefa_id FROM PreSet_tarefa WHERE preset_id = @preset_id AND grupo_tarefas_id = @grupo_tarefas_id AND texto = @texto AND prazo = @prazo ORDER BY PreSet_tarefa_id DESC");
                query.SetParameter("preset_id", preset.preset_id)
                    .SetParameter("grupo_tarefas_id", grupo_tarefas.grupo_tarefas_id)
                    .SetParameter("texto", texto)
                    .SetParameter("prazo", prazo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["PreSet_tarefa_id"]);
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

        public void Alterar(PreSet_tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE PreSet_tarefa SET grupo_tarefas_id = @grupo_tarefas_id, texto = @texto, prazo = @prazo WHERE preset_tarefa_id = @preset_tarefa_id");
                query.SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id.grupo_tarefas_id)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("prazo", variavel.prazo)
                    .SetParameter("preset_tarefa_id", variavel.preset_tarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(PreSet_tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM preset_tarefa WHERE preset_tarefa_id = @preset_tarefa_id; DELETE FROM preset_subtarefa WHERE preset_tarefa_id = @preset_tarefa_id");
                query.SetParameter("preset_tarefa_id", variavel.preset_tarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public PreSet_tarefa Buscar(int id)
        {
            try
            {
                PreSet_tarefa retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_tarefa WHERE PreSet_tarefa_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new PreSet_tarefa(Convert.ToInt32(reader["PreSet_tarefa_id"]), new PreSet(Convert.ToInt32(reader["preset_id"])), new Grupo_tarefas(Convert.ToInt32(reader["Grupo_tarefas_id"])), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["prazo"]));
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

        public List<PreSet_tarefa> Listar(int id)
        {
            try
            {
                List<PreSet_tarefa> retorno = new List<PreSet_tarefa>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_tarefa WHERE PreSet_id = @id ORDER BY texto");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new PreSet_tarefa(Convert.ToInt32(reader["PreSet_tarefa_id"]), new PreSet(Convert.ToInt32(reader["preset_id"])), new Grupo_tarefas(Convert.ToInt32(reader["Grupo_tarefas_id"])), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["prazo"])));
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
