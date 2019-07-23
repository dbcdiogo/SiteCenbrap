using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_curso_logDB
    {
        public void Salvar(Aluno_curso_log variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_curso_log (Aluno_curso, data, tipo, texto) VALUES (@Aluno_curso, @data, @tipo, @texto) ");
                query.SetParameter("aluno_curso", variavel.aluno_curso.codigo)
                .SetParameter("data", variavel.data)
                .SetParameter("tipo", variavel.tipo)
                .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso_log> Listar(int curso)
        {
            try
            {
                List<Aluno_curso_log> abriu = new List<Aluno_curso_log>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select acl.aluno_curso_log_id, acl.data as data, acl.tipo as tipo, acl.texto as texto, ac.codigo as aluno_curso, ac.situacao as situacao, a.codigo as aluno, a.nome as nome, c.codigo as curso, c.titulo as titulo, c.titulo1 as titulo1 from aluno_curso_log as acl inner join aluno_curso as ac on acl.aluno_curso = ac.codigo inner join aluno as a on ac.aluno = a.codigo inner join curso as c on ac.curso = c.codigo where ac.curso = @curso ORDER BY data");
                query.SetParameter("@curso", curso);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    abriu.Add(new Aluno_curso_log() {
                        Aluno_curso_log_id = Convert.ToInt32(reader["aluno_curso_log_id"]),
                        data = Convert.ToDateTime(reader["dtabriu"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        texto = Convert.ToString(reader["texto"]),
                        aluno_curso = new Aluno_curso()
                        {
                            codigo = Convert.ToInt32(reader["aluno_curso"]),
                            situacao = Convert.ToInt32(reader["situacao"]),
                            aluno = new Aluno()
                            {
                                codigo = Convert.ToInt32(reader["aluno"]),
                                nome = Convert.ToString(reader["nome"])
                            },
                            curso = new Curso()
                            {
                                codigo = Convert.ToInt32(reader["curso"]),
                                titulo = Convert.ToString(reader["titulo"]),
                                titulo1 = Convert.ToString(reader["titulo1"])
                            }
                        }
                    });
                }
                reader.Close();
                session.Close();

                return abriu;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
