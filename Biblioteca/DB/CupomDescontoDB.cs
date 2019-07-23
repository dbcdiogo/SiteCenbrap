using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class CupomDescontoDB
    {
        public int SalvarRetornar(CupomDesconto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO CupomDesconto (cupom, data, ip) output INSERTED.CupomDesconto_id VALUES (@cupom, @data, @ip) ");
                query.SetParameter("cupom", variavel.cupom)
                    .SetParameter("ip", variavel.ip)
                    .SetParameter("data", variavel.data);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(CupomDesconto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE CupomDesconto set cupom = @cupom WHERE CupomDesconto_id = @CupomDesconto_id");
                query.SetParameter("cupom", variavel.cupom)
                    .SetParameter("CupomDesconto_id", variavel.cupomDesconto_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(CupomDesconto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM CupomDesconto WHERE CupomDesconto_id = @CupomDesconto_id; DELETE FROM CupomDesconto_utilizacao WHERE CupomDesconto_id = @CupomDesconto_id;");
                query.SetParameter("CupomDesconto_id", variavel.cupomDesconto_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(string cupom)
        {
            try
            {
                bool CupomDesconto = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(cupom, '') as cupom, isnull(data, '01/01/1900') as data, isnull(ip, '') as ip FROM CupomDesconto WHERE cupom = @cupom");
                query.SetParameter("cupom", cupom);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    CupomDesconto = true;
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public CupomDesconto Buscar(int id)
        {
            try
            {
                CupomDesconto CupomDesconto = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(cupom, '') as cupom, isnull(data, '01/01/1900') as data, isnull(ip, '') as ip FROM CupomDesconto WHERE CupomDesconto_id = @id");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    CupomDesconto = new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"]), Convert.ToString(reader["cupom"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["ip"]));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public CupomDesconto Buscar(string cupom)
        {
            try
            {
                CupomDesconto CupomDesconto = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(cupom, '') as cupom, isnull(data, '01/01/1900') as data, isnull(ip, '') as ip FROM CupomDesconto WHERE cupom = @cupom");
                query.SetParameter("cupom", cupom);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    CupomDesconto = new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"]), Convert.ToString(reader["cupom"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["ip"]));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<CupomDesconto> Listar(int exibir = 0)
        {
            try
            {
                List<CupomDesconto> CupomDesconto = new List<CupomDesconto>();

                string executar = "select isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(cupom, '') as cupom, isnull(data, '01/01/1900') as data, isnull(ip, '') as ip, isnull((select count(*) from CupomDesconto_utilizacao where CupomDesconto_utilizacao.cupomDesconto_id = CupomDesconto.cupomDesconto_id), 0) as qtdUtilizado, isnull((select count(aluno_curso.aluno) from aluno_curso WHERE aluno_curso.situacao = 2 and aluno_curso.curso = 374 AND exists (select * from CupomDesconto_utilizacao WHERE CupomDesconto_utilizacao.aluno = aluno_curso.aluno and CupomDesconto_utilizacao.cupomDesconto_id = CupomDesconto.cupomDesconto_id)), 0) as qtdConcluido ";
                if(exibir == 1)
                {
                    executar += ", isnull((select count(*) from envio_email where envio_email.assunto = 'Cupom Desconto Congresso Brasileiro de Psiquiatria Ocupacional' and envio_email.texto LIKE concat('%', cupom , '%')), 0) qtdEnviado";
                }
                executar += " FROM CupomDesconto ORDER BY cupomDesconto_id DESC";

                DBSession session = new DBSession();
                Query query = session.CreateQuery(executar);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    if(exibir == 1)
                    {
                        CupomDesconto.Add(new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"]), Convert.ToString(reader["cupom"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["ip"]), Convert.ToInt32(reader["qtdUtilizado"]), Convert.ToInt32(reader["qtdConcluido"]), Convert.ToInt32(reader["qtdEnviado"])));
                    }
                    else
                    {
                        CupomDesconto.Add(new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"]), Convert.ToString(reader["cupom"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["ip"]), Convert.ToInt32(reader["qtdUtilizado"]), Convert.ToInt32(reader["qtdConcluido"])));
                    }
                    
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<CupomAluno> ReenviarNaoUtilizado()
        {
            try
            {
                List<CupomAluno> CupomDesconto = new List<CupomAluno>();

                string executar = "select a.codigo, a.nome, ee.para, cd.cupom from CupomDesconto as cd inner join envio_email as ee ON ee.assunto = 'Cupom Desconto Congresso Brasileiro de Psiquiatria Ocupacional' and ee.texto LIKE concat('%', cupom , '%') inner join aluno as a on a.email = ee.para where not exists (select * from CupomDesconto_utilizacao as cdu where cdu.cupomDesconto_id = cd.cupomDesconto_id)";

                DBSession session = new DBSession();
                Query query = session.CreateQuery(executar);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    //int aluno, string nome, string email, string cupom
                    CupomDesconto.Add(new CupomAluno(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["para"]), Convert.ToString(reader["cupom"])));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }

    public class CupomDesconto_utilizacaoDB
    {
        public int SalvarRetornar(CupomDesconto_utilizacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO CupomDesconto_utilizacao (CupomDesconto_id, aluno, data, curso) output INSERTED.CupomDesconto_utilizacao_id VALUES (@CupomDesconto_id, @aluno, @data, @curso) ");
                query.SetParameter("CupomDesconto_id", variavel.cupomDesconto_id.cupomDesconto_id)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("curso", variavel.curso);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(CupomDesconto_utilizacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM cupomDesconto_utilizacao WHERE CupomDesconto_utilizacao_id = @CupomDesconto_utilizacao_id;");
                query.SetParameter("CupomDesconto_utilizacao", variavel.cupomDesconto_utilizacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public CupomDesconto_utilizacao Buscar(int id)
        {
            try
            {
                CupomDesconto_utilizacao CupomDesconto = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(CupomDesconto_utilizacao_id, 0) as CupomDesconto_utilizacao_id, isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data FROM CupomDesconto_utilizacao WHERE CupomDesconto_utilizacao_id = @id");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    CupomDesconto = new CupomDesconto_utilizacao(Convert.ToInt32(reader["CupomDesconto_utilizacao_id"]), new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"])), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<CupomDesconto_utilizacao> Listar(CupomDesconto c)
        {
            try
            {
                List<CupomDesconto_utilizacao> CupomDesconto = new List<CupomDesconto_utilizacao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(c.CupomDesconto_utilizacao_id, 0) as CupomDesconto_utilizacao_id, isnull(c.CupomDesconto_id, 0) as CupomDesconto_id, isnull(c.aluno, 0) as aluno, isnull(c.data, '01/01/1900') as data, a.nome as nome, a.email as email, isnull(c.curso, 0) as curso FROM CupomDesconto_utilizacao as c inner join aluno as a on c.aluno = a.codigo WHERE c.CupomDesconto_id = @id");
                query.SetParameter("id", c.cupomDesconto_id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    CupomDesconto.Add(new CupomDesconto_utilizacao(Convert.ToInt32(reader["CupomDesconto_utilizacao_id"]), c, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]), nome = Convert.ToString(reader["nome"]), email = Convert.ToString(reader["email"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["curso"])));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public CupomDesconto_utilizacao Buscar(Aluno aluno)
        {
            try
            {
                CupomDesconto_utilizacao CupomDesconto = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(CupomDesconto_utilizacao_id, 0) as CupomDesconto_utilizacao_id, isnull(CupomDesconto_id, 0) as CupomDesconto_id, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data FROM CupomDesconto_utilizacao WHERE aluno = @id ORDER BY data DESC");
                query.SetParameter("id", aluno.codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    CupomDesconto = new CupomDesconto_utilizacao(Convert.ToInt32(reader["CupomDesconto_utilizacao_id"]), new CupomDesconto(Convert.ToInt32(reader["CupomDesconto_id"])), aluno, Convert.ToDateTime(reader["data"]));
                }
                reader.Close();
                session.Close();

                return CupomDesconto;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Boolean CupomUtilizado(int aluno, int cupom)
        {
            try
            {
                var r = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from CupomDesconto_utilizacao where cupomdesconto_id = @cupom and aluno = @aluno");
                query.SetParameter("cupom", cupom);
                query.SetParameter("aluno", aluno);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    r = true;
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
