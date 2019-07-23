using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PalestranteDB
    {
        public void Salvar(Palestrante variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Palestrante (nome, titulo, trabalho, foto, curriculo, dominio, ordem) VALUES (@nome, @titulo, @trabalho, @foto, @curriculo, @dominio, @ordem) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("foto", variavel.foto)
                    .SetParameter("trabalho", variavel.trabalho)
                    .SetParameter("curriculo", variavel.curriculo)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Palestrante variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Palestrante SET dominio = @dominio, nome = @nome, titulo = @titulo, trabalho = @trabalho, foto = @foto, curriculo = @curriculo, ordem = @ordem WHERE palestrante_id = @id");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("dominio", variavel.dominio)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("foto", variavel.foto)
                    .SetParameter("trabalho", variavel.trabalho)
                    .SetParameter("curriculo", variavel.curriculo)
                    .SetParameter("id", variavel.palestrante_id)
                    .SetParameter("ordem", variavel.ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(int id, int ordem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Palestrante SET ordem = @ordem WHERE palestrante_id = @id");
                query.SetParameter("id", id)
                    .SetParameter("ordem", ordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Palestrante variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Palestrante WHERE Palestrante_id = @id; DELETE FROM Programacao_Palestrante WHERE Palestrante_id = @id;");
                query.SetParameter("id", variavel.palestrante_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Palestrante Buscar(int id)
        {
            try
            {
                Palestrante palestrante = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante WHERE Palestrante_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    palestrante = new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"]));
                }
                reader.Close();
                session.Close();

                return palestrante;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Palestrante Buscar(string dominio, string nome, string titulo, int ordem)
        {
            try
            {
                Palestrante palestrante = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante WHERE dominio = @dominio AND nome = @nome AND titulo = @titulo AND ordem = @ordem");
                quey.SetParameter("dominio", dominio)
                    .SetParameter("nome", nome)
                    .SetParameter("titulo", titulo)
                    .SetParameter("ordem", ordem);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    palestrante = new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"]));
                }
                reader.Close();
                session.Close();

                return palestrante;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        public List<Palestrante> Listar()
        {
            try
            {
                List<Palestrante> dataLote = new List<Palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante ORDER BY dominio, ordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Palestrante> Listar(string dominio)
        {
            try
            {
                List<Palestrante> dataLote = new List<Palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante WHERE dominio = @dominio ORDER BY dominio, ordem");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Palestrante> ListarOrdenado(string dominio)
        {
            try
            {
                List<Palestrante> dataLote = new List<Palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante WHERE dominio = @dominio ORDER BY dominio, nome");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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

        public List<Palestrante> Listar(string dominio, int ordem)
        {
            try
            {
                List<Palestrante> dataLote = new List<Palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Palestrante WHERE dominio = @dominio AND ordem >= @ordem ORDER BY dominio, ordem");
                quey.SetParameter("dominio", dominio)
                    .SetParameter("ordem", ordem);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Palestrante(Convert.ToInt32(reader["palestrante_id"]), Convert.ToString(reader["dominio"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["trabalho"]), Convert.ToString(reader["foto"]), Convert.ToString(reader["curriculo"]), Convert.ToInt32(reader["ordem"])));
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

        public void Ordenar(int id, int ordem, string dominio)
        {
            try
            {
                foreach(var p in Listar(dominio, ordem))
                {
                    p.ordem = ordem + 1;
                    Alterar(p.palestrante_id, p.ordem);
                }
                Alterar(id, ordem);

                Ordenar(dominio);
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public void Ordenar(string dominio)
        {
            try
            {
                int cont = 1;
                foreach (var p in Listar(dominio))
                {
                    Alterar(p.palestrante_id, cont);
                    cont++;
                }

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
