using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ContaDB
    {
        public void Salvar(Conta variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Conta (conta,entrada,saida,banco,cc,convenio,carteira,agencia,contrato,cnpj,nome) VALUES (@conta,@entrada,@saida,@banco,@cc,@convenio,@carteira,@agencia,@contrato,@cnpj,@nome) ");
                query.SetParameter("conta", variavel.conta)
                    .SetParameter("entrada", variavel.entrada)
                    .SetParameter("saida", variavel.saida)
                    .SetParameter("banco", variavel.banco)
                    .SetParameter("cc", variavel.cc)
                    .SetParameter("convenio", variavel.convenio)
                    .SetParameter("carteira", variavel.carteira)
                    .SetParameter("agencia", variavel.agencia)
                    .SetParameter("contrato", variavel.contrato)
                    .SetParameter("cnpj", variavel.cnpj)
                    .SetParameter("nome", variavel.nome);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Conta variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Conta SET conta = @conta,entrada = @entrada,saida = @saida,banco = @banco,cc = @cc,convenio = @convenio,carteira = @carteira,agencia = @agencia,contrato = @contrato,cnpj = @cnpj,nome = @nome WHERE codigo = @codigo) ");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("entrada", variavel.entrada)
                    .SetParameter("saida", variavel.saida)
                    .SetParameter("banco", variavel.banco)
                    .SetParameter("cc", variavel.cc)
                    .SetParameter("convenio", variavel.convenio)
                    .SetParameter("carteira", variavel.carteira)
                    .SetParameter("agencia", variavel.agencia)
                    .SetParameter("contrato", variavel.contrato)
                    .SetParameter("cnpj", variavel.cnpj)
                    .SetParameter("nome", variavel.nome);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Conta variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Conta WHERE codigo = @codigo) ");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Conta Buscar(int codigo)
        {
            try
            {
                Conta conta = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM conta WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    conta = new Conta(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["conta"]), Convert.ToInt32(reader["entrada"]), Convert.ToInt32(reader["saida"]), Convert.ToString(reader["banco"]), Convert.ToString(reader["cc"]), Convert.ToString(reader["convenio"]), Convert.ToString(reader["carteira"]), Convert.ToString(reader["agencia"]), Convert.ToString(reader["contrato"]), Convert.ToString(reader["cnpj"]), Convert.ToString(reader["nome"]));
                }
                reader.Close();
                session.Close();

                return conta;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Conta> Listar()
        {
            try
            {
                List<Conta> conta = new List<Conta>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM conta");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    conta.Add(new Conta(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["conta"]), Convert.ToInt32(reader["entrada"]), Convert.ToInt32(reader["saida"]), Convert.ToString(reader["banco"]), Convert.ToString(reader["cc"]), Convert.ToString(reader["convenio"]), Convert.ToString(reader["carteira"]), Convert.ToString(reader["agencia"]), Convert.ToString(reader["contrato"]), Convert.ToString(reader["cnpj"]), Convert.ToString(reader["nome"])));
                }
                reader.Close();
                session.Close();

                return conta;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
