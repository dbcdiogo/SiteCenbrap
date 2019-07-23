using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;


namespace Biblioteca.DB
{
    public class CidadeDB
    {
        public void Salvar(Cidade variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cidade (cidade, estado, obs, data, painel, link) VALUES (@cidade, @estado, @obs, @data, @painel,@link) ");
                query.SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cidade variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cidade SET cidade = @cidade, estado = @estado, obs = @obs, data = @data, painel = @painel, link = @link WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cidade variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cidade WHERE codigo = @codigo; DELETE FROM cidade_local WHERE codigo = @codigo; DELETE FROM cidade_copiadora WHERE codigo = @codigo; DELETE FROM cidade_equipamento WHERE codigo = @codigo"); 
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cidade Buscar(int codigo)
        {
            try
            {
                Cidade Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo, c.cidade, c.estado, c.obs, c.data, c.painel, (SELECT cl.nome FROM cidade_local AS cl where cl.cidade = c.codigo) AS local, c.link FROM Cidade AS c WHERE c.codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["local"]), Convert.ToString(reader["link"]));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Cidade Buscar(string link)
        {
            try
            {
                Cidade Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo, c.cidade, c.estado, c.obs, c.data, c.painel, (SELECT cl.nome FROM cidade_local AS cl where cl.cidade = c.codigo) AS local, c.link FROM Cidade AS c WHERE c.link = @link");
                quey.SetParameter("link", link);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["local"]), Convert.ToString(reader["link"]));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cidade> Listar()
        {
            try
            {
                List<Cidade> Cidade = new List<Cidade>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade ORDER BY cidade");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, link: Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cidade> ListarCursosAtivos()
        {
            try
            {
                List<Cidade> Cidade = new List<Cidade>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo, c.cidade, c.estado, c.obs, c.data, c.painel, c.link FROM Cidade AS c WHERE exists (SELECT curso.codigo FROM curso WHERE curso.cidade_codigo = c.codigo AND curso.visualiza_site = 1) ORDER BY c.cidade");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, link: Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cidade> ListarTituloCurso(int id)
        {
            try
            {
                List<Cidade> Cidade = new List<Cidade>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT DISTINCT ci.codigo, ci.cidade, ci.estado, ci.obs, ci.data, ci.painel, ci.link FROM Cidade as ci JOIN curso as c ON ci.codigo = c.cidade_codigo WHERE c.titulo_curso = @id ORDER BY ci.cidade");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, link: Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cidade> ListarMidia()
        {
            try
            {
                List<Cidade> Cidade = new List<Cidade>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade WHERE exists (SELECT midia_id FROM midia_cidade WHERE cidade.codigo = midia_cidade.cidade) ORDER BY estado, cidade");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, link: Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cidade> ListarMidia(int midia_id)
        {
            try
            {
                List<Cidade> Cidade = new List<Cidade>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade WHERE exists (SELECT midia_id FROM midia_cidade WHERE cidade.codigo = midia_cidade.cidade AND midia_cidade.midia_id = @midia_id) ORDER BY estado, cidade").SetParameter("midia_id", midia_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, link: Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public List<string> Cidades(string estado)
        {
            try
            {
                List<string> Cidade = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT cidade FROM Cidade WHERE estado = @estado ORDER BY cidade").SetParameter("estado", estado);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(Convert.ToString(reader["cidade"]));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
