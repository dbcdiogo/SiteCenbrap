using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineAnaliseDB
    {        
        public List<TimelineAnalise> EventosUsuariosDia(int turma)
        {
            try
            {
                List<TimelineAnalise> eventos = new List<TimelineAnalise>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select d.data, sum(Inscricao) as 'Inscricao', sum(Boleto) as 'Boleto', sum(Cartao) as Cartao, sum(Matricula) as Matricula, sum(Desistencia) as 'Desistencia', sum(Contrato) as 'Contrato',
	                sum(AbertoInativo) as 'AbertoInativo', sum(AbertoReativado) as 'AbertoReativado', sum(MatriculaInativo) as 'MatriculaInativo', sum(MatriculaReativado) as 'MatriculaReativado',
	                sum(PreReserva) as 'PreReserva', sum(Inicio) as 'Inicio', sum(AberturaMatricula) as 'AberturaMatricula', sum(InicioConfirmado) as 'InicioConfirmado', sum(Espera) as 'Espera', 
	                sum(Adiamento) as 'Adiamento', Campanha, Evento, TipoEvento from (
	                SELECT s.data,
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 0 and cast(data as date) = cast(s.data as date)) as 'Inscricao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 1 and cast(data as date) = cast(s.data as date)) as 'Boleto',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 2 and cast(data as date) = cast(s.data as date)) as 'Cartao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 3 and cast(data as date) = cast(s.data as date)) as 'Matricula',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 4 and cast(data as date) = cast(s.data as date)) as 'Desistencia',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 5 and cast(data as date) = cast(s.data as date)) as 'Contrato',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 6 and cast(data as date) = cast(s.data as date)) as 'AbertoInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 7 and cast(data as date) = cast(s.data as date)) as 'AbertoReativado',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 8 and cast(data as date) = cast(s.data as date)) as 'MatriculaInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 9 and cast(data as date) = cast(s.data as date)) as 'MatriculaReativado',
		                    0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento
	                    FROM aluno_curso_log AS a LEFT JOIN
		                (
			                select distinct(cast(data as date)) as data from aluno_curso_log
				                where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1))
		                ) s ON  cast(a.data as date) = s.data
	                where a.aluno_curso in (select ac.codigo from aluno_curso ac where ac.curso = @turma and ac.aluno not in (select tu.idaluno from timeline_usuarios tu where tu.flignorar = 1))
                    group by s.data
	                union all
	                select data_abertura_pre_reserva as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 1 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso where codigo = @turma and data_abertura_pre_reserva is not null
	                union all
	                select ativo_data_abertura_matricula as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 1 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso where codigo = @turma and ativo_data_abertura_matricula is not null
	                union all
	                select data_inicio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 1 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso where codigo = @turma and data_inicio is not null
	                union all
	                select inicio_confirmado_data as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 1 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso where codigo = @turma and inicio_confirmado_data is not null
	                union all
	                select data_lista_espera as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 1 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso where codigo = @turma and data_lista_espera is not null
	                union all
		                select data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 1 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento', '' as TipoEvento from curso_adiamento where curso = @turma
	                union all
                        select mca.dtenvio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', m.idcampanha as 'Campanha', 0 as 'Evento', '' as TipoEvento
		                from mailing_campanhas_cursos m inner join mailing_campanhas_agendamento mca on mca.idcampanha = m.idcampanha 
		                where m.idcurso = @turma
	                union all
		                select u.data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
			                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', u.idevento as 'Evento', u.fltipo as TipoEvento 
		                from (
			                select * from (
                                select i.idinvestimento as idevento, i.txinvestimento as txtitulo, i.dtinicio as dteventoini, i.dtfim  as dteventofim, 'R' as fltipo
				                from investimentos_turmas it inner join investimentos i on i.idinvestimento = it.idinvestimento 
				                where it.idturma = @turma  
				                union all
				                select idevento, txtitulo, dteventoini, dteventofim, fltipo
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date))) 
				                union all
				                select idevento, txtitulo, dteventoini, dteventofim, fltipo
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)
				                union all
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim, te.fltipo
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date)
				                union all 
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim, te.fltipo
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dtdeadline as date) <= cast(getdate() as date)
			                ) as t
			                cross apply (
				                select top (datediff(dd, cast(dateadd(day, -1, t.dteventoini) as date), cast(t.dteventofim as date))) ROW_NUMBER() over(order by a.name) as SiNo, 
					                Dateadd(dd, ROW_NUMBER() over(order by a.name), cast(dateadd(day, -1, t.dteventoini) as date)) as data 
				                from sys.all_objects a
			                ) as dt
		                ) u
	                ) as d		
                GROUP BY d.data, d.Campanha, d.Evento, d.TipoEvento
                ORDER BY d.data, d.Campanha, d.Evento");
                //where it.idturma = @turma and((cast(i.dtinicio as date) <= cast(getdate() as date) and cast(i.dtfim as date) >= cast(getdate() as date)) or(cast(i.dtinicio as date) > cast(getdate() as date))) 
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineAnalise(Convert.ToString(reader["data"]), Convert.ToInt32(reader["Inscricao"]), Convert.ToInt32(reader["Boleto"]), Convert.ToInt32(reader["Cartao"]), Convert.ToInt32(reader["Matricula"]), Convert.ToInt32(reader["Desistencia"]), Convert.ToInt32(reader["Contrato"]), Convert.ToInt32(reader["AbertoInativo"]), Convert.ToInt32(reader["AbertoReativado"]), Convert.ToInt32(reader["MatriculaInativo"]), Convert.ToInt32(reader["MatriculaReativado"]), Convert.ToInt32(reader["PreReserva"]), Convert.ToInt32(reader["Inicio"]), Convert.ToInt32(reader["AberturaMatricula"]), Convert.ToInt32(reader["InicioConfirmado"]), Convert.ToInt32(reader["Espera"]), Convert.ToInt32(reader["Adiamento"]), Convert.ToInt32(reader["Campanha"]), Convert.ToInt32(reader["Evento"]), Convert.ToString(reader["TipoEvento"])));
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

        public List<TimelineAnalise> EventosUsuariosSemana(int turma)
        {
            try
            {
                List<TimelineAnalise> eventos = new List<TimelineAnalise>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select concat(year(d.data),'/',month(d.data),'/',(DATEPART(WEEK, d.data) - DATEPART(WEEK, DATEADD(MM, DATEDIFF(MM,0,d.data), 0))+ 1)) as data, sum(Inscricao) as 'Inscricao', sum(Boleto) as 'Boleto', sum(Cartao) as 'Cartao', sum(Matricula) as 'Matricula', sum(Desistencia) as 'Desistencia', sum(Contrato) as 'Contrato',
	                sum(AbertoInativo) as 'AbertoInativo', sum(AbertoReativado) as 'AbertoReativado', sum(MatriculaInativo) as 'MatriculaInativo', sum(MatriculaReativado) as 'MatriculaReativado',
	                sum(PreReserva) as 'PreReserva', sum(Inicio) as 'Inicio', sum(AberturaMatricula) as 'AberturaMatricula', sum(InicioConfirmado) as 'InicioConfirmado', sum(Espera) as 'Espera', 
	                sum(Adiamento) as 'Adiamento', sum(Campanha) as 'Campanha', sum(Evento) as 'Evento' from (
	                SELECT s.data,
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 0 and cast(data as date) = cast(s.data as date)) as 'Inscricao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 1 and cast(data as date) = cast(s.data as date)) as 'Boleto',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 2 and cast(data as date) = cast(s.data as date)) as 'Cartao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 3 and cast(data as date) = cast(s.data as date)) as 'Matricula',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 4 and cast(data as date) = cast(s.data as date)) as 'Desistencia',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 5 and cast(data as date) = cast(s.data as date)) as 'Contrato',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 6 and cast(data as date) = cast(s.data as date)) as 'AbertoInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 7 and cast(data as date) = cast(s.data as date)) as 'AbertoReativado',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 8 and cast(data as date) = cast(s.data as date)) as 'MatriculaInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 9 and cast(data as date) = cast(s.data as date)) as 'MatriculaReativado',
		                    0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento'
	                    FROM aluno_curso_log AS a LEFT JOIN
		                (
			                select distinct(cast(data as date)) as data from aluno_curso_log
				                where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1))
		                ) s ON  cast(a.data as date) = s.data
	                where a.aluno_curso in (select ac.codigo from aluno_curso ac where ac.curso = @turma and ac.aluno not in (select tu.idaluno from timeline_usuarios tu where tu.flignorar = 1))
                    group by s.data
	                union all
	                select data_abertura_pre_reserva as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 1 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_abertura_pre_reserva is not null
	                union all
	                select ativo_data_abertura_matricula as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 1 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and ativo_data_abertura_matricula is not null
	                union all
	                select data_inicio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 1 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_inicio is not null
	                union all
	                select inicio_confirmado_data as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 1 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and inicio_confirmado_data is not null
	                union all
	                select data_lista_espera as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 1 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_lista_espera is not null
	                union all
		                select data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 1 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso_adiamento where curso = @turma
	                union all
                        select mca.dtenvio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', m.idcampanha as 'Campanha', 0 as 'Evento'
		                from mailing_campanhas_cursos m inner join mailing_campanhas_agendamento mca on mca.idcampanha = m.idcampanha 
		                where m.idcurso = @turma
	                union all
		                select u.data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
			                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', u.idevento as 'Evento' 
		                from (
			                select * from (
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date))) 
				                union all
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)
				                union all
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date)
				                union all 
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dtdeadline as date) <= cast(getdate() as date)
			                ) as t
			                cross apply (
				                select top (datediff(dd, cast(dateadd(day, -1, t.dteventoini) as date), cast(t.dteventofim as date))) ROW_NUMBER() over(order by a.name) as SiNo, 
					                Dateadd(dd, ROW_NUMBER() over(order by a.name), cast(dateadd(day, -1, t.dteventoini) as date)) as data 
				                from sys.all_objects a
			                ) as dt
		                ) u
	                ) as d			
	                GROUP BY concat(year(d.data),'/',month(d.data),'/',(DATEPART(WEEK, d.data) - DATEPART(WEEK, DATEADD(MM, DATEDIFF(MM,0,d.data), 0))+ 1))
	                ORDER BY concat(year(d.data),'/',month(d.data),'/',(DATEPART(WEEK, d.data) - DATEPART(WEEK, DATEADD(MM, DATEDIFF(MM,0,d.data), 0))+ 1))");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineAnalise(Convert.ToString(reader["data"]), Convert.ToInt32(reader["Inscricao"]), Convert.ToInt32(reader["Boleto"]), Convert.ToInt32(reader["Cartao"]), Convert.ToInt32(reader["Matricula"]), Convert.ToInt32(reader["Desistencia"]), Convert.ToInt32(reader["Contrato"]), Convert.ToInt32(reader["AbertoInativo"]), Convert.ToInt32(reader["AbertoReativado"]), Convert.ToInt32(reader["MatriculaInativo"]), Convert.ToInt32(reader["MatriculaReativado"]), Convert.ToInt32(reader["PreReserva"]), Convert.ToInt32(reader["Inicio"]), Convert.ToInt32(reader["AberturaMatricula"]), Convert.ToInt32(reader["InicioConfirmado"]), Convert.ToInt32(reader["Espera"]), Convert.ToInt32(reader["Adiamento"]), Convert.ToInt32(reader["Campanha"]), Convert.ToInt32(reader["Evento"]), ""));
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

        public List<TimelineAnalise> EventosUsuariosMes(int turma)
        {
            try
            {
                List<TimelineAnalise> eventos = new List<TimelineAnalise>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select concat(year(d.data),'/',month(d.data)) as data, sum(Inscricao) as 'Inscricao', sum(Boleto) as 'Boleto', sum(Cartao) as 'Cartao', sum(Matricula) as 'Matricula', sum(Desistencia) as 'Desistencia', sum(Contrato) as 'Contrato',
	                sum(AbertoInativo) as 'AbertoInativo', sum(AbertoReativado) as 'AbertoReativado', sum(MatriculaInativo) as 'MatriculaInativo', sum(MatriculaReativado) as 'MatriculaReativado',
	                sum(PreReserva) as 'PreReserva', sum(Inicio) as 'Inicio', sum(AberturaMatricula) as 'AberturaMatricula', sum(InicioConfirmado) as 'InicioConfirmado', sum(Espera) as 'Espera', 
	                sum(Adiamento) as 'Adiamento', sum(Campanha) as 'Campanha', sum(Evento) as 'Evento' from (
	                SELECT s.data,
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 0 and cast(data as date) = cast(s.data as date)) as 'Inscricao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 1 and cast(data as date) = cast(s.data as date)) as 'Boleto',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 2 and cast(data as date) = cast(s.data as date)) as 'Cartao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 3 and cast(data as date) = cast(s.data as date)) as 'Matricula',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 4 and cast(data as date) = cast(s.data as date)) as 'Desistencia',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 5 and cast(data as date) = cast(s.data as date)) as 'Contrato',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 6 and cast(data as date) = cast(s.data as date)) as 'AbertoInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 7 and cast(data as date) = cast(s.data as date)) as 'AbertoReativado',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 8 and cast(data as date) = cast(s.data as date)) as 'MatriculaInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 9 and cast(data as date) = cast(s.data as date)) as 'MatriculaReativado',
		                    0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento'
	                    FROM aluno_curso_log AS a LEFT JOIN
		                (
			                select distinct(cast(data as date)) as data from aluno_curso_log
				                where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1))
		                ) s ON  cast(a.data as date) = s.data
	                where a.aluno_curso in (select ac.codigo from aluno_curso ac where ac.curso = @turma and ac.aluno not in (select tu.idaluno from timeline_usuarios tu where tu.flignorar = 1))
                    group by s.data
	                union all
	                select data_abertura_pre_reserva as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 1 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_abertura_pre_reserva is not null
	                union all
	                select ativo_data_abertura_matricula as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 1 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and ativo_data_abertura_matricula is not null
	                union all
	                select data_inicio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 1 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_inicio is not null
	                union all
	                select inicio_confirmado_data as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 1 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and inicio_confirmado_data is not null
	                union all
	                select data_lista_espera as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 1 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_lista_espera is not null
	                union all
		                select data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 1 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso_adiamento where curso = @turma
	                union all
                        select mca.dtenvio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', m.idcampanha as 'Campanha', 0 as 'Evento'
		                from mailing_campanhas_cursos m inner join mailing_campanhas_agendamento mca on mca.idcampanha = m.idcampanha 
		                where m.idcurso = @turma
	                union all
		                select u.data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
			                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', u.idevento as 'Evento' 
		                from (
			                select * from (
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date))) 
				                union all
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)
				                union all
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date)
				                union all 
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dtdeadline as date) <= cast(getdate() as date)
			                ) as t
			                cross apply (
				                select top (datediff(dd, cast(dateadd(day, -1, t.dteventoini) as date), cast(t.dteventofim as date))) ROW_NUMBER() over(order by a.name) as SiNo, 
					                Dateadd(dd, ROW_NUMBER() over(order by a.name), cast(dateadd(day, -1, t.dteventoini) as date)) as data 
				                from sys.all_objects a
			                ) as dt
		                ) u
	                ) as d			
	                GROUP BY concat(year(d.data),'/',month(d.data))
	                ORDER BY concat(year(d.data),'/',month(d.data))");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineAnalise(Convert.ToString(reader["data"]), Convert.ToInt32(reader["Inscricao"]), Convert.ToInt32(reader["Boleto"]), Convert.ToInt32(reader["Cartao"]), Convert.ToInt32(reader["Matricula"]), Convert.ToInt32(reader["Desistencia"]), Convert.ToInt32(reader["Contrato"]), Convert.ToInt32(reader["AbertoInativo"]), Convert.ToInt32(reader["AbertoReativado"]), Convert.ToInt32(reader["MatriculaInativo"]), Convert.ToInt32(reader["MatriculaReativado"]), Convert.ToInt32(reader["PreReserva"]), Convert.ToInt32(reader["Inicio"]), Convert.ToInt32(reader["AberturaMatricula"]), Convert.ToInt32(reader["InicioConfirmado"]), Convert.ToInt32(reader["Espera"]), Convert.ToInt32(reader["Adiamento"]), Convert.ToInt32(reader["Campanha"]), Convert.ToInt32(reader["Evento"]), ""));
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

        public List<TimelineAnalise> EventosUsuariosAno(int turma)
        {
            try
            {
                List<TimelineAnalise> eventos = new List<TimelineAnalise>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select year(d.data) as data, sum(Inscricao) as 'Inscricao', sum(Boleto) as 'Boleto', sum(Cartao) as 'Cartao', sum(Matricula) as 'Matricula', sum(Desistencia) as 'Desistencia', sum(Contrato) as 'Contrato',
	                sum(AbertoInativo) as 'AbertoInativo', sum(AbertoReativado) as 'AbertoReativado', sum(MatriculaInativo) as 'MatriculaInativo', sum(MatriculaReativado) as 'MatriculaReativado',
	                sum(PreReserva) as 'PreReserva', sum(Inicio) as 'Inicio', sum(AberturaMatricula) as 'AberturaMatricula', sum(InicioConfirmado) as 'InicioConfirmado', sum(Espera) as 'Espera', 
	                sum(Adiamento) as 'Adiamento', sum(Campanha) as 'Campanha', sum(Evento) as 'Evento' from (
	                SELECT s.data,
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 0 and cast(data as date) = cast(s.data as date)) as 'Inscricao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 1 and cast(data as date) = cast(s.data as date)) as 'Boleto',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 2 and cast(data as date) = cast(s.data as date)) as 'Cartao',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 3 and cast(data as date) = cast(s.data as date)) as 'Matricula',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 4 and cast(data as date) = cast(s.data as date)) as 'Desistencia',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 5 and cast(data as date) = cast(s.data as date)) as 'Contrato',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 6 and cast(data as date) = cast(s.data as date)) as 'AbertoInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 7 and cast(data as date) = cast(s.data as date)) as 'AbertoReativado',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 8 and cast(data as date) = cast(s.data as date)) as 'MatriculaInativo',
		                    (select count(*) as total from aluno_curso_log
			                    where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1)) and tipo = 9 and cast(data as date) = cast(s.data as date)) as 'MatriculaReativado',
		                    0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento'
	                    FROM aluno_curso_log AS a LEFT JOIN
		                (
			                select distinct(cast(data as date)) as data from aluno_curso_log
				                where aluno_curso in (select codigo from aluno_curso where curso = @turma and aluno not in (select idaluno from timeline_usuarios where flignorar = 1))
		                ) s ON  cast(a.data as date) = s.data
	                where a.aluno_curso in (select ac.codigo from aluno_curso ac where ac.curso = @turma and ac.aluno not in (select tu.idaluno from timeline_usuarios tu where tu.flignorar = 1))
                    group by s.data
	                union all
	                select data_abertura_pre_reserva as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 1 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_abertura_pre_reserva is not null
	                union all
	                select ativo_data_abertura_matricula as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 1 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and ativo_data_abertura_matricula is not null
	                union all
	                select data_inicio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 1 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_inicio is not null
	                union all
	                select inicio_confirmado_data as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 1 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and inicio_confirmado_data is not null
	                union all
	                select data_lista_espera as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 1 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso where codigo = @turma and data_lista_espera is not null
	                union all
		                select data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 1 as 'Adiamento', 0 as 'Campanha', 0 as 'Evento' from curso_adiamento where curso = @turma
	                union all
                        select mca.dtenvio as data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
		                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', m.idcampanha as 'Campanha', 0 as 'Evento'
		                from mailing_campanhas_cursos m inner join mailing_campanhas_agendamento mca on mca.idcampanha = m.idcampanha 
		                where m.idcurso = @turma
	                union all
		                select u.data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
			                0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', 0 as 'Campanha', u.idevento as 'Evento' 
		                from (
			                select * from (
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and ((cast(dteventoini as date) <= cast(getdate() as date) and cast(dteventofim as date) >= cast(getdate() as date)) or (cast(dteventoini as date) > cast(getdate() as date))) 
				                union all
				                select idevento, txtitulo, dteventoini, dteventofim
				                from timeline_eventos 
				                where idcurso = @turma and fltipo = 'V' and cast(dteventofim as date) < cast(getdate() as date)
				                union all
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dttarefa as date) <= cast(getdate() as date) and cast(te.dtdeadline as date) >= cast(getdate() as date)
				                union all 
				                select te.idevento, te.txtitulo, te.dteventoini, te.dtdeadline as dteventofim
				                from timeline_eventos te
				                inner join timeline_eventos_itens tei on tei.idevento = te.idevento
				                where te.idcurso = @turma and te.fltipo = 'T' and tei.fldashboard = 1	and cast(te.dtdeadline as date) <= cast(getdate() as date)
			                ) as t
			                cross apply (
				                select top (datediff(dd, cast(dateadd(day, -1, t.dteventoini) as date), cast(t.dteventofim as date))) ROW_NUMBER() over(order by a.name) as SiNo, 
					                Dateadd(dd, ROW_NUMBER() over(order by a.name), cast(dateadd(day, -1, t.dteventoini) as date)) as data 
				                from sys.all_objects a
			                ) as dt
		                ) u
	                ) as d			
	                GROUP BY year(d.data)
	                ORDER BY year(d.data)");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineAnalise(Convert.ToString(reader["data"]), Convert.ToInt32(reader["Inscricao"]), Convert.ToInt32(reader["Boleto"]), Convert.ToInt32(reader["Cartao"]), Convert.ToInt32(reader["Matricula"]), Convert.ToInt32(reader["Desistencia"]), Convert.ToInt32(reader["Contrato"]), Convert.ToInt32(reader["AbertoInativo"]), Convert.ToInt32(reader["AbertoReativado"]), Convert.ToInt32(reader["MatriculaInativo"]), Convert.ToInt32(reader["MatriculaReativado"]), Convert.ToInt32(reader["PreReserva"]), Convert.ToInt32(reader["Inicio"]), Convert.ToInt32(reader["AberturaMatricula"]), Convert.ToInt32(reader["InicioConfirmado"]), Convert.ToInt32(reader["Espera"]), Convert.ToInt32(reader["Adiamento"]), Convert.ToInt32(reader["Campanha"]), Convert.ToInt32(reader["Evento"]), ""));
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
    }
}

//select dt.data, 0 as 'Inscricao', 0 as 'Boleto', 0 as 'Cartao', 0 as 'Matricula', 0 as 'Desistencia', 0 as 'Contrato', 0 as 'AbertoInativo', 0 as 'AbertoReativado', 
//0 as 'MatriculaInativo', 0 as 'MatriculaReativado', 0 as 'PreReserva', 0 as 'Inicio', 0 as 'AberturaMatricula', 0 as 'InicioConfirmado', 0 as 'Espera', 0 as 'Adiamento', m.idcampanha as 'Campanha', 0 as 'Evento'
//from mailing_campanhas_cursos m 
//cross apply (
// select top (datediff(dd, (select cast(dateadd(day, -1, mca1.dtenvio) as date) from mailing_campanhas_cursos mcc1 inner join mailing_campanhas_agendamento mca1 on mca1.idcampanha = mcc1.idcampanha where mcc1.idcampanha = m.idcampanha and mcc1.idcurso = m.idcurso
//  ), (select cast(dateadd(day, 6, mca1.dtenvio) as date) from mailing_campanhas_cursos mcc1 inner join mailing_campanhas_agendamento mca1 on mca1.idcampanha = mcc1.idcampanha where mcc1.idcampanha = m.idcampanha and mcc1.idcurso = m.idcurso))) ROW_NUMBER() over(order by a.name) as SiNo, 
//  Dateadd(dd, ROW_NUMBER() over(order by a.name), (select cast(dateadd(day, -1, mca1.dtenvio) as date) from mailing_campanhas_cursos mcc1 inner join mailing_campanhas_agendamento mca1 on mca1.idcampanha = mcc1.idcampanha where mcc1.idcampanha = m.idcampanha and mcc1.idcurso = m.idcurso)) as data 
// from sys.all_objects a
//) as dt
//where m.idcurso = @turma
