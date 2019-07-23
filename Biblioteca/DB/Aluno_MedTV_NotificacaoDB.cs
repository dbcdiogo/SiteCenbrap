using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_MedTV_NotificacaoDB
    {
        public void Salvar(Aluno_MedTV_Notificacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_MedTV_Notificacao (aluno_medtv_id, data, status, msg) VALUES (@aluno_medtv_id, @data, @status, @msg) ");
                query.SetParameter("aluno_medtv_id", variavel.aluno_MedTV_id.aluno_MedTV_id)
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

        public bool Existe(Aluno_MedTV aluno_medtv, DateTime data)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, '') as status, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Notificacao WHERE aluno_medtv_id = @aluno_medtv_id AND data = @data ORDER BY data");
                query.SetParameter("aluno_medtv_id", aluno_medtv.aluno_MedTV_id)
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

        public List<Aluno_MedTV_Notificacao> Listar(Aluno_MedTV aluno_medtv)
        {
            try
            {
                List<Aluno_MedTV_Notificacao> aluno_medtv_notificacao = new List<Aluno_MedTV_Notificacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(status, '') as status, isnull(data, '01/01/1900') as data, isnull(msg, '') as msg FROM Aluno_MedTV_Notificacao WHERE aluno_medtv_id = @aluno_medtv_id ORDER BY data");
                query.SetParameter("aluno_medtv_id", aluno_medtv.aluno_MedTV_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_medtv_notificacao.Add(new Aluno_MedTV_Notificacao(aluno_medtv, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["status"]), Convert.ToString(reader["msg"])));
                }
                reader.Close();
                session.Close();

                return aluno_medtv_notificacao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
