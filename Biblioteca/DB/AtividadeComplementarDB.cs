using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AtividadeComplementarDB
    {      
        
        public string BuscarTitulo(int encontro = 0)
        {
            try
            {
                string titulo = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM atividade_complementar WHERE idencontro = @encontro");
                quey.SetParameter("encontro", encontro);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    titulo = Convert.ToString(reader["txtitulo"]);
                }
                reader.Close();
                session.Close();

                return titulo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public AtividadeComplementar Buscar(int encontro = 0, int aluno = 0)
        {
            try
            {
                AtividadeComplementar atividade = new AtividadeComplementar();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM atividade_complementar WHERE idencontro = @encontro");
                quey.SetParameter("encontro", encontro);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    atividade = new AtividadeComplementar(Convert.ToInt32(reader["idatividade"]), Convert.ToInt32(reader["idencontro"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToDateTime(reader["dtexibicao"]), aluno);
                }
                reader.Close();
                session.Close();

                return atividade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<AtividadeComplementarQuestoes> ListaQuestoes(int atividade, int aluno)
        {
            try
            {
                List<AtividadeComplementarQuestoes> questao = new List<AtividadeComplementarQuestoes>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT acq.*, ISNULL((SELECT TXRESPOSTA FROM atividade_complementar_resposta WHERE idquestao = acq.idquestao and idaluno = @aluno), '') as resposta from atividade_complementar_questoes acq WHERE acq.idatividade = @atividade order by acq.idquestao");
                quey.SetParameter("atividade", atividade);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    questao.Add(new AtividadeComplementarQuestoes(Convert.ToInt32(reader["idatividade"]), Convert.ToInt32(reader["idquestao"]), Convert.ToString(reader["txquestao"]), Convert.ToString(reader["flgabarito"]), Convert.ToString(reader["resposta"])));
                }
                reader.Close();
                session.Close();

                return questao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<AtividadeComplementarVideos> ListaVideos(int atividade)
        {
            try
            {
                List<AtividadeComplementarVideos> videos = new List<AtividadeComplementarVideos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from atividade_complementar_videos WHERE idatividade = @atividade");
                quey.SetParameter("atividade", atividade);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    videos.Add(new AtividadeComplementarVideos(Convert.ToInt32(reader["idatividade"]), Convert.ToString(reader["txlink"])));
                }
                reader.Close();
                session.Close();

                return videos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<AtividadeComplementarAnexos> ListaAnexos(int atividade)
        {
            try
            {
                List<AtividadeComplementarAnexos> anexos = new List<AtividadeComplementarAnexos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from atividade_complementar_anexos WHERE idatividade = @atividade");
                quey.SetParameter("atividade", atividade);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    anexos.Add(new AtividadeComplementarAnexos(Convert.ToInt32(reader["idatividade"]), Convert.ToString(reader["txarquivo"])));
                }
                reader.Close();
                session.Close();

                return anexos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int ExisteResposta(int idaluno, int idquestao)
        {
            try
            {
                int idq = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from atividade_complementar_resposta where idquestao = @questao and idaluno = @aluno");
                query.SetParameter("questao", idquestao);
                query.SetParameter("aluno", idaluno);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    idq = Convert.ToInt32(reader["idquestao"]);
                }
                reader.Close();
                session.Close();

                return idq;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public void SalvarResposta(AtividadeComplementarResposta variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO atividade_complementar_resposta (idquestao, idaluno, txresposta) VALUES (@questao, @aluno, @resposta) ");
                query.SetParameter("questao", variavel.idquestao)
                    .SetParameter("aluno", variavel.idaluno)
                    .SetParameter("resposta", variavel.txresposta);

                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarResposta(AtividadeComplementarResposta variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE atividade_complementar_resposta SET txresposta = @resposta WHERE idquestao = @questao and idaluno = @aluno");
                query.SetParameter("questao", variavel.idquestao)
                    .SetParameter("aluno", variavel.idaluno)
                    .SetParameter("resposta", variavel.txresposta);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int TotalRespostas(int idatividade, int idaluno)
        {
            try
            {
                int total = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select count(*) as total from atividade_complementar_resposta where idaluno = @aluno and idquestao in (select idquestao from atividade_complementar_questoes where idatividade = @atividade)");
                query.SetParameter("aluno", idaluno);
                query.SetParameter("atividade", idatividade);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    total = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
                session.Close();

                return total;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
