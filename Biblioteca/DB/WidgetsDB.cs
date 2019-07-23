using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class WidgetsDB
    {
        public void Salvar(Widgets variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_widgets (txwidget, txaplicativo, nrheight, nrwidth, idgrupo) VALUES (@txwidget, @txaplicativo, @nrheight, @nrwidth, @idgrupo) ");
                query.SetParameter("txwidget", variavel.txwidget)
                    .SetParameter("txaplicativo", variavel.txaplicativo)
                    .SetParameter("nrheight", variavel.nrheight)
                    .SetParameter("nrwidth", variavel.nrwidth)
                    .SetParameter("idgrupo", variavel.idgrupo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Widgets variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_widgets SET txwidget = @txwidget, txaplicativo = @txaplicativo, nrheight = @nrheight, nrwidth = @nrwidth, idgrupo = @idgrupo WHERE idwidget = @idwidget");
                query.SetParameter("txwidget", variavel.txwidget)
                    .SetParameter("txaplicativo", variavel.txaplicativo)
                    .SetParameter("nrheight", variavel.nrheight)
                    .SetParameter("nrwidth", variavel.nrwidth)
                    .SetParameter("idwidget", variavel.idwidget)
                    .SetParameter("idgrupo", variavel.idgrupo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Widgets variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_widgets WHERE idwidget = @idwidget");
                query.SetParameter("idwidget", variavel.idwidget);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Widgets Buscar(int id)
        {
            try
            {
                Widgets wdg = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets WHERE idwidget = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    wdg = new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"]));
                }
                reader.Close();
                session.Close();

                return wdg;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Widgets Buscar(string widget)
        {
            try
            {
                Widgets wdg = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets WHERE txwidget = @widget");
                quey.SetParameter("widget", widget);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    wdg = new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"]));
                }
                reader.Close();
                session.Close();

                return wdg;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Widgets> Listar()
        {
            try
            {
                List<Widgets> dataLote = new List<Widgets>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets ORDER BY txwidget");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"])));
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

        public List<Widgets> ListarDoPerfil(string perfil, int usuario = 0)
        {
            try
            {
                List<Widgets> dataLote = new List<Widgets>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT tw.*
                    FROM timeline_widgets tw
                    WHERE tw.idwidget in (" + perfil + ") AND tw.idwidget NOT IN(select idwidget FROM timeline_usuarios_widgets WHERE idusuario = " + usuario + ") ORDER BY tw.idgrupo, tw.txwidget");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"])));
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

        public List<Widgets> ListarPerfil(string perfil, int idusuario)
        {
            try
            {
                List<Widgets> dataLote = new List<Widgets>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT w.idwidget, w.txwidget, w.txaplicativo, ISNULL(uw.nrwidth, w.nrwidth) as width, ISNULL(uw.nrheight, w.nrheight) as height, uw.nrtop, uw.nrleft, uw.txclass, uw.txcor 
                    FROM timeline_widgets w
                    INNER JOIN timeline_usuarios_widgets uw ON uw.idwidget = w.idwidget and uw.idusuario = " + idusuario + " WHERE w.idwidget in (" + perfil + ") order by nrtop, nrleft ");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["height"]), Convert.ToInt32(reader["width"]), Convert.ToInt32(reader["nrtop"]), Convert.ToInt32(reader["nrleft"]), Convert.ToString(reader["txclass"]), Convert.ToString(reader["txcor"])));
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

        public List<Widgets> Listar(int pagina = 1)
        {
            try
            {
                List<Widgets> dataLote = new List<Widgets>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets ORDER BY txwidget OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"])));
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

        public List<Widgets> Listar(int pagina = 1, string widget = "")
        {
            try
            {
                List<Widgets> dataLote = new List<Widgets>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets WHERE txwidget like '%" + widget.Replace(" ", "%") + "%' ORDER BY txwidget OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("widget", widget);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Widgets(Convert.ToInt32(reader["idwidget"]), Convert.ToString(reader["txwidget"]), Convert.ToString(reader["txaplicativo"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["idgrupo"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_widgets");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string widget = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_widgets WHERE txwidget like '%" + widget.Replace(" ", "%") + "%'");
            quey.SetParameter("widget", widget);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public void SalvarWidgetUsuario(WidgetsUsuario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_usuarios_widgets (idwidget, idusuario, nrheight, nrwidth, nrtop, nrleft, txclass, txcor) VALUES (@idwidget, @idusuario, @nrheight, @nrwidth, @nrtop, @nrleft, @txclass, @txcor) ");
                query.SetParameter("idwidget", variavel.idwidget)
                    .SetParameter("idusuario", variavel.idusuario)
                    .SetParameter("nrheight", variavel.nrheight)
                    .SetParameter("nrwidth", variavel.nrwidth)
                    .SetParameter("nrtop", variavel.nrtop)
                    .SetParameter("nrleft", variavel.nrleft)
                    .SetParameter("txclass", variavel.txclass)
                    .SetParameter("txcor", variavel.txcor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarWidgetUsuario(WidgetsUsuario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_usuarios_widgets SET nrheight = @nrheight, nrwidth = @nrwidth, nrtop = @nrtop, nrleft = @nrleft, txclass = @txclass, txcor = @txcor WHERE idwidget = @idwidget and idusuario = @idusuario");
                query.SetParameter("idwidget", variavel.idwidget)
                    .SetParameter("idusuario", variavel.idusuario)
                    .SetParameter("nrheight", variavel.nrheight)
                    .SetParameter("nrwidth", variavel.nrwidth)
                    .SetParameter("nrtop", variavel.nrtop)
                    .SetParameter("nrleft", variavel.nrleft)
                    .SetParameter("txclass", variavel.txclass)
                    .SetParameter("txcor", variavel.txcor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirWidgetUsuario(WidgetsUsuario variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_usuarios_widgets WHERE idwidget = @idwidget and idusuario = @idusuario");
                query.SetParameter("idwidget", variavel.idwidget);
                query.SetParameter("idusuario", variavel.idusuario);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public WidgetsUsuario BuscarWidgetUsuario(int id, int id2)
        {
            try
            {
                WidgetsUsuario wdg = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios_widgets WHERE idwidget = @idwidget and idusuario = @idusuario");
                quey.SetParameter("idwidget", id);
                quey.SetParameter("idusuario", id2);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    wdg = new WidgetsUsuario(Convert.ToInt32(reader["idwidget"]), Convert.ToInt32(reader["idusuario"]), Convert.ToInt32(reader["nrheight"]), Convert.ToInt32(reader["nrwidth"]), Convert.ToInt32(reader["nrtop"]), Convert.ToInt32(reader["nrleft"]), Convert.ToString(reader["txclass"]), Convert.ToString(reader["txcor"]));
                }
                reader.Close();
                session.Close();

                return wdg;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public WidgetsGrupos BuscarGrupo(int id)
        {
            try
            {
                WidgetsGrupos wdg = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets_grupos WHERE idgrupo = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    wdg = new WidgetsGrupos(Convert.ToInt32(reader["idgrupo"]), Convert.ToString(reader["txgrupo"]));
                }
                reader.Close();
                session.Close();

                return wdg;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<WidgetsGrupos> Grupos()
        {
            try
            {
                List<WidgetsGrupos> dataLote = new List<WidgetsGrupos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_widgets_grupos ORDER BY txgrupo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new WidgetsGrupos(Convert.ToInt32(reader["idgrupo"]), Convert.ToString(reader["txgrupo"])));
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
