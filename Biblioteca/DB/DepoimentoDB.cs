using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DepoimentoDB
    {
        public void Salvar(Depoimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO depoimento (ativo,data,nome,cidade,curso,texto,dominio) VALUES (@ativo,@data,@nome,@cidade,@curso,@texto,@dominio) ");
                query.SetParameter("ativo", variavel.ativo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("curso", variavel.curso)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("dominio", variavel.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Depoimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE depoimento SET ativo = @ativo, data = @data, nome = @nome, cidade = @cidade, curso = @curso, texto = @texto, dominio = @dominio WHERE depoimento_id = @depoimento_id");
                query.SetParameter("depoimento_id", variavel.depoimento_id)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("curso", variavel.curso)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("dominio", variavel.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Depoimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM depoimento WHERE depoimento_id = @depoimento_id");
                query.SetParameter("depoimento_id", variavel.depoimento_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Depoimento Buscar(int id)
        {
            try
            {
                Depoimento depoimento = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Depoimento WHERE depoimento_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    depoimento = new Depoimento(Convert.ToInt32(reader["depoimento_id"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]));
                }
                reader.Close();
                session.Close();

                return depoimento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Depoimento> Listar(string dominio = "", bool ativo = true)
        {
            try
            {
                string executar = "SELECT * FROM Depoimento WHERE depoimento_id > 0";

                if (ativo)
                    executar += " AND ativo = 1";

                if (dominio != "")
                    executar += " AND dominio = '" + dominio + "'";

                executar += " ORDER BY dominio, data DESC";

                List<Depoimento> depoimento = new List<Depoimento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    depoimento.Add(new Depoimento(Convert.ToInt32(reader["depoimento_id"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"])));
                }
                reader.Close();
                session.Close();

                return depoimento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
