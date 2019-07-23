using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Tarefa_cursoDB
    {
        public void Salvar(Tarefa_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tarefa_curso (tarefa_id, curso) VALUES (@tarefa_id, @curso) ");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("curso", variavel.curso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Tarefa_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Tarefa_curso WHERE tarefa_id = @tarefa_id AND curso = @curso");
                query.SetParameter("tarefa_id", variavel.tarefa_id.tarefa_id)
                    .SetParameter("curso", variavel.curso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Tarefa_curso> Listar(Tarefa tarefa)
        {
            try
            {
                List<Tarefa_curso> retorno = new List<Tarefa_curso>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT * FROM Tarefa_curso WHERE tarefa_id = @tarefa_id");
                query.SetParameter("tarefa_id", tarefa.tarefa_id);

                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Tarefa_curso(tarefa, new Curso(Convert.ToInt32(reader["curso"])) ));
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
