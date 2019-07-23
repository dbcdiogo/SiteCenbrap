using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PreSet_subtarefaDB
    {
        public void Salvar(PreSet_subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_subtarefa (preset_tarefa_id, texto, prazo) VALUES (@preset_tarefa_id, @texto, @prazo) ");
                query.SetParameter("preset_tarefa_id", variavel.preset_tarefa_id.preset_tarefa_id)
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

        public int Salvar(PreSet_tarefa preset_tarefa, string texto, int prazo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_tarefa (preset_tarefa_id, texto, prazo) VALUES (@preset_tarefa_id, @texto, @prazo) ");
                query.SetParameter("preset_tarefa_id", preset_tarefa.preset_tarefa_id)
                    .SetParameter("texto", texto)
                    .SetParameter("prazo", prazo);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT PreSet_subtarefa_id FROM PreSet_tarefa WHERE preset_tarefa_id = @preset_tarefa_id AND texto = @texto AND prazo = @prazo ORDER BY PreSet_subtarefa_id DESC");
                query.SetParameter("preset_tarefa_id", preset_tarefa.preset_tarefa_id)
                    .SetParameter("texto", texto)
                    .SetParameter("prazo", prazo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["PreSet_subtarefa_id"]);
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

        public void Alterar(PreSet_subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE PreSet_subtarefa SET texto = @texto, prazo = @prazo WHERE PreSet_subtarefa_id = @PreSet_subtarefa_id");
                query.SetParameter("texto", variavel.texto)
                    .SetParameter("prazo", variavel.prazo)
                    .SetParameter("PreSet_subtarefa_id", variavel.preset_subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(PreSet_subtarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM preset_subtarefa WHERE PreSet_subtarefa_id = @PreSet_subtarefa_id");
                query.SetParameter("PreSet_subtarefa_id", variavel.preset_subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public PreSet_subtarefa Buscar(int id)
        {
            try
            {
                PreSet_subtarefa retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_subtarefa WHERE PreSet_subtarefa_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new PreSet_subtarefa(Convert.ToInt32(reader["PreSet_subtarefa_id"]), new PreSet_tarefa(Convert.ToInt32(reader["PreSet_tarefa_id"])), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["prazo"]));
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

        public List<PreSet_subtarefa> Listar(int id)
        {
            try
            {
                List<PreSet_subtarefa> retorno = new List<PreSet_subtarefa>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_subtarefa WHERE preset_tarefa_id = @id ORDER BY texto");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno.Add(new PreSet_subtarefa(Convert.ToInt32(reader["PreSet_subtarefa_id"]), new PreSet_tarefa(Convert.ToInt32(reader["PreSet_tarefa_id"])), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["prazo"])));
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
