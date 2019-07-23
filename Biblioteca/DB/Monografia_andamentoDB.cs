using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Monografia_andamentoDB
    {
        public void Salvar(Monografia_andamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia_andamento (curso,aluno,monografia,data,destino,arquivo,texto,situacao) VALUES (@curso,@aluno,@monografia,@data,@destino,@arquivo,@texto,@situacao) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("destino", variavel.destino)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("situacao", variavel.situacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Monografia_andamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia_andamento (curso,aluno,monografia,data,destino,arquivo,texto,situacao) output INSERTED.codigo VALUES (@curso,@aluno,@monografia,@data,@destino,@arquivo,@texto,@situacao)");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("destino", variavel.destino)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("situacao", variavel.situacao);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Monografia_andamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Monografia_andamento SET curso = @curso, aluno = @aluno, monografia = @monografia, data = @data, destino = @destino, arquivo = @arquivo, texto = @texto, situacao = @situacao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("monografia", variavel.monografia.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("destino", variavel.destino)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("situacao", variavel.situacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Monografia_andamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Monografia_andamento WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Monografia_andamento Buscar(int codigo)
        {
            try
            {
                Monografia_andamento retorno = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(monografia,   0) AS monografia, isnull(data,  '1900-01-01') AS data, isnull(destino,  0) AS destino, isnull(arquivo,  '') AS arquivo, isnull(texto,  '') AS texto, isnull(situacao,  0) AS situacao FROM Monografia_andamento WHERE codigo = @codigo");
                query.SetParameter("@codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Monografia_andamento(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["destino"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["situacao"]));
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

        public List<Monografia_andamento> Listar(Monografia monografia)
        {
            try
            {
                List<Monografia_andamento> retorno = new List<Monografia_andamento>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(monografia,   0) AS monografia, isnull(data,  '1900-01-01') AS data, isnull(destino,  0) AS destino, isnull(arquivo,  '') AS arquivo, isnull(texto,  '') AS texto, isnull(situacao,  0) AS situacao FROM Monografia_andamento WHERE monografia = @codigo ORDER BY codigo DESC");
                query.SetParameter("@codigo", monografia.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Monografia_andamento(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["destino"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["situacao"])));
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

        public List<Monografia_andamento> Listar(Aluno aluno, Curso curso)
        {
            try
            {
                List<Monografia_andamento> retorno = new List<Monografia_andamento>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(monografia,   0) AS monografia, isnull(data,  '1900-01-01') AS data, isnull(destino,  0) AS destino, isnull(arquivo,  '') AS arquivo, isnull(texto,  '') AS texto, isnull(situacao,  0) AS situacao FROM Monografia_andamento WHERE aluno = @aluno AND curso = @curso ORDER BY codigo DESC");
                query.SetParameter("@aluno", aluno.codigo)
                    .SetParameter("@curso", curso.codigo);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Monografia_andamento(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Monografia() { codigo = Convert.ToInt32(reader["monografia"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["destino"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["situacao"])));
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
