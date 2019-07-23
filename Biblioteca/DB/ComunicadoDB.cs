using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ComunicadoDB
    {
        public void Salvar(Comunicado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Curso_comunicados (turma, aluno, tipo, novocurso, dados) VALUES (@turma, @aluno, @tipo, @novocurso, @dados) ");
                query.SetParameter("turma", variavel.turma);
                query.SetParameter("aluno", variavel.aluno);
                query.SetParameter("tipo", variavel.tipo);
                query.SetParameter("novocurso", variavel.novocurso);
                query.SetParameter("dados", variavel.dados);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Comunicado Buscar(int turma, int aluno)
        {
            try
            {
                Comunicado comunicado = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from curso_comunicados where turma = @turma and aluno = @aluno order by ident desc");
                quey.SetParameter("turma", turma);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    comunicado = new Comunicado(Convert.ToInt32(reader["ident"]), Convert.ToString(reader["turma"]), Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["novocurso"]), Convert.ToString(reader["dados"]));
                }
                reader.Close();
                session.Close();

                return comunicado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
