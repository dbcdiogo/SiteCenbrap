using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ClienteDB
    {
        public void Salvar(Cliente variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cliente (aluno,grupo,subgrupo,tipo,nome,contato,cpf_cnpj,endereco,bairro,cidade,estado,cep,telefone,celular,fax,email,cod_municipio,numero,complemento,ativo,desconto,obs) VALUES (@aluno,@grupo,@subgrupo,@tipo,@nome,@contato,@cpf_cnpj,@endereco,@bairro,@cidade,@estado,@cep,@telefone,@celular,@fax,@email,@cod_municipio,@numero,@complemento,@ativo,@desconto,@obs) ");
                query.SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("grupo", variavel.grupo.codigo)
                    .SetParameter("subgrupo", variavel.subgrupo.codigo)
                    .SetParameter("tipo", variavel.tipo)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("contato", variavel.contato)
                    .SetParameter("cpf_cnpj", variavel.cpf_cnpj)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("fax", variavel.fax)
                    .SetParameter("email", variavel.email)
                    .SetParameter("cod_municipio", variavel.cod_municipio)
                    .SetParameter("numero", variavel.numero)
                    .SetParameter("complemento", variavel.complemento)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("obs", variavel.obs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cliente variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cliente SET aluno = @aluno, grupo = @grupo, subgrupo = @subgrupo, tipo = @tipo, nome = @nome, contato = @contato, cpf_cnpj = @cpf_cnpj, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, telefone = @telefone, celular = @celular, fax = @fax, email = @email, cod_municipio = @cod_municipio, numero = @numero, complemento = @complemento, ativo = @ativo, desconto = @desconto, obs = @obs WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("grupo", variavel.grupo.codigo)
                    .SetParameter("subgrupo", variavel.subgrupo.codigo)
                    .SetParameter("tipo", variavel.tipo)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("contato", variavel.contato)
                    .SetParameter("cpf_cnpj", variavel.cpf_cnpj)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("fax", variavel.fax)
                    .SetParameter("email", variavel.email)
                    .SetParameter("cod_municipio", variavel.cod_municipio)
                    .SetParameter("numero", variavel.numero)
                    .SetParameter("complemento", variavel.complemento)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("obs", variavel.obs);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cliente variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cliente WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cliente Buscar(int codigo)
        {
            try
            {
                Cliente cliente = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente = new Cliente() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        aluno = new Aluno() { codigo = Convert.ToInt32(reader["aluno"]), data = DateTime.Now },
                        grupo = new Cliente_grupo() { codigo = Convert.ToInt32(reader["grupo"]) },
                        subgrupo = new Cliente_grupo_subgrupo() { codigo = Convert.ToInt32(reader["subgrupo"]) },
                        tipo = Convert.ToInt32(reader["tipo"]),
                        nome = Convert.ToString(reader["nome"]),
                        contato = Convert.ToString(reader["contato"]),
                        cpf_cnpj = Convert.ToString(reader["cpf_cnpj"]),
                        endereco = Convert.ToString(reader["endereco"]),
                        bairro = Convert.ToString(reader["bairro"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        estado = Convert.ToString(reader["estado"]),
                        cep = Convert.ToString(reader["cep"]),
                        telefone = Convert.ToString(reader["telefone"]),
                        celular = Convert.ToString(reader["celular"]),
                        fax = Convert.ToString(reader["fax"]),
                        email = Convert.ToString(reader["email"]),
                        cod_municipio = Convert.ToString(reader["cod_municipio"]),
                        numero = Convert.ToString(reader["numero"]),
                        complemento = Convert.ToString(reader["complemento"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        desconto = Convert.ToInt32(reader["desconto"]),
                        obs = Convert.ToString(reader["obs"])
                    };
                }
                reader.Close();
                session.Close();

                return cliente;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Buscar(string cpf, Cliente_grupo cliente_grupo)
        {
            try
            {
                int cliente = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo FROM Cliente WHERE grupo = @grupo AND cpf_cnpj = @cpf");
                quey.SetParameter("cpf", cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", ""))
                    .SetParameter("grupo", cliente_grupo.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente = Convert.ToInt32(reader["codigo"]);
                }

                reader.Close();
                session.Close();

                return cliente;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> AutoComplete(string busca)
        {
            try
            {
                List<string> cliente = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("(select concat(c.nome, ' (', c.codigo, ') ', g.grupo) as string from cliente as c JOIN cliente_grupo as g ON c.grupo = g.codigo where c.nome like '%" + busca + "%') UNION (select concat('#', g.grupo, '#') from cliente_grupo as g where g.grupo like '%" + busca+"%') ORDER BY string");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    cliente.Add(Convert.ToString(reader["string"]));
                }

                reader.Close();
                session.Close();

                return cliente;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                List<Cliente> cliente = new List<Cliente>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cliente");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    cliente.Add(new Cliente(Convert.ToInt32(reader["codigo"]), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Cliente_grupo() { codigo = Convert.ToInt32(reader["grupo"]) }, new Cliente_grupo_subgrupo() { codigo = Convert.ToInt32(reader["subgrupo"]) }, Convert.ToInt32(reader["tipo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["contato"]), Convert.ToString(reader["cpf_cnpj"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["fax"]), Convert.ToString(reader["email"]), Convert.ToString(reader["cod_municipio"]), Convert.ToString(reader["numero"]), Convert.ToString(reader["complemento"]), Convert.ToInt32(reader["ativo"]), Convert.ToInt32(reader["desconto"]), Convert.ToString(reader["obs"])));
                }
                reader.Close();
                session.Close();

                return cliente;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ClienteAcademico Pesquisar(int codigo)
        {
            try
            {
                ClienteAcademico cliente = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select aluno.codigo AS aluno, aluno.nome AS nome, aluno.cpf AS cpf, concat(aluno.ddd, ' ', aluno.telefone) as telefone, concat(aluno.ddd_celular, ' ', aluno.celular) as celular, curso.codigo AS curso, curso.titulo AS cursoTitulo, aluno_curso.codigo AS aluno_curso, aluno_curso.situacao AS situacao, isnull(aluno_curso.data_confirmacao, '01/01/1900') as DataConfirmacao, isnull(aluno_curso.data_desistente, '01/01/1900') as DataDesistente, isnull((select top 1 isnull(data, '01/01/2000') as data from documentos, documentos_alunos WHERE documentos.codigo = documentos_alunos.documentos and documentos.curso = curso.codigo and documentos1 like '%contrato%' and aluno = aluno.codigo), '01/01/1900') AS contrato from aluno JOIN cliente ON replace(replace(replace(replace(aluno.cpf, '.', ''), '-', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cliente.cpf_cnpj, '.', ''), '-', ''), '/', ''), ' ', '') JOIN cliente_grupo ON cliente.grupo = cliente_grupo.codigo JOIN curso ON curso.titulo1 = cliente_grupo.grupo JOIN aluno_curso ON curso.codigo = aluno_curso.curso AND aluno.codigo = aluno_curso.aluno WHERE cliente.codigo = @cliente");
                quey.SetParameter("cliente", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    cliente = new ClienteAcademico()
                    {
                        aluno = Convert.ToInt32(reader["aluno"]),
                        nome = Convert.ToString(reader["nome"]),
                        cpf = Convert.ToString(reader["cpf"]),
                        telefone = Convert.ToString(reader["telefone"]),
                        celular = Convert.ToString(reader["celular"]),
                        curso = Convert.ToInt32(reader["curso"]),
                        cursoTitulo = Convert.ToString(reader["cursoTitulo"]),
                        aluno_curso = Convert.ToInt32(reader["aluno_curso"]),
                        situacao = Convert.ToInt32(reader["situacao"]),
                        dataConfirmacao = Convert.ToDateTime(reader["dataConfirmacao"]),
                        dataDesistente = Convert.ToDateTime(reader["dataDesistente"]),
                        contrato = Convert.ToDateTime(reader["contrato"]),
                        documentos = new Documentos_alunosDB().PendenciaDocumentos(Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["curso"])),
                        qtdEncontros = new EncontroDB().QtdEncontrosRealizados(Convert.ToInt32(reader["curso"])),
                        frequencia = new Aluno_curso_encontroDB().Pendencias(Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["curso"]))
                    };
                }
                reader.Close();
                session.Close();

                return cliente;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
