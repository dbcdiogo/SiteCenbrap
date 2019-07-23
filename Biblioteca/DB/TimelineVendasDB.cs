using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineVendasDB
    {
        

        public List<TimelineVendas> Listar(DateTime inicio, DateTime fim)
        {
            try
            {
                List<TimelineVendas> vendas = new List<TimelineVendas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select acc.idusuario, tu.txnome, cast(acc.dtacao as date) as data,
	                (select count(distinct(aluno_curso)) from aluno_curso_acoes where idusuario = acc.idusuario and cast(dtacao as date) = cast(acc.dtacao as date)) as alunos,
	                (select count(distinct(aluno_curso)) from aluno_curso_acoes where idusuario = acc.idusuario and cast(dtacao as date) = cast(acc.dtacao as date) and tipo = 'Whatsapp') as whatsapp,
	                (select count(distinct(aluno_curso)) from aluno_curso_acoes where idusuario = acc.idusuario and cast(dtacao as date) = cast(acc.dtacao as date) and tipo = 'Telefone') as telefone, 
	                (select count(distinct(aluno_curso)) from aluno_curso_acoes where idusuario = acc.idusuario and cast(dtacao as date) = cast(acc.dtacao as date) and tipo = 'E-mail') as email,
	                (select count(distinct(aluno_curso)) from aluno_curso_acoes where idusuario = acc.idusuario and cast(dtacao as date) = cast(acc.dtacao as date) and tipo = 'Observação') as observacao,
	                (select count(distinct(aluno_curso)) from aluno_curso_status where idusuario = acc.idusuario and cast(dtstatus as date) = cast(acc.dtacao as date) and status = 3) as boleto,
	                (select count(distinct(aluno_curso)) from aluno_curso_status where idusuario = acc.idusuario and cast(dtstatus as date) = cast(acc.dtacao as date) and status = 4) as inativo,
	                (select count(distinct(aluno_curso)) from aluno_curso_status where idusuario = acc.idusuario and cast(dtstatus as date) = cast(acc.dtacao as date) and status = 1) as contato
                from aluno_curso_acoes acc 
                inner join timeline_usuarios tu on tu.idusuario = acc.idusuario
                where cast(acc.dtacao as date) between @inicio and @fim
                group by acc.idusuario, tu.txnome, cast(acc.dtacao as date)
                order by tu.txnome, cast(acc.dtacao as date)");
                quey.SetParameter("inicio", inicio);
                quey.SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    vendas.Add(new TimelineVendas(Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["alunos"]), Convert.ToInt32(reader["whatsapp"]), Convert.ToInt32(reader["telefone"]), Convert.ToInt32(reader["email"]), Convert.ToInt32(reader["observacao"]), Convert.ToInt32(reader["boleto"]), Convert.ToInt32(reader["inativo"]), Convert.ToInt32(reader["contato"])));
                }
                reader.Close();
                session.Close();

                return vendas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TimelineVendasBoleto> ListarBoletos(DateTime inicio, DateTime fim)
        {
            try
            {
                List<TimelineVendasBoleto> vendas = new List<TimelineVendasBoleto>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT a.nome, c.titulo1,
	                STUFF 
	                ( 
		                (
			                SELECT ', ' + cast(cast(acs.dtstatus as date) as varchar) 
			                FROM aluno_curso_status acs 
			                WHERE cast(acs.dtstatus as date) between @inicio and @fim and acs.status = 3 and acs.aluno_curso = acs1.aluno_curso order by acs.dtstatus FOR XML PATH ('') 
		                ), 1, 2, ''
	                ) AS Datas
                from aluno_curso_status acs1 
                inner join aluno_curso ac on ac.codigo = acs1.aluno_curso
                inner join aluno a on a.codigo = ac.aluno
                inner join curso c on c.codigo = ac.curso
                where cast(acs1.dtstatus as date) between @inicio and @fim and acs1.status = 3
                GROUP BY acs1.aluno_curso, a.nome, c.titulo1
                ORDER BY Datas");
                quey.SetParameter("inicio", inicio);
                quey.SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    vendas.Add(new TimelineVendasBoleto(Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["Datas"])));
                }
                reader.Close();
                session.Close();

                return vendas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
