using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class DisciplinaDB
    {
        public void Salvar(Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Disciplina (data,painel,curso,modulo,professor,professor1,professor2,titulo,titulo1,texto,obs,ativo,vinculado,titulo_certificadora,disciplina_professor) VALUES (@data,@painel,@curso,@modulo,@professor,@professor1,@professor2,@titulo,@titulo1,@texto,@obs,@ativo,@vinculado,@titulo_certificadora,@disciplina_professor) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("professor1", variavel.professor1)
                    .SetParameter("professor2", variavel.professor2)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo1", variavel.titulo1)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("vinculado", variavel.vinculado)
                    .SetParameter("titulo_certificadora", variavel.titulo_certificadora)
                    .SetParameter("disciplina_professor", variavel.disciplina_professor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE disciplina SET data = @data, painel = @painel, curso = @curso, modulo = @modulo, professor = @professor, professor1 = @professor1, professor2 = @professor2, titulo = @titulo, titulo1 = @titulo1, texto = @texto, obs = @obs, ativo = @ativo, vinculado = @vinculado, titulo_certificadora = @titulo_certificadora, disciplina_professor = @disciplina_professor WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("modulo", variavel.modulo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("professor1", variavel.professor1)
                    .SetParameter("professor2", variavel.professor2)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo1", variavel.titulo1)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("vinculado", variavel.vinculado)
                    .SetParameter("titulo_certificadora", variavel.titulo_certificadora)
                    .SetParameter("disciplina_professor", variavel.disciplina_professor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM disciplina WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Disciplina Buscar(int codigo)
        {
            try
            {
                Disciplina disciplina = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Disciplina WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    disciplina = new Disciplina(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["professor"]), Convert.ToInt32(reader["professor1"]), Convert.ToInt32(reader["professor2"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["ativo"]), Convert.ToInt32(reader["vinculado"]), Convert.ToString(reader["titulo_certificadora"]), Convert.ToInt32(reader["disciplina_professor"]));
                }
                reader.Close();
                session.Close();

                return disciplina;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Disciplina> Listar()
        {
            try
            {
                List<Disciplina> disciplina = new List<Disciplina>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Disciplina");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    disciplina.Add(new Disciplina(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["professor"]), Convert.ToInt32(reader["professor1"]), Convert.ToInt32(reader["professor2"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["ativo"]), Convert.ToInt32(reader["vinculado"]), Convert.ToString(reader["titulo_certificadora"]), Convert.ToInt32(reader["disciplina_professor"])));
                }
                reader.Close();
                session.Close();

                return disciplina;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Disciplina> Listar(Curso curso)
        {
            try
            {
                List<Disciplina> disciplina = new List<Disciplina>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Disciplina where curso = @curso")
                    .SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    disciplina.Add(new Disciplina(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, Convert.ToInt32(reader["modulo"]), Convert.ToInt32(reader["professor"]), Convert.ToInt32(reader["professor1"]), Convert.ToInt32(reader["professor2"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["ativo"]), Convert.ToInt32(reader["vinculado"]), Convert.ToString(reader["titulo_certificadora"]), Convert.ToInt32(reader["disciplina_professor"])));
                }
                reader.Close();
                session.Close();

                return disciplina;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
