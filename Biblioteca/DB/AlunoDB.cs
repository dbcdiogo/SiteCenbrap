using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class AlunoDB
    {
        public void Salvar(Aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno (data, painel, nome, cpf, convenio, email, senha, data_nascimento, endereco, bairro, cidade, estado, cep, ddd, telefone, ddd_celular, celular, formacao, graduacao, instituicao, profissao, local_trabalho, obs, conheceu, rg, rg_emissor, rg_2via, formacao_data, formacao_titulo, formacao_instituicao, titulo_monografia, envio_email, sexo, recado_telefone, recado_nome, email_autoriza, email_apoio, pne, pne_qual, nome_cracha, nacionalidade,bloqueio, idprofissao, numero, complemento, flcorrecao) VALUES (@data, @painel, @nome, @cpf, @convenio, @email, @senha, @data_nascimento, @endereco, @bairro, @cidade, @estado, @cep, @ddd, @telefone, @ddd_celular, @celular, @formacao, @graduacao, @instituicao, @profissao, @local_trabalho, @obs, @conheceu, @rg, @rg_emissor, @rg_2via, @formacao_data, @formacao_titulo, @formacao_instituicao, @titulo_monografia, @envio_email, @sexo, @recado_telefone, @recado_nome, @email_autoriza, @email_apoio, @pne, @pne_qual, @nome_cracha, @nacionalidade,@bloqueio, @idprofissao, @numero, @complemento, @flcorrecao) ");
                query.SetParameter("data", variavel.data);
                query.SetParameter("painel", variavel.painel.codigo);
                query.SetParameter("nome", variavel.nome.ToUpper());
                query.SetParameter("cpf", variavel.cpf);
                query.SetParameter("convenio", variavel.convenio);
                query.SetParameter("email", variavel.email);
                query.SetParameter("senha", variavel.senha);
                query.SetParameter("data_nascimento", variavel.data_nascimento);
                query.SetParameter("endereco", variavel.endereco);
                query.SetParameter("bairro", variavel.bairro);
                query.SetParameter("cidade", variavel.cidade);
                query.SetParameter("estado", variavel.estado);
                query.SetParameter("cep", variavel.cep);
                query.SetParameter("ddd", variavel.ddd);
                query.SetParameter("telefone", variavel.telefone);
                query.SetParameter("ddd_celular", variavel.ddd_celular);
                query.SetParameter("celular", variavel.celular);
                query.SetParameter("formacao", variavel.formacao);
                query.SetParameter("graduacao", variavel.graduacao);
                query.SetParameter("instituicao", variavel.instituicao);
                query.SetParameter("profissao", variavel.profissao);
                query.SetParameter("local_trabalho", variavel.local_trabalho);
                query.SetParameter("obs", variavel.obs);
                query.SetParameter("conheceu", variavel.conheceu);
                query.SetParameter("rg", variavel.rg);
                query.SetParameter("rg_emissor", variavel.rg_emissor);
                query.SetParameter("rg_2via", variavel.rg_2via);
                query.SetParameter("formacao_data", variavel.formacao_data);
                query.SetParameter("formacao_titulo", variavel.formacao_titulo);
                query.SetParameter("formacao_instituicao", variavel.formacao_instituicao);
                query.SetParameter("titulo_monografia", variavel.titulo_monografia);
                query.SetParameter("envio_email", variavel.envio_email);
                query.SetParameter("sexo", variavel.sexo);
                query.SetParameter("recado_telefone", variavel.recado_telefone);
                query.SetParameter("recado_nome", variavel.recado_nome);
                query.SetParameter("email_autoriza", variavel.email_autoriza);
                query.SetParameter("email_apoio", variavel.email_apoio);
                query.SetParameter("pne", variavel.pne);
                query.SetParameter("pne_qual", variavel.pne_qual);
                query.SetParameter("nome_cracha", variavel.nome_cracha);
                query.SetParameter("nacionalidade", variavel.nacionalidade);
                query.SetParameter("bloqueio", variavel.bloqueio);
                query.SetParameter("idprofissao", variavel.idprofissao);
                query.SetParameter("numero", variavel.numero);
                query.SetParameter("complemento", variavel.complemento);
                query.SetParameter("flcorrecao", variavel.flcorrecao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(Aluno variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno (data, painel, nome, cpf, convenio, email, senha, data_nascimento, endereco, bairro, cidade, estado, cep, ddd, telefone, ddd_celular, celular, formacao, graduacao, instituicao, profissao, local_trabalho, obs, conheceu, rg, rg_emissor, rg_2via, formacao_data, formacao_titulo, formacao_instituicao, titulo_monografia, envio_email, sexo, recado_telefone, recado_nome, email_autoriza, email_apoio, pne, pne_qual, nome_cracha, nacionalidade,bloqueio, idprofissao, numero, complemento, flcorrecao) output INSERTED.codigo VALUES (@data, @painel, @nome, @cpf, @convenio, @email, @senha, @data_nascimento, @endereco, @bairro, @cidade, @estado, @cep, @ddd, @telefone, @ddd_celular, @celular, @formacao, @graduacao, @instituicao, @profissao, @local_trabalho, @obs, @conheceu, @rg, @rg_emissor, @rg_2via, @formacao_data, @formacao_titulo, @formacao_instituicao, @titulo_monografia, @envio_email, @sexo, @recado_telefone, @recado_nome, @email_autoriza, @email_apoio, @pne, @pne_qual, @nome_cracha, @nacionalidade,@bloqueio,@idprofissao, @numero, @complemento, @flcorrecao) ");
                query.SetParameter("data", variavel.data);
                query.SetParameter("painel", variavel.painel.codigo);
                query.SetParameter("nome", variavel.nome.ToUpper());
                query.SetParameter("cpf", variavel.cpf);
                query.SetParameter("convenio", variavel.convenio);
                query.SetParameter("email", variavel.email);
                query.SetParameter("senha", variavel.senha);
                query.SetParameter("data_nascimento", variavel.data_nascimento);
                query.SetParameter("endereco", variavel.endereco);
                query.SetParameter("bairro", variavel.bairro);
                query.SetParameter("cidade", variavel.cidade);
                query.SetParameter("estado", variavel.estado);
                query.SetParameter("cep", variavel.cep);
                query.SetParameter("ddd", variavel.ddd);
                query.SetParameter("telefone", variavel.telefone);
                query.SetParameter("ddd_celular", variavel.ddd_celular);
                query.SetParameter("celular", variavel.celular);
                query.SetParameter("formacao", variavel.formacao);
                query.SetParameter("graduacao", variavel.graduacao);
                query.SetParameter("instituicao", variavel.instituicao);
                query.SetParameter("profissao", variavel.profissao);
                query.SetParameter("local_trabalho", variavel.local_trabalho);
                query.SetParameter("obs", variavel.obs);
                query.SetParameter("conheceu", variavel.conheceu);
                query.SetParameter("rg", variavel.rg);
                query.SetParameter("rg_emissor", variavel.rg_emissor);
                query.SetParameter("rg_2via", variavel.rg_2via);
                query.SetParameter("formacao_data", variavel.formacao_data);
                query.SetParameter("formacao_titulo", variavel.formacao_titulo);
                query.SetParameter("formacao_instituicao", variavel.formacao_instituicao);
                query.SetParameter("titulo_monografia", variavel.titulo_monografia);
                query.SetParameter("envio_email", variavel.envio_email);
                query.SetParameter("sexo", variavel.sexo);
                query.SetParameter("recado_telefone", variavel.recado_telefone);
                query.SetParameter("recado_nome", variavel.recado_nome);
                query.SetParameter("email_autoriza", variavel.email_autoriza);
                query.SetParameter("email_apoio", variavel.email_apoio);
                query.SetParameter("pne", variavel.pne);
                query.SetParameter("pne_qual", variavel.pne_qual);
                query.SetParameter("nome_cracha", variavel.nome_cracha);
                query.SetParameter("nacionalidade", variavel.nacionalidade);
                query.SetParameter("bloqueio", variavel.bloqueio);
                query.SetParameter("idprofissao", variavel.idprofissao);
                query.SetParameter("numero", variavel.numero);
                query.SetParameter("complemento", variavel.complemento);
                query.SetParameter("flcorrecao", variavel.flcorrecao);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarJornada(Aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno SET nome = @nome, cpf = @cpf, email = @email, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, ddd = @ddd, telefone = @telefone, sexo = @sexo, nome_cracha = @nome_cracha, idprofissao = @idprofissao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("nome", variavel.nome.ToUpper())
                    .SetParameter("cpf", variavel.cpf)
                    .SetParameter("email", variavel.email)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("ddd", variavel.ddd)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("sexo", variavel.sexo)
                    .SetParameter("nome_cracha", variavel.nome_cracha)
                    .SetParameter("idprofissao", variavel.idprofissao)
                    ;
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarSenha(Aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno SET senha = @senha WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("senha", variavel.senha);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno SET data = @data, painel = @painel, nome = @nome, cpf = @cpf, convenio = @convenio, email = @email, senha = @senha, data_nascimento = @data_nascimento, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, ddd = @ddd, telefone = @telefone, ddd_celular = @ddd_celular, celular = @celular, formacao = @formacao, graduacao = @graduacao, instituicao = @instituicao, profissao = @profissao, local_trabalho = @local_trabalho, obs = @obs, conheceu = @conheceu, rg = @rg, rg_emissor = @rg_emissor, rg_2via = @rg_2via, formacao_data = @formacao_data, formacao_titulo = @formacao_titulo, formacao_instituicao = @formacao_instituicao, titulo_monografia = @titulo_monografia, envio_email = @envio_email, sexo = @sexo, recado_telefone = @recado_telefone, recado_nome = @recado_nome, email_autoriza = @email_autoriza, email_apoio = @email_apoio, pne = @pne, pne_qual = @pne_qual, nome_cracha = @nome_cracha, nacionalidade = @nacionalidade, bloqueio = @bloqueio, idprofissao = @idprofissao, numero = @numero, complemento = @complemento, flcorrecao = @flcorrecao WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("nome", variavel.nome.ToUpper())
                    .SetParameter("cpf", variavel.cpf)
                    .SetParameter("convenio", variavel.convenio)
                    .SetParameter("email", variavel.email)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("data_nascimento", variavel.data_nascimento)
                    .SetParameter("endereco", variavel.endereco)
                    .SetParameter("bairro", variavel.bairro)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("estado", variavel.estado)
                    .SetParameter("cep", variavel.cep)
                    .SetParameter("ddd", variavel.ddd)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("ddd_celular", variavel.ddd_celular)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("formacao", variavel.formacao)
                    .SetParameter("graduacao", variavel.graduacao)
                    .SetParameter("instituicao", variavel.instituicao)
                    .SetParameter("profissao", variavel.profissao)
                    .SetParameter("local_trabalho", variavel.local_trabalho)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("conheceu", variavel.conheceu)
                    .SetParameter("rg", variavel.rg)
                    .SetParameter("rg_emissor", variavel.rg_emissor)
                    .SetParameter("rg_2via", variavel.rg_2via)
                    .SetParameter("formacao_data", variavel.formacao_data)
                    .SetParameter("formacao_titulo", variavel.formacao_titulo)
                    .SetParameter("formacao_instituicao", variavel.formacao_instituicao)
                    .SetParameter("titulo_monografia", variavel.titulo_monografia)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("sexo", variavel.sexo)
                    .SetParameter("recado_telefone", variavel.recado_telefone)
                    .SetParameter("recado_nome", variavel.recado_nome)
                    .SetParameter("email_autoriza", variavel.email_autoriza)
                    .SetParameter("email_apoio", variavel.email_apoio)
                    .SetParameter("pne", variavel.pne)
                    .SetParameter("pne_qual", variavel.pne_qual)
                    .SetParameter("nome_cracha", variavel.nome_cracha)
                    .SetParameter("nacionalidade", variavel.nacionalidade)
                    .SetParameter("bloqueio", variavel.bloqueio)
                    .SetParameter("idprofissao", variavel.idprofissao)
                    .SetParameter("numero", variavel.numero)
                    .SetParameter("complemento", variavel.complemento)
                    .SetParameter("flcorrecao", variavel.flcorrecao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Aluno WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Aluno Buscar(int codigo)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao, numero, complemento, isnull(flcorrecao, 0) as flcorrecao FROM Aluno WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]), Convert.ToString(reader["numero"]), Convert.ToString(reader["complemento"]), Convert.ToInt32(reader["flcorrecao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarCelular(int codigo)
        {
            try
            {
                string celular = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(a.ddd_celular,'') as ddd, isnull(a.celular,'') as celular from aluno_curso ac inner join aluno a on a.codigo = ac.aluno where ac.codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    celular = Whatsapp.FormataCelular(Convert.ToString(reader["ddd"]), Convert.ToString(reader["celular"]));
                }
                reader.Close();
                session.Close();

                return celular;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarCelularAluno(int codigo)
        {
            try
            {
                string celular = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(ddd_celular,'') as ddd, isnull(celular,'') as celular from aluno where codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    celular = Whatsapp.FormataCelular(Convert.ToString(reader["ddd"]), Convert.ToString(reader["celular"]));
                }
                reader.Close();
                session.Close();

                return celular;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno BuscarNome(string chave)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao FROM Aluno WHERE nome = @chave");
                quey.SetParameter("chave", chave);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno Buscar(string chave)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao, isnull(flcorrecao, 0) as flcorrecao FROM Aluno WHERE nome LIKE @chave OR cpf LIKE @chave OR email LIKE @chave OR telefone LIKE @chave OR celular LIKE @chave");
                quey.SetParameter("chave", "%"+chave+"%");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]), Convert.ToInt32(reader["flcorrecao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }       

        public Aluno Buscar(string nome, string cpf)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao, isnull(flcorrecao, 0) as flcorrecao FROM Aluno WHERE (replace(replace(replace(replace(cpf, ' ',''), '.',''), '-',''), '/','') = replace(replace(replace(replace(@cpf, ' ',''), '.',''), '-',''), '/','') AND nome COLLATE Latin1_general_CI_AI LIKE '" + nome + "%') OR email = @nome AND senha = @cpf");
                quey.SetParameter("cpf", cpf).SetParameter("nome", nome);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]), Convert.ToInt32(reader["flcorrecao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno BuscarMedTV(string nome, string cpf)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao FROM Aluno WHERE ((replace(replace(replace(replace(cpf, ' ',''), '.',''), '-',''), '/','') = replace(replace(replace(replace(@cpf, ' ',''), '.',''), '-',''), '/','') AND nome LIKE '" + nome + "%') OR email = @nome AND senha = @cpf) OR (email = @nome AND EXISTS (select * From aluno_medtv where aluno_medtv.aluno = codigo and aluno_medtv.senha = @cpf))");
                quey.SetParameter("cpf", cpf).SetParameter("nome", nome);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno CPF(string cpf)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao, numero, complemento, isnull(flcorrecao, 0) as flcorrecao FROM Aluno WHERE lower(replace(replace(replace(replace(cpf, ' ',''), '.',''), '-',''), '/','')) = lower(replace(replace(replace(replace(@cpf, ' ',''), '.',''), '-',''), '/',''))");
                quey.SetParameter("cpf", cpf);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]), Convert.ToString(reader["numero"]), Convert.ToString(reader["complemento"]), Convert.ToInt32(reader["flcorrecao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno Email(string email)
        {
            try
            {
                Aluno aluno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data , isnull(painel, 0) AS painel, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf, isnull(convenio , 0) AS convenio, isnull(email, '') AS email, isnull(senha, '') AS senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento, isnull(endereco, '') AS endereco, isnull(bairro, '') AS bairro, isnull(cidade, '') AS cidade, isnull(estado, '') AS estado, isnull(cep, '') AS cep, isnull(ddd, '') AS ddd, isnull(telefone, '') AS telefone, isnull(ddd_celular, '') AS ddd_celular, isnull(celular, '') AS celular, isnull(formacao, '') AS formacao, isnull(graduacao, '') AS graduacao, isnull(instituicao, '') AS instituicao, isnull(profissao, '') AS profissao, isnull(local_trabalho, '') AS local_trabalho, isnull(obs, '') AS obs, isnull(conheceu, '') AS conheceu, isnull(rg, '') AS rg, isnull(rg_emissor, '') AS rg_emissor, isnull(rg_2via, 0) AS rg_2via, isnull(formacao_data, '') AS formacao_data, isnull(formacao_titulo, '') AS formacao_titulo, isnull(formacao_instituicao, '') AS formacao_instituicao, isnull(titulo_monografia, '') AS titulo_monografia, isnull(envio_email, 1) AS envio_email, isnull(sexo, '') AS sexo, isnull(recado_telefone, '') AS recado_telefone, isnull(recado_nome, '') AS recado_nome, isnull(email_autoriza, 0) AS email_autoriza, isnull(email_apoio, '') AS email_apoio, isnull(pne, 0) AS pne, isnull(pne_qual, '') AS pne_qual, isnull(nome_cracha, '') AS nome_cracha, isnull(nacionalidade, '') AS nacionalidade, isnull(bloqueio, 0) as bloqueio, isnull(idprofissao, 0) as idprofissao FROM Aluno WHERE lower(email) = lower(@email)");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool ExisteEmail(string email)
        {
            try
            {
                bool aluno = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo FROM Aluno WHERE lower(email) = lower(@email)");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno = true;
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno> BuscarResumido(string chave)
        {
            try
            {
                List<Aluno> aluno = new List<Aluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf FROM Aluno WHERE nome COLLATE Latin1_general_CI_AI LIKE @chave OR cpf LIKE @chave OR email LIKE @chave OR telefone LIKE @chave OR celular LIKE @chave");
                quey.SetParameter("chave", "%" + chave + "%");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"])));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno BuscarResumido(int codigo)
        {
            try
            {
                Aluno aluno = new Aluno();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(nome, '') AS nome, isnull(cpf, '') AS cpf FROM Aluno WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    aluno = new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno> Listar(string chave)
        {
            try
            {
                List<Aluno> aluno = new List<Aluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, isnull(data, '1900-01-01') AS data ,painel,nome,cpf,convenio,email,senha, isnull(data_nascimento, '1900-01-01') AS data_nascimento,endereco,bairro,cidade,estado,cep,ddd,telefone,ddd_celular,celular,formacao,graduacao,instituicao,profissao,local_trabalho,obs,conheceu,rg,rg_emissor,rg_2via,formacao_data,formacao_titulo,formacao_instituicao,titulo_monografia,envio_email,sexo,recado_telefone,recado_nome,email_autoriza,email_apoio,pne,pne_qual,nome_cracha,nacionalidade,bloqueio, idprofissao FROM Aluno WHERE nome LIKE @chave OR cpf LIKE @chave OR email LIKE @chave OR telefone LIKE @chave OR celular LIKE @chave");
                quey.SetParameter("chave", "%" + chave + "%");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new Aluno(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf"]), Convert.ToInt32(reader["convenio"]), Convert.ToString(reader["email"]), Convert.ToString(reader["senha"]), Convert.ToDateTime(reader["data_nascimento"]), Convert.ToString(reader["endereco"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["estado"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["ddd"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["ddd_celular"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["formacao"]), Convert.ToString(reader["graduacao"]), Convert.ToString(reader["instituicao"]), Convert.ToString(reader["profissao"]), Convert.ToString(reader["local_trabalho"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["conheceu"]), Convert.ToString(reader["rg"]), Convert.ToString(reader["rg_emissor"]), Convert.ToInt32(reader["rg_2via"]), Convert.ToString(reader["formacao_data"]), Convert.ToString(reader["formacao_titulo"]), Convert.ToString(reader["formacao_instituicao"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["envio_email"]), Convert.ToString(reader["sexo"]), Convert.ToString(reader["recado_telefone"]), Convert.ToString(reader["recado_nome"]), Convert.ToInt32(reader["email_autoriza"]), Convert.ToString(reader["email_apoio"]), Convert.ToInt32(reader["pne"]), Convert.ToString(reader["pne_qual"]), Convert.ToString(reader["nome_cracha"]), Convert.ToString(reader["nacionalidade"]), Convert.ToBoolean(reader["bloqueio"]), Convert.ToInt32(reader["idprofissao"])));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno> Listar(DateTime inicio, DateTime fim, string assunto)
        {
            try
            {
                List<Aluno> aluno = new List<Aluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT a.codigo, isnull(a.data, '1900-01-01') AS data, a.nome, a.email, a.sexo, c.titulo FROM aluno AS a JOIN aluno_curso AS ac ON a.codigo = ac.aluno JOIN curso AS c ON ac.curso = c.codigo WHERE ac.adesao between @inicio AND @fim AND NOT EXISTS (SELECT e.codigo FROM envio_email AS e WHERE e.para = a.email AND e.assunto LIKE @assunto AND e.data_envio >= dateadd(d, -30, @inicio)) AND c.tipo IN (0, 1, 2) AND c.codigo != 376"); 
                quey.SetParameter("inicio", inicio)
                    .SetParameter("fim", fim)
                    .SetParameter("assunto", assunto);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new Aluno() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        nome = Convert.ToString(reader["nome"]),
                        email = Convert.ToString(reader["email"]),
                        data = Convert.ToDateTime(reader["data"]),
                        endereco = Convert.ToString(reader["titulo"]),
                        sexo = Convert.ToString(reader["sexo"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<InscritosParaLigacao> ListarInscritosParaLigar(DateTime inicio, DateTime fim)
        {
            try
            {
                List<InscritosParaLigacao> aluno = new List<InscritosParaLigacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT a.nome, c.titulo AS curso, concat('http://cenbrap.com.br/sistema/curso_aluno_relacao1.asp?curso=', c.codigo, '#', ac.codigo) as link, isnull(ac.obs1, '') AS obs FROM aluno AS a JOIN aluno_curso AS ac ON a.codigo = ac.aluno JOIN curso AS c ON ac.curso = c.codigo WHERE ac.situacao IN (0, 1) AND ((ac.email_impressao_boleto is null AND ac.adesao between @inicio AND @fim) OR (ac.email_impressao_boleto between @inicio AND @fim))");
                quey.SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new InscritosParaLigacao(Convert.ToString(reader["nome"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["link"]), Convert.ToString(reader["obs"])));
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno> Cursos14Encontro(Curso curso)
        {
            try
            {
                List<Aluno> aluno = new List<Aluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select aluno.codigo, aluno.nome, aluno.cpf from aluno where aluno.codigo in (select aluno from aluno_curso_encontro where curso = @curso and aluno in (select a.codigo as aluno from cliente as c inner join aluno as a on c.cpf_cnpj = replace(replace(replace(replace(a.cpf, '.', ''), ' ', ''), '-', ''), '-', '') inner join aluno_curso as ac on ac.aluno = a.codigo inner join curso as cu on ac.curso = cu.codigo where cu.titulo1 = @curso_titulo and ac.situacao = 2 and c.codigo in (select cliente from entrada as e where situacao < 2 and tipo_entrada = 1 and e.cliente in (select c1.codigo from cliente as c1 inner join cliente_grupo as g ON c1.grupo = g.codigo where g.grupo = @curso_titulo) and vencimento < getdate() and not exists (select * from aluno_curso_rematricula as acr where acr.data >= dateadd(Month, -7, getdate()) and acr.aluno_curso = ac.codigo) group by cliente having count(*) > 6)) and (nota = 0 or frequencia = 0) group by aluno having count(*) > 6)");
                quey.SetParameter("curso", curso.codigo)
                    .SetParameter("curso_titulo", curso.titulo1);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new Aluno(){ codigo = Convert.ToInt32(reader["codigo"]), nome = Convert.ToString(reader["nome"]), cpf = Convert.ToString(reader["cpf"]) });
                }
                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> Emails(string estado, string cidade_curso = "", string estado_curso = "", string cidades = "")
        {
            try
            {
                List<string> retorno = new List<string>();

                string executar = "select distinct a.email from aluno  as a where a.envio_email = 1  and (a.estado = @estado or exists( select * from aluno_curso as ac WHERE ac.aluno = a.codigo and ac.envio_email = 1 and exists (select * from curso as c WHERE c.codigo = ac.curso and exists (select * from cidade as ci where ci.codigo = c.cidade_codigo and ci.estado = @estado))))";

                if (cidades != "")
                {
                    executar = "select distinct a.email from aluno  as a where a.envio_email = 1  and ((a.estado = @estado and a.cidade in (";
                    if(cidades.IndexOf(",") > 0)
                    {
                        var c = cidades.Split(',');
                        for (int i = 0; i < c.Length; i++)
                        {
                            if (i != 0)
                                executar += ",";

                            executar += "'" + c[i] + "'";
                        }
                    }
                    else
                    {
                        executar += "'" + cidades + "'";
                    }
                    executar += ")) or exists( select * from aluno_curso as ac WHERE ac.aluno = a.codigo and ac.envio_email = 1 and exists (select * from curso as c WHERE c.codigo = ac.curso and exists (select * from cidade as ci where ci.codigo = c.cidade_codigo and ci.estado = '" + estado_curso + "' AND ci.cidade = '" + cidade_curso + "'))))";
                }

                DBSession session = new DBSession();
                Query query = session.CreateQuery(executar);
                query.SetParameter("estado", estado);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(Convert.ToString(reader["email"]));
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

        public List<Aluno> EmailsJBPO()
        {
            try
            {
                List<Aluno> retorno = new List<Aluno>();

                string executar = "select email, nome from (select distinct a.email, a.nome, (case when (select top 1 isnull(ac1.codigo, 0) from aluno as a1 inner join aluno_curso as ac1 on a1.codigo = ac1.aluno where a1.email = a.email and ac1.curso = 374 and ac1.situacao = 2) > 0 then 1 else 0 end) as jbpo from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno where ac.situacao = 2 and a.envio_email = 1 and exists (select * from curso as c where c.codigo = ac.curso and (c.titulo1 like 'PS%' OR c.titulo1 like 'MT%' OR c.titulo1 like 'CBM%' OR c.titulo1 like 'SIM%' OR c.titulo1 like 'SMT%'))) as t where t.jbpo = 0";

                DBSession session = new DBSession();
                Query query = session.CreateQuery(executar);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Aluno() { email = Convert.ToString(reader["email"]), nome = Convert.ToString(reader["nome"]) });
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

        public List<CidadeString> Cidades(string estado)
        {
            try
            {
                List<CidadeString> aluno = new List<CidadeString>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select distinct a.cidade as value, concat(a.cidade, ' (', (select count(*) from aluno as a1 where a1.cidade = a.cidade and a1.estado = @estado) ,')') as cidade from aluno as a where a.estado = @estado GROUP BY a.cidade ORDER BY a.cidade").SetParameter("estado", estado);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new CidadeString(Convert.ToString(reader["value"]), Convert.ToString(reader["cidade"])));
                }
                reader.Close();
                session.Close();

                return aluno;
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
                List<string> aluno = new List<string>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select concat(a.nome, ' (', a.email, ')') as string from aluno as a where (a.nome COLLATE Latin1_General_CI_AI) like '%" + busca + "%' OR a.email like '%" + busca + "%' ORDER BY string");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(Convert.ToString(reader["string"]));
                }

                reader.Close();
                session.Close();

                return aluno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string PrimeiroNome(string email)
        {
            try
            {
                string nome = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select SUBSTRING(nome, 1, CHARINDEX(' ', nome)) as nome from aluno where lower(email) = lower(@email)");
                quey.SetParameter("email", email);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    nome = Convert.ToString(reader["nome"]);
                }
                reader.Close();
                session.Close();

                return nome;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string NomeAluno(int aluno)
        {
            try
            {
                string nome = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select nome from aluno where codigo = @aluno");
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    nome = Convert.ToString(reader["nome"]);
                }
                reader.Close();
                session.Close();

                return nome;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Boolean ValidaDadosAluno(int codigo = 0)
        {
            try
            {
                Boolean valido = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from aluno where codigo = @codigo and endereco <> '' and bairro <> '' and cidade <> '' and estado <> '' and (replace(replace(cep,'.',''),'-','') <> '' and len(replace(replace(cep,'.',''),'-','')) = 8) and (replace(replace(cpf,'.',''),'-','') <> '' and len(replace(replace(cpf,'.',''),'-','')) = 11)");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    valido = true;
                }
                reader.Close();
                session.Close();

                return valido;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
