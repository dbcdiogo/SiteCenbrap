using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class CertificadoraDB
    {
        public void Salvar(Certificadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Certificadora (titulo, titulo_abreviado) VALUES (@titulo, @titulo_abreviado) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo_abreviado", variavel.titulo_abreviado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Certificadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Certificadora SET titulo = @titulo, titulo_abreviado = @titulo_abreviado WHERE certificadora_id = @id");
                query.SetParameter("id", variavel.certificadora_id)
                    .SetParameter("titulo_abreviado", variavel.titulo_abreviado)
                    .SetParameter("titulo", variavel.titulo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Certificadora variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Certificadora WHERE certificadora_id = @id");
                query.SetParameter("id", variavel.certificadora_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Certificadora Buscar(int id)
        {
            try
            {
                Certificadora certificadora = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Certificadora WHERE certificadora_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    certificadora = new Certificadora(Convert.ToInt32(reader["certificadora_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_abreviado"]));
                }
                reader.Close();
                session.Close();

                return certificadora;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Certificadora> Listar()
        {
            try
            {
                List<Certificadora> certificadora = new List<Certificadora>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Certificadora ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    certificadora.Add(new Certificadora(Convert.ToInt32(reader["certificadora_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo_abreviado"])));
                }
                reader.Close();
                session.Close();

                return certificadora;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
