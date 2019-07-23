using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class ProfessorDB
    {
        public void Salvar(Professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Professor (data, painel, nome, email, obs, graduacao, titulacao, instituicao, graduacao_data, rg, rg_emissor, cpf, endereco, bairro, cidade, estado, cep, telefone, telefone1, rg_2via, nascimento, banco, agencia, conta, endereco1, bairro1, cidade1, estado1, cep1, lates, banco1, agencia1, conta1, titular, titular1, especialidade) VALUES (@data, @painel, @nome, @email, @obs, @graduacao, @titulacao, @instituicao, @graduacao_data, @rg, @rg_emissor, @cpf, @endereco, @bairro, @cidade, @estado, @cep, @telefone, @telefone1, @rg_2via, @nascimento, @banco, @agencia, @conta, @endereco1, @bairro1, @cidade1, @estado1, @cep1, @lates, @banco1, @agencia1, @conta1, @titular, @titular1, @especialidade) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("graduacao", variavel.graduacao)
                    .SetParameter("titulacao", variavel.titulacao)
                    .SetParameter("instituicao", variavel.instituicao)
                    .SetParameter("graduacao_data", variavel.graduacao_data)
                    .SetParameter("rg", variavel.rg)
                    .SetParameter("rg_emissor", variavel.rg_emissor)
                    .SetParameter("cpf", variavel.cpf)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("telefone1", variavel.telefone1)
                    .SetParameter("rg_2via", variavel.rg_2via)
                    .SetParameter("nascimento", variavel.nascimento)
                    .SetParameter("banco", variavel.banco)
                    .SetParameter("agencia", variavel.agencia)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("endereco1", variavel.endereco1)
                    .SetParameter("bairro1", variavel.bairro1)
                    .SetParameter("cidade1", variavel.cidade1)
                    .SetParameter("estado1", variavel.estado1)
                    .SetParameter("cep1", variavel.cep1)
                    .SetParameter("lates", variavel.lates)
                    .SetParameter("banco1", variavel.banco1)
                    .SetParameter("agencia1", variavel.agencia1)
                    .SetParameter("conta1", variavel.conta1)
                    .SetParameter("titular", variavel.titular)
                    .SetParameter("titular1", variavel.titular1)
                    .SetParameter("especialidade", variavel.especialidade);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Professor SET data = @data , painel = @painel , nome = @nome , email = @email , obs = @obs , graduacao = @graduacao , titulacao = @titulacao , instituicao = @instituicao , graduacao_data = @graduacao_data , rg = @rg , rg_emissor = @rg_emissor , cpf = @cpf , endereco = @endereco , bairro = @bairro , cidade = @cidade , estado = @estado , cep = @cep , telefone = @telefone , telefone1 = @telefone1 , rg_2via = @rg_2via , nascimento = @nascimento , banco = @banco , agencia = @agencia , conta = @conta , endereco1 = @endereco1 , bairro1 = @bairro1 , cidade1 = @cidade1 , estado1 = @estado1 , cep1 = @cep1 , lates = @lates , banco1 = @banco1 , agencia1 = @agencia1 , conta1 = @conta1 , titular = @titular , titular1 = @titular1 , especialidade = @especialidade WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo).SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("graduacao", variavel.graduacao)
                    .SetParameter("titulacao", variavel.titulacao)
                    .SetParameter("instituicao", variavel.instituicao)
                    .SetParameter("graduacao_data", variavel.graduacao_data)
                    .SetParameter("rg", variavel.rg)
                    .SetParameter("rg_emissor", variavel.rg_emissor)
                    .SetParameter("cpf", variavel.cpf)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("telefone1", variavel.telefone1)
                    .SetParameter("rg_2via", variavel.rg_2via)
                    .SetParameter("nascimento", variavel.nascimento)
                    .SetParameter("banco", variavel.banco)
                    .SetParameter("agencia", variavel.agencia)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("endereco1", variavel.endereco1)
                    .SetParameter("bairro1", variavel.bairro1)
                    .SetParameter("cidade1", variavel.cidade1)
                    .SetParameter("estado1", variavel.estado1)
                    .SetParameter("cep1", variavel.cep1)
                    .SetParameter("lates", variavel.lates)
                    .SetParameter("banco1", variavel.banco1)
                    .SetParameter("agencia1", variavel.agencia1)
                    .SetParameter("conta1", variavel.conta1)
                    .SetParameter("titular", variavel.titular)
                    .SetParameter("titular1", variavel.titular1)
                    .SetParameter("especialidade", variavel.especialidade);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Professor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Professor WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Professor Buscar(int codigo)
        {
            try
            {
                Professor Professor = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Professor WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Professor = new Professor(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["titulacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["graduacao_data"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToString(reader["cpf"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToDateTime(reader["nascimento"]), Convert.ToString(reader["banco"]), Convert.ToString(reader["agencia"]), Convert.ToString(reader["conta"]), Convert.ToString(reader["endereco1"]), Convert.ToString(reader["bairro1"]), Convert.ToString(reader["cidade1"]), Convert.ToString(reader["estado1"]), Convert.ToString(reader["cep1"]), Convert.ToString(reader["lates"]), Convert.ToString(reader["banco1"]), Convert.ToString(reader["agencia1"]), Convert.ToString(reader["conta1"]), Convert.ToString(reader["titular"]), Convert.ToString(reader["titular1"]), Convert.ToString(reader["especialidade"]));
                }
                reader.Close();
                session.Close();

                return Professor;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Professor> Listar()
        {
            try
            {
                List<Professor> Professor = new List<Professor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Professor ORDER BY nome");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    Professor.Add(new Professor(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["titulacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["graduacao_data"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToString(reader["cpf"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["telefone1"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToDateTime(reader["nascimento"]), Convert.ToString(reader["banco"]), Convert.ToString(reader["agencia"]), Convert.ToString(reader["conta"]), Convert.ToString(reader["endereco1"]), Convert.ToString(reader["bairro1"]), Convert.ToString(reader["cidade1"]), Convert.ToString(reader["estado1"]), Convert.ToString(reader["cep1"]), Convert.ToString(reader["lates"]), Convert.ToString(reader["banco1"]), Convert.ToString(reader["agencia1"]), Convert.ToString(reader["conta1"]), Convert.ToString(reader["titular"]), Convert.ToString(reader["titular1"]), Convert.ToString(reader["especialidade"])));
                }
                reader.Close();
                session.Close();

                return Professor;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
