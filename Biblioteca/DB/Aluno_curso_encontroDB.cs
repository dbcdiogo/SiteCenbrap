using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Aluno_curso_encontroDB
    {
        public void Salvar(Aluno_curso_encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_curso_encontro (data,hora,painel,aluno,curso,aluno_curso,modulo,encontro,frequencia,nota,disciplina,visualizar,reposicao) VALUES (@data,@hora,@painel,@aluno,@curso,@aluno_curso,@modulo,@encontro,@frequencia,@nota,@disciplina,@visualizar,@reposicao) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("hora", variavel.hora)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno_curso", variavel.aluno_curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("encontro", variavel.encontro)
                    .SetParameter("frequencia", variavel.frequencia)
                    .SetParameter("nota", variavel.nota)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("visualizar", variavel.visualizar)
                    .SetParameter("reposicao", variavel.reposicao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno_curso_encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_curso_encontro SET data = @data, hora = @hora, painel = @painel, aluno = @aluno, curso = @curso, aluno_curso = @aluno_curso, modulo = @modulo, encontro = @encontro, frequencia = @frequencia, nota = @nota, disciplina = @disciplina, visualizar = @visualizar, reposicao = @reposicao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("hora", variavel.hora)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno_curso", variavel.aluno_curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("encontro", variavel.encontro)
                    .SetParameter("frequencia", variavel.frequencia)
                    .SetParameter("nota", variavel.nota)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("visualizar", variavel.visualizar)
                    .SetParameter("reposicao", variavel.reposicao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Aluno_curso_encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Aluno_curso_encontro WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Aluno_curso_encontro Buscar(int codigo)
        {
            try
            {
                Aluno_curso_encontro aluno_curso_encontro = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo,isnull(data, '1900-01-01') AS data,isnull(hora, '1900-01-01') AS hora,isnull(painel,  0) AS painel,isnull(aluno,  0) AS aluno,isnull(curso,  0) AS curso,isnull(aluno_curso,  0) AS aluno_curso,isnull(modulo, 0) AS modulo,isnull(encontro, 0) AS encontro,isnull(frequencia, 0) AS frequencia,isnull(nota, 0) AS nota,isnull(disciplina, 0) AS disciplina,isnull(visualizar, 0) AS visualizar,isnull(reposicao, 0) AS reposicao FROM Aluno_curso_encontro WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso_encontro = new Aluno_curso_encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["frequencia"]), Convert.ToDouble(reader["nota"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["visualizar"]), Convert.ToBoolean(reader["reposicao"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso_encontro> Listar()
        {
            try
            {
                List<Aluno_curso_encontro> aluno_curso_encontro = new List<Aluno_curso_encontro>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo,isnull(data, '1900-01-01') AS data,isnull(hora, '1900-01-01') AS hora,isnull(painel,  0) AS painel,isnull(aluno,  0) AS aluno,isnull(curso,  0) AS curso,isnull(aluno_curso,  0) AS aluno_curso,isnull(modulo, 0) AS modulo,isnull(encontro, 0) AS encontro,isnull(frequencia, 0) AS frequencia,isnull(nota, 0) AS nota,isnull(disciplina, 0) AS disciplina,isnull(visualizar, 0) AS visualizar,isnull(reposicao, 0) as reposicao FROM Aluno_curso_encontro");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso_encontro.Add(new Aluno_curso_encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["frequencia"]), Convert.ToDouble(reader["nota"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["visualizar"]), Convert.ToBoolean(reader["reposicao"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso_encontro> Listar(Curso curso, Encontro encontro)
        {
            try
            {
                List<Aluno_curso_encontro> aluno_curso_encontro = new List<Aluno_curso_encontro>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo,isnull(data, '1900-01-01') AS data,isnull(hora, '1900-01-01') AS hora,isnull(painel,  0) AS painel,isnull(aluno,  0) AS aluno,isnull(curso,  0) AS curso,isnull(aluno_curso,  0) AS aluno_curso,isnull(modulo, 0) AS modulo,isnull(encontro, 0) AS encontro,isnull(frequencia, 0) AS frequencia,isnull(nota, 0) AS nota,isnull(disciplina, 0) AS disciplina,isnull(visualizar, 0) AS visualizar, isnull(reposicao, 0) as reposicao FROM Aluno_curso_encontro WHERE curso = @curso AND encontro = @encontro");
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("encontro", encontro.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso_encontro.Add(new Aluno_curso_encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["frequencia"]), Convert.ToDouble(reader["nota"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["visualizar"]), Convert.ToBoolean(reader["reposicao"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso_encontro Buscar(Aluno aluno, Curso curso, Encontro encontro)
        {
            try
            {
                Aluno_curso_encontro aluno_curso_encontro = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(aluno_curso_encontro.codigo, 0) AS codigo, isnull(aluno_curso_encontro.data, '1900-01-01') AS data, isnull(aluno_curso_encontro.hora, '1900-01-01 00:00:00') AS hora, isnull(aluno_curso_encontro.painel,  0) AS painel, isnull(aluno_curso_encontro.aluno,  0) AS aluno, isnull(aluno_curso_encontro.curso,  0) AS curso, isnull(aluno_curso_encontro.aluno_curso,  0) AS aluno_curso, isnull(aluno_curso_encontro.modulo, 0) AS modulo, isnull(aluno_curso_encontro.encontro, 0) AS encontro, isnull(aluno_curso_encontro.frequencia, 0) AS frequencia, isnull(aluno_curso_encontro.nota, 0) AS nota, isnull(aluno_curso_encontro.disciplina, 0) AS disciplina, isnull(aluno_curso_encontro.visualizar, 0) AS visualizar, isnull(aluno_curso_encontro.reposicao, 0) AS reposicao FROM Aluno_curso_encontro JOIN encontro ON aluno_curso_encontro.disciplina = encontro.disciplina AND aluno_curso_encontro.curso = encontro.curso WHERE aluno_curso_encontro.aluno = @aluno AND aluno_curso_encontro.curso = @curso AND encontro.codigo = @encontro");
                quey.SetParameter("aluno", aluno.codigo)
                    .SetParameter("curso", curso.codigo)
                    .SetParameter("encontro", encontro.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    string hora = "01/01/1900 " + Convert.ToString(reader["hora"]);
                    aluno_curso_encontro = new Aluno_curso_encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(hora), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["frequencia"]), Convert.ToDouble(reader["nota"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["visualizar"]), Convert.ToBoolean(reader["reposicao"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> Pendencias(int aluno, int curso)
        {
            try
            {
                List<string> aluno_curso_encontro = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select concat(day(data_encontro), '/', month(data_encontro), '/', year(data_encontro), ' - ', disciplina.titulo, ' => N: ', nota, ' F: ', frequencia) as titulo from aluno_curso_encontro JOIN disciplina ON aluno_curso_encontro.disciplina = disciplina.codigo JOIN encontro ON encontro.disciplina = disciplina.codigo where aluno_curso_encontro.aluno = @aluno and aluno_curso_encontro.curso = @curso and (aluno_curso_encontro.frequencia < 75 OR aluno_curso_encontro.nota < 7) and encontro.ativo = 1 ORDER BY encontro.data_encontro");
                quey.SetParameter("curso", curso)
                    .SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                int cont = 0;
                while (reader.Read())
                {
                    cont++;
                    aluno_curso_encontro.Add(cont + ". " + Convert.ToString(reader["titulo"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasDisciplinas> Pendencias(Curso curso, Aluno aluno)
        {
            try
            {
                List<PendenciasDisciplinas> aluno_curso_encontro = new List<PendenciasDisciplinas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select d.codigo as disciplina_codigo, d.titulo as disciplina_titulo, a.nota, a.frequencia from aluno_curso_encontro as a inner join disciplina as d on a.disciplina = d.codigo where a.curso = @curso and a.aluno = @aluno and (a.nota < 7 or a.frequencia < 75)");
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso_encontro.Add(new PendenciasDisciplinas(Convert.ToInt32(reader["disciplina_codigo"]), Convert.ToString(reader["disciplina_titulo"]), Convert.ToDouble(reader["nota"]), Convert.ToDouble(reader["frequencia"]), aluno.codigo, curso.codigo));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasDisciplinasEncontros> PendenciasDisciplinas(int disciplina, int aluno, int curso)
        {
            try
            {
                List<PendenciasDisciplinasEncontros> aluno_curso_encontro = new List<PendenciasDisciplinasEncontros>();

                DBSession session = new DBSession();

                Query quey = session.CreateQuery(@"SELECT professor.nome, cl.nome as local, d1.curso AS curso, curso.titulo AS curso_titulo, curso.qtd_reposicao AS qtd_reposicao, 
                    (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') as qtd_utilizadas, 
	                encontro.data_encontro as data_encontro, encontro.data_encontro1 as data_encontro1, encontro.codigo AS encontro, encontro.ativo, 
	                (select concat(r.codigo, '#', r.confirmada, '#', r.cancelada, '#', r.arquivo_mapa, '#', r.arquivo_material) from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) as reposicao
                 FROM disciplina as d
                 inner join disciplina as d1 ON d.titulo1 = d1.titulo1 OR d1.titulo1 = (SELECT top 1 disc.titulo1 FROM disciplina_professor AS disc WHERE disc.codigo = d.disciplina_professor) 
                 inner join encontro ON encontro.disciplina = d1.codigo
                 inner join curso ON d1.curso = curso.codigo
                 left join professor on professor.codigo = d1.professor
                 left join cidade_local cl on cl.cidade = curso.cidade_codigo
                 WHERE d.codigo = @disciplina AND encontro.data_encontro > getdate() AND encontro.ativo = 1
                 group by professor.nome, cl.nome, encontro.local, d1.curso, curso.titulo, curso.qtd_reposicao, encontro.data_encontro, encontro.data_encontro1, encontro.codigo, encontro.ativo, d.codigo, curso.codigo
                 having curso.qtd_reposicao >= (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') 
                 ORDER BY data_encontro");

                //Query quey = session.CreateQuery("SELECT professor.nome, encontro.local, d1.curso AS curso, curso.titulo AS curso_titulo, curso.qtd_reposicao AS qtd_reposicao, (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') as qtd_utilizadas, encontro.data_encontro as data_encontro, encontro.data_encontro1 as data_encontro1, encontro.codigo AS encontro, encontro.ativo, (select concat(r.codigo, '#', r.confirmada, '#', r.cancelada, '#', r.arquivo_mapa, '#', r.arquivo_material) from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) as reposicao FROM disciplina as d inner join disciplina as d1 ON d.titulo1 = d1.titulo1 OR d1.titulo1 = (SELECT top 1 disc.titulo1 FROM disciplina_professor AS disc WHERE disc.codigo = d.disciplina_professor) inner join encontro ON encontro.disciplina = d1.codigo inner join curso ON d1.curso = curso.codigo left join professor on professor.codigo = d1.professor WHERE d.codigo = @disciplina AND encontro.data_encontro > getdate() AND encontro.ativo = 1 group by professor.nome, encontro.local, d1.curso, curso.titulo, curso.qtd_reposicao, encontro.data_encontro, encontro.data_encontro1, encontro.codigo, encontro.ativo, d.codigo, curso.codigo having curso.qtd_reposicao >= (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') ORDER BY data_encontro");
                //Query quey = session.CreateQuery("SELECT d1.curso AS curso, curso.titulo AS curso_titulo, curso.qtd_reposicao AS qtd_reposicao, (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') as qtd_utilizadas, encontro.data_encontro as data_encontro, encontro.data_encontro1 as data_encontro1, encontro.codigo AS encontro, encontro.ativo, (select concat(r.codigo, '#', r.confirmada, '#', r.cancelada, '#', r.arquivo_mapa, '#', r.arquivo_material) from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) as reposicao FROM disciplina as d inner join disciplina as d1 ON d.titulo1 = d1.titulo1 OR d1.titulo1 = (SELECT top 1 disc.titulo1 FROM disciplina_professor AS disc WHERE disc.codigo = d.disciplina_professor) inner join encontro ON encontro.disciplina = d1.codigo inner join curso ON d1.curso = curso.codigo WHERE d.codigo = @disciplina AND encontro.data_encontro > getdate() AND encontro.ativo = 1 group by d1.curso, curso.titulo, curso.qtd_reposicao, encontro.data_encontro, encontro.data_encontro1, encontro.codigo, encontro.ativo, d.codigo, curso.codigo having curso.qtd_reposicao >= (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0' and reposicao.curso = @curso) ORDER BY data_encontro");
                quey.SetParameter("disciplina", disciplina)
                    .SetParameter("aluno", aluno)
                    .SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso_encontro.Add(new PendenciasDisciplinasEncontros(disciplina, Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["curso"]), Convert.ToString(reader["curso_titulo"]), Convert.ToInt32(reader["qtd_reposicao"]), Convert.ToInt32(reader["qtd_utilizadas"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["reposicao"]), Convert.ToString(reader["local"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasDisciplinasEncontros> PendenciasDisciplinasTodas(int disciplina, int aluno, int curso)
        {
            try
            {
                List<PendenciasDisciplinasEncontros> aluno_curso_encontro = new List<PendenciasDisciplinasEncontros>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT professor.nome, cl.nome as local, d1.curso AS curso, curso.titulo AS curso_titulo, curso.qtd_reposicao AS qtd_reposicao, 
                    (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') as qtd_utilizadas, 
	                encontro.data_encontro as data_encontro, encontro.data_encontro1 as data_encontro1, encontro.codigo AS encontro, encontro.ativo, 
	                (select concat(r.codigo, '#', r.confirmada, '#', r.cancelada, '#', r.arquivo_mapa, '#', r.arquivo_material) from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) as reposicao
                FROM disciplina as d
                inner join disciplina as d1 ON d.titulo1 = d1.titulo1 OR d1.titulo1 = (SELECT top 1 disc.titulo1 FROM disciplina_professor AS disc WHERE disc.codigo = d.disciplina_professor) 
                inner join encontro ON encontro.disciplina = d1.codigo
                inner join curso ON d1.curso = curso.codigo
                left join professor on professor.codigo = d1.professor
                left join cidade_local cl on cl.cidade = curso.cidade_codigo
                WHERE d.codigo = @disciplina AND encontro.data_encontro > getdate() AND encontro.ativo = 1 and (curso.qtd_reposicao > 0 or (select count(*) from reposicao where aluno = @aluno and curso = @curso and disciplina = @disciplina) > 0)
                group by professor.nome, cl.nome, encontro.local, d1.curso, curso.titulo, curso.qtd_reposicao, encontro.data_encontro, encontro.data_encontro1, encontro.codigo, encontro.ativo, d.codigo, curso.codigo
                having(curso.qtd_reposicao >= (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0' and reposicao.curso = @curso)) or((select r.codigo from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) is not null) 
                ORDER BY data_encontro");
                //Query quey = session.CreateQuery("SELECT professor.nome, encontro.local, d1.curso AS curso, curso.titulo AS curso_titulo, curso.qtd_reposicao AS qtd_reposicao, (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0') as qtd_utilizadas, encontro.data_encontro as data_encontro, encontro.data_encontro1 as data_encontro1, encontro.codigo AS encontro, encontro.ativo, (select concat(r.codigo, '#', r.confirmada, '#', r.cancelada, '#', r.arquivo_mapa, '#', r.arquivo_material) from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) as reposicao FROM disciplina as d inner join disciplina as d1 ON d.titulo1 = d1.titulo1 OR d1.titulo1 = (SELECT top 1 disc.titulo1 FROM disciplina_professor AS disc WHERE disc.codigo = d.disciplina_professor) inner join encontro ON encontro.disciplina = d1.codigo inner join curso ON d1.curso = curso.codigo left join professor on professor.codigo = d1.professor WHERE d.codigo = @disciplina AND encontro.data_encontro > getdate() AND encontro.ativo = 1 group by professor.nome, encontro.local, d1.curso, curso.titulo, curso.qtd_reposicao, encontro.data_encontro, encontro.data_encontro1, encontro.codigo, encontro.ativo, d.codigo, curso.codigo having (curso.qtd_reposicao >= (select count(*) FROM reposicao WHERE reposicao.curso_reposicao = d1.curso AND reposicao.encontro_reposicao = encontro.codigo AND reposicao.cancelada = '0' and reposicao.curso = @curso)) or ((select r.codigo from reposicao as r where r.disciplina = d.codigo and r.aluno = @aluno and r.curso = @curso and r.curso_reposicao = curso.codigo and r.cancelada = 0) is not null) ORDER BY data_encontro");
                quey.SetParameter("disciplina", disciplina)
                    .SetParameter("aluno", aluno)
                    .SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso_encontro.Add(new PendenciasDisciplinasEncontros(disciplina, Convert.ToInt32(reader["encontro"]), Convert.ToInt32(reader["curso"]), Convert.ToString(reader["curso_titulo"]), Convert.ToInt32(reader["qtd_reposicao"]), Convert.ToInt32(reader["qtd_utilizadas"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["reposicao"]), Convert.ToString(reader["local"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso_encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
