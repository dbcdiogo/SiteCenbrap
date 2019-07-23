using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PaginasDB
    {
        public void Salvar(Paginas paginas)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO paginas (titulo, texto, dominio) VALUES (@titulo, @texto, @dominio) ");
                query.SetParameter("titulo", paginas.titulo)
                    .SetParameter("texto", paginas.texto)
                    .SetParameter("dominio", paginas.dominio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Paginas paginas)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE paginas SET titulo = @titulo, texto = @texto, dominio = @dominio WHERE paginas_id = @paginas_id");
                query.SetParameter("titulo", paginas.titulo)
                    .SetParameter("texto", paginas.texto)
                    .SetParameter("dominio", paginas.dominio)
                    .SetParameter("paginas_id", paginas.paginas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Paginas paginas)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM paginas WHERE paginas_id = @paginas_id");
                query.SetParameter("paginas_id", paginas.paginas_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Paginas Buscar(int paginas_id)
        {
            try
            {
                Paginas paginas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM paginas WHERE paginas_id = @paginas_id");
                quey.SetParameter("paginas_id", paginas_id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    paginas = new Paginas(Convert.ToInt32(reader["paginas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"]));
                }
                reader.Close();
                session.Close();

                return paginas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Paginas> Listar()
        {
            try
            {
                List<Paginas> paginas = new List<Paginas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM paginas ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    paginas.Add(new Paginas(Convert.ToInt32(reader["paginas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"])));
                }
                reader.Close();
                session.Close();

                return paginas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Paginas> Listar(string dominio)
        {
            try
            {
                List<Paginas> paginas = new List<Paginas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM paginas WHERE dominio = @dominio ORDER BY titulo");
                quey.SetParameter("dominio", dominio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    paginas.Add(new Paginas(Convert.ToInt32(reader["paginas_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["dominio"])));
                }
                reader.Close();
                session.Close();

                return paginas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
