using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DB
{
    public class Aluno_pgto_NotificacaoDB
    {
        public void Salvar(Aluno_pgto_Notificacao variavel)
        {
            try
            {

                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_pgto_Notificacao (aluno_pgto, data, status, msg) VALUES (@aluno_pgto, @data, @status, @msg) ");
                query.SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("status", variavel.status)
                    .SetParameter("data", variavel.data)
                    .SetParameter("msg", variavel.msg);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(Aluno_pgto aluno_pgto, DateTime data)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, '') as status, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Notificacao WHERE aluno_pgto = @aluno_pgto AND DATEADD(ms, -DATEPART(ms, data), data) = @data ORDER BY data");
                query.SetParameter("aluno_pgto", aluno_pgto.codigo)
                    .SetParameter("data", data);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = true;
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

        public List<Aluno_pgto_Notificacao> Listar(Aluno_pgto aluno_pgto)
        {
            try
            {
                List<Aluno_pgto_Notificacao> aluno_pgto_notificacao = new List<Aluno_pgto_Notificacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_pgto, 0) as aluno_pgto, isnull(status, '') as status, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_pgto_Notificacao WHERE aluno_pgto = @aluno_pgto ORDER BY data");
                query.SetParameter("aluno_pgto", aluno_pgto.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_pgto_notificacao.Add(new Aluno_pgto_Notificacao(aluno_pgto, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["status"]), Convert.ToString(reader["msg"])));
                }
                reader.Close();
                session.Close();

                return aluno_pgto_notificacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
