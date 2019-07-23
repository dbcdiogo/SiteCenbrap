using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PreSet_acionadorDB
    {
        public void Salvar(PreSet_acionador variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_acionador (preset_id, tabela, inclusao, alteracao, alteracao_campo, alteracao_campo_valor) VALUES (@preset_id, @tabela, @inclusao, @alteracao, @alteracao_campo, @alteracao_campo_valor) ");
                query.SetParameter("preset_id", variavel.preset_id.preset_id)
                    .SetParameter("tabela", variavel.tabela)
                    .SetParameter("inclusao", variavel.inclusao)
                    .SetParameter("alteracao", variavel.alteracao)
                    .SetParameter("alteracao_campo", variavel.alteracao_campo)
                    .SetParameter("alteracao_campo_valor", variavel.alteracao_campo_valor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Salvar(PreSet preset, string tabela, bool inclusao, bool alteracao, string alteracao_campo, string alteracao_campo_valor)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PreSet_acionador (preset_id, tabela, inclusao, alteracao, alteracao_campo, alteracao_campo_valor) VALUES (@preset_id, @tabela, @inclusao, @alteracao, @alteracao_campo, @alteracao_campo_valor) ");
                query.SetParameter("preset_id", preset.preset_id)
                    .SetParameter("tabela", tabela)
                    .SetParameter("inclusao", inclusao)
                    .SetParameter("alteracao", alteracao)
                    .SetParameter("alteracao_campo", alteracao_campo)
                    .SetParameter("alteracao_campo_valor", alteracao_campo_valor);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT PreSet_acionador_id FROM PreSet_acionador WHERE preset_id = @preset_id AND tabela = @tabela AND inclusao = @inclusao AND alteracao = @alteracao AND alteracao_campo = @alteracao_campo AND alteracao_campo_valor = @alteracao_campo_valor ORDER BY PreSet_acionador_id DESC");
                query.SetParameter("preset_id", preset.preset_id)
                    .SetParameter("tabela", tabela)
                    .SetParameter("inclusao", inclusao)
                    .SetParameter("alteracao", alteracao)
                    .SetParameter("alteracao_campo", alteracao_campo)
                    .SetParameter("alteracao_campo_valor", alteracao_campo_valor);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["PreSet_acionador_id"]);
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

        public void Alterar(PreSet_acionador variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE PreSet_acionador SET tabela = @tabela, inclusao = @inclusao, alteracao = @alteracao, alteracao_campo = @alteracao_campo, alteracao_campo_valor = @alteracao_campo_valor WHERE PreSet_acionador_id = @PreSet_acionador_id");
                query.SetParameter("tabela", variavel.tabela)
                    .SetParameter("inclusao", variavel.inclusao)
                    .SetParameter("alteracao", variavel.alteracao)
                    .SetParameter("alteracao_campo", variavel.alteracao_campo)
                    .SetParameter("alteracao_campo_valor", variavel.alteracao_campo_valor)
                    .SetParameter("PreSet_acionador_id", variavel.preset_acionador_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(PreSet_acionador variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM PreSet_acionador WHERE PreSet_acionador_id = @PreSet_acionador_id");
                query.SetParameter("PreSet_acionador_id", variavel.preset_acionador_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public PreSet_acionador Buscar(int id)
        {
            try
            {
                PreSet_acionador retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_acionador WHERE PreSet_acionador_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new PreSet_acionador(Convert.ToInt32(reader["PreSet_acionador_id"]), new PreSet(Convert.ToInt32(reader["preset_id"])), Convert.ToString(reader["tabela"]), Convert.ToBoolean(reader["inclusao"]), Convert.ToBoolean(reader["alteracao"]), Convert.ToString(reader["alteracao_campo"]), Convert.ToString(reader["alteracao_campo_valor"]));
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

        public List<PreSet_acionador> Listar(int id)
        {
            try
            {
                List<PreSet_acionador> retorno = new List<PreSet_acionador>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PreSet_acionador WHERE PreSet_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno.Add(new PreSet_acionador(Convert.ToInt32(reader["PreSet_acionador_id"]), new PreSet(Convert.ToInt32(reader["preset_id"])), Convert.ToString(reader["tabela"]), Convert.ToBoolean(reader["inclusao"]), Convert.ToBoolean(reader["alteracao"]), Convert.ToString(reader["alteracao_campo"]), Convert.ToString(reader["alteracao_campo_valor"])));
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
