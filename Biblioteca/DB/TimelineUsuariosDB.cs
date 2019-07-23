using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineUsuariosDB
    {
        public void Salvar(TimelineUsuarios variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_usuarios (txnome, txemail, txsenha, txlogin, idperfil, flativo, txfoto, idaluno, flignorar, fldashboard) VALUES (@nome, @email, @senha, @login, @perfil, @ativo, @foto, @aluno, @ignorar, @dashboard) ");
                query.SetParameter("nome", variavel.txnome)
                    .SetParameter("email", variavel.txemail)
                    .SetParameter("senha", variavel.txsenha)
                    .SetParameter("login", variavel.txlogin)
                    .SetParameter("perfil", variavel.idperfil)
                    .SetParameter("ativo", variavel.flativo)
                    .SetParameter("foto", variavel.txfoto)
                    .SetParameter("aluno", variavel.idaluno)
                    .SetParameter("dashboard", variavel.fldashboard)
                    .SetParameter("ignorar", variavel.flignorar);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(TimelineUsuarios variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_usuarios set txnome = @nome, txemail = @email, txsenha = @senha, txlogin = @login, idperfil = @perfil, flativo = @ativo, txfoto = @foto, idaluno = @aluno, flignorar = @ignorar, fldashboard = @dashboard where idusuario = @idusuario ");
                query.SetParameter("idusuario", variavel.idusuario)
                    .SetParameter("nome", variavel.txnome)
                    .SetParameter("email", variavel.txemail)
                    .SetParameter("senha", variavel.txsenha)
                    .SetParameter("login", variavel.txlogin)
                    .SetParameter("perfil", variavel.idperfil)
                    .SetParameter("ativo", variavel.flativo)
                    .SetParameter("foto", variavel.txfoto)
                    .SetParameter("aluno", variavel.idaluno)
                    .SetParameter("dashboard", variavel.fldashboard)
                    .SetParameter("ignorar", variavel.flignorar);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(int idusuario)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_usuarios WHERE idusuario = @idusuario");
                query.SetParameter("idusuario", idusuario);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineUsuarios Buscar(int idusuario)
        {
            try
            {
                TimelineUsuarios usuario = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios WHERE idusuario = @idusuario");
                quey.SetParameter("idusuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    usuario = new TimelineUsuarios(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txsenha"]), Convert.ToString(reader["txlogin"]), Convert.ToInt32(reader["idperfil"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txfoto"]), Convert.ToInt32(reader["idaluno"]), Convert.ToInt32(reader["flignorar"]), Convert.ToInt32(reader["fldashboard"]));
                }
                reader.Close();
                session.Close();

                return usuario;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineUsuarios ValidaSenha(string login, string senha)
        {
            try
            {
                TimelineUsuarios usuario = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios WHERE txlogin = @login AND txsenha = @senha");
                quey.SetParameter("login", login).SetParameter("senha", senha);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    usuario = new TimelineUsuarios(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txsenha"]), Convert.ToString(reader["txlogin"]), Convert.ToInt32(reader["idperfil"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txfoto"]), Convert.ToInt32(reader["idaluno"]), Convert.ToInt32(reader["flignorar"]), Convert.ToInt32(reader["fldashboard"]));
                }
                reader.Close();
                session.Close();

                return usuario;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineUsuarios> Listar()
        {
            try
            {
                List<TimelineUsuarios> dataLote = new List<TimelineUsuarios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios ORDER BY txnome");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelineUsuarios(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txsenha"]), Convert.ToString(reader["txlogin"]), Convert.ToInt32(reader["idperfil"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txfoto"]), Convert.ToInt32(reader["idaluno"]), Convert.ToInt32(reader["flignorar"]), Convert.ToInt32(reader["fldashboard"])));
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

        public List<TimelineUsuarios> Listar(int pagina = 1)
        {
            try
            {
                List<TimelineUsuarios> dataLote = new List<TimelineUsuarios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios ORDER BY txnome OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelineUsuarios(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txsenha"]), Convert.ToString(reader["txlogin"]), Convert.ToInt32(reader["idperfil"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txfoto"]), Convert.ToInt32(reader["idaluno"]), Convert.ToInt32(reader["flignorar"]), Convert.ToInt32(reader["fldashboard"])));
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

        public List<TimelineUsuarios> Listar(int pagina = 1, string usuario = "")
        {
            try
            {
                List<TimelineUsuarios> dataLote = new List<TimelineUsuarios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_usuarios WHERE (txnome like '%" + usuario.Replace(" ", "%") + "%' or txlogin like '%" + usuario.Replace(" ", "%") + "%') ORDER BY txnome OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelineUsuarios(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToString(reader["txemail"]), Convert.ToString(reader["txsenha"]), Convert.ToString(reader["txlogin"]), Convert.ToInt32(reader["idperfil"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txfoto"]), Convert.ToInt32(reader["idaluno"]), Convert.ToInt32(reader["flignorar"]), Convert.ToInt32(reader["fldashboard"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_usuarios");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string usuario = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM timeline_usuarios WHERE (txnome like '%" + usuario.Replace(" ", "%") + "%' or txlogin like '%" + usuario.Replace(" ", "%") + "%')");
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
