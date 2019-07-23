using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TvCenbrapDB
    {
        public List<TvCenbrap> Listar()
        {
            try
            {
                List<TvCenbrap> lista = new List<TvCenbrap>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery(@"select acl.data, acl.tipo, a.nome, c.titulo1, isnull(e.latitude,0) as latitude, isnull(e.longitude,0) as longitude, a.cidade, a.estado,
                                                    (SELECT count(*) FROM aluno_curso ac WHERE ac.curso = c.codigo AND(ac.situacao = '2' OR ac.situacao = '1' OR(ac.situacao = '0' AND ac.email_impressao_boleto > getdate())) and ac.aluno not in (38, 317, 8099, 2797, 13115, 12772)) as turma, c.total_alunos
                                                    from aluno_curso_log acl
                                                    inner
                                                    join aluno_curso ac on ac.codigo = acl.aluno_curso
                                                    inner
                                                    join aluno a on a.codigo = ac.aluno
                                                    inner
                                                    join curso c on c.codigo = ac.curso
                                                    left
                                                    join enderecos e on e.cep = a.cep
                                                    where acl.data >= DATEADD(second, -30, GETDATE()) and a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1)");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    lista.Add(new TvCenbrap(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["latitude"]), Convert.ToString(reader["longitude"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToInt32(reader["turma"]), Convert.ToInt32(reader["total_alunos"])));
                }
                reader.Close();
                session.Close();

                return lista;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        
    }
}
