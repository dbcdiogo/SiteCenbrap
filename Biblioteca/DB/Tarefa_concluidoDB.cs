using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Tarefa_concluidoDB
    {
        public void Salvar(Tarefa_concluido variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa_concluido (tarefa_id, painel, data) VALUES (@tarefa_id, @painel, @data) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
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

        public void Excluir(Tarefa variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Tarefa_concluido WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", variavel.tarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Tarefa_concluido Buscar(Tarefa tarefa)
        {
            try
            {
                Tarefa_concluido retorno = null;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM tarefa_concluido WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", tarefa.tarefa_id);

                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Tarefa_concluido(tarefa, new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]));
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
