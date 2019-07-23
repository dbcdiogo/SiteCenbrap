using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Titulo_curso_DisciplinaDB
    {
        public void Salvar(Titulo_curso_Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Titulo_curso_Disciplina (titulo_curso, disciplina, ordem) VALUES (@titulo_curso, @disciplina, @ordem) ");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Titulo_curso_Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Titulo_curso_Disciplina SET titulo_curso = @titulo_curso, disciplina = @disciplina, ordem = @ordem WHERE Titulo_curso_Disciplina_id = @Titulo_curso_Disciplina_id");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("disciplina", variavel.disciplina)
                    .SetParameter("ordem", variavel.ordem)
                    .SetParameter("Titulo_curso_Disciplina_id", variavel.Titulo_curso_Disciplina_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Titulo_curso_Disciplina variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Titulo_curso_Disciplina WHERE Titulo_curso_Disciplina_id = @Titulo_curso_Disciplina_id");
                query.SetParameter("Titulo_curso_Disciplina_id", variavel.Titulo_curso_Disciplina_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Titulo_curso_Disciplina Buscar(int codigo)
        {
            try
            {
                Titulo_curso_Disciplina retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso_Disciplina WHERE Titulo_curso_Disciplina_id = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Titulo_curso_Disciplina(Convert.ToInt32(reader["Titulo_curso_Disciplina_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) }, Convert.ToString(reader["disciplina"]), Convert.ToInt32(reader["ordem"]));
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

        public List<Titulo_curso_Disciplina> Listar()
        {
            try
            {
                List<Titulo_curso_Disciplina> retorno = new List<Titulo_curso_Disciplina>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT d.Titulo_curso_Disciplina_id, d.titulo_curso, d.disciplina, d.ordem, t.titulo FROM Titulo_curso_Disciplina AS d JOIN titulo_curso AS t ON d.titulo_curso = t.codigo ORDER BY d.ordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Titulo_curso_Disciplina(Convert.ToInt32(reader["Titulo_curso_Disciplina_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["disciplina"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Titulo_curso_Disciplina> Listar(int titulo_curso)
        {
            try
            {
                List<Titulo_curso_Disciplina> retorno = new List<Titulo_curso_Disciplina>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT d.Titulo_curso_Disciplina_id, d.titulo_curso, d.disciplina, d.ordem, t.titulo FROM Titulo_curso_Disciplina AS d JOIN titulo_curso AS t ON d.titulo_curso = t.codigo WHERE d.titulo_curso = @titulo_curso ORDER BY d.ordem");
                quey.SetParameter("titulo_curso", titulo_curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Titulo_curso_Disciplina(Convert.ToInt32(reader["Titulo_curso_Disciplina_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["disciplina"]), Convert.ToInt32(reader["ordem"])));
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
