using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_cursoDB
    {

        public void Salvar(Aluno_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Aluno_curso (curso,aluno,data,situacao,data1,painel,obs,adesao,painel1,campo_documentacao,campo_status_relatorio,campo_status_certificado,campo_status_relatorio_data,campo_entrega_certificado,obs1,obs2,obs_documentos,cor,obs_financeiro,cor_financeiro,info,data_confirmacao,data_desistente,campo_financeiro,cor_certificado,cor_certificado1,envio_email,relatorio_certificadora,contato_pre_matricula,ligou_pre_reserva,ligou_matricula_aberta,ligou_apos_7dias,confirmou_pre_matricula,ligou_no_adiamento,ligou_turma_confirmada,visita_tecnica1,visita_tecnica2,email_pre_reserva,email_informativo,email_matriculas_abertas,email_matriculas_abertas_reforco,email_impressao_boleto,envio_pre_matricula,email_inicio_turma,email_adiamento_turma,obs_nota_frequencia,titulo_monografia,fase,nao_fara_o_curso) VALUES (@curso,@aluno,@data,@situacao,@data1,@painel,@obs,@adesao,@painel1,@campo_documentacao,@campo_status_relatorio,@campo_status_certificado,@campo_status_relatorio_data,@campo_entrega_certificado,@obs1,@obs2,@obs_documentos,@cor,@obs_financeiro,@cor_financeiro,@info,@data_confirmacao,@data_desistente,@campo_financeiro,@cor_certificado,@cor_certificado1,@envio_email,@relatorio_certificadora,@contato_pre_matricula,@ligou_pre_reserva,@ligou_matricula_aberta,@ligou_apos_7dias,@confirmou_pre_matricula,@ligou_no_adiamento,@ligou_turma_confirmada,@visita_tecnica1,@visita_tecnica2,@email_pre_reserva,@email_informativo,@email_matriculas_abertas,@email_matriculas_abertas_reforco,@email_impressao_boleto,@envio_pre_matricula,@email_inicio_turma,@email_adiamento_turma,@obs_nota_frequencia,@titulo_monografia,@fase,@nao_fara_o_curso) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("adesao", variavel.adesao)
                    .SetParameter("painel1", variavel.painel1.codigo)
                    .SetParameter("campo_documentacao", variavel.campo_documentacao)
                    .SetParameter("campo_status_relatorio", variavel.campo_status_relatorio)
                    .SetParameter("campo_status_certificado", variavel.campo_status_certificado)
                    .SetParameter("campo_status_relatorio_data", variavel.campo_status_relatorio_data)
                    .SetParameter("campo_entrega_certificado", variavel.campo_entrega_certificado)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("obs2", variavel.obs2)
                    .SetParameter("obs_documentos", variavel.obs_documentos)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("obs_financeiro", variavel.obs_financeiro)
                    .SetParameter("cor_financeiro", variavel.cor_financeiro)
                    .SetParameter("info", variavel.info)
                    .SetParameter("data_confirmacao", variavel.data_confirmacao)
                    .SetParameter("data_desistente", variavel.data_desistente)
                    .SetParameter("campo_financeiro", variavel.campo_financeiro)
                    .SetParameter("cor_certificado", variavel.cor_certificado)
                    .SetParameter("cor_certificado1", variavel.cor_certificado1)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("relatorio_certificadora", variavel.relatorio_certificadora)
                    .SetParameter("contato_pre_matricula", variavel.contato_pre_matricula)
                    .SetParameter("ligou_pre_reserva", variavel.ligou_pre_reserva)
                    .SetParameter("ligou_matricula_aberta", variavel.ligou_matricula_aberta)
                    .SetParameter("ligou_apos_7dias", variavel.ligou_apos_7dias)
                    .SetParameter("confirmou_pre_matricula", variavel.confirmou_pre_matricula)
                    .SetParameter("ligou_no_adiamento", variavel.ligou_no_adiamento)
                    .SetParameter("ligou_turma_confirmada", variavel.ligou_turma_confirmada)
                    .SetParameter("visita_tecnica1", variavel.visita_tecnica1)
                    .SetParameter("visita_tecnica2", variavel.visita_tecnica2)
                    .SetParameter("email_pre_reserva", variavel.email_pre_reserva)
                    .SetParameter("email_informativo", variavel.email_informativo)
                    .SetParameter("email_matriculas_abertas", variavel.email_matriculas_abertas)
                    .SetParameter("email_matriculas_abertas_reforco", variavel.email_matriculas_abertas_reforco)
                    .SetParameter("email_impressao_boleto", variavel.email_impressao_boleto)
                    .SetParameter("envio_pre_matricula", variavel.envio_pre_matricula)
                    .SetParameter("email_inicio_turma", variavel.email_inicio_turma)
                    .SetParameter("email_adiamento_turma", variavel.email_adiamento_turma)
                    .SetParameter("obs_nota_frequencia", variavel.obs_nota_frequencia)
                    .SetParameter("titulo_monografia", variavel.titulo_monografia)
                    .SetParameter("fase", variavel.fase)
                    .SetParameter("nao_fara_o_curso", variavel.nao_fara_o_curso);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_curso SET curso = @curso, aluno = @aluno, data = @data, situacao = @situacao, data1 = @data1, painel = @painel, obs = @obs, adesao = @adesao, painel1 = @painel1, campo_documentacao = @campo_documentacao, campo_status_relatorio = @campo_status_relatorio, campo_status_certificado = @campo_status_certificado, campo_status_relatorio_data = @campo_status_relatorio_data, campo_entrega_certificado = @campo_entrega_certificado, obs1 = @obs1, obs2 = @obs2, obs_documentos = @obs_documentos, cor = @cor, obs_financeiro = @obs_financeiro, cor_financeiro = @cor_financeiro, info = @info, data_confirmacao = @data_confirmacao, data_desistente = @data_desistente, campo_financeiro = @campo_financeiro, cor_certificado = @cor_certificado, cor_certificado1 = @cor_certificado1, envio_email = @envio_email, relatorio_certificadora = @relatorio_certificadora, contato_pre_matricula = @contato_pre_matricula, ligou_pre_reserva = @ligou_pre_reserva, ligou_matricula_aberta = @ligou_matricula_aberta, ligou_apos_7dias = @ligou_apos_7dias, confirmou_pre_matricula = @confirmou_pre_matricula, ligou_no_adiamento = @ligou_no_adiamento, ligou_turma_confirmada = @ligou_turma_confirmada, visita_tecnica1 = @visita_tecnica1, visita_tecnica2 = @visita_tecnica2, email_pre_reserva = @email_pre_reserva, email_informativo = @email_informativo, email_matriculas_abertas = @email_matriculas_abertas, email_matriculas_abertas_reforco = @email_matriculas_abertas_reforco, email_impressao_boleto = @email_impressao_boleto, envio_pre_matricula = @envio_pre_matricula, email_inicio_turma = @email_inicio_turma, email_adiamento_turma = @email_adiamento_turma, obs_nota_frequencia = @obs_nota_frequencia, titulo_monografia = @titulo_monografia, fase = @fase, nao_fara_o_curso = @nao_fara_o_curso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("situacao", variavel.situacao)
                    .SetParameter("data1", variavel.data1)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("adesao", variavel.adesao)
                    .SetParameter("painel1", variavel.painel1.codigo)
                    .SetParameter("campo_documentacao", variavel.campo_documentacao)
                    .SetParameter("campo_status_relatorio", variavel.campo_status_relatorio)
                    .SetParameter("campo_status_certificado", variavel.campo_status_certificado)
                    .SetParameter("campo_status_relatorio_data", variavel.campo_status_relatorio_data)
                    .SetParameter("campo_entrega_certificado", variavel.campo_entrega_certificado)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("obs2", variavel.obs2)
                    .SetParameter("obs_documentos", variavel.obs_documentos)
                    .SetParameter("cor", variavel.cor)
                    .SetParameter("obs_financeiro", variavel.obs_financeiro)
                    .SetParameter("cor_financeiro", variavel.cor_financeiro)
                    .SetParameter("info", variavel.info)
                    .SetParameter("data_confirmacao", variavel.data_confirmacao)
                    .SetParameter("data_desistente", variavel.data_desistente)
                    .SetParameter("campo_financeiro", variavel.campo_financeiro)
                    .SetParameter("cor_certificado", variavel.cor_certificado)
                    .SetParameter("cor_certificado1", variavel.cor_certificado1)
                    .SetParameter("envio_email", variavel.envio_email)
                    .SetParameter("relatorio_certificadora", variavel.relatorio_certificadora)
                    .SetParameter("contato_pre_matricula", variavel.contato_pre_matricula)
                    .SetParameter("ligou_pre_reserva", variavel.ligou_pre_reserva)
                    .SetParameter("ligou_matricula_aberta", variavel.ligou_matricula_aberta)
                    .SetParameter("ligou_apos_7dias", variavel.ligou_apos_7dias)
                    .SetParameter("confirmou_pre_matricula", variavel.confirmou_pre_matricula)
                    .SetParameter("ligou_no_adiamento", variavel.ligou_no_adiamento)
                    .SetParameter("ligou_turma_confirmada", variavel.ligou_turma_confirmada)
                    .SetParameter("visita_tecnica1", variavel.visita_tecnica1)
                    .SetParameter("visita_tecnica2", variavel.visita_tecnica2)
                    .SetParameter("email_pre_reserva", variavel.email_pre_reserva)
                    .SetParameter("email_informativo", variavel.email_informativo)
                    .SetParameter("email_matriculas_abertas", variavel.email_matriculas_abertas)
                    .SetParameter("email_matriculas_abertas_reforco", variavel.email_matriculas_abertas_reforco)
                    .SetParameter("email_impressao_boleto", variavel.email_impressao_boleto)
                    .SetParameter("envio_pre_matricula", variavel.envio_pre_matricula)
                    .SetParameter("email_inicio_turma", variavel.email_inicio_turma)
                    .SetParameter("email_adiamento_turma", variavel.email_adiamento_turma)
                    .SetParameter("obs_nota_frequencia", variavel.obs_nota_frequencia)
                    .SetParameter("titulo_monografia", variavel.titulo_monografia)
                    .SetParameter("fase", variavel.fase)
                    .SetParameter("nao_fara_o_curso", variavel.nao_fara_o_curso);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ImprimiuBoleto(int codigo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_curso SET email_impressao_boleto = @email_impressao_boleto WHERE codigo = @codigo");
                query.SetParameter("codigo", codigo)
                    .SetParameter("email_impressao_boleto", DateTime.Now);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarFase(int codigo, int fase)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_curso SET fase = @fase WHERE codigo = @codigo");
                query.SetParameter("codigo", codigo)
                    .SetParameter("fase", fase);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarInativo(int codigo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Aluno_curso SET nao_fara_o_curso = getdate() WHERE codigo = @codigo");
                query.SetParameter("codigo", codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Aluno_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Aluno_curso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int UltimoStatusCurso(int codigo)
        {
            try
            {
                int status = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select TOP 1 tipo from aluno_curso_log where aluno_curso = @codigo and tipo <> 6 order by data desc");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    status = Convert.ToInt32(reader["tipo"]);
                }
                reader.Close();
                session.Close();

                return status;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso Buscar(int codigo)
        {
            try
            {
                Aluno_curso aluno_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso = new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso Buscar(Cliente cliente)
        {
            try
            {
                Aluno_curso aluno_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ac.codigo, 0) AS codigo, isnull(ac.curso, 0) AS curso, isnull(ac.aluno, 0) AS aluno, isnull(ac.data, '1900-01-01') AS data, isnull(ac.situacao, 0) AS situacao, isnull(ac.data1, '1900-01-01') AS data1, isnull(ac.painel, 0) AS painel, isnull(ac.obs, '') AS obs, isnull(ac.adesao, '1900-01-01') AS adesao, isnull(ac.painel1, 0) AS painel1, isnull(ac.campo_documentacao, '') AS campo_documentacao, isnull(ac.campo_status_relatorio, '') AS campo_status_relatorio, isnull(ac.campo_status_certificado, '') AS campo_status_certificado, isnull(ac.campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(ac.campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(ac.obs1, '') AS obs1, isnull(ac.obs2, '') AS obs2, isnull(ac.obs_documentos, '') AS obs_documentos, isnull(ac.cor, 0) AS cor, isnull(ac.obs_financeiro, '') AS obs_financeiro, isnull(ac.cor_financeiro, 0) AS cor_financeiro, isnull(ac.info, 0) AS info, isnull(ac.data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(ac.data_desistente, '1900-01-01') AS data_desistente, isnull(ac.campo_financeiro, '') AS campo_financeiro, isnull(ac.cor_certificado, 0) AS cor_certificado, isnull(ac.cor_certificado1, 0) AS cor_certificado1, isnull(ac.envio_email, 0) AS envio_email, isnull(ac.relatorio_certificadora, 0) AS relatorio_certificadora, isnull(ac.contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ac.ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ac.ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ac.ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(ac.confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ac.ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ac.ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(ac.visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(ac.visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(ac.nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(ac.email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(ac.email_informativo, '1900-01-01') AS email_informativo, isnull(ac.email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(ac.email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(ac.email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(ac.envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(ac.email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(ac.email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(ac.obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(ac.titulo_monografia, '') AS titulo_monografia, isnull(ac.fase, 0) as fase FROM Aluno_curso as ac INNER JOIN aluno as a ON ac.aluno = a.codigo INNER JOIN curso as c ON ac.curso = c.codigo INNER JOIN cliente as cl ON replace(replace(replace(replace(a.cpf, '.', ''), '-', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cl.cpf_cnpj, '.', ''), '-', ''), '/', ''), ' ', '') INNER JOIN cliente_grupo as cg ON cl.grupo = cg.codigo WHERE cg.grupo = c.titulo1 AND cl.codigo = @id");
                quey.SetParameter("id", cliente.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso = new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso BuscarResumido(int codigo)
        {
            try
            {
                Aluno_curso aluno_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.aluno, ac.situacao, a.nome from aluno_curso ac left join aluno a on a.codigo = ac.aluno where ac.codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso = new Aluno_curso(Convert.ToInt32(reader["aluno"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["nome"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso Buscar(Curso curso, Aluno aluno)
        {
            try
            {
                Aluno_curso aluno_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE curso = @curso AND aluno = @aluno ORDER BY adesao DESC");
                quey.SetParameter("curso", curso.codigo).SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso = new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Aluno_curso Buscar(Curso curso, Aluno aluno, int situacao)
        {
            try
            {
                Aluno_curso aluno_curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE curso = @curso AND aluno = @aluno AND situacao = @situacao ORDER BY adesao DESC");
                quey.SetParameter("curso", curso.codigo).SetParameter("aluno", aluno.codigo).SetParameter("situacao", situacao);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    aluno_curso = new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"]));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Qtd(Curso curso)
        {
            try
            {
                int qtd = 0;
                DateTime datatemp = Convert.ToDateTime("01/01/1900");

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT ac.situacao, ac.email_impressao_boleto FROM aluno_curso ac WHERE ac.curso = @curso AND(ac.situacao = '2' OR ac.situacao = '1' OR(ac.situacao = '0' AND ac.email_impressao_boleto > @data)) and ac.aluno not in (38, 317, 8099, 2797, 13115, 12772)");
                //Query quey = session.CreateQuery("SELECT count(codigo) AS qtd FROM aluno_curso WHERE curso = @curso AND (situacao = '2' OR situacao = '1' OR (situacao = '0' AND adesao >= @data))");
                quey.SetParameter("curso", curso.codigo).SetParameter("data", DateTime.Now.AddDays(-10)); 
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read()) {

                    if (Convert.ToInt32(reader["situacao"]) == 0)
                    {

                        datatemp = Convert.ToDateTime(reader["email_impressao_boleto"]).AddDays(2);

                        // Verifica final de semana
                        if (datatemp.DayOfWeek.ToString() == "Saturday")
                        {
                            datatemp = datatemp.AddDays(2);
                        }
                        if (datatemp.DayOfWeek.ToString() == "Sunday")
                        {
                            datatemp = datatemp.AddDays(1);
                        }

                        // Verifica se é feriado
                        if (new FeriadosDB().Validar(datatemp.Day, datatemp.Month))
                        {
                            datatemp = datatemp.AddDays(1);
                        }

                        // Verifica novamente se é final de semana
                        if (datatemp.DayOfWeek.ToString() == "Saturday")
                        {
                            datatemp = datatemp.AddDays(2);
                        }
                        if (datatemp.DayOfWeek.ToString() == "Sunday")
                        {
                            datatemp = datatemp.AddDays(1);
                        }

                        // 1 dia para compensação
                        datatemp = datatemp.AddDays(1);

                        if (datatemp >= DateTime.Now)
                        {
                            qtd++;
                        }
                    }
                    else
                    {
                        qtd++;
                    }
                }

                reader.Close();
                session.Close();

                return qtd;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> Listar(Curso curso)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE curso = @curso");
                quey.SetParameter("curso", curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> Listar(Aluno aluno)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE aluno = @aluno");
                quey.SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> ListarCurso(Aluno aluno)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ac.codigo, 0) AS codigo, isnull(ac.curso, 0) AS curso, isnull(ac.aluno, 0) AS aluno, isnull(ac.data, '1900-01-01') AS data, isnull(ac.situacao, 0) AS situacao, isnull(ac.data1, '1900-01-01') AS data1, isnull(ac.painel, 0) AS painel, isnull(ac.obs, '') AS obs, isnull(ac.adesao, '1900-01-01') AS adesao, isnull(ac.painel1, 0) AS painel1, isnull(ac.campo_documentacao, '') AS campo_documentacao, isnull(ac.campo_status_relatorio, '') AS campo_status_relatorio, isnull(ac.campo_status_certificado, '') AS campo_status_certificado, isnull(ac.campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(ac.campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(ac.obs1, '') AS obs1, isnull(ac.obs2, '') AS obs2, isnull(ac.obs_documentos, '') AS obs_documentos, isnull(ac.cor, 0) AS cor, isnull(ac.obs_financeiro, '') AS obs_financeiro, isnull(ac.cor_financeiro, 0) AS cor_financeiro, isnull(ac.info, 0) AS info, isnull(ac.data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(ac.data_desistente, '1900-01-01') AS data_desistente, isnull(ac.campo_financeiro, '') AS campo_financeiro, isnull(ac.cor_certificado, 0) AS cor_certificado, isnull(ac.cor_certificado1, 0) AS cor_certificado1, isnull(ac.envio_email, 0) AS envio_email, isnull(ac.relatorio_certificadora, 0) AS relatorio_certificadora, isnull(ac.contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ac.ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ac.ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ac.ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(ac.confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ac.ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ac.ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(ac.visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(ac.visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(ac.nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(ac.email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(ac.email_informativo, '1900-01-01') AS email_informativo, isnull(ac.email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(ac.email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(ac.email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(ac.envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(ac.email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(ac.email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(ac.obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(ac.titulo_monografia, '') AS titulo_monografia, isnull(ac.fase, 0) as fase, isnull(c.titulo, 0) as titulo, isnull(c.tipo, 0) as tipo FROM Aluno_curso ac inner join curso c on c.codigo = ac.curso WHERE ac.aluno = @aluno order by c.tipo, c.titulo");
                quey.SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]), titulo = Convert.ToString(reader["titulo"]), titulo1 = Convert.ToString(reader["tipo"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<VendasAlunoCurso> ListarCursoVendas(int aluno)
        {
            try
            {
                List<VendasAlunoCurso> aluno_curso = new List<VendasAlunoCurso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT AC.curso, C.titulo, C.titulo1, AC.adesao, AC.codigo, L.data, L.texto, L.tipo, (SELECT count(ACA.idacao) FROM aluno_curso_acoes ACA WHERE ACA.aluno_curso = AC.codigo) as acoes FROM aluno_curso AC INNER JOIN curso C ON C.codigo = AC.curso CROSS APPLY (select top 1 ACL.data, ACL.tipo, ACL.texto from aluno_curso_log ACL WHERE ACL.aluno_curso = AC.codigo order by data desc) AS L WHERE AC.aluno = @aluno ORDER BY C.titulo1");
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new VendasAlunoCurso(Convert.ToInt32(reader["curso"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"]), Convert.ToDateTime(reader["adesao"]), Convert.ToInt32(reader["codigo"]), Convert.ToDateTime(reader["data"]), Convert.ToString(reader["texto"]), Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["acoes"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<VendasAlunoCurso> ListarCursoResumido(int aluno)
        {
            try
            {
                List<VendasAlunoCurso> aluno_curso = new List<VendasAlunoCurso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT AC.curso, C.titulo, C.titulo1 FROM aluno_curso AC INNER JOIN curso C ON C.codigo = AC.curso WHERE AC.aluno = @aluno ORDER BY C.titulo1");
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new VendasAlunoCurso(Convert.ToInt32(reader["curso"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public List<Aluno_curso> CursosAtivo(int aluno)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ac.codigo, 0) AS codigo, isnull(ac.curso, 0) AS curso, isnull(ac.aluno, 0) AS aluno, isnull(ac.data, '1900-01-01') AS data, isnull(ac.situacao, 0) AS situacao, c.codigo as curso_codigo, c.tipo as curso_tipo, c.titulo as curso_titulo, c.titulo1 as curso_titulo1, c.cidade_codigo as curso_cidade_codigo, c.titulo_curso as curso_titulo_curso, ci.cidade as cidade_cidade, ci.estado as cidade_estado FROM Aluno_curso as ac inner join curso as c ON ac.curso = c.codigo inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE ac.aluno = @aluno AND ac.situacao = 2 order by ci.cidade, c.titulo");
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        curso = new Curso()
                        {
                            codigo = Convert.ToInt32(reader["curso"]),
                            tipo = Convert.ToInt32(reader["curso_tipo"]),
                            titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["curso_titulo_curso"]) },
                            cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) },
                            titulo = Convert.ToString(reader["curso_titulo"]),
                            titulo1 = Convert.ToString(reader["curso_titulo1"])
                        },
                        aluno = new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        situacao = Convert.ToInt32(reader["situacao"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cursos> TituloCursos(TipoCurso tipo = 0, int top = 1000, int aluno = 0)
        {
            try
            {
                string executar = "select tbl.*, (select top 1 codigo from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as codigo, (select top 1 titulo1 from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as titulo1, (select top 1 link_trailer from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as link_trailer, (select top 1 texto from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as texto from (select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo and t.codigo not in (SELECT c.titulo_curso FROM Aluno_curso as ac inner join curso as c ON ac.curso = c.codigo WHERE ac.aluno = @aluno AND ac.situacao = 2 and c.tipo = 2) GROUP BY t.codigo, t.titulo, c.titulo, t.imagem, t.ordem, t.link ORDER BY t.ordem) as tbl ORDER BY tbl.ordem";
                List<Cursos> dados = new List<Cursos>(); 

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                .SetParameter("tipo", tipo)
                .SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Cursos(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["link_trailer"]), Convert.ToString(reader["texto"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cursos> CursosEaD(TipoCurso tipo = 0, int top = 1000, int aluno = 0)
        {
            try
            {
                string executar = "select tbl.*, (select top 1 codigo from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as codigo, (select top 1 titulo1 from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as titulo1, (select top 1 link_trailer from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as link_trailer, (select top 1 texto from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as texto from (select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem, g.txgrupo  FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo JOIN grupos_ead as ge ON ge.idcurso = c.codigo JOIN grupos as g ON g.idgrupo = ge.idgrupo where c.visualiza_site = 1 and c.tipo = @tipo and t.codigo not in (SELECT c.titulo_curso FROM Aluno_curso as ac inner join curso as c ON ac.curso = c.codigo WHERE ac.aluno = @aluno AND ac.situacao = 2 and c.tipo = 2) GROUP BY t.codigo, t.titulo, c.titulo, t.imagem, t.ordem, t.link, g.txgrupo ORDER BY g.txgrupo ,t.ordem) as tbl ORDER BY tbl.txgrupo";
                List<Cursos> dados = new List<Cursos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                .SetParameter("tipo", tipo)
                .SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Cursos(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["link_trailer"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["txgrupo"])));
                }
                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> CursosAtivoSel(int aluno, int curso)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ac.codigo, 0) AS codigo, isnull(ac.curso, 0) AS curso, isnull(ac.aluno, 0) AS aluno, isnull(ac.data, '1900-01-01') AS data, isnull(ac.situacao, 0) AS situacao, c.codigo as curso_codigo, c.tipo as curso_tipo, c.titulo as curso_titulo, c.titulo1 as curso_titulo1, c.cidade_codigo as curso_cidade_codigo, c.titulo_curso as curso_titulo_curso, ci.cidade as cidade_cidade, ci.estado as cidade_estado, (case ac.curso when @curso then 0 else 1 end) as ord FROM Aluno_curso as ac inner join curso as c ON ac.curso = c.codigo inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE ac.aluno = @aluno AND ac.situacao = 2 order by ord, ci.cidade, c.titulo");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        curso = new Curso()
                        {
                            codigo = Convert.ToInt32(reader["curso"]),
                            tipo = Convert.ToInt32(reader["curso_tipo"]),
                            titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["curso_titulo_curso"]) },
                            cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) },
                            titulo = Convert.ToString(reader["curso_titulo"]),
                            titulo1 = Convert.ToString(reader["curso_titulo1"])
                        },
                        aluno = new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        situacao = Convert.ToInt32(reader["situacao"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> CursosAtivo(int aluno, int tipo)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(ac.codigo, 0) AS codigo, isnull(ac.curso, 0) AS curso, isnull(ac.aluno, 0) AS aluno, isnull(ac.data, '1900-01-01') AS data, isnull(ac.situacao, 0) AS situacao, c.codigo as curso_codigo, c.tipo as curso_tipo, c.titulo as curso_titulo, c.titulo1 as curso_titulo1, c.cidade_codigo as curso_cidade_codigo, c.titulo_curso as curso_titulo_curso, ci.cidade as cidade_cidade, ci.estado as cidade_estado FROM Aluno_curso as ac inner join curso as c ON ac.curso = c.codigo inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE ac.aluno = @aluno AND ac.situacao = 2 and c.tipo = @tipo order by c.titulo");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        curso = new Curso()
                        {
                            codigo = Convert.ToInt32(reader["curso"]),
                            tipo = Convert.ToInt32(reader["curso_tipo"]),
                            titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["curso_titulo_curso"]) },
                            cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) },
                            titulo = Convert.ToString(reader["curso_titulo"]),
                            titulo1 = Convert.ToString(reader["curso_titulo1"])
                        },
                        aluno = new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        situacao = Convert.ToInt32(reader["situacao"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> CursosAtivo(Aluno aluno)

        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE aluno = @aluno AND situacao = 2");
                quey.SetParameter("aluno", aluno.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Matriculado(Aluno aluno)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo FROM Aluno_curso WHERE aluno = @aluno AND situacao = 2");
                quey.SetParameter("aluno", aluno.codigo);
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

        public bool MatriculadoCurso(int aluno = 0, int curso = 0)
        {
            try
            {
                bool retorno = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo FROM Aluno_curso WHERE aluno = @aluno and curso = @curso AND situacao = 2");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
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

        public List<int> Aluno_Curso_Acompanhamento(int curso = 0, int aluno = 0)
        {
            try
            {
                List<int> list = new List<int>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT curso FROM aluno_curso_acompanhamento where aluno = @aluno and cursoref = @curso");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    list.Add(Convert.ToInt32(reader["curso"]));
                }
                reader.Close();
                session.Close();

                return list;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso_acompanhamento> Lista_Curso_Acompanhamento(int curso = 0, int aluno = 0)
        {
            try
            {
                List<Aluno_curso_acompanhamento> list = new List<Aluno_curso_acompanhamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"SELECT aluno_curso_acompanhamento.codigo AS codigo, curso.titulo AS titulo, curso.codigo AS curso 
                FROM aluno_curso_acompanhamento, curso
                WHERE aluno_curso_acompanhamento.aluno = @aluno and aluno_curso_acompanhamento.cursoref = @curso AND aluno_curso_acompanhamento.curso = curso.codigo");
                quey.SetParameter("aluno", aluno);
                quey.SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    list.Add(new Aluno_curso_acompanhamento(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToInt32(reader["curso"])));
                }
                reader.Close();
                session.Close();

                return list;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso> Listar(Curso curso, Aluno aluno)
        {
            try
            {
                List<Aluno_curso> aluno_curso = new List<Aluno_curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(codigo, 0) AS codigo, isnull(curso, 0) AS curso, isnull(aluno, 0) AS aluno, isnull(data, '1900-01-01') AS data, isnull(situacao, 0) AS situacao, isnull(data1, '1900-01-01') AS data1, isnull(painel, 0) AS painel, isnull(obs, '') AS obs, isnull(adesao, '1900-01-01') AS adesao, isnull(painel1, 0) AS painel1, isnull(campo_documentacao, '') AS campo_documentacao, isnull(campo_status_relatorio, '') AS campo_status_relatorio, isnull(campo_status_certificado, '') AS campo_status_certificado, isnull(campo_status_relatorio_data, '1900-01-01') AS campo_status_relatorio_data, isnull(campo_entrega_certificado, '') AS campo_entrega_certificado, isnull(obs1, '') AS obs1, isnull(obs2, '') AS obs2, isnull(obs_documentos, '') AS obs_documentos, isnull(cor, 0) AS cor, isnull(obs_financeiro, '') AS obs_financeiro, isnull(cor_financeiro, 0) AS cor_financeiro, isnull(info, 0) AS info, isnull(data_confirmacao, '1900-01-01') AS data_confirmacao, isnull(data_desistente, '1900-01-01') AS data_desistente, isnull(campo_financeiro, '') AS campo_financeiro, isnull(cor_certificado, 0) AS cor_certificado, isnull(cor_certificado1, 0) AS cor_certificado1, isnull(envio_email, 0) AS envio_email, isnull(relatorio_certificadora, 0) AS relatorio_certificadora, isnull(contato_pre_matricula, 0) AS contato_pre_matricula, isnull(ligou_pre_reserva, '1900-01-01') AS ligou_pre_reserva, isnull(ligou_matricula_aberta, '1900-01-01') AS ligou_matricula_aberta, isnull(ligou_apos_7dias, '1900-01-01') AS ligou_apos_7dias, isnull(confirmou_pre_matricula, '1900-01-01') AS confirmou_pre_matricula, isnull(ligou_no_adiamento, '1900-01-01') AS ligou_no_adiamento, isnull(ligou_turma_confirmada, '1900-01-01') AS ligou_turma_confirmada, isnull(visita_tecnica1, '1900-01-01') AS visita_tecnica1, isnull(visita_tecnica2, '1900-01-01') AS visita_tecnica2, isnull(nao_fara_o_curso, '1900-01-01') AS nao_fara_o_curso, isnull(email_pre_reserva, '1900-01-01') AS email_pre_reserva, isnull(email_informativo, '1900-01-01') AS email_informativo, isnull(email_matriculas_abertas, '1900-01-01') AS email_matriculas_abertas, isnull(email_matriculas_abertas_reforco, '1900-01-01') AS email_matriculas_abertas_reforco, isnull(email_impressao_boleto, '1900-01-01') AS email_impressao_boleto, isnull(envio_pre_matricula, '1900-01-01') AS envio_pre_matricula, isnull(email_inicio_turma, '1900-01-01') AS email_inicio_turma, isnull(email_adiamento_turma, '1900-01-01') AS email_adiamento_turma, isnull(obs_nota_frequencia, '') AS obs_nota_frequencia, isnull(titulo_monografia, '') AS titulo_monografia, isnull(fase, 0) as fase FROM Aluno_curso WHERE aluno = @aluno AND curso = @curso");
                quey.SetParameter("aluno", aluno.codigo).SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToDateTime(reader["data1"]), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToString(reader["obs"]), Convert.ToDateTime(reader["adesao"]), new Painel() { codigo = Convert.ToInt32(reader["painel1"]) }, Convert.ToString(reader["campo_documentacao"]), Convert.ToString(reader["campo_status_relatorio"]), Convert.ToString(reader["campo_status_certificado"]), Convert.ToDateTime(reader["campo_status_relatorio_data"]), Convert.ToString(reader["campo_entrega_certificado"]), Convert.ToString(reader["obs1"]), Convert.ToString(reader["obs2"]), Convert.ToString(reader["obs_documentos"]), Convert.ToInt32(reader["cor"]), Convert.ToString(reader["obs_financeiro"]), Convert.ToInt32(reader["cor_financeiro"]), Convert.ToInt32(reader["info"]), Convert.ToDateTime(reader["data_confirmacao"]), Convert.ToDateTime(reader["data_desistente"]), Convert.ToString(reader["campo_financeiro"]), Convert.ToInt32(reader["cor_certificado"]), Convert.ToInt32(reader["cor_certificado1"]), Convert.ToInt32(reader["envio_email"]), Convert.ToInt32(reader["relatorio_certificadora"]), Convert.ToInt32(reader["contato_pre_matricula"]), Convert.ToDateTime(reader["ligou_pre_reserva"]), Convert.ToDateTime(reader["ligou_matricula_aberta"]), Convert.ToDateTime(reader["ligou_apos_7dias"]), Convert.ToDateTime(reader["confirmou_pre_matricula"]), Convert.ToDateTime(reader["ligou_no_adiamento"]), Convert.ToDateTime(reader["ligou_turma_confirmada"]), Convert.ToDateTime(reader["visita_tecnica1"]), Convert.ToDateTime(reader["visita_tecnica2"]), Convert.ToDateTime(reader["email_pre_reserva"]), Convert.ToDateTime(reader["email_informativo"]), Convert.ToDateTime(reader["email_matriculas_abertas"]), Convert.ToDateTime(reader["email_matriculas_abertas_reforco"]), Convert.ToDateTime(reader["email_impressao_boleto"]), Convert.ToDateTime(reader["envio_pre_matricula"]), Convert.ToDateTime(reader["email_inicio_turma"]), Convert.ToDateTime(reader["email_adiamento_turma"]), Convert.ToString(reader["obs_nota_frequencia"]), Convert.ToString(reader["titulo_monografia"]), Convert.ToInt32(reader["fase"]), Convert.ToDateTime(reader["nao_fara_o_curso"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_curso_fase> ListarClassificarFase()
        {
            try
            {
                List<Aluno_curso_fase> aluno_curso = new List<Aluno_curso_fase>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select ac.codigo, isnull(ac.situacao, 0) as situacao, isnull(ac.adesao, '1900-01-01') as adesao, isnull(ac.fase, 0) as fase, isnull(c.data_inicio, '1900-01-01') as data_inicio, isnull(c.inicio_confirmado_data, '1900-01-01') as inicio_confirmado_data, isnull(c.inicio_confirmado, 0) as inicio_confirmado, isnull(c.data_abertura_pre_reserva, '1900-01-01') as data_abertura_pre_reserva, isnull(c.ativo_data_abertura_matricula, '1900-01-01') as ativo_data_abertura_matricula, isnull((select top 1 ca.data from curso_adiamento as ca WHERE ca.curso = c.codigo ORDER BY ca.data), '1900-01-01') as data_prorrogacao from aluno_curso as ac JOIN curso as c ON ac.curso = c.codigo WHERE ac.fase = 0 and c.data_inicio >= dateadd(m, -18, getdate())");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_curso_fase() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        fase = Convert.ToInt32(reader["fase"]),
                        situacao = Convert.ToInt32(reader["situacao"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        adesao = Convert.ToDateTime(reader["adesao"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        data_prorrogacao = Convert.ToDateTime(reader["data_prorrogacao"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Aluno_desistente> AlunoDesistente(int curso = 0, string inicio = "", string fim = "")
        {
            try
            {
                List<Aluno_desistente> aluno_curso = new List<Aluno_desistente>();

                DateTime data_inicio = Convert.ToDateTime("01/01/1900");
                DateTime data_fim = Convert.ToDateTime("01/01/1900");

                string executar = "select c.codigo as curso, c.titulo, a.codigo as aluno, a.nome, a.cpf, ac.situacao, isnull(ac.data_desistente, '01/01/1900') as data_desistente, ac.obs, ac.obs_financeiro from aluno_curso as ac inner join aluno as a ON ac.aluno = a.codigo inner join curso as c ON ac.curso = c.codigo where ac.situacao = 3";

                if(curso != 0){
                    executar += " and c.codigo = " + curso;
                }
                if(inicio != "" && fim != "")
                {
                    data_inicio = Convert.ToDateTime(inicio);
                    data_fim = Convert.ToDateTime(fim);
                    executar += " and ac.data_desistente between @inicio and @fim";
                }

                executar += " ORDER BY a.nome";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                if (data_inicio != Convert.ToDateTime("01/01/1900") && data_fim != Convert.ToDateTime("01/01/1900"))
                    quey.SetParameter("inicio", data_inicio).SetParameter("fim", data_fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new Aluno_desistente() {
                        curso = Convert.ToInt32(reader["curso"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        aluno = Convert.ToInt32(reader["aluno"]),
                        nome = Convert.ToString(reader["nome"]),
                        cpf = Convert.ToString(reader["cpf"]),
                        data_desistente = Convert.ToDateTime(reader["data_desistente"]),
                        obs = Convert.ToString(reader["obs"]),
                        obs_financeiro = Convert.ToString(reader["obs_financeiro"])
                    });
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<AlunoVendaRD> VendaRD()
        {
            try
            {
                List<AlunoVendaRD> aluno_curso = new List<AlunoVendaRD>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select a.nome, a.email, c.titulo1 as curso, tc.link as titulo_curso, ci.link as cidade from aluno_curso as ac inner join aluno as a on ac.aluno = a.codigo inner join curso as c on ac.curso = c.codigo inner join titulo_curso as tc on c.titulo_curso = tc.codigo inner join cidade as ci on c.cidade_codigo = ci.codigo where ac.situacao = 2 and ac.data_confirmacao = cast(dateadd(day, -1, getdate()) as date)");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno_curso.Add(new AlunoVendaRD(Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["curso"]), Convert.ToString(reader["titulo_curso"]), Convert.ToString(reader["cidade"])));
                }
                reader.Close();
                session.Close();

                return aluno_curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PendenciasNotificacao> PendenciasNotificacao(int aluno, int curso)
        {
            try
            {
                List<PendenciasNotificacao> retorno = new List<PendenciasNotificacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from (select 'pendencias' as tipo, d.codigo, concat('Documento pendente ', d.documentos) as texto from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join documentos as d on c.codigo = d.curso where a.codigo = @aluno and c.codigo = @curso and not exists (select * from documentos_alunos as da where da.aluno = a.codigo and da.documentos = d.codigo)) as t union (select concat('encontros/#', ace.disciplina) as tipo, ace.disciplina, concat('Disciplina pendente ', d.titulo, ' - Nota: ', ace.nota, ' - Frequencia: ', ace.frequencia) from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join aluno_curso_encontro as ace on c.codigo = ace.curso and a.codigo = ace.aluno inner join disciplina as d on d.codigo = ace.disciplina where a.codigo = @aluno and c.codigo = @curso and (ace.nota < 7 OR ace.frequencia < 75)) union (select 'boletos' as tipo, e.codigo, concat('Fatura em aberto, vencimento ', day(e.vencimento), '/', month(e.vencimento), '/', year(e.vencimento), '  valor ', replace(replace(CONVERT(decimal(10, 2), e.valor), ',', ''), '.', ',')) from aluno as a inner join aluno_curso as ac on a.codigo = ac.aluno inner join curso as c on c.codigo = ac.curso inner join cliente as cl on replace(replace(replace(replace(a.cpf, '.', ''), '-', ''), '/', ''), ' ', '') = replace(replace(replace(replace(cl.cpf_cnpj, '.', ''), '-', ''), '/', ''), ' ', '') inner join entrada as e on cl.codigo = e.cliente inner join cliente_grupo as cg on cl.grupo = cg.codigo inner join boleto as b on e.codigo = b.entrada where a.codigo = @aluno and c.codigo = @curso and c.titulo1 = cg.grupo and c.titulo1 = cg.grupo and e.vencimento < dateadd(day, -5, getdate()) and e.situacao < 2 and ac.situacao = 2)");
                quey.SetParameter("aluno", aluno)
                    .SetParameter("curso", curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new PendenciasNotificacao(Convert.ToString(reader["tipo"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["texto"])));
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

        public List<Aluno> ListarAlunosEad(int codigo)
        {
            try
            {
                List<Aluno> aluno = new List<Aluno>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select a.nome, a.email from aluno_curso ac left join aluno a on a.codigo = ac.aluno where ac.curso = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    aluno.Add(new Aluno()
                    {
                        nome = Convert.ToString(reader["nome"]),
                        email = Convert.ToString(reader["email"])
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
    }
}
