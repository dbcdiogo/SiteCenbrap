using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AvaliacaoDB
    {
        public int Salvar(AvaliacaoForm variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO avaliacoes (dtavaliacao, idaluno, idcurso, idencontro, ntdominio, ntpontualidade, ntdidatica, ntmaterial, txelogioprof, txsugestaoprof, flautorizo, ntdisponibilidade, ntpontualidaderep, ntcompetencia, txelogiorep, txsugestaorep) output INSERTED.idavaliacao VALUES (getdate(), @idaluno, @idcurso, @idencontro, @ntdominio, @ntpontualidade, @ntdidatica, @ntmaterial, @txelogioprof, @txsugestaoprof, @flautorizo, @ntdisponibilidade, @ntpontualidaderep, @ntcompetencia, @txelogiorep, @txsugestaorep)");
                query.SetParameter("idaluno", variavel.idaluno)
                    .SetParameter("idcurso", variavel.idcurso)
                    .SetParameter("idencontro", variavel.idencontro)
                    .SetParameter("ntdominio", variavel.ntdominio)
                    .SetParameter("ntpontualidade", variavel.ntpontualidade)
                    .SetParameter("ntdidatica", variavel.ntdidatica)
                    .SetParameter("ntmaterial", variavel.ntmaterial)
                    .SetParameter("txelogioprof", variavel.txelogio)
                    .SetParameter("txsugestaoprof", variavel.txsugestao)
                    .SetParameter("flautorizo", variavel.autorizo)
                    .SetParameter("ntdisponibilidade", variavel.ntdisponibilidade)
                    .SetParameter("ntpontualidaderep", variavel.ntpontualidaderep)
                    .SetParameter("ntcompetencia", variavel.ntcompetencia)
                    .SetParameter("txelogiorep", variavel.txelogiorep)
                    .SetParameter("txsugestaorep", variavel.txsugestaorep);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public string Representante(int c)
        {
            string r = "";
            DBSession session = new DBSession();
            Query quey = session.CreateQuery(@"SELECT r.nome FROM curso c LEFT JOIN representante r ON r.cidade = c.cidade_codigo WHERE c.codigo = @curso and r.ativo = 1");
            quey.SetParameter("curso", c);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToString(reader["NOME"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public string Professor(Encontro e, Curso c)
        {
            string r = "";
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT P.NOME FROM DISCIPLINA D LEFT JOIN PROFESSOR P ON P.CODIGO = D.PROFESSOR WHERE D.CURSO = @curso AND D.CODIGO = (SELECT DISCIPLINA FROM ENCONTRO WHERE CODIGO = @encontro)");
            quey.SetParameter("curso", c.codigo);
            quey.SetParameter("encontro", e.codigo);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToString(reader["NOME"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public Boolean Respondido(int a = 0, int e = 0, int c = 0)
        {
            Boolean r = false;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT * FROM AVALIACOES WHERE IDALUNO = @aluno AND IDCURSO = @curso AND IDENCONTRO = @encontro");
            quey.SetParameter("aluno", a);
            quey.SetParameter("curso", c);
            quey.SetParameter("encontro", e);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = true;
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<AvaliacaoLista> ListarAlunos(int c)
        {
            try
            {
                List<AvaliacaoLista> dataLote = new List<AvaliacaoLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT aluno.nome As nome, aluno.codigo, aluno.email
                    FROM aluno, aluno_curso
                    WHERE aluno.codigo = aluno_curso.aluno AND aluno_curso.curso = @curso AND aluno_curso.situacao = '2' AND aluno.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and aluno.nome not like '%representante%'
                    GROUP BY aluno.codigo, aluno.nome, aluno.email
                    ORDER BY aluno.nome");
                quey.SetParameter("curso", c);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoLista(Convert.ToString(reader["nome"]), Convert.ToInt32(reader["codigo"]), "", Convert.ToString(reader["email"])));
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

        public List<AvaliacaoLista> ListarAlunosFrequencia(int c, int e)
        {
            try
            {
                List<AvaliacaoLista> dataLote = new List<AvaliacaoLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select a.nome, a.codigo, a.email from Avaliacoes_frequencia af inner join aluno a on a.codigo = af.idaluno where af.idcurso = @curso and af.idencontro = @encontro and af.frequencia > 0");
                quey.SetParameter("curso", c);
                quey.SetParameter("encontro", e);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoLista(Convert.ToString(reader["nome"]), Convert.ToInt32(reader["codigo"]), "", Convert.ToString(reader["email"])));
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

        public AvaliacaoForm Buscar(int curso, int encontro, int aluno)
        {
            try
            {
                AvaliacaoForm avaliacao = new AvaliacaoForm();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from avaliacoes where idcurso = @curso and idencontro = @encontro and idaluno = @aluno");
                quey.SetParameter("curso", curso);
                quey.SetParameter("encontro", encontro);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    avaliacao = new AvaliacaoForm() {
                        dtavaliacao = Convert.ToDateTime(reader["dtavaliacao"]),
                        idaluno = Convert.ToInt32(reader["idaluno"]),
                        idencontro = Convert.ToInt32(reader["idencontro"]),
                        idcurso = Convert.ToInt32(reader["idcurso"]),
                        ntdominio = Convert.ToString(reader["ntdominio"]),
                        ntdidatica = Convert.ToString(reader["ntdidatica"]),
                        ntpontualidade = Convert.ToString(reader["ntpontualidade"]),
                        ntmaterial = Convert.ToString(reader["ntmaterial"]),
                        txelogio = Convert.ToString(reader["txelogioprof"]),
                        txsugestao = Convert.ToString(reader["txsugestaoprof"]),
                        autorizo = Convert.ToString(reader["flautorizo"]),
                        ntdisponibilidade = Convert.ToString(reader["ntdisponibilidade"]),
                        ntpontualidaderep = Convert.ToString(reader["ntpontualidaderep"]),
                        ntcompetencia = Convert.ToString(reader["ntcompetencia"]),
                        txelogiorep = Convert.ToString(reader["txelogiorep"]),
                        txsugestaorep = Convert.ToString(reader["txsugestaorep"]),
                        lista_conheceu = new AvaliacaoDB().ListarConheceu(Convert.ToInt32(reader["idavaliacao"])),
                        lista_objetivo = new AvaliacaoDB().ListarObjetivos(Convert.ToInt32(reader["idavaliacao"])),
                        lista_trabalho = new AvaliacaoDB().ListarTrabalhos(Convert.ToInt32(reader["idavaliacao"])),
                    };
                }
                reader.Close();
                session.Close();

                return avaliacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<AvaliacaoItens> ListarConheceu(int id = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.iditem, ac.txoutros, aic.txitem, aic.nrordem from Avaliacoes_conheceu ac inner join Avaliacoes_Itens_Conheceu aic on aic.iditem = ac.iditem where ac.idavaliacao = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txoutros"])));
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

        public List<AvaliacaoItens> ListarObjetivos(int id = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.iditem, ac.txoutros, aic.txitem, aic.nrordem from Avaliacoes_objetivos ac inner join Avaliacoes_Itens_Objetivos aic on aic.iditem = ac.iditem where ac.idavaliacao = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txoutros"])));
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

        public List<AvaliacaoItens> ListarTrabalhos(int id = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.iditem, ac.txoutros, aic.txitem, aic.nrordem from Avaliacoes_trabalhos ac inner join Avaliacoes_Itens_trabalhos aic on aic.iditem = ac.iditem where ac.idavaliacao = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txoutros"])));
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

        public List<AvaliacaoItens> AvaliacaoConheceu(string ids = "0")
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                if (ids == "") { ids = "0"; }
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Conheceu where iditem in (" + ids + ")");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<AvaliacaoItens> AvaliacaoObjetivo(string ids = "0")
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();
                if (ids == "") { ids = "0"; }
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Objetivos where iditem in (" + ids + ")");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<AvaliacaoItens> AvaliacaoTrabalho(string ids = "0")
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();
                if (ids == "") { ids = "0"; }
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Trabalhos where iditem in (" + ids + ")");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<AvaliacaoLista> ListarAlunosComAvaliacao(int c, int e)
        {
            try
            {
                List<AvaliacaoLista> dataLote = new List<AvaliacaoLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT a.nome, a.codigo, af.frequencia
                    FROM avaliacoes_frequencia af
                    LEFT JOIN Aluno a ON a.codigo = af.idaluno
                    WHERE af.idcurso = @curso AND af.idencontro = @encontro AND a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and a.nome not like '%representante%'
                    ORDER BY a.nome");
                quey.SetParameter("curso", c);
                quey.SetParameter("encontro", e);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoLista()
                    {
                        aluno = Convert.ToString(reader["nome"]),
                        idaluno = Convert.ToInt32(reader["codigo"]),
                        avaliacao = new AvaliacaoDB().Buscar(c, e, Convert.ToInt32(reader["codigo"])),
                        frequencia = Convert.ToInt32(reader["frequencia"]),
                    });
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

        public List<AvaliacaoLista> ListarAlunosComAvaliacao(int ano)
        {
            try
            {
                List<AvaliacaoLista> dataLote = new List<AvaliacaoLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT a.nome, a.codigo, af.frequencia, af.idcurso, af.idencontro
                    FROM avaliacoes_frequencia af
                    LEFT JOIN encontro e on e.codigo = af.idencontro
                    LEFT JOIN aluno a ON a.codigo = af.idaluno
                    WHERE YEAR(e.data_encontro) = @ano AND a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and a.nome not like '%representante%'
                    ORDER BY af.idcurso, af.idencontro, a.nome");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoLista()
                    {
                        aluno = Convert.ToString(reader["nome"]),
                        idaluno = Convert.ToInt32(reader["codigo"]),
                        avaliacao = new AvaliacaoDB().Buscar(Convert.ToInt32(reader["idcurso"]), Convert.ToInt32(reader["idencontro"]), Convert.ToInt32(reader["codigo"])),
                        frequencia = Convert.ToInt32(reader["frequencia"]),
                    });
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

        public List<Avaliacao1Encontro> ListarAlunosComAvaliacao1Encontro(int ano)
        {
            try
            {
                List<Avaliacao1Encontro> dataLote = new List<Avaliacao1Encontro>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT af.frequencia, af.idcurso, af.idencontro, isnull(av.idavaliacao, 0) as resposta
                    FROM avaliacoes_frequencia af
                    LEFT JOIN encontro e on e.codigo = af.idencontro
                    LEFT JOIN aluno a ON a.codigo = af.idaluno
                    LEFT join avaliacoes av on av.idaluno = af.idaluno and av.idcurso = af.idcurso and av.idencontro = af.idencontro
                    WHERE YEAR(e.data_encontro) = @ano AND a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and a.nome not like '%representante%' AND e.numero = 1 and e.modulo = 1
                    ORDER BY af.idcurso, af.idencontro");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Avaliacao1Encontro()
                    {
                        idcurso = Convert.ToInt32(reader["idcurso"]),
                        idencontro = Convert.ToInt32(reader["idencontro"]),
                        frequencia = Convert.ToInt32(reader["frequencia"]),
                        resposta = Convert.ToInt32(reader["resposta"]),
                    });
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

        public List<AvaliacaoLista> ListarReposicoes(int e)
        {
            try
            {
                List<AvaliacaoLista> dataLote = new List<AvaliacaoLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT aluno.nome As nome, curso.titulo AS titulo, aluno.codigo  
                    FROM aluno, reposicao, curso 
                    WHERE aluno.codigo = reposicao.aluno AND reposicao.encontro_reposicao = @encontro AND reposicao.confirmada = '1' AND reposicao.cancelada = '0' AND curso.codigo = reposicao.curso 
                    GROUP BY aluno.nome, curso.titulo , aluno.codigo  
                    ORDER BY aluno.nome");
                quey.SetParameter("encontro", e);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoLista(Convert.ToString(reader["nome"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"])));
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

        public List<AvaliacaoItens> ListarItensConheceu()
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Conheceu");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<AvaliacaoItens> ListarItensObjetivos()
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Objetivos");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<AvaliacaoItens> ListarItensTrabalhos()
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Avaliacoes_Itens_Trabalhos");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txitem"]), Convert.ToInt32(reader["nrordem"])));
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

        public void SalvarFrequencia(AvaliacaoFrequencia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO avaliacoes_frequencia (idaluno, idcurso, idencontro, frequencia) VALUES (@idaluno, @idcurso, @idencontro, @frequencia)");
                query.SetParameter("idaluno", variavel.idaluno)
                    .SetParameter("idcurso", variavel.idcurso)
                    .SetParameter("idencontro", variavel.idencontro)
                    .SetParameter("frequencia", variavel.frequencia);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarFrequencia(AvaliacaoFrequencia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE avaliacoes_frequencia set frequencia = @frequencia WHERE idaluno = @idaluno AND idencontro = @idencontro AND idcurso = @idcurso");
                query.SetParameter("idaluno", variavel.idaluno)
                    .SetParameter("idcurso", variavel.idcurso)
                    .SetParameter("idencontro", variavel.idencontro)
                    .SetParameter("frequencia", variavel.frequencia);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public AvaliacaoFrequencia BuscarFrequencia(int idcurso, int idencontro, int idaluno)
        {
            try
            {
                AvaliacaoFrequencia avaliacao = new AvaliacaoFrequencia();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from avaliacoes_frequencia where idcurso = @idcurso and idencontro = @idencontro and idaluno = @idaluno");
                quey.SetParameter("idcurso", idcurso);
                quey.SetParameter("idencontro", idencontro);
                quey.SetParameter("idaluno", idaluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    avaliacao = new AvaliacaoFrequencia()
                    {
                        idcurso = Convert.ToInt32(reader["idcurso"]),
                        idencontro = Convert.ToInt32(reader["idencontro"]),
                        idaluno = Convert.ToInt32(reader["idaluno"]),
                        frequencia = Convert.ToInt32(reader["frequencia"])
                    };
                }
                reader.Close();
                session.Close();

                return avaliacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirConheceu(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Avaliacoes_Conheceu WHERE idavaliacao = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirObjetivos(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Avaliacoes_Objetivos WHERE idavaliacao = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirTrabalhos(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Avaliacoes_Trabalhos WHERE idavaliacao = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void SalvarConheceu(int id = 0, int idavaliacao = 0, string outros = "")
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Avaliacoes_Conheceu (idavaliacao, iditem, txoutros) VALUES (@idavaliacao, @id, @outros) ");
                query.SetParameter("idavaliacao", idavaliacao)
                    .SetParameter("id", id)
                    .SetParameter("outros", outros);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void SalvarObjetivos(int id = 0, int idavaliacao = 0, string outros = "")
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Avaliacoes_Objetivos (idavaliacao, iditem, txoutros) VALUES (@idavaliacao, @id, @outros) ");
                query.SetParameter("idavaliacao", idavaliacao)
                    .SetParameter("id", id)
                    .SetParameter("outros", outros);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void SalvarTrabalhos(int id = 0, int idavaliacao = 0, string outros = "")
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Avaliacoes_Trabalhos (idavaliacao, iditem, txoutros) VALUES (@idavaliacao, @id, @outros) ");
                query.SetParameter("idavaliacao", idavaliacao)
                    .SetParameter("id", id)
                    .SetParameter("outros", outros);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<AvaliacaoItens> RespostasConheceu(int ano = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT count(ac.iditem) as total, aic.txitem
                    FROM Avaliacoes a
                    LEFT JOIN Avaliacoes_conheceu ac ON ac.idavaliacao = a.idavaliacao
                    LEFT JOIN Avaliacoes_Itens_Conheceu aic on aic.iditem = ac.iditem
                    INNER JOIN Encontro e ON e.codigo = a.idencontro
                    WHERE e.numero = 1 and YEAR(e.data_encontro) = @ano
                    GROUP BY aic.txitem");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["total"]), Convert.ToString(reader["txitem"])));
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

        public List<AvaliacaoItens> RespostasObjetivos(int ano = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT count(ac.iditem) as total, aic.txitem
                    FROM Avaliacoes a
                    LEFT JOIN Avaliacoes_objetivos ac ON ac.idavaliacao = a.idavaliacao
                    LEFT JOIN Avaliacoes_Itens_objetivos aic on aic.iditem = ac.iditem
                    INNER JOIN Encontro e ON e.codigo = a.idencontro
                    WHERE e.numero = 1 and YEAR(e.data_encontro) = @ano
                    GROUP BY aic.txitem");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["total"]), Convert.ToString(reader["txitem"])));
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

        public List<AvaliacaoItens> RespostasTrabalhos(int ano = 0)
        {
            try
            {
                List<AvaliacaoItens> dataLote = new List<AvaliacaoItens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT count(ac.iditem) as total, aic.txitem
                    FROM Avaliacoes a
                    LEFT JOIN Avaliacoes_Trabalhos ac ON ac.idavaliacao = a.idavaliacao
                    LEFT JOIN Avaliacoes_Itens_Trabalhos aic on aic.iditem = ac.iditem
                    INNER JOIN Encontro e ON e.codigo = a.idencontro
                    WHERE e.numero = 1 and YEAR(e.data_encontro) = @ano
                    GROUP BY aic.txitem");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoItens(Convert.ToInt32(reader["total"]), Convert.ToString(reader["txitem"])));
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

        public List<AvaliacaoElogioSugestao> ListarElogioSugestao(int curso, int encontro, string palavra, int alvo, int tipo)
        {
            try
            {
                List<AvaliacaoElogioSugestao> dataLote = new List<AvaliacaoElogioSugestao>();
                string qry = "";

                if ((alvo == 1) && (tipo == 1)) { qry += "select a.txelogiorep as texto, "; }
                if ((alvo == 1) && (tipo == 2)) { qry += "select a.txsugestaorep as texto, "; }
                if ((alvo == 2) && (tipo == 1)) { qry += "select a.txelogioprof as texto, "; }
                if ((alvo == 2) && (tipo == 2)) { qry += "select a.txsugestaorep as texto, "; }
                qry += "al.nome, c.titulo1, a.dtavaliacao, e.titulo ";
                qry += "from Avaliacoes a ";
                qry += "left join encontro e on e.codigo = a.idencontro ";
                qry += "left join aluno al on al.codigo = a.idaluno ";
                qry += "left join curso c on c.codigo = a.idcurso ";
                qry += "where ";
                if ((alvo == 1) && (tipo == 1)) { qry += "cast(a.txelogiorep as nvarchar) <> '' "; }
                if ((alvo == 1) && (tipo == 2)) { qry += "cast(a.txsugestaorep as nvarchar) <> '' "; }
                if ((alvo == 2) && (tipo == 1)) { qry += "cast(a.txelogioprof as nvarchar) <> '' "; }
                if ((alvo == 2) && (tipo == 2)) { qry += "cast(a.txsugestaorep as nvarchar) <> '' "; }
                if (curso > 0) { qry += "and c.codigo = " + curso + " ";  }
                if (encontro > 0) { qry += "and e.codigo = " + encontro + " "; }
                if (palavra != "") {
                    if ((alvo == 1) && (tipo == 1)) { qry += "and a.txelogiorep like '%" + palavra.Replace(" ", "%") + "%' "; }
                    if ((alvo == 1) && (tipo == 2)) { qry += "and a.txsugestaorep like '%" + palavra.Replace(" ", "%") + "%' "; }
                    if ((alvo == 2) && (tipo == 1)) { qry += "and a.txelogioprof like '%" + palavra.Replace(" ", "%") + "%' "; }
                    if ((alvo == 2) && (tipo == 2)) { qry += "and a.txsugestaorep like '%" + palavra.Replace(" ", "%") + "%' "; }
                }
                qry += "order by a.dtavaliacao";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(qry);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dataLote.Add(new AvaliacaoElogioSugestao(Convert.ToString(reader["texto"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["dtavaliacao"])));
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
    }
}
