using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class EncontroDB
    {
        public void Salvar(Encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Encontro (data,painel,curso,modulo,numero,ativo,titulo,data_encontro,data_encontro1,data_encontro2,local,disciplina,disciplina1,disciplina2,disciplina3,obs,situacao,situacao1,obs1,enviado) VALUES (@data,@painel,@curso,@modulo,@numero,@ativo,@titulo,@data_encontro,@data_encontro1,@data_encontro2,@local,@disciplina,@disciplina1,@disciplina2,@disciplina3,@obs,@situacao,@situacao1,@obs1,@enviado) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("numero", variavel.numero)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("data_encontro", variavel.data_encontro)
                    .SetParameter("data_encontro1", variavel.data_encontro1)
                    .SetParameter("data_encontro2", variavel.data_encontro2)
                    .SetParameter("local", variavel.local)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("disciplina1", variavel.disciplina1)
                    .SetParameter("disciplina2", variavel.disciplina2)
                    .SetParameter("disciplina3", variavel.disciplina3)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("situacao1", variavel.situacao1)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("enviado", variavel.enviado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Encontro SET data = @data, painel = @painel, curso = @curso, modulo = @modulo, numero = @numero, ativo = @ativo, titulo = @titulo, data_encontro = @data_encontro, data_encontro1 = @data_encontro1, data_encontro2 = @data_encontro2, local = @local, disciplina = @disciplina, disciplina1 = @disciplina1, disciplina2 = @disciplina2, disciplina3 = @disciplina3, obs = @obs, situacao = @situacao, situacao1 = @situacao1, obs1 = @obs1, enviado = @enviado WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("numero", variavel.numero)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("data_encontro", variavel.data_encontro)
                    .SetParameter("data_encontro1", variavel.data_encontro1)
                    .SetParameter("data_encontro2", variavel.data_encontro2)
                    .SetParameter("local", variavel.local)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("disciplina1", variavel.disciplina1)
                    .SetParameter("disciplina2", variavel.disciplina2)
                    .SetParameter("disciplina3", variavel.disciplina3)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("situacao1", variavel.situacao1)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("enviado", variavel.enviado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Encontro variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Encontro WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Encontro Buscar(int codigo)
        {
            try
            {
                Encontro encontro = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo,isnull(data, '1900-01-01') AS data,isnull(painel,  0) AS painel,isnull(curso,  0) AS curso,isnull(modulo, 0) AS modulo,isnull(numero, 0) AS numero,isnull(ativo, 0) AS ativo,isnull(titulo, '') AS titulo,isnull(data_encontro, '1900-01-01') AS data_encontro,isnull(data_encontro1, '1900-01-01') AS data_encontro1,isnull(data_encontro2, '1900-01-01') AS data_encontro2,isnull(local, '') AS local,isnull(disciplina, 0) AS disciplina,isnull(disciplina1, 0) AS disciplina1,isnull(disciplina2, 0) AS disciplina2,isnull(disciplina3, 0) AS disciplina3,isnull(obs, '') AS obs,isnull(situacao, 0) AS situacao,isnull(situacao1, 0) AS situacao1,isnull(obs1, '') AS obs1,isnull(enviado, 0) AS enviado FROM Encontro WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    encontro = new Encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["numero"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToDateTime(reader["data_encontro2"]), Convert.ToString(reader["local"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["disciplina1"]), Convert.ToInt32(reader["disciplina2"]), Convert.ToInt32(reader["disciplina3"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["situacao1"]), Convert.ToString(reader["obs1"]), Convert.ToInt32(reader["enviado"]));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Encontro> Listar(Curso curso, int ativo = 1)
        {
            try
            {
                List<Encontro> encontro = new List<Encontro>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo,isnull(data, '1900-01-01') AS data,isnull(painel,  0) AS painel,isnull(curso,  0) AS curso,isnull(modulo, 0) AS modulo,isnull(numero, 0) AS numero,isnull(ativo, 0) AS ativo,isnull(titulo, '') AS titulo,isnull(data_encontro, '1900-01-01') AS data_encontro,isnull(data_encontro1, '1900-01-01') AS data_encontro1,isnull(data_encontro2, '1900-01-01') AS data_encontro2,isnull(local, '') AS local,isnull(disciplina, 0) AS disciplina,isnull(disciplina1, 0) AS disciplina1,isnull(disciplina2, 0) AS disciplina2,isnull(disciplina3, 0) AS disciplina3,isnull(obs, '') AS obs,isnull(situacao, 0) AS situacao,isnull(situacao1, 0) AS situacao1,isnull(obs1, '') AS obs1,isnull(enviado, 0) AS enviado FROM Encontro WHERE curso = @curso AND ativo = @ativo ORDER BY modulo, numero");
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("ativo", ativo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new Encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["numero"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToDateTime(reader["data_encontro2"]), Convert.ToString(reader["local"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["disciplina1"]), Convert.ToInt32(reader["disciplina2"]), Convert.ToInt32(reader["disciplina3"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["situacao1"]), Convert.ToString(reader["obs1"]), Convert.ToInt32(reader["enviado"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Encontro> Listar(Curso curso, Aluno aluno, int ativo = 1, int situacao = 0)
        {
            try
            {
                List<Encontro> encontro = new List<Encontro>();

                string executar = "SELECT e.codigo, e.data, e.painel, e.curso, e.modulo, e.numero, e.ativo, e.titulo, isnull(e.data_encontro, '01/01/1900') as data_encontro, isnull(e.data_encontro1, '01/01/1900') as data_encontro1, isnull(e.data_encontro2, '01/01/1900') as data_encontro2, e.local, e.disciplina, e.disciplina1, e.disciplina2, e.disciplina3, isnull(e.obs, '') obs, e.situacao, e.situacao1, isnull(e.obs1, '') obs1, e.enviado, d.titulo AS disciplina_titulo, isnull(p.nome, '') as professor_nome, isnull(a.nota, 9999) as nota, isnull(a.frequencia, 9999) as frequencia FROM encontro as e INNER JOIN disciplina AS d ON e.disciplina = d.codigo LEFT JOIN professor as p ON d.professor = p.codigo LEFT JOIN aluno_curso_encontro as a ON e.disciplina = a.disciplina and a.aluno = @aluno WHERE e.curso = @curso AND e.ativo = 1";
                if(situacao == 1)
                {
                    executar += " AND e.data_encontro <= getdate() AND e.data_encontro1 <= getdate()";
                }
                if (situacao == 2)
                {
                    executar += " AND e.data_encontro >= getdate() AND (e.data_encontro1 >= getdate() || e.data_encontro1 = '01-01-1900')";
                }

                executar += " ORDER BY e.data_encontro";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("aluno", aluno.codigo)
                    .SetParameter("ativo", ativo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new Encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["numero"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToDateTime(reader["data_encontro2"]), Convert.ToString(reader["local"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["disciplina1"]), Convert.ToInt32(reader["disciplina2"]), Convert.ToInt32(reader["disciplina3"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["situacao1"]), Convert.ToString(reader["obs1"]), Convert.ToInt32(reader["enviado"]), Convert.ToString(reader["disciplina_titulo"]), Convert.ToString(reader["professor_nome"]), Convert.ToDouble(reader["nota"]), Convert.ToDouble(reader["frequencia"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Encontro> ListarTodosAcompanhamento(int curso = 0)
        {
            try
            {
                List<Encontro> encontro = new List<Encontro>();

                string executar = "SELECT e.codigo, e.data, e.painel, e.curso, e.modulo, e.numero, e.ativo, e.titulo, isnull(e.data_encontro, '01/01/1900') as data_encontro, isnull(e.data_encontro1, '01/01/1900') as data_encontro1, isnull(e.data_encontro2, '01/01/1900') as data_encontro2, e.local, e.disciplina, e.disciplina1, e.disciplina2, e.disciplina3, isnull(e.obs, '') obs, e.situacao, e.situacao1, isnull(e.obs1, '') obs1, e.enviado, d.titulo AS disciplina_titulo, isnull(p.nome, '') as professor_nome FROM encontro as e LEFT JOIN disciplina AS d ON e.disciplina = d.codigo LEFT JOIN professor as p ON d.professor = p.codigo WHERE e.curso = @curso AND e.ativo = 1";
                executar += " ORDER BY e.data_encontro";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new Encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["numero"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToDateTime(reader["data_encontro2"]), Convert.ToString(reader["local"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["disciplina1"]), Convert.ToInt32(reader["disciplina2"]), Convert.ToInt32(reader["disciplina3"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["situacao1"]), Convert.ToString(reader["obs1"]), Convert.ToInt32(reader["enviado"]), Convert.ToString(reader["disciplina_titulo"]), Convert.ToString(reader["professor_nome"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Encontro> ListarTodos(Curso curso, Aluno aluno, int ativo = 1, int situacao = 0)
        {
            try
            {
                List<Encontro> encontro = new List<Encontro>();

                string executar = "SELECT e.codigo, e.data, e.painel, e.curso, e.modulo, e.numero, e.ativo, e.titulo, isnull(e.data_encontro, '01/01/1900') as data_encontro, isnull(e.data_encontro1, '01/01/1900') as data_encontro1, isnull(e.data_encontro2, '01/01/1900') as data_encontro2, e.local, e.disciplina, e.disciplina1, e.disciplina2, e.disciplina3, isnull(e.obs, '') obs, e.situacao, e.situacao1, isnull(e.obs1, '') obs1, e.enviado, d.titulo AS disciplina_titulo, isnull(p.nome, '') as professor_nome, isnull(a.nota, 9999) as nota, isnull(a.frequencia, 9999) as frequencia, isnull(a.visualizar, 0) as visualizar FROM encontro as e LEFT JOIN disciplina AS d ON e.disciplina = d.codigo LEFT JOIN professor as p ON d.professor = p.codigo LEFT JOIN aluno_curso_encontro as a ON e.disciplina = a.disciplina and a.aluno = @aluno WHERE e.curso = @curso AND e.ativo = 1";
                if (situacao == 1)
                {
                    executar += " AND e.data_encontro <= getdate() AND e.data_encontro1 <= getdate()";
                }
                if (situacao == 2)
                {
                    executar += " AND e.data_encontro >= getdate() AND (e.data_encontro1 >= getdate() || e.data_encontro1 = '01-01-1900')";
                }
                executar += " ORDER BY e.data_encontro";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("aluno", aluno.codigo)
                    .SetParameter("ativo", ativo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new Encontro(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["numero"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"]), Convert.ToDateTime(reader["data_encontro2"]), Convert.ToString(reader["local"]), Convert.ToInt32(reader["disciplina"]), Convert.ToInt32(reader["disciplina1"]), Convert.ToInt32(reader["disciplina2"]), Convert.ToInt32(reader["disciplina3"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["situacao1"]), Convert.ToString(reader["obs1"]), Convert.ToInt32(reader["enviado"]), Convert.ToString(reader["disciplina_titulo"]), Convert.ToString(reader["professor_nome"]), Convert.ToDouble(reader["nota"]), Convert.ToDouble(reader["frequencia"]), Convert.ToInt32(reader["visualizar"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ProximasAulas> ProximasAulas(int top = 4)
        {
            try
            {
                List<ProximasAulas> encontro = new List<ProximasAulas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top " + top + " e.codigo as encontro, tc.titulo as curso, c.cidade, concat(p.especialidade, ' ', p.nome) as professor, d.titulo as disciplina, e.data_encontro as data from encontro as e JOIN curso as c ON e.curso = c.codigo JOIN titulo_curso AS tc ON c.titulo_curso = tc.codigo JOIN disciplina as d ON e.disciplina = d.codigo JOIN disciplina_professor AS dp ON d.disciplina_professor = dp.codigo JOIN professor as p ON dp.professor = p.codigo where e.data_encontro >= getdate() and e.ativo = 1 and e.titulo != 'A definir' ORDER BY e.data_encontro");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new ProximasAulas(Convert.ToInt32(reader["encontro"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["disciplina"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ProximasAulas> ProximasAulas(int top = 4, int titulo_curso = 0)
        {
            try
            {
                List<ProximasAulas> encontro = new List<ProximasAulas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top " + top + " e.codigo as encontro, tc.titulo as curso, c.cidade, concat(p.especialidade, ' ', p.nome) as professor, d.titulo as disciplina, e.data_encontro as data from encontro as e JOIN curso as c ON e.curso = c.codigo JOIN titulo_curso AS tc ON c.titulo_curso = tc.codigo JOIN disciplina as d ON e.disciplina = d.codigo JOIN disciplina_professor AS dp ON d.disciplina_professor = dp.codigo JOIN professor as p ON dp.professor = p.codigo where e.data_encontro >= getdate() and e.ativo = 1 and e.titulo != 'A definir' AND tc.codigo = @codigo ORDER BY e.data_encontro");
                quey.SetParameter("codigo", titulo_curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new ProximasAulas(Convert.ToInt32(reader["encontro"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["disciplina"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ProximasAulas> ProximasAulas(Cidade cidade, int top = 4)
        {
            try
            {
                List<ProximasAulas> encontro = new List<ProximasAulas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top " + top + " e.codigo as encontro, tc.titulo as curso, c.cidade, concat(p.especialidade, ' ', p.nome) as professor, d.titulo as disciplina, e.data_encontro as data from encontro as e JOIN curso as c ON e.curso = c.codigo JOIN cidade as ci on c.cidade_codigo = ci.codigo JOIN titulo_curso AS tc ON c.titulo_curso = tc.codigo JOIN disciplina as d ON e.disciplina = d.codigo JOIN disciplina_professor AS dp ON d.disciplina_professor = dp.codigo JOIN professor as p ON dp.professor = p.codigo where e.data_encontro >= getdate() and e.ativo = 1 and e.titulo != 'A definir' AND ci.codigo = @codigo ORDER BY e.data_encontro");
                quey.SetParameter("codigo", cidade.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new ProximasAulas(Convert.ToInt32(reader["encontro"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["disciplina"]), Convert.ToDateTime(reader["data"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string QtdEncontrosRealizados(int curso)
        {
            try
            {
                string encontro = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select concat((select count(codigo) as qtd from encontro where curso = @curso and ativo = 1 and data_encontro <= getdate()), '/', (select count(codigo) as total from encontro where curso = @curso and ativo = 1)) as qtd");
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    encontro = Convert.ToString(reader["qtd"]);
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int BuscarEncontrosAno(int ano)
        {
            try
            {
                int r = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT Count(codigo) as Total FROM encontro WHERE codigo IN (SELECT DISTINCT idencontro FROM Avaliacoes) AND YEAR(data_encontro) = @ano");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    r = Convert.ToInt32(reader["Total"]);
                }
                reader.Close();
                session.Close();

                return r;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<EncontroEmail> ListaParaEmail()
        {
            try
            {
                List<EncontroEmail> encontro = new List<EncontroEmail>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select c.titulo1, e.data_encontro, e.obsemailmarcos, d.titulo, p.nome,
	                    (case when ((select count(*) as total from checklist ch inner join checklist_encontro ce on ce.checklist = ch.codigo where ch.curso = c.codigo and ch.titulo like '%gabarito%' and ce.encontro = e.codigo) > 0) then 1 else 0 end) as gabarito
                    from encontro e
                    inner join curso c on c.codigo = e.curso
                    inner join disciplina d on d.codigo = e.disciplina
                    inner join professor p on p.codigo = d.professor
                    where c.tipo = 0 and cast(data_encontro as date) >= cast(dateadd(day, -2, getdate()) as date) and cast(data_encontro as date) <= cast(getdate() as date) and e.ativo = 1
                    order by c.titulo1");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    encontro.Add(new EncontroEmail(Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToString(reader["obsemailmarcos"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["nome"]), Convert.ToInt32(reader["gabarito"])));
                }
                reader.Close();
                session.Close();

                return encontro;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
