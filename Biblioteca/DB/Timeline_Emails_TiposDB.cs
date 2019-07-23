using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Timeline_Emails_TiposDB
    {
        public void GravarEmailSistema(int idemailtipo, int idmensagem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_emails_sistema (idemailtipo, idmensagem) VALUES (@idemailtipo,@idmensagem) ");
                query.SetParameter("idemailtipo", idemailtipo)
                    .SetParameter("idmensagem", idmensagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarEmailSistema(int idemailtipo, int idmensagem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_emails_sistema SET idmensagem = @idmensagem WHERE idemailtipo = @idemailtipo) ");
                query.SetParameter("idemailtipo", idemailtipo)
                    .SetParameter("idmensagem", idmensagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Timeline_Emails_Sistema BuscarEmailSistema(int idemailtipo)
        {
            try
            {
                Timeline_Emails_Sistema email = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from timeline_emails_sistema WHERE idemailtipo = @idemailtipo");
                quey.SetParameter("idemailtipo", idemailtipo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    email = new Timeline_Emails_Sistema()
                    {
                        idemailtipo = Convert.ToInt32(reader["idemailtipo"]),
                        idmensagem = Convert.ToInt32(reader["idmensagem"]),
                    };
                }

                reader.Close();
                session.Close();

                return email;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Timeline_Emails_Tipos> Listar()
        {
            try
            {
                List<Timeline_Emails_Tipos> tipos = new List<Timeline_Emails_Tipos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select tet.*, ttc.txtipo, isnull(tes.idmensagem,0) as idmensagem from Timeline_Emails_Tipo tet inner join timeline_tipos_cursos ttc on ttc.idtipo = tet.idtipo left join timeline_emails_sistema tes on tes.idemailtipo = tet.idemailtipo order by ttc.txtipo, tet.txtitulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    tipos.Add(new Timeline_Emails_Tipos()
                    {
                        idemailtipo = Convert.ToInt32(reader["idemailtipo"]),
                        idtipo = Convert.ToInt32(reader["idtipo"]),
                        txtitulo = Convert.ToString(reader["txtitulo"]),
                        txtipo = Convert.ToString(reader["txtipo"]),
                        idmensagem = Convert.ToInt32(reader["idmensagem"])
                    });
                }

                reader.Close();
                session.Close();

                return tipos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
