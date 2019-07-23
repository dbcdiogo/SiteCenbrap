using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PreSetDB
    {
        public void Salvar(PreSet variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet (data, painel, ativo, titulo) VALUES (@data, @painel, @ativo, @titulo) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("titulo", variavel.titulo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Salvar(DateTime data, Painel painel, bool ativo, string titulo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet (data, painel, ativo, titulo) VALUES (@data, @painel, @ativo, @titulo) ");
                query.SetParameter("data", data)
                    .SetParameter("painel", painel.codigo)
                    .SetParameter("ativo", ativo)
                    .SetParameter("titulo", titulo);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT preset_id FROM PreSet WHERE data = @data AND painel = @painel AND ativo = @ativo AND titulo = @titulo ORDER BY preset_id DESC");
                query.SetParameter("data", data)
                    .SetParameter("painel", painel.codigo)
                    .SetParameter("ativo", ativo)
                    .SetParameter("titulo", titulo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["preset_id"]);
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

        public void Alterar(PreSet variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE PreSet SET data = @data, painel = @painel, ativo = @ativo, titulo = @titulo WHERE preset_id = @preset_id");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("preset_id", variavel.preset_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(PreSet variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM PreSet WHERE preset_id = @preset_id; DELETE FROM PreSet_acionador WHERE preset_id = @preset_id; DELETE FROM PreSet_subtarefa WHERE preset_subtarefa_id IN (SELECT preset_tarefa_id FROM diagweb.preset_tarefa WHERE preset_id = @preset_id); DELETE FROM PreSet_tarefa WHERE preset_id = @preset_id");
                query.SetParameter("preset_id", variavel.preset_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public PreSet Buscar(int id)
        {
            try
            {
                PreSet retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet WHERE PreSet_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new PreSet(Convert.ToInt32(reader["PreSet_id"]), new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToString(reader["titulo"]));
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

        public List<PreSet> Listar()
        {
            try
            {
                List<PreSet> retorno = new List<PreSet>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet ORDER BY ativo DESC, titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new PreSet(Convert.ToInt32(reader["PreSet_id"]), new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToString(reader["titulo"])));
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

        public List<PreSet> Listar(string ativo, string chave)
        {
            try
            {
                List<PreSet> retorno = new List<PreSet>();

                string executar = "SELECT * FROM PreSet WHERE preset_id > 0";

                if (ativo != null && ativo != "")
                    executar += " AND ativo = " + ativo;

                if (chave != null && chave != "")
                    executar += " AND titulo LIKE '%" + chave + "%'";

                executar += " ORDER BY ativo DESC, titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new PreSet(Convert.ToInt32(reader["PreSet_id"]), new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToString(reader["titulo"])));
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
