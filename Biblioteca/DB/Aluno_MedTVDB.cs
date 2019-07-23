using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_MedTVDB
    {
        public void Salvar(Aluno_MedTV variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_MedTV (aluno, senha, data, ativo, ativoEm, ativoAte, desativado, desativadoEm, urlPagseguro, msgpagseguro, pagseguro, codePagseguro) VALUES (@aluno, @senha, @data, @ativo, @ativoEm, @ativoAte, @desativado, @desativadoEm, @urlPagseguro, @msgpagseguro, @pagseguro, @codePagseguro) ");
                query.SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("data", variavel.data)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("ativoEm", variavel.ativoEm)
                    .SetParameter("ativoAte", variavel.ativoAte)
                    .SetParameter("desativado", variavel.desativado)
                    .SetParameter("desativadoEm", variavel.desativadoEm)
                    .SetParameter("urlPagseguro", variavel.urlPagseguro)
                    .SetParameter("msgpagseguro", variavel.msgPagseguro)
                    .SetParameter("pagseguro", variavel.pagseguro)
                    .SetParameter("codePagseguro", variavel.codePagseguro);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Aluno_MedTV variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_MedTV (aluno, senha, data, ativo, ativoEm, ativoAte, desativado, desativadoEm, urlPagseguro, msgpagseguro, pagseguro, codePagseguro) output INSERTED.aluno_MedTV_id VALUES (@aluno, @senha, @data, @ativo, @ativoEm, @ativoAte, @desativado, @desativadoEm, @urlPagseguro, @msgpagseguro, @pagseguro, @codePagseguro) ");
                query.SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("data", variavel.data)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("ativoEm", variavel.ativoEm)
                    .SetParameter("ativoAte", variavel.ativoAte)
                    .SetParameter("desativado", variavel.desativado)
                    .SetParameter("desativadoEm", variavel.desativadoEm)
                    .SetParameter("urlPagseguro", variavel.urlPagseguro)
                    .SetParameter("msgpagseguro", variavel.msgPagseguro)
                    .SetParameter("pagseguro", variavel.pagseguro)
                    .SetParameter("codePagseguro", variavel.codePagseguro);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Aluno_MedTV variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE aluno_MedTV SET senha = @senha, data = @data, ativo = @ativo, ativoEm = @ativoEm, ativoAte = @ativoAte, desativado = @desativado, desativadoEm = @desativadoEm, urlPagseguro = @urlPagseguro, pagseguro = @pagseguro, msgpagseguro = @msgpagseguro, codePagseguro = @codePagseguro WHERE aluno_MedTV_id = @aluno_MedTV_id");
                query.SetParameter("senha", variavel.senha)
                    .SetParameter("data", variavel.data)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("ativoEm", variavel.ativoEm)
                    .SetParameter("ativoAte", variavel.ativoAte)
                    .SetParameter("desativado", variavel.desativado)
                    .SetParameter("desativadoEm", variavel.desativadoEm)
                .SetParameter("aluno_MedTV_id", variavel.aluno_MedTV_id)
                    .SetParameter("urlPagseguro", variavel.urlPagseguro)
                    .SetParameter("msgpagseguro", variavel.msgPagseguro)
                    .SetParameter("pagseguro", variavel.pagseguro)
                    .SetParameter("codePagseguro", variavel.codePagseguro);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Aluno_MedTV variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_MedTV WHERE aluno_MedTV_id = @aluno_MedTV_id; DELETE FROM aluno_MedTV_Transacao WHERE aluno_MedTV_id = @aluno_MedTV_id; DELETE FROM aluno_MedTV_Notificacao WHERE aluno_MedTV_id = @aluno_MedTV_id;");
                query.SetParameter("aluno_MedTV_id", variavel.aluno_MedTV_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_MedTV Buscar(Aluno aluno)
        {
            try
            {
                Aluno_MedTV aluno_medtv = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(aluno, 0) as aluno, isnull(senha, '') as senha, isnull(data, '01/01/1900') as data, isnull(ativo, 0) as ativo, isnull(ativoEm, '01/01/1900') as ativoEm, isnull(ativoAte, '01/01/1900') as ativoAte, isnull(desativado, 0) as desativado, isnull(desativadoEm, '01/01/1900') as desativadoEm, isnull(urlPagseguro, '') as urlPagseguro, isnull(msgpagseguro, '') as msgpagseguro, isnull(pagseguro, 0) as pagseguro, isnull(codePagseguro, '') as codePagseguro FROM Aluno_MedTV WHERE aluno = @aluno");
                query.SetParameter("aluno", aluno.codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv = new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"]), aluno, Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["ativoEm"]), Convert.ToDateTime(reader["ativoAte"]), Convert.ToBoolean(reader["desativado"]), Convert.ToDateTime(reader["desativadoEm"]), Convert.ToString(reader["urlPagseguro"]), Convert.ToString(reader["msgpagseguro"]), Convert.ToBoolean(reader["pagseguro"]), Convert.ToString(reader["codePagseguro"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public bool Ativo(Aluno aluno)
        {
            try
            {
                bool aluno_medtv = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(aluno, 0) as aluno, isnull(senha, '') as senha, isnull(data, '01/01/1900') as data, isnull(ativo, 0) as ativo, isnull(ativoEm, '01/01/1900') as ativoEm, isnull(desativado, 0) as desativado, isnull(desativadoEm, '01/01/1900') as desativadoEm, isnull(urlPagseguro, '') as urlPagseguro, isnull(msgpagseguro, '') as msgpagseguro, isnull(pagseguro, 0) as pagseguro FROM Aluno_MedTV WHERE aluno = @aluno AND ativo = 1 AND ativoAte >= @data AND desativado = 0");
                query.SetParameter("aluno", aluno.codigo)
                    .SetParameter("data", DateTime.Now);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv = true;
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_MedTV Buscar(int id)
        {
            try
            {
                Aluno_MedTV aluno_medtv = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(aluno, 0) as aluno, isnull(senha, '') as senha, isnull(data, '01/01/1900') as data, isnull(ativo, 0) as ativo, isnull(ativoEm, '01/01/1900') as ativoEm, isnull(ativoAte, '01/01/1900') as ativoAte, isnull(desativado, 0) as desativado, isnull(desativadoEm, '01/01/1900') as desativadoEm, isnull(urlPagseguro, '') as urlPagseguro, isnull(msgpagseguro, '') as msgpagseguro, isnull(pagseguro, 0) as pagseguro, isnull(codePagseguro, '') as codePagseguro FROM Aluno_MedTV WHERE aluno_MedTV_id = @aluno_MedTV_id");
                query.SetParameter("aluno_MedTV_id", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_medtv = new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"]), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["ativoEm"]), Convert.ToDateTime(reader["ativoAte"]), Convert.ToBoolean(reader["desativado"]), Convert.ToDateTime(reader["desativadoEm"]), Convert.ToString(reader["urlPagseguro"]), Convert.ToString(reader["msgpagseguro"]), Convert.ToBoolean(reader["pagseguro"]), Convert.ToString(reader["codePagseguro"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Aluno_MedTV BuscarCompleto(int id)
        {
            try
            {
                Aluno_MedTV aluno_medtv = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(aluno, 0) as aluno, isnull(senha, '') as senha, isnull(data, '01/01/1900') as data, isnull(ativo, 0) as ativo, isnull(ativoEm, '01/01/1900') as ativoEm, isnull(ativoAte, '01/01/1900') as ativoAte, isnull(desativado, 0) as desativado, isnull(desativadoEm, '01/01/1900') as desativadoEm, isnull(urlPagseguro, '') as urlPagseguro, isnull(msgpagseguro, '') as msgpagseguro, isnull(pagseguro, 0) as pagseguro, isnull(codePagseguro, '') as codePagseguro FROM Aluno_MedTV WHERE aluno_MedTV_id = @aluno_MedTV_id");
                query.SetParameter("aluno_MedTV_id", id);
                IDataReader reader = query.ExecuteQuery();

                AlunoDB db = new AlunoDB();

                if (reader.Read())
                {
                    aluno_medtv = new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"]), db.Buscar(Convert.ToInt32(reader["aluno"])), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["ativoEm"]), Convert.ToDateTime(reader["ativoAte"]), Convert.ToBoolean(reader["desativado"]), Convert.ToDateTime(reader["desativadoEm"]), Convert.ToString(reader["urlPagseguro"]), Convert.ToString(reader["msgpagseguro"]), Convert.ToBoolean(reader["pagseguro"]), Convert.ToString(reader["codePagseguro"]));
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }


        public List<string> AutoComplete(string busca)
        {
            try
            {
                List<string> aluno = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select concat(a.nome, ' (', a.cpf, ')') as string from aluno as a where a.nome like '%" + busca + "%' OR replace(replace(replace(replace(a.cpf, '.', ''), '-', ''), '/', ''), ' ', '') like replace(replace(replace(replace('%" + busca + "%', '.', ''), '-', ''), '/', ''), ' ', '') ORDER BY string");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(Convert.ToString(reader["string"]));
                }

                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_MedTV> Listar(string aluno, int status, string inicio, string fim)
        {
            try
            {
                string q = "";

                if(aluno != "")
                {
                    if(aluno.IndexOf("(") > -1)
                    {
                        aluno = aluno.Substring(0, aluno.IndexOf("(") - 1).TrimStart().TrimEnd();
                    }
                    q += " AND a.nome LIKE '%" + aluno +"%'";
                }

                if(status == 1)
                {
                    q += " AND am.ativo = 1";
                }
                if (status == 2)
                {
                    q += " AND am.desativado = 1";
                }

                DateTime i = Convert.ToDateTime("01/01/1900");
                DateTime f = Convert.ToDateTime("01/01/1900");

                if (inicio.Length == 10 && fim.Length == 10)
                {
                    i = Convert.ToDateTime(inicio);
                    f = Convert.ToDateTime(fim);
                    q += " AND am.data between @i AND @f";
                }

                List<Aluno_MedTV> aluno_medtv = new List<Aluno_MedTV>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(am.aluno_MedTV_id, 0) as aluno_MedTV_id, isnull(am.aluno, 0) as aluno, isnull(a.email, '') as email, isnull(a.nome, '') as nome, isnull(a.cpf, '') as cpf, isnull(am.senha, '') as senha, isnull(am.data, '01/01/1900') as data, isnull(am.ativo, 0) as ativo, isnull(am.ativoEm, '01/01/1900') as ativoEm, isnull(ativoAte, '01/01/1900') as ativoAte, isnull(am.desativado, 0) as desativado, isnull(am.desativadoEm, '01/01/1900') as desativadoEm, isnull(am.urlPagseguro, '') as urlPagseguro, isnull(am.msgpagseguro, '') as msgpagseguro, isnull(am.pagseguro, 0) as pagseguro, isnull(am.codePagseguro, '') as codePagseguro FROM Aluno_MedTV as am INNER JOIN aluno as a ON am.aluno = a.codigo WHERE am.aluno_MedTV_id > 0 " + q + " ORDER BY nome");
                if(i != Convert.ToDateTime("01/01/1900") && f != Convert.ToDateTime("01/01/1900"))
                {
                    query.SetParameter("i", i)
                        .SetParameter("f", f);
                }
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_medtv.Add(new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"]), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]), nome = Convert.ToString(reader["nome"]), cpf = Convert.ToString(reader["cpf"]), email = Convert.ToString(reader["email"]) }, Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["ativoEm"]), Convert.ToDateTime(reader["ativoAte"]), Convert.ToBoolean(reader["desativado"]), Convert.ToDateTime(reader["desativadoEm"]), Convert.ToString(reader["urlPagseguro"]), Convert.ToString(reader["msgpagseguro"]), Convert.ToBoolean(reader["pagseguro"]), Convert.ToString(reader["codePagseguro"])));
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Aluno_MedTV> ListarParaLancamento()
        {
            try
            {
                
                List<Aluno_MedTV> aluno_medtv = new List<Aluno_MedTV>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from aluno_MedTV where pagseguro = 1 and ativo = 1 and exists (select * from aluno_medtv_notificacao where status = 'ACTIVE' and aluno_medtv_notificacao.aluno_medtv_id = aluno_medtv.aluno_medtv_id) and aluno not in(4284,4402)");
                IDataReader reader = query.ExecuteQuery();

                AlunoDB alunodb = new AlunoDB();
                while (reader.Read())
                {
                    aluno_medtv.Add(new Aluno_MedTV(Convert.ToInt32(reader["aluno_MedTV_id"]), alunodb.Buscar(Convert.ToInt32(reader["aluno"])), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data"]), Convert.ToBoolean(reader["ativo"]), Convert.ToDateTime(reader["ativoEm"]), Convert.ToDateTime(reader["ativoAte"]), Convert.ToBoolean(reader["desativado"]), Convert.ToDateTime(reader["desativadoEm"]), Convert.ToString(reader["urlPagseguro"]), Convert.ToString(reader["msgpagseguro"]), Convert.ToBoolean(reader["pagseguro"]), Convert.ToString(reader["codePagseguro"])));
                }
                reader.Close();
                session.Close();

                return aluno_medtv;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
