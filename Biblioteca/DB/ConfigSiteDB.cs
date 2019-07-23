using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ConfigSiteDB
    {
        public void Salvar(ConfigSite variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO ConfigSite (imagem, dominio) VALUES (@imagem, @dominio) ");
                query.SetParameter("imagem", variavel.imagem)
                    .SetParameter("dominio", variavel.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(ConfigSite variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE ConfigSite SET imagem = @imagem WHERE dominio = @dominio");
                query.SetParameter("dominio", variavel.dominio)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(ConfigSite variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM ConfigSite WHERE dominio = @dominio");
                query.SetParameter("dominio", variavel.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ConfigSite Buscar(string dominio)
        {
            try
            {
                ConfigSite dataLote = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM ConfigSite WHERE dominio = @dominio");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dataLote = new ConfigSite(Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"]));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ConfigSite> Listar()
        {
            try
            {
                List<ConfigSite> dataLote = new List<ConfigSite>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM ConfigSite ORDER BY dominio");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ConfigSite(Convert.ToString(reader["dominio"]), Convert.ToString(reader["imagem"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
