using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Programacao_palestranteDB
    {
        public void Salvar(Programacao_palestrante variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Programacao_palestrante VALUES (@programacao_id, @palestrante_id) ");
                query.SetParameter("programacao_id", variavel.programacao_id.programacao_id)
                    .SetParameter("palestrante_id", variavel.palestrante_id.palestrante_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Programacao_palestrante variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Programacao_palestrante WHERE programacao_id = @programacao_id and palestrante_id = @palestrante_id");
                query.SetParameter("programacao_id", variavel.programacao_id.programacao_id)
                    .SetParameter("palestrante_id", variavel.palestrante_id.palestrante_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Programacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Programacao_palestrante WHERE programacao_id = @programacao_id");
                query.SetParameter("programacao_id", variavel.programacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Programacao_palestrante Buscar(int programacao_id, int palestrante_id)
        {
            try
            {
                Programacao_palestrante contaEnvio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao_palestrante WHERE programacao_id = @programacao_id AND palestrante_id = @palestrante_id");
                quey.SetParameter("programacao_id", programacao_id)
                    .SetParameter("palestrante_id", palestrante_id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contaEnvio = new Programacao_palestrante(new ProgramacaoDB().Buscar(Convert.ToInt32(reader["programacao_id"])), new PalestranteDB().Buscar(Convert.ToInt32(reader["palestrante_id"])));
                }
                reader.Close();
                session.Close();

                return contaEnvio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao_palestrante> Listar()
        {
            try
            {
                List<Programacao_palestrante> contaEnvio = new List<Programacao_palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao_palestrante");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contaEnvio.Add(new Programacao_palestrante(new ProgramacaoDB().Buscar(Convert.ToInt32(reader["programacao_id"])), new PalestranteDB().Buscar(Convert.ToInt32(reader["palestrante_id"]))));
                }
                reader.Close();
                session.Close();

                return contaEnvio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao_palestrante> Listar(Programacao programacao)
        {
            try
            {
                List<Programacao_palestrante> contaEnvio = new List<Programacao_palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao_palestrante WHERE programacao_id = @programacao_id");
                quey.SetParameter("programacao_id", programacao.programacao_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contaEnvio.Add(new Programacao_palestrante(programacao, new PalestranteDB().Buscar(Convert.ToInt32(reader["palestrante_id"]))));
                }
                reader.Close();
                session.Close();

                return contaEnvio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao_palestrante> ListarOrdenado(Programacao programacao)
        {
            try
            {
                List<Programacao_palestrante> contaEnvio = new List<Programacao_palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT pp.* FROM cenbrap.Programacao_palestrante pp left join cenbrap.palestrante p on p.palestrante_id = pp.palestrante_id WHERE pp.programacao_id = @programacao_id order by p.nome");
                quey.SetParameter("programacao_id", programacao.programacao_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contaEnvio.Add(new Programacao_palestrante(programacao, new PalestranteDB().Buscar(Convert.ToInt32(reader["palestrante_id"]))));
                }
                reader.Close();
                session.Close();

                return contaEnvio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Programacao_palestrante> Listar(Palestrante palestrante)
        {
            try
            {
                List<Programacao_palestrante> contaEnvio = new List<Programacao_palestrante>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Programacao_palestrante WHERE palestrante_id = @palestrante_id");
                quey.SetParameter("palestrante_id", palestrante.palestrante_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contaEnvio.Add(new Programacao_palestrante(new ProgramacaoDB().Buscar(Convert.ToInt32(reader["programacao_id"])), palestrante));
                }
                reader.Close();
                session.Close();

                return contaEnvio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
