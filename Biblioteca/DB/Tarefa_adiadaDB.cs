using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Tarefa_adiadaDB
    {
        public void Salvar(Tarefa_adiada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa_adiada (tarefa_id, painel, data, de, para) VALUES (@tarefa_id, @painel, @data, @de, @para) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("de", variavel.de)
                    .SetParameter("para", variavel.para);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Tarefa_adiada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Tarefa_adiada WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Tarefa_adiada> Listar(Tarefa tarefa)
        {
            try
            {
                List<Tarefa_adiada> retorno = new List<Tarefa_adiada>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Tarefa_adiada WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", tarefa.tarefa_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Tarefa_adiada(tarefa, new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["de"]), Convert.ToDateTime(reader["para"])));
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
