using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Subtarefa_adiadaDB
    {
        public void Salvar(Subtarefa_adiada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Subtarefa_adiada (subsubtarefa_id, painel, data, de, para) VALUES (@subsubtarefa_id, @painel, @data, @de, @para) ");
                query.SetParameter("subtarefa_id", variavel.subtarefa_id)
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

        public void Excluir(Subtarefa_adiada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Subtarefa_adiada WHERE subsubtarefa_id = @subsubtarefa_id");
                query.SetParameter("subtarefa_id", variavel.subtarefa_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Subtarefa_adiada> Listar(Subtarefa subtarefa)
        {
            try
            {
                List<Subtarefa_adiada> retorno = new List<Subtarefa_adiada>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Subtarefa_adiada WHERE subtarefa_id = @subtarefa_id");
                query.SetParameter("subtarefa_id", subtarefa.subtarefa_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Subtarefa_adiada(subtarefa, new Painel(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["de"]), Convert.ToDateTime(reader["para"])));
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
