using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cidade_localDB
    {
        public void Salvar(Cidade_local variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cidade_local (cidade, aula, hospedagem, nome, endereco, email, telefone, telefone1, link_google_maps, data, painel) VALUES (@cidade, @aula, @hospedagem, @nome, @endereco, @email, @telefone, @telefone1, @link_google_maps, @data, @painel) ");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("aula", variavel.aula)
                    .SetParameter("hospedagem", variavel.hospedagem)
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

        public void Alterar(Cidade_local variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cidade_local SET cidade = @cidade, aula = @aula, hospedagem = @hospedagem, nome = @nome, endereco = @endereco, telefone = @telefone, telefone1 = @telefone1, link_google_maps = @link_google_maps, data = @data, painel = @painel WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo).SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("aula", variavel.aula)
                    .SetParameter("hospedagem", variavel.hospedagem)
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

        public void Excluir(Cidade_local variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM cidade_local WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cidade_local Buscar(int codigo)
        {
            try
            {
                Cidade_local Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_local WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade_local(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToInt32(reader["aula"]), Convert.ToInt32(reader["hospedagem"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["email"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) });
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

        public Cidade_local BuscarCidade(int codigo)
        {
            try
            {
                Cidade_local Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_local WHERE cidade = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade_local(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToInt32(reader["aula"]), Convert.ToInt32(reader["hospedagem"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["email"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) });
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

        public List<Cidade_local> Listar()
        {
            try
            {
                List<Cidade_local> Cidade = new List<Cidade_local>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_local ORDER BY nome");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_local(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToInt32(reader["aula"]), Convert.ToInt32(reader["hospedagem"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["email"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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

        public List<Cidade_local> Listar(Cidade cidade)
        {
            try
            {
                List<Cidade_local> Cidade = new List<Cidade_local>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_local WHERE cidade = @cidade ORDER BY nome");
                quey.SetParameter("cidade", cidade);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_local(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToInt32(reader["aula"]), Convert.ToInt32(reader["hospedagem"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["email"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToString(reader["link_google_maps"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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
