using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Boleto_avulsoDB
    {
        public void Salvar(Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Boleto_avulso (aluno_pgto,cliente,data,vencimento,data_pgto,valor,situacao,obs,descricao) VALUES (@aluno_pgto,@cliente,@data,@vencimento,@data_pgto,@valor,@situacao,@obs,@descricao) ");
                query.SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("data_pgto", variavel.data_pgto)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("descricao", variavel.descricao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Boleto_avulso (aluno_pgto,cliente,data,vencimento,data_pgto,valor,situacao,obs,descricao) VALUES (@aluno_pgto,@cliente,@data,@vencimento,@data_pgto,@valor,@situacao,@obs,@descricao) ");
                query.SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("data_pgto", variavel.data_pgto)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("descricao", variavel.descricao);
                query.ExecuteUpdate();
                session.Close();

                int id = 0;

                DBSession session1 = new DBSession();
                Query quey = session1.CreateQuery("SELECT codigo FROM boleto_avulso WHERE cliente = @cliente AND vencimento = @vencimento ORDER BY codigo DESC");
                quey.SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("vencimento", variavel.vencimento.Date);
                    //.SetParameter("valor", variavel.valor);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["codigo"]);
                }
                reader.Close();
                session1.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        
        public void Alterar(Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Boleto_avulso SET aluno_pgto = @aluno_pgto, cliente = @cliente, data = @data, vencimento = @vencimento, data_pgto = @data_pgto, valor = @valor, situacao = @situacao, obs = @obs, descricao = @descricao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("data_pgto", variavel.data_pgto)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("descricao", variavel.descricao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Boleto_avulso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Boleto_avulso Buscar(int codigo)
        {
            try
            {
                Boleto_avulso boleto_avulso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, aluno_pgto, cliente, isnull(data, '01/01/1900') as data, isnull(vencimento, '01/01/1900') as vencimento, isnull(data_pgto, '01/01/1900') as data_pgto, valor, situacao, obs, descricao FROM boleto_avulso WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto_avulso = new Boleto_avulso(Convert.ToInt32(reader["codigo"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["aluno_pgto"]) }, new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToDateTime(reader["data_pgto"]), Convert.ToDouble(reader["valor"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["descricao"]));
                }
                reader.Close();
                session.Close();

                return boleto_avulso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Boleto_avulso> Listar(int boleto)
        {
            try
            {
                List<Boleto_avulso> boleto_avulso = new List<Boleto_avulso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM boleto_avulso WHERE boleto = @boleto ORDER BY data DESC");
                quey.SetParameter("boleto", boleto);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    boleto_avulso.Add(new Boleto_avulso(Convert.ToInt32(reader["codigo"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["aluno_pgto"]) }, new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToDateTime(reader["data_pgto"]), Convert.ToDouble(reader["valor"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["descricao"])));
                }
                reader.Close();
                session.Close();

                return boleto_avulso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
