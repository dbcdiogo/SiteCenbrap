using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DB
{
    public class Grupo_tarefas_painelDB
    {
        public void Salvar(Grupo_tarefas_painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Grupo_tarefas_painel (grupo_tarefas_id, painel) VALUES (@grupo_tarefas_id, @painel) ");
                query.SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id.grupo_tarefas_id)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Grupo_tarefas_painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Grupo_tarefas_painel WHERE grupo_tarefas_id = @grupo_tarefas_id AND painel = @painel");
                query.SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id.grupo_tarefas_id)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Grupo_tarefas_painel Buscar(int grupo_tarefas_id, int painel)
        {
            try
            {
                Grupo_tarefas_painel retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Grupo_tarefas_painel WHERE grupo_tarefas_id = @grupo_tarefas_id AND painel = @painel");
                quey.SetParameter("grupo_tarefas_id", grupo_tarefas_id)
                    .SetParameter("painel", painel);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Grupo_tarefas_painel(new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"])), new Painel(Convert.ToInt32(reader["painel"])));
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

        public List<Grupo_tarefas_painel> Listar(Grupo_tarefas grupo_tarefas)
        {
            try
            {
                List<Grupo_tarefas_painel> retorno = new List<Grupo_tarefas_painel>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Grupo_tarefas_painel WHERE grupo_tarefas_id = @id");
                quey.SetParameter("id", grupo_tarefas.grupo_tarefas_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Grupo_tarefas_painel(grupo_tarefas, new Entidades.Painel(Convert.ToInt32(reader["painel"]))));
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

        public List<Grupo_tarefas_painel> Listar(Painel painel)
        {
            try
            {
                List<Grupo_tarefas_painel> retorno = new List<Grupo_tarefas_painel>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Grupo_tarefas_painel WHERE painel = @id");
                quey.SetParameter("id", painel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Grupo_tarefas_painel(new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"])), painel));
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
