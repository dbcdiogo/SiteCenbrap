using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineCursosDashboardDB
    {       
        public List<TimelineCursosDashboard> ListarEncontros()
        {
            try
            {
                List<TimelineCursosDashboard> lista = new List<TimelineCursosDashboard>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select  e.modulo, e.numero, c.titulo1, e.data_encontro, e.data_encontro1, d.titulo, isnull(p.nome,'') as professor, isnull(r.nome, '') as representante, isnull(r.telefone, '') as telefone, c.codigo as codigo_curso, e.codigo as codigo_encontro
                    from encontro e
                    inner join curso c on c.codigo = e.curso
                    inner join disciplina d on d.codigo = e.disciplina
                    inner join professor p on p.codigo = d.professor
                    left join representante r on r.cidade = c.cidade_codigo
                    where cast(e.data_encontro1 as date) >= cast(getdate() as date) and cast(e.data_encontro1 as date) <= cast(dateadd(day, 5, getdate()) as date) and e.ativo = 1 and r.ativo = 1
                    order by e.data_encontro, c.titulo1
                    ");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    byte[] chave = Encoding.ASCII.GetBytes(Convert.ToInt32(reader["codigo_encontro"]) + "#" + Convert.ToInt32(reader["codigo_curso"]));
                    lista.Add(new TimelineCursosDashboard()
                    {
                        modulo = Convert.ToInt32(reader["modulo"]),
                        numero = Convert.ToInt32(reader["numero"]),
                        curso = Convert.ToString(reader["titulo1"]),
                        data1 = Convert.ToDateTime(reader["data_encontro"]),
                        data2 = Convert.ToDateTime(reader["data_encontro1"]),
                        disciplina = Convert.ToString(reader["titulo"]),
                        professor = Convert.ToString(reader["professor"]),
                        representante = Convert.ToString(reader["representante"]),
                        codigo_curso = Convert.ToInt32(reader["codigo_curso"]),
                        codigo_encontro = Convert.ToInt32(reader["codigo_encontro"]),
                        telefone = Whatsapp.FormataCelular("", Convert.ToString(reader["telefone"])),
                        chave = Crypt.Encode(chave)
                    });
                }

                reader.Close();
                session.Close();

                return lista;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
