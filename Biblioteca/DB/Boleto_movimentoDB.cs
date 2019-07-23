using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Boleto_movimentoDB
    {
        public void Salvar(Boleto_movimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Boleto_movimento (boleto,movimento_codigo,movimento_descricao,data,retorno) VALUES (@boleto,@movimento_codigo,@movimento_descricao,@data,@retorno) ");
                query.SetParameter("boleto", variavel.boleto.codigo)
                    .SetParameter("movimento_codigo", variavel.movimento_codigo)
                    .SetParameter("movimento_descricao", variavel.movimento_descricao)
                    .SetParameter("data", variavel.data)
                    .SetParameter("retorno", variavel.retorno);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Boleto_movimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Boleto_movimento SET boleto = @boleto, movimento_codigo = @movimento_codigo, movimento_descricao = @movimento_descricao, data = @data, retorno = @retorno WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("boleto", variavel.boleto.codigo)
                    .SetParameter("movimento_codigo", variavel.movimento_codigo)
                    .SetParameter("movimento_descricao", variavel.movimento_descricao)
                    .SetParameter("data", variavel.data)
                    .SetParameter("retorno", variavel.retorno);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Boleto_movimento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Boleto_movimento WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Boleto_movimento Buscar(int codigo)
        {
            try
            {
                Boleto_movimento boleto_movimento = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM boleto_movimento WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto_movimento = new Boleto_movimento(Convert.ToInt32(reader["codigo"]), new Boleto() { codigo = Convert.ToInt32(reader["boleto"]) }, Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["retorno"]));
                }
                reader.Close();
                session.Close();

                return boleto_movimento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Boleto_movimento> Listar(int boleto)
        {
            try
            {
                List<Boleto_movimento> boleto_movimento = new List<Boleto_movimento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM boleto_movimento WHERE boleto = @boleto ORDER BY data DESC");
                quey.SetParameter("boleto", boleto);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    boleto_movimento.Add(new Boleto_movimento(Convert.ToInt32(reader["codigo"]), new Boleto() { codigo = Convert.ToInt32(reader["boleto"]) }, Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["retorno"])));
                }
                reader.Close();
                session.Close();

                return boleto_movimento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
