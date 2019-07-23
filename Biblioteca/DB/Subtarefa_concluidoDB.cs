using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Subtarefa_concluidoDB
    {
        public void Salvar(Subtarefa_concluido variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Subtarefa_concluido (subtarefa_id, painel, data) VALUES (@subtarefa_id, @painel, @data) ");
                query.SetParameter("subtarefa_id", variavel.subtarefa_id.subtarefa_id)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data);
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
                Query query = session.CreateQuery("DELETE FROM Subtarefa_concluido WHERE subtarefa_id = @subtarefa_id");
                query.SetParameter("subtarefa_id", variavel.subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Subtarefa_concluido Buscar(Subtarefa subtarefa)
        {
            try
            {
                Subtarefa_concluido retorno = null;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Subtarefa_concluido WHERE subtarefa_id = @subtarefa_id");
                query.SetParameter("subtarefa_id", subtarefa.subtarefa_id);

                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Subtarefa_concluido(subtarefa, new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]));
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
