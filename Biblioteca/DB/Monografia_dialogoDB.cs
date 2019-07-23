using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Monografia_dialogoDB
    {
        public void Salvar(Monografia_dialogo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia_dialogo (monografia, curso, de, data, texto) VALUES (@monografia, @curso, @de, @data, @texto) ");
                query.SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("de", variavel.de)
                    .SetParameter("data", variavel.data)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Monografia_dialogo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia_dialogo (monografia, curso, de, data, texto) output INSERTED.codigo VALUES (@monografia, @curso, @de, @data, @texto) ");
                query.SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("de", variavel.de)
                    .SetParameter("data", variavel.data)
                    .SetParameter("texto", variavel.texto);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Monografia_dialogo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Monografia_dialogo SET monografia = @monografia, curso = @curso, de = @de, data = @data, texto = @texto WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("de", variavel.de)
                    .SetParameter("data", variavel.data)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Monografia_dialogo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Monografia_dialogo WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Monografia_dialogo Buscar(int codigo)
        {
            try
            {
                Monografia_dialogo retorno = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(monografia,   0) AS monografia, isnull(curso,   0) AS curso, isnull(de,  0) AS de, isnull(data,  '1900-01-01') AS data, isnull(texto,  '') AS texto FROM Monografia_dialogo WHERE codigo = @codigo");
                query.SetParameter("@codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Monografia_dialogo(Convert.ToInt32(reader["codigo"]), new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["de"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["texto"]));
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

        public List<Monografia_dialogo> Listar(Monografia monografia)
        {
            try
            {
                List<Monografia_dialogo> retorno = new List<Monografia_dialogo>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(monografia,   0) AS monografia, isnull(curso,   0) AS curso, isnull(de,  0) AS de, isnull(data,  '1900-01-01') AS data, isnull(texto,  '') AS texto FROM Monografia_dialogo WHERE monografia = @monografia ORDER BY codigo DESC");
                query.SetParameter("@monografia", monografia.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Monografia_dialogo(Convert.ToInt32(reader["codigo"]), new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["de"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["texto"])));
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

        public List<Monografia_dialogo> Listar(Monografia monografia, int de)
        {
            try
            {
                List<Monografia_dialogo> retorno = new List<Monografia_dialogo>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(monografia,   0) AS monografia, isnull(curso,   0) AS curso, isnull(de,  0) AS de, isnull(data,  '1900-01-01') AS data, isnull(texto,  '') AS texto FROM Monografia_dialogo WHERE monografia = @monografia AND de = @de ORDER BY codigo DESC");
                query.SetParameter("@monografia", monografia.codigo)
                    .SetParameter("@de", de);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Monografia_dialogo(Convert.ToInt32(reader["codigo"]), new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["de"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["texto"])));
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
