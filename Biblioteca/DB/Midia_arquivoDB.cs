using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Midia_arquivoDB
    {
        public void Salvar(Midia_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Midia_arquivo (midia_id, arquivo, texto) VALUES (@midia_id, arquivo, texto) ");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("texto", variavel.texto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Midia_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Midia_arquivo SET arquivo = @arquivo, texto = @texto, midia_id = @midia_id WHERE midia_arquivo_id = @midia_arquivo_id;");
                query.SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("midia_arquivo_id", variavel.midia_arquivo_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Midia_arquivo WHERE midia_arquivo_id = @midia_arquivo_id;");
                query.SetParameter("midia_arquivo_id", variavel.midia_arquivo_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Midia_arquivo Buscar(int id)
        {
            Midia_arquivo retorno;
            try
            {
                retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Midia_arquivo WHERE midia_arquivo_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Midia_arquivo(Convert.ToInt32(reader["midia_arquivo_id"]), new Midia() { midia_id = Convert.ToInt32(reader["midia_id"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia_arquivo> Listar()
        {
            List<Midia_arquivo> retorno;
            try
            {
                retorno = new List<Midia_arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia_tipo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia_arquivo(Convert.ToInt32(reader["midia_arquivo_id"]), new Midia() { midia_id = Convert.ToInt32(reader["midia_id"]) }, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia_arquivo> Listar(Midia midia)
        {
            List<Midia_arquivo> retorno;
            try
            {
                retorno = new List<Midia_arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia_tipo WHERE midia_id = @id");
                quey.SetParameter("id", midia.midia_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia_arquivo(Convert.ToInt32(reader["midia_arquivo_id"]), midia, Convert.ToString(reader["arquivo"]), Convert.ToString(reader["texto"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
