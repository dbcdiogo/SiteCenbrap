using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cliente_grupo_subgrupoDB
    {
        public void Salvar(Cliente_grupo_subgrupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cliente_grupo_subgrupo (grupo,subgrupo) VALUES (@grupo,@subgrupo) ");
                query.SetParameter("grupo", variavel.grupo.codigo)
                    .SetParameter("subgrupo", variavel.subgrupo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cliente_grupo_subgrupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cliente_grupo_subgrupo SET grupo = @grupo, subgrupo = @subgrupo WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("grupo", variavel.grupo.codigo)
                    .SetParameter("subgrupo", variavel.subgrupo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cliente_grupo_subgrupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cliente_grupo_subgrupo WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cliente_grupo_subgrupo Buscar(int codigo)
        {
            try
            {
                Cliente_grupo_subgrupo cliente_grupo_subgrupo = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_grupo_subgrupo WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente_grupo_subgrupo = new Cliente_grupo_subgrupo(Convert.ToInt32(reader["codigo"]), new Cliente_grupo(){ codigo = Convert.ToInt32(reader["grupo"]) }, Convert.ToString(reader["subgrupo"]));
                }
                reader.Close();
                session.Close();

                return cliente_grupo_subgrupo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cliente_grupo_subgrupo> Listar()
        {
            try
            {
                List<Cliente_grupo_subgrupo> cliente_grupo_subgrupo = new List<Cliente_grupo_subgrupo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_grupo_subgrupo");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente_grupo_subgrupo.Add(new Cliente_grupo_subgrupo(Convert.ToInt32(reader["codigo"]), new Cliente_grupo() { codigo = Convert.ToInt32(reader["grupo"]) }, Convert.ToString(reader["subgrupo"])));
                }
                reader.Close();
                session.Close();

                return cliente_grupo_subgrupo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
