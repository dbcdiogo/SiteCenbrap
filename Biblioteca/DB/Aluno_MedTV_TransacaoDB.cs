using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_MedTV_TransacaoDB
    {
        public void Salvar(Aluno_MedTV_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_MedTV_Transacao (aluno_medtv_id, status, code, msg, data) VALUES (@aluno_medtv_id, @status, @code, @msg, @data) ");
                query.SetParameter("aluno_medtv_id", variavel.aluno_medTV_id.aluno_MedTV_id)
                    .SetParameter("status", variavel.status)
                    .SetParameter("data", variavel.data)
                    .SetParameter("code", variavel.code)
                    .SetParameter("msg", variavel.msg);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Aluno_MedTV_Transacao variavel)
        {
            try
            {
                Salvar(variavel);

                return Buscar(variavel.aluno_medTV_id, variavel.code, variavel.status).aluno_MedTV_Transacao_id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Aluno_MedTV_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_MedTV_Transacao SET code = @code, status = @status, msg = @msg, data = @data WHERE aluno_MedTV_Transacao_id = @aluno_MedTV_Transacao_id");
                query.SetParameter("aluno_MedTV_Transacao_id", variavel.aluno_MedTV_Transacao_id)
                    .SetParameter("code", variavel.code)
                    .SetParameter("status", variavel.status)
                    .SetParameter("msg", variavel.msg)
                    .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Aluno_MedTV_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_MedTV_Transacao WHERE aluno_MedTV_Transacao_id = @aluno_MedTV_Transacao_id;");
                query.SetParameter("aluno_MedTV_Transacao_id", variavel.aluno_MedTV_Transacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_MedTV_Transacao Buscar(Aluno_MedTV aluno_medtv, string code, int status)
        {
            try
            {
                Aluno_MedTV_Transacao aluno_medtv_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_Transacao_id, 0) as aluno_MedTV_Transacao_id, isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Transacao WHERE aluno_medtv_id = @aluno_medtv_id AND code = @code and status = @status");
                query.SetParameter("aluno_medtv_id", aluno_medtv.aluno_MedTV_id)
                    .SetParameter("code", code)
                    .SetParameter("status", status);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv_transacao = new Aluno_MedTV_Transacao(Convert.ToInt32(reader["aluno_MedTV_transacao_id"]), aluno_medtv, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_MedTV_Transacao Buscar(Aluno_MedTV aluno_medtv, int status)
        {
            try
            {
                Aluno_MedTV_Transacao aluno_medtv_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_Transacao_id, 0) as aluno_MedTV_Transacao_id, isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Transacao WHERE aluno_medtv_id = @aluno_medtv_id AND status = @status ORDER BY data DESC");
                query.SetParameter("aluno_medtv_id", aluno_medtv.aluno_MedTV_id)
                    .SetParameter("status", status);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv_transacao = new Aluno_MedTV_Transacao(Convert.ToInt32(reader["aluno_MedTV_transacao_id"]), aluno_medtv, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_MedTV_Transacao Buscar(int id)
        {
            try
            {
                Aluno_MedTV_Transacao aluno_medtv_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_Transacao_id, 0) as aluno_MedTV_Transacao_id, isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Transacao WHERE aluno_medtv_transacao_id = @aluno_medtv_transacao_id");
                query.SetParameter("aluno_medtv_transacao_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv_transacao = new Aluno_MedTV_Transacao(Convert.ToInt32(reader["aluno_MedTV_transacao_id"]), new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"])), Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_MedTV_Transacao> Listar(Aluno_MedTV aluno_medtv)
        {
            try
            {
                List<Aluno_MedTV_Transacao> aluno_medtv_transacao = new List<Aluno_MedTV_Transacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_Transacao_id, 0) as aluno_MedTV_Transacao_id, isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Transacao WHERE aluno_medtv_id = @aluno_medtv_id ORDER BY aluno_medtv_transacao_id");
                query.SetParameter("aluno_medtv_id", aluno_medtv.aluno_MedTV_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_medtv_transacao.Add(new Aluno_MedTV_Transacao(Convert.ToInt32(reader["aluno_MedTV_transacao_id"]), aluno_medtv, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_MedTV_Transacao> Disponivel()
        {
            try
            {
                List<Aluno_MedTV_Transacao> aluno_medtv_transacao = new List<Aluno_MedTV_Transacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_Transacao_id, 0) as aluno_MedTV_Transacao_id, isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Transacao WHERE status = 4 ORDER BY aluno_medtv_transacao_id");

                IDataReader reader = query.ExecuteQuery();

                Aluno_MedTVDB db = new Aluno_MedTVDB();

                while (reader.Read())
                {
                    aluno_medtv_transacao.Add(new Aluno_MedTV_Transacao(Convert.ToInt32(reader["aluno_MedTV_transacao_id"]), db.BuscarCompleto(Convert.ToInt32(reader["aluno_MedTV_id"])), Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
