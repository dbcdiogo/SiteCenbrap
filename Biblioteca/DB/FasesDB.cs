using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class FasesDB
    {
  
        public Fases Buscar(int id)
        {
            try
            {
                Fases fase = new Fases();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_fases WHERE idfase = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    fase = new Fases(Convert.ToInt32(reader["idfase"]), Convert.ToString(reader["txfase"]));
                }
                reader.Close();
                session.Close();

                return fase;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
               
        public List<Fases> Listar()
        {
            try
            {
                List<Fases> fase = new List<Fases>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_fases ORDER BY txfase");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    fase.Add(new Fases(Convert.ToInt32(reader["idfase"]), Convert.ToString(reader["txfase"])));
                }
                reader.Close();
                session.Close();

                return fase;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
