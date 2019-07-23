using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cliente_grupoDB
    {
        public void Salvar(Cliente_grupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cliente_grupo (grupo,cod_municipio,cidade,estado,negativado) VALUES (@grupo,@cod_municipio,@cidade,@estado,@negativado) ");
                query.SetParameter("grupo", variavel.grupo)
                    .SetParameter("cod_municipio", variavel.cod_municipio)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("negativado", variavel.negativado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cliente_grupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cliente_grupo SET grupo = @grupo, cod_municipio = @cod_municipio, cidade = @cidade, estado = @estado, negativado = @negativado WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("grupo", variavel.grupo)
                    .SetParameter("cod_municipio", variavel.cod_municipio)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("negativado", variavel.negativado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cliente_grupo variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cliente_grupo WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cliente_grupo Buscar(int codigo)
        {
            try
            {
                Cliente_grupo cliente_grupo = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_grupo WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente_grupo = new Cliente_grupo(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["grupo"]), Convert.ToString(reader["cod_municipio"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToInt32(reader["negativado"]));
                }
                reader.Close();
                session.Close();

                return cliente_grupo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Cliente_grupo Buscar(string grupo)
        {
            try
            {
                Cliente_grupo cliente_grupo = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_grupo WHERE grupo = @grupo");
                quey.SetParameter("grupo", grupo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente_grupo = new Cliente_grupo(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["grupo"]), Convert.ToString(reader["cod_municipio"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToInt32(reader["negativado"]));
                }
                reader.Close();
                session.Close();

                return cliente_grupo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cliente_grupo> Listar()
        {
            try
            {
                List<Cliente_grupo> cliente_grupo = new List<Cliente_grupo>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente_grupo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    cliente_grupo.Add(new Cliente_grupo(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["grupo"]), Convert.ToString(reader["cod_municipio"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToInt32(reader["negativado"])));
                }
                reader.Close();
                session.Close();

                return cliente_grupo;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
