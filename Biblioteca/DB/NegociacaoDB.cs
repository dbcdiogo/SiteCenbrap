using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class NegociacaoDB
    {
        public int Salvar(Negociacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Negociacao (cliente, painel, data, subtotal, desconto, total, parcelas, vencimento) VALUES (@cliente, @painel, @data, @subtotal, @desconto, @total, @parcelas, @vencimento) ");
                query.SetParameter("cliente", variavel.cliente.codigo)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("subtotal", variavel.subtotal)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("total", variavel.total)
                    .SetParameter("parcelas", variavel.parcelas)
                    .SetParameter("vencimento", variavel.vencimento);
                query.ExecuteUpdate();
                session.Close();

                int id = 0;

                DBSession session1 = new DBSession();
                Query quey = session1.CreateQuery("SELECT negociacao_id FROM negociacao WHERE painel = @painel AND cliente = @cliente ORDER BY negociacao_id DESC");
                quey.SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("cliente", variavel.cliente.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["negociacao_id"]);
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

        public void Alterar(Negociacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Negociacao SET vencimento = @vencimento, parcelas = @parcelas, subtotal = @subtotal, desconto = @desconto, total = @total WHERE negociacao_id = @negociacao_id");
                query.SetParameter("negociacao_id", variavel.negociacao_id)
                    .SetParameter("subtotal", variavel.subtotal)
                    .SetParameter("desconto", variavel.desconto)
                    .SetParameter("total", variavel.total)
                    .SetParameter("parcelas", variavel.parcelas)
                    .SetParameter("vencimento", variavel.vencimento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Negociacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Negociacao WHERE negociacao_id = @negociacao_id; DELETE FROM Negociacao_entrada WHERE negociacao_id = @negociacao_id; DELETE FROM Negociacao_boleto_avulso WHERE negociacao_id = @negociacao_id");
                query.SetParameter("negociacao_id", variavel.negociacao_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Negociacao Buscar(int codigo)
        {
            try
            {
                Negociacao boleto_avulso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, cliente, painel, isnull(data, '01/01/1900') as data, isnull(vencimento, '01/01/1900') as vencimento, subtotal, desconto, total, parcelas FROM negociacao WHERE negociacao_id = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    boleto_avulso = new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"]));
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

        public List<Negociacao> Listar()
        {
            try
            {
                List<Negociacao> retorno = new List<Negociacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, cliente, painel, isnull(data, '01/01/1900') as data, isnull(vencimento, '01/01/1900') as vencimento, subtotal, desconto, total, parcelas FROM negociacao ORDER BY data DESC");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"])));
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

        public List<Negociacao> Listar(string cliente, int situacao, string data_inicio, string data_fim)
        {
            try
            {
                string executar = "SELECT n.negociacao_id, n.cliente, c.nome as cliente_nome, n.painel, p.nome as painel_nome, isnull(n.data, '01/01/1900') as data, isnull(n.vencimento, '01/01/1900') as vencimento, n.subtotal, n.desconto, n.total, parcelas FROM negociacao AS n INNER JOIN cliente AS c ON n.cliente = c.codigo INNER JOIN painel as p ON n.painel = p.codigo WHERE n.negociacao_id > 0";

                if (cliente != "")
                {
                    if (cliente.IndexOf('#') > -1)
                    {
                        executar += " AND EXISTS (select g.codigo from cliente_grupo as g where g.codigo = c.grupo AND g.grupo = '" + cliente.Replace("#", "") + "')";
                    }
                    else
                    {
                        if (cliente.IndexOf('(') > -1)
                        {
                            string grupo = cliente.Substring(cliente.IndexOf(')') + 2);
                            string cliente_codigo = cliente.Substring(cliente.IndexOf('(') + 1, (cliente.IndexOf(')') - cliente.IndexOf('(')) - 1);
                            cliente = cliente.Substring(0, cliente.IndexOf("(") - 1);
                            executar += " AND n.cliente = '" + cliente_codigo + "' AND EXISTS (SELECT g.codigo FROM cliente_grupo as g WHERE g.codigo = c.grupo AND g.grupo = '" + grupo + "')";
                        }
                        else
                        {
                            executar += " AND c.codigo = " + cliente;
                        }
                    }
                }

                if (situacao != 5)
                {
                    //em andamento
                    if (situacao == 0)
                    {
                        executar += " AND EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento >= dateadd(d, -15, getdate())) AND NOT EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento < dateadd(d, -15, getdate()))";
                    }

                    //concluidas
                    if (situacao == 1)
                    {
                        executar += " AND NOT EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0)";
                    }

                    //canceladas
                    if (situacao == 2)
                    {
                        executar += " AND EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento < dateadd(d, -15, getdate()))";
                    }

                    //em atraso
                    if (situacao == 3)
                    {
                        executar += " AND EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento > dateadd(d, -15, getdate()) AND b.vencimento <= getdate()) AND NOT EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento < dateadd(d, -15, getdate()))";
                    }

                    //primeira fatura
                    if (situacao == 4)
                    {
                        executar += "AND EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.situacao = 0 AND b.vencimento >= getdate()) AND NOT EXISTS (SELECT b.codigo FROM negociacao_boleto_avulso as nb INNER JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo WHERE nb.negociacao_id = n.negociacao_id AND b.vencimento < getdate())";
                    }
                }

                DateTime dat_inicio = Convert.ToDateTime("01/01/1900");
                DateTime dat_fim = Convert.ToDateTime("01/01/1900");

                if (data_inicio.Length == 10 && data_fim.Length == 10)
                {
                    dat_inicio = Convert.ToDateTime(data_inicio);
                    dat_fim = Convert.ToDateTime(data_fim);
                    executar += " AND n.data between @dat_inicio AND @dat_fim";
                }

                executar += " ORDER BY n.data DESC";


                List<Negociacao> retorno = new List<Negociacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);

                if (dat_inicio > Convert.ToDateTime("01/01/1900"))
                {
                    quey.SetParameter("dat_inicio", dat_inicio)
                        .SetParameter("dat_fim", dat_fim);
                }

                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    Negociacao neg = new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]), nome = Convert.ToString(reader["cliente_nome"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]), nome = Convert.ToString(reader["painel_nome"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"]));
                    neg.Completar();
                    neg.PrepararJson();
                    retorno.Add(neg);
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

        public List<Negociacao> Listar(Cliente cliente)
        {
            try
            {
                List<Negociacao> retorno = new List<Negociacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, cliente, painel, isnull(data, '01/01/1900') as data, isnull(vencimento, '01/01/1900') as vencimento, subtotal, desconto, total, parcelas FROM negociacao WHERE cliente = @cliente ORDER BY data DESC");
                quey.SetParameter("cliente", cliente.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Negociacao(Convert.ToInt32(reader["negociacao_id"]), cliente, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"])));
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

        public List<Negociacao> Listar(Painel painel)
        {
            try
            {
                List<Negociacao> retorno = new List<Negociacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, cliente, painel, isnull(data, '01/01/1900') as data, isnull(vencimento, '01/01/1900') as vencimento, subtotal, desconto, total, parcelas FROM negociacao WHERE painel = @painel ORDER BY data DESC");
                quey.SetParameter("painel", painel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, painel, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"])));
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

    public class Negociacao_entradaDB
    {
        public void Salvar(Negociacao_entrada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Negociacao_entrada (negociacao_id, entrada) VALUES (@negociacao_id, @entrada) ");
                query.SetParameter("negociacao_id", variavel.negociacao_id.negociacao_id)
                    .SetParameter("entrada", variavel.entrada.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Negociacao_entrada variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Negociacao_entrada WHERE negociacao_id = @negociacao_id AND entrada = @entrada");
                query.SetParameter("negociacao_id", variavel.negociacao_id.negociacao_id)
                    .SetParameter("entrada", variavel.entrada.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Negociacao_entrada Buscar(int negociacao_id, int entrada)
        {
            try
            {
                Negociacao_entrada negociacao_entrada = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, entrada FROM negociacao_entrada WHERE negociacao_id = @codigo AND entrada = @entrada");
                quey.SetParameter("codigo", negociacao_id)
                    .SetParameter("entrada", entrada);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    negociacao_entrada = new Negociacao_entrada(new NegociacaoDB().Buscar(Convert.ToInt32(reader["negociacao_id"])), new EntradaDB().Buscar(Convert.ToInt32(reader["entrada"])));
                }
                reader.Close();
                session.Close();

                return negociacao_entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Negociacao_entrada> Listar(Negociacao negociacao_id)
        {
            try
            {
                List<Negociacao_entrada> negociacao_entrada = new List<Negociacao_entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ne.negociacao_id, 0) as negociacao_id, isnull(ne.entrada, 0) AS entrada, isnull(e.cliente, 0) AS cliente, isnull(e.painel, 0) as painel, isnull(e.data, '1900-01-01') as data, isnull(e.conta, 0) as conta, isnull(e.conta_devolucao, 0) AS conta_devolucao, isnull(e.valor, 0) as valor, isnull(e.vencimento, '1900-01-01') as vencimento, isnull(e.situacao, 0) as situacao, isnull(e.multa, 0) as multa, isnull(e.juros, 0) as juros, isnull(e.desconto, 0) as desconto, isnull(e.tipo_entrada, 0) as tipo_entrada, isnull(e.identificacao, '') as identificacao, isnull(e.data_quitado, '1900-01-01') as data_quitado, isnull(e.data_recebimento, '1900-01-01') as data_recebimento, isnull(e.data_devolucao, '1900-01-01') as data_devolucao, e.nota_fiscal, isnull(e.data_nota_fiscal, '1900-01-01') as data_nota_fiscal, isnull(e.tipo_pgto, 0) as tipo_pgto, isnull(e.boleto, '') as boleto, isnull(e.parcela, '') as parcela, isnull(e.xml_envio, '') as xml_envio, isnull(e.cod_verificacao, '') as cod_verificacao, isnull(e.xml_retorno, '') as xml_retorno, isnull(e.arquivo_xml, '') as arquivo_xml, isnull(e.obs_cancelado, '') as obs_cancelado, isnull(e.negociacao, 0) as negociacao, isnull(e.emolumento, 0) as emolumento, isnull(e.negativado, 0) as negativado, isnull(e.negativado_data, '1900-01-01') as negativado_data, isnull(e.negativado_data_removido, '1900-01-01') as negativado_data_removido FROM negociacao_entrada as ne JOIN entrada as e ON ne.entrada = e.codigo WHERE ne.negociacao_id = @codigo");
                quey.SetParameter("codigo", negociacao_id.negociacao_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    negociacao_entrada.Add(new Negociacao_entrada(negociacao_id, new Entrada(Convert.ToInt32(reader["entrada"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), new Conta() { codigo = Convert.ToInt32(reader["conta"]) }, new Conta() { codigo = Convert.ToInt32(reader["conta_devolucao"]) }, Convert.ToDouble(reader["valor"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToInt32(reader["situacao"]), Convert.ToDouble(reader["multa"]), Convert.ToDouble(reader["juros"]), Convert.ToDouble(reader["desconto"]), new Tipo_entradaDB().Buscar(Convert.ToInt32(reader["tipo_entrada"])), Convert.ToString(reader["identificacao"]), Convert.ToDateTime(reader["data_quitado"]), Convert.ToDateTime(reader["data_recebimento"]), Convert.ToDateTime(reader["data_devolucao"]), Convert.ToString(reader["nota_fiscal"]), Convert.ToDateTime(reader["data_nota_fiscal"]), Convert.ToString(reader["tipo_pgto"]), Convert.ToString(reader["boleto"]), Convert.ToString(reader["parcela"]), Convert.ToString(reader["xml_envio"]), Convert.ToString(reader["cod_verificacao"]), Convert.ToString(reader["xml_retorno"]), Convert.ToString(reader["arquivo_xml"]), Convert.ToString(reader["obs_cancelado"]), Convert.ToInt32(reader["negociacao"]), Convert.ToString(reader["emolumento"]), Convert.ToInt32(reader["negativado"]), Convert.ToDateTime(reader["negativado_data"]), Convert.ToDateTime(reader["negativado_data_removido"]))));
                }
                reader.Close();
                session.Close();

                return negociacao_entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Negociacao_entrada> Listar(Entrada entrada)
        {
            try
            {
                List<Negociacao_entrada> negociacao_entrada = new List<Negociacao_entrada>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT ne.negociacao_id, n.cliente, n.painel, isnull(n.data, '01/01/1900') as data, isnull(n.vencimento, '01/01/1900') as vencimento, n.subtotal, n.desconto, n.total, n.parcelas, ne.entrada FROM negociacao_entrada as ne JOIN negociacao as n ON ne.negociacao_id = n.negociacao_id WHERE ne.entrada = @codigo");
                quey.SetParameter("codigo", entrada.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    negociacao_entrada.Add(new Negociacao_entrada(new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"])), entrada));
                }
                reader.Close();
                session.Close();

                return negociacao_entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public class Negociacao_Boleto_avulsoDB
    {
        public void Salvar(Negociacao_Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Negociacao_Boleto_avulso (negociacao_id, boleto_avulso) VALUES (@negociacao_id, @boleto_avulso) ");
                query.SetParameter("negociacao_id", variavel.negociacao_id.negociacao_id)
                    .SetParameter("boleto_avulso", variavel.boleto_avulso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Negociacao_Boleto_avulso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Negociacao_Boleto_avulso WHERE negociacao_id = @negociacao_id AND boleto_avulso = @boleto_avulso");
                query.SetParameter("negociacao_id", variavel.negociacao_id.negociacao_id)
                    .SetParameter("boleto_avulso", variavel.boleto_avulso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Negociacao_Boleto_avulso Buscar(int negociacao_id, int boleto_avulso)
        {
            try
            {
                Negociacao_Boleto_avulso negociacao_boleto_avulso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT negociacao_id, Boleto_avulso FROM Negociacao_Boleto_avulso WHERE negociacao_id = @codigo AND Boleto_avulso = @Boleto_avulso");
                quey.SetParameter("codigo", negociacao_id)
                    .SetParameter("Boleto_avulso", boleto_avulso);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    negociacao_boleto_avulso = new Negociacao_Boleto_avulso(new NegociacaoDB().Buscar(Convert.ToInt32(reader["negociacao_id"])), new Boleto_avulsoDB().Buscar(Convert.ToInt32(reader["Boleto_avulso"])));
                }
                reader.Close();
                session.Close();

                return negociacao_boleto_avulso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Negociacao_Boleto_avulso> Listar(Negociacao negociacao_id)
        {
            try
            {
                List<Negociacao_Boleto_avulso> negociacao_entrada = new List<Negociacao_Boleto_avulso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT nb.negociacao_id, nb.boleto_avulso, b.aluno_pgto, b.cliente, isnull(b.data, '01/01/1900') as data, isnull(b.vencimento, '01/01/1900') as vencimento, isnull(b.data_pgto, '01/01/1900') as data_pgto, b.valor, b.situacao, b.obs, b.descricao, bo.codigo as boleto_codigo FROM Negociacao_Boleto_avulso as nb JOIN boleto_avulso as b ON nb.boleto_avulso = b.codigo JOIN boleto as bo ON b.codigo = bo.boleto_avulso WHERE nb.negociacao_id = @codigo ORDER BY vencimento");
                quey.SetParameter("codigo", negociacao_id.negociacao_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    negociacao_entrada.Add(new Negociacao_Boleto_avulso(negociacao_id, new Boleto_avulso(Convert.ToInt32(reader["boleto_avulso"]), new Aluno_pgto() { codigo = Convert.ToInt32(reader["aluno_pgto"]) }, new Cliente(){ codigo = Convert.ToInt32(reader["cliente"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToDateTime(reader["data_pgto"]), Convert.ToDouble(reader["valor"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["obs"]), Convert.ToString(reader["descricao"]), Convert.ToInt32(reader["boleto_codigo"]))));
                }
                reader.Close();
                session.Close();

                return negociacao_entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Negociacao_Boleto_avulso> Listar(Boleto_avulso boleto_avulso)
        {
            try
            {
                List<Negociacao_Boleto_avulso> negociacao_entrada = new List<Negociacao_Boleto_avulso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT nb.negociacao_id, n.cliente, n.painel, isnull(n.data, '01/01/1900') as data, isnull(n.vencimento, '01/01/1900') as vencimento, n.subtotal, n.desconto, n.total, n.parcelas, nb.boleto_avulso FROM Negociacao_Boleto_avulso as nb JOIN negociacao as n ON nb.negociacao_id = n.negociacao_id WHERE nb.Boleto_avulso = @codigo");
                quey.SetParameter("codigo", boleto_avulso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    negociacao_entrada.Add(new Negociacao_Boleto_avulso(new Negociacao(Convert.ToInt32(reader["negociacao_id"]), new Cliente() { codigo = Convert.ToInt32(reader["cliente"]) }, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToDouble(reader["subtotal"]), Convert.ToDouble(reader["desconto"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["parcelas"]), Convert.ToDateTime(reader["vencimento"])), boleto_avulso));
                }
                reader.Close();
                session.Close();

                return negociacao_entrada;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
