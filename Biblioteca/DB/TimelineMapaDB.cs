using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineMapaDB
    {

        public List<TimelineMapa> Listar(int turma)
        {
            try
            {
                List<TimelineMapa> alunos = new List<TimelineMapa>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select tipo, a.nome, a.cep, a.cidade, a.estado, isnull(e.latitude,0) as latitude, isnull(e.longitude,0) as longitude
                from aluno_curso ac
                inner join aluno a on a.codigo = ac.aluno
                left join enderecos e on Replace(Replace(e.cep,' ',''),'-','') = Replace(a.cep,'-','')
                CROSS APPLY(select top 1(
                    select case tipo
                        when 1 then 0 
                        when 2 then 3
                        when 8 then 6 
                        when 7 then 0
                        when 9 then 3
                    else tipo end) as tipo from aluno_curso_log acl WHERE acl.aluno_curso = ac.codigo
                    and((acl.tipo <> 1) or(acl.tipo = 1 and(select max(a.tipo) from aluno_curso_log a where a.aluno_curso = acl.aluno_curso and a.data < acl.data) not in (3, 4, 5, 9))) order by data desc) AS L
                WHERE ac.curso = @turma and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1)
                order by a.estado, a.cidade, a.nome");
                quey.SetParameter("turma", turma);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    alunos.Add(new TimelineMapa(Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["latitude"]), Convert.ToString(reader["longitude"])));
                }
                reader.Close();
                session.Close();

                return alunos;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineMapa BuscarLocalizacao(string cidade, string estado)
        {
            try
            {
                TimelineMapa mapa = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top 1 isnull(latitude,0) as latitude, isnull(longitude,0) as longitude from enderecos where upper(cidade) = @cidade and upper(uf) = @estado");
                quey.SetParameter("cidade", cidade.ToUpper());
                quey.SetParameter("estado", estado.ToUpper());
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    mapa = new TimelineMapa()
                    {
                        latitude = Convert.ToString(reader["latitude"]),
                        longitude = Convert.ToString(reader["longitude"]),
                    };
                }
                reader.Close();
                session.Close();

                return mapa;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
