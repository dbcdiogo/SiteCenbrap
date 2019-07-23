using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_pgto_TransacaoDB
    {

        public void Salvar(Aluno_pgto_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_pgto_Transacao (aluno_pgto, status, code, msg, data) VALUES (@aluno_pgto, @status, @code, @msg, @data) ");
                query.SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
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

        public int SalvarRetornar(Aluno_pgto_Transacao variavel)
        {
            try
            {
                Salvar(variavel);

                return Buscar(variavel.aluno_pgto, variavel.code, variavel.status).aluno_pgto_Transacao_id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Aluno_pgto_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_pgto_Transacao SET code = @code, status = @status, msg = @msg, data = @data WHERE aluno_pgto_Transacao_id = @aluno_pgto_Transacao_id");
                query.SetParameter("aluno_pgto_Transacao_id", variavel.aluno_pgto_Transacao_id)
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

        public void Excluir(Aluno_pgto_Transacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_pgto_Transacao WHERE aluno_pgto_Transacao_id = @aluno_pgto_Transacao_id;");
                query.SetParameter("aluno_pgto_Transacao_id", variavel.aluno_pgto_Transacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_pgto_Transacao Buscar(Aluno_pgto aluno_pgto, string code, int status)
        {
            try
            {
                Aluno_pgto_Transacao aluno_pgto_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto_Transacao_id, 0) as aluno_pgto_Transacao_id, isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Transacao WHERE aluno_pgto = @aluno_pgto AND code = @code and status = @status");
                query.SetParameter("aluno_pgto", aluno_pgto.codigo)
                    .SetParameter("code", code)
                    .SetParameter("status", status);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_pgto_transacao = new Aluno_pgto_Transacao(Convert.ToInt32(reader["aluno_pgto_transacao_id"]), aluno_pgto, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_pgto_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_pgto_Transacao Buscar(Aluno_pgto aluno_pgto, int status)
        {
            try
            {
                Aluno_pgto_Transacao aluno_pgto_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto_Transacao_id, 0) as aluno_pgto_Transacao_id, isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Transacao WHERE aluno_pgto = @aluno_pgto AND status = @status ORDER BY data DESC");
                query.SetParameter("aluno_pgto", aluno_pgto.codigo)
                    .SetParameter("status", status);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_pgto_transacao = new Aluno_pgto_Transacao(Convert.ToInt32(reader["aluno_pgto_transacao_id"]), aluno_pgto, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_pgto_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_pgto_Transacao Buscar(int id)
        {
            try
            {
                Aluno_pgto_Transacao aluno_pgto_transacao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto_Transacao_id, 0) as aluno_pgto_Transacao_id, isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Transacao WHERE aluno_medtv_transacao_id = @aluno_medtv_transacao_id");
                query.SetParameter("aluno_medtv_transacao_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_pgto_transacao = new Aluno_pgto_Transacao(Convert.ToInt32(reader["aluno_pgto_transacao_id"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["aluno_pgto"]) }, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return aluno_pgto_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_pgto_Transacao> Listar(Aluno_pgto aluno_pgto)
        {
            try
            {
                List<Aluno_pgto_Transacao> aluno_pgto_transacao = new List<Aluno_pgto_Transacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto_Transacao_id, 0) as aluno_pgto_Transacao_id, isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Transacao WHERE aluno_pgto = @aluno_pgto ORDER BY aluno_medtv_transacao_id");
                query.SetParameter("aluno_pgto", aluno_pgto.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_pgto_transacao.Add(new Aluno_pgto_Transacao(Convert.ToInt32(reader["aluno_pgto_transacao_id"]), aluno_pgto, Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return aluno_pgto_transacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_pgto_Transacao> Disponivel()
        {
            try
            {
                List<Aluno_pgto_Transacao> aluno_medtv_transacao = new List<Aluno_pgto_Transacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto_Transacao_id, 0) as aluno_pgto_Transacao_id, isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, 0) as status, isnull(code, '') as code, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Transacao WHERE status = 4 ORDER BY aluno_medtv_transacao_id");

                IDataReader reader = query.ExecuteQuery();

                Aluno_pgtoDB db = new Aluno_pgtoDB();

                while (reader.Read())
                {
                    aluno_medtv_transacao.Add(new Aluno_pgto_Transacao(Convert.ToInt32(reader["aluno_pgto_transacao_id"]), db.Buscar(Convert.ToInt32(reader["aluno_pgto"])), Convert.ToInt32(reader["status"]), Convert.ToString(reader["code"]), Convert.ToString(reader["msg"]), Convert.ToDateTime(reader["data"])));
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
