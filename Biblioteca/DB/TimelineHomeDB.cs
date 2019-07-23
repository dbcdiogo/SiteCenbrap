using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineHomeDB
    {

        public List<TimelineHome> ListarConfirmados(int dias)
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
                    ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
	                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
                FROM curso c
                WHERE c.codigo > 0 AND ((c.visualiza_site = '1' or c.tipo = 3) OR (c.visualiza_site = '0')) AND c.inicio_confirmado = 1 and cast(c.data_inicio as date) >= cast(getdate() as date) and c.tipo in (0, 1)
                ORDER BY c.data_inicio, titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(dias, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineHome> ListarAbertos(int dias)
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
	                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) + 
	                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and ((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
	                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) + 
	                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
                FROM curso c 
                WHERE c.codigo > 0 AND (c.visualiza_site = '1' or c.tipo = 3) and c.inicio_confirmado = 0 and cast(c.data_inicio as date) >= cast(getdate() as date) and datediff(day, getdate(), c.data_inicio) <= 30 and c.tipo in (0,1) 
                ORDER BY c.data_inicio, titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(dias, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<TimelineHome> ListarPorSituacao()
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                //Query quey = session.CreateQuery("SELECT c.codigo, (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.curso = c.codigo AND a.situacao = '2') as confirmado, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio FROM curso c WHERE c.codigo > 0 AND c.visualiza_site = '1' and c.tipo in (0,1) ORDER BY c.data_inicio, titulo1");
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo1, 
	                (select count(*) from (
		                select l.tipo
		                from aluno_curso ac
		                CROSS APPLY (
			                select top 1 tipo from aluno_curso_log acl WHERE acl.aluno_curso = ac.codigo 
			                and ((acl.tipo <> 1) or (acl.tipo = 1 and (select max(a.tipo) from aluno_curso_log a where a.aluno_curso = acl.aluno_curso and a.data < acl.data) not in (3,4,5,9))) order by data desc
		                ) as l
		                where ac.curso = c.codigo 
		                ) as t where t.tipo in (3,5,9)) as confirmado,
	                isnull(c.data_inicio, '1900-01-01') AS data_inicio 
                FROM curso c 
                WHERE c.codigo > 0 AND c.visualiza_site = '1' and c.tipo in (0,1) 
                ORDER BY c.data_inicio, c.titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["confirmado"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<TimelineHome> ListarDestaques(int dias)
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession(); 
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
	                    ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) + 
	                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and ((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
	                    (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
	                    ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) + 
	                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
	                    (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
	                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
                    FROM curso c                     
                    WHERE((c.codigo > 0 AND(c.visualiza_site = '1' or c.tipo = 3)) or((select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) > 0)) and isnull(c.inicio_confirmado_data,'1900-01-01') = '1900-01-01'");
                    //WHERE (c.codigo > 0 AND (c.visualiza_site = '1' or c.tipo = 3) and c.inicio_confirmado_data is null) or ((select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) > 0)");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(dias, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineHome> ListarcomAcoes(int dias)
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select * from (
	                SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
		                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) +
		                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
		                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
		                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) +
		                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
		                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                        (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
	                FROM curso c
	                WHERE c.codigo > 0 AND (c.visualiza_site = '1' or c.tipo = 3) AND c.inicio_confirmado = 1 and cast(c.data_inicio as date) < cast(getdate() as date) and c.tipo in (0, 1) and c.inicio_confirmado_data is null
	                union all
	                SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
		                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) + 
		                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and ((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
		                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
		                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) + 
		                (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
		                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                        (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
	                FROM curso c 
	                WHERE c.codigo > 0 AND (c.visualiza_site = '1' or c.tipo = 3) and c.inicio_confirmado = 0 and (cast(c.data_inicio as date) < cast(getdate() as date) or datediff(day, getdate(), c.data_inicio) > 30) and c.tipo in (0,1) and c.inicio_confirmado_data is null
                        and ((select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) = 0)
                ) as t where t.total > 0 or t.historico > 0
                ORDER BY t.data_inicio, t.titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(dias, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineHome> ListarTurmasAndamento(int dias)
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
                    ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
	                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
                FROM curso c
                WHERE c.codigo > 0 AND c.inicio_confirmado = 1 and c.tipo in (0, 1)
	                and (select count(*) from encontro where curso = c.codigo and ativo = 1) > 5 
	                and (select count(*) from encontro where curso = c.codigo and ativo = 1 and data_encontro <= getdate()) between 1 and 4
                ORDER BY c.data_inicio, titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(dias, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineHome> TurmasListaEspera()
        {
            try
            {
                List<TimelineHome> dados = new List<TimelineHome>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT c.codigo, c.titulo, c.titulo1, isnull(c.data_inicio, '1900-01-01') AS data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, 
                    ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date)))) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date))) as total, 
	                ((select count(*) from timeline_eventos where idcurso = c.codigo and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)) +
                    (select count(*) from mailing_campanhas_cursos mcc inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = c.codigo and cast(mca.dtenvio as date) < cast(getdate() as date)) +
	                (SELECT count(*) FROM timeline_eventos te inner join timeline_eventos_itens tei on tei.idevento = te.idevento WHERE te.idcurso = c.codigo and te.fltipo = 'T' and tei.fldashboard = 1 and cast(te.dtdeadline as date) <= cast(getdate() as date))) as historico,
                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
                FROM curso c
                WHERE c.codigo > 0 AND c.data_lista_espera is not null and c.tipo in (0, 1)
                ORDER BY c.data_inicio, titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new TimelineHome(0, Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToDateTime(reader["inicio_confirmado_data"]), Convert.ToInt32(reader["total"]), Convert.ToInt32(reader["historico"]), Convert.ToInt32(reader["destaque"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineTurmaDados ListarDadosTurma(int codigo)
        {
            try
            {
                TimelineTurmaDados dados = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT count(codigo) AS qtd_aberto, 
                    (SELECT count(a.codigo) FROM aluno_curso AS a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND((a.situacao = '0' AND datediff(DAY, email_impressao_boleto, getdate()) <= 5) OR a.situacao = '1')) AS qtd_reservado,
	                (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao = '2') AS qtd_confirmado,
	                (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao in (3, 4)) AS qtd_desistente,
	                (select count(*) from documentos_alunos where curso = @codigo and documentos = (select codigo from documentos where curso = @codigo and documentos1 = 'Contrato')) AS qtd_contrato,
	                (SELECT COUNT(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo and Year(isnull(nao_fara_o_curso, '1900-01-01')) <> 1900) as qtd_inativos
                 FROM aluno_curso
                 WHERE curso = @codigo AND situacao = '0' and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)");
                //Query quey = session.CreateQuery(@"SELECT count(codigo) AS qtd_aberto, 
                //    (SELECT count(a.codigo) FROM aluno_curso AS a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND((a.situacao = '0' AND datediff(DAY, email_impressao_boleto, getdate()) <= 5) OR a.situacao = '1')) AS qtd_reservado,
	               // (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao = '2') AS qtd_confirmado,
	               // (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao in (3, 4)) AS qtd_desistente,
	               // (select count(*) from documentos_alunos where curso = @codigo and documentos = (select codigo from documentos where curso = @codigo and documentos1 = 'Contrato')) AS qtd_contrato,
	               // (SELECT COUNT(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo and a.situacao = 0 and Year(isnull(nao_fara_o_curso, '1900-01-01')) <> 1900) as qtd_inativos
                // FROM aluno_curso
                // WHERE curso = @codigo AND situacao = '0' and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dados = new TimelineTurmaDados(Convert.ToInt32(reader["qtd_aberto"]), Convert.ToInt32(reader["qtd_reservado"]), Convert.ToInt32(reader["qtd_confirmado"]), Convert.ToInt32(reader["qtd_desistente"]), Convert.ToInt32(reader["qtd_contrato"]), Convert.ToInt32(reader["qtd_inativos"]));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineTurmaDadosLog> ListarDadosTurmaLog(int codigo)
        {
            try
            {
                List<TimelineTurmaDadosLog> dados = new List<TimelineTurmaDadosLog>();

                DBSession session = new DBSession();

                //Query quey = session.CreateQuery(@"select t.tipo, count(t.tipo) as total
                //from
                //(
                // select *, 
                //  (select top 1 (select case tipo when 1 then (select case when datediff(DAY, acl.data, getdate()) <= 5 then 10 else 0 end) when 2 then 10 when 6 then 0 when 7 then 0 when 9 then 3 else tipo end) as tipo
                //  from aluno_curso_log acl where acl.aluno_curso = ac.codigo and ((acl.tipo <> 1) or (acl.tipo = 1 and (select max(a.tipo) from aluno_curso_log a where a.aluno_curso = acl.aluno_curso and a.data < acl.data) not in (3,4,5,9))) order by acl.data desc
                //  ) as tipo 
                // from aluno_curso ac
                // WHERE ac.curso = @codigo and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1)
                //) as t
                //group by t.tipo");

                Query quey = session.CreateQuery(@"select tipo, count(l.tipo) as total
                    from aluno_curso ac
                    CROSS APPLY (select top 1 (
                     select case tipo 
                      when 1 then (select case when datediff(DAY, acl.data, getdate()) <= 5 then 10 else 0 end) 
                      when 2 then 10
                      when 6 then 0 
                      when 7 then 0
                      when 9 then 3
                      else tipo end) as tipo from aluno_curso_log acl WHERE acl.aluno_curso = ac.codigo 
                       and ((acl.tipo <> 1) or (acl.tipo = 1 and (select max(a.tipo) from aluno_curso_log a where a.aluno_curso = acl.aluno_curso and a.data < acl.data) not in (3,4,5,9))) order by data desc) AS L
                    WHERE ac.curso = @codigo and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1)
                    group by l.tipo");

                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dados.Add(new TimelineTurmaDadosLog(Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["total"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineTurmaDadosLog> ListarDadosTurmaLogAnterior(int codigo)
        {
            try
            {
                List<TimelineTurmaDadosLog> dados = new List<TimelineTurmaDadosLog>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select tipo, count(l.tipo) as total
                    from aluno_curso ac
                    CROSS APPLY (select top 1 (
	                    select case tipo 
		                    when 1 then (select case when datediff(DAY, acl.data, getdate()) <= 5 then 10 else 0 end) 
		                    when 2 then 10
		                    when 6 then 0 
		                    when 7 then 0
		                    when 9 then 3
		                    else tipo end) as tipo from aluno_curso_log acl WHERE acl.aluno_curso = ac.codigo 
			                    and ((acl.tipo <> 1) or (acl.tipo = 1 and (select max(a.tipo) from aluno_curso_log a where a.aluno_curso = acl.aluno_curso and a.data < acl.data) not in (3,4,5,9))) order by data desc) AS L
                    WHERE ac.curso = @codigo and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and cast(ac.data as date) <= cast(dateadd(DAY, -1, getdate()) as date)
                    group by l.tipo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    dados.Add(new TimelineTurmaDadosLog(Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["total"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineTurmaDados ListarDadosTurmaAnterior(int codigo, int dias)
        {
            try
            {
                TimelineTurmaDados dados = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT count(codigo) AS qtd_aberto, 
                    (SELECT count(a.codigo) FROM aluno_curso AS a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND((a.situacao = '0' AND datediff(DAY, email_impressao_boleto, getdate()) <= 5) OR a.situacao = '1') and cast(a.data as date) <= cast(dateadd(DAY, @dias, getdate()) as date) and cast(email_impressao_boleto as date) < cast(getdate() as date)) AS qtd_reservado,
	                (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao = '2' and cast(a.data as date) <= cast(dateadd(DAY, @dias, getdate()) as date)) AS qtd_confirmado,
	                (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo AND a.situacao in (3, 4) and cast(a.data as date) <= cast(dateadd(DAY, @dias, getdate()) as date)) AS qtd_desistente,
                	(select count(da.codigo) from documentos_alunos da where da.curso = @codigo and da.documentos = (select codigo from documentos where curso = @codigo and documentos1 = 'Contrato') and da.aluno in (select aluno from aluno_curso WHERE curso = @codigo) and cast(da.data as date) <= cast(dateadd(DAY, @dias, getdate()) as date)) AS qtd_contrato,
	                (SELECT COUNT(a.codigo) FROM aluno_curso as a WHERE a.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and a.curso = @codigo and cast(a.data as date) <= cast(dateadd(DAY, @dias, getdate()) as date) and Year(isnull(nao_fara_o_curso, '1900-01-01')) <> 1900) as qtd_inativos
                FROM aluno_curso
                WHERE curso = @codigo AND situacao = '0' and aluno not in (select idaluno from timeline_usuarios where flignorar = 1) and cast(data as date) <= cast(dateadd(DAY, @dias, getdate()) as date)");
                quey.SetParameter("codigo", codigo);
                quey.SetParameter("dias", dias);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dados = new TimelineTurmaDados(Convert.ToInt32(reader["qtd_aberto"]), Convert.ToInt32(reader["qtd_reservado"]), Convert.ToInt32(reader["qtd_confirmado"]), Convert.ToInt32(reader["qtd_desistente"]), Convert.ToInt32(reader["qtd_contrato"]), Convert.ToInt32(reader["qtd_inativos"]));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
