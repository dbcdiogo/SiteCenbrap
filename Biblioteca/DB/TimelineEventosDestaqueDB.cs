using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineEventosDestaqueDB
    {

        public void Salvar(TimelineEventosDestaque variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_eventos_destaque (idusuario, idcurso, dtinicio, dtfim, txdestaque, txremocao) VALUES (@idusuario, @idcurso, @dtinicio, @dtfim, @txdestaque, @txremocao) ");
                query.SetParameter("idusuario", variavel.idusuario)
                .SetParameter("idcurso", variavel.idcurso)
                .SetParameter("dtinicio", variavel.dtinicio)
                .SetParameter("dtfim", variavel.dtfim)
                .SetParameter("txdestaque", variavel.txdestaque)
                .SetParameter("txremocao", variavel.txremocao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(TimelineEventosDestaque variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_eventos_destaque set dtfim = @dtfim, txdestaque = @txdestaque, txremocao = @txremocao where idevento = @idevento");
                query.SetParameter("idevento", variavel.idevento)
                .SetParameter("dtfim", variavel.dtfim)
                .SetParameter("txdestaque", variavel.txdestaque)
                .SetParameter("txremocao", variavel.txremocao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineEventosDestaque Buscar(int idevento)
        {
            try
            {
                TimelineEventosDestaque destaque = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from timeline_eventos_destaque where idevento = @idevento");
                quey.SetParameter("idevento", idevento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    destaque = new TimelineEventosDestaque(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["idusuario"]), Convert.ToInt32(reader["idcurso"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txdestaque"]), Convert.ToString(reader["txremocao"]));
                }
                reader.Close();
                session.Close();

                return destaque;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineEventosDestaque BuscarAtivo(int curso, int usuario)
        {
            try
            {
                TimelineEventosDestaque destaque = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from timeline_eventos_destaque where idcurso = @curso and idusuario = @usuario and year(dtfim) = 1900");
                quey.SetParameter("curso", curso);
                quey.SetParameter("usuario", usuario);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    destaque = new TimelineEventosDestaque(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["idusuario"]), Convert.ToInt32(reader["idcurso"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txdestaque"]), Convert.ToString(reader["txremocao"]));
                }
                reader.Close();
                session.Close();

                return destaque;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int BuscarAtivoGeral(int curso)
        {
            try
            {
                int retorno = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as total from timeline_eventos_destaque where idcurso = @curso and year(dtfim) = 1900");
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventosDestaque> BuscarDestaques(int curso, int usuario)
        {
            try
            {
                List<TimelineEventosDestaque> destaque = new List<TimelineEventosDestaque>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from timeline_eventos_destaque where idcurso = @curso and idusuario = @usuario");
                quey.SetParameter("curso", curso);
                quey.SetParameter("usuario", usuario);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    destaque.Add(new TimelineEventosDestaque(Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["idusuario"]), Convert.ToInt32(reader["idcurso"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txdestaque"]), Convert.ToString(reader["txremocao"])));
                }
                reader.Close();
                session.Close();

                return destaque;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
