using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ContaEnvioDB
    {
        public void Salvar(ContaEnvio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO ContaEnvio (titulo, email, usuario, senha) VALUES (@titulo, @email, @usuario, @senha) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("email", variavel.email)
                    .SetParameter("usuario", variavel.usuario)
                    .SetParameter("senha", variavel.senha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(ContaEnvio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE ContaEnvio SET titulo = @titulo, email = @email, usuario = @usuario, senha = @senha WHERE contaEnvio_id = @ContaEnvio_id");
                query.SetParameter("ContaEnvio_id", variavel.contaEnvio_id)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("email", variavel.email)
                    .SetParameter("usuario", variavel.usuario)
                    .SetParameter("senha", variavel.senha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(ContaEnvio variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM ContaEnvio WHERE contaEnvio_id = @contaEnvio_id");
                query.SetParameter("contaEnvio_id", variavel.contaEnvio_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public ContaEnvio Buscar(string email)
        {
            try
            {
                ContaEnvio contaEnvio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contaEnvio WHERE email = @email");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contaEnvio = new ContaEnvio(Convert.ToInt32(reader["contaEnvio_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["email"]), Convert.ToString(reader["usuario"]), Convert.ToString(reader["senha"]));
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

        public ContaEnvio Buscar(int id)
        {
            try
            {
                ContaEnvio contaEnvio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contaEnvio WHERE contaEnvio_id = @contaEnvio_id");
                quey.SetParameter("contaEnvio_id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contaEnvio = new ContaEnvio(Convert.ToInt32(reader["contaEnvio_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["email"]), Convert.ToString(reader["usuario"]), Convert.ToString(reader["senha"]));
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

        public List<ContaEnvio> Listar()
        {
            try
            {
                List<ContaEnvio> contaEnvio = new List<ContaEnvio>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contaEnvio ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contaEnvio.Add(new ContaEnvio(Convert.ToInt32(reader["contaEnvio_id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["email"]), Convert.ToString(reader["usuario"]), Convert.ToString(reader["senha"])));
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
