using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineKanbanDB
    {

        public List<TimelineKanban> Listar(int curso = 0, string tipo = "")
        {
            try
            {
                List<TimelineKanban> kb = new List<TimelineKanban>();
                DBSession session = new DBSession();

                string qry = "";
                switch (tipo) {
                    case "I":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO = 0 AND ac.email_impressao_boleto = '1900-01-01' and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "B":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO = 0 AND ac.email_impressao_boleto <= @data AND ac.email_impressao_boleto > '1900-01-01' and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "R":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO = 0 AND ac.email_impressao_boleto > @data and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "M":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO = 2 and isnull(ac.nao_fara_o_curso, '1900-01-01') = '1900-01-01' and ac.aluno not in (select aluno from documentos_alunos where curso = @curso and documentos = (select codigo from documentos where curso = @curso and documentos1 = 'Contrato')) and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "C":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO = 2 and isnull(ac.nao_fara_o_curso, '1900-01-01') = '1900-01-01' and ac.aluno in (select aluno from documentos_alunos where curso = @curso and documentos = (select codigo from documentos where curso = @curso and documentos1 = 'Contrato')) and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "N":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso and isnull(ac.nao_fara_o_curso, '1900-01-01') > '1900-01-01' and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "D":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso AND ac.SITUACAO in (3,4) and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                    case "E":
                        qry = "SELECT ac.codigo, a.nome FROM ALUNO_CURSO ac inner join aluno a on a.codigo = ac.aluno WHERE ac.CURSO = @curso and ac.adesao >= (select data_lista_espera from curso where codigo = @curso) and ac.aluno not in (select idaluno from timeline_usuarios where flignorar = 1) order by a.nome";
                        break;
                }

                Query quey = session.CreateQuery(qry);
                quey.SetParameter("curso", curso).SetParameter("data", DateTime.Now.AddDays(-5));
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    kb.Add(new TimelineKanban(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return kb;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
    }
}
