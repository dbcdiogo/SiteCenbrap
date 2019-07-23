using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineTarefasDB
    {
        public int SalvarRetornar(TimelineTarefas variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Timeline_Eventos (idcurso, txtitulo, txtexto, dtevento, fltipo, idusuario, dttarefa, dtdeadline, dteventoini, dteventofim) output INSERTED.idevento VALUES (@curso, @titulo, @texto, @data, @tipo, @usuario, @data_tarefa, @data_deadline, @data_inicio, @data_fim) ");
                query.SetParameter("curso", variavel.idcurso);
                query.SetParameter("titulo", variavel.txtitulo);
                query.SetParameter("texto", variavel.txtexto);
                query.SetParameter("data", variavel.dtevento);                
                query.SetParameter("tipo", variavel.fltipo);
                query.SetParameter("usuario", variavel.idusuario);
                query.SetParameter("data_tarefa", variavel.dttarefa);
                query.SetParameter("data_deadline", variavel.dtdeadline);
                query.SetParameter("data_inicio", variavel.dteventoini);
                query.SetParameter("data_fim", variavel.dteventofim);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(TimelineTarefas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Timeline_Eventos SET idcurso = @curso, txtitulo = @titulo, txtexto = @texto, dtevento = @data, fltipo = @tipo, idusuario = @usuario, dttarefa = @data_tarefa, dtdeadline = @data_deadline, dteventoini = @data_inicio, dteventofim = @data_fim WHERE idevento = @id");
                query.SetParameter("id", variavel.idevento);
                query.SetParameter("curso", variavel.idcurso);
                query.SetParameter("titulo", variavel.txtitulo);
                query.SetParameter("texto", variavel.txtexto);
                query.SetParameter("data", variavel.dtevento);
                query.SetParameter("tipo", variavel.fltipo);
                query.SetParameter("usuario", variavel.idusuario);
                query.SetParameter("data_tarefa", variavel.dttarefa);
                query.SetParameter("data_deadline", variavel.dtdeadline);
                query.SetParameter("data_inicio", variavel.dteventoini);
                query.SetParameter("data_fim", variavel.dteventofim);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirUsuarios(int idevento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_eventos_usuarios WHERE idevento = @idevento");
                query.SetParameter("idevento", idevento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AdicionarUsuarios(int idevento, int idusuario)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_eventos_usuarios (idevento, idusuario) VALUES (@idevento, @idusuario) ");
                query.SetParameter("idevento", idevento);
                query.SetParameter("idusuario", idusuario);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int VerificaUusario(int idevento, int idusuario)
        {
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("select count(*) as total from timeline_eventos_usuarios where idevento = @idevento and idusuario = @idusuario");
            quey.SetParameter("idevento", idevento);
            quey.SetParameter("idusuario", idusuario);
            IDataReader reader = quey.ExecuteQuery();
            int retorno = 0;
            if (reader.Read())
            {
                retorno = Convert.ToInt32(reader["total"]);
            }
            else
            {
                retorno = 0;
            }
            reader.Close();
            session.Close();
            return retorno;
        }

        public void SalvarItem(TimelineTarefasItens variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_eventos_itens (idevento, txitem, fldashboard) VALUES (@idevento, @txitem, @fldashboard) ");
                query.SetParameter("idevento", variavel.idevento);
                query.SetParameter("txitem", variavel.txitem);
                query.SetParameter("fldashboard", variavel.fldashboard);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarItem(TimelineTarefasItens variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_eventos_itens SET txitem = @txitem, fldashboard = @fldashboard WHERE idevento = @idevento and iditem = @iditem");
                query.SetParameter("iditem", variavel.iditem);
                query.SetParameter("idevento", variavel.idevento);
                query.SetParameter("txitem", variavel.txitem);
                query.SetParameter("fldashboard", variavel.fldashboard);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirItem(int iditem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_eventos_itens WHERE iditem = @iditem");
                query.SetParameter("iditem", iditem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineTarefasItens BuscarItem(int iditem)
        {
            try
            {
                TimelineTarefasItens tarefa = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT idevento, iditem, txitem, fldashboard FROM timeline_eventos_itens WHERE iditem = @iditem");
                quey.SetParameter("iditem", iditem);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    tarefa = new TimelineTarefasItens(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["fldashboard"]));
                }
                reader.Close();
                session.Close();

                return tarefa;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineTarefasItens BuscarItem(int iditem, int idusuario)
        {
            try
            {
                TimelineTarefasItens tarefa = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT idevento, iditem, txitem, fldashboard FROM timeline_eventos_itens WHERE iditem = @iditem");
                quey.SetParameter("iditem", iditem);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    tarefa = new TimelineTarefasItens(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), idusuario, Convert.ToInt32(reader["fldashboard"]));
                }
                reader.Close();
                session.Close();

                return tarefa;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirItemAcao(int iditem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_eventos_usuarios_acao WHERE iditem = @iditem");
                query.SetParameter("iditem", iditem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineTarefasItens> ListarTarefas(int evento = 0)
        {
            try
            {
                List<TimelineTarefasItens> tarefa = new List<TimelineTarefasItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM timeline_eventos_itens WHERE idevento = @evento ORDER BY txitem");
                quey.SetParameter("evento", evento);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    tarefa.Add(new TimelineTarefasItens(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["fldashboard"])));
                }
                reader.Close();
                session.Close();

                return tarefa;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public void ExcluirEvento(int idevento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM timeline_eventos_usuarios WHERE idevento = @idevento");
                query.SetParameter("idevento", idevento);
                query.ExecuteUpdate();

                query = session.CreateQuery("DELETE FROM timeline_eventos_usuarios_acao WHERE iditem in (select iditem from timeline_eventos_usuarios where idevento = @idevento)");
                query.SetParameter("idevento", idevento);
                query.ExecuteUpdate();

                query = session.CreateQuery("DELETE FROM timeline_eventos_itens WHERE idevento = @idevento");
                query.SetParameter("idevento", idevento);
                query.ExecuteUpdate();

                query = session.CreateQuery("DELETE FROM timeline_eventos WHERE idevento = @idevento");
                query.SetParameter("idevento", idevento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarAcao(int iditem, int idusuario, string obs)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_eventos_usuarios_acao (iditem, idusuario, dtacao, txobs) values (@iditem, @idusuario, getdate(), @obs)");
                query.SetParameter("iditem", iditem);
                query.SetParameter("idusuario", idusuario);
                query.SetParameter("obs", obs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
