using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Envio_email_abriuDB
    {
        public void Salvar(Envio_email_abriu variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Envio_email_abriu (envio_email, data) VALUES (@envio_email, @data) ");
                query.SetParameter("envio_email", variavel.envio_email.codigo)
                    .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Envio_email_abriu variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Envio_email_abriu WHERE envio_email_abriu_id = @id ");
                query.SetParameter("id", variavel.envio_email_abriu_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Envio_email_abriu> Buscar(Envio_email envio_email)
        {
            try
            {
                List<Envio_email_abriu> retorno = new List<Envio_email_abriu>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Envio_email_abriu WHERE envio_email = @envio_email ORDER BY data DESC");
                quey.SetParameter("envio_email", envio_email.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add( new Envio_email_abriu( Convert.ToInt32(reader["envio_email_abriu_id"]), new Envio_email() { codigo = Convert.ToInt32(reader["envio_email"]) }, Convert.ToDateTime(reader["data"]) ) );
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
    }
}
