using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class BannersDB
    {
        public int Salvar(Banners variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Banners (idsite, txfoto, txlink, nrordem, flativo, dtinicio, dtfim) output INSERTED.idbanner VALUES (@idsite, @txfoto, @txlink, @nrordem, @flativo, @dtinicio, @dtfim)");
                query.SetParameter("idsite", variavel.idsite)
                    .SetParameter("txfoto", variavel.txfoto)
                    .SetParameter("txlink", variavel.txlink)
                    .SetParameter("nrordem", variavel.nrordem)
                    .SetParameter("flativo", variavel.flativo)
                    .SetParameter("dtinicio", variavel.dtinicio)
                    .SetParameter("dtfim", variavel.dtfim);
                id = query.ExecuteScalar();
                session.Close();
                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Banners variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Banners SET idsite = @idsite, txfoto = @txfoto, txlink = @txlink, nrordem = @nrordem, flativo = @flativo, dtinicio = @dtinicio, dtfim = @dtfim WHERE idbanner = @idbanner");
                query.SetParameter("idsite", variavel.idsite)
                    .SetParameter("txfoto", variavel.txfoto)
                    .SetParameter("txlink", variavel.txlink)
                    .SetParameter("nrordem", variavel.nrordem)
                    .SetParameter("flativo", variavel.flativo)
                    .SetParameter("dtinicio", variavel.dtinicio)
                    .SetParameter("dtfim", variavel.dtfim)
                    .SetParameter("idbanner", variavel.idbanner);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Banners variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Banners where idbanner = @idbanner");
                query.SetParameter("idbanner", variavel.idbanner);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Banners Buscar(int id)
        {
            try
            {
                Banners banner = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM banners WHERE idbanner = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    banner = new Banners(Convert.ToInt32(reader["idbanner"]), Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txfoto"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["nrordem"]), Convert.ToInt32(reader["flativo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]));
                }
                reader.Close();
                session.Close();

                return banner;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Total(int site = 0)
        {
            int r = 0;
            DBSession session = new DBSession();
            string cmdtxt = "SELECT count(*) as total FROM banners WHERE 1=1 ";
            if (site != 0) { cmdtxt += "AND idsite = '" + site + "'"; }
            Query quey = session.CreateQuery(cmdtxt);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<Banners> Listar(int pagina = 1, int site = 0)
        {
            try
            {
                List<Banners> dataLote = new List<Banners>();

                DBSession session = new DBSession();
                string cmdtxt = "SELECT * FROM banners WHERE 1=1 ";
                if (site != 0) { cmdtxt += "AND idsite = '" + site + "' "; }
                cmdtxt += "ORDER BY idsite, nrordem OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY";
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Banners(Convert.ToInt32(reader["idbanner"]), Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txfoto"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["nrordem"]), Convert.ToInt32(reader["flativo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"])));
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

        public List<Banners> ListarPorSite(int site = 0)
        {
            try
            {
                List<Banners> dataLote = new List<Banners>();

                DBSession session = new DBSession();
                string cmdtxt = "SELECT * FROM banners WHERE idsite = @site and flativo = 1 and cast(dtinicio as date) <= cast(getdate() as date) and ((cast(dtfim as date) >= cast(getdate() as date)) or (cast(dtfim as date) = '1900-01-01')) ORDER BY nrordem";
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("site", site);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Banners(Convert.ToInt32(reader["idbanner"]), Convert.ToInt32(reader["idsite"]), Convert.ToString(reader["txfoto"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["nrordem"]), Convert.ToInt32(reader["flativo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"])));
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

        public List<Banners> ListarBanners(int site)
        {
            try
            {
                List<Banners> dataLote = new List<Banners>();

                DBSession session = new DBSession();
                string cmdtxt = "select * from banners where idsite = @site and flativo = 1 and cast(dtinicio as date) <= cast(getdate() as date) and ((cast(dtfim as date) >= cast(getdate() as date)) or (cast(dtfim as date) = '1900-01-01')) order by nrordem";
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("site", site);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Banners(Convert.ToInt32(reader["idbanner"]), Convert.ToString(reader["txlink"])));
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
