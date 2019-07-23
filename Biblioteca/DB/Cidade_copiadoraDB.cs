using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cidade_copiadoraDB
    {
        public void Salvar(Cidade_copiadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cidade_copiadora (cidade, responsavel, email1, nome, endereco, email, telefone, telefone1, link_google_maps, data, painel) VALUES (@cidade, @responsavel, @email1, @nome, @endereco, @email, @telefone, @telefone1, @link_google_maps, @data, @painel) ");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("responsavel", variavel.responsavel)
                    .SetParameter("email", variavel.email)
                    .SetParameter("email1", variavel.email1)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("telefone1", variavel.telefone1)
                    .SetParameter("link_google_maps", variavel.link_google_maps)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cidade_copiadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cidade_copiadora SET cidade = @cidade, responsavel = @responsavel, email1 = @email1, nome = @nome, endereco = @endereco, email = @email, telefone = @telefone, telefone1 = @telefone1, link_google_maps = @link_google_maps, data = @data, painel = @painel WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("responsavel", variavel.responsavel)
                    .SetParameter("email", variavel.email)
                    .SetParameter("email1", variavel.email1)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("telefone1", variavel.telefone1)
                    .SetParameter("link_google_maps", variavel.link_google_maps)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cidade_copiadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cidade_copiadora WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cidade_copiadora Buscar(int codigo)
        {
            try
            {
                Cidade_copiadora Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_copiadora WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade_copiadora(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToString(reader["responsavel"]), Convert.ToString(reader["email"]), Convert.ToString(reader["email1"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) });
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

        public Cidade_copiadora BuscarCidade(int codigo)
        {
            try
            {
                Cidade_copiadora Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_copiadora WHERE cidade = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade_copiadora(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToString(reader["responsavel"]), Convert.ToString(reader["email"]), Convert.ToString(reader["email1"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) });
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

        public List<Cidade_copiadora> Listar()
        {
            try
            {
                List<Cidade_copiadora> Cidade = new List<Cidade_copiadora>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_copiadora ORDER BY cidade, nome");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_copiadora(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToString(reader["responsavel"]), Convert.ToString(reader["email"]), Convert.ToString(reader["email1"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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

        public List<Cidade_copiadora> Listar(Cidade cidade)
        {
            try
            {
                List<Cidade_copiadora> Cidade = new List<Cidade_copiadora>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_copiadora WHERE cidade = @cidade ORDER BY cidade, descricao");
                quey.SetParameter("cidade", cidade.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_copiadora(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToString(reader["responsavel"]), Convert.ToString(reader["email"]), Convert.ToString(reader["email1"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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
