using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class MunicipioDB
    {
        public int Buscar(string municipio, string uf)
        {
            try
            {
                int retorno = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT id FROM municipio WHERE municipio = @municipio AND uf = @uf");
                quey.SetParameter("municipio", municipio)
                    .SetParameter("uf", uf);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["id"]);
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
