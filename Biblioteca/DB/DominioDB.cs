using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DominioDB
    {
        public void Salvar(Dominio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_dominios (txdominio, txsmtp, txporta, flautenticacao) VALUES (@dominio, @smtp, @porta, @autenticacao) ");
                query.SetParameter("dominio", variavel.dominio)
                    .SetParameter("smtp", variavel.smtp)
                    .SetParameter("porta", variavel.porta)
                    .SetParameter("autenticacao", variavel.autenticacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Dominio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_dominios SET txdominio = @dominio, txsmtp = @smtp, txporta = @porta, flautenticacao = @autenticacao WHERE iddominio = @id");
                query.SetParameter("dominio", variavel.dominio)
                    .SetParameter("smtp", variavel.smtp)
                    .SetParameter("porta", variavel.porta)
                    .SetParameter("autenticacao", variavel.autenticacao)
                    .SetParameter("id", variavel.iddominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Dominio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_dominios WHERE iddominio = @id");
                query.SetParameter("id", variavel.iddominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Dominio Buscar(int id)
        {
            try
            {
                Dominio dominio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_dominios WHERE iddominio = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dominio = new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"]));
                }
                reader.Close();
                session.Close();

                return dominio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Dominio Buscar(string usuario)
        {
            try
            {
                Dominio dominio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_dominios WHERE txdominio = @dominio");
                quey.SetParameter("txdominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dominio = new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"]));
                }
                reader.Close();
                session.Close();

                return dominio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Dominio> Listar(int pagina = 1)
        {
            try
            {
                List<Dominio> dataLote = new List<Dominio>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_dominios ORDER BY txdominio OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"])));
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

        public List<Dominio> Listar(int pagina = 1, string dominio = "")
        {
            try
            {
                List<Dominio> dataLote = new List<Dominio>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_dominios WHERE txdominio like '%" + dominio.Replace(" ", "%") + "%' ORDER BY txdominio OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("dominio", dominio);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"])));
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

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_dominios");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string dominio = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_dominios WHERE txdominio like '%" + dominio.Replace(" ", "%") + "%'");
            quey.SetParameter("dominio", dominio);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }
    }
}
