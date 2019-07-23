using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_ConfirmacaoDB
    {
        public void Salvar(Aluno_confirmacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO alunos_confirmacao (idaluno_curso, dtconfirmacao, txobs) VALUES (@idaluno_curso, @dtconfirmacao, @txobs) ");
                query.SetParameter("idaluno_curso", variavel.idaluno_curso)
                    .SetParameter("dtconfirmacao", variavel.dtconfirmacao)
                    .SetParameter("txobs", variavel.txobs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Aluno_confirmacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE alunos_confirmacao SET idaluno_curso = @idaluno_curso, dtconfirmacao = @dtconfirmacao, txobs = @txobs WHERE idconfirmacao = @idconfirmacao");
                query.SetParameter("idconfirmacao", variavel.idconfirmacao)
                    .SetParameter("idaluno_curso", variavel.idaluno_curso)
                    .SetParameter("dtconfirmacao", variavel.dtconfirmacao)
                    .SetParameter("txobs", variavel.txobs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Aluno_confirmacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM alunos_confirmacao WHERE idconfirmacao = @idconfirmacao");
                query.SetParameter("idconfirmacao", variavel.idconfirmacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_confirmacao> ListarPorTurma(int idturma = 0)
        {
            try
            {
                List<Aluno_confirmacao> dataLote = new List<Aluno_confirmacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT ISNULL(ACO.idconfirmacao,0) AS id, ISNULL(ACO.dtconfirmacao, '1900-01-01') as data, ISNULL(ACO.txobs, '') as obs, A.nome, AC.codigo, concat(a.ddd, ' ', A.telefone) as telefone, C.titulo1
                FROM aluno_curso AC
                INNER JOIN aluno A ON A.codigo = AC.aluno
                INNER JOIN curso C on C.codigo = AC.curso
                LEFT JOIN alunos_confirmacao ACO ON ACO.idaluno_curso = AC.codigo
                WHERE AC.curso = @idturma AND AC.situacao = 2 AND A.codigo NOT IN(SELECT idaluno FROM timeline_usuarios WHERE flignorar = 1)
                ORDER BY A.nome");
                quey.SetParameter("idturma", idturma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Aluno_confirmacao(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_confirmacao> ListarPorAluno(int idaluno = 0)
        {
            try
            {
                List<Aluno_confirmacao> dataLote = new List<Aluno_confirmacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT ISNULL(ACO.idconfirmacao,0) AS id, ISNULL(ACO.dtconfirmacao, '1900-01-01') as data, ISNULL(ACO.txobs, '') as obs, A.nome, AC.codigo, concat(a.ddd, ' ', A.telefone) as telefone, C.titulo1
                FROM aluno_curso AC
                INNER JOIN aluno A ON A.codigo = AC.aluno
                INNER JOIN curso C on C.codigo = AC.curso
                LEFT JOIN alunos_confirmacao ACO ON ACO.idaluno_curso = AC.codigo
                WHERE AC.aluno = @idaluno AND AC.situacao = 2 AND A.codigo NOT IN(SELECT idaluno FROM timeline_usuarios WHERE flignorar = 1)
                ORDER BY A.nome");
                quey.SetParameter("idaluno", idaluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Aluno_confirmacao(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_confirmacao> ListarPorAlunoTurma(int idaluno = 0, int idturma = 0)
        {
            try
            {
                List<Aluno_confirmacao> dataLote = new List<Aluno_confirmacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT ISNULL(ACO.idconfirmacao,0) AS id, ISNULL(ACO.dtconfirmacao, '1900-01-01') as data, ISNULL(ACO.txobs, '') as obs, A.nome, AC.codigo, concat(a.ddd, ' ', A.telefone) as telefone, C.titulo1
                FROM aluno_curso AC
                INNER JOIN aluno A ON A.codigo = AC.aluno
                INNER JOIN curso C on C.codigo = AC.curso
                LEFT JOIN alunos_confirmacao ACO ON ACO.idaluno_curso = AC.codigo
                WHERE AC.aluno = @idaluno AND AC.curso = @idturma AND AC.situacao = 2 AND A.codigo NOT IN(SELECT idaluno FROM timeline_usuarios WHERE flignorar = 1)
                ORDER BY A.nome");
                quey.SetParameter("idaluno", idaluno);
                quey.SetParameter("idturma", idturma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Aluno_confirmacao(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_confirmacao Buscar(int idconfirmacao = 0)
        {
            try
            {
                Aluno_confirmacao conf = new Aluno_confirmacao();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from alunos_confirmacao where idconfirmacao = @idconfirmacao");
                quey.SetParameter("idconfirmacao", idconfirmacao);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    conf = new Aluno_confirmacao(Convert.ToInt32(reader["idconfirmacao"]), Convert.ToInt32(reader["idaluno_curso"]), Convert.ToDateTime(reader["dtconfirmacao"]), Convert.ToString(reader["txobs"]));
                }
                reader.Close();
                session.Close();

                return conf;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Confirmados(int idturma = 0)
        {
            try
            {
                int r = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as total from alunos_confirmacao a inner join aluno_curso ac on ac.codigo = a.idaluno_curso where ac.curso = @idturma and datediff(day, a.dtconfirmacao, getdate()) <= 15");
                quey.SetParameter("idturma", idturma);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    r = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
                session.Close();

                return r;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
