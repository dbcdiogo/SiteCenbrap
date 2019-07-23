using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class CampanhasDB
    {
        public int Salvar(Campanhas variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas (txcampanha, idmensagem, flativo, txcodigo, flcondicao) output INSERTED.idcampanha VALUES (@campanha, @mensagem, @ativo, @codigo, @condicao) ");
                query.SetParameter("campanha", variavel.txcampanha)
                    .SetParameter("mensagem", variavel.idmensagem.idmensagem)
                    .SetParameter("ativo", variavel.flativo)
                    .SetParameter("condicao", variavel.condicao)
                    .SetParameter("codigo", variavel.txcodigo);                
                    id = query.ExecuteScalar();
                    session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarRemetente(string email, int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_remetentes (idcampanha, idemail) VALUES (@campanha, @email) ");
                query.SetParameter("campanha", campanha)
                .SetParameter("email", email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirRemetente(int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas_remetentes WHERE idcampanha = @campanha");
                query.SetParameter("campanha", campanha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarResponder(string email, int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_responder (idcampanha, idemail) VALUES (@campanha, @email) ");
                query.SetParameter("campanha", campanha)
                .SetParameter("email", email);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public void ExcluirResponder(int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas_responder WHERE idcampanha = @campanha");
                query.SetParameter("campanha", campanha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Campanhas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_campanhas SET  txcampanha = @campanha, idmensagem = @mensagem, flativo = @ativo, txcodigo = @codigo, flcondicao = @condicao WHERE idcampanha = @idcampanha");
                query.SetParameter("idcampanha", variavel.idcampanha)
                   .SetParameter("campanha", variavel.txcampanha)
                   .SetParameter("mensagem", variavel.idmensagem.idmensagem)
                   .SetParameter("ativo", variavel.flativo)
                   .SetParameter("condicao", variavel.condicao)
                   .SetParameter("codigo", variavel.txcodigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Campanhas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas WHERE idcampanha = @idcampanha");
                query.SetParameter("idcampanha", variavel.idcampanha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Campanhas Buscar(int id)
        {
            try
            {
                Campanhas campanhas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_campanhas WHERE idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    campanhas = new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]),  Convert.ToString(reader["txcodigo"]), Convert.ToString(reader["flcondicao"]));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Campanhas Buscar(string campanha)
        {
            try
            {
                Campanhas campanhas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_campanhas WHERE txcampanha like '%@campanha%' Or txcodigo like '%@campanha%'");
                quey.SetParameter("campanha", campanha);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    campanhas = new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]),  Convert.ToString(reader["txcodigo"]));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Campanhas> Listar()
        {
            try
            {
                List<Campanhas> dataLote = new List<Campanhas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT idcampanha, txcampanha, idmensagem, flativo, txcodigo, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mailing_campanhas.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, flcondicao, ISNULL((case (select count(*) from mailing_enviados mv where mv.idcampanha = mailing_campanhas.idcampanha and mv.flenviado = 0) WHEN 0 THEN (select top 1 md.dtenviado from mailing_enviados md where md.idcampanha = mailing_campanhas.idcampanha and md.flenviado = 1 order by md.dtenviado desc) ELSE '01/01/1900' END), '01/01/1900') as ultimoenvio FROM mailing_campanhas ORDER BY data desc, txcampanha");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txcodigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["flcondicao"]), Convert.ToDateTime(reader["ultimoenvio"])));
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

        public List<Campanhas> ListarResumido()
        {
            try
            {
                List<Campanhas> dataLote = new List<Campanhas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT idcampanha, txcampanha FROM mailing_campanhas ORDER BY txcampanha");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"])));
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

        public List<Campanhas> Listar(int pagina = 1)
        {
            try
            {
                List<Campanhas> dataLote = new List<Campanhas>();

                DBSession session = new DBSession();
                //Query quey = session.CreateQuery("SELECT idcampanha, txcampanha, idmensagem, flativo, txcodigo, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mailing_campanhas.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, flcondicao, ISNULL((case (select count(*) from mailing_enviados mv where mv.idcampanha = mailing_campanhas.idcampanha and mv.flenviado = 0) WHEN 0 THEN (select top 1 md.dtenviado from mailing_enviados md where md.idcampanha = mailing_campanhas.idcampanha and md.flenviado = 1 order by md.dtenviado desc) ELSE '01/01/1900' END), '01/01/1900') as ultimoenvio FROM mailing_campanhas ORDER BY data desc, txcampanha OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                Query quey = session.CreateQuery(@"SELECT mc.idcampanha, mc.txcampanha, mc.idmensagem, mc.flativo, mc.txcodigo, 
	                isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, 
	                flcondicao,
	                ISNULL((select max(dtenviado) from mailing_enviados me where me.flenviado = 1 and me.idcampanha = mc.idcampanha), '01/01/1900') as ultimoenvio 
                FROM mailing_campanhas mc
                ORDER BY data desc, mc.txcampanha OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txcodigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["flcondicao"]), Convert.ToDateTime(reader["ultimoenvio"])));
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

        public List<Campanhas> Listar(int pagina = 1, string campanha = "")
        {
            try
            {
                List<Campanhas> dataLote = new List<Campanhas>();

                DBSession session = new DBSession();
                //Query quey = session.CreateQuery("SELECT idcampanha, txcampanha, idmensagem, flativo, txcodigo, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mailing_campanhas.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, flcondicao, ISNULL((case (select count(*) from mailing_enviados mv where mv.idcampanha = mailing_campanhas.idcampanha and mv.flenviado = 0) WHEN 0 THEN (select top 1 md.dtenviado from mailing_enviados md where md.idcampanha = mailing_campanhas.idcampanha and md.flenviado = 1 order by md.dtenviado desc) ELSE '01/01/1900' END), '01/01/1900') as ultimoenvio FROM mailing_campanhas WHERE txcampanha like '%" + campanha.Replace(" ", "%") + "%' Or txcodigo like '%" + campanha.Replace(" ", "%") + "%' ORDER BY data desc, txcampanha OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                Query quey = session.CreateQuery("SELECT mc.idcampanha, mc.txcampanha, mc.idmensagem, mc.flativo, mc.txcodigo, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, flcondicao, ISNULL((select max(dtenviado) from mailing_enviados me where me.flenviado = 1 and me.idcampanha = mc.idcampanha), '01/01/1900') as ultimoenvio FROM mailing_campanhas mc WHERE mc.txcampanha like '%" + campanha.Replace(" ", "%") + "%' Or mc.txcodigo like '%" + campanha.Replace(" ", "%") + "%' ORDER BY data desc, mc.txcampanha OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txcodigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["flcondicao"]), Convert.ToDateTime(reader["ultimoenvio"])));
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

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_campanhas");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string campanha = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_campanhas WHERE txcampanha like '%" + campanha.Replace(" ", "%") + "%' Or txcodigo like '%" + campanha.Replace(" ", "%") + "%'");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int VerificaRemetente(int id, int emails)
        {
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("select count(*) as total from mailing_campanhas_remetentes where idcampanha = @campanha and idemail = @email");
            quey.SetParameter("campanha", id);
            quey.SetParameter("email", emails);
            IDataReader reader = quey.ExecuteQuery();
            int retorno = 0;
            if (reader.Read())
            {
                retorno = Convert.ToInt32(reader["total"]);
            }
            else
            {
                retorno = 0;
            }
            reader.Close();
            session.Close();
            return retorno;
        }

        public int VerificaResponder(int id, int emails)
        {
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("select count(*) as total from mailing_campanhas_responder where idcampanha = @campanha and idemail = @email");
            quey.SetParameter("campanha", id);
            quey.SetParameter("email", emails);
            IDataReader reader = quey.ExecuteQuery();
            int retorno = 0;
            if (reader.Read())
            {
                retorno = Convert.ToInt32(reader["total"]);
            }
            else
            {
                retorno = 0;
            }
            reader.Close();
            session.Close();
            return retorno;
        }

        public List<CidadesCursos> ListarCidades(string cursos)
        {
            try
            {
                List<CidadesCursos> cidades = new List<CidadesCursos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT tc.titulo, tc.codigo as codigo_curso, ci.cidade, ci.codigo as codigo_cidade FROM curso c LEFT JOIN cidade as ci ON c.cidade_codigo = ci.codigo LEFT JOIN titulo_curso tc ON tc.codigo = c.titulo_curso WHERE c.titulo_curso in (" + cursos + ") AND c.visualiza_site = 1 and c.tipo in (0, 1, 2) ORDER BY tc.titulo, ci.cidade");               
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    cidades.Add(new CidadesCursos(Convert.ToInt32(reader["codigo_curso"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["codigo_cidade"]), Convert.ToString(reader["cidade"])));
                }
                reader.Close();
                session.Close();

                return cidades;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public CampanhasEnviados BuscarEnviados(int id, int page = 1, int regs = 500)
        {
            try
            {
                CampanhasEnviados campanhas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mc.idcampanha, mc.txcampanha, mc.idmensagem, mc.flativo, mc.txcodigo, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha) as enviados, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_abriu as ma where ma.idenviado = me.idenviado)) as abertos, (select count(*) as qtd from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and exists (select * from mailing_campanhas_cursos where mailing_campanhas_cursos.idcampanha = me.idcampanha and mailing_campanhas_cursos.idcurso = ac.curso) inner join curso as c ON c.codigo = ac.curso where me.idcampanha = mc.idcampanha and a.codigo not in (317, 4402)) as inscricoes from mailing_campanhas as mc where mc.idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    campanhas = new CampanhasEnviados(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToInt32(reader["flativo"]), Convert.ToString(reader["txcodigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["enviados"]), Convert.ToInt32(reader["abertos"]), Convert.ToInt32(reader["inscricoes"]), ListarEnviados(Convert.ToInt32(reader["idcampanha"]), page, regs), ListarCursosInscritos(Convert.ToInt32(reader["idcampanha"])));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<CampanhasEmails> ListarEnviados(int id = 0, int page = 1, int regs = 500)
        {
            try
            {
                List<CampanhasEmails> retorno = new List<CampanhasEmails>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select a.codigo as aluno, a.nome, a.email, isnull(c.codigo, 0) as curso, isnull(c.titulo1, '') as titulo, isnull(ac.adesao, '') as data_adesao, (case when (select count(*) from mailing_abriu where mailing_abriu.idenviado = me.idenviado) > 0 then 1 else 0 end) as abriu, (case when (select count(*) from mailing_clicou where mailing_clicou.idenviado = me.idenviado) > 0 then 1 else 0 end) as clicou from aluno as a inner join mailing_enviados me ON a.email = me.txpara left join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao left join curso as c ON c.codigo = ac.curso  where me.idcampanha = @idcampanha and a.codigo not in (317, 4402) ORDER BY nome OFFSET @regs * (@page - 1) ROWS FETCH NEXT @regs ROWS ONLY");
                quey.SetParameter("idcampanha", id);
                quey.SetParameter("regs", regs);
                quey.SetParameter("page", page);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new CampanhasEmails() {
                        abriu = Convert.ToBoolean(reader["abriu"]),
                        clicou = Convert.ToBoolean(reader["clicou"]),
                        aluno = Convert.ToInt32(reader["aluno"]),
                        nome = Convert.ToString(reader["nome"]),
                        email = Convert.ToString(reader["email"]),
                        data_adesao = Convert.ToDateTime(reader["data_adesao"]),
                        curso = Convert.ToInt32(reader["curso"]),
                        titulo = Convert.ToString(reader["titulo"])
                    });
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

        public string ListarCursosInscritos(int id = 0)
        {
            try
            {
                string retorno = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select distinct c.titulo1 from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao inner join curso as c ON c.codigo = ac.curso  where me.idcampanha = @idcampanha and a.codigo not in (317, 4402) ORDER BY titulo1");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (retorno != "")
                        retorno += ", ";
                    retorno += Convert.ToString(reader["titulo1"]);
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

        public Contas Remetentes(int id)
        {
            try
            {
                Contas contas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_campanhas_remetentes WHERE mailing_campanhas_remetentes.idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contas = new Contas(Convert.ToInt32(reader["idemail"]));
                }
                reader.Close();
                session.Close();

                return contas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> Responder(int id)
        {
            try
            {
                List<string> contas = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mailing_emails.txusuario from mailing_campanhas_responder inner join mailing_emails on mailing_campanhas_responder.idemail = mailing_emails.idemail where mailing_campanhas_responder.idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contas.Add(Convert.ToString(reader["txusuario"]));
                }
                reader.Close();
                session.Close();

                return contas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirCursosVinculados(int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas_cursos WHERE idcampanha = @campanha");
                query.SetParameter("campanha", campanha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarCursoVinculado(int curso, int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_cursos (idcampanha, idcurso) VALUES (@campanha, @curso) ");
                query.SetParameter("campanha", campanha)
                .SetParameter("curso", curso);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public String ListarCursosVinculados(int campanha)
        {
            try
            {
                string retorno = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT SUBSTRING((SELECT ',' + Cast(idcurso as varchar) from mailing_campanhas_cursos WHERE idcampanha = @campanha FOR XML PATH('')),2,999) as cursos");
                quey.SetParameter("campanha", campanha);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    retorno = Convert.ToString(reader["cursos"]);
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

        public String ListarCursosVinculadosNomes(int campanha)
        {
            try
            {
                string retorno = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT SUBSTRING((SELECT ', ' + c.titulo1 from mailing_campanhas_cursos m inner join curso c on c.codigo = m.idcurso WHERE m.idcampanha = @campanha FOR XML PATH('')),2,999) as cursos");
                quey.SetParameter("campanha", campanha);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    retorno = Convert.ToString(reader["cursos"]);
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

        public void ExcluirAgendamento(int campanha)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas_agendamento WHERE idcampanha = @campanha");
                query.SetParameter("campanha", campanha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

       
        public CampanhasEnviados BuscarDados(int id)
        {
            try
            {
                CampanhasEnviados campanhas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha) as selecionados, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and me.flenviado = 1) as enviados, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_abriu as ma where ma.idenviado = me.idenviado)) as abertos, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_clicou as ma where ma.idenviado = me.idenviado)) as clicados, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoes, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_abriu ma on ma.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoesa, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_clicou mc on mc.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoesc, mc.idmensagem, mc.txcodigo, (select count(*) from mailing_descadastrar as md WHERE md.idcampanha = mc.idcampanha) as descadastrados from mailing_campanhas as mc where mc.idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    campanhas = new CampanhasEnviados(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["enviados"]), Convert.ToInt32(reader["abertos"]), Convert.ToInt32(reader["inscricoes"]), Convert.ToInt32(reader["clicados"]), Convert.ToInt32(reader["inscricoesa"]), Convert.ToInt32(reader["inscricoesc"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txcodigo"]), Convert.ToInt32(reader["descadastrados"]), Convert.ToInt32(reader["selecionados"]));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public CampanhasEnviados BuscarDadosSemLink(int id)
        {
            try
            {
                CampanhasEnviados campanhas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha) as selecionados, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and me.flenviado = 1) as enviados, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_abriu as ma where ma.idenviado = me.idenviado)) as abertos, (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_clicou as ma where ma.idenviado = me.idenviado)) as clicados, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoes, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_abriu ma on ma.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoesa, (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_clicou mc on mc.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso where me.idcampanha = @idcampanha) as inscricoesc, mc.idmensagem, mc.txcodigo, (select count(*) from mailing_descadastrar as md WHERE md.idcampanha = mc.idcampanha) as descadastrados from mailing_campanhas as mc where mc.idcampanha = @idcampanha");
                quey.SetParameter("idcampanha", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    campanhas = new CampanhasEnviados();
                    campanhas.idcampanha = id;
                    campanhas.data = Convert.ToDateTime(reader["data"]);
                    campanhas.selecionados = Convert.ToInt32(reader["selecionados"]);
                    campanhas.enviados = Convert.ToInt32(reader["enviados"]);
                    campanhas.inscricoes = Convert.ToInt32(reader["inscricoes"]);
                    campanhas.abertos = Convert.ToInt32(reader["abertos"]);
                    campanhas.clicados = Convert.ToInt32(reader["clicados"]);
                    campanhas.inscricoesa = Convert.ToInt32(reader["inscricoesa"]);
                    campanhas.inscricoesc = Convert.ToInt32(reader["inscricoesc"]);
                    campanhas.taxa_abertura = (double)Convert.ToInt32(reader["abertos"]) / (double)Convert.ToInt32(reader["enviados"]) * 100;
                    campanhas.taxa_inscricoes = ((double)Convert.ToInt32(reader["inscricoesa"]) / (double)Convert.ToInt32(reader["abertos"])) * 100;
                    campanhas.taxa_clicados = ((double)Convert.ToInt32(reader["clicados"]) / (double)Convert.ToInt32(reader["abertos"])) * 100;
                    campanhas.idmensagem = new DB.MensagensDB().Buscar(Convert.ToInt32(reader["idmensagem"]));
                    campanhas.txcodigo = Convert.ToString(reader["txcodigo"]);
                    campanhas.descadastrados = Convert.ToInt32(reader["descadastrados"]);
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<CampanhasGraf> GraficoDados(int campanha)
        {
            try
            {
                List<CampanhasGraf> campanhas = new List<CampanhasGraf>();

                string cmdtxt = "";
                cmdtxt = cmdtxt + "select FORMAT(t2.data,'dd/MM/yyyy') as data, sum(t2.abriu) as abriu, sum(t2.clicou) as clicou from ( ";
                cmdtxt = cmdtxt + "select count(t.data) as abriu, 0 as clicou, t.data from( ";
                cmdtxt = cmdtxt + "select ma.idenviado, (case when CONVERT(DATE, ma.dtabriu, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, ma.dtabriu, 101) ELSE '2500-01-01' END) as data, ";
                cmdtxt = cmdtxt + "ROW_NUMBER() OVER(PARTITION BY ma.idenviado ORDER BY(case when CONVERT(DATE, ma.dtabriu, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, ma.dtabriu, 101) ELSE '2500-01-01' END) ASC) as linha ";
                cmdtxt = cmdtxt + "from mailing_abriu ma ";
                cmdtxt = cmdtxt + "inner join mailing_enviados me on me.idenviado = ma.idenviado ";
                cmdtxt = cmdtxt + "where me.idcampanha = @campanha ";
                cmdtxt = cmdtxt + "group by ma.idenviado, (case when CONVERT(DATE, ma.dtabriu, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, ma.dtabriu, 101) ELSE '2500-01-01' END) ";
                cmdtxt = cmdtxt + ") as t where linha = 1 group by t.data ";
                cmdtxt = cmdtxt + "union all ";
                cmdtxt = cmdtxt + "select 0 as abriu, count(t.data) as clicou, t.data from( ";
                cmdtxt = cmdtxt + "select mc.idenviado, (case when CONVERT(DATE, mc.dtclicou, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, mc.dtclicou, 101) ELSE '2500-01-01' END) as data, ";
                cmdtxt = cmdtxt + "ROW_NUMBER() OVER(PARTITION BY mc.idenviado ORDER BY(case when CONVERT(DATE, mc.dtclicou, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, mc.dtclicou, 101) ELSE '2500-01-01' END) ASC) as linha ";
                cmdtxt = cmdtxt + "from mailing_clicou mc ";
                cmdtxt = cmdtxt + "inner join mailing_enviados me on me.idenviado = mc.idenviado ";
                cmdtxt = cmdtxt + "where me.idcampanha = @campanha ";
                cmdtxt = cmdtxt + "group by mc.idenviado, (case when CONVERT(DATE, mc.dtclicou, 101) <= DateAdd(day, 12, CONVERT(DATE, me.dtenviado, 101)) THEN CONVERT(DATE, mc.dtclicou, 101) ELSE '2500-01-01' END) ";
                cmdtxt = cmdtxt + ") as t where linha = 1 group by t.data ";
                cmdtxt = cmdtxt + ") as t2 ";
                cmdtxt = cmdtxt + "group by t2.data ";
                cmdtxt = cmdtxt + "order by t2.data";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("campanha", campanha);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    campanhas.Add(new CampanhasGraf(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["abriu"]), Convert.ToInt32(reader["clicou"])));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<CampanhasAlunos> ListaAlunos(int id, int tipo)
        {
            try
            {
                List<CampanhasAlunos> campanhas = new List<CampanhasAlunos>();

                string cmdtxt = "";
                if (tipo == 1)
                {
                    cmdtxt = cmdtxt + "SELECT 1 as tipo, a.nome, me.dtenviado as data, '' as curso FROM mailing_enviados me inner join aluno a on a.email = me.txpara where idcampanha = @campanha and me.flenviado = 1 order by a.nome";
                }
                if (tipo == 2)
                {
                    cmdtxt = cmdtxt + "SELECT 2 as tipo, a.nome, ma.dtabriu as data, '' as curso FROM mailing_abriu ma inner join mailing_enviados me on me.idenviado = ma.idenviado inner join aluno a on a.email = me.txpara where idcampanha = @campanha order by a.nome, ma.dtabriu";
                }
                if (tipo == 3)
                {
                    cmdtxt = cmdtxt + "SELECT  3 as tipo, a.nome, mc.dtclicou as data, '' as curso FROM mailing_clicou mc inner join mailing_enviados me on me.idenviado = mc.idenviado inner join aluno a on a.email = me.txpara where idcampanha = @campanha order by a.nome, mc.dtclicou";
                }
                if (tipo == 4)
                {
                    cmdtxt = cmdtxt + "select 4 as tipo, a.nome, FORMAT(ac.adesao,'dd/MM/yyyy') as data, c.titulo1 as curso from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso inner join curso c on c.codigo = ac.curso where me.idcampanha = @campanha order by a.nome";
                }
                if (tipo == 5)
                {
                    cmdtxt = cmdtxt + "select distinct 5 as tipo, a.nome, FORMAT(ac.adesao,'dd/MM/yyyy') as data, c.titulo1 as curso from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_abriu ma on ma.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso inner join curso c on c.codigo = ac.curso where me.idcampanha = @campanha order by a.nome";
                }
                if (tipo == 6)
                {
                    cmdtxt = cmdtxt + "select distinct 6 as tipo, a.nome, FORMAT(ac.adesao,'dd/MM/yyyy') as data, c.titulo1 as curso from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_clicou mc on mc.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso inner join curso c on c.codigo = ac.curso where me.idcampanha = @campanha order by a.nome";
                }
                if (tipo == 7)
                {
                    cmdtxt = cmdtxt + "select 7 AS tipo, a.nome, md.data as data, '' as curso from mailing_descadastrar md inner join aluno a on a.codigo = md.idaluno where md.idcampanha = @campanha order by a.nome";
                }
                if (tipo == 8)
                {
                    cmdtxt = cmdtxt + "SELECT 1 as tipo, a.nome, me.dtenviado as data, '' as curso FROM mailing_enviados me inner join aluno a on a.email = me.txpara where idcampanha = @campanha order by a.nome";
                }
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(cmdtxt);
                quey.SetParameter("campanha", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    campanhas.Add(new CampanhasAlunos(Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["nome"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["curso"])));
                }
                reader.Close();
                session.Close();

                return campanhas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool DescadastrarBusca(int campanha = 0, int aluno = 0)
        {
            try
            {
                bool existe = false;
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from mailing_descadastrar where idcampanha = @idcampanha and idaluno = @idaluno");
                quey.SetParameter("idcampanha", campanha);
                quey.SetParameter("idaluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    existe = true;
                }
                reader.Close();
                session.Close();

                return existe;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Descadastrar(int campanha = 0, int aluno = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_descadastrar (idcampanha, idaluno, data) VALUES (@idcampanha, @idaluno, getdate()) ");
                query.SetParameter("idcampanha", campanha);
                query.SetParameter("idaluno", aluno);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Campanhas> ListarPorCurso(int curso)
        {
            try
            {
                List<Campanhas> dataLote = new List<Campanhas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mcc.idcampanha, mc.txcampanha, mca.dtenvio from mailing_campanhas_cursos mcc left join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha where mcc.idcurso = @curso");
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Campanhas(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), Convert.ToDateTime(reader["dtenvio"])));
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
