using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class FaqDB
    {
        public void Salvar(Faq faq)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO faq (titulo_curso, pergunta, resposta, ordem, dominio) VALUES (@titulo_curso, @pergunta, @resposta, @ordem, @dominio) ");
                query.SetParameter("titulo_curso", faq.titulo_curso.codigo)
                    .SetParameter("pergunta", faq.pergunta)
                    .SetParameter("resposta", faq.resposta)
                    .SetParameter("ordem", faq.ordem)
                    .SetParameter("dominio", faq.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Faq faq)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE faq SET titulo_curso = @titulo_curso, pergunta = @pergunta, resposta = @resposta, ordem = @ordem, dominio = @dominio WHERE faq_id = @faq_id");
                query.SetParameter("titulo_curso", faq.titulo_curso.codigo)
                    .SetParameter("pergunta", faq.pergunta)
                    .SetParameter("resposta", faq.resposta)
                    .SetParameter("ordem", faq.ordem)
                    .SetParameter("faq_id", faq.faq_id)
                    .SetParameter("dominio", faq.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Faq faq)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM faq WHERE faq_id = @faq_id");
                query.SetParameter("faq_id", faq.faq_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Faq Buscar(int faq_id)
        {
            try
            {
                Faq faq = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM faq WHERE faq_id = @faq_id");
                quey.SetParameter("faq_id", faq_id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    faq = new Faq(Convert.ToInt32(reader["faq_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) }, Convert.ToString(reader["pergunta"]), Convert.ToString(reader["resposta"]), Convert.ToInt32(reader["ordem"]), Convert.ToString(reader["dominio"]));
                }
                reader.Close();
                session.Close();

                return faq;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Faq> Listar(string dominio = "")
        {
            try
            {
                List<Faq> faq = new List<Faq>();

                string executar = "SELECT faq.faq_id, faq.titulo_curso, faq.pergunta, faq.resposta, faq.ordem, isnull((SELECT titulo_curso.titulo FROM titulo_curso WHERE titulo_curso.codigo = faq.titulo_curso), '') as titulo, faq.dominio FROM faq";
                if (dominio != "")
                    executar += " WHERE dominio = '" + dominio + "'";
                executar += " ORDER BY titulo, ordem";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    faq.Add(new Faq(Convert.ToInt32(reader["faq_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["pergunta"]), Convert.ToString(reader["resposta"]), Convert.ToInt32(reader["ordem"]), Convert.ToString(reader["dominio"])));
                }
                reader.Close();
                session.Close();

                return faq;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Faq> Listar(int codigo, string dominio = "cenbrap.com.br")
        {
            try
            {
                List<Faq> faq = new List<Faq>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT faq.faq_id, faq.titulo_curso, faq.pergunta, faq.resposta, faq.ordem, isnull((SELECT titulo_curso.titulo FROM titulo_curso WHERE titulo_curso.codigo = faq.titulo_curso), '') as titulo, faq.dominio FROM faq WHERE titulo_curso = @titulo_curso AND dominio = @dominio ORDER BY titulo, ordem");
                quey.SetParameter("titulo_curso", codigo)
                    .SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    faq.Add(new Faq(Convert.ToInt32(reader["faq_id"]), new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo"]) }, Convert.ToString(reader["pergunta"]), Convert.ToString(reader["resposta"]), Convert.ToInt32(reader["ordem"]), Convert.ToString(reader["dominio"])));
                }
                reader.Close();
                session.Close();

                return faq;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<int> Cursos(string dominio = "cenbrap.com.br")
        {
            try
            {
                List<int> faq = new List<int>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT DISTINCT faq.titulo_curso FROM faq WHERE dominio = @dominio GROUP BY faq.titulo_curso")
                    .SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    faq.Add(Convert.ToInt32(reader["titulo_curso"]));
                }
                reader.Close();
                session.Close();

                return faq;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
