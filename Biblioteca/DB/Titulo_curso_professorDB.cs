using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Titulo_curso_professorDB
    {
        public void Salvar(Titulo_curso_professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Titulo_curso_professor (titulo_curso, foto, professor, especializacao, curriculo, ordem) VALUES (@titulo_curso, @foto, @professor, @especializacao, @curriculo, @ordem) ");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("foto", variavel.foto)
                    .SetParameter("curriculo", variavel.curriculo)
                    .SetParameter("especializacao", variavel.especializacao)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(Titulo_curso_professor variavel)
        {
            try
            {
                int id = 0;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Titulo_curso_professor (titulo_curso, foto, professor, especializacao, curriculo, ordem) VALUES (@titulo_curso, @foto, @professor, @especializacao, @curriculo, @ordem) ");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("especializacao", variavel.especializacao)
                    .SetParameter("foto", variavel.foto)
                    .SetParameter("curriculo", variavel.curriculo)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();

                DBSession session1 = new DBSession();
                Query quey = session1.CreateQuery("SELECT Titulo_curso_professor_id FROM Titulo_curso_professor WHERE titulo_curso = @titulo_curso AND professor = @professor AND ordem = @ordem ORDER BY Titulo_curso_professor_id DESC");
                quey.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("ordem", variavel.ordem);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["Titulo_curso_professor_id"]);
                }
                reader.Close();
                session1.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Titulo_curso_professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Titulo_curso_professor SET titulo_curso = @titulo_curso, professor = @professor, foto = @foto, curriculo = @curriculo, especializacao = @especializacao, ordem = @ordem WHERE Titulo_curso_professor_id = @Titulo_curso_professor_id");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("professor", variavel.professor)
                    .SetParameter("curriculo", variavel.curriculo)
                    .SetParameter("foto", variavel.foto)
                    .SetParameter("especializacao", variavel.especializacao)
                    .SetParameter("ordem", variavel.ordem)
                    .SetParameter("Titulo_curso_professor_id", variavel.Titulo_curso_professor_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Titulo_curso_professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Titulo_curso_professor WHERE Titulo_curso_professor_id = @Titulo_curso_professor_id");
                query.SetParameter("Titulo_curso_professor_id", variavel.Titulo_curso_professor_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Titulo_curso_professor Buscar(int codigo)
        {
            try
            {
                Titulo_curso_professor retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT tcp.Titulo_curso_professor_id, tcp.titulo_curso, tc.titulo, tcp.foto, tcp.professor, tcp.curriculo, tcp.especializacao, tcp.ordem FROM Titulo_curso_professor AS tcp JOIN titulo_curso AS tc ON tcp.titulo_curso = tc.codigo  WHERE tcp.Titulo_curso_professor_id = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Titulo_curso_professor(Convert.ToInt32(reader["Titulo_curso_professor_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["foto"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["especializacao"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"]));
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

        public List<Titulo_curso_professor> Listar()
        {
            try
            {
                List<Titulo_curso_professor> retorno = new List<Titulo_curso_professor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT tcp.Titulo_curso_professor_id, tcp.titulo_curso, tc.titulo, tcp.foto, tcp.professor, tcp.curriculo, tcp.especializacao, tcp.ordem FROM Titulo_curso_professor AS tcp JOIN titulo_curso AS tc ON tcp.titulo_curso = tc.codigo ORDER BY tcp.ordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Titulo_curso_professor(Convert.ToInt32(reader["Titulo_curso_professor_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["foto"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["especializacao"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Titulo_curso_professor> Listar(int titulo_curso)
        {
            try
            {
                List<Titulo_curso_professor> retorno = new List<Titulo_curso_professor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT tcp.Titulo_curso_professor_id, tcp.titulo_curso, tc.titulo, tcp.foto, tcp.professor, tcp.curriculo, tcp.especializacao, tcp.ordem FROM Titulo_curso_professor AS tcp JOIN titulo_curso AS tc ON tcp.titulo_curso = tc.codigo WHERE tcp.titulo_curso = @titulo_curso ORDER BY tcp.ordem");
                quey.SetParameter("titulo_curso", titulo_curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Titulo_curso_professor(Convert.ToInt32(reader["Titulo_curso_professor_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["foto"]), Convert.ToString(reader["professor"]), Convert.ToString(reader["especializacao"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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
