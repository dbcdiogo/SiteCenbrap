using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Email_tipoDB
    {
        public void Alterar(Email_tipo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Email_tipo SET tipo = @tipo, data = @data, painel = @painel, titulo = @titulo, texto = @texto, assunto = @assunto WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("tipo", variavel.tipo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("assunto", variavel.assunto)
                    .SetParameter("painel", variavel.painel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        
        public Email_tipo Buscar(int tipo, string titulo)
        {
            try
            {
                Email_tipo email = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from email_tipo WHERE tipo = @tipo AND titulo = @titulo");
                quey.SetParameter("tipo", tipo).SetParameter("titulo", titulo );
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    email = new Email_tipo()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        data = Convert.ToDateTime(reader["data"]),
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"])},
                        titulo = Convert.ToString(reader["titulo"]),
                        texto = Convert.ToString(reader["texto"]),
                        assunto = Convert.ToString(reader["assunto"])
                    };
                }

                reader.Close();
                session.Close();

                return email;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Email_tipo> Listar()
        {
            try
            {
                List<Email_tipo> email = new List<Email_tipo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from email_tipo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    email.Add(new Email_tipo()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        data = Convert.ToDateTime(reader["data"]),
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        titulo = Convert.ToString(reader["titulo"]),
                        texto = Convert.ToString(reader["texto"]),
                        assunto = Convert.ToString(reader["assunto"])
                    });
                }

                reader.Close();
                session.Close();

                return email;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
