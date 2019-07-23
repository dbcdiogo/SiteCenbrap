using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ReposicaoDB
    {
        public int SalvarRetornar(Reposicao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Reposicao (data, curso, aluno, disciplina, curso_reposicao, encontro_reposicao, data1, confirmada, cancelada, obs, cor, endereco_local, obs_local, arquivo_mapa, arquivo_material) output INSERTED.codigo VALUES (@data, @curso, @aluno, @disciplina, @curso_reposicao, @encontro_reposicao, @data1, @confirmada, @cancelada, @obs, @cor, @endereco_local, @obs_local, @arquivo_mapa, @arquivo_material) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("disciplina", variavel.disciplina.codigo)
                    .SetParameter("curso_reposicao", variavel.curso_reposicao.codigo)
                    .SetParameter("encontro_reposicao", variavel.encontro_reposicao.codigo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("confirmada", variavel.confirmada)
                    .SetParameter("cancelada", variavel.cancelada)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("endereco_local", variavel.endereco_local)
                    .SetParameter("obs_local", variavel.obs_local)
                    .SetParameter("arquivo_mapa", variavel.arquivo_mapa)
                    .SetParameter("arquivo_material", variavel.arquivo_material);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Reposicao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Reposicao SET data = @data, curso = @curso, aluno = @aluno, disciplina = @disciplina, curso_reposicao = @curso_reposicao, encontro_reposicao = @encontro_reposicao, data1 = @data1, confirmada = @confirmada, cancelada = @cancelada, obs = @obs, cor = @cor, endereco_local = @endereco_local, obs_local = @obs_local, arquivo_mapa = @arquivo_mapa, arquivo_material = @arquivo_material WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("disciplina", variavel.disciplina.codigo)
                    .SetParameter("curso_reposicao", variavel.curso_reposicao.codigo)
                    .SetParameter("encontro_reposicao", variavel.encontro_reposicao.codigo)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("confirmada", variavel.confirmada)
                    .SetParameter("cancelada", variavel.cancelada)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("endereco_local", variavel.endereco_local)
                    .SetParameter("obs_local", variavel.obs_local)
                    .SetParameter("arquivo_mapa", variavel.arquivo_mapa)
                    .SetParameter("arquivo_material", variavel.arquivo_material);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Reposicao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Reposicao WHERE codigo = @codigo;");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void CancelarReposicao(int id)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Reposicao SET cancelada = 1 WHERE codigo = @codigo");
                query.SetParameter("codigo", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void EnvioConfirmacao(int id)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Reposicao SET envio_confirmacao = getdate() WHERE codigo = @codigo");
                query.SetParameter("codigo", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(Reposicao variavel)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT codigo FROM reposicao WHERE curso = @curso AND aluno = @aluno AND curso_reposicao = @curso_reposicao AND encontro_reposicao = @encontro_reposicao");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("curso_reposicao", variavel.curso_reposicao.codigo)
                    .SetParameter("encontro_reposicao", variavel.encontro_reposicao.codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = true;
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

        public List<Reposicao> ListarReposicaoAluno(int curso, int aluno)
        {
            try
            {
                List<Reposicao> rep = new List<Reposicao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from reposicao where aluno = @aluno and curso = @curso");
                quey.SetParameter("aluno", aluno)
                    .SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    rep.Add(new Reposicao()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        data = Convert.ToDateTime(reader["data"]),
                        codigo_encontro_reposicao = Convert.ToInt32(reader["encontro_reposicao"]),
                        confirmada = Convert.ToInt32(reader["confirmada"]),
                        cancelada = Convert.ToInt32(reader["cancelada"]),
                        codigo_aluno = Convert.ToInt32(reader["aluno"]),
                    });
                }
                reader.Close();
                session.Close();

                return rep;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
