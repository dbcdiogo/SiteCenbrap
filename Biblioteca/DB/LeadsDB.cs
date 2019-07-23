using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class LeadsDB
    {
        public List<Leads> Listar(DateTime inicio, DateTime fim)
        {
            try
            {
                List<Leads> lead = new List<Leads>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("  select n.nome, n.email, n.data, n.telefone, isnull(n.idlandingpage,0) as idlandingpage, isnull(a.codigo, 0) as codigo, a.nome as aluno from newsletter n left join aluno a on a.email = n.email where n.data between @inicio AND @fim order by codigo desc");
                quey.SetParameter("inicio", inicio)
                .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    lead.Add(new Leads(Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["telefone"]), Convert.ToInt32(reader["idlandingpage"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["aluno"])));
                }
                reader.Close();
                session.Close();

                return lead;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
