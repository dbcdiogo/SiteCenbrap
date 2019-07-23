using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cliente_obsDB
    {
        public void Salvar(Cliente_obs variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cliente_obs (cliente, painel, data, obs) VALUES (@cliente, @painel, @data, @obs) ");
                query.SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("obs", variavel.obs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cliente_obs variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cliente_obs SET cliente = @cliente, painel = @painel, data = @data, obs = @obs WHERE cliente_obs_id = @cliente_obs_id");
                query.SetParameter("cliente_obs_id", variavel.cliente_obs_id)
                    .SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("obs", variavel.obs); ;
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cliente_obs variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cliente_obs WHERE cliente_obs_id = @cliente_obs_id");
                query.SetParameter("cliente_obs_id", variavel.cliente_obs_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cliente_obs Buscar(int codigo)
        {
            try
            {
                Cliente_obs Cliente_obs = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_obs WHERE cliente_obs_id = @cliente_obs_id");
                quey.SetParameter("cliente_obs_id", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Cliente_obs = new Cliente_obs(Convert.ToInt32(reader["cliente_obs_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"]));
                }
                reader.Close();
                session.Close();

                return Cliente_obs;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cliente_obs> Listar()
        {
            try
            {
                List<Cliente_obs> Cliente_obs = new List<Cliente_obs>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_obs");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cliente_obs.Add(new Cliente_obs(Convert.ToInt32(reader["cliente_obs_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"])));
                }
                reader.Close();
                session.Close();

                return Cliente_obs;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cliente_obs> Listar(int cliente)
        {
            try
            {
                List<Cliente_obs> Cliente_obs = new List<Cliente_obs>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_obs WHERE cliente = @cliente ORDER BY data DESC");
                quey.SetParameter("cliente", cliente);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cliente_obs.Add(new Cliente_obs(Convert.ToInt32(reader["cliente_obs_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new PainelDB().Buscar(Convert.ToInt32(reader["painel"])), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"])));
                }
                reader.Close();
                session.Close();

                return Cliente_obs;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
