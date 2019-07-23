using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Midia_tipoDB
    {
        public void Salvar(Midia_tipo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO midia_tipo (titulo, email, sms, facebook) VALUES (@titulo, @email, @sms, @facebook) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("email", variavel.email)
                    .SetParameter("sms", variavel.sms)
                    .SetParameter("facebook", variavel.facebook);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Midia_tipo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE midia_tipo SET titulo = @titulo, email = @email, sms = @sms, facebook = @facebook WHERE midia_tipo_id = @midia_tipo_id;");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("midia_tipo_id", variavel.midia_tipo_id)
                    .SetParameter("email", variavel.email)
                    .SetParameter("sms", variavel.sms)
                    .SetParameter("facebook", variavel.facebook);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia_tipo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM midia_tipo WHERE midia_tipo_id = @midia_tipo_id;");
                query.SetParameter("midia_tipo_id", variavel.midia_tipo_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Midia_tipo Buscar(int id)
        {
            Midia_tipo retorno;
            try
            {
                retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia_tipo WHERE midia_tipo_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Midia_tipo(Convert.ToInt32(reader["midia_tipo_id"]), Convert.ToString(reader["titulo"]), Convert.ToBoolean(reader["email"]), Convert.ToBoolean(reader["sms"]), Convert.ToBoolean(reader["facebook"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia_tipo> Listar()
        {
            List<Midia_tipo> retorno;
            try
            {
                retorno = new List<Midia_tipo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia_tipo ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia_tipo(Convert.ToInt32(reader["midia_tipo_id"]), Convert.ToString(reader["titulo"]), Convert.ToBoolean(reader["email"]), Convert.ToBoolean(reader["sms"]), Convert.ToBoolean(reader["facebook"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia_tipo> ListarMidia()
        {
            List<Midia_tipo> retorno;
            try
            {
                retorno = new List<Midia_tipo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia_tipo WHERE exists (SELECT midia_id FROM midia WHERE midia.midia_tipo_id = midia_tipo.midia_tipo_id) ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia_tipo(Convert.ToInt32(reader["midia_tipo_id"]), Convert.ToString(reader["titulo"]), Convert.ToBoolean(reader["email"]), Convert.ToBoolean(reader["sms"]), Convert.ToBoolean(reader["facebook"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
