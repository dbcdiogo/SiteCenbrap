using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_pgtoDB
    {
        public void Salvar(Aluno_pgto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_pgto (aluno,curso,aluno_curso,boleto_avulso,data,vencimento,total,total_parcelas,desconto_pgto_dia,forma_pgto,parcela,valor_parcela,situacao,painel,painel_pgto,data_pgto,obs,vinculado,total_vinculado,data_gerado,txt,matricula,boleto) VALUES (@aluno,@curso,@aluno_curso,@boleto_avulso,@data,@vencimento,@total,@total_parcelas,@desconto_pgto_dia,@forma_pgto,@parcela,@valor_parcela,@situacao,@painel,@painel_pgto,@data_pgto,@obs,@vinculado,@total_vinculado,@data_gerado,@txt,@matricula,@boleto) ");
                query.SetParameter("aluno", variavel.aluno.codigo)
                        .SetParameter("curso", variavel.curso.codigo)
                        .SetParameter("aluno_curso", variavel.aluno_curso.codigo)
                        .SetParameter("boleto_avulso", variavel.boleto_avulso)
                        .SetParameter("data", variavel.data)
                        .SetParameter("vencimento", variavel.vencimento)
                        .SetParameter("total", variavel.total)
                        .SetParameter("total_parcelas", variavel.total_parcelas)
                        .SetParameter("desconto_pgto_dia", variavel.desconto_pgto_dia)
                        .SetParameter("forma_pgto", variavel.forma_pgto)
                        .SetParameter("parcela", variavel.parcela)
                        .SetParameter("valor_parcela", variavel.valor_parcela)
                        .SetParameter("situacao", variavel.situacao)
                        .SetParameter("painel", variavel.painel)
                        .SetParameter("painel_pgto", variavel.painel_pgto)
                        .SetParameter("data_pgto", variavel.data_pgto)
                        .SetParameter("obs", variavel.obs)
                        .SetParameter("vinculado", variavel.vinculado)
                        .SetParameter("total_vinculado", variavel.total_vinculado)
                        .SetParameter("data_gerado", variavel.data_gerado)
                        .SetParameter("txt", variavel.txt)
                        .SetParameter("matricula", variavel.matricula)
                        .SetParameter("boleto", variavel.boleto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno_pgto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_pgto SET aluno = @aluno, curso = @curso, aluno_curso = @aluno_curso, boleto_avulso = @boleto_avulso, data = @data, vencimento = @vencimento, total = @total, total_parcelas = @total_parcelas, desconto_pgto_dia = @desconto_pgto_dia, forma_pgto = @forma_pgto, parcela = @parcela, valor_parcela = @valor_parcela, situacao = @situacao, painel = @painel, painel_pgto = @painel_pgto, data_pgto = @data_pgto, obs = @obs, vinculado = @vinculado, total_vinculado = @total_vinculado, data_gerado = @data_gerado, txt = @txt, matricula = @matricula, boleto = @boleto WHERE codigo = @codigo");
                query.SetParameter("aluno", variavel.aluno.codigo)
                        .SetParameter("codigo", variavel.codigo)
                        .SetParameter("curso", variavel.curso.codigo)
                        .SetParameter("aluno_curso", variavel.aluno_curso.codigo)
                        .SetParameter("boleto_avulso", variavel.boleto_avulso)
                        .SetParameter("data", variavel.data)
                        .SetParameter("vencimento", variavel.vencimento)
                        .SetParameter("total", variavel.total)
                        .SetParameter("total_parcelas", variavel.total_parcelas)
                        .SetParameter("desconto_pgto_dia", variavel.desconto_pgto_dia)
                        .SetParameter("forma_pgto", variavel.forma_pgto)
                        .SetParameter("parcela", variavel.parcela)
                        .SetParameter("valor_parcela", variavel.valor_parcela)
                        .SetParameter("situacao", variavel.situacao)
                        .SetParameter("painel", variavel.painel)
                        .SetParameter("painel_pgto", variavel.painel_pgto)
                        .SetParameter("data_pgto", variavel.data_pgto)
                        .SetParameter("obs", variavel.obs)
                        .SetParameter("vinculado", variavel.vinculado)
                        .SetParameter("total_vinculado", variavel.total_vinculado)
                        .SetParameter("data_gerado", variavel.data_gerado)
                        .SetParameter("txt", variavel.txt)
                        .SetParameter("matricula", variavel.matricula)
                        .SetParameter("boleto", variavel.boleto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Aluno_pgto variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Aluno_pgto WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Aluno_pgto Buscar(int codigo)
        {
            try
            {
                Aluno_pgto aluno_pgto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(aluno, 0) AS aluno, isnull(curso, 0) AS curso, isnull(aluno_curso, 0) AS aluno_curso, isnull(boleto_avulso, 0) AS boleto_avulso, isnull(data, '1900-01-01') AS data, isnull(vencimento, '1900-01-01') AS vencimento, isnull(total, 0) AS total, isnull(total_parcelas, 0) AS total_parcelas, isnull(desconto_pgto_dia, 0) AS desconto_pgto_dia, isnull(forma_pgto, 0) AS forma_pgto, isnull(parcela, 0) AS parcela, isnull(valor_parcela, 0) AS valor_parcela, isnull(situacao, 0) AS situacao, isnull(painel, 0) AS painel, isnull(painel_pgto, 0) AS painel_pgto, isnull(data_pgto, '1900-01-01') AS data_pgto, isnull(obs, '') AS obs, isnull(vinculado, 0) AS vinculado, isnull(total_vinculado, 0) AS total_vinculado, isnull(data_gerado, '1900-01-01') AS data_gerado, isnull(txt, '') AS txt, isnull(matricula, 0) AS matricula, isnull(boleto, 0) AS boleto FROM Aluno_pgto WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_pgto = new Aluno_pgto(Convert.ToInt32(reader["codigo"]), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["boleto_avulso"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["total_parcelas"]), Convert.ToDouble(reader["desconto_pgto_dia"]), Convert.ToInt32(reader["forma_pgto"]), Convert.ToInt32(reader["parcela"]), Convert.ToDouble(reader["valor_parcela"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["painel"]), Convert.ToInt32(reader["painel_pgto"]), Convert.ToDateTime(reader["data_pgto"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["vinculado"]), Convert.ToDouble(reader["total_vinculado"]), Convert.ToDateTime(reader["data_gerado"]), Convert.ToString(reader["txt"]), Convert.ToDouble(reader["matricula"]), Convert.ToInt32(reader["boleto"]));
                }
                reader.Close();
                session.Close();

                return aluno_pgto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_pgto Buscar(Aluno_curso aluno_curso)
        {
            try
            {
                Aluno_pgto aluno_pgto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(aluno, 0) AS aluno, isnull(curso, 0) AS curso, isnull(aluno_curso, 0) AS aluno_curso, isnull(boleto_avulso, 0) AS boleto_avulso, isnull(data, '1900-01-01') AS data, isnull(vencimento, '1900-01-01') AS vencimento, isnull(total, 0) AS total, isnull(total_parcelas, 0) AS total_parcelas, isnull(desconto_pgto_dia, 0) AS desconto_pgto_dia, isnull(forma_pgto, 0) AS forma_pgto, isnull(parcela, 0) AS parcela, isnull(valor_parcela, 0) AS valor_parcela, isnull(situacao, 0) AS situacao, isnull(painel, 0) AS painel, isnull(painel_pgto, 0) AS painel_pgto, isnull(data_pgto, '1900-01-01') AS data_pgto, isnull(obs, '') AS obs, isnull(vinculado, 0) AS vinculado, isnull(total_vinculado, 0) AS total_vinculado, isnull(data_gerado, '1900-01-01') AS data_gerado, isnull(txt, '') AS txt, isnull(matricula, 0) AS matricula, isnull(boleto, 0) AS boleto FROM Aluno_pgto WHERE aluno_curso = @codigo");
                quey.SetParameter("codigo", aluno_curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_pgto = new Aluno_pgto(Convert.ToInt32(reader["codigo"]), new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno_curso() { codigo = Convert.ToInt32(reader["aluno_curso"]) }, Convert.ToInt32(reader["boleto_avulso"]), Convert.ToDateTime(reader["data"]), Convert.ToDateTime(reader["vencimento"]), Convert.ToDouble(reader["total"]), Convert.ToInt32(reader["total_parcelas"]), Convert.ToDouble(reader["desconto_pgto_dia"]), Convert.ToInt32(reader["forma_pgto"]), Convert.ToInt32(reader["parcela"]), Convert.ToDouble(reader["valor_parcela"]), Convert.ToInt32(reader["situacao"]), Convert.ToInt32(reader["painel"]), Convert.ToInt32(reader["painel_pgto"]), Convert.ToDateTime(reader["data_pgto"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["vinculado"]), Convert.ToDouble(reader["total_vinculado"]), Convert.ToDateTime(reader["data_gerado"]), Convert.ToString(reader["txt"]), Convert.ToDouble(reader["matricula"]), Convert.ToInt32(reader["boleto"]));
                }
                reader.Close();
                session.Close();

                return aluno_pgto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int BuscarCodigo(int aluno, int curso, int codigo)
        {
            try
            {
                int r = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT TOP 1 codigo FROM aluno_pgto WHERE situacao = 1 AND aluno = @aluno AND curso = @curso AND aluno_curso = @codigo ORDER BY codigo DESC");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    r = Convert.ToInt32(reader["codigo"]);
                }
                reader.Close();
                session.Close();

                return r;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
