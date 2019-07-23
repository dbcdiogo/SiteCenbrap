using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineUsuariosEventosDB
    {
        public List<TimelineUsuariosEventos> EventosVendas(DateTime data1, DateTime data2, int usuario)
        {
            try
            {
                List<TimelineUsuariosEventos> eventos = new List<TimelineUsuariosEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    select aca.dtacao as data, concat(c.titulo1, ' - ', c.titulo) as curso, a.nome as aluno, 0 as tipo, aca.tipo as tipo_evento, aca.txacao as titulo, '' as texto
                    from aluno_curso_acoes aca
                    inner join aluno_curso ac on ac.codigo = aca.aluno_curso
                    inner join curso c on c.codigo = ac.curso
                    inner join aluno a on a.codigo = ac.aluno
                    where aca.idusuario = @usuario and cast(aca.dtacao as date) between @data1 and @data2
                    order by aca.dtacao desc
                    ");
                quey.SetParameter("usuario", usuario);
                quey.SetParameter("data1", data1);
                quey.SetParameter("data2", data2);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineUsuariosEventos(Convert.ToDateTime(reader["data"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["aluno"]), Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["tipo_evento"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"])));
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

        public List<TimelineUsuariosEventos> EventosTurma(DateTime data1, DateTime data2, int usuario)
        {
            try
            {
                List<TimelineUsuariosEventos> eventos = new List<TimelineUsuariosEventos>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"
                    select te.dtevento as data, concat(c.titulo1, ' - ', c.titulo) as curso, '' as aluno, 1 as tipo, te.fltipo as tipo_evento, te.txtitulo as titulo, te.txtexto as texto, idevento, dttarefa, dtdeadline, dteventoini, dteventofim, idusuario
                    from timeline_eventos te
                    inner join curso c on c.codigo = te.idcurso
                    where te.idusuario = @usuario and cast(te.dtevento as date) between @data1 and @data2
                    order by te.dtevento desc
                    ");
                quey.SetParameter("usuario", usuario);
                quey.SetParameter("data1", data1);
                quey.SetParameter("data2", data2);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    eventos.Add(new TimelineUsuariosEventos(Convert.ToDateTime(reader["data"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["aluno"]), Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["tipo_evento"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["idevento"]), Convert.ToDateTime(reader["dttarefa"]), Convert.ToDateTime(reader["dtdeadline"]), Convert.ToDateTime(reader["dteventoini"]), Convert.ToDateTime(reader["dteventofim"]), Convert.ToInt32(reader["idusuario"])));
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
