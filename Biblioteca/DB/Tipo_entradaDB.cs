using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class Tipo_entradaDB
    {
        public void Salvar(Tipo_entrada t)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Tipo_entrada (tipo) VALUES (@tipo) ");
                query.SetParameter("tipo", t.tipo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Tipo_entrada t)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE tipo_entrada SET tipo = @tipo WHERE codigo = @codigo");
                query.SetParameter("tipo", t.tipo)
                    .SetParameter("codigo", t.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Tipo_entrada t)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM tipo_entrada WHERE codigo = @codigo");
                query.SetParameter("codigo", t.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Tipo_entrada Buscar(int codigo)
        {
            try
            {
                Tipo_entrada retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM tipo_entrada WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Tipo_entrada(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["tipo"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Tipo_entrada> Listar()
        {
            try
            {
                List<Tipo_entrada> retorno = new List<Tipo_entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM tipo_entrada ORDER BY tipo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add( new Tipo_entrada(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["tipo"])) );
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
