using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DocumentosDB
    {
        public void Salvar(Documentos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Documentos (curso,documentos,documentos1) VALUES (@curso,@documentos,@documentos) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("documentos", variavel.documentos)
                    .SetParameter("documentos1", variavel.documentos1);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Documentos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Documentos SET curso = @curso, documentos = @documentos, documentos1 = @documentos1 WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("documentos", variavel.documentos)
                    .SetParameter("documentos1", variavel.documentos1);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Documentos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Documentos WHERE codigo = @codigo; DELETE FROM Documentos_alunos WHERE Documentos = @codigo;");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Documentos Buscar(int codigo)
        {
            try
            {
                Documentos documentos = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(documentos, '') AS documentos, isnull(documentos1, '') AS documentos1 FROM Documentos WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    documentos = new Documentos(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToString(reader["documentos"]), Convert.ToString(reader["documentos1"]));
                }
                reader.Close();
                session.Close();

                return documentos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Documentos> Listar(Curso curso)
        {
            try
            {
                List<Documentos> documentos = new List<Documentos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(documentos, '') AS documentos, isnull(documentos1, '') AS documentos1 FROM Documentos WHERE curso = @curso ORDER BY documentos");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    documentos.Add(new Documentos(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToString(reader["documentos"]), Convert.ToString(reader["documentos1"])));
                }
                reader.Close();
                session.Close();

                return documentos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasDocumentos> Pendencias(Curso curso, Aluno aluno)
        {
            try
            {
                List<PendenciasDocumentos> documentos = new List<PendenciasDocumentos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select documentos, (case when (select count(*) from documentos_alunos where documentos_alunos.aluno = @aluno and documentos_alunos.curso = documentos.curso and documentos_alunos.documentos = documentos.codigo) > 0 then 1 else 0 end) as entregue from documentos where curso = @curso ORDER BY documentos");
                quey.SetParameter("aluno", aluno.codigo)
                    .SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    documentos.Add(new PendenciasDocumentos(Convert.ToString(reader["documentos"]), Convert.ToBoolean(reader["entregue"])));
                }
                reader.Close();
                session.Close();

                return documentos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasDocumentos> PendenciasN(Curso curso, Aluno aluno)
        {
            try
            {
                List<PendenciasDocumentos> documentos = new List<PendenciasDocumentos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from (select documentos, (case when (select count(*) from documentos_alunos where documentos_alunos.aluno = @aluno and documentos_alunos.curso = documentos.curso and documentos_alunos.documentos = documentos.codigo) > 0 then 1 else 0 end) as entregue from documentos where curso = @curso) as t where t.entregue = 0 ORDER BY documentos");
                quey.SetParameter("aluno", aluno.codigo)
                    .SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    documentos.Add(new PendenciasDocumentos(Convert.ToString(reader["documentos"]), Convert.ToBoolean(reader["entregue"])));
                }
                reader.Close();
                session.Close();

                return documentos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
