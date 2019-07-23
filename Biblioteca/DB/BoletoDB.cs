using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class BoletoDB
    {
        public void Salvar(Boleto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Boleto (data,conta,entrada,cliente,painel,valor,multa,juros,protesto,vencimento,impresso,instrucoes,impresso_data,remessa,remessa_data,retorno,retorno_data,arquivo,remessa_codigo,retorno_codigo,retorno_msg_erro,entrada_confirmada,pagamento_efetuado,entrada_rejeitada,movimento_codigo,movimento_descricao,rejeicao_codigo,rejeicao_msg,ticket,aluno_pgto,boleto_avulso) VALUES (@data,@conta,@entrada,@cliente,@painel,@valor,@multa,@juros,@protesto,@vencimento,@impresso,@instrucoes,@impresso_data,@remessa,@remessa_data,@retorno,@retorno_data,@arquivo,@remessa_codigo,@retorno_codigo,@retorno_msg_erro,@entrada_confirmada,@pagamento_efetuado,@entrada_rejeitada,@movimento_codigo,@movimento_descricao,@rejeicao_codigo,@rejeicao_msg,@ticket,@aluno_pgto,@boleto_avulso) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("entrada", variavel.entrada.codigo)
                    .SetParameter("cliente", variavel.cliente)
                    .SetParameter("painel", variavel.painel)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("multa", variavel.multa)
                    .SetParameter("juros", variavel.juros)
                    .SetParameter("protesto", variavel.protesto)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("impresso", variavel.impresso)
                    .SetParameter("instrucoes", variavel.instrucoes)
                    .SetParameter("impresso_data", variavel.impresso_data)
                    .SetParameter("remessa", variavel.remessa)
                    .SetParameter("remessa_data", variavel.remessa_data)
                    .SetParameter("retorno", variavel.retorno)
                    .SetParameter("retorno_data", variavel.retorno_data)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("remessa_codigo", variavel.remessa_codigo)
                    .SetParameter("retorno_codigo", variavel.retorno_codigo)
                    .SetParameter("retorno_msg_erro", variavel.retorno_msg_erro)
                    .SetParameter("entrada_confirmada", variavel.entrada_confirmada)
                    .SetParameter("pagamento_efetuado", variavel.pagamento_efetuado)
                    .SetParameter("entrada_rejeitada", variavel.entrada_rejeitada)
                    .SetParameter("movimento_codigo", variavel.movimento_codigo)
                    .SetParameter("movimento_descricao", variavel.movimento_descricao)
                    .SetParameter("rejeicao_codigo", variavel.rejeicao_codigo)
                    .SetParameter("rejeicao_msg", variavel.rejeicao_msg)
                    .SetParameter("ticket", variavel.ticket)
                    .SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("boleto_avulso", variavel.boleto_avulso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarRetornar(Boleto variavel)
        {
            int id = 0;
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Boleto (data,conta,entrada,cliente,painel,valor,multa,juros,protesto,vencimento,impresso,instrucoes,impresso_data,remessa,remessa_data,retorno,retorno_data,arquivo,remessa_codigo,retorno_codigo,retorno_msg_erro,entrada_confirmada,pagamento_efetuado,entrada_rejeitada,movimento_codigo,movimento_descricao,rejeicao_codigo,rejeicao_msg,ticket,aluno_pgto,boleto_avulso) output INSERTED.codigo VALUES (@data,@conta,@entrada,@cliente,@painel,@valor,@multa,@juros,@protesto,@vencimento,@impresso,@instrucoes,@impresso_data,@remessa,@remessa_data,@retorno,@retorno_data,@arquivo,@remessa_codigo,@retorno_codigo,@retorno_msg_erro,@entrada_confirmada,@pagamento_efetuado,@entrada_rejeitada,@movimento_codigo,@movimento_descricao,@rejeicao_codigo,@rejeicao_msg,@ticket,@aluno_pgto,@boleto_avulso) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("entrada", variavel.entrada.codigo)
                    .SetParameter("cliente", variavel.cliente)
                    .SetParameter("painel", variavel.painel)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("multa", variavel.multa)
                    .SetParameter("juros", variavel.juros)
                    .SetParameter("protesto", variavel.protesto)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("impresso", variavel.impresso)
                    .SetParameter("instrucoes", variavel.instrucoes)
                    .SetParameter("impresso_data", variavel.impresso_data)
                    .SetParameter("remessa", variavel.remessa)
                    .SetParameter("remessa_data", variavel.remessa_data)
                    .SetParameter("retorno", variavel.retorno)
                    .SetParameter("retorno_data", variavel.retorno_data)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("remessa_codigo", variavel.remessa_codigo)
                    .SetParameter("retorno_codigo", variavel.retorno_codigo)
                    .SetParameter("retorno_msg_erro", variavel.retorno_msg_erro)
                    .SetParameter("entrada_confirmada", variavel.entrada_confirmada)
                    .SetParameter("pagamento_efetuado", variavel.pagamento_efetuado)
                    .SetParameter("entrada_rejeitada", variavel.entrada_rejeitada)
                    .SetParameter("movimento_codigo", variavel.movimento_codigo)
                    .SetParameter("movimento_descricao", variavel.movimento_descricao)
                    .SetParameter("rejeicao_codigo", variavel.rejeicao_codigo)
                    .SetParameter("rejeicao_msg", variavel.rejeicao_msg)
                    .SetParameter("ticket", variavel.ticket)
                    .SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("boleto_avulso", variavel.boleto_avulso.codigo);
                id = query.ExecuteScalar();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return id;
        }

        public void Alterar(Boleto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Boleto SET data = @data, conta = @conta, entrada = @entrada, cliente = @cliente, painel = @painel, valor = @valor, multa = @multa, juros = @juros, protesto = @protesto, vencimento = @vencimento, impresso = @impresso, instrucoes = @instrucoes, impresso_data = @impresso_data, remessa = @remessa, remessa_data = @remessa_data, retorno = @retorno, retorno_data = @retorno_data, arquivo = @arquivo, remessa_codigo = @remessa_codigo, retorno_codigo = @retorno_codigo, retorno_msg_erro = @retorno_msg_erro, entrada_confirmada = @entrada_confirmada, pagamento_efetuado = @pagamento_efetuado, entrada_rejeitada = @entrada_rejeitada, movimento_codigo = @movimento_codigo, movimento_descricao = @movimento_descricao, rejeicao_codigo = @rejeicao_codigo, rejeicao_msg = @rejeicao_msg, ticket = @ticket, aluno_pgto = @aluno_pgto, boleto_avulso = @boleto_avulso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("entrada", variavel.entrada.codigo)
                    .SetParameter("cliente", variavel.cliente)
                    .SetParameter("painel", variavel.painel)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("multa", variavel.multa)
                    .SetParameter("juros", variavel.juros)
                    .SetParameter("protesto", variavel.protesto)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("impresso", variavel.impresso)
                    .SetParameter("instrucoes", variavel.instrucoes)
                    .SetParameter("impresso_data", variavel.impresso_data)
                    .SetParameter("remessa", variavel.remessa)
                    .SetParameter("remessa_data", variavel.remessa_data)
                    .SetParameter("retorno", variavel.retorno)
                    .SetParameter("retorno_data", variavel.retorno_data)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("remessa_codigo", variavel.remessa_codigo)
                    .SetParameter("retorno_codigo", variavel.retorno_codigo)
                    .SetParameter("retorno_msg_erro", variavel.retorno_msg_erro)
                    .SetParameter("entrada_confirmada", variavel.entrada_confirmada)
                    .SetParameter("pagamento_efetuado", variavel.pagamento_efetuado)
                    .SetParameter("entrada_rejeitada", variavel.entrada_rejeitada)
                    .SetParameter("movimento_codigo", variavel.movimento_codigo)
                    .SetParameter("movimento_descricao", variavel.movimento_descricao)
                    .SetParameter("rejeicao_codigo", variavel.rejeicao_codigo)
                    .SetParameter("rejeicao_msg", variavel.rejeicao_msg)
                    .SetParameter("ticket", variavel.ticket)
                    .SetParameter("aluno_pgto", variavel.aluno_pgto.codigo)
                    .SetParameter("boleto_avulso", variavel.boleto_avulso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Boleto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Boleto WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Boleto Buscar(int codigo)
        {
            try
            {
                Boleto boleto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data, isnull(conta, 0) AS conta, isnull(entrada, 0) AS entrada, isnull(cliente, 0) AS cliente, isnull(painel, 0) AS painel, isnull(valor, 0) AS valor, isnull(multa, 0) AS multa, isnull(juros, 0) AS juros, isnull(protesto, 0) AS protesto, isnull(vencimento, '1900-01-01') AS vencimento, isnull(impresso, 0) AS impresso, isnull(instrucoes, '') AS instrucoes, isnull(impresso_data, '1900-01-01') AS impresso_data, isnull(remessa, 0) AS remessa, isnull(remessa_data, '1900-01-01') AS remessa_data, isnull(retorno, 0) AS retorno, isnull(retorno_data, '1900-01-01') AS retorno_data, isnull(arquivo, '') AS arquivo, isnull(remessa_codigo, 0) AS remessa_codigo, isnull(retorno_codigo, 0) AS retorno_codigo, isnull(retorno_msg_erro, '') AS retorno_msg_erro, isnull(entrada_confirmada, 0) AS entrada_confirmada, isnull(pagamento_efetuado, 0) AS pagamento_efetuado, isnull(entrada_rejeitada, 0) AS entrada_rejeitada, isnull(movimento_codigo, '') AS movimento_codigo, isnull(movimento_descricao, '') AS movimento_descricao, isnull(rejeicao_codigo, '') AS rejeicao_codigo, isnull(rejeicao_msg, '') AS rejeicao_msg, isnull(ticket, 0) AS ticket, isnull(aluno_pgto, 0) AS aluno_pgto, isnull(boleto_avulso, 0) AS boleto_avulso FROM boleto WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = new Boleto(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["conta"]), new Entrada() { codigo = Convert.ToInt32(reader["entrada"]) }, Convert.ToInt32(reader["cliente"]), Convert.ToInt32(reader["painel"]), Convert.ToDouble(reader["valor"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToInt32(reader["protesto"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["impresso"]), Convert.ToString(reader["instrucoes"]), Convert.ToDateTime(reader["impresso_data"]), Convert.ToInt32(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["retorno"]), Convert.ToDateTime(reader["retorno_data"]), Convert.ToString(reader["arquivo"]), Convert.ToInt32(reader["remessa_codigo"]), Convert.ToInt32(reader["retorno_codigo"]), Convert.ToString(reader["retorno_msg_erro"]), Convert.ToInt32(reader["entrada_confirmada"]), Convert.ToInt32(reader["pagamento_efetuado"]), Convert.ToInt32(reader["entrada_rejeitada"]), Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToString(reader["rejeicao_codigo"]), Convert.ToString(reader["rejeicao_msg"]), Convert.ToInt32(reader["ticket"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["aluno_pgto"]) }, new Boleto_avulso() { codigo = Convert.ToInt32(reader["boleto_avulso"]) });
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Buscar(string email, int codigo)
        {
            try
            {
                int boleto = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select top 1 b.codigo AS codigo from aluno_pgto AS ap JOIN boleto AS b ON ap.codigo = b.aluno_pgto JOIN aluno AS a ON ap.aluno = a.codigo WHERE ap.curso = @codigo AND ap.forma_pgto = 3 AND a.email = @email ORDER BY b.codigo DESC");
                quey.SetParameter("email", email).SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = Convert.ToInt32(reader["codigo"]);
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Boleto Buscar(Aluno_pgto aluno_pgto)
        {
            try
            {
                Boleto boleto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data, isnull(conta, 0) AS conta, isnull(entrada, 0) AS entrada, isnull(cliente, 0) AS cliente, isnull(painel, 0) AS painel, isnull(valor, 0) AS valor, isnull(multa, 0) AS multa, isnull(juros, 0) AS juros, isnull(protesto, 0) AS protesto, isnull(vencimento, '1900-01-01') AS vencimento, isnull(impresso, 0) AS impresso, isnull(instrucoes, '') AS instrucoes, isnull(impresso_data, '1900-01-01') AS impresso_data, isnull(remessa, 0) AS remessa, isnull(remessa_data, '1900-01-01') AS remessa_data, isnull(retorno, 0) AS retorno, isnull(retorno_data, '1900-01-01') AS retorno_data, isnull(arquivo, '') AS arquivo, isnull(remessa_codigo, 0) AS remessa_codigo, isnull(retorno_codigo, 0) AS retorno_codigo, isnull(retorno_msg_erro, '') AS retorno_msg_erro, isnull(entrada_confirmada, 0) AS entrada_confirmada, isnull(pagamento_efetuado, 0) AS pagamento_efetuado, isnull(entrada_rejeitada, 0) AS entrada_rejeitada, isnull(movimento_codigo, '') AS movimento_codigo, isnull(movimento_descricao, '') AS movimento_descricao, isnull(rejeicao_codigo, '') AS rejeicao_codigo, isnull(rejeicao_msg, '') AS rejeicao_msg, isnull(ticket, 0) AS ticket, isnull(aluno_pgto, 0) AS aluno_pgto, isnull(boleto_avulso, 0) as boleto_avulso FROM boleto WHERE aluno_pgto = @aluno_pgto ORDER BY codigo DESC");
                quey.SetParameter("aluno_pgto", aluno_pgto.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = new Boleto(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["conta"]), new Entrada() { codigo = Convert.ToInt32(reader["entrada"]) }, Convert.ToInt32(reader["cliente"]), Convert.ToInt32(reader["painel"]), Convert.ToDouble(reader["valor"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToInt32(reader["protesto"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["impresso"]), Convert.ToString(reader["instrucoes"]), Convert.ToDateTime(reader["impresso_data"]), Convert.ToInt32(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["retorno"]), Convert.ToDateTime(reader["retorno_data"]), Convert.ToString(reader["arquivo"]), Convert.ToInt32(reader["remessa_codigo"]), Convert.ToInt32(reader["retorno_codigo"]), Convert.ToString(reader["retorno_msg_erro"]), Convert.ToInt32(reader["entrada_confirmada"]), Convert.ToInt32(reader["pagamento_efetuado"]), Convert.ToInt32(reader["entrada_rejeitada"]), Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToString(reader["rejeicao_codigo"]), Convert.ToString(reader["rejeicao_msg"]), Convert.ToInt32(reader["ticket"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["codigo"]) }, new Boleto_avulso() { codigo = Convert.ToInt32(reader["boleto_avulso"]) });
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Boleto Buscar(Entrada entrada)
        {
            try
            {
                Boleto boleto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data, isnull(conta, 0) AS conta, isnull(entrada, 0) AS entrada, isnull(cliente, 0) AS cliente, isnull(painel, 0) AS painel, isnull(valor, 0) AS valor, isnull(multa, 0) AS multa, isnull(juros, 0) AS juros, isnull(protesto, 0) AS protesto, isnull(vencimento, '1900-01-01') AS vencimento, isnull(impresso, 0) AS impresso, isnull(instrucoes, '') AS instrucoes, isnull(impresso_data, '1900-01-01') AS impresso_data, isnull(remessa, 0) AS remessa, isnull(remessa_data, '1900-01-01') AS remessa_data, isnull(retorno, 0) AS retorno, isnull(retorno_data, '1900-01-01') AS retorno_data, isnull(arquivo, '') AS arquivo, isnull(remessa_codigo, 0) AS remessa_codigo, isnull(retorno_codigo, 0) AS retorno_codigo, isnull(retorno_msg_erro, '') AS retorno_msg_erro, isnull(entrada_confirmada, 0) AS entrada_confirmada, isnull(pagamento_efetuado, 0) AS pagamento_efetuado, isnull(entrada_rejeitada, 0) AS entrada_rejeitada, isnull(movimento_codigo, '') AS movimento_codigo, isnull(movimento_descricao, '') AS movimento_descricao, isnull(rejeicao_codigo, '') AS rejeicao_codigo, isnull(rejeicao_msg, '') AS rejeicao_msg, isnull(ticket, 0) AS ticket, isnull(aluno_pgto, 0) AS aluno_pgto, isnull(boleto_avulso, 0) as boleto_avulso FROM boleto WHERE entrada = @entrada");
                quey.SetParameter("entrada", entrada.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = new Boleto(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["conta"]), new Entrada() { codigo = Convert.ToInt32(reader["entrada"]) }, Convert.ToInt32(reader["cliente"]), Convert.ToInt32(reader["painel"]), Convert.ToDouble(reader["valor"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToInt32(reader["protesto"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["impresso"]), Convert.ToString(reader["instrucoes"]), Convert.ToDateTime(reader["impresso_data"]), Convert.ToInt32(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["retorno"]), Convert.ToDateTime(reader["retorno_data"]), Convert.ToString(reader["arquivo"]), Convert.ToInt32(reader["remessa_codigo"]), Convert.ToInt32(reader["retorno_codigo"]), Convert.ToString(reader["retorno_msg_erro"]), Convert.ToInt32(reader["entrada_confirmada"]), Convert.ToInt32(reader["pagamento_efetuado"]), Convert.ToInt32(reader["entrada_rejeitada"]), Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToString(reader["rejeicao_codigo"]), Convert.ToString(reader["rejeicao_msg"]), Convert.ToInt32(reader["ticket"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["codigo"]) }, new Boleto_avulso() { codigo = Convert.ToInt32(reader["boleto_avulso"]) });
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Boleto Buscar(Boleto_avulso boleto_avulso)
        {
            try
            {
                Boleto boleto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(data, '1900-01-01') AS data, isnull(conta, 0) AS conta, isnull(entrada, 0) AS entrada, isnull(cliente, 0) AS cliente, isnull(painel, 0) AS painel, isnull(valor, 0) AS valor, isnull(multa, 0) AS multa, isnull(juros, 0) AS juros, isnull(protesto, 0) AS protesto, isnull(vencimento, '1900-01-01') AS vencimento, isnull(impresso, 0) AS impresso, isnull(instrucoes, '') AS instrucoes, isnull(impresso_data, '1900-01-01') AS impresso_data, isnull(remessa, 0) AS remessa, isnull(remessa_data, '1900-01-01') AS remessa_data, isnull(retorno, 0) AS retorno, isnull(retorno_data, '1900-01-01') AS retorno_data, isnull(arquivo, '') AS arquivo, isnull(remessa_codigo, 0) AS remessa_codigo, isnull(retorno_codigo, 0) AS retorno_codigo, isnull(retorno_msg_erro, '') AS retorno_msg_erro, isnull(entrada_confirmada, 0) AS entrada_confirmada, isnull(pagamento_efetuado, 0) AS pagamento_efetuado, isnull(entrada_rejeitada, 0) AS entrada_rejeitada, isnull(movimento_codigo, '') AS movimento_codigo, isnull(movimento_descricao, '') AS movimento_descricao, isnull(rejeicao_codigo, '') AS rejeicao_codigo, isnull(rejeicao_msg, '') AS rejeicao_msg, isnull(ticket, 0) AS ticket, isnull(aluno_pgto, 0) AS aluno_pgto, isnull(boleto_avulso, 0) as boleto_avulso FROM boleto WHERE boleto_avulso = @boleto_avulso");
                quey.SetParameter("boleto_avulso", boleto_avulso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = new Boleto(Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["conta"]), new Entrada() { codigo = Convert.ToInt32(reader["entrada"]) }, Convert.ToInt32(reader["cliente"]), Convert.ToInt32(reader["painel"]), Convert.ToDouble(reader["valor"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToInt32(reader["protesto"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["impresso"]), Convert.ToString(reader["instrucoes"]), Convert.ToDateTime(reader["impresso_data"]), Convert.ToInt32(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["retorno"]), Convert.ToDateTime(reader["retorno_data"]), Convert.ToString(reader["arquivo"]), Convert.ToInt32(reader["remessa_codigo"]), Convert.ToInt32(reader["retorno_codigo"]), Convert.ToString(reader["retorno_msg_erro"]), Convert.ToInt32(reader["entrada_confirmada"]), Convert.ToInt32(reader["pagamento_efetuado"]), Convert.ToInt32(reader["entrada_rejeitada"]), Convert.ToString(reader["movimento_codigo"]), Convert.ToString(reader["movimento_descricao"]), Convert.ToString(reader["rejeicao_codigo"]), Convert.ToString(reader["rejeicao_msg"]), Convert.ToInt32(reader["ticket"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["codigo"]) }, new Boleto_avulso() { codigo = Convert.ToInt32(reader["boleto_avulso"]) });
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<BoletoAluno> BoletosAluno(string cpf_cnpj)
        {
            try
            {
                List<BoletoAluno> boleto = new List<BoletoAluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT boleto.protesto AS protesto, boleto.codigo AS codigo, boleto.valor AS valor, boleto.vencimento AS vencimento, boleto.movimento_descricao AS descricao, boleto.pagamento_efetuado AS pagamento_efetuado, cliente.nome AS nome, boleto.remessa AS remessa, isnull(boleto.remessa_data, '01/01/1900') AS remessa_data, entrada.situacao AS entrada_situacao, isnull((SELECT TOP 1 curso.titulo FROM curso WHERE titulo1 = cliente_grupo.grupo), '') AS curso FROM boleto, cliente, entrada, cliente_grupo WHERE boleto.cliente = cliente.codigo AND cliente.cpf_cnpj = @cpf_cnpj AND entrada.codigo = boleto.entrada AND entrada.situacao != 4 AND cliente_grupo.codigo = cliente.grupo AND EXISTS (SELECT TOP 1 aluno_curso.situacao FROM curso INNER JOIN aluno_curso ON curso.codigo = aluno_curso.curso INNER JOIN aluno ON aluno.codigo = aluno_curso.aluno WHERE curso.titulo1 = cliente_grupo.grupo AND replace(replace(replace(replace(aluno.cpf, '-', ''), '.', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cliente.cpf_cnpj, '-', ''), '.', ''), '/', ''), ' ', '') AND aluno_curso.situacao <= 2) ORDER BY cliente_grupo.grupo, boleto.vencimento");
                quey.SetParameter("cpf_cnpj", cpf_cnpj);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    boleto.Add(new BoletoAluno(Convert.ToBoolean(reader["protesto"]), Convert.ToInt32(reader["codigo"]), Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToString(reader["descricao"]), Convert.ToBoolean(reader["pagamento_efetuado"]), Convert.ToString(reader["nome"]), Convert.ToBoolean(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["entrada_situacao"]), Convert.ToString(reader["curso"])));
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<BoletoAluno> BoletosAluno(string cpf_cnpj, string curso)
        {
            try
            {
                List<BoletoAluno> boleto = new List<BoletoAluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT boleto.protesto AS protesto, boleto.codigo AS codigo, boleto.valor AS valor, boleto.vencimento AS vencimento, boleto.movimento_descricao AS descricao, boleto.pagamento_efetuado AS pagamento_efetuado, cliente.nome AS nome, boleto.remessa AS remessa, isnull(boleto.remessa_data, '01/01/1900') AS remessa_data, entrada.situacao AS entrada_situacao, isnull((SELECT TOP 1 curso.titulo FROM curso WHERE titulo1 = cliente_grupo.grupo), '') AS curso FROM boleto inner join entrada on entrada.codigo = boleto.entrada inner join cliente on boleto.cliente = cliente.codigo inner join cliente_grupo on cliente_grupo.codigo = cliente.grupo WHERE cliente.cpf_cnpj = @cpf_cnpj AND cliente_grupo.grupo like @curso AND entrada.situacao != 4 AND entrada.situacao != 5 AND EXISTS (SELECT TOP 1 aluno_curso.situacao FROM curso INNER JOIN aluno_curso ON curso.codigo = aluno_curso.curso INNER JOIN aluno ON aluno.codigo = aluno_curso.aluno WHERE curso.titulo1 = cliente_grupo.grupo AND replace(replace(replace(replace(aluno.cpf, '-', ''), '.', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cliente.cpf_cnpj, '-', ''), '.', ''), '/', ''), ' ', '') AND aluno_curso.situacao <= 2) ORDER BY cliente_grupo.grupo, boleto.vencimento");
                quey.SetParameter("cpf_cnpj", cpf_cnpj)
                    .SetParameter("curso", "%"+curso+"%");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    boleto.Add(new BoletoAluno(Convert.ToBoolean(reader["protesto"]), Convert.ToInt32(reader["codigo"]), Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToString(reader["descricao"]), Convert.ToBoolean(reader["pagamento_efetuado"]), Convert.ToString(reader["nome"]), Convert.ToBoolean(reader["remessa"]), Convert.ToDateTime(reader["remessa_data"]), Convert.ToInt32(reader["entrada_situacao"]), Convert.ToString(reader["curso"])));
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int BuscarVencimento(Aluno_pgto aluno_pgto)
        {
            try
            {
                int boleto = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo FROM boleto WHERE aluno_pgto = @aluno_pgto and vencimento >= @data ORDER BY codigo DESC");
                quey.SetParameter("aluno_pgto", aluno_pgto.codigo).
                    SetParameter("data", DateTime.Now.Date);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto = Convert.ToInt32(reader["codigo"]);
                }
                reader.Close();
                session.Close();

                return boleto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
