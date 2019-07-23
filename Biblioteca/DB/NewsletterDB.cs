using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class NewsletterDB
    {
        public void Salvar(Newsletter variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Newsletter (nome, email, curso, data, cidade, profissao, envio_email, telefone, idlandingpage) VALUES (@nome, @email, @curso, @data, @cidade, @profissao, @envio_email, @telefone, @idlandingpage) ");
                query.SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("curso", variavel.curso)
                    .SetParameter("data", variavel.data)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("profissao", variavel.profissao)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("idlandingpage", variavel.idlandingpage);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(Newsletter variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Newsletter (nome, email, curso, data, cidade, profissao, envio_email, telefone, idlandingpage) output INSERTED.codigo VALUES (@nome, @email, @curso, @data, @cidade, @profissao, @envio_email, @telefone, @idlandingpage) ");
                query.SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("curso", variavel.curso)
                    .SetParameter("data", variavel.data)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("profissao", variavel.profissao)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("idlandingpage", variavel.idlandingpage);
                id = query.ExecuteScalar();
                session.Close();
                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Newsletter variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE newsletter SET nome = @nome, email = @email, curso = @curso, data = @data, cidade = @cidade, profissao = @profissao, envio_email = @envio_email, telefone = @telefone, idlandingpage = @idlandingpage WHERE codigo = @codigo");
                query.SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("curso", variavel.curso)
                    .SetParameter("data", variavel.data)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("profissao", variavel.profissao)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("codigo", variavel.codigo)
                    .SetParameter("idlandingpage", variavel.idlandingpage);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Newsletter variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM newsletter WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Newsletter Buscar(int codigo)
        {
            try
            {
                Newsletter newsletter = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome,  '') AS nome, isnull(email, '') AS email, isnull(curso, '') AS curso, isnull(data, '1900-01-01') AS data, isnull(cidade, '') AS cidade, isnull(profissao, '') AS profissao, isnull(envio_email, 1) AS envio_email, isnull(telefone, '') as telefone, isnull(idlandingpage, '') AS idlandingpage FROM Newsletter WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    newsletter = new Newsletter(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["profissao"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"]));
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Newsletter Buscar(string email)
        {
            try
            {
                Newsletter newsletter = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome,  '') AS nome, isnull(email, '') AS email, isnull(curso, '') AS curso, isnull(data, '1900-01-01') AS data, isnull(cidade, '') AS cidade, isnull(profissao, '') AS profissao, isnull(envio_email, 1) AS envio_email, isnull(telefone, '') as telefone, isnull(idlandingpage, '') AS idlandingpage FROM Newsletter WHERE email = @email");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    newsletter = new Newsletter(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["profissao"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"]));
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(string email)
        {
            try
            {
                bool newsletter = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo FROM Newsletter WHERE email = @email");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    newsletter = true;
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public List<Newsletter> Listar()
        {
            try
            {
                List<Newsletter> newsletter = new List<Newsletter>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome,  '') AS nome, isnull(email, '') AS email, isnull(curso, '') AS curso, isnull(data, '1900-01-01') AS data, isnull(cidade, '') AS cidade, isnull(profissao, '') AS profissao, isnull(envio_email, 1) AS envio_email, isnull(telefone, '') as telefone, isnull(idlandingpage, '') AS idlandingpage FROM Newsletter");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    newsletter.Add(new Newsletter(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["profissao"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"])));
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Newsletter> Listar(int pagina = 1)
        {
            try
            {
                List<Newsletter> newsletter = new List<Newsletter>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome,  '') AS nome, isnull(email, '') AS email, isnull(curso, '') AS curso, isnull(data, '1900-01-01') AS data, isnull(cidade, '') AS cidade, isnull(profissao, '') AS profissao, isnull(envio_email, 1) AS envio_email, isnull(telefone, '') as telefone, isnull(idlandingpage, '') AS idlandingpage FROM Newsletter ORDER BY email OFFSET 30 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    newsletter.Add(new Newsletter(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["profissao"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"])));
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Newsletter> Listar(int pagina = 1, string chave = "")
        {
            try
            {
                List<Newsletter> newsletter = new List<Newsletter>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome,  '') AS nome, isnull(email, '') AS email, isnull(curso, '') AS curso, isnull(data, '1900-01-01') AS data, isnull(cidade, '') AS cidade, isnull(profissao, '') AS profissao, isnull(envio_email, 1) AS envio_email, isnull(telefone, '') as telefone, isnull(idlandingpage, '') AS idlandingpage FROM Newsletter WHERE email = @chave OR nome = @chave OR cidade = @chave OR curso = @chave OR profissao = @chave ORDER BY email OFFSET 30 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("chave", chave);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    newsletter.Add(new Newsletter(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["profissao"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"])));
                }
                reader.Close();
                session.Close();

                return newsletter;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM newsletter");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string chave = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM newsletter WHERE email = @chave OR nome = @chave OR cidade = @chave OR curso = @chave OR profissao = @chave");
            quey.SetParameter("chave", chave);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public void SalvarFormulario(NewsletterFormulario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO newsletter_formulario (idnewsletter, idform, txresposta) VALUES (@newsletter, @formulario, @resposta) ");
                query.SetParameter("newsletter", variavel.codigo)
                    .SetParameter("formulario", variavel.formulario)
                    .SetParameter("resposta", variavel.resposta);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
