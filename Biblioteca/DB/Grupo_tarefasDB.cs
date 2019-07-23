using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Grupo_tarefasDB
    {
        public void Salvar(Grupo_tarefas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Grupo_tarefas (titulo,cor) VALUES (@titulo,@cor) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("cor", variavel.cor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Salvar(string titulo, string cor)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Grupo_tarefas (titulo,cor) VALUES (@titulo,@cor) ");
                query.SetParameter("titulo", titulo)
                    .SetParameter("cor", cor);
                query.ExecuteUpdate();
                session.Close();

                int retorno = 0;

                session = new DBSession();
                query = session.CreateQuery("SELECT grupo_tarefas_id FROM Grupo_tarefas WHERE titulo = @titulo AND cor = @cor ORDER BY grupo_tarefas_id DESC");
                query.SetParameter("titulo", titulo)
                    .SetParameter("cor", cor);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["grupo_tarefas_id"]);
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

        public void Alterar(Grupo_tarefas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Grupo_tarefas SET titulo = @titulo, cor = @cor WHERE grupo_tarefas_id = @grupo_tarefas_id ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Grupo_tarefas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Grupo_tarefas WHERE grupo_tarefas_id = @grupo_tarefas_id; DELETE FROM grupo_tarefas_painel WHERE grupo_tarefas_id = @grupo_tarefas_id; DELETE FROM grupo_tarefa_grupo WHERE grupo_tarefas_id = @grupo_tarefas_id;");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("grupo_tarefas_id", variavel.grupo_tarefas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Grupo_tarefas Buscar(int grupo_tarefas_id)
        {
            try
            {
                Grupo_tarefas retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Grupo_tarefas WHERE grupo_tarefas_id = @grupo_tarefas_id");
                quey.SetParameter("grupo_tarefas_id", grupo_tarefas_id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["cor"]));
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

        public List<Grupo_tarefas> Listar()
        {
            try
            {
                List<Grupo_tarefas> retorno = new List<Grupo_tarefas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Grupo_tarefas ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["cor"])));
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

        public List<Grupo_tarefas> Listar(Painel painel)
        {
            try
            {
                List<Grupo_tarefas> retorno = new List<Grupo_tarefas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT gt.grupo_tarefas_id, gt.titulo, gt.cor FROM Grupo_tarefas AS gt JOIN Grupo_tarefas_painel AS gtp ON gt.grupo_tarefas_id = gtp.grupo_tarefas_id WHERE gtp.painel = @painel ORDER BY gt.titulo");
                quey.SetParameter("painel", painel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Grupo_tarefas(Convert.ToInt32(reader["grupo_tarefas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["cor"])));
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
