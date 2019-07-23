using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Documentos_alunosDB
    {
        public void Salvar(Documentos_alunos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Documentos_alunos (curso,aluno,documentos,data) VALUES (@curso,@aluno,@documentos,@data) ");
                query.SetParameter("curso", variavel.curso.codigo)
                        .SetParameter("aluno", variavel.aluno.codigo)
                        .SetParameter("documentos", variavel.documentos.codigo)
                        .SetParameter("data", variavel.data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Documentos_alunos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Documentos_alunos SET curso = @curso, aluno = @aluno, documentos = @documentos, data = @data WHERE codigo = @codigo");
                query.SetParameter("curso", variavel.curso.codigo)
                        .SetParameter("aluno", variavel.aluno.codigo)
                        .SetParameter("documentos", variavel.documentos.codigo)
                        .SetParameter("data", variavel.data)
                        .SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Documentos_alunos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Documentos_alunos WHERE codigo = @codigo;");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Documentos_alunos Buscar(int codigo)
        {
            try
            {
                Documentos_alunos documentos = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,  0) AS aluno, isnull(documentos,  0) AS documentos, isnull(data, '1900-01-01') AS data FROM Documentos_alunos WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    documentos = new Documentos_alunos(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Documentos() { codigo = Convert.ToInt32(reader["documentos"]) }, Convert.ToDateTime(reader["data"]));
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

        public Documentos_alunos Buscar(int documentos, int aluno)
        {
            try
            {
                Documentos_alunos documentos_alunos = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,  0) AS aluno, isnull(documentos,  0) AS documentos, isnull(data, '1900-01-01') AS data FROM Documentos_alunos WHERE documentos = @documentos AND aluno = @aluno");
                quey.SetParameter("documentos", documentos)
                    .SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    documentos_alunos = new Documentos_alunos(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Documentos() { codigo = Convert.ToInt32(reader["documentos"]) }, Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return documentos_alunos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> PendenciaDocumentos(int aluno, int curso)
        {
            try
            {
                List<string> documentos_alunos = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select documentos1 from documentos where curso = @curso and not exists(select * from documentos_alunos where curso = @curso and aluno = @aluno and documentos.codigo = documentos_alunos.documentos)");
                quey.SetParameter("curso", curso)
                    .SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    documentos_alunos.Add(Convert.ToString(reader["documentos1"]));
                }
                reader.Close();
                session.Close();

                return documentos_alunos;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
