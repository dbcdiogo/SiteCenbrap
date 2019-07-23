using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB

{
    public class CursoDB
    {
        public void Salvar(Curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Curso (data, painel, cidade_codigo, titulo_curso, painel_contrato, data_contrato, titulo, titulo1, texto, textoData, valor, valor_avista, matricula, matricula1, desconto_pgto_dia, data_criacao, data_limite1, data_limite2, data_inicio, data_2parcela, inicio_confirmado_data, ativo_data_abertura_matricula, data_abertura_pre_reserva, qtd_parcelas, total_alunos, tipo, qtd_modulos,  pgto_1parcela, ultimas_vagas, inicio_confirmado, visualiza_site, ativar_monografia, ativo, vagas_esgotadas, qtd_reposicao, representante, grupo_datas, carga_horaria, obs1, obs, cidade, contrato, contrato1, contrato2, orientador, email_orientador, arquivo_2passo, data_fim, xerox, dossie, endereco_local, arquivo_mapa, obs_local, pag_site_professores, pag_site_disciplina, contrato_tcc, certificadora, certificadora_id, cartao, imprimir_certificado, link_trailer, idhotel, dtaberturainicial, contratoc, pagseguro_recorrente) VALUES (@data, @painel, @cidade_codigo, @titulo_curso, @painel_contrato, @data_contrato, @titulo, @titulo1, @texto, @textoData, @valor, @valor_avista, @matricula, @matricula1, @desconto_pgto_dia, @data_criacao, @data_limite1, @data_limite2, @data_inicio, @data_2parcela, @inicio_confirmado_data, @ativo_data_abertura_matricula, @data_abertura_pre_reserva, @qtd_parcelas, @total_alunos, @tipo, @qtd_modulos, @pgto_1parcela, @ultimas_vagas, @inicio_confirmado, @visualiza_site, @ativar_monografia, @ativo, @vagas_esgotadas, @qtd_reposicao, @representante, @grupo_datas, @carga_horaria, @obs1, @obs, @cidade, @contrato, @contrato1, @contrato2, @orientador, @email_orientador, @arquivo_2passo, @data_fim, @xerox, @dossie, @endereco_local, @arquivo_mapa, @obs_local, @pag_site_professores, @pag_site_disciplina, @contrato_tcc, @certificadora, @certificadora_id, @cartao, @imprimir_certificado, @link_trailer, @idhotel, @dtaberturainicial, @contratoc, @pagseguro_recorrente) ");
                query.SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("cidade_codigo", variavel.cidade_codigo.codigo)
                    .SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("painel_contrato", variavel.painel_contrato.codigo)
                    .SetParameter("data_contrato", variavel.data_contrato)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo1", variavel.titulo1)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("textoData", variavel.textoData)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("valor_avista", variavel.valor_avista)
                    .SetParameter("matricula", variavel.matricula)
                    .SetParameter("matricula1", variavel.matricula1)
                    .SetParameter("desconto_pgto_dia", variavel.desconto_pgto_dia)
                    .SetParameter("data_criacao", variavel.data_criacao)
                    .SetParameter("data_limite1", variavel.data_limite1)
                    .SetParameter("data_limite2", variavel.data_limite2)
                    .SetParameter("data_inicio", variavel.data_inicio)
                    .SetParameter("data_2parcela", variavel.data_2parcela)
                    .SetParameter("inicio_confirmado_data", variavel.inicio_confirmado_data)
                    .SetParameter("ativo_data_abertura_matricula", variavel.ativo_data_abertura_matricula)
                    .SetParameter("data_abertura_pre_reserva", variavel.data_abertura_pre_reserva)
                    .SetParameter("qtd_parcelas", variavel.qtd_parcelas)
                    .SetParameter("total_alunos", variavel.total_alunos)
                    .SetParameter("tipo", variavel.tipo)
                    .SetParameter("qtd_modulos", variavel.qtd_modulos)
                    .SetParameter("pgto_1parcela", variavel.pgto_1parcela)
                    .SetParameter("ultimas_vagas", variavel.ultimas_vagas)
                    .SetParameter("inicio_confirmado", variavel.inicio_confirmado)
                    .SetParameter("visualiza_site", variavel.visualiza_site)
                    .SetParameter("ativar_monografia", variavel.ativar_monografia)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("vagas_esgotadas", variavel.vagas_esgotadas)
                    .SetParameter("qtd_reposicao", variavel.qtd_reposicao)
                    .SetParameter("representante", variavel.representante)
                    .SetParameter("grupo_datas", variavel.grupo_datas)
                    .SetParameter("carga_horaria", variavel.carga_horaria)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("contrato", variavel.contrato)
                    .SetParameter("contrato1", variavel.contrato1)
                    .SetParameter("contrato2", variavel.contrato2)
                    .SetParameter("orientador", variavel.orientador)
                    .SetParameter("email_orientador", variavel.email_orientador)
                    .SetParameter("arquivo_2passo", variavel.arquivo_2passo)
                    .SetParameter("data_fim", variavel.data_fim)
                    .SetParameter("xerox", variavel.xerox)
                    .SetParameter("dossie", variavel.dossie)
                    .SetParameter("endereco_local", variavel.endereco_local)
                    .SetParameter("arquivo_mapa", variavel.arquivo_mapa)
                    .SetParameter("obs_local", variavel.obs_local)
                    .SetParameter("pag_site_professores", variavel.pag_site_professores)
                    .SetParameter("pag_site_disciplina", variavel.pag_site_disciplina)
                    .SetParameter("contrato_tcc", variavel.contrato_tcc)
                    .SetParameter("certificadora", variavel.certificadora)
                    .SetParameter("certificadora_id", variavel.certificadora_id.certificadora_id)
                    .SetParameter("cartao", variavel.cartao)
                    .SetParameter("imprimir_certificado", variavel.imprimir_certificado)
                    .SetParameter("link_trailer", variavel.link_trailer)
                    .SetParameter("idhotel", variavel.idhotel)
                    .SetParameter("dtaberturainicial", variavel.dtaberturainicial)
                    .SetParameter("contratoc", variavel.contratoc)
                    .SetParameter("pagseguro_recorrente", variavel.pagseguro_recorrente);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE curso SET data = @data, painel = @painel, cidade_codigo = @cidade_codigo, titulo_curso = @titulo_curso, painel_contrato = @painel_contrato, data_contrato = @data_contrato, titulo = @titulo, titulo1 = @titulo1, texto = @texto, textoData = @textoData, valor = @valor, valor_avista = @valor_avista, matricula = @matricula, matricula1 = @matricula1, desconto_pgto_dia = @desconto_pgto_dia, data_criacao = @data_criacao, data_limite1 = @data_limite1, data_limite2 = @data_limite2, data_inicio = @data_inicio, data_2parcela = @data_2parcela, inicio_confirmado_data = @inicio_confirmado_data, ativo_data_abertura_matricula = @ativo_data_abertura_matricula, data_abertura_pre_reserva = @data_abertura_pre_reserva, qtd_parcelas = @qtd_parcelas, total_alunos = @total_alunos, tipo = @tipo, qtd_modulos = @qtd_modulos, pgto_1parcela = @pgto_1parcela, ultimas_vagas = @ultimas_vagas, inicio_confirmado = @inicio_confirmado, visualiza_site = @visualiza_site, ativar_monografia = @ativar_monografia, ativo = @ativo, vagas_esgotadas = @vagas_esgotadas, qtd_reposicao = @qtd_reposicao, representante = @representante, grupo_datas = @grupo_datas, carga_horaria = @carga_horaria, obs1 = @obs1, obs = @obs, cidade = @cidade, contrato = @contrato, contrato1 = @contrato1, contrato2 = @contrato2, orientador = @orientador, email_orientador = @email_orientador, arquivo_2passo = @arquivo_2passo, data_fim = @data_fim, xerox = @xerox, dossie = @dossie, endereco_local = @endereco_local, arquivo_mapa = @arquivo_mapa, obs_local = @obs_local, pag_site_professores = @pag_site_professores, pag_site_disciplina = @pag_site_disciplina, contrato_tcc = @contrato_tcc, certificadora = @certificadora, certificadora_id = @certificadora_id, cartao = @cartao, imprimir_certificado = @imprimir_certificado, link_trailer = @link_trailer, idhotel = @idhotel, dtaberturainicial = @dtaberturainicial, texto_curso = @texto_curso, contratoc = @contratoc, pagseguro_recorrente = @pagseguro_recorrente WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("cidade_codigo", variavel.cidade_codigo.codigo)
                    .SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("painel_contrato", variavel.painel_contrato.codigo)
                    .SetParameter("data_contrato", variavel.data_contrato)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("titulo1", variavel.titulo1)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("textoData", variavel.textoData)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("valor_avista", variavel.valor_avista)
                    .SetParameter("matricula", variavel.matricula)
                    .SetParameter("matricula1", variavel.matricula1)
                    .SetParameter("desconto_pgto_dia", variavel.desconto_pgto_dia)
                    .SetParameter("data_criacao", variavel.data_criacao)
                    .SetParameter("data_limite1", variavel.data_limite1)
                    .SetParameter("data_limite2", variavel.data_limite2)
                    .SetParameter("data_inicio", variavel.data_inicio)
                    .SetParameter("data_2parcela", variavel.data_2parcela)
                    .SetParameter("inicio_confirmado_data", variavel.inicio_confirmado_data)
                    .SetParameter("ativo_data_abertura_matricula", variavel.ativo_data_abertura_matricula)
                    .SetParameter("data_abertura_pre_reserva", variavel.data_abertura_pre_reserva)
                    .SetParameter("qtd_parcelas", variavel.qtd_parcelas)
                    .SetParameter("total_alunos", variavel.total_alunos)
                    .SetParameter("tipo", variavel.tipo)
                    .SetParameter("qtd_modulos", variavel.qtd_modulos)
                    .SetParameter("pgto_1parcela", variavel.pgto_1parcela)
                    .SetParameter("ultimas_vagas", variavel.ultimas_vagas)
                    .SetParameter("inicio_confirmado", variavel.inicio_confirmado)
                    .SetParameter("visualiza_site", variavel.visualiza_site)
                    .SetParameter("ativar_monografia", variavel.ativar_monografia)
                    .SetParameter("ativo", variavel.ativo)
                    .SetParameter("vagas_esgotadas", variavel.vagas_esgotadas)
                    .SetParameter("qtd_reposicao", variavel.qtd_reposicao)
                    .SetParameter("representante", variavel.representante)
                    .SetParameter("grupo_datas", variavel.grupo_datas)
                    .SetParameter("carga_horaria", variavel.carga_horaria)
                    .SetParameter("obs1", variavel.obs1)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("cidade", variavel.cidade)
                    .SetParameter("contrato", variavel.contrato)
                    .SetParameter("contrato1", variavel.contrato1)
                    .SetParameter("contrato2", variavel.contrato2)
                    .SetParameter("orientador", variavel.orientador)
                    .SetParameter("email_orientador", variavel.email_orientador)
                    .SetParameter("arquivo_2passo", variavel.arquivo_2passo)
                    .SetParameter("data_fim", variavel.data_fim)
                    .SetParameter("xerox", variavel.xerox)
                    .SetParameter("dossie", variavel.dossie)
                    .SetParameter("endereco_local", variavel.endereco_local)
                    .SetParameter("arquivo_mapa", variavel.arquivo_mapa)
                    .SetParameter("obs_local", variavel.obs_local)
                    .SetParameter("pag_site_professores", variavel.pag_site_professores)
                    .SetParameter("pag_site_disciplina", variavel.pag_site_disciplina)
                    .SetParameter("contrato_tcc", variavel.contrato_tcc)
                    .SetParameter("certificadora", variavel.certificadora)
                    .SetParameter("certificadora_id", variavel.certificadora_id.certificadora_id)
                    .SetParameter("cartao", variavel.cartao)
                    .SetParameter("imprimir_certificado", variavel.imprimir_certificado)
                    .SetParameter("link_trailer", variavel.link_trailer)
                    .SetParameter("idhotel", variavel.idhotel)
                    .SetParameter("dtaberturainicial", variavel.dtaberturainicial)
                    .SetParameter("texto_curso", variavel.texto_curso)
                    .SetParameter("contratoc", variavel.contratoc)
                    .SetParameter("pagseguro_recorrente", variavel.pagseguro_recorrente);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Curso WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Curso Buscar(int codigo)
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, ci.link as cidade_link, ci.cidade as cidade_cidade, ci.estado as cidade_estado, c.titulo_curso AS titulo_curso, tc.titulo as titulo_curso_titulo, tc.link as titulo_curso_link, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao AS cartao, c.imprimir_certificado as imprimir_certificado, isnull(c.link_trailer, '') as link_trailer, isnull(c.idhotel, 0) as idhotel, isnull(c.dtaberturainicial, '1900-01-01') as dtaberturainicial, c.texto_curso, c.contratoc, c.pagseguro_recorrente FROM curso as c INNER JOIN cidade as ci ON c.cidade_codigo = ci.codigo INNER JOIN titulo_curso as tc ON c.titulo_curso = tc.codigo WHERE c.codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]), titulo = Convert.ToString(reader["titulo_curso_titulo"]), link = Convert.ToString(reader["titulo_curso_link"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]), link = Convert.ToString(reader["cidade_link"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao  = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1  = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2  = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio  = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela  = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data  = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula  = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva  = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista  = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        matriculaContrato = Convert.ToDecimal(reader["matricula"]),
                        matricula1Contrato = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1  = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1  = Convert.ToString(reader["obs1"]),
                        obs  = Convert.ToString(reader["obs"]),
                        cidade  = Convert.ToString(reader["cidade"]),
                        contrato  = Convert.ToString(reader["contrato"]),
                        contrato1  = Convert.ToString(reader["contrato1"]),
                        contrato2  = Convert.ToString(reader["contrato2"]),
                        orientador  = Convert.ToString(reader["orientador"]),
                        email_orientador  = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo  = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim  = Convert.ToDateTime(reader["data_fim"]),
                        xerox  = Convert.ToString(reader["xerox"]),
                        dossie  = Convert.ToString(reader["dossie"]),
                        endereco_local  = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa  = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local  = Convert.ToString(reader["obs_local"]),
                        pag_site_professores  = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina  = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc  = Convert.ToString(reader["contrato_tcc"]),
                        certificadora  = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new CertificadoraDB().Buscar(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        dtaberturainicial = Convert.ToDateTime(reader["dtaberturainicial"]),
                        idhotel = Convert.ToInt32(reader["idhotel"]),
                        texto_curso = Convert.ToString(reader["texto_curso"]),
                        contratoc = Convert.ToString(reader["contratoc"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso Buscar(string codigo)
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao AS cartao, c.imprimir_certificado AS imprimir_certificado, isnull(c.link_trailer, '') as link_trailer, isnull(c.idhotel, 0) as idhotel, isnull(c.dtaberturainicial, '1900-01-01') as dtaberturainicial, c.texto_curso, c.contratoc, c.pagseguro_recorrente FROM curso as c WHERE c.titulo1 = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_cursoDB().Buscar(Convert.ToInt32(reader["titulo_curso"])),
                        cidade_codigo = new CidadeDB().Buscar(Convert.ToInt32(reader["cidade_codigo"])),
                        //cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto = Convert.ToString(reader["texto"]), textoData = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new CertificadoraDB().Buscar(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        dtaberturainicial = Convert.ToDateTime(reader["dtaberturainicial"]),
                        idhotel = Convert.ToInt32(reader["idhotel"]),
                        texto_curso = Convert.ToString(reader["texto_curso"]),
                        contratoc = Convert.ToString(reader["contratoc"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso Congresso()
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao as cartao, c.imprimir_certificado as imprimir_certificado, isnull(c.link_trailer, '') as link_trailer, c.pagseguro_recorrente FROM curso AS c WHERE c.ativo = 1 AND c.tipo = 3");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso SimposioMedicina()
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao as cartao, c.imprimir_certificado as imprimir_certificado, c.pagseguro_recorrente FROM curso AS c WHERE c.ativo = 1 AND c.tipo = 4 AND c.titulo_curso = 1");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso SimposioPsiquiatria()
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao AS cartao, c.imprimir_certificado as imprimir_certificado, c.pagseguro_recorrente FROM curso AS c WHERE c.ativo = 1 AND c.tipo = 4 AND c.titulo_curso = 3");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso JornadaPsiquiatria()
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, c.cartao AS cartao, c.imprimir_certificado as imprimir_certificado, isnull(c.link_trailer, '') as link_trailer, c.pagseguro_recorrente FROM curso AS c WHERE c.codigo = 374");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        cartao = Convert.ToBoolean(reader["cartao"]),
                        imprimir_certificado = Convert.ToBoolean(reader["imprimir_certificado"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto = Convert.ToString(reader["texto"]),
                        textoData = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Curso Buscar(int codigo, bool simples)
        {
            try
            {
                Curso curso = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT curso.codigo, curso.tipo, curso.titulo, curso.titulo1, curso.cidade_codigo, curso.titulo_curso, cidade.cidade, cidade.estado, curso.total_alunos FROM curso INNER JOIN cidade ON curso.cidade_codigo = cidade.codigo WHERE curso.codigo = @codigo ORDER BY cidade.cidade, curso.titulo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    curso = new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]), cidade = Convert.ToString(reader["cidade"]), estado = Convert.ToString(reader["estado"]) },
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"])
                    };
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                List<Curso> curso = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, isnull(link_trailer, '') as link_trailer, c.contratoc, c.pagseguro_recorrente FROM curso AS c ORDER BY c.titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        contratoc = Convert.ToString(reader["contratoc"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarResumido()
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.cidade_codigo as curso_cidade_codigo,  ci.cidade as cidade_cidade, ci.estado as cidade_estado, (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.curso = c.codigo AND a.situacao = '2') as confirmado FROM curso c inner join cidade as ci ON c.cidade_codigo = ci.codigo order by ci.cidade, c.titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        total_alunos = Convert.ToInt32(reader["confirmado"]),
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) }
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarResumido(int tipo)
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                string executar = "SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.cidade_codigo as curso_cidade_codigo,  ci.cidade as cidade_cidade, ci.estado as cidade_estado, (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.curso = c.codigo AND a.situacao = '2') as confirmado FROM curso c inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE 1=1 ";

                if (tipo == 0)
                    executar += " AND c.tipo in (0,1,2) ";
                if (tipo == 3)
                    executar += " AND c.tipo = 3 ";

                executar += " order by ci.cidade, c.titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        total_alunos = Convert.ToInt32(reader["confirmado"]),
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) }
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarNomeCurso(int codigo)
        {
            try
            {
                string turma = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT concat(titulo1, ' - ', titulo) AS titulo FROM curso where codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    turma = Convert.ToString(reader["titulo"]);
                }
                reader.Close();
                session.Close();

                return turma;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DateTime BuscarDataFim(int codigo)
        {
            try
            {
                DateTime data = Convert.ToDateTime("01/01/1900");

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(data_fim, '1900-01-01') as data from curso where codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    data = Convert.ToDateTime(reader["data"]);
                }
                reader.Close();
                session.Close();

                return data;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DateTime BuscarDataFimAluno(int codigo, int aluno)
        {
            try
            {
                DateTime data = Convert.ToDateTime("01/01/1900");

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select isnull(max(data), '1900-01-01') as data from conteudo_ead_vencimento where aluno = @aluno and conteudo_ead_id in (select conteudo_ead_id from conteudo_ead where curso = @codigo)");
                quey.SetParameter("codigo", codigo);
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    data = Convert.ToDateTime(reader["data"]);
                }
                reader.Close();
                session.Close();

                return data;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarAtivos()
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.data_inicio as data_inicio FROM curso AS c WHERE c.data_inicio <= getdate() ORDER BY c.titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarVisualizaSite()
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.ativo AS ativo FROM curso AS c WHERE c.visualiza_site = 1 and c.tipo in (0,1,2) and c.vagas_esgotadas = 0 ORDER BY c.titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        ativo = Convert.ToInt32(reader["ativo"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarVisualizaSite(int cidades = 0, int cursos = 0)
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                string executar = "SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.ativo as ativo FROM curso AS c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.vagas_esgotadas = 0 and c.tipo in (0,1,2) ";

                if (cursos != 0)
                    executar += " AND c.titulo_curso = " + cursos;
                if (cidades != 0)
                    executar += " AND ci.codigo = " + cidades;

                executar += " ORDER BY c.titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        ativo = Convert.ToInt32(reader["ativo"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> CursosPorTitulo(int titulo = 0)
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                string executar = "SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.cidade_codigo as curso_cidade_codigo, ci.cidade as cidade_cidade, ci.estado as cidade_estado FROM curso c inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.titulo_curso = " + titulo + " order by ci.cidade, c.titulo";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) }

                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarMidia()
        {
            try
            {
                List<Curso> curso = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, isnull(link_trailer, '') as link_trailer, c.pagseguro_recorrente FROM curso AS c WHERE exists (SELECT midia_id FROM midia_curso WHERE c.codigo = midia_curso.curso) ORDER BY c.titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarMidia(int midia_id)
        {
            try
            {
                List<Curso> curso = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, isnull(c.link_trailer, '') as link_trailer, c.pagseguro_recorrente FROM curso AS c WHERE exists (SELECT midia_id FROM midia_curso WHERE c.codigo = midia_curso.curso AND midia_curso.midia_id = @midia_id) ORDER BY c.titulo").SetParameter("midia_id", midia_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) },
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto  = Convert.ToString(reader["texto"]), textoData  = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new Certificadora(Convert.ToInt32(reader["certificadora_id"])),
                        link_trailer = Convert.ToString(reader["link_trailer"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<DadosRelatorio> Relatorio(string curso, DateTime inicio)
        {
            try
            {
                List<DadosRelatorio> dados = new List<DadosRelatorio>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("WITH date_range (semana) AS (SELECT @inicio UNION ALL SELECT DATEADD(week, 1, semana) FROM date_range WHERE DATEADD(week, 1, semana) <= getdate()) SELECT semana AS data, isnull(sum(case when ac.situacao = 2 then 1 else 0 end), 0) as confirmado, isnull(sum(case when ac.situacao = 0 and (ac.nao_fara_o_curso is null OR ac.nao_fara_o_curso = '1900-01-01') then 1 else 0 end), 0) as aberto, isnull(sum(case when ac.situacao > 2 then 1 else 0 end), 0) as desistente, isnull(sum(case when da.data > '1900-01-01' AND da.data <= semana then 1 else 0 end), 0) as contrato, isnull(sum(case when ac.nao_fara_o_curso is not null and ac.nao_fara_o_curso != '1900-01-01' then 1 else 0 end), 0) as nao_fara_o_curso FROM date_range JOIN aluno_curso as ac ON ac.adesao <= semana AND NOT EXISTS (SELECT aluno_equipe.aluno FROM aluno_equipe WHERE aluno_equipe.aluno = ac.aluno) JOIN curso as c ON ac.curso = c.codigo AND c.titulo1 = @curso LEFT JOIN documentos AS d ON c.codigo = d.curso AND d.documentos1 LIKE '%Contrato%' LEFT JOIN documentos_alunos AS da ON da.documentos = d.codigo AND da.aluno = ac.aluno AND ac.situacao = 2 AND da.curso = c.codigo GROUP BY date_range.semana ORDER BY date_range.semana")
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio);
                IDataReader reader = quey.ExecuteQuery();

                DadosRelatorio dr = new DadosRelatorio();
                DadosRelatorio dranterior = new DadosRelatorio();

                while (reader.Read())
                {
                    dr = new DadosRelatorio(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["confirmado"]), Convert.ToInt32(reader["aberto"]), Convert.ToInt32(reader["desistente"]), Convert.ToInt32(reader["contrato"]), Convert.ToInt32(reader["nao_fara_o_curso"]));
                    if(dr.aberto != dranterior.aberto || dr.confirmado != dranterior.confirmado || dr.desistente != dranterior.desistente || dr.contrato != dranterior.contrato || dr.nao_fara_o_curso != dranterior.nao_fara_o_curso)
                        dados.Add(dr);
                    dranterior = new DadosRelatorio(Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["confirmado"]), Convert.ToInt32(reader["aberto"]), Convert.ToInt32(reader["desistente"]), Convert.ToInt32(reader["contrato"]), Convert.ToInt32(reader["nao_fara_o_curso"]));
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

        public DadosRelatorio Dado(string curso, DateTime inicio, string titulo)
        {
            try
            {
                DadosRelatorio dados = new DadosRelatorio(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select @inicio as data, isnull(sum(case when ac.situacao = 0 then 1 else 0 end), 0) as aberto, isnull(sum(case when ac.situacao = 2 then 1 else 0 end), 0) as confirmado, isnull(sum(case when ac.situacao > 2 then 1 else 0 end), 0) as desistente, isnull(sum(case when da.data > '1900-01-01' AND da.data <= @inicio then 1 else 0 end), 0) as contrato FROM aluno_curso as ac JOIN curso as c ON ac.curso = c.codigo AND NOT EXISTS (SELECT aluno_equipe.aluno FROM aluno_equipe WHERE aluno_equipe.aluno = ac.aluno) AND c.titulo1 = @curso LEFT JOIN documentos AS d ON c.codigo = d.curso AND d.documentos1 LIKE '%Contrato%' LEFT JOIN documentos_alunos AS da ON da.documentos = d.codigo AND da.aluno = ac.aluno AND ac.situacao = 2 AND da.curso = c.codigo WHERE c.titulo1 = @curso and ac.adesao <= @inicio")
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dados = new DadosRelatorio(titulo, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["confirmado"]), Convert.ToInt32(reader["aberto"]), Convert.ToInt32(reader["desistente"]), Convert.ToInt32(reader["contrato"]));
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

        public List<Valor> TituloCursos(int tipo = 0, int cursos = 0)
        {
            try
            {
                string executar = "select distinct t.codigo AS id, t.titulo AS titulo, t.link AS link FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo";

                if (cursos != 0)
                    executar += " AND c.codigo = " + cursos;

                executar += " GROUP BY t.codigo, t.titulo, t.link ORDER BY t.titulo";

                List<Valor> dados = new List<Valor>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Valor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["link"])));
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

        public List<Valor> Cidades(int tipo = 0, int curso = 0)
        {
            try
            {
                string executar = "select distinct ci.codigo AS id, concat(ci.cidade, ' - ', ci.estado) AS titulo, ci.link as link from curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso AS t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo";

                if (curso != 0)
                    executar += " AND c.codigo = " + curso;

                executar += " GROUP BY ci.codigo, ci.cidade, ci.estado, ci.link ORDER BY titulo";

                List<Valor> dados = new List<Valor>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Valor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["link"])));
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

        public List<Valor> CidadesTituloCursos(int tipo = 0, int titulo_curso = 0)
        {
            try
            {
                string executar = "select distinct ci.codigo AS id, concat(ci.cidade, ' - ', ci.estado) AS titulo, ci.link as link from curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso AS t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo";

                if (titulo_curso != 0)
                    executar += " AND t.codigo = " + titulo_curso;

                executar += " GROUP BY ci.codigo, ci.cidade, ci.estado, ci.link ORDER BY titulo";

                List<Valor> dados = new List<Valor>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Valor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["link"])));
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

        public List<Turma> Cursos(int cidades = 0, int cursos = 0)
        {
            try
            {
                string executar = "select distinct c.codigo AS id, c.titulo AS titulo, c.inicio_confirmado, c.ultimas_vagas, c.data_inicio FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.vagas_esgotadas = 0 and c.tipo in (0,1,2) ";

                if (cursos != 0)
                    executar += " AND c.titulo_curso = " + cursos;
                if (cidades != 0)
                    executar += " AND ci.codigo = " + cidades;

                executar += " GROUP BY c.codigo, c.titulo, c.data_inicio, c.inicio_confirmado, c.ultimas_vagas ORDER BY titulo";

                List<Turma> dados = new List<Turma>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Turma(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToBoolean(reader["inicio_confirmado"]), Convert.ToBoolean(reader["ultimas_vagas"])));
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

        public List<Turma> Cursos(int tipo = 0, int cidades = 0, int cursos = 0)
        {
            try
            {
                string executar = "select distinct c.codigo AS id, c.titulo AS titulo, c.titulo1 AS titulo1, c.inicio_confirmado, c.ultimas_vagas, c.data_inicio, c.ativo FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.vagas_esgotadas = 0 and c.tipo = @tipo and c.tipo in (0,1,2) ";

                if (cursos != 0)
                    executar += " AND c.titulo_curso = " + cursos;
                if (cidades != 0)
                    executar += " AND ci.codigo = " + cidades;

                executar += " GROUP BY c.codigo, c.titulo, c.titulo1, c.data_inicio, c.inicio_confirmado, c.ultimas_vagas, c.ativo ORDER BY titulo";

                List<Turma> dados = new List<Turma>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Turma(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToBoolean(reader["inicio_confirmado"]), Convert.ToBoolean(reader["ultimas_vagas"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo1"])));
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

        public List<Turma> CursosHome(int tipo = 0, int cidades = 0, int cursos = 0)
        {
            try
            {
                string executar = "select distinct c.codigo AS id, c.titulo AS titulo, c.titulo1 AS titulo1, c.inicio_confirmado, c.ultimas_vagas, c.data_inicio, c.ativo, c.vagas_esgotadas FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo and c.tipo in (0,1,2) ";

                if (cursos != 0)
                    executar += " AND c.titulo_curso = " + cursos;
                if (cidades != 0)
                    executar += " AND ci.codigo = " + cidades;

                executar += " GROUP BY c.codigo, c.titulo, c.titulo1, c.data_inicio, c.inicio_confirmado, c.ultimas_vagas, c.ativo, c.Vagas_esgotadas ORDER BY titulo";

                List<Turma> dados = new List<Turma>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Turma(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToBoolean(reader["inicio_confirmado"]), Convert.ToBoolean(reader["ultimas_vagas"]), Convert.ToInt32(reader["ativo"]),Convert.ToString(reader["titulo1"])));
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

        public List<Turma> CursosHomeEad(int tipo = 0, int cidades = 0, int cursos = 0)
        {
            try
            {
                string executar = "select distinct c.codigo AS id, c.titulo AS titulo, c.titulo1 AS titulo1, c.inicio_confirmado, c.ultimas_vagas, c.data_inicio, c.ativo, c.vagas_esgotadas, g.txgrupo FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo JOIN grupos_ead as ge ON ge.idcurso = c.codigo JOIN grupos as g ON g.idgrupo = ge.idgrupo where c.visualiza_site = 1 and c.tipo = @tipo and c.tipo in (0,1,2) ";

                if (cursos != 0)
                    executar += " AND c.titulo_curso = " + cursos;
                if (cidades != 0)
                    executar += " AND ci.codigo = " + cidades;

                executar += " GROUP BY c.codigo, c.titulo, c.titulo1, c.data_inicio, c.inicio_confirmado, c.ultimas_vagas, c.ativo, c.Vagas_esgotadas, g.txgrupo ORDER BY g.txgrupo";

                List<Turma> dados = new List<Turma>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Turma(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToDateTime(reader["data_inicio"]), Convert.ToBoolean(reader["inicio_confirmado"]), Convert.ToBoolean(reader["ultimas_vagas"]), Convert.ToInt32(reader["ativo"]), Convert.ToString(reader["titulo1"]), Convert.ToString(reader["txgrupo"])));
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

        public List<Valor> Cidades()
        {
            try
            {
                string executar = "select distinct ci.codigo AS id, ci.cidade AS titulo, ci.link as link from curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso AS t ON c.titulo_curso = t.codigo where c.visualiza_site = 1";

                executar += " GROUP BY ci.codigo, ci.cidade, ci.link ORDER BY ci.cidade";

                List<Valor> dados = new List<Valor>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Valor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["link"])));
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

        public List<Cursos> TituloCursos(TipoCurso tipo = 0, int top = 1000)
        {
            try
            {
                string executar = "select tbl.*, (select top 1 codigo from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as codigo, (select top 1 titulo1 from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as titulo1, (select top 1 link_trailer from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as link_trailer, (select top 1 texto from curso where titulo_curso = tbl.id and visualiza_site = 1 and tipo in (0,1,2) order by data_inicio) as texto from (select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo GROUP BY t.codigo, t.titulo, c.titulo, t.imagem, t.ordem, t.link ORDER BY t.ordem) as tbl ORDER BY tbl.ordem";

                //string executar = "select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and c.tipo = @tipo GROUP BY t.codigo, t.titulo, c.titulo, t.imagem, t.ordem, t.link ORDER BY t.ordem";

                List<Cursos> dados = new List<Cursos>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
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

        public List<Curso> Proximos(TipoCurso tipo = 0, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, (case when @tipo = 0 then c.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, c.titulo1 AS titulo1, ci.cidade AS cidade, c.data_inicio, c.inicio_confirmado AS inicio_confirmado FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.tipo = @tipo ORDER BY c.data_inicio";

                List<Curso> dados = new List<Curso>(); 

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso() {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"])
                    });
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

        public List<Curso> ProximosSite(TipoCurso tipo = 0, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, (case when @tipo = 0 then c.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, c.titulo1 AS titulo1, ci.cidade AS cidade, c.data_inicio, c.inicio_confirmado AS inicio_confirmado FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.tipo = @tipo AND (select count(*) from encontro where curso = c.codigo and data_encontro < getdate()) < 4 ORDER BY c.data_inicio";

                List<Curso> dados = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"])
                    });
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

        public List<Curso> Proximos(Titulo_curso titulo_curso, TipoCurso tipo = 0, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, (case when @tipo = 0 then c.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, c.titulo1 AS titulo1, ci.cidade AS cidade, c.data_inicio, c.inicio_confirmado AS inicio_confirmado, c.matricula, c.matricula1, c.data_limite1, c.valor, c.qtd_parcelas FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.titulo_curso = @titulo_curso and c.tipo = @tipo ORDER BY c.data_inicio";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("titulo_curso", titulo_curso.codigo)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"])
                    });
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

        public List<Curso> Proximos(Titulo_curso titulo_curso, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, isnull(c.idhotel, 0) as idhotel, c.pagseguro_recorrente FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.titulo_curso = @titulo_curso and c.tipo in (0,1,2) ORDER BY data_inicio";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("titulo_curso", titulo_curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_cursoDB().Buscar(Convert.ToInt32(reader["titulo_curso"])),
                        cidade_codigo = new CidadeDB().Buscar(Convert.ToInt32(reader["cidade_codigo"])),
                        //cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto = Convert.ToString(reader["texto"]),
                        textoData = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new CertificadoraDB().Buscar(Convert.ToInt32(reader["certificadora_id"])),
                        idhotel = Convert.ToInt32(reader["idhotel"]),
                        pagseguro_recorrente = Convert.ToBoolean(reader["pagseguro_recorrente"])
                    });
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

        public List<Curso> ProximosWorkshop(Titulo_curso titulo_curso, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, isnull(c.data, '1900-01-01') AS data, c.painel AS painel, c.cidade_codigo AS cidade_codigo, c.titulo_curso AS titulo_curso, isnull(c.data_contrato, '1900-01-01') AS data_contrato, c.painel_contrato AS painel_contrato, isnull(c.data_criacao, '1900-01-01') AS data_criacao, c.titulo AS titulo, c.titulo1 AS titulo1, c.texto AS texto, c.textoData AS textoData, c.valor AS valor, c.valor_avista AS valor_avista, c.matricula AS matricula, c.matricula1 AS matricula1, c.matricula2 AS matricula2, isnull(c.data_limite1, '1900-01-01') as data_limite1, isnull(c.data_limite2, '1900-01-01') as data_limite2, c.qtd_parcelas AS qtd_parcelas, c.total_alunos AS total_alunos, c.tipo AS tipo, c.obs1 AS obs1, c.obs AS obs, c.qtd_modulos AS qtd_modulos, c.duracao AS duracao, isnull(c.data_inicio, '1900-01-01') data_inicio, isnull(c.data_2parcela, '1900-01-01') AS data_2parcela, c.desconto_pgto_dia AS desconto_pgto_dia, c.cidade AS cidade, isnull(c.estado, '') AS estado, c.pgto_1parcela AS pgto_1parcela, c.ultimas_vagas AS ultimas_vagas, c.inicio_confirmado AS inicio_confirmado, isnull(c.inicio_confirmado_data, '1900-01-01') AS inicio_confirmado_data, c.visualiza_site AS visualiza_site, c.contrato AS contrato, c.contrato1 AS contrato1, c.contrato2 AS contrato2, c.orientador AS orientador, c.email_orientador AS email_orientador, isnull(c.arquivo_1passo, '') AS arquivo_1passo, isnull(c.arquivo_2passo, '') AS arquivo_2passo, isnull(c.arquivo_2passo1, '') AS arquivo_2passo1, isnull(c.data_fim, '1900-01-01') AS data_fim, c.ativar_monografia AS ativar_monografia, c.ativo AS ativo, isnull(c.ativo_data_abertura_matricula, '1900-01-01') AS ativo_data_abertura_matricula, isnull(c.data_abertura_pre_reserva, '1900-01-01') AS data_abertura_pre_reserva, c.vagas_esgotadas AS vagas_esgotadas, c.xerox AS xerox, isnull(c.dossie, '') as dossie, c.endereco_local AS endereco_local, isnull(c.arquivo_mapa, '') AS arquivo_mapa, c.obs_local AS obs_local, c.qtd_reposicao AS qtd_reposicao, c.pag_site_professores AS pag_site_professores, c.pag_site_disciplina AS pag_site_disciplina, c.representante AS representante, isnull(c.dia_vencimento, 10) AS dia_vencimento, c.valor_taxa_tcc AS valor_taxa_tcc, c.contrato_tcc AS contrato_tcc, c.dias_final_tcc AS dias_final_tcc, c.grupo_datas AS grupo_datas, (select certificadora.titulo FROM certificadora WHERE certificadora.certificadora_id = c.certificadora_id) AS certificadora, c.certificadora_id AS certificadora_id, c.carga_horaria AS carga_horaria, isnull(c.idhotel, 0) as idhotel FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE (c.visualiza_site = 1 or (c.visualiza_site = 0 and c.data_inicio >= getdate())) and c.titulo_curso = @titulo_curso and c.tipo in (0,1,2) ORDER BY data_inicio DESC";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("titulo_curso", titulo_curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        qtd_parcelas = Convert.ToInt32(reader["qtd_parcelas"]),
                        total_alunos = Convert.ToInt32(reader["total_alunos"]),
                        tipo = Convert.ToInt32(reader["tipo"]),
                        qtd_modulos = Convert.ToInt32(reader["qtd_modulos"]),
                        pgto_1parcela = Convert.ToInt32(reader["pgto_1parcela"]),
                        ultimas_vagas = Convert.ToInt32(reader["ultimas_vagas"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"]),
                        visualiza_site = Convert.ToInt32(reader["visualiza_site"]),
                        ativar_monografia = Convert.ToInt32(reader["ativar_monografia"]),
                        ativo = Convert.ToInt32(reader["ativo"]),
                        vagas_esgotadas = Convert.ToInt32(reader["vagas_esgotadas"]),
                        qtd_reposicao = Convert.ToInt32(reader["qtd_reposicao"]),
                        representante = Convert.ToInt32(reader["representante"]),
                        grupo_datas = Convert.ToInt32(reader["grupo_datas"]),
                        carga_horaria = Convert.ToInt32(reader["carga_horaria"]),
                        titulo_curso = new Titulo_cursoDB().Buscar(Convert.ToInt32(reader["titulo_curso"])),
                        cidade_codigo = new CidadeDB().Buscar(Convert.ToInt32(reader["cidade_codigo"])),
                        //cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["cidade_codigo"]) },
                        painel = new Painel() { codigo = Convert.ToInt32(reader["painel"]) },
                        painel_contrato = new Painel() { codigo = Convert.ToInt32(reader["painel_contrato"]) },
                        data = Convert.ToDateTime(reader["data"]),
                        data_contrato = Convert.ToDateTime(reader["data"]),
                        data_criacao = Convert.ToDateTime(reader["data_criacao"]),
                        data_limite1 = Convert.ToDateTime(reader["data_limite1"]),
                        data_limite2 = Convert.ToDateTime(reader["data_limite2"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        data_2parcela = Convert.ToDateTime(reader["data_2parcela"]),
                        inicio_confirmado_data = Convert.ToDateTime(reader["inicio_confirmado_data"]),
                        ativo_data_abertura_matricula = Convert.ToDateTime(reader["ativo_data_abertura_matricula"]),
                        data_abertura_pre_reserva = Convert.ToDateTime(reader["data_abertura_pre_reserva"]),
                        valor = Convert.ToDecimal(reader["valor"]),
                        valor_avista = Convert.ToDecimal(reader["valor_avista"]),
                        matricula = Convert.ToDecimal(reader["matricula"]),
                        matricula1 = Convert.ToDecimal(reader["matricula1"]),
                        desconto_pgto_dia = Convert.ToDecimal(reader["desconto_pgto_dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        texto = Convert.ToString(reader["texto"]),
                        textoData = Convert.ToString(reader["textoData"]),
                        obs1 = Convert.ToString(reader["obs1"]),
                        obs = Convert.ToString(reader["obs"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        orientador = Convert.ToString(reader["orientador"]),
                        email_orientador = Convert.ToString(reader["email_orientador"]),
                        arquivo_2passo = Convert.ToString(reader["arquivo_2passo"]),
                        data_fim = Convert.ToDateTime(reader["data_fim"]),
                        xerox = Convert.ToString(reader["xerox"]),
                        dossie = Convert.ToString(reader["dossie"]),
                        endereco_local = Convert.ToString(reader["endereco_local"]),
                        arquivo_mapa = Convert.ToString(reader["arquivo_mapa"]),
                        obs_local = Convert.ToString(reader["obs_local"]),
                        pag_site_professores = Convert.ToString(reader["pag_site_professores"]),
                        pag_site_disciplina = Convert.ToString(reader["pag_site_disciplina"]),
                        contrato_tcc = Convert.ToString(reader["contrato_tcc"]),
                        certificadora = Convert.ToString(reader["certificadora"]),
                        certificadora_id = new CertificadoraDB().Buscar(Convert.ToInt32(reader["certificadora_id"])),
                        idhotel = Convert.ToInt32(reader["idhotel"]),
                    });
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

        public List<Curso> CursosCidade(Titulo_curso titulo_curso)
        {
            try
            {
                string executar = "select distinct c.titulo1 AS titulo1, c.cidade FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.titulo_curso = @titulo_curso and c.tipo in (0,1,2) ORDER BY c.cidade";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("titulo_curso", titulo_curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                    });
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

        public List<Curso> CursosCidade2(Titulo_curso titulo_curso)
        {
            try
            {
                string executar = "select c.titulo1, t.cidade from (select max(c.codigo) as codigo, c.cidade FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and c.titulo_curso = @titulo_curso and c.tipo in (0, 1, 2) GROUP BY c.cidade) as t left join curso c on c.codigo = t.codigo ORDER BY t.cidade";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("titulo_curso", titulo_curso.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                    });
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

        public List<Curso> Proximos(Cidade cidade, TipoCurso tipo = 0, int top = 1000)
        {
            try
            {
                string executar = "select distinct top " + top + " c.codigo AS codigo, (case when @tipo = 0 then c.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, c.titulo1 AS titulo1, ci.cidade AS cidade, c.data_inicio, c.inicio_confirmado AS inicio_confirmado FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.visualiza_site = 1 and ci.codigo = @cidade and c.tipo = @tipo ORDER BY c.data_inicio";

                List<Curso> dados = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("tipo", tipo)
                    .SetParameter("cidade", cidade.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        cidade = Convert.ToString(reader["cidade"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        inicio_confirmado = Convert.ToInt32(reader["inicio_confirmado"])
                    });
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

       public List<Cursos> TituloCursos(Cidade cidade, TipoCurso tipo, int top = 1000)
        {
            try
            {
                //string executar = "select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and ci.codigo = @codigo and c.tipo = @tipo GROUP BY t.codigo, t.titulo, c.titulo, t.imagem, t.ordem, t.link ORDER BY t.ordem";
                string executar = "select tbl.*, ISNULL((select top 1 codigo from curso where titulo_curso = tbl.id and visualiza_site = 1 and cidade_codigo = @codigo and tipo in (0,1,2) order by data_inicio),0) as codigo from (select distinct top " + top + " t.codigo AS id, (case when @tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem, c.titulo1 FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and ci.codigo = @codigo and c.tipo = @tipo GROUP BY t.codigo, t.titulo, c.titulo, c.titulo1, t.imagem, t.ordem, t.link ORDER BY t.ordem) as tbl ORDER BY tbl.ordem";

                List<Cursos> dados = new List<Cursos>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("codigo", cidade.codigo)
                    .SetParameter("tipo", tipo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Cursos(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"]), Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo1"])));
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

        public List<Cursos> TituloCursos(Cidade cidade, int top = 1000)
        {
            try
            {
                string executar = "select distinct top 100 t.codigo AS id, (case when c.tipo = 0 then t.titulo else left(c.titulo, charindex(' (', c.titulo)) end) AS titulo, t.link as link, t.imagem AS imagem, t.ordem as ordem FROM curso as c JOIN cidade as ci ON c.cidade_codigo = ci.codigo JOIN titulo_curso as t ON c.titulo_curso = t.codigo where c.visualiza_site = 1 and ci.codigo = @codigo GROUP BY t.codigo, c.tipo, t.titulo, c.titulo, t.imagem, t.ordem, t.link ORDER BY t.ordem";

                List<Cursos> dados = new List<Cursos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar)
                    .SetParameter("codigo", cidade.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dados.Add(new Cursos(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"]), Convert.ToString(reader["link"])));
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

        public List<Curso> Cursos14Encontro(int qtd = 15)
        {
            try
            {
                List<Curso> curso = new List<Curso>(); ;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select codigo, titulo, titulo1, data_inicio from curso where data_inicio between dateadd(MONTH, -" + (qtd + 1) + ", getdate()) and dateadd(MONTH, -" + (qtd)+ ", getdate()) and tipo = 0 and exists(select * from encontro inner join aluno_curso_encontro ON encontro.disciplina = aluno_curso_encontro.disciplina WHERE encontro.curso = curso.codigo and encontro.ativo = 1)");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        data_inicio = Convert.ToDateTime(reader["data_inicio"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        titulo = Convert.ToString(reader["titulo"])
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> BuscarLista(string ids)
        {
            try
            {
                List<Curso> curso = new List<Curso>();
                string qry = "";
                DBSession session = new DBSession();
                qry = "SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.contrato, c.contrato1, c.contrato2, c.contratoc FROM curso c where c.codigo in (" + ids + ") order by c.titulo";
                Query quey = session.CreateQuery(qry);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        contrato = Convert.ToString(reader["contrato"]),
                        contrato1 = Convert.ToString(reader["contrato1"]),
                        contrato2 = Convert.ToString(reader["contrato2"]),
                        contratoc = Convert.ToString(reader["contratoc"]),
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DateTime BuscarDataListaEspera(string codigo)
        {
            try
            {
                DateTime data = Convert.ToDateTime("01/01/1900");

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(data_lista_espera, '1900-01-01') as data FROM curso WHERE titulo1 = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    data = Convert.ToDateTime(reader["data"]);
                }
                reader.Close();
                session.Close();

                return data;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> ListarResumidoPorAluno(int aluno = 0)
        {
            try
            {
                List<Curso> curso = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT c.codigo AS codigo, c.titulo AS titulo, c.titulo1 AS titulo1, c.cidade_codigo as curso_cidade_codigo,  ci.cidade as cidade_cidade, ci.estado as cidade_estado, (SELECT count(a.codigo) FROM aluno_curso as a WHERE a.curso = c.codigo AND a.situacao = '2') as confirmado FROM curso c inner join cidade as ci ON c.cidade_codigo = ci.codigo WHERE c.codigo not in (select curso from aluno_curso where aluno = @aluno) and((c.visualiza_site = 1 AND c.ativo = 1) OR(c.tipo = 3 AND c.ativo = 1) OR c.data_inicio > getdate()) order by ci.cidade, c.titulo");
                quey.SetParameter("aluno", aluno);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["codigo"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                        total_alunos = Convert.ToInt32(reader["confirmado"]),
                        cidade_codigo = new Cidade() { codigo = Convert.ToInt32(reader["curso_cidade_codigo"]), cidade = Convert.ToString(reader["cidade_cidade"]), estado = Convert.ToString(reader["cidade_estado"]) }
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int TotalAlunos(int curso, string adesao)
        {
            try
            {
                int t = 0;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT count(*) as total FROM aluno_curso WHERE curso = @curso AND (situacao = '2' OR situacao = '1' OR (situacao = '0' AND adesao >= @adesao))");
                quey.SetParameter("curso", curso);
                quey.SetParameter("adesao", adesao);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    t = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
                session.Close();

                return t;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> Listar(int pagina = 1)
        {
            try
            {
                List<Curso> dataLote = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, titulo, titulo1 FROM curso ORDER BY titulo1 OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> Listar(int pagina = 1, string curso = "")
        {
            try
            {
                List<Curso> dataLote = new List<Curso>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT codigo, titulo, titulo1 FROM curso WHERE titulo1 like '%" + curso.Replace(" ", "%") + "%' or titulo like '%" + curso.Replace(" ", "%") + "%' ORDER BY titulo1 OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Curso(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["titulo1"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM curso");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string curso = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM curso WHERE titulo1 like '%" + curso.Replace(" ", "%") + "%' or titulo like '%" + curso.Replace(" ", "%") + "%'");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int BuscarCodigo(string curso = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("select codigo from curso where titulo1 = @curso");
            quey.SetParameter("curso", curso);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["codigo"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<Curso> AutomacaoAlterarParcela(int tipo = 1)
        {
            try
            {
                string q = "";
                List<Curso> dataLote = new List<Curso>();

                if (tipo == 1)
                {
                    q = "select codigo from curso where data_inicio <= getdate() and data_fim > getdate() and pgto_1parcela = 0 and data_2parcela > getdate() and tipo = 0 and visualiza_site = 1";
                }

                if (tipo == 2)
                {
                    q = "select codigo from curso where data_inicio <= getdate() and data_fim > getdate() and pgto_1parcela = 0 and data_2parcela <= getdate() and tipo = 0 and visualiza_site = 1";
                }

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(q);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Curso(Convert.ToInt32(reader["codigo"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Curso> BuscarListaEADTermino()
        {
            try
            {
                List<Curso> curso = new List<Curso>();
                string qry = "";
                DBSession session = new DBSession();
                qry = "select DateDiff(day, getdate(), data_fim) as dia, titulo1, titulo from curso where tipo = 2 and DateDiff(day, getdate(), data_fim) > 0";
                Query quey = session.CreateQuery(qry);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    curso.Add(new Curso()
                    {
                        codigo = Convert.ToInt32(reader["dia"]),
                        titulo = Convert.ToString(reader["titulo"]),
                        titulo1 = Convert.ToString(reader["titulo1"]),
                    });
                }
                reader.Close();
                session.Close();

                return curso;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
