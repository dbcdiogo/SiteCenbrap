using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Tarefa_painelDB
    {
        public void Salvar(Tarefa_painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa_painel (tarefa_id, painel) VALUES (@tarefa_id, @painel) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Tarefa_painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Tarefa_painel WHERE tarefa_id = @tarefa_id AND painel = @painel");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Tarefa_painel> Listar(Tarefa tarefa)
        {
            try
            {
                List<Tarefa_painel> retorno = new List<Tarefa_painel>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Tarefa WHERE tarefa_id = @id");
                quey.SetParameter("id", tarefa.tarefa_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add( new Tarefa_painel( tarefa, new Painel(Convert.ToInt32(reader["painel"])) ) );
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
