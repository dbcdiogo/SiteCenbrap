using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelinePerfisDB
    {
        public void Salvar(TimelinePerfis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_perfis (txperfil, menus, widgets) VALUES (@perfil, @menus, @widgets) ");
                query.SetParameter("perfil", variavel.txperfil);
                query.SetParameter("menus", variavel.menus);
                query.SetParameter("widgets", variavel.widgets);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(TimelinePerfis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_perfis set txperfil = @perfil, menus = @menus, widgets = @widgets where idperfil = @idperfil ");
                query.SetParameter("perfil", variavel.txperfil);
                query.SetParameter("idperfil", variavel.idperfil);
                query.SetParameter("widgets", variavel.widgets);
                query.SetParameter("menus", variavel.menus);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(TimelinePerfis variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_perfis WHERE idperfil = @idperfil) ");
                query.SetParameter("idperfil", variavel.idperfil);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelinePerfis Buscar(int idperfil)
        {
            try
            {
                TimelinePerfis perfil = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_perfis WHERE idperfil = @idperfil");
                quey.SetParameter("idperfil", idperfil);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    perfil = new TimelinePerfis(Convert.ToInt32(reader["idperfil"]), Convert.ToString(reader["txperfil"]), Convert.ToString(reader["menus"]), Convert.ToString(reader["widgets"]));
                }
                reader.Close();
                session.Close();

                return perfil;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelinePerfis> Listar(int pagina = 1)
        {
            try
            {
                List<TimelinePerfis> dataLote = new List<TimelinePerfis>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_perfis ORDER BY txperfil OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelinePerfis(Convert.ToInt32(reader["idperfil"]), Convert.ToString(reader["txperfil"]), Convert.ToString(reader["menus"]), Convert.ToString(reader["widgets"])));
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

        public List<TimelinePerfis> Listar(int pagina = 1, string perfil = "")
        {
            try
            {
                List<TimelinePerfis> dataLote = new List<TimelinePerfis>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_perfis WHERE txperfil like '%" + perfil.Replace(" ", "%") + "%' ORDER BY txperfil OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("perfil", perfil);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelinePerfis(Convert.ToInt32(reader["idperfil"]), Convert.ToString(reader["txperfil"]), Convert.ToString(reader["menus"]), Convert.ToString(reader["widgets"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_perfis");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string perfil = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_perfis WHERE txperfil like '%" + perfil.Replace(" ", "%") + "%'");
            quey.SetParameter("perfil", perfil);
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
