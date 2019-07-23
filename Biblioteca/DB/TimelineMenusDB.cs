using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineMenusDB
    {
        public void Salvar(TimelineMenus variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_menus (idmenupai, txicone, txlink, txmenu, nrordem) VALUES (@idmenupai, @txicone, @txlink, @txmenu, @nrordem) ");
                query.SetParameter("idmenupai", variavel.idmenupai);
                query.SetParameter("txicone", variavel.txicone);
                query.SetParameter("txlink", variavel.txlink);
                query.SetParameter("txmenu", variavel.txmenu);
                query.SetParameter("nrordem", variavel.nrordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(TimelineMenus variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_menus set idmenupai = @idmenupai, txicone = @txicone, txlink = @txlink, txmenu = @txmenu, nrordem = @nrordem where idmenu = @idmenu ");
                query.SetParameter("idmenu", variavel.idmenu);
                query.SetParameter("idmenupai", variavel.idmenupai);
                query.SetParameter("txicone", variavel.txicone);
                query.SetParameter("txlink", variavel.txlink);
                query.SetParameter("txmenu", variavel.txmenu);
                query.SetParameter("nrordem", variavel.nrordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(TimelineMenus variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_menus WHERE idmenu = @idmenu");
                query.SetParameter("idmenu", variavel.idmenu);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineMenus Buscar(int idmenu)
        {
            try
            {
                TimelineMenus menu = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_menus WHERE idmenu = @idmenu");
                quey.SetParameter("idmenu", idmenu);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    menu = new TimelineMenus(Convert.ToInt32(reader["idmenu"]), Convert.ToInt32(reader["idmenupai"]), Convert.ToString(reader["txicone"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txmenu"]), Convert.ToInt32(reader["nrordem"]));
                }
                reader.Close();
                session.Close();

                return menu;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineMenus> ListarOrdenado()
        {
            try
            {
                List<TimelineMenus> menus = new List<TimelineMenus>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_menus WHERE idmenupai = 0 ORDER BY nrordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    menus.Add(new TimelineMenus(Convert.ToInt32(reader["idmenu"]), Convert.ToString(reader["txicone"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txmenu"]), Convert.ToInt32(reader["nrordem"])));
                }
                reader.Close();
                session.Close();

                return menus;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineMenus> ListarFilhos(int idmenupai)
        {
            try
            {
                List<TimelineMenus> menus = new List<TimelineMenus>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_menus WHERE idmenupai = @idmenupai ORDER BY nrordem");
                quey.SetParameter("idmenupai", idmenupai);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    menus.Add(new TimelineMenus(Convert.ToInt32(reader["idmenu"]), Convert.ToInt32(reader["idmenupai"]), Convert.ToString(reader["txicone"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txmenu"]), Convert.ToInt32(reader["nrordem"])));
                }
                reader.Close();
                session.Close();

                return menus;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineMenus> Listar(int pagina = 1)
        {
            try
            {
                List<TimelineMenus> menus = new List<TimelineMenus>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_menus ORDER BY txmenu OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    menus.Add(new TimelineMenus(Convert.ToInt32(reader["idmenu"]), Convert.ToInt32(reader["idmenupai"]), Convert.ToString(reader["txicone"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txmenu"]), Convert.ToInt32(reader["nrordem"])));
                }
                reader.Close();
                session.Close();

                return menus;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineMenus> Listar(int pagina = 1, string menu = "")
        {
            try
            {
                List<TimelineMenus> menus = new List<TimelineMenus>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_menus WHERE txmenu like '%" + menu.Replace(" ", "%") + "%' ORDER BY txmenu OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    menus.Add(new TimelineMenus(Convert.ToInt32(reader["idmenu"]), Convert.ToInt32(reader["idmenupai"]), Convert.ToString(reader["txicone"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txmenu"]), Convert.ToInt32(reader["nrordem"])));
                }
                reader.Close();
                session.Close();

                return menus;
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_menus");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string menu = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_menus WHERE txmenu like '%" + menu.Replace(" ", "%") + "%'");
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
