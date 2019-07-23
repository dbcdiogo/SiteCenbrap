using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class HoteisDB
    {
        public void Salvar(Hoteis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO hoteis (txhotel, txendereco, txemail, txtelefone, txlink, fllocalaula, flhospedagem) VALUES (@txhotel, @txendereco, @txemail, @txtelefone, @txlink, @fllocalaula, @flhospedagem) ");
                query.SetParameter("txhotel", variavel.txhotel)
                    .SetParameter("txendereco", variavel.txendereco)
                    .SetParameter("txemail", variavel.txemail)
                    .SetParameter("txtelefone", variavel.txtelefone)
                    .SetParameter("txlink", variavel.txlink)
                    .SetParameter("fllocalaula", variavel.fllocalaula)
                    .SetParameter("flhospedagem", variavel.flhospedagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Hoteis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE hoteis SET txhotel = @txhotel, txendereco = @txendereco, txemail = @txemail, txtelefone = @txtelefone, txlink = @txlink, fllocalaula = @fllocalaula, flhospedagem = @flhospedagem WHERE idhotel = @idhotel");
                query.SetParameter("idhotel", variavel.idhotel)
                    .SetParameter("txhotel", variavel.txhotel)
                    .SetParameter("txendereco", variavel.txendereco)
                    .SetParameter("txemail", variavel.txemail)
                    .SetParameter("txtelefone", variavel.txtelefone)
                    .SetParameter("txlink", variavel.txlink)
                    .SetParameter("fllocalaula", variavel.fllocalaula)
                    .SetParameter("flhospedagem", variavel.flhospedagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Hoteis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM hoteis WHERE idhotel = @idhotel");
                query.SetParameter("idhotel", variavel.idhotel);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Hoteis Buscar(int id)
        {
            try
            {
                Hoteis hotel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM hoteis WHERE idhotel = @idhotel");
                quey.SetParameter("idhotel", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    hotel = new Hoteis(Convert.ToInt32(reader["idhotel"]), Convert.ToString(reader["txhotel"]), Convert.ToString(reader["txendereco"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txtelefone"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["fllocalaula"]), Convert.ToInt32(reader["flhospedagem"]));
                }
                reader.Close();
                session.Close();

                return hotel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Hoteis Buscar(string nomehotel)
        {
            try
            {
                Hoteis hotel = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM hoteis WHERE txhotel like '%" + nomehotel.Replace(" ", "%") + "%'");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    hotel = new Hoteis(Convert.ToInt32(reader["idhotel"]), Convert.ToString(reader["txhotel"]), Convert.ToString(reader["txendereco"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txtelefone"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["fllocalaula"]), Convert.ToInt32(reader["flhospedagem"]));
                }
                reader.Close();
                session.Close();

                return hotel;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Hoteis> Listar()
        {
            try
            {
                List<Hoteis> dataLote = new List<Hoteis>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM hoteis ORDER BY txhotel");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Hoteis(Convert.ToInt32(reader["idhotel"]), Convert.ToString(reader["txhotel"]), Convert.ToString(reader["txendereco"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txtelefone"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["fllocalaula"]), Convert.ToInt32(reader["flhospedagem"])));
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

        public List<Hoteis> Listar(int pagina = 1)
        {
            try
            {
                List<Hoteis> dataLote = new List<Hoteis>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM hoteis ORDER BY txhotel OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Hoteis(Convert.ToInt32(reader["idhotel"]), Convert.ToString(reader["txhotel"]), Convert.ToString(reader["txendereco"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txtelefone"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["fllocalaula"]), Convert.ToInt32(reader["flhospedagem"])));
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

        public List<Hoteis> Listar(int pagina = 1, string nomehotel = "")
        {
            try
            {
                List<Hoteis> dataLote = new List<Hoteis>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM hoteis WHERE txhotel like '%" + nomehotel.Replace(" ", "%") + "%' ORDER BY txhotel OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Hoteis(Convert.ToInt32(reader["idhotel"]), Convert.ToString(reader["txhotel"]), Convert.ToString(reader["txendereco"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txtelefone"]), Convert.ToString(reader["txlink"]), Convert.ToInt32(reader["fllocalaula"]), Convert.ToInt32(reader["flhospedagem"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM hoteis");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string nomehotel = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM hoteis WHERE txhotel like '%" + nomehotel.Replace(" ", "%") + "%'");
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
