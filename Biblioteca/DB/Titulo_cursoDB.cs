using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Titulo_cursoDB
    {

        public void Salvar(Titulo_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Titulo_curso (titulo, titulo_detalhado, certificacao, aula_inaugural, publico_alvo, duracao_meses, horario_aulas, documentacao, disciplinas, disciplinas_completo, professores, professores_completo, icone, cor1, cor2, texto, imagem, link) VALUES (@titulo, @titulo_detalhado, @certificacao, @aula_inaugural, @publico_alvo, @duracao_meses, @horario_aulas, @documentacao, @disciplinas, @disciplinas_completo, @professores, @professores_completo, @icone, @cor1, @cor2, @texto, @imagem, @link) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo_detalhado", variavel.titulo_detalhado)
                    .SetParameter("certificacao", variavel.certificacao)
                    .SetParameter("aula_inaugural", variavel.aula_inaugural)
                    .SetParameter("publico_alvo", variavel.publico_alvo)
                    .SetParameter("duracao_meses", variavel.duracao_meses)
                    .SetParameter("horario_aulas", variavel.horario_aulas)
                    .SetParameter("documentacao", variavel.documentacao)
                    .SetParameter("disciplinas", variavel.disciplinas)
                    .SetParameter("disciplinas_completo", variavel.disciplinas_completo)
                    .SetParameter("professores", variavel.professores)
                    .SetParameter("professores_completo", variavel.professores_completo)
                    .SetParameter("icone", variavel.icone)
                    .SetParameter("cor1", variavel.cor1)
                    .SetParameter("cor2", variavel.cor2)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Titulo_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Titulo_curso SET titulo = @titulo, titulo_detalhado = @titulo_detalhado, certificacao = @certificacao, aula_inaugural = @aula_inaugural, publico_alvo = @publico_alvo, duracao_meses = @duracao_meses, horario_aulas = @horario_aulas, documentacao = @documentacao, disciplinas = @disciplinas, disciplinas_completo = @disciplinas_completo, professores = @professores, professores_completo = @professores_completo, icone = @icone, cor1 = @cor1, cor2 = @cor2, texto = @texto, imagem = @imagem, link = @link WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo_detalhado", variavel.titulo_detalhado)
                    .SetParameter("certificacao", variavel.certificacao)
                    .SetParameter("aula_inaugural", variavel.aula_inaugural)
                    .SetParameter("publico_alvo", variavel.publico_alvo)
                    .SetParameter("duracao_meses", variavel.duracao_meses)
                    .SetParameter("horario_aulas", variavel.horario_aulas)
                    .SetParameter("documentacao", variavel.documentacao)
                    .SetParameter("disciplinas", variavel.disciplinas)
                    .SetParameter("disciplinas_completo", variavel.disciplinas_completo)
                    .SetParameter("professores", variavel.professores)
                    .SetParameter("professores_completo", variavel.professores_completo)
                    .SetParameter("icone", variavel.icone)
                    .SetParameter("cor1", variavel.cor1)
                    .SetParameter("cor2", variavel.cor2)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("imagem", variavel.imagem)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Titulo_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Titulo_curso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Titulo_curso Buscar(int codigo)
        {
            try
            {
                Titulo_curso titulo_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    titulo_curso = new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_detalhado"]), Convert.ToString(reader["certificacao"]), Convert.ToString(reader["aula_inaugural"]), Convert.ToString(reader["publico_alvo"]), Convert.ToString(reader["duracao_meses"]), Convert.ToString(reader["horario_aulas"]), Convert.ToString(reader["documentacao"]), Convert.ToString(reader["disciplinas"]), Convert.ToString(reader["disciplinas_completo"]), Convert.ToString(reader["professores"]), Convert.ToString(reader["professores_completo"]), Convert.ToString(reader["icone"]), Convert.ToString(reader["cor1"]), Convert.ToString(reader["cor2"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"]));
                }
                reader.Close();
                session.Close();

                return titulo_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Titulo_curso Buscar(string link)
        {
            try
            {
                Titulo_curso titulo_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso WHERE link = @link");
                quey.SetParameter("link", link);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    titulo_curso = new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_detalhado"]), Convert.ToString(reader["certificacao"]), Convert.ToString(reader["aula_inaugural"]), Convert.ToString(reader["publico_alvo"]), Convert.ToString(reader["duracao_meses"]), Convert.ToString(reader["horario_aulas"]), Convert.ToString(reader["documentacao"]), Convert.ToString(reader["disciplinas"]), Convert.ToString(reader["disciplinas_completo"]), Convert.ToString(reader["professores"]), Convert.ToString(reader["professores_completo"]), Convert.ToString(reader["icone"]), Convert.ToString(reader["cor1"]), Convert.ToString(reader["cor2"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"]));
                }
                reader.Close();
                session.Close();

                return titulo_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Titulo_curso> Listar()
        {
            try
            {
                List<Titulo_curso> Cidade = new List<Titulo_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_detalhado"]), Convert.ToString(reader["certificacao"]), Convert.ToString(reader["aula_inaugural"]), Convert.ToString(reader["publico_alvo"]), Convert.ToString(reader["duracao_meses"]), Convert.ToString(reader["horario_aulas"]), Convert.ToString(reader["documentacao"]), Convert.ToString(reader["disciplinas"]), Convert.ToString(reader["disciplinas_completo"]), Convert.ToString(reader["professores"]), Convert.ToString(reader["professores_completo"]), Convert.ToString(reader["icone"]), Convert.ToString(reader["cor1"]), Convert.ToString(reader["cor2"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Titulo_curso> Listar(int cidades = 0, int cursos = 0)
        {
            try
            {
                List<Titulo_curso> Cidade = new List<Titulo_curso>();

                string executar = "SELECT distinct t.codigo, t.titulo FROM Titulo_curso t JOIN curso c on c.titulo_curso = t.codigo JOIN cidade ci on c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 ";
                if (cidades != 0)
                    executar += " and ci.codigo = " + cidades;
                if (cursos != 0)
                    executar += " and c.titulo_curso = " + cursos;

                executar += " ORDER BY t.titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();
                
                while (reader.Read())
                {
                    Cidade.Add(new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Titulo_curso> Listar(int tipo = 0)
        {
            try
            {
                List<Titulo_curso> titulo = new List<Titulo_curso>();

                string executar = "SELECT distinct t.codigo, t.titulo, t.link FROM Titulo_curso t JOIN curso c on c.titulo_curso = t.codigo WHERE c.visualiza_site = 1 AND c.tipo = " + tipo +" ORDER BY t.titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    titulo.Add(new Titulo_curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        link = Convert.ToString(reader["link"])
                    });
                }
                reader.Close();
                session.Close();

                return titulo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Titulo_curso> ListarMidia()
        {
            try
            {
                List<Titulo_curso> Cidade = new List<Titulo_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso WHERE exists (SELECT midia_id FROM midia_titulo_curso WHERE titulo_curso.codigo = midia_titulo_curso.titulo_curso) ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_detalhado"]), Convert.ToString(reader["certificacao"]), Convert.ToString(reader["aula_inaugural"]), Convert.ToString(reader["publico_alvo"]), Convert.ToString(reader["duracao_meses"]), Convert.ToString(reader["horario_aulas"]), Convert.ToString(reader["documentacao"]), Convert.ToString(reader["disciplinas"]), Convert.ToString(reader["disciplinas_completo"]), Convert.ToString(reader["professores"]), Convert.ToString(reader["professores_completo"]), Convert.ToString(reader["icone"]), Convert.ToString(reader["cor1"]), Convert.ToString(reader["cor2"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Titulo_curso> ListarMidia(int midia_id)
        {
            try
            {
                List<Titulo_curso> Cidade = new List<Titulo_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso WHERE exists (SELECT midia_id FROM midia_titulo_curso WHERE titulo_curso.codigo = midia_titulo_curso.titulo_curso AND midia_titulo_curso.midia_id = @midia_id) ORDER BY titulo").SetParameter("midia_id", midia_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Cidade.Add(new Titulo_curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_detalhado"]), Convert.ToString(reader["certificacao"]), Convert.ToString(reader["aula_inaugural"]), Convert.ToString(reader["publico_alvo"]), Convert.ToString(reader["duracao_meses"]), Convert.ToString(reader["horario_aulas"]), Convert.ToString(reader["documentacao"]), Convert.ToString(reader["disciplinas"]), Convert.ToString(reader["disciplinas_completo"]), Convert.ToString(reader["professores"]), Convert.ToString(reader["professores_completo"]), Convert.ToString(reader["icone"]), Convert.ToString(reader["cor1"]), Convert.ToString(reader["cor2"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Cidade;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
