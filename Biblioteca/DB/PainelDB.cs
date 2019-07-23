using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PainelDB
    {
        public void Salvar(Painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO painel (nivel, financeiro, nome, login, senha, email) VALUES (@nivel, @financeiro, @nome, @login, @senha, @email) ");
                query.SetParameter("nivel", variavel.nivel)
                    .SetParameter("financeiro", variavel.financeiro)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("login", variavel.login)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("email", variavel.email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE painel SET nivel = @nivel, financeiro = @financeiro, nome = @nome, login = @login, senha = @senha, email = @email WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("nivel", variavel.nivel)
                    .SetParameter("financeiro", variavel.financeiro)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("login", variavel.login)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("email", variavel.email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Painel variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM painel WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("nivel", variavel.nivel)
                    .SetParameter("financeiro", variavel.financeiro)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("login", variavel.login)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("email", variavel.email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Painel Buscar(int codigo)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Painel Pedagogico(int codigo)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE codigo = @codigo AND pedagogico > 0");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Painel Marketing(int codigo)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE codigo = @codigo AND marketing > 0");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Painel Financeiro(int codigo)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE codigo = @codigo AND financeiro > 0");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Painel BuscarLogin(string login)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE login = @login");
                quey.SetParameter("login", login);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Painel Buscar(string login, string senha)
        {
            try
            {
                Painel painel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE login = @login AND senha = @senha");
                quey.SetParameter("login", login).SetParameter("senha", senha);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    painel = new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"]));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Painel> Listar(string chave)
        {
            try
            {
                List<Painel> painel = new List<Painel>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel WHERE nome LIKE @chave OR login LIKE @chave OR email LIKE @chave ORDER BY nome");
                quey.SetParameter("chave", "%"+chave+"%");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    painel.Add(new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"])));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Painel> Listar(Grupo_tarefas tarefa)
        {
            try
            {
                List<Painel> painel = new List<Painel>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM painel AS p WHERE NOT EXISTS (SELECT * FROM grupo_tarefas_painel AS gtp WHERE gtp.painel = painel.codigo AND gtp.grupo_tarefas_id = @grupo_tarefas_id)");
                quey.SetParameter("grupo_tarefas_id", tarefa.grupo_tarefas_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    painel.Add(new Painel(Convert.ToInt32(reader["codigo"]), Convert.ToInt32(reader["nivel"]), Convert.ToInt32(reader["financeiro"]), Convert.ToInt32(reader["pedagogico"]), Convert.ToInt32(reader["marketing"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["login"]), Convert.ToString(reader["senha"]), Convert.ToString(reader["email"])));
                }
                reader.Close();
                session.Close();

                return painel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
