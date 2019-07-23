using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineTurmasDashboardDB
    {
        public List<TurmasDashboardAnalise> AnaliseConfirmacao(int turma = 0)
        {
            try
            {
                string titulo;
                int codigo;
                int tempo_matricula;
                int confirmados;
                int confirmadosmes;
                int confirmados4meses;
                int naoconfirmados;
                int naoconfirmadosmes;
                int naoconfirmados4meses;
                int boletosmes;
                int boletos4meses;
                int pontos;
                int destaques;
                int farao;
                DateTime datainicio;
                DateTime dataconfirmado;
                int p1, p2, p3, p4, p5, p6;

                List<TurmasDashboardAnalise> analise = new List<TurmasDashboardAnalise>();

                string qry = "";
                qry = "SELECT ";
                qry += "C.titulo1, C.titulo, C.codigo, DATEDIFF(MONTH, C.ativo_data_abertura_matricula, GETDATE()) AS tempo_matricula, ISNULL(C.data_inicio, '1900-01-01') AS data_inicio, ";
                qry += "    ISNULL((SELECT MAX(A.adesao) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2'),'1900-01-01') AS data_confirmado, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2') AS confirmados, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -1, GETDATE())) as confirmadosmes, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -4, GETDATE())) as confirmados4meses, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND A.data >= DATEADD(MONTH, -1, GETDATE())) as naoconfirmadosmes, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND A.data >= DATEADD(MONTH, -4, GETDATE())) as naoconfirmados4meses, ";
                qry += "    (SELECT COUNT(*) as total from TIMELINE_EVENTOS_DESTAQUE WHERE idcurso = C.codigo and YEAR(dtfim) = 1900) as destaque, ";
                qry += "    (select count(*) as total from alunos_confirmacao a inner join aluno_curso ac on ac.codigo = a.idaluno_curso where ac.curso = c.codigo and datediff(day, a.dtconfirmacao, getdate()) <= 15) as farao ";
                qry += "FROM CURSO C ";
                qry += "WHERE C.codigo > 0 AND(C.visualiza_site = '1' or C.tipo = 3) and C.inicio_confirmado = 0 and C.tipo in (0, 1) ";
                if (turma != 0)
                {
                    qry += " AND C.codigo = " + turma + " ";
                }
                qry += "ORDER BY C.titulo1";
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(qry);
                //Query quey = session.CreateQuery(@"SELECT 
                // C.titulo1, C.titulo, C.codigo, DATEDIFF(DAY, C.dtaberturainicial, GETDATE()) AS tempo_matricula,
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2') AS confirmados,
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -1, GETDATE())) as confirmadosmes,
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -4, GETDATE())) as confirmados4meses,
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900) as naoconfirmados,
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900 AND Year(isnull(email_impressao_boleto, '1900-01-01')) = 1900 AND A.data >= DATEADD(MONTH, -1, GETDATE())) as naoconfirmadosmes,	
                // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900 AND Year(isnull(email_impressao_boleto, '1900-01-01')) = 1900 AND A.data >= DATEADD(MONTH, -4, GETDATE())) as naoconfirmados4meses,
                // (SELECT count(ACS.aluno_curso) FROM ALUNO_CURSO A INNER JOIN ALUNO_CURSO_STATUS ACS ON ACS.aluno_curso = A.codigo WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND ACS.status = 3 AND ACS.dtstatus >= DATEADD(MONTH, -1, GETDATE())) AS boletosmes,
                // (SELECT count(ACS.aluno_curso) FROM ALUNO_CURSO A INNER JOIN ALUNO_CURSO_STATUS ACS ON ACS.aluno_curso = A.codigo WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND ACS.status = 3 AND ACS.dtstatus >= DATEADD(MONTH, -4, GETDATE())) AS boletos4meses
                //FROM CURSO C
                //WHERE C.codigo > 0 AND (C.visualiza_site = '1' or C.tipo = 3) and C.inicio_confirmado = 0 and C.tipo in (0,1)
                //ORDER BY C.titulo1
                //");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    titulo = Convert.ToString(reader["titulo1"]);
                    codigo = Convert.ToInt32(reader["codigo"]);
                    tempo_matricula = Convert.ToInt32(reader["tempo_matricula"]);
                    confirmados = Convert.ToInt32(reader["confirmados"]);
                    confirmadosmes = Convert.ToInt32(reader["confirmadosmes"]);
                    confirmados4meses = Convert.ToInt32(reader["confirmados4meses"]);
                    //naoconfirmados = Convert.ToInt32(reader["naoconfirmados"]);                    
                    naoconfirmadosmes = Convert.ToInt32(reader["naoconfirmadosmes"]);
                    naoconfirmados4meses = Convert.ToInt32(reader["naoconfirmados4meses"]);
                    //boletosmes = Convert.ToInt32(reader["boletosmes"]);
                    //boletos4meses = Convert.ToInt32(reader["boletos4meses"]);
                    pontos = 0;
                    destaques = Convert.ToInt32(reader["destaque"]);
                    datainicio = Convert.ToDateTime(reader["data_inicio"]);
                    dataconfirmado = Convert.ToDateTime(reader["data_confirmado"]);
                    farao = Convert.ToInt32(reader["farao"]);
                    p1 = 0;
                    p2 = 0;
                    p3 = 0;
                    p4 = 0;
                    p5 = 0;
                    p6 = 0;

                    naoconfirmados = 0;
                    boletosmes = 0;
                    boletos4meses = 0;

                    // Alunos confirmados
                    if (confirmados >= 24) { p1 += 12; } else { if (confirmados >= 20) { p1 += 8; } else { if (confirmados >= 16) { p1 += 4; } } }

                    // Taxa de crescimento de matrículas feitas
                    if ((confirmadosmes >= 8) || (confirmados4meses >= 24)) { p2 += 10; } else { if ((confirmadosmes >= 6) || (confirmados4meses >= 18)) { p2 += 6; } else { if ((confirmadosmes >= 3) || (confirmados4meses >= 9)) { p2 += 2; } } }

                    // Taxa de crescimento de não confirmados
                    if ((naoconfirmadosmes >= 8) || (naoconfirmados4meses >= 24)) { p3 += 3; } else { if ((naoconfirmadosmes >= 6) || (naoconfirmados4meses >= 18)) { p3 += 2; } else { if ((naoconfirmadosmes >= 3) || (naoconfirmados4meses >= 9)) { p3 += 1; } } }

                    // Boletos enviados via solicitação
                    //if ((boletosmes >= 9) || (boletos4meses >= 30)) { p4 += 6; } else { if ((boletosmes >= 7) || (boletos4meses >= 22)) { p4 += 4; } else { if ((boletosmes >= 5) || (boletos4meses >= 15)) { p4 += 2; } } }

                    // Não confirmados
                    //if (naoconfirmados >= 30) { p5 += 2; } else { if (naoconfirmados >= 22) { p5 += 1; } }

                    // Abertura de matrícula
                    if (tempo_matricula <= 12) { p6 += 12; } else { if (tempo_matricula <= 24) { p6 += 8; } else { if (tempo_matricula > 24) { p6 += 4; } } }

                    pontos += p1 + p2 + p3 + p4 + p5 + p6;

                    analise.Add(new TurmasDashboardAnalise(titulo, codigo, tempo_matricula, confirmados, confirmadosmes, confirmados4meses, naoconfirmados, naoconfirmadosmes, naoconfirmados4meses, boletosmes, boletos4meses, pontos, p1, p2, p3, p4, p5, p6, destaques, datainicio, farao, dataconfirmado));
                }
                reader.Close();
                session.Close();

                return analise;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<TurmasDashboardAnalise> AnaliseConfirmacaoConf(int turma = 0)
        {
            try
            {
                string titulo;
                int codigo;
                int tempo_matricula;
                int confirmados;
                int confirmadosmes;
                int confirmados4meses;
                int naoconfirmados;
                int naoconfirmadosmes;
                int naoconfirmados4meses;
                int boletosmes;
                int boletos4meses;
                int pontos;
                int destaques;
                int farao;
                DateTime datainicio;
                DateTime dataconfirmado;
                int p1, p2, p3, p4, p5, p6;

                List<TurmasDashboardAnalise> analise = new List<TurmasDashboardAnalise>();

                string qry = "";
                qry = "SELECT ";
                qry += "C.titulo1, C.titulo, C.codigo, DATEDIFF(MONTH, C.ativo_data_abertura_matricula, GETDATE()) AS tempo_matricula, ISNULL(C.data_inicio, '1900-01-01') AS data_inicio, ";
                qry += "    ISNULL((SELECT MAX(A.adesao) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2'),'1900-01-01') AS data_confirmado, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2') AS confirmados, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -1, GETDATE())) as confirmadosmes, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN(SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -4, GETDATE())) as confirmados4meses, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND A.data >= DATEADD(MONTH, -1, GETDATE())) as naoconfirmadosmes, ";
                qry += "    (SELECT COUNT(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND A.data >= DATEADD(MONTH, -4, GETDATE())) as naoconfirmados4meses, ";
                qry += "    (SELECT COUNT(*) as total from TIMELINE_EVENTOS_DESTAQUE WHERE idcurso = C.codigo and YEAR(dtfim) = 1900) as destaque, ";
                qry += "    (select count(*) as total from alunos_confirmacao a inner join aluno_curso ac on ac.codigo = a.idaluno_curso where ac.curso = c.codigo and datediff(day, a.dtconfirmacao, getdate()) <= 15) as farao ";
                qry += "FROM CURSO C ";
                qry += "WHERE C.codigo > 0 AND(C.visualiza_site = '1' or C.tipo = 3) and C.inicio_confirmado = 1 and C.tipo in (0, 1) ";
                if (turma != 0)
                {
                    qry += " AND C.codigo = " + turma + " ";
                }
                qry += "ORDER BY C.titulo1";
                DBSession session = new DBSession();
                Query quey = session.CreateQuery(qry);
                //Query quey = session.CreateQuery(@"SELECT 
	               // C.titulo1, C.titulo, C.codigo, DATEDIFF(DAY, C.dtaberturainicial, GETDATE()) AS tempo_matricula,
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2') AS confirmados,
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -1, GETDATE())) as confirmadosmes,
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno NOT IN (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) AND A.curso = C.codigo AND A.situacao = '2' AND A.data >= DATEADD(MONTH, -4, GETDATE())) as confirmados4meses,
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900) as naoconfirmados,
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900 AND Year(isnull(email_impressao_boleto, '1900-01-01')) = 1900 AND A.data >= DATEADD(MONTH, -1, GETDATE())) as naoconfirmadosmes,	
	               // (SELECT count(A.codigo) FROM ALUNO_CURSO A WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND A.situacao = 0 AND Year(isnull(nao_fara_o_curso, '1900-01-01')) = 1900 AND Year(isnull(email_impressao_boleto, '1900-01-01')) = 1900 AND A.data >= DATEADD(MONTH, -4, GETDATE())) as naoconfirmados4meses,
	               // (SELECT count(ACS.aluno_curso) FROM ALUNO_CURSO A INNER JOIN ALUNO_CURSO_STATUS ACS ON ACS.aluno_curso = A.codigo WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND ACS.status = 3 AND ACS.dtstatus >= DATEADD(MONTH, -1, GETDATE())) AS boletosmes,
	               // (SELECT count(ACS.aluno_curso) FROM ALUNO_CURSO A INNER JOIN ALUNO_CURSO_STATUS ACS ON ACS.aluno_curso = A.codigo WHERE A.aluno not in (SELECT idaluno FROM TIMELINE_USUARIOS WHERE flignorar = 1) and A.curso = C.codigo AND ACS.status = 3 AND ACS.dtstatus >= DATEADD(MONTH, -4, GETDATE())) AS boletos4meses
                //FROM CURSO C
                //WHERE C.codigo > 0 AND (C.visualiza_site = '1' or C.tipo = 3) and C.inicio_confirmado = 0 and C.tipo in (0,1)
                //ORDER BY C.titulo1
                //");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    titulo = Convert.ToString(reader["titulo1"]);
                    codigo = Convert.ToInt32(reader["codigo"]);
                    tempo_matricula = Convert.ToInt32(reader["tempo_matricula"]);
                    confirmados = Convert.ToInt32(reader["confirmados"]);
                    confirmadosmes = Convert.ToInt32(reader["confirmadosmes"]);
                    confirmados4meses = Convert.ToInt32(reader["confirmados4meses"]);
                    //naoconfirmados = Convert.ToInt32(reader["naoconfirmados"]);                    
                    naoconfirmadosmes = Convert.ToInt32(reader["naoconfirmadosmes"]);
                    naoconfirmados4meses = Convert.ToInt32(reader["naoconfirmados4meses"]);
                    //boletosmes = Convert.ToInt32(reader["boletosmes"]);
                    //boletos4meses = Convert.ToInt32(reader["boletos4meses"]);
                    pontos = 0;
                    destaques = Convert.ToInt32(reader["destaque"]);
                    datainicio = Convert.ToDateTime(reader["data_inicio"]);
                    dataconfirmado = Convert.ToDateTime(reader["data_confirmado"]);
                    farao = Convert.ToInt32(reader["farao"]);
                    p1 = 0;
                    p2 = 0;
                    p3 = 0;
                    p4 = 0;
                    p5 = 0;
                    p6 = 0;

                    naoconfirmados = 0;
                    boletosmes = 0;
                    boletos4meses = 0;

                    // Alunos confirmados
                    if (confirmados >= 24) { p1 += 12; } else { if (confirmados >= 20) { p1 += 8; } else { if (confirmados >= 16) { p1 += 4; } } }

                    // Taxa de crescimento de matrículas feitas
                    if ((confirmadosmes >= 8) || (confirmados4meses >= 24)) { p2 += 10; } else { if ((confirmadosmes >= 6) || (confirmados4meses >= 18)) { p2 += 6; } else { if ((confirmadosmes >= 3) || (confirmados4meses >= 9)) { p2 += 2; } } }

                    // Taxa de crescimento de não confirmados
                    if ((naoconfirmadosmes >= 8) || (naoconfirmados4meses >= 24)) { p3 += 3; } else { if ((naoconfirmadosmes >= 6) || (naoconfirmados4meses >= 18)) { p3 += 2; } else { if ((naoconfirmadosmes >= 3) || (naoconfirmados4meses >= 9)) { p3 += 1; } } }

                    // Boletos enviados via solicitação
                    //if ((boletosmes >= 9) || (boletos4meses >= 30)) { p4 += 6; } else { if ((boletosmes >= 7) || (boletos4meses >= 22)) { p4 += 4; } else { if ((boletosmes >= 5) || (boletos4meses >= 15)) { p4 += 2; } } }

                    // Não confirmados
                    //if (naoconfirmados >= 30) { p5 += 2; } else { if (naoconfirmados >= 22) { p5 += 1; } }

                    // Abertura de matrícula
                    if (tempo_matricula <= 12) { p6 += 12; } else { if (tempo_matricula <= 24 ) { p6 += 8; } else { if (tempo_matricula > 24) { p6 += 4; } } }

                    pontos += p1 + p2 + p3 + p4 + p5 + p6;

                    analise.Add(new TurmasDashboardAnalise(titulo, codigo, tempo_matricula, confirmados, confirmadosmes, confirmados4meses, naoconfirmados, naoconfirmadosmes, naoconfirmados4meses, boletosmes, boletos4meses, pontos, p1, p2, p3, p4, p5, p6, destaques, datainicio, farao, dataconfirmado));
                }
                reader.Close();
                session.Close();

                return analise;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
