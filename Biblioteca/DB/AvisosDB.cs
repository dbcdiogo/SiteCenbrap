using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AvisosDB
    {      
        
        public List<Avisos> Listar(int curso = 0, int aluno = 0)
        {
            try
            {
                List<Avisos> dataLote = new List<Avisos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT a.codigo, a.data, a.aluno, a.titulo, a.texto, a.arquivo, a.texto, a.urgente, isnull(av.data,'') as datav, case when av.codigo is null then 0 else 1 end as visualizado FROM Avisos a left join avisos_visualizar av on av.avisos = a.codigo and av.aluno = @aluno WHERE a.curso = @curso order by data desc");
                quey.SetParameter("curso", curso);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Avisos(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["visualizado"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["urgente"]), Convert.ToDateTime(reader["datav"])));
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

        public Avisos Buscar(int codigo = 0, int aluno = 0)
        {
            try
            {
                Avisos dataLote = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT a.codigo, a.data, a.aluno, a.titulo, a.texto, a.arquivo, a.texto, a.urgente, isnull(av.data,'') as datav, case when av.codigo is null then 0 else 1 end as visualizado FROM Avisos a left join avisos_visualizar av on av.avisos = a.codigo and av.aluno = @aluno WHERE a.codigo = @codigo order by data desc");
                quey.SetParameter("codigo", codigo);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote = new Avisos(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["visualizado"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["urgente"]), Convert.ToDateTime(reader["datav"]));
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

        public void GravaVisualizado(int aviso, int aluno)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO avisos_visualizar (avisos, aluno, data) values (@aviso, @aluno, getdate())");
                query.SetParameter("aviso", aviso)
                    .SetParameter("aluno", aluno);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
