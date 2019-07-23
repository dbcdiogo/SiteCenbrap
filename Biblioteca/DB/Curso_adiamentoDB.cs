using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Curso_adiamentoDB
    {
        public void Salvar(Curso_adiamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Curso_adiamento (curso,painel,de,para,data) VALUES (@curso,@painel,@de,@para,@data) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("de", variavel.de)
                    .SetParameter("para", variavel.para)
                    .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Curso_adiamento Ultimo(Curso curso)
        {
            try
            {
                Curso_adiamento retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT top 1 * FROM Curso_adiamento WHERE curso = @curso order by data desc");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Curso_adiamento(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["de"]), Convert.ToDateTime(reader["para"]), Convert.ToDateTime(reader["data"]));
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

        public List<Curso_adiamento> Listar(Curso curso)
        {
            try
            {
                List<Curso_adiamento> retorno = new List<Curso_adiamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Curso_adiamento WHERE curso = @curso");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Curso_adiamento(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["de"]), Convert.ToDateTime(reader["para"]), Convert.ToDateTime(reader["data"])));
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
