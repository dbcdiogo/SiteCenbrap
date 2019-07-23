using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Qtds
    {
        public int qtd_visitas { get; set; }
        public int qtd_matriculas { get; set; }
    }

    public class UrlOrigemDB
    {
        public int Salvar(UrlOrigem variavel)
        {
            try
            {
                if (variavel.identificador == null)
                    variavel.identificador = "";

                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO UrlOrigem (url, parametros, urlEntrou, data, ip, _ga, identificador) output INSERTED.urlOrigem_id VALUES (@url, @parametros, @urlEntrou, @data, @ip, @_ga, @identificador) ");
                query.SetParameter("url", variavel.url)
                    .SetParameter("parametros", variavel.parametros)
                    .SetParameter("urlEntrou", variavel.urlEntrou)
                    .SetParameter("data", variavel.data)
                    .SetParameter("ip", variavel.ip)
                    .SetParameter("_ga", variavel._ga)
                    .SetParameter("identificador", variavel.identificador);
                id = query.ExecuteScalar();
                session.Close();
               
                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public UrlOrigem Buscar(int id)
        {
            try
            {
                UrlOrigem urlOrigem = null;
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM UrlOrigem WHERE urlOrigem_id = @urlOrigem_id");
                quey.SetParameter("urlOrigem_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    urlOrigem = new UrlOrigem(Convert.ToInt32(reader["urlOrigem_id"]), Convert.ToString(reader["url"]), Convert.ToString(reader["parametros"]), Convert.ToString(reader["urlEntrou"]), Convert.ToString(reader["ip"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["_ga"]), Convert.ToString(reader["identificador"]));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioPeriodo(DateTime inicio, DateTime fim, int curso = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                string qry = "";
                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();

                qry = "SELECT concat(a.nome, ' (', a.cpf, ')') as aluno, c.titulo1 as curso, t1.data, t1.origem, t1.identificador, ";
	            qry += "    isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, ";
                qry += "   isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, ";
                qry += "    isnull((select top 1 codigo from aluno_curso where aluno = a.codigo and curso = c.codigo),0) as aluno_curso,";
                qry += "    (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC)) as acoes, ";
                qry += "    isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status, ";
                qry += "    isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado, ";
                qry += "    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque ";
                qry += "FROM(";
                qry += "    SELECT cast(data as date) as data,";
                qry += "        isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, ";
                qry += "        (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem, ";
                qry += "       Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 'https://www.cenbrap.com.br/Inscreva/Completar/', '') as url ";
                qry += "    FROM urlOrigem AS u ";
                qry += "    WHERE u.data BETWEEN @inicio AND @fim ";
                qry += "       AND(u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%') ";
                qry += "    GROUP BY cast(data as date), u.identificador, u.url, u.ip, Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 'https://www.cenbrap.com.br/Inscreva/Completar/', '') ";
                qry += ") t1 ";
                qry += "INNER JOIN Curso c on (cast(c.codigo as varchar) = substring(t1.url, 0, charindex('/', t1.url)) or c.titulo1 = substring(t1.url, 0, charindex('/', t1.url)))";
                qry += "INNER JOIN Aluno a on a.codigo = substring(substring(t1.url, charindex('/', t1.url) + 1, 99), 0, case charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) when 0 then 99 else charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) end) ";
                qry += "WHERE a.codigo NOT IN((select idaluno from timeline_usuarios where flignorar = 1)) ";
                qry += "    AND((c.inicio_confirmado = 1) or(c.ativo = 1)) and c.titulo1 is not null ";
                if (curso > 0 )  
                {
                    qry += " AND c.codigo = @curso ";
                }
                qry += "order by data desc, boleto";

                //qry = "select * from( ";
                //qry += "select substring(aluno, charindex('.', aluno) +2, len(aluno)) as Aluno, curso, data, origem, identificador, ";
                //qry += "    isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, ";
                //qry += "    isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, ";
                //qry += "    (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, ";
                //qry += "    (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, ";
                //qry += "     isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status ";
                //qry += "FROM( ";
                //qry += "    SELECT distinct( ";
                //qry += "        SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') ";
                //qry += "        FROM aluno as a ";
                //qry += "       where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS(select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) ";
                //qry += "       AND a.codigo = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), CHARINDEX('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) + 1, 100)) AS aluno, ";
                //qry += "        ( ";
                //qry += "            SELECT c.titulo1 ";
                //qry += "                FROM curso as c ";
                //qry += "                where ";
                //if (curso > 0 )  
                //{
                //    qry += " c.codigo = @curso and ";
                //}
                //qry += "((c.inicio_confirmado = 0) or(c.ativo = 1)) and c.codigo = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1)) AS curso, ";
                //qry += "                    CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, ";
                //qry += "            (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u ";
                //qry += "            WHERE u.data BETWEEN @inicio AND @fim AND(u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%') ";
                //qry += "            GROUP BY u.data, u.urlEntrou, u.ip ";
                //qry += "        ) as t ";
                //qry += "    ) as t1 where t1.curso is not null and t1.Aluno is not null order by data desc, boleto";
                Query quey = session.CreateQuery(qry);
                //Query quey = session.CreateQuery("select * from (select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM (SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))+1, len(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where ((c.inicio_confirmado = 0) or (c.ativo = 1)) and c.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 1, charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))-1)) AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t) as t1 where t1.curso is not null and t1.Aluno is not null order by data desc, boleto");
                quey.SetParameter("link", link)
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if(Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        //urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["origem"]), Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"])));
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["origem"]), Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["inicio_confirmado"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"]), 0, Convert.ToInt32(reader["destaque"]), 0));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioPeriodoVendas(DateTime inicio, DateTime fim, int curso = 0, int idusuario = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {

                inicio = inicio.AddDays(-10);

                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    select * from(
                    select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, 
	                curso, 
	                data, 
	                 
	                identificador, 
	                isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, 
	                isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, 
	                (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, 
	                (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, 
	                isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status,
                    (select count(*) from aluno_curso_acoes aca left join aluno_curso_acoes_usuarios acau on acau.idacao = aca.idacao where aca.aluno_curso = (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) and cast(aca.dtretorno as date) > cast(getdate() as date) and acau.idusuario = @idusuario) as retorno 
                FROM(
                    SELECT distinct(
                        SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')')
                        FROM aluno as a
                        where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS(
                            select aluno_equipe.aluno
                            from aluno_equipe
                            where aluno_equipe.aluno = a.codigo
                        ) AND a.codigo = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', ''), CHARINDEX('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', '')) + 1,100)) AS aluno,
  		                (
			                SELECT c.titulo1  
                              FROM curso as c  
                              where((c.inicio_confirmado = 1) or(c.ativo = 1))  
                                  and c.codigo = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', '')) -1)) AS curso,
                                CAST(u.data AS DATE) AS data,
                                isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador
                        FROM urlOrigem AS u
                        WHERE u.data BETWEEN @inicio AND @fim AND (u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%')

                        GROUP BY u.data, u.urlEntrou, u.ip
	                ) as t
                ) as t1 where t1.data_confirmacao = '1900-01-01' and t1.status in (2, 3) and t1.curso is not null order by t1.boleto, t1.data desc");
                //Query quey = session.CreateQuery("select * from (select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM(SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))+1, len(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where c.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 1, charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))-1)) AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t) as t1 where t1.data_confirmacao = '1900-01-01' and t1.status <> 4 order by t1.boleto");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim)
                    .SetParameter("idusuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), "", Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"]), Convert.ToInt32(reader["retorno"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioPeriodoVendasNovo(DateTime inicio, DateTime fim, int curso = 0, int idusuario = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {

                inicio = inicio.AddDays(-10);

                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    SELECT t3.aluno, t3.curso, t3.identificador, t3.boleto, t3.data_confirmacao, isnull(t3.aluno_curso,0) as aluno_curso, t3.acoes, t3.status, t3.retorno, t3.inicio_confirmado, t3.destaque, max(t3.data) as data, count(t3.aluno) as cont
                    FROM (
	                    SELECT *
	                    FROM (
		                    SELECT concat(a.nome, ' (', a.cpf, ')') as aluno, c.titulo1 as curso, t1.data, t1.identificador,
			                    isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto,
			                    isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao,
			                    (select top 1 codigo from aluno_curso where aluno = a.codigo and curso = c.codigo) as aluno_curso,
			                    (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC)) as acoes, 
			                    isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status,
			                    (select count(*) from aluno_curso_acoes aca left join aluno_curso_acoes_usuarios acau on acau.idacao = aca.idacao where aca.aluno_curso = (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.titulo1 = c.titulo1 ORDER BY aluno_curso.codigo DESC) and cast(aca.dtretorno as date) > cast(getdate() as date) and acau.idusuario = @idusuario) as retorno,
			                    isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado,
			                    (select count(*) as total from timeline_eventos_destaque where idcurso = c.codigo and year(dtfim) = 1900) as destaque
		                    FROM (
			                    SELECT cast(data as date) as data, identificador,
				                    Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''),'https://www.cenbrap.com.br/Inscreva/Completar/','') as url
			                    FROM urlOrigem AS u
			                    WHERE u.data BETWEEN @inicio AND @fim
				                    AND (u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%')
			                    GROUP BY cast(data as date), identificador, Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''),'https://www.cenbrap.com.br/Inscreva/Completar/','')
		                    ) t1
		                    INNER JOIN Curso c on (cast(c.codigo as varchar) = substring(t1.url, 0, charindex('/', t1.url)) or c.titulo1 = substring(t1.url, 0, charindex('/', t1.url)))
		                    INNER JOIN Aluno a on a.codigo = substring(substring(t1.url, charindex('/', t1.url) + 1, 99), 0, case charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) when 0 then 99 else charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) end)
		                    WHERE a.codigo NOT IN ((select idaluno from timeline_usuarios where flignorar = 1))
			                    AND ((c.inicio_confirmado = 1) or (c.ativo = 1)) and c.titulo1 is not null
	                    ) t2	
	                    WHERE t2.data_confirmacao = '1900-01-01' and t2.status in (2, 3)
                    ) t3
                    where t3.aluno_curso > 0
                    GROUP BY t3.aluno, t3.curso, t3.identificador, t3.boleto, t3.data_confirmacao, t3.aluno_curso, t3.acoes, t3.status, t3.retorno, t3.inicio_confirmado, t3.destaque
                    order by t3.boleto, t3.data_confirmacao desc, max(t3.data) desc, t3.aluno");
                    quey.SetParameter("inicio", inicio)
                    .SetParameter("fim", fim)
                    .SetParameter("idusuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), "", Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["inicio_confirmado"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"]), Convert.ToInt32(reader["retorno"]), Convert.ToInt32(reader["destaque"]), Convert.ToInt32(reader["cont"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioPeriodoVendasAgendados(int idusuario = 0)
        {
            try
            {
                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    select concat(a.nome, ' (', a.cpf, ')') as aluno, c.titulo1 as curso, ac.adesao as data, '' as identificador, ac.email_impressao_boleto as boleto, ac.data_confirmacao, ac.codigo as aluno_curso,
	                    (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.codigo = c.codigo ORDER BY aluno_curso.codigo DESC)) as acoes,
	                    isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = a.codigo and curso1.codigo = c.codigo ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status,
	                    0 as retorno, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado
                    from aluno_curso_acoes aca
                    inner join aluno_curso ac on ac.codigo = aca.aluno_curso
                    inner join aluno a on a.codigo = ac.aluno
                    inner join curso c on c.codigo = ac.curso
                    inner join aluno_curso_acoes_usuarios acau on acau.idacao = aca.idacao
                    where cast(aca.dtretorno as date) = cast(getdate() as date)
	                    and (select count(*) from aluno_curso_acoes where aluno_curso = aca.aluno_curso and cast(dtacao as date) > cast(getdate() as date)) = 0
	                    and a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1)
	                    and acau.idusuario = @idusuario");
                //Query quey = session.CreateQuery("select * from (select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM(SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))+1, len(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where c.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 1, charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))-1)) AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t) as t1 where t1.data_confirmacao = '1900-01-01' and t1.status <> 4 order by t1.boleto");
                    quey.SetParameter("idusuario", idusuario);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), "", Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["inicio_confirmado"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"]), Convert.ToInt32(reader["retorno"]), 0, 0));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorioGroup> RelatorioPeriodoOrigem(DateTime inicio, DateTime fim, int curso, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {

                string qry = "";
                qry += "select origem, count(*) as qtd ";
                qry += "from( ";
                qry += "SELECT ";
                qry += "distinct(SELECT concat(a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS(select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), CHARINDEX('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) + 1,100)) AS aluno, ";
                qry += "(SELECT c.titulo1 FROM curso as c where ";
                qry += "((cast(c.codigo as varchar) = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1)))  ";
                qry += "or ";
                qry += "(cast(c.titulo1 as varchar) = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1)))  ";
                qry += "AS titulo_curso, CAST(u.data AS DATE) AS data, ";
                qry += "(SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem, ";
                qry += "(substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace(urlEntrou, 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1)) AS curso ";
                qry += "FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND(u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%') ";
                qry += "GROUP BY u.data, u.urlEntrou, u.ip ";
                qry += ") as t ";
                qry += "where t.aluno is not null ";
                if (curso > 0) { 
                    qry += "and (t.curso = '" + curso + "' or t.curso = (select titulo1 from curso where codigo = " + curso + "))";
                }
                qry += "group by origem ";
                qry += "ORDER BY qtd desc ";
                
                //qry += "select origem, count(*) as qtd ";
                //qry += "from( ";
                //qry += "    SELECT ";
                //qry += "      	distinct(SELECT concat(a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(replace(replace((substring(urlentrou,1,(case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end)-1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', ''), CHARINDEX('/', replace(replace(replace((substring(urlentrou,1,(case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end)-1)), 'https://www.cenbrap.com.br/Inscreva/',''), 'Contrato/',''), 'Completar/', '')) + 1,100)) AS aluno, ";
                //qry += "        (SELECT c.titulo1 FROM curso as c where  ";
                //qry += "        ((cast(c.codigo as varchar) = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1))) ";
                //qry += "        or ";
                //qry += "        (cast(c.titulo1 as varchar) = substring(replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace((substring(urlentrou, 1, (case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end) - 1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1))) ";
                //qry += "        AS titulo_curso, CAST(u.data AS DATE) AS data, ";
                //qry += "        (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem, ";
                //qry += "        (substring(replace(replace(replace((substring(urlentrou,1,(case charindex('?', urlentrou) when 0 then 9999 else charindex('?', urlentrou) end)-1)), 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', ''), 1, charindex('/', replace(replace(replace(urlEntrou, 'https://www.cenbrap.com.br/Inscreva/', ''), 'Contrato/', ''), 'Completar/', '')) - 1)) AS curso ";
                //qry += "    FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND(u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%') ";
                //qry += "    GROUP BY u.data, u.urlEntrou, u.ip ";
                //qry += ") as t ";
                //qry += "where t.aluno is not null ";
                //if (curso > 0 )
                //{
                //    qry += " and t.curso = '@curso' or t.curso = (select titulo1 from curso where codigo = @curso)  ";
                //}
                //qry += "group by origem ";
                //qry += "ORDER BY qtd desc ";

                List<UrlRelatorioGroup> urlOrigem = new List<UrlRelatorioGroup>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(qry);
                quey.SetParameter("link", link)
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    urlOrigem.Add(new UrlRelatorioGroup(Convert.ToString(reader["origem"]), Convert.ToInt32(reader["qtd"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }



        public List<UrlRelatorio> RelatorioPeriodoJornada(DateTime inicio, DateTime fim, int curso = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM(SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), 0, charindex('/', replace(u.urlEntrou, replace(@link, '%', ''), '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where c.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))+1, charindex('&', replace(u.urlEntrou, replace(@link, '%', ''), ''))-charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))-1)) AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t order by data desc, boleto");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["origem"]), Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioPeriodoJornadaVendas(DateTime inicio, DateTime fim, int curso = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from(select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso,(select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM(SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), 0, charindex('/', replace(u.urlEntrou, replace(@link, '%', ''), '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where c.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))+1, charindex('&', replace(u.urlEntrou, replace(@link, '%', ''), ''))-charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))-1)) AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t ) as t1 where t1.data_confirmacao = '1900-01-01' order by t1.boleto");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["origem"]), Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorioGroup> RelatorioPeriodoOrigemJornada(DateTime inicio, DateTime fim, int curso, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorioGroup> urlOrigem = new List<UrlRelatorioGroup>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select origem, count(*) as qtd from (SELECT distinct(SELECT concat(a.nome, ' (', a.cpf, ')') FROM aluno as a where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1) and NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND  a.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), 0, charindex('/', replace(u.urlEntrou, replace(@link, '%', ''), '')))) AS aluno, (SELECT c.titulo1 FROM curso as c where c.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))+1, charindex('&', replace(u.urlEntrou, replace(@link, '%', ''), ''))-charindex('=', replace(u.urlEntrou, replace(@link, '%', ''), ''))-1)) AS curso, CAST(u.data AS DATE) AS data, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t group by origem ORDER BY qtd desc");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    urlOrigem.Add(new UrlRelatorioGroup(Convert.ToString(reader["origem"]), Convert.ToInt32(reader["qtd"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }




        public List<UrlRelatorio> RelatorioPeriodoMedTV(DateTime inicio, DateTime fim, int curso = 0, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select substring(aluno, charindex('.', aluno)+2, len(aluno)) as Aluno, curso, data, origem, identificador, isnull((select top 1 aluno_curso.email_impressao_boleto from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC), '1900-01-01') as boleto, isnull((select top 1 aluno_curso.data_confirmacao from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso and aluno_curso.situacao = 2 ORDER BY aluno_curso.codigo DESC), '1900-01-01') as data_confirmacao, (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) as aluno_curso, (select count(*) from aluno_curso_acoes where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC)) as acoes, isnull((select top 1 status from aluno_curso_status where aluno_curso in (select top 1 aluno_curso.codigo from aluno_curso inner join curso as curso1 on aluno_curso.curso = curso1.codigo WHERE aluno_curso.aluno = substring(t.aluno, 0, charindex('.', t.aluno)) and curso1.titulo1 = t.curso ORDER BY aluno_curso.codigo DESC) order by dtstatus desc),2) as status FROM(SELECT distinct (SELECT concat(a.codigo, '. ', a.nome, ' (', a.cpf, ')') FROM aluno as a where NOT EXISTS (select aluno_equipe.aluno from aluno_equipe where aluno_equipe.aluno = a.codigo) AND a.codigo = substring(replace(u.urlEntrou, replace(@link, '%', ''), ''), 0, charindex('/', replace(u.urlEntrou, replace(@link, '%', ''), '')))) AS aluno, '' AS curso, CAST(u.data AS DATE) AS data, isnull((SELECT TOP 1 ur.identificador FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data), '') as identificador, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t order by data desc, boleto");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["aluno"]) != null && Convert.ToString(reader["aluno"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["aluno"]), Convert.ToString(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["origem"]), Convert.ToDateTime(reader["boleto"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToString(reader["identificador"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToInt32(reader["acoes"]), Convert.ToInt32(reader["status"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorioGroup> RelatorioPeriodoOrigemMedTV(DateTime inicio, DateTime fim, int curso, string link = "https://www.cenbrap.com.br/Inscreva/Contrato/")
        {
            try
            {
                if (curso == 0)
                    link += "%";
                else
                    link += curso + "/%";

                List<UrlRelatorioGroup> urlOrigem = new List<UrlRelatorioGroup>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select origem, count(*) as qtd from (SELECT '' AS aluno, '' AS curso, CAST(u.data AS DATE) AS data, (SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip ORDER BY ur.data) AS origem FROM urlOrigem AS u WHERE u.data BETWEEN @inicio AND @fim AND u.urlEntrou LIKE @link GROUP BY u.data, u.urlEntrou, u.ip) as t group by origem ORDER BY qtd desc");
                quey.SetParameter("link", link)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    urlOrigem.Add(new UrlRelatorioGroup(Convert.ToString(reader["origem"]), Convert.ToInt32(reader["qtd"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }




        public List<Curso> Cursos()
        {
            try
            {
                List<Curso> retorno = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT distinct c.codigo, c.titulo, c.titulo1 FROM urlOrigem AS u INNER JOIN curso as c ON c.codigo = substring(replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''), 1, charindex('/', replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''))-1) WHERE u.urlEntrou LIKE 'https://www.cenbrap.com.br/Inscreva/Contrato/%' GROUP BY c.codigo, c.titulo, c.titulo1 ORDER BY titulo1;");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"])));
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

        public Qtds Midia(string identificador, DateTime inicio, DateTime fim)
        {
            try
            {
                Qtds qtds = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select (select count(urlOrigem_id) from urlorigem where identificador = @identificador AND data between cast(@inicio as date) and dateadd(day, 1, cast(@fim as date)) and ip != '45.225.188.254') as qtd_visitas, (select count(*) FROM urlOrigem AS u WHERE u.data BETWEEN cast(@inicio as date) AND dateadd(day, 1, cast(@fim as date)) AND u.urlEntrou LIKE @link and exists ((SELECT TOP 1 ur.url FROM urlOrigem AS ur WHERE CAST(ur.data AS DATE) between dateadd(d, -1, CAST(u.data AS DATE)) and CAST(u.data AS DATE) AND ur.ip = u.ip and ur.identificador = @identificador and ip != '45.225.188.254' ORDER BY ur.data))) as qtd_matriculas");
                quey.SetParameter("identificador", identificador)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim)
                    .SetParameter("link", "https://www.cenbrap.com.br/Inscreva/Contrato/%");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    qtds = new Qtds();
                    qtds.qtd_visitas = Convert.ToInt32(reader["qtd_visitas"]);
                    qtds.qtd_matriculas = Convert.ToInt32(reader["qtd_matriculas"]);
                }
                reader.Close();
                session.Close();

                return qtds;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<UrlRelatorio> RelatorioEventos(int aluno_curso, DateTime inicio, DateTime fim)
        {
            try
            {
                List<UrlRelatorio> urlOrigem = new List<UrlRelatorio>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    SELECT t1.data, a.nome, c.titulo1
                    FROM (
	                    SELECT cast(data as date) as data, 
		                    Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''),'https://www.cenbrap.com.br/Inscreva/Completar/','') as url
	                    FROM urlOrigem AS u
	                    WHERE u.data BETWEEN @inicio AND @fim
		                    AND (u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Contrato/%' or u.urlEntrou LIKE '%https://www.cenbrap.com.br/Inscreva/Completar/%')
	                    GROUP BY cast(data as date), Replace(Replace(u.urlEntrou, 'https://www.cenbrap.com.br/Inscreva/Contrato/', ''),'https://www.cenbrap.com.br/Inscreva/Completar/','')
                    ) t1
                    INNER JOIN Curso c on c.codigo = substring(t1.url, 0, charindex('/', t1.url))
                    INNER JOIN Aluno a on a.codigo = substring(substring(t1.url, charindex('/', t1.url) + 1, 99), 0, case charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) when 0 then 99 else charindex('?', substring(t1.url, charindex('/', t1.url) + 1, 99)) end)
                    INNER JOIN aluno_curso ac on ac.aluno = a.codigo and ac.curso = c.codigo
                    WHERE a.codigo NOT IN ((select idaluno from timeline_usuarios where flignorar = 1))
	                    AND ((c.inicio_confirmado = 1) or (c.ativo = 1)) and c.titulo1 is not null and ac.codigo = @aluno_curso
                    order by t1.data desc");
                quey.SetParameter("aluno_curso", aluno_curso)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["nome"]) != null && Convert.ToString(reader["nome"]) != "")
                        urlOrigem.Add(new UrlRelatorio(Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();
                return urlOrigem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
