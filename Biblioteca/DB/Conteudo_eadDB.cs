using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Conteudo_eadDB
    {
        public void Salvar(Conteudo_ead variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Conteudo_ead (curso,data,painel,titulo,conteudo,ativo,data_ativo,data_ativo_fim,categoria) VALUES (@curso,@data,@painel,@titulo,@conteudo,@ativo,@data_ativo,@data_ativo_fim,@categoria) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("conteudo", variavel.conteudo)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("data_ativo", variavel.data_ativo)
                    .SetParameter("data_ativo_fim", variavel.data_ativo_fim)
                    .SetParameter("categoria", variavel.categoria);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Conteudo_ead variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Conteudo_ead SET curso = @curso, data = @data, painel = @painel, titulo = @titulo, conteudo = @conteudo, ativo = @ativo, data_ativo = @data_ativo, data_ativo_fim = @data_ativo_fim, categoria = @categoria WHERE conteudo_ead_id = @conteudo_ead_id");
                query.SetParameter("conteudo_ead_id", variavel.conteudo_ead_id)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("conteudo", variavel.conteudo)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("data_ativo", variavel.data_ativo)
                    .SetParameter("data_ativo_fim", variavel.data_ativo_fim)
                    .SetParameter("categoria", variavel.categoria);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Conteudo_ead variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Conteudo_ead WHERE conteudo_ead_id = @conteudo_ead_id");
                query.SetParameter("conteudo_ead_id", variavel.conteudo_ead_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Conteudo_ead Buscar(int codigo)
        {
            try
            {
                Conteudo_ead conteudo_ead = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(conteudo_ead_id, 0) AS conteudo_ead_id, isnull(curso, 0) AS curso, isnull(data, '1900-01-01') AS data, isnull(painel,  0) AS painel, isnull(titulo, '') AS titulo, isnull(conteudo, '') AS conteudo, isnull(ativo,  0) AS ativo, isnull(data_ativo, '1900-01-01') AS data_ativo, isnull(data_ativo_fim, '1900-01-01') AS data_ativo_fim, isnull(categoria, '') AS categoria FROM Conteudo_ead WHERE conteudo_ead_id = @conteudo_ead_id");
                quey.SetParameter("conteudo_ead_id", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    conteudo_ead = new Conteudo_ead(Convert.ToInt32(reader["conteudo_ead_id"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["titulo"]), Convert.ToString(reader["conteudo"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data_ativo"]), Convert.ToDateTime(reader["data_ativo_fim"]), Convert.ToString(reader["categoria"]));
                }
                reader.Close();
                session.Close();

                return conteudo_ead;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Conteudo_ead> Listar(Curso curso)
        {
            try
            {
                List<Conteudo_ead> conteudo_ead = new List<Conteudo_ead>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(conteudo_ead_id, 0) AS conteudo_ead_id, isnull(curso, 0) AS curso, isnull(data, '1900-01-01') AS data, isnull(painel,  0) AS painel, isnull(titulo, '') AS titulo, isnull(conteudo, '') AS conteudo, isnull(ativo,  0) AS ativo, isnull(data_ativo, '1900-01-01') AS data_ativo, isnull(data_ativo_fim, '1900-01-01') AS data_ativo_fim, isnull(categoria, '') AS categoria FROM Conteudo_ead WHERE curso = @curso");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    conteudo_ead.Add(new Conteudo_ead(Convert.ToInt32(reader["conteudo_ead_id"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["titulo"]), Convert.ToString(reader["conteudo"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data_ativo"]), Convert.ToDateTime(reader["data_ativo_fim"]), Convert.ToString(reader["categoria"])));
                }
                reader.Close();
                session.Close();

                return conteudo_ead;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Conteudo_ead> Ativos(Curso curso)
        {
            try
            {
                List<Conteudo_ead> conteudo_ead = new List<Conteudo_ead>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(conteudo_ead_id, 0) AS conteudo_ead_id, isnull(curso, 0) AS curso, isnull(data, '1900-01-01') AS data, isnull(painel,  0) AS painel, isnull(titulo, '') AS titulo, isnull(conteudo, '') AS conteudo, isnull(ativo,  0) AS ativo, isnull(data_ativo, '1900-01-01') AS data_ativo, isnull(data_ativo_fim, '1900-01-01') AS data_ativo_fim, isnull(categoria, '') as categoria FROM Conteudo_ead WHERE curso = @curso AND ativo = 1 AND data_ativo <= getdate() AND data_ativo_fim >= CAST(GETDATE() AS DATE) order by categoria, painel, titulo");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    conteudo_ead.Add(new Conteudo_ead(Convert.ToInt32(reader["conteudo_ead_id"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["titulo"]), Convert.ToString(reader["conteudo"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data_ativo"]), Convert.ToDateTime(reader["data_ativo_fim"]), Convert.ToString(reader["categoria"])));
                }
                reader.Close();
                session.Close();

                return conteudo_ead;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Conteudo_ead> Ativos(Curso curso, Aluno aluno)
        {
            try
            {
                List<Conteudo_ead> conteudo_ead = new List<Conteudo_ead>();

                DBSession session = new DBSession();

                Query quey = session.CreateQuery(@"SELECT 
                    isnull(ce.conteudo_ead_id, 0) AS conteudo_ead_id, isnull(ce.curso, 0) AS curso, isnull(ce.data, '1900-01-01') AS data, isnull(ce.painel, 0) AS painel, isnull(ce.titulo, '') AS titulo,
                    isnull(ce.conteudo, '') AS conteudo, isnull(ce.ativo, 0) AS ativo, isnull(ce.data_ativo, '1900-01-01') AS data_ativo, isnull(ce.data_ativo_fim, '1900-01-01') AS data_ativo_fim, isnull(ce.categoria, '') as categoria
                FROM Conteudo_ead ce
                WHERE ce.curso = @curso
                    AND ce.ativo = 1
                    AND ce.data_ativo <= getdate()
                    AND isnull((select cev.data from conteudo_ead_vencimento cev where cev.conteudo_ead_id = ce.conteudo_ead_id and cev.aluno = @aluno), ce.data_ativo_fim) >= CAST(GETDATE() AS DATE)
                order by ce.categoria, ce.painel, ce.titulo");
                quey.SetParameter("curso", curso.codigo);
                quey.SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    conteudo_ead.Add(new Conteudo_ead(Convert.ToInt32(reader["conteudo_ead_id"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["titulo"]), Convert.ToString(reader["conteudo"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["data_ativo"]), Convert.ToDateTime(reader["data_ativo_fim"]), Convert.ToString(reader["categoria"])));
                }
                reader.Close();
                session.Close();

                return conteudo_ead;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
