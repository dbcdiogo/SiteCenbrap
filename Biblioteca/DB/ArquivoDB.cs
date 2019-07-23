using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class ArquivoDB
    {
        private string endereco_fisico = @"D:\Parallels\Plesk Panel\Vhosts\cenbrap.com.br\httpdocs\arquivos\";

        public void Salvar(Arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Arquivo (data, painel, curso, modulo, disciplina, professor, arquivo, titulo, texto, obs, link) VALUES (@data, @painel, @curso, @modulo, @disciplina, @professor, @arquivo, @titulo, @texto, @obs, @link) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("disciplina", variavel.disciplina.codigo)
                    .SetParameter("professor", variavel.professor.codigo)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Arquivo SET data = @data, painel = @painel, curso = @curso, modulo = @modulo, disciplina = @disciplina, professor = @professor, arquivo = @arquivo, titulo = @titulo, texto = @texto, obs = @obs, link = @link WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("disciplina", variavel.disciplina.codigo)
                    .SetParameter("professor", variavel.professor.codigo)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("link", variavel.link);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Arquivo WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Arquivo Buscar(int codigo)
        {
            try
            {
                Arquivo Arquivo = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Arquivo WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Arquivo = new Arquivo(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), new Disciplina() { codigo = Convert.ToInt32(reader["disciplina"]) }, new Professor() { codigo = Convert.ToInt32(reader["professor"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["link"]));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Arquivo> Listar()
        {
            try
            {
                List<Arquivo> Arquivo = new List<Arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Arquivo ORDER BY nome");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Arquivo.Add(new Arquivo(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), new Disciplina() { codigo = Convert.ToInt32(reader["disciplina"]) }, new Professor() { codigo = Convert.ToInt32(reader["professor"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Arquivo> Listar(Curso curso)
        {
            try
            {
                List<Arquivo> Arquivo = new List<Arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Arquivo WHERE curso = @curso ORDER BY nome");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Arquivo.Add(new Arquivo(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), new Disciplina() { codigo = Convert.ToInt32(reader["disciplina"]) }, new Professor() { codigo = Convert.ToInt32(reader["professor"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Arquivo> Listar(Disciplina disciplina)
        {
            try
            {
                List<Arquivo> Arquivo = new List<Arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT arquivo.codigo, arquivo.data, arquivo.painel, arquivo.curso, arquivo.modulo, arquivo.disciplina, disciplina.titulo as disciplina_titulo, arquivo.professor, professor.nome as professor_nome, arquivo.arquivo, arquivo.titulo, arquivo.texto, arquivo.obs, arquivo.link FROM Arquivo INNER JOIN disciplina ON disciplina.codigo = arquivo.codigo INNER JOIN professor ON professor.codigo = arquivo.professor WHERE arquivo.disciplina = @disciplina ORDER BY arquivo.modulo, arquivo.titulo");
                quey.SetParameter("disciplina", disciplina.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Arquivo.Add(new Arquivo(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), new Disciplina() { codigo = Convert.ToInt32(reader["disciplina"]), titulo = Convert.ToString(reader["disciplina_titulo"]) }, new Professor() { codigo = Convert.ToInt32(reader["professor"]), nome = Convert.ToString(reader["professor_nome"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["link"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ArquivoVisualizar> ListarArquivo(int disciplina)
        {
            try
            {
                List<ArquivoVisualizar> Arquivo = new List<ArquivoVisualizar>();

                DBSession session = new DBSession();
                //Query quey = session.CreateQuery("select codigo, disciplina_professor, visualizacao, modulo, titulo, texto, disciplina_titulo, professor, data, data_arquivo, data_encontro, data_encontro1 from ((SELECT concat('dpm', disciplina_professor_material.codigo) AS codigo, disciplina_professor_material.disciplina_professor AS disciplina_professor, disciplina_professor_material.visualizacao AS visualizacao, disciplina.modulo AS modulo, disciplina_professor_material.titulo As titulo, disciplina_professor_material.texto As texto, disciplina.titulo AS disciplina_titulo, professor.nome As professor, encontro.data AS data, disciplina_professor_material.data As data_arquivo, encontro.data_encontro AS data_encontro, encontro.data_encontro1 AS data_encontro1, encontro.codigo as encontro FROM disciplina_professor_material, disciplina, professor, encontro WHERE disciplina.codigo = @disciplina AND disciplina.disciplina_professor = disciplina_professor_material.disciplina_professor AND disciplina_professor_material.tipo = '0' AND disciplina.professor = professor.codigo AND encontro.disciplina = disciplina.codigo AND encontro.ativo = 1 AND encontro.data_encontro1 < getdate()) UNION (select concat('a',a.codigo) as codigo, a.disciplina as disciplina_professor, 0 as visualizacao, a.modulo as modulo, a.titulo as titulo, a.texto as texto, d.titulo as disciplina_titulo, p.nome as professor, a.data as data, a.data as data_arquivo, a.data as data_encontro, a.data as data_encontro1, 0 as encontro from arquivo AS a INNER JOIN disciplina as d ON a.disciplina = d.codigo INNER JOIN professor as p ON a.professor = p.codigo where a.disciplina = @disciplina) ) as t ORDER BY data");
                Query quey = session.CreateQuery("select codigo, disciplina_professor, visualizacao, modulo, titulo, texto, disciplina_titulo, professor, data, data_arquivo, data_encontro, isnull(data_encontro1,'1900-01-01') as data_encontro1 from ((SELECT concat('dpm', disciplina_professor_material.codigo) AS codigo, disciplina_professor_material.disciplina_professor AS disciplina_professor, disciplina_professor_material.visualizacao AS visualizacao, disciplina.modulo AS modulo, disciplina_professor_material.titulo As titulo, disciplina_professor_material.texto As texto, disciplina.titulo AS disciplina_titulo, professor.nome As professor, encontro.data AS data, disciplina_professor_material.data As data_arquivo, encontro.data_encontro AS data_encontro, encontro.data_encontro1 AS data_encontro1, encontro.codigo as encontro FROM disciplina_professor_material, disciplina, professor, encontro WHERE disciplina.codigo = @disciplina AND disciplina.disciplina_professor = disciplina_professor_material.disciplina_professor AND disciplina_professor_material.tipo = '0' AND disciplina.professor = professor.codigo AND encontro.disciplina = disciplina.codigo AND encontro.ativo = 1) UNION (select concat('a',a.codigo) as codigo, a.disciplina as disciplina_professor, 0 as visualizacao, a.modulo as modulo, a.titulo as titulo, a.texto as texto, d.titulo as disciplina_titulo, p.nome as professor, a.data as data, a.data as data_arquivo, a.data as data_encontro, a.data as data_encontro1, 0 as encontro from arquivo AS a INNER JOIN disciplina as d ON a.disciplina = d.codigo INNER JOIN professor as p ON a.professor = p.codigo where a.disciplina = @disciplina) ) as t ORDER BY data");
                quey.SetParameter("disciplina", disciplina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Arquivo.Add(new ArquivoVisualizar(Convert.ToString(reader["codigo"]), Convert.ToInt32(reader["disciplina_professor"]), Convert.ToInt32(reader["visualizacao"]), Convert.ToInt32(reader["modulo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["disciplina_titulo"]), Convert.ToString(reader["professor"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["data_arquivo"]), Convert.ToDateTime(reader["data_encontro"]), Convert.ToDateTime(reader["data_encontro1"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string ArquivoDisciplinaProfessorMaterial(string id)
        {
            try
            {
                string retorno = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT (CASE WHEN arquivo is not null THEN concat('" + endereco_fisico + "', arquivo) ELSE link END) as arquivo FROM Disciplina_professor_material WHERE codigo = @codigo");
                quey.SetParameter("codigo", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToString(reader["arquivo"]);
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

        public string Arquivo(string id)
        {
            try
            {
                string retorno = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT (CASE WHEN arquivo is not null THEN concat('" + endereco_fisico + "', arquivo) ELSE link END) as arquivo FROM arquivo WHERE codigo = @codigo");
                quey.SetParameter("codigo", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = Convert.ToString(reader["arquivo"]);
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

    }
}
