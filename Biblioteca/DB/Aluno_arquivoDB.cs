using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Aluno_arquivoDB
    {
        //Falta fazer 
        //codigo, arquivo, aluno, data, hora
        public void Salvar(Aluno_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_arquivo (arquivo, aluno, data, hora) VALUES (@arquivo, @aluno, @data, @hora) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("arquivo", variavel.arquivo.codigo)
                    .SetParameter("hora", variavel.hora);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_arquivo SET arquivo = @arquivo, aluno = @arquivo, data = @data, hora = @hora WHERE codigo = @codigo");
                query.SetParameter("data", variavel.data)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("arquivo", variavel.arquivo.codigo)
                    .SetParameter("hora", variavel.hora)
                    .SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Aluno_arquivo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Aluno_arquivo WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Aluno_arquivo Buscar(int codigo)
        {
            try
            {
                Aluno_arquivo Arquivo = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) as codigo, isnull(arquivo, 0) as arquivo, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data, isnull(hora, '01/01/1900') as hora FROM Arquivo_aluno WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Arquivo = new Aluno_arquivo(Convert.ToInt32(reader["codigo"]), new Arquivo() { codigo = Convert.ToInt32(reader["arquivo"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"]));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_arquivo> Listar()
        {
            try
            {
                List<Aluno_arquivo> Arquivo = new List<Aluno_arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) as codigo, isnull(arquivo, 0) as arquivo, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data, isnull(hora, '01/01/1900') as hora FROM Arquivo_aluno");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Arquivo.Add(new Aluno_arquivo(Convert.ToInt32(reader["codigo"]), new Arquivo() { codigo = Convert.ToInt32(reader["arquivo"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_arquivo> Listar(Aluno aluno)
        {
            try
            {
                List<Aluno_arquivo> Arquivo = new List<Aluno_arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) as codigo, isnull(arquivo, 0) as arquivo, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data, isnull(hora, '01/01/1900') as hora FROM Arquivo_aluno WHERE aluno = @aluno ORDER BY arquivo, data")
                    .SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Arquivo.Add(new Aluno_arquivo(Convert.ToInt32(reader["codigo"]), new Arquivo() { codigo = Convert.ToInt32(reader["arquivo"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_arquivo> Listar(Arquivo arquivo)
        {
            try
            {
                List<Aluno_arquivo> Arquivo = new List<Aluno_arquivo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) as codigo, isnull(arquivo, 0) as arquivo, isnull(aluno, 0) as aluno, isnull(data, '01/01/1900') as data, isnull(hora, '01/01/1900') as hora FROM Arquivo_aluno WHERE aluno = @arquivo ORDER BY data, hora, aluno")
                    .SetParameter("arquivo", arquivo.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Arquivo.Add(new Aluno_arquivo(Convert.ToInt32(reader["codigo"]), new Arquivo() { codigo = Convert.ToInt32(reader["arquivo"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["hora"])));
                }
                reader.Close();
                session.Close();

                return Arquivo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
