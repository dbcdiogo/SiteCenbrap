using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineEventosDB
    {

        public void GravaVisualizacao(int evento, int usuario)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO timeline_eventos_visualizado (idevento, idusuario, dtvisualizado) VALUES (@idevento, @idusuario, getdate()) ");
                query.SetParameter("idevento", evento)
                .SetParameter("idusuario", usuario);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineEventosTurma EventosTurma(int turma)
        {
            try
            {
                TimelineEventosTurma eventos = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(data_abertura_pre_reserva,'1900-01-01') as reserva, isnull(ativo_data_abertura_matricula,'1900-01-01') as matricula, isnull(data_inicio,'1900-01-01') as inicio, isnull(inicio_confirmado_data,'1900-01-01') as confirmado, isnull(data_lista_espera,'1900-01-01') as lista_espera from curso where codigo = @turma");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    eventos = new TimelineEventosTurma(Convert.ToDateTime(reader["reserva"]), Convert.ToDateTime(reader["matricula"]), Convert.ToDateTime(reader["inicio"]), Convert.ToDateTime(reader["confirmado"]), Convert.ToDateTime(reader["lista_espera"]));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosAdiamento(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select data, CONCAT('de ', FORMAT(de,'dd/MM/yyyy'), ' para ', FORMAT(para,'dd/MM/yyyy')) as texto from curso_adiamento where curso = @turma order by data");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 1, 0, "Adiamento", Convert.ToString(reader["texto"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosAlunos(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.codigo, ac.adesao from aluno_curso ac left join aluno a on a.codigo = ac.aluno where ac.curso = @turma and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by ac.adesao");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["adesao"]), 5, 0, Convert.ToInt32(reader["codigo"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosAlunosLog(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                //Query quey = session.CreateQuery(@"select a.data, a.aluno_curso, 
                // (case when(a.data >= c.data_lista_espera and a.tipo = 0) then 99 else a.tipo end) as tipo ,
                // ISNULL((select max(acl.tipo) from aluno_curso_log acl where acl.aluno_curso = a.aluno_curso and acl.data < a.data),0) as anterior
                //from aluno_curso_log a 
                //inner join curso c on c.codigo = @turma 
                //where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) 
                //order by a.data, a.tipo");
                Query quey = session.CreateQuery(@"select a.data, a.aluno_curso, ac.aluno, ac.situacao, al.nome,
	                (case when(a.data >= c.data_lista_espera and a.tipo = 0) then 99 else a.tipo end) as tipo ,
	                ISNULL((select max(acl.tipo) from aluno_curso_log acl where acl.aluno_curso = a.aluno_curso and acl.data < a.data),0) as anterior
                from aluno_curso_log a 
                inner join curso c on c.codigo = @turma 
                left join aluno_curso ac on ac.codigo = a.aluno_curso and ac.curso = c.codigo
                left join aluno al on al.codigo = ac.aluno
                where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) 
                order by a.data, a.tipo");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    //eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["aluno_curso"]), 0, Convert.ToInt32(reader["anterior"])));
                    eventos.Add(new TimelineEventos()
                    {
                        data = Convert.ToDateTime(reader["data"]),
                        tipo = 5,
                        usuario = 0,
                        aluno_curso = new Aluno_curso(Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["nome"])),
                        titulo = Convert.ToString(reader["tipo"]),
                        anterior = Convert.ToInt32(reader["anterior"]),
                        texto = Convert.ToString(reader["situacao"])
                    });                        
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosEmails(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();

                DBSession session = new DBSession();
                //Query quey = session.CreateQuery("select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha from mailing_campanhas_cursos mcc inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = @turma and mca.dtenvio is not null order by mca.dtenvio");
                Query quey = session.CreateQuery(@"select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha,
	                isnull((select top 1 me.dtenviarapartir from mailing_enviados as me where me.idcampanha = mc.idcampanha order by me.dtenviarapartir), '01/01/1900') as data2,
	                (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha) as selecionados, 
	                (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and me.flenviado = 1) as enviados, 
	                (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_abriu as ma where ma.idenviado = me.idenviado)) as abertos, 
	                (select count(*) from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and exists (select * from mailing_clicou as ma where ma.idenviado = me.idenviado)) as clicados, 
	                (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_campanhas_cursos mccu on mccu.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mccu.idcurso where me.idcampanha = mcc.idcampanha) as inscricoes, 
	                (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_abriu ma on ma.idenviado = me.idenviado inner join mailing_campanhas_cursos mccu on mccu.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mccu.idcurso where me.idcampanha = mcc.idcampanha) as inscricoesa, 
	                (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_clicou mc on mc.idenviado = me.idenviado inner join mailing_campanhas_cursos mccu on mccu.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mccu.idcurso where me.idcampanha = mcc.idcampanha) as inscricoesc, 
	                mc.idmensagem, mc.txcodigo, 
	                (select count(*) from mailing_descadastrar as md WHERE md.idcampanha = mc.idcampanha) as descadastrados 
                from mailing_campanhas_cursos mcc 
                inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha 
                inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha 
                where mcc.idcurso = @turma and mca.dtenvio is not null 
                order by mca.dtenvio
                ");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    CampanhasEnviados campanhas = new CampanhasEnviados();
                    campanhas.idcampanha = Convert.ToInt32(reader["idcampanha"]);
                    campanhas.data = Convert.ToDateTime(reader["data2"]);
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

                    eventos.Add(new TimelineEventos()
                    {
                        data = Convert.ToDateTime(reader["data"]),
                        tipo = 6,
                        usuario = Convert.ToInt32(reader["idcampanha"]),
                        titulo = Convert.ToString(reader["txcampanha"]),
                        campanha = campanhas
                    });
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosEmails(int turma, int aluno)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha from mailing_enviados me inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha where me.txpara = (select email from aluno where codigo = @aluno) and mcc.idcurso = @turma and mca.dtenvio is not null order by mca.dtenvio");
                quey.SetParameter("turma", turma);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 6, Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), ""));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosEmailsAtivos(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha from mailing_campanhas_cursos mcc inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha where mcc.idcurso = @turma and mca.dtenvio is not null and mca.dtenvio is not null and ((mca.dtenvio <= getdate() and dateadd(day, 7, mca.dtenvio) >= getdate()) or (mca.dtenvio > getdate()))  order by mca.dtenvio");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 6, Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), ""));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosEmailsDashboard(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select * from (
	                select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha, 1 as ativo
                    from mailing_campanhas_cursos mcc 
                    inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha 
                    inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha 
                    where mcc.idcurso = @turma and mca.dtenvio is not null and ((cast(mca.dtenvio as date) <= cast(getdate() as date) and cast(dateadd(day, 7, mca.dtenvio) as date) >= cast(getdate() as date)) or (cast(mca.dtenvio as date) > cast(getdate() as date)))  
                    union all
                    select mca.dtenvio as data, mcc.idcampanha, mc.txcampanha, 0 as ativo
                    from mailing_campanhas_cursos mcc 
                    inner join mailing_campanhas mc on mc.idcampanha = mcc.idcampanha 
                    inner join mailing_campanhas_agendamento mca on mca.idcampanha = mcc.idcampanha 
                    where mcc.idcurso = @turma and mca.dtenvio is not null and cast(dateadd(day, 7, mca.dtenvio) as date) < cast(getdate() as date)
                ) as t order by t.ativo desc, t.data");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 6, Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txcampanha"]), "", Convert.ToInt32(reader["ativo"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_Email> EventosAlunosEmail(int aluno, int campanha)
        {
            try
            {
                List<Aluno_Email> aluno_email = new List<Aluno_Email>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select me.txtitulo, me.dtenviado, (SELECT SUBSTRING((SELECT ',' + Convert(varchar(19), dtabriu, 25) from mailing_abriu WHERE idenviado = me.idenviado ORDER BY dtabriu FOR XML PATH('')),2,999)) as aberto, (SELECT SUBSTRING((SELECT ',' + Convert(varchar(19), dtclicou, 25) from mailing_clicou WHERE idenviado = me.idenviado ORDER BY dtclicou FOR XML PATH('')),2,999)) as clicado from mailing_enviados me where me.idcampanha = @campanha and me.txpara = (select email from aluno where codigo = @aluno)");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("campanha", campanha);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_email.Add(new Aluno_Email(Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["dtenviado"]), Convert.ToString(reader["aberto"]), Convert.ToString(reader["clicado"])));
                }
                reader.Close();
                session.Close();

                return aluno_email;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosUsuarios(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select dtevento as data, idusuario, txtitulo, txtexto, fltipo, idevento, dttarefa, dtdeadline, dteventoini, dteventofim from timeline_eventos where idcurso = @turma order by dtevento");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 7, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["fltipo"]), Convert.ToInt32(reader["idevento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosInvestimentos(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select i.dtinicio as data, i.idusuario, i.txinvestimento, ('Valor: ' + cast(FORMAT(i.vlinvestimento, 'N') as varchar) + '<br>Tipo de investimento: ' + ip.txtipoperiodo + '<br>Forma de investimento: ' + iv.txtipoinvestimento) as txtexto, 'R' as fltipo, i.idinvestimento, '1900-01-01' as dttarefa, '1900-01-01' as dtdeadline, i.dtinicio as dteventoini, i.dtfim as dteventofim  from investimentos_turmas it inner join investimentos i on i.idinvestimento = it.idinvestimento inner join Investimentos_tipos iv on iv.idtipoinvestimento = i.idtipoinvestimento inner join investimentos_periodos ip on ip.idtipoperiodo = i.idtipoperiodo where it.idturma = @turma order by i.dtinicio");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 9, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txinvestimento"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["fltipo"]), Convert.ToInt32(reader["idinvestimento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosDestaques(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select dtinicio as data, idusuario, 'Turma em destaque' as titulo, (case year(dtfim) when 1900 then txdestaque else concat(txdestaque, '<br><br>Removido em: ', convert(varchar, dtfim, 103), '<br>Motivo: ', txremocao) end) as texto
                    from timeline_eventos_destaque where idcurso = @turma
                    order by data desc");
                //select * from (
                //    select dtinicio as data, idusuario, 'Turma em destaque' as titulo, txdestaque as texto
                //    from timeline_eventos_destaque where idcurso = @turma
                //    union all
                //    select dtfim as data, idusuario, 'Remoçao de turma em destaque' as titulo, txremocao as texto
                //    from timeline_eventos_destaque where idcurso = @turma and year(dtfim) != 1900
                //    ) as t order by t.data desc");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 8, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosVendas(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select dtevento as data, idusuario, txtitulo, txtexto, fltipo, idevento, dttarefa, dtdeadline, dteventoini, dteventofim from timeline_eventos where idcurso = @turma and fltipo = 'V' and ((dteventoini <= getdate() and dteventofim >= getdate()) or (dteventoini > getdate())) ORDER BY dteventoini");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 7, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["fltipo"]), Convert.ToInt32(reader["idevento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineEventos> EventosVendasDashboard(int turma)
        {
            try
            {
                List<TimelineEventos> eventos = new List<TimelineEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select * from (
	                select dtevento as data, idusuario, txtitulo, txtexto, fltipo, idevento, dttarefa, dtdeadline, dteventoini, dteventofim, 1 as ativo 
	                from timeline_eventos 
	                where idcurso = @turma and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date))) 
	                union all
	                select dtevento as data, idusuario, txtitulo, txtexto, fltipo, idevento, dttarefa, dtdeadline, dteventoini, dteventofim, 0 as ativo
	                from timeline_eventos 
	                where idcurso = @turma and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)
	                union all
	                select te.dtevento as data, te.idusuario, te.txtitulo, te.txtexto, te.fltipo, te.idevento, te.dttarefa, te.dtdeadline, te.dteventoini, te.dtdeadline as dteventofim, 1 as ativo
	                from timeline_eventos te
	                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
	                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date)
	                union all 
	                select te.dtevento as data, te.idusuario, te.txtitulo, te.txtexto, te.fltipo, te.idevento, te.dttarefa, te.dtdeadline, te.dteventoini, te.dtdeadline as dteventofim, 0 as ativo
	                from timeline_eventos te
	                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
	                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dtdeadline as date) <= cast(getdate() as date)
                ) as t order by t.ativo desc, t.dteventoini");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineEventos(Convert.ToDateTime(reader["data"]), 7, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["fltipo"]), Convert.ToInt32(reader["idevento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"]), Convert.ToInt32(reader["ativo"])));
                }
                reader.Close();
                session.Close();

                return eventos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineEventos Buscar(int idevento)
        {
            try
            {
                TimelineEventos evento = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT dtevento as data, idusuario, txtitulo, txtexto, fltipo, idevento, dttarefa, dtdeadline, dteventoini, dteventofim, flinvestimento, idtipoinvestimento, vlinvestimento FROM timeline_eventos WHERE idevento = @idevento");
                quey.SetParameter("idevento", idevento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    evento = new TimelineEventos(Convert.ToDateTime(reader["data"]), 0, Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["fltipo"]), Convert.ToInt32(reader["idevento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"]), Convert.ToInt32(reader["flinvestimento"]), Convert.ToDecimal(reader["vlinvestimento"]), Convert.ToInt32(reader["idtipoinvestimento"]));
                }
                reader.Close();
                session.Close();

                return evento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarNomeEvento(int idevento)
        {
            try
            {
                string evento = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT txtitulo FROM timeline_eventos WHERE idevento = @idevento");
                quey.SetParameter("idevento", idevento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    evento = Convert.ToString(reader["txtitulo"]);
                }
                reader.Close();
                session.Close();

                return evento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineTarefasUsuarioAcao> AcoesUsuarios(int idevento = 0, int iditem = 0)
        {
            try
            {
                List<TimelineTarefasUsuarioAcao> acoes = new List<TimelineTarefasUsuarioAcao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select u.txnome, u.txfoto, isnull(ua.dtacao,'1900-01-01') as dtacao, txobs from timeline_eventos_usuarios eu inner join timeline_usuarios u on u.idusuario = eu.idusuario inner join timeline_eventos_itens ei on ei.idevento = eu.idevento left join timeline_eventos_usuarios_acao ua on ua.iditem = ei.iditem and ua.idusuario = eu.idusuario where eu.idevento = @idevento and ei.iditem = @iditem order by u.txnome");
                quey.SetParameter("idevento", idevento);
                quey.SetParameter("iditem", iditem);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    acoes.Add(new TimelineTarefasUsuarioAcao(Convert.ToString(reader["txnome"]), Convert.ToString(reader["txfoto"]), Convert.ToDateTime(reader["dtacao"]), Convert.ToString(reader["txobs"])));
                }
                reader.Close();
                session.Close();

                return acoes;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineTarefasUsuarioAcao AcaoUsuario(int idevento = 0, int iditem = 0, int idusuario = 0)
        {
            try
            {
                TimelineTarefasUsuarioAcao acao = new TimelineTarefasUsuarioAcao();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select u.txnome, u.txfoto, isnull(ua.dtacao,'1900-01-01') as dtacao, txobs from timeline_eventos_usuarios eu inner join timeline_usuarios u on u.idusuario = eu.idusuario inner join timeline_eventos_itens ei on ei.idevento = eu.idevento left join timeline_eventos_usuarios_acao ua on ua.iditem = ei.iditem and ua.idusuario = eu.idusuario where eu.idevento = @idevento and ei.iditem = @iditem and ua.idusuario = @usuario order by u.txnome");
                quey.SetParameter("idevento", idevento);
                quey.SetParameter("iditem", iditem);
                quey.SetParameter("usuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    acao = new TimelineTarefasUsuarioAcao(Convert.ToString(reader["txnome"]), Convert.ToString(reader["txfoto"]), Convert.ToDateTime(reader["dtacao"]), Convert.ToString(reader["txobs"]));
                }
                reader.Close();
                session.Close();

                return acao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<HomeViewAlertasLista> ListaAlertas(int idusuario = 0)
        {
            try
            {
                List<HomeViewAlertasLista> alertas = new List<HomeViewAlertasLista>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    select * from (
	                    select isnull(ei.iditem,0) as iditem, e.idevento, e.txtitulo, e.dtdeadline as data, ei.txitem, c.titulo1 as curso, e.idusuario, 
		                    (select count(*) from timeline_eventos_visualizado where idevento = e.idevento and idusuario = eu.idusuario) as visualizado, 'T' as tipo
	                    from timeline_eventos_usuarios eu 
	                    inner join timeline_eventos e on e.idevento = eu.idevento 
	                    inner join curso c on c.codigo = e.idcurso 
	                    left join timeline_eventos_itens ei on ei.idevento = e.idevento 
	                    left join timeline_eventos_usuarios_acao eua on eua.iditem = ei.iditem and eua.idusuario = eu.idusuario 
	                    where eu.idusuario = @idusuario and e.fltipo = 'T' and cast(e.dttarefa as date) <= cast(getdate() as date) and cast(e.dtdeadline as date) >= cast(getdate() as date) and eua.dtacao is null 
	                    union all
	                    select isnull(ei.iditem,0) as iditem,  e.idevento, e.txtitulo, eua.dtacao as data, ei.txitem, c.titulo1 as curso, eua.idusuario, 0 as visualizado, 'A' as tipo
	                    from timeline_eventos_usuarios_acao eua
	                    inner join timeline_eventos_itens ei on ei.iditem = eua.iditem
	                    inner join timeline_eventos e on e.idevento = ei.idevento
	                    inner join curso c on c.codigo = e.idcurso 
	                    where eua.dtvisualizado is null and e.idusuario = @idusuario and e.fltipo = 'T'
                    ) as t
                    order by t.data, t.txitem");
                quey.SetParameter("idusuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    alertas.Add(new HomeViewAlertasLista(Convert.ToInt32(reader["iditem"]), Convert.ToString(reader["txtitulo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["txitem"]), Convert.ToString(reader["curso"]), Convert.ToInt32(reader["idevento"]), Convert.ToInt32(reader["idusuario"]), Convert.ToInt32(reader["visualizado"]), Convert.ToString(reader["tipo"])));
                }
                reader.Close();
                session.Close();

                return alertas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void GravaVisualizacaoAcao(int item)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE timeline_eventos_usuarios_acao SET dtvisualizado = getdate() WHERE iditem = @item");
                query.SetParameter("item", item);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
