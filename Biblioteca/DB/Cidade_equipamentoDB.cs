using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cidade_equipamentoDB
    {
        public void Salvar(Cidade_equipamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cidade_equipamento (cidade, equipamento, descricao, data, painel) VALUES (@cidade, @equipamento, @descricao, @data, @painel) ");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("equipamento", variavel.equipamento.codigo)
                    .SetParameter("descricao", variavel.descricao)
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

        public void Alterar(Cidade_equipamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cidade_equipamento SET cidade = @cidade, equipamento = @equipamento, descricao = @descricao, data = @data, painel = @painel WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo).SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("equipamento", variavel.equipamento.codigo)
                    .SetParameter("descricao", variavel.descricao)
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

        public void Excluir(Cidade_equipamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cidade_equipamento WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cidade_equipamento Buscar(int codigo)
        {
            try
            {
                Cidade_equipamento Cidade = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_equipamento WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cidade = new Cidade_equipamento(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, new Entidades.Equipamento() { codigo = Convert.ToInt32(reader["equipamento"]) }, Convert.ToString(reader["descricao"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) });
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

        public List<Cidade_equipamento> Listar()
        {
            try
            {
                List<Cidade_equipamento> Cidade = new List<Cidade_equipamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_equipamento ORDER BY cidade, descricao");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_equipamento(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, new Entidades.Equipamento() { codigo = Convert.ToInt32(reader["equipamento"]) }, Convert.ToString(reader["descricao"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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

        public List<Cidade_equipamento> Listar(Cidade cidade)
        {
            try
            {
                List<Cidade_equipamento> Cidade = new List<Cidade_equipamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_equipamento WHERE cidade = @cidade ORDER BY cidade, descricao");
                quey.SetParameter("cidade", cidade.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_equipamento(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, new Entidades.Equipamento() { codigo = Convert.ToInt32(reader["equipamento"]) }, Convert.ToString(reader["descricao"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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

        public List<Cidade_equipamento> Listar(Equipamento equipamento)
        {
            try
            {
                List<Cidade_equipamento> Cidade = new List<Cidade_equipamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_equipamento WHERE equipamento = @equipamento ORDER BY cidade, descricao");
                quey.SetParameter("equipamento", equipamento.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Cidade_equipamento(Convert.ToInt32(reader["codigo"]), new Entidades.Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, new Entidades.Equipamento() { codigo = Convert.ToInt32(reader["equipamento"]) }, Convert.ToString(reader["descricao"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }));
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
