using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DeclaracaoDB
    {
        public void Salvar(Declaracao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Declaracao (data, titulo, texto) VALUES (@data, @titulo, @texto) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Declaracao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Declaracao (data, titulo, texto)  output INSERTED.codigo VALUES (@data, @titulo, @texto) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Declaracao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Declaracao SET data = @data, titulo = @titulo, texto = @texto WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Declaracao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Declaracao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Declaracao Buscar(int codigo)
        {
            try
            {
                Declaracao declaracao = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) as codigo, isnull(data, '01/01/1900') as data, isnull(titulo, '') as titulo, isnull(texto, '') as texto FROM Declaracao WHERE codigo = @codigo");
                query.SetParameter("codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    declaracao = new Declaracao(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["texto"]));
                }
                reader.Close();
                session.Close();

                return declaracao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Declaracao> Listar()
        {
            try
            {
                List<Declaracao> declaracao = new List<Declaracao>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) as codigo, isnull(data, '01/01/1900') as data, isnull(titulo, '') as titulo FROM Declaracao ORDER by titulo");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    declaracao.Add(new Declaracao(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), ""));
                }
                reader.Close();
                session.Close();

                return declaracao;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
