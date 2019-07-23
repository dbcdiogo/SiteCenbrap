using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class EntradaDB
    {
        public void Salvar(Entrada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Entrada (cliente,painel,data,conta,conta_devolucao,valor,vencimento,situacao,multa,juros,desconto,tipo_entrada,identificacao,data_quitado,data_recebimento,data_devolucao,nota_fiscal,data_nota_fiscal,tipo_pgto,boleto,parcela,xml_envio,cod_verificacao,xml_retorno,arquivo_xml,obs_cancelado,negociacao,emolumento,negativado,negativado_data,negativado_data_removido,valor_parcela1,valor_parcela2,valor_parcela3,valor_parcela4,valor_parcela5,valor_parcela6,data_recebimento2,data_recebimento3,data_recebimento4,data_recebimento5,data_recebimento6) VALUES (@cliente,@painel,@data,@conta,@conta_devolucao,@valor,@vencimento,@situacao,@multa,@juros,@desconto,@tipo_entrada,@identificacao,@data_quitado,@data_recebimento,@data_devolucao,@nota_fiscal,@data_nota_fiscal,@tipo_pgto,@boleto,@parcela,@xml_envio,@cod_verificacao,@xml_retorno,@arquivo_xml,@obs_cancelado,@negociacao,@emolumento,@negativado,@negativado_data,@negativado_data_removido,@valor_parcela1,@valor_parcela2,@valor_parcela3,@valor_parcela4,@valor_parcela5,@valor_parcela6,@data_recebimento2,@data_recebimento3,@data_recebimento4,@data_recebimento5,@data_recebimento6) ");
                query.SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("conta", variavel.conta.codigo)
                    .SetParameter("conta_devolucao", variavel.conta_devolucao.codigo)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("multa", variavel.multa)
                    .SetParameter("juros", variavel.juros)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("tipo_entrada", variavel.tipo_entrada.codigo)
                    .SetParameter("identificacao", variavel.identificacao)
                    .SetParameter("data_quitado", variavel.data_quitado)
                    .SetParameter("data_recebimento", variavel.data_recebimento)
                    .SetParameter("data_devolucao", variavel.data_devolucao)
                    .SetParameter("nota_fiscal", variavel.nota_fiscal)
                    .SetParameter("data_nota_fiscal", variavel.data_nota_fiscal)
                    .SetParameter("tipo_pgto", variavel.tipo_pgto)
                    .SetParameter("boleto", variavel.boleto)
                    .SetParameter("parcela", variavel.parcela)
                    .SetParameter("xml_envio", variavel.xml_envio)
                    .SetParameter("cod_verificacao", variavel.cod_verificacao)
                    .SetParameter("xml_retorno", variavel.xml_retorno)
                    .SetParameter("arquivo_xml", variavel.arquivo_xml)
                    .SetParameter("obs_cancelado", variavel.obs_cancelado)
                    .SetParameter("negociacao", variavel.negociacao)
                    .SetParameter("emolumento", variavel.emolumento)
                    .SetParameter("negativado", variavel.negativado)
                    .SetParameter("negativado_data", variavel.negativado_data)
                    .SetParameter("negativado_data_removido", variavel.negativado_data_removido)
                    
                    .SetParameter("valor_parcela1", variavel.valor_parcela1)
                    .SetParameter("valor_parcela2", variavel.valor_parcela2)
                    .SetParameter("valor_parcela3", variavel.valor_parcela3)
                    .SetParameter("valor_parcela4", variavel.valor_parcela4)
                    .SetParameter("valor_parcela5", variavel.valor_parcela5)
                    .SetParameter("valor_parcela6", variavel.valor_parcela6)

                    .SetParameter("data_recebimento2", variavel.data_recebimento2)
                    .SetParameter("data_recebimento3", variavel.data_recebimento3)
                    .SetParameter("data_recebimento4", variavel.data_recebimento4)
                    .SetParameter("data_recebimento5", variavel.data_recebimento5)
                    .SetParameter("data_recebimento6", variavel.data_recebimento6);

                query.ExecuteUpdate();
                session.Close();
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Entrada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Entrada SET cliente = @cliente, painel = @painel, data = @data, conta = @conta, conta_devolucao = @conta_devolucao, valor = @valor, vencimento = @vencimento, situacao = @situacao, multa = @multa, juros = @juros, desconto = @desconto, tipo_entrada = @tipo_entrada, identificacao = @identificacao, data_quitado = @data_quitado, data_recebimento = @data_recebimento, data_devolucao = @data_devolucao, nota_fiscal = @nota_fiscal, data_nota_fiscal = @data_nota_fiscal, tipo_pgto = @tipo_pgto, boleto = @boleto, parcela = @parcela, xml_envio = @xml_envio, cod_verificacao = @cod_verificacao, xml_retorno = @xml_retorno, arquivo_xml = @arquivo_xml, obs_cancelado = @obs_cancelado, negociacao = @negociacao, emolumento = @emolumento, negativado = @negativado, negativado_data = @negativado_data, negativado_data_removido = @negativado_data_removido, valor_parcela1 = @valor_parcela1, valor_parcela2 = @valor_parcela2, valor_parcela3 = @valor_parcela3, valor_parcela4 = @valor_parcela4, valor_parcela5 = @valor_parcela5, valor_parcela6 = @valor_parcela6, data_recebimento2 = @data_recebimento2, data_recebimento3 = @data_recebimento3, data_recebimento4 = @data_recebimento4, data_recebimento5 = @data_recebimento5, data_recebimento6 = @data_recebimento6 WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("conta", variavel.conta)
                    .SetParameter("conta_devolucao", variavel.conta_devolucao)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("vencimento", variavel.vencimento)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("multa", variavel.multa)
                    .SetParameter("juros", variavel.juros)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("tipo_entrada", variavel.tipo_entrada.codigo)
                    .SetParameter("identificacao", variavel.identificacao)
                    .SetParameter("data_quitado", variavel.data_quitado)
                    .SetParameter("data_recebimento", variavel.data_recebimento)
                    .SetParameter("data_devolucao", variavel.data_devolucao)
                    .SetParameter("nota_fiscal", variavel.nota_fiscal)
                    .SetParameter("data_nota_fiscal", variavel.data_nota_fiscal)
                    .SetParameter("tipo_pgto", variavel.tipo_pgto)
                    .SetParameter("boleto", variavel.boleto)
                    .SetParameter("parcela", variavel.parcela)
                    .SetParameter("xml_envio", variavel.xml_envio)
                    .SetParameter("cod_verificacao", variavel.cod_verificacao)
                    .SetParameter("xml_retorno", variavel.xml_retorno)
                    .SetParameter("arquivo_xml", variavel.arquivo_xml)
                    .SetParameter("obs_cancelado", variavel.obs_cancelado)
                    .SetParameter("negociacao", variavel.negociacao)
                    .SetParameter("emolumento", variavel.emolumento)
                    .SetParameter("negativado", variavel.negativado)
                    .SetParameter("negativado_data", variavel.negativado_data)
                    .SetParameter("negativado_data_removido", variavel.negativado_data_removido)

                    .SetParameter("valor_parcela1", variavel.valor_parcela1)
                    .SetParameter("valor_parcela2", variavel.valor_parcela2)
                    .SetParameter("valor_parcela3", variavel.valor_parcela3)
                    .SetParameter("valor_parcela4", variavel.valor_parcela4)
                    .SetParameter("valor_parcela5", variavel.valor_parcela5)
                    .SetParameter("valor_parcela6", variavel.valor_parcela6)

                    .SetParameter("data_recebimento2", variavel.data_recebimento2)
                    .SetParameter("data_recebimento3", variavel.data_recebimento3)
                    .SetParameter("data_recebimento4", variavel.data_recebimento4)
                    .SetParameter("data_recebimento5", variavel.data_recebimento5)
                    .SetParameter("data_recebimento6", variavel.data_recebimento6);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void NotaFiscal(string xml, string numero, string cod_verificacao, string xml_retorno)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Entrada SET nota_fiscal = @nota_fiscal, data_nota_fiscal = getdate(), cod_verificacao = @cod_verificacao, xml_retorno = @xml_retorno WHERE arquivo_xml = @arquivo_xml");
                query.SetParameter("arquivo_xml", xml)
                    .SetParameter("nota_fiscal", numero)
                    .SetParameter("cod_verificacao", cod_verificacao)
                    .SetParameter("xml_retorno", xml_retorno);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Entrada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Entrada WHERE codigo = @codigo ");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Entrada Buscar(int codigo)
        {
            try
            {
                Entrada entrada = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM entrada WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    entrada = new Entrada(Convert.ToInt32(reader["codigo"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), new Conta() { codigo = Convert.ToInt32(reader["conta"]) }, new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"])}, Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["situacao"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToDouble(reader["desconto"]), new Tipo_entradaDB().Buscar(Convert.ToInt32(reader["tipo_entrada"])), Convert.ToString(reader["identificacao"]), Convert.ToDateTime(reader["data_quitado"]), Convert.ToDateTime(reader["data_recebimento"]), Convert.ToDateTime(reader["data_devolucao"]), Convert.ToString(reader["nota_fiscal"]), Convert.ToDateTime(reader["data_nota_fiscal"]), Convert.ToString(reader["tipo_pgto"]), Convert.ToString(reader["boleto"]), Convert.ToString(reader["parcela"]), Convert.ToString(reader["xml_envio"]), Convert.ToString(reader["cod_verificacao"]), Convert.ToString(reader["xml_retorno"]), Convert.ToString(reader["arquivo_xml"]), Convert.ToString(reader["obs_cancelado"]), Convert.ToInt32(reader["negociacao"]), Convert.ToString(reader["emolumento"]), Convert.ToInt32(reader["negativado"]), Convert.ToDateTime(reader["negativado_data"]), Convert.ToDateTime(reader["negativado_data_removido"]));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public List<Entrada> Listar()
        {
            try
            {
                List<Entrada> entrada = new List<Entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT e.codigo, e.cliente, e.painel, e.data, e.conta, e.conta_devolucao, e.valor, e.vencimento, e.situacao, e.multa, e.juros, e.desconto, e.tipo_entrada, e.identificacao, isnull(e.data_quitado, '1900-01-01') AS data_quitado, isnull(e.data_recebimento, '1900-01-01') AS data_recebimento, isnull(e.data_devolucao, '1900-01-01') AS data_devolucao, isnull(e.nota_fiscal, '') AS nota_fiscal, isnull(e.data_nota_fiscal, '1900-01-01') AS data_nota_fiscal, isnull(e.tipo_pgto, '') AS tipo_pgto, e.boleto, e.parcela, isnull(e.xml_envio, '') AS xml_envio, isnull(e.cod_verificacao, '') AS cod_verificacao, isnull(e.xml_retorno, '') AS xml_retorno, isnull(e.arquivo_xml, '') AS arquivo_xml, isnull(e.obs_cancelado, '') AS obs_cancelado, e.negociacao, e.emolumento, e.negativado, isnull(e.negativado_data, '1900-01-01') AS negativado_data, isnull(e.negativado_data_removido, '1900-01-01') AS negativado_data_removido FROM entrada");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(new Entrada(Convert.ToInt32(reader["codigo"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), new Conta() { codigo = Convert.ToInt32(reader["conta"]) }, new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]) }, Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["situacao"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToDouble(reader["desconto"]), new Tipo_entradaDB().Buscar(Convert.ToInt32(reader["tipo_entrada"])), Convert.ToString(reader["identificacao"]), Convert.ToDateTime(reader["data_quitado"]), Convert.ToDateTime(reader["data_recebimento"]), Convert.ToDateTime(reader["data_devolucao"]), Convert.ToString(reader["nota_fiscal"]), Convert.ToDateTime(reader["data_nota_fiscal"]), Convert.ToString(reader["tipo_pgto"]), Convert.ToString(reader["boleto"]), Convert.ToString(reader["parcela"]), Convert.ToString(reader["xml_envio"]), Convert.ToString(reader["cod_verificacao"]), Convert.ToString(reader["xml_retorno"]), Convert.ToString(reader["arquivo_xml"]), Convert.ToString(reader["obs_cancelado"]), Convert.ToInt32(reader["negociacao"]), Convert.ToString(reader["emolumento"]), Convert.ToInt32(reader["negativado"]), Convert.ToDateTime(reader["negativado_data"]), Convert.ToDateTime(reader["negativado_data_removido"])));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Entrada> Listar(string ids)
        {
            try
            {
                List<Entrada> entrada = new List<Entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT e.codigo, e.cliente, e.painel, e.data, e.conta, e.conta_devolucao, e.valor, e.vencimento, e.situacao, e.multa, e.juros, e.desconto, e.tipo_entrada, e.identificacao, isnull(e.data_quitado, '1900-01-01') AS data_quitado, isnull(e.data_recebimento, '1900-01-01') AS data_recebimento, isnull(e.data_devolucao, '1900-01-01') AS data_devolucao, isnull(e.nota_fiscal, '') AS nota_fiscal, isnull(e.data_nota_fiscal, '1900-01-01') AS data_nota_fiscal, isnull(e.tipo_pgto, '') AS tipo_pgto, e.boleto, e.parcela, isnull(e.xml_envio, '') AS xml_envio, isnull(e.cod_verificacao, '') AS cod_verificacao, isnull(e.xml_retorno, '') AS xml_retorno, isnull(e.arquivo_xml, '') AS arquivo_xml, isnull(e.obs_cancelado, '') AS obs_cancelado, e.negociacao, e.emolumento, e.negativado, isnull(e.negativado_data, '1900-01-01') AS negativado_data, isnull(e.negativado_data_removido, '1900-01-01') AS negativado_data_removido FROM entrada as e WHERE e.codigo IN (" + ids + ") ORDER BY e.vencimento");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(new Entrada(Convert.ToInt32(reader["codigo"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), new Conta() { codigo = Convert.ToInt32(reader["conta"]) }, new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]) }, Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["situacao"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToDouble(reader["desconto"]), new Tipo_entradaDB().Buscar(Convert.ToInt32(reader["tipo_entrada"])), Convert.ToString(reader["identificacao"]), Convert.ToDateTime(reader["data_quitado"]), Convert.ToDateTime(reader["data_recebimento"]), Convert.ToDateTime(reader["data_devolucao"]), Convert.ToString(reader["nota_fiscal"]), Convert.ToDateTime(reader["data_nota_fiscal"]), Convert.ToString(reader["tipo_pgto"]), Convert.ToString(reader["boleto"]), Convert.ToString(reader["parcela"]), Convert.ToString(reader["xml_envio"]), Convert.ToString(reader["cod_verificacao"]), Convert.ToString(reader["xml_retorno"]), Convert.ToString(reader["arquivo_xml"]), Convert.ToString(reader["obs_cancelado"]), Convert.ToInt32(reader["negociacao"]), Convert.ToString(reader["emolumento"]), Convert.ToInt32(reader["negativado"]), Convert.ToDateTime(reader["negativado_data"]), Convert.ToDateTime(reader["negativado_data_removido"])));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Entrada> Listar(string cliente, int situacao, string vencimento_inicio, string vencimento_fim, string tipo, string conta, string pgto_inicio, string pgto_fim, string data_inicio, string data_fim, string identificacao, string boleto, int info, string dados, string negociacao, string negativacao, string ordem, bool unicaparcela = false)
        {
            try
            {
                string executar = "SELECT e.codigo, e.cliente, e.painel, p.nome as painel_nome, e.data, e.conta, c1.conta as conta_conta, e.conta_devolucao, isnull(c2.conta, '') as conta_devolucao_conta, e.valor, isnull(e.vencimento, '01/01/1900') as vencimento, e.situacao, e.multa, e.juros, e.desconto, e.tipo_entrada, te.tipo as tipo_entrada_tipo, e.identificacao, isnull(e.data_quitado, '01/01/1900') as data_quitado, isnull(e.data_recebimento, '01/01/1900') as data_recebimento, isnull(e.data_devolucao, '01/01/1900') as data_devolucao, e.nota_fiscal, isnull(e.data_nota_fiscal, '01/01/1900') as data_nota_fiscal, e.tipo_pgto, e.boleto, e.parcela, e.xml_envio, e.cod_verificacao, e.xml_retorno, e.arquivo_xml, e.obs_cancelado, e.negociacao, e.emolumento, e.negativado, isnull(e.negativado_data, '01/01/1900') as negativado_data, isnull(e.negativado_data_removido, '01/01/1900') as negativado_data_removido, c.nome, isnull(c.obs, '') as obs, isnull(c.cpf_cnpj, '') as cpf_cnpj, isnull(c.email, '') as email, isnull(c.telefone, '') as telefone, isnull(c.celular, '') as celular, c.grupo as grupo, isnull((select top 1 g.grupo from cliente_grupo as g where g.codigo = c.grupo), '') as grupo_nome ";
                if (info == 1 || (situacao >= 6 && situacao <= 9))
                    executar += ", dbo.AlunoInfo_ClienteGrupoCpf(c.codigo, c.grupo, c.cpf_cnpj) AS info, dbo.AlunoContrato_GrupoCpf(c.grupo, c.cpf_cnpj) AS contrato ";
                else
                    executar += ", '#100#' AS info, '' AS contrato ";

                executar += ", isnull(b.codigo, 0) AS boletoCodigo, isnull(b.remessa_codigo, 0) AS remessa_codigo, isnull(b.remessa_data, '01/01/1900') as remessa_data ";

                executar += ", isnull((SELECT count(ent.codigo) FROM entrada AS ent WHERE ent.cliente = e.cliente AND ent.situacao = 1 AND ent.vencimento < getdate()), 0) AS qtdAtrasado ";
                executar += ", isnull((SELECT count(ent.codigo) FROM entrada AS ent WHERE ent.cliente = e.cliente AND ent.situacao = 1 AND ent.vencimento >= getdate()), 0) AS qtdEmAberto ";
                executar += ", isnull((SELECT count(ent.codigo) FROM entrada AS ent WHERE ent.cliente = e.cliente AND ent.situacao = 2), 0) AS qtdPagos ";
                executar += ", isnull((SELECT count(ent.codigo) FROM entrada AS ent WHERE ent.cliente = e.cliente AND ent.situacao = 2), '') AS NegociacaoStatus ";

                executar += ", isnull((select top 1 concat('Negociado em ', day(n.data), '/', month(n.data), '/', year(n.data), '<BR>Próx. venc. ', (select top 1 concat(day(ba.vencimento), '/', month(ba.vencimento), '/', year(ba.vencimento)) from negociacao_boleto_avulso as nb inner join boleto_avulso as ba on ba.codigo = nb.boleto_avulso where nb.negociacao_id = n.negociacao_id and ba.situacao = 0 order by vencimento)) as vencimento from negociacao as n INNER JOIN negociacao_entrada as ne ON n.negociacao_id = ne.negociacao_id where ne.entrada = e.codigo), '') as negociacao_txt";
                executar += ", isnull((select top 1 concat('Negativado no venc ', day(en.vencimento), '/', month(en.vencimento), '/', year(en.vencimento)) from entrada as en WHERE en.negativado = 1 and en.cliente = e.cliente), '') as negativado_txt";

                executar += " FROM entrada AS e JOIN cliente AS c ON e.cliente = c.codigo JOIN painel as p ON e.painel = p.codigo JOIN tipo_entrada as te ON e.tipo_entrada = te.codigo JOIN conta as c1 ON e.conta = c1.codigo LEFT JOIN conta as c2 ON e.conta_devolucao = c2.codigo LEFT JOIN boleto as b ON b.entrada = e.codigo WHERE e.codigo > 0";

                if (cliente != "")
                    if (cliente.IndexOf('#') > -1)
                    {
                        executar += " AND EXISTS (select g.codigo from cliente_grupo as g where g.codigo = c.grupo AND g.grupo = '" + cliente.Replace("#", "") + "')";
                    } else {
                        if(cliente.IndexOf('(') > -1)
                        {
                            string grupo = cliente.Substring(cliente.IndexOf(')') + 2);
                            string cliente_codigo = cliente.Substring(cliente.IndexOf('(') + 1, (cliente.IndexOf(')') - cliente.IndexOf('(')) - 1);
                            cliente = cliente.Substring(0, cliente.IndexOf("(") - 1);
                            executar += " AND c.codigo = '" + cliente_codigo + "' AND EXISTS (SELECT g.codigo FROM cliente_grupo as g WHERE g.codigo = c.grupo AND g.grupo = '" + grupo + "')";
                        }
                        else
                        {
                            executar += " AND c.codigo = " + cliente;
                        }
                    }

                if (tipo != "")
                    executar += " AND e.tipo_entrada = " + tipo;

                if (conta != "")
                    executar += " AND e.conta = " + conta;

                if (boleto != "")
                    executar += " AND exists (SELECT b1.entrada FROM boleto as b1 WHERE b1.entrada = e.codigo AND b1.codigo IN (" + boleto + "))";

                if(situacao != 10)
                {
                    if(situacao == 6 || situacao == 7)
                    {
                        executar += " AND e.situacao = 1";
                    }
                    else if(situacao == 8 || situacao == 9)
                    {
                        executar += " AND e.situacao = 2";
                    }
                    else
                    {
                        executar += " AND situacao = " + situacao;
                    }
                }

                DateTime dat_inicio = Convert.ToDateTime("01/01/1900");
                DateTime dat_fim = Convert.ToDateTime("01/01/1900");

                if (data_inicio.Length == 10 && data_fim.Length == 10)
                {
                    dat_inicio = Convert.ToDateTime(data_inicio);
                    dat_fim = Convert.ToDateTime(data_fim);
                    executar += " AND e.data between @dat_inicio AND @dat_fim";
                }

                DateTime venc_inicio = Convert.ToDateTime("01/01/1900");
                DateTime venc_fim = Convert.ToDateTime("01/01/1900");

                if (vencimento_inicio.Length == 10 && vencimento_fim.Length == 10)
                {
                    venc_inicio = Convert.ToDateTime(vencimento_inicio);
                    venc_fim = Convert.ToDateTime(vencimento_fim);
                    executar += " AND e.vencimento between @venc_inicio AND @venc_fim";
                }

                DateTime pg_inicio = Convert.ToDateTime("01/01/1900");
                DateTime pg_fim = Convert.ToDateTime("01/01/1900");

                if (pgto_inicio.Length == 10 && pgto_fim.Length == 10)
                {
                    pg_inicio = Convert.ToDateTime(pgto_inicio);
                    pg_fim = Convert.ToDateTime(pgto_fim);
                    executar += " AND e.data_quitado BETWEEN @pg_inicio AND @pg_fim";
                }

                if (identificacao != "")
                    executar += " AND e.identificacao = '" + identificacao + "'";

                if (negativacao != "")
                    executar += " AND e.negativado = '" + negativacao + "'";

                if (negociacao != "")
                    executar += " AND e.negociacao = '" + negociacao + "'";

                if (unicaparcela)
                {
                    executar += " AND NOT EXISTS (SELECT e1.codigo FROM entrada as e1 INNER JOIN cliente as c1 ON e1.cliente = c1.codigo WHERE c1.codigo = c.codigo AND e1.vencimento < getdate() AND e1.situacao = 1 AND e1.codigo != e.codigo)";
                }

                if (ordem == "")
                    executar += " ORDER BY e.vencimento, e.situacao";
                else
                    executar += " ORDER BY c.nome, e.vencimento, e.situacao";

                List<Entrada> entrada = new List<Entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                if(dat_inicio > Convert.ToDateTime("01/01/1900"))
                {
                    quey.SetParameter("@dat_inicio", dat_inicio);
                    quey.SetParameter("@dat_fim", dat_fim);
                }
                if (venc_inicio > Convert.ToDateTime("01/01/1900"))
                {
                    quey.SetParameter("@venc_inicio", venc_inicio);
                    quey.SetParameter("@venc_fim", venc_fim);
                }
                if (pg_inicio > Convert.ToDateTime("01/01/1900"))
                {
                    quey.SetParameter("@pg_inicio", pg_inicio);
                    quey.SetParameter("@pg_fim", pg_fim);
                }
                IDataReader reader = quey.ExecuteQuery();

                bool incluir = true;
                while (reader.Read())
                {
                    incluir = true;
                    if (situacao >= 6 && situacao <= 9)
                    {
                        if(((situacao == 6 || situacao == 8) && Convert.ToString(reader["contrato"]) == "com") || ((situacao == 7 || situacao == 9) && Convert.ToString(reader["contrato"]) == "sem"))
                        {
                            incluir = false;
                        }

                    }

                    if(incluir)
                        entrada.Add(new Entrada(Convert.ToInt32(reader["codigo"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]), nome = Convert.ToString(reader["nome"]), obs = Convert.ToString(reader["obs"]), cpf_cnpj = Convert.ToString(reader["cpf_cnpj"]), email = Convert.ToString(reader["email"]), telefone = Convert.ToString(reader["telefone"]), celular = Convert.ToString(reader["celular"]), grupo = new Cliente_grupo() { codigo = Convert.ToInt32(reader["grupo"]), grupo = Convert.ToString(reader["grupo_nome"]) } }, new Painel() { codigo = Convert.ToInt32(reader["painel"]), nome = Convert.ToString(reader["painel_nome"]) }, Convert.ToDateTime(reader["data"]), new Conta() { codigo = Convert.ToInt32(reader["conta"]), conta = Convert.ToString(reader["conta_conta"]) }, new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]), conta = Convert.ToString(reader["conta_devolucao_conta"]) }, Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["situacao"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToDouble(reader["desconto"]), new Tipo_entrada() { codigo = Convert.ToInt32(reader["tipo_entrada"]), tipo = Convert.ToString(reader["tipo_entrada_tipo"]) }, Convert.ToString(reader["identificacao"]), Convert.ToDateTime(reader["data_quitado"]), Convert.ToDateTime(reader["data_recebimento"]), Convert.ToDateTime(reader["data_devolucao"]), Convert.ToString(reader["nota_fiscal"]), Convert.ToDateTime(reader["data_nota_fiscal"]), Convert.ToString(reader["tipo_pgto"]), Convert.ToString(reader["boleto"]), Convert.ToString(reader["parcela"]), Convert.ToString(reader["xml_envio"]), Convert.ToString(reader["cod_verificacao"]), Convert.ToString(reader["xml_retorno"]), Convert.ToString(reader["arquivo_xml"]), Convert.ToString(reader["obs_cancelado"]), Convert.ToInt32(reader["negociacao"]), Convert.ToString(reader["emolumento"]), Convert.ToInt32(reader["negativado"]), Convert.ToDateTime(reader["negativado_data"]), Convert.ToDateTime(reader["negativado_data_removido"]), 0, Convert.ToString(reader["contrato"]), Convert.ToString(reader["info"]), new Boleto() {codigo = Convert.ToInt32(reader["boletoCodigo"]) , remessa_codigo = Convert.ToInt32(reader["remessa_codigo"]), remessa_data = Convert.ToDateTime(reader["remessa_data"]) }, Convert.ToInt32(reader["qtdAtrasado"]), Convert.ToInt32(reader["qtdEmAberto"]), Convert.ToInt32(reader["qtdPagos"]), Convert.ToString(reader["negociacao_txt"]), Convert.ToString(reader["negativado_txt"])));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Entrada> VenceAmanha()
        {
            try
            {
                List<Entrada> entrada = new List<Entrada>();
                DateTime vencimento = DateTime.Now.AddDays(1);

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT e.codigo, e.cliente, e.painel, e.data, e.conta, e.conta_devolucao, e.valor, e.vencimento, e.situacao, e.multa, e.juros, e.desconto, e.tipo_entrada, e.identificacao, isnull(e.data_quitado, '1900-01-01') AS data_quitado, isnull(e.data_recebimento, '1900-01-01') AS data_recebimento, isnull(e.data_devolucao, '1900-01-01') AS data_devolucao, isnull(e.nota_fiscal, '') AS nota_fiscal, isnull(e.data_nota_fiscal, '1900-01-01') AS data_nota_fiscal, isnull(e.tipo_pgto, '') AS tipo_pgto, e.boleto, e.parcela, isnull(e.xml_envio, '') AS xml_envio, isnull(e.cod_verificacao, '') AS cod_verificacao, isnull(e.xml_retorno, '') AS xml_retorno, isnull(e.arquivo_xml, '') AS arquivo_xml, isnull(e.obs_cancelado, '') AS obs_cancelado, e.negociacao, e.emolumento, e.negativado, isnull(e.negativado_data, '1900-01-01') AS negativado_data, isnull(e.negativado_data_removido, '1900-01-01') AS negativado_data_removido, b.codigo AS codboleto FROM entrada AS e JOIN boleto AS b ON e.codigo = b.entrada WHERE e.situacao = 1 AND e.vencimento = @vencimento AND ( day(e.vencimento) = 10 OR day(e.vencimento) = 20 OR day(e.vencimento) = 30 ) and not exists (select * from aluno_curso as ac inner join aluno as a on ac.aluno = a.codigo inner join curso as c on ac.curso = c.codigo inner join cliente as cl on replace(replace(replace(replace(a.cpf, '.', ''), '-', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cl.cpf_cnpj, '.', ''), '-', ''), '/', ''), ' ', '') inner join cliente_grupo as g on cl.grupo = g.codigo and g.grupo = c.titulo1 where ac.situacao = 2 and ac.nao_fara_o_curso is not null and ac.nao_fara_o_curso != '1900-01-01' and cl.codigo = e.cliente)");
                quey.SetParameter("vencimento", vencimento.Date);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(
                        new Entrada()
                        {
                            codigo = Convert.ToInt32(reader["codigo"]),
                            cliente = new ClienteDB().Buscar(Convert.ToInt32(reader["cliente"])),
                            painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                            data = Convert.ToDateTime(reader["data"]),
                            conta = new Conta() { codigo = Convert.ToInt32(reader["conta"]) },
                            conta_devolucao = new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]) },
                            valor = Convert.ToDouble(reader["valor"]),
                            vencimento = Convert.ToDateTime(reader["vencimento"]),
                            situacao = Convert.ToInt32(reader["situacao"]),
                            multa = Convert.ToDouble(reader["multa"]),
                            juros = Convert.ToDouble(reader["juros"]),
                            desconto = Convert.ToDouble(reader["desconto"]),
                            tipo_entrada = new Tipo_entradaDB().Buscar( Convert.ToInt32(reader["tipo_entrada"]) ),
                            identificacao = Convert.ToString(reader["identificacao"]),
                            data_quitado = Convert.ToDateTime(reader["data_quitado"]),
                            data_recebimento = Convert.ToDateTime(reader["data_recebimento"]),
                            data_devolucao = Convert.ToDateTime(reader["data_devolucao"]),
                            nota_fiscal = Convert.ToString(reader["nota_fiscal"]),
                            data_nota_fiscal = Convert.ToDateTime(reader["data_nota_fiscal"]),
                            tipo_pgto = Convert.ToString(reader["tipo_pgto"]),
                            boleto = Convert.ToString(reader["boleto"]),
                            parcela = Convert.ToString(reader["parcela"]),
                            xml_envio = Convert.ToString(reader["xml_envio"]),
                            cod_verificacao = Convert.ToString(reader["cod_verificacao"]),
                            xml_retorno = Convert.ToString(reader["xml_retorno"]),
                            arquivo_xml = Convert.ToString(reader["arquivo_xml"]),
                            obs_cancelado = Convert.ToString(reader["obs_cancelado"]),
                            negociacao = Convert.ToInt32(reader["negociacao"]),
                            emolumento = Convert.ToString(reader["emolumento"]),
                            negativado = Convert.ToInt32(reader["negativado"]),
                            negativado_data = Convert.ToDateTime(reader["negativado_data"]),
                            negativado_data_removido = Convert.ToDateTime(reader["negativado_data_removido"]),
                            codboleto = Convert.ToInt32(reader["codboleto"])
                        }
                        );
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Entrada> PgtoOntem()
        {
            try
            {
                List<Entrada> entrada = new List<Entrada>();
                DateTime pgtoontem = DateTime.Now.AddDays(-1);

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT e.codigo, e.cliente, e.painel, e.data, e.conta, e.conta_devolucao, e.valor, e.vencimento, e.situacao, e.multa, e.juros, e.desconto, e.tipo_entrada, e.identificacao, isnull(e.data_quitado, '1900-01-01') AS data_quitado, isnull(e.data_recebimento, '1900-01-01') AS data_recebimento, isnull(e.data_devolucao, '1900-01-01') AS data_devolucao, isnull(e.nota_fiscal, '') AS nota_fiscal, isnull(e.data_nota_fiscal, '1900-01-01') AS data_nota_fiscal, isnull(e.tipo_pgto, '') AS tipo_pgto, e.boleto, e.parcela, isnull(e.xml_envio, '') AS xml_envio, isnull(e.cod_verificacao, '') AS cod_verificacao, isnull(e.xml_retorno, '') AS xml_retorno, isnull(e.arquivo_xml, '') AS arquivo_xml, isnull(e.obs_cancelado, '') AS obs_cancelado, e.negociacao, e.emolumento, e.negativado, isnull(e.negativado_data, '1900-01-01') AS negativado_data, isnull(e.negativado_data_removido, '1900-01-01') AS negativado_data_removido, b.codigo AS codboleto FROM entrada AS e JOIN boleto AS b ON e.codigo = b.entrada WHERE e.situacao = 2 AND e.data_quitado = @data_quitado");
                quey.SetParameter("data_quitado", pgtoontem.Date);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(
                        new Entrada()
                        {
                            codigo = Convert.ToInt32(reader["codigo"]),
                            cliente = new ClienteDB().Buscar(Convert.ToInt32(reader["cliente"])),
                            painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                            data = Convert.ToDateTime(reader["data"]),
                            conta = new Conta() { codigo = Convert.ToInt32(reader["conta"]) },
                            conta_devolucao = new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]) },
                            valor = Convert.ToDouble(reader["valor"]),
                            vencimento = Convert.ToDateTime(reader["vencimento"]),
                            situacao = Convert.ToInt32(reader["situacao"]),
                            multa = Convert.ToDouble(reader["multa"]),
                            juros = Convert.ToDouble(reader["juros"]),
                            desconto = Convert.ToDouble(reader["desconto"]),
                            tipo_entrada = new Tipo_entradaDB().Buscar(Convert.ToInt32(reader["tipo_entrada"])),
                            identificacao = Convert.ToString(reader["identificacao"]),
                            data_quitado = Convert.ToDateTime(reader["data_quitado"]),
                            data_recebimento = Convert.ToDateTime(reader["data_recebimento"]),
                            data_devolucao = Convert.ToDateTime(reader["data_devolucao"]),
                            nota_fiscal = Convert.ToString(reader["nota_fiscal"]),
                            data_nota_fiscal = Convert.ToDateTime(reader["data_nota_fiscal"]),
                            tipo_pgto = Convert.ToString(reader["tipo_pgto"]),
                            boleto = Convert.ToString(reader["boleto"]),
                            parcela = Convert.ToString(reader["parcela"]),
                            xml_envio = Convert.ToString(reader["xml_envio"]),
                            cod_verificacao = Convert.ToString(reader["cod_verificacao"]),
                            xml_retorno = Convert.ToString(reader["xml_retorno"]),
                            arquivo_xml = Convert.ToString(reader["arquivo_xml"]),
                            obs_cancelado = Convert.ToString(reader["obs_cancelado"]),
                            negociacao = Convert.ToInt32(reader["negociacao"]),
                            emolumento = Convert.ToString(reader["emolumento"]),
                            negativado = Convert.ToInt32(reader["negativado"]),
                            negativado_data = Convert.ToDateTime(reader["negativado_data"]),
                            negativado_data_removido = Convert.ToDateTime(reader["negativado_data_removido"]),
                            codboleto = Convert.ToInt32(reader["codboleto"])
                        }
                        );
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<DadosIR> DadosIR(int ano)
        {
            try
            {
                List<DadosIR> entrada = new List<DadosIR>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select c.codigo, c.nome, c.cpf_cnpj, c.email, sum(e.valor) AS total from entrada AS e JOIN cliente AS c ON e.cliente = c.codigo WHERE e.data_recebimento between '"+ano+ "-01-01' and '" + ano + "-12-31' AND e.tipo_entrada = 1 AND e.conta IN (4, 7) GROUP BY c.codigo, c.nome, c.cpf_cnpj, c.email ORDER BY c.nome");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(new DadosIR(Convert.ToInt32(reader["codigo"]), ano, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf_cnpj"]), Convert.ToString(reader["email"]), Convert.ToDouble(reader["total"])));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<DadosIR> DadosIRNovo(int ano)
        {
            try
            {
                List<DadosIR> entrada = new List<DadosIR>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select c.codigo, c.nome, c.cpf_cnpj, c.email, sum(e.valor) AS total, cs.certificadora_id from entrada AS e JOIN cliente AS c ON e.cliente = c.codigo JOIN cliente_grupo AS cg ON cg.codigo = c.grupo JOIN curso AS cs ON cs.titulo1 = cg.grupo WHERE e.data_recebimento between '" + ano + "-01-01' and '" + ano + "-12-31' AND e.tipo_entrada in (1,3) AND e.conta IN (3, 4, 6, 7, 8, 9) and cs.certificadora_id not in (2,3,4,5) and e.data_devolucao is null GROUP BY c.codigo, c.nome, c.cpf_cnpj, c.email, cs.certificadora_id ORDER BY c.nome");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    entrada.Add(new DadosIR(Convert.ToInt32(reader["codigo"]), ano, Convert.ToString(reader["nome"]), Convert.ToString(reader["cpf_cnpj"]), Convert.ToString(reader["email"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["certificadora_id"])));
                }
                reader.Close();
                session.Close();

                return entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(Entrada entrada)
        {
            try
            {
                string s_data = entrada.data.Year + "-" + entrada.data.Month + "-" + entrada.data.Day;

                bool retorno = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM entrada WHERE cliente = @cliente AND data = cast(@data as date) AND conta = @conta AND situacao = @situacao AND tipo_entrada = @tipo_entrada");
                quey.SetParameter("cliente", entrada.cliente.codigo)
                    .SetParameter("data", s_data)
                    .SetParameter("conta", entrada.conta.codigo)
                    .SetParameter("situacao", entrada.situacao)
                    .SetParameter("tipo_entrada", entrada.tipo_entrada.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = true;
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
