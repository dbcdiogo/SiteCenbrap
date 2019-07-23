using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AbriuDB
    {
        public void Salvar(Abriu variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_abriu (idenviado, dtabriu) VALUES (@idenviado, @dtabriu) ");
                query.SetParameter("idenviado", variavel.idenviado.idenviado)
                .SetParameter("dtabriu", variavel.dtabriu);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Abriu variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_abriu WHERE idabriu = @idabriu");
                query.SetParameter("idabriu", variavel.idabriu);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Abriu> Listar(Enviado enviado)
        {
            try
            {
                List<Abriu> abriu = new List<Abriu>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(idabriu, 0) as idabriu, isnull(idenviado, 0) as idenviado, isnull(dtabriu, '01/01/1900') as dtabriu FROM mailing_abriu WHERE idenviado = @idenviado ORDER BY dtabriu DESC");
                query.SetParameter("@idenviado", enviado.idenviado);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    abriu.Add(new Abriu(Convert.ToInt32(reader["idemail"]), new Enviado() { idenviado = Convert.ToInt32(reader["idenviado"]) }, Convert.ToDateTime(reader["dtabriu"])));
                }
                reader.Close();
                session.Close();

                return abriu;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
