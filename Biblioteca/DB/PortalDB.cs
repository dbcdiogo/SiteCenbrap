using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PortalDB
    {             

        public Portal Buscar(int curso = 0, int aluno = 0)
        {
            try
            {
                Portal dataLote = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from (SELECT aluno, curso, isnull(data, '') as data, ROW_NUMBER() over(order by data desc) as rn FROM portal_acesso WHERE aluno = @aluno and curso = @curso) t where t.rn = 2");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote = new Portal(Convert.ToInt32(reader["curso"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["aluno"]));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int BuscarNovas(int curso = 0, int aluno = 0)
        {
            try
            {
                int qt = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as qtde from avisos where curso = @curso and data >= (select data from(SELECT aluno, curso, isnull(data, '') as data, ROW_NUMBER() over(order by data desc) as rn FROM portal_acesso WHERE aluno = @aluno and curso = @curso) t where t.rn = 2)");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    qt = Convert.ToInt32(reader["qtde"]);
                }
                reader.Close();
                session.Close();
                return qt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int MensagensTcc(int curso = 0, int aluno = 0)
        {
            try
            {
                int qt = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as qtde from Monografia_dialogo where monografia = (select codigo from monografia where curso = @curso and aluno = @aluno) and de = 1 and data >= (select data from(SELECT aluno, curso, isnull(data, '') as data, ROW_NUMBER() over(order by data desc) as rn FROM portal_acesso WHERE aluno = @aluno and curso = @curso) t where t.rn = 2)");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    qt = Convert.ToInt32(reader["qtde"]);
                }
                reader.Close();
                session.Close();
                return qt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void InsereAcesso(int curso = 0, int aluno = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO portal_Acesso (aluno, curso, data) values (@aluno, @curso, getdate())");
                query.SetParameter("aluno", aluno)
                    .SetParameter("curso", curso);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int PendenciasDocumentos(int curso = 0, int aluno = 0)
        {
            try
            {
                int qt = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as qtde from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join documentos as d on c.codigo = d.curso where a.codigo = @aluno and c.codigo = @curso and not exists(select * from documentos_alunos as da where da.aluno = a.codigo and da.documentos = d.codigo)");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    qt = Convert.ToInt32(reader["qtde"]);
                }
                reader.Close();
                session.Close();
                return qt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int PendenciasEncontros(int curso = 0, int aluno = 0)
        {
            try
            {
                int qt = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select count(*) as qtde from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join aluno_curso_encontro as ace on c.codigo = ace.curso and a.codigo = ace.aluno inner join encontro as e on ace.disciplina = e.disciplina and e.curso = c.codigo and e.ativo = 1 and e.data_encontro < getdate() where a.codigo = @aluno and c.codigo = @curso and (ace.nota < 7 OR ace.frequencia < 75)");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    qt = Convert.ToInt32(reader["qtde"]);
                }
                reader.Close();
                session.Close();
                return qt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int PendenciasFinanceiro(int curso = 0, int aluno = 0)
        {
            try
            {
                int qt = 0;

                DBSession session = new DBSession();                
                Query quey = session.CreateQuery("select count(b.codigo) AS qtde from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join cliente as cl on replace(replace(replace(replace(a.cpf, '.', ''), '-', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cl.cpf_cnpj, '.', ''), '-', ''), '/', ''), ' ', '') inner join entrada as e on cl.codigo = e.cliente inner join cliente_grupo as cg on cl.grupo = cg.codigo inner join boleto as b on e.codigo = b.entrada where a.codigo = @aluno and c.codigo = @curso and c.titulo1 = cg.grupo and c.titulo1 = cg.grupo and e.vencimento < dateadd(day, -5, getdate()) and e.situacao < 2 and ac.situacao = 2");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    qt = Convert.ToInt32(reader["qtde"]);
                }
                reader.Close();
                session.Close();
                return qt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
