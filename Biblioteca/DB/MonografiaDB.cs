using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class MonografiaDB
    {
        public void Salvar(Monografia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia (curso,aluno,data_inicial,nome,email,celular,telefone,msn,problemas,objetivos,metodologia,bibliografia,justificativa,hipotese,data_final,nota,arquivo,obs,parte1,parte2,parte3,problemas_corrigido,objetivos_corrigido,metodologia_corrigido,bibliografia_corrigido,justificativa_corrigido,hipotese_corrigido,recados,conteudo,formatacao,pago) VALUES (@curso,@aluno,@data_inicial,@nome,@email,@celular,@telefone,@msn,@problemas,@objetivos,@metodologia,@bibliografia,@justificativa,@hipotese,@data_final,@nota,@arquivo,@obs,@parte1,@parte2,@parte3,@problemas_corrigido,@objetivos_corrigido,@metodologia_corrigido,@bibliografia_corrigido,@justificativa_corrigido,@hipotese_corrigido,@recados,@conteudo,@formatacao,@pago) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data_inicial", variavel.data_inicial)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("msn", variavel.msn)
                    .SetParameter("problemas", variavel.problemas)
                    .SetParameter("objetivos", variavel.objetivos)
                    .SetParameter("metodologia", variavel.metodologia)
                    .SetParameter("bibliografia", variavel.bibliografia)
                    .SetParameter("justificativa", variavel.justificativa)
                    .SetParameter("hipotese", variavel.hipotese)
                    .SetParameter("data_final", variavel.data_final)
                    .SetParameter("nota", variavel.nota)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("parte1", variavel.parte1)
                    .SetParameter("parte2", variavel.parte2)
                    .SetParameter("parte3", variavel.parte3)
                    .SetParameter("problemas_corrigido", variavel.problemas_corrigido)
                    .SetParameter("objetivos_corrigido", variavel.objetivos_corrigido)
                    .SetParameter("metodologia_corrigido", variavel.metodologia_corrigido)
                    .SetParameter("bibliografia_corrigido", variavel.bibliografia_corrigido)
                    .SetParameter("justificativa_corrigido", variavel.justificativa_corrigido)
                    .SetParameter("hipotese_corrigido", variavel.hipotese_corrigido)
                    .SetParameter("recados", variavel.recados)
                    .SetParameter("conteudo", variavel.conteudo)
                    .SetParameter("formatacao", variavel.formatacao)
                    .SetParameter("pago", variavel.pago);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Monografia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Monografia (curso,aluno,data_inicial,nome,email,celular,telefone,msn,problemas,objetivos,metodologia,bibliografia,justificativa,hipotese,data_final,nota,arquivo,obs,parte1,parte2,parte3,problemas_corrigido,objetivos_corrigido,metodologia_corrigido,bibliografia_corrigido,justificativa_corrigido,hipotese_corrigido,recados,conteudo,formatacao,pago) output INSERTED.codigo VALUES (@curso,@aluno,@data_inicial,@nome,@email,@celular,@telefone,@msn,@problemas,@objetivos,@metodologia,@bibliografia,@justificativa,@hipotese,@data_final,@nota,@arquivo,@obs,@parte1,@parte2,@parte3,@problemas_corrigido,@objetivos_corrigido,@metodologia_corrigido,@bibliografia_corrigido,@justificativa_corrigido,@hipotese_corrigido,@recados,@conteudo,@formatacao,@pago) ");
                query.SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data_inicial", variavel.data_inicial)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("msn", variavel.msn)
                    .SetParameter("problemas", variavel.problemas)
                    .SetParameter("objetivos", variavel.objetivos)
                    .SetParameter("metodologia", variavel.metodologia)
                    .SetParameter("bibliografia", variavel.bibliografia)
                    .SetParameter("justificativa", variavel.justificativa)
                    .SetParameter("hipotese", variavel.hipotese)
                    .SetParameter("data_final", variavel.data_final)
                    .SetParameter("nota", variavel.nota)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("parte1", variavel.parte1)
                    .SetParameter("parte2", variavel.parte2)
                    .SetParameter("parte3", variavel.parte3)
                    .SetParameter("problemas_corrigido", variavel.problemas_corrigido)
                    .SetParameter("objetivos_corrigido", variavel.objetivos_corrigido)
                    .SetParameter("metodologia_corrigido", variavel.metodologia_corrigido)
                    .SetParameter("bibliografia_corrigido", variavel.bibliografia_corrigido)
                    .SetParameter("justificativa_corrigido", variavel.justificativa_corrigido)
                    .SetParameter("hipotese_corrigido", variavel.hipotese_corrigido)
                    .SetParameter("recados", variavel.recados)
                    .SetParameter("conteudo", variavel.conteudo)
                    .SetParameter("formatacao", variavel.formatacao)
                    .SetParameter("pago", variavel.pago);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Monografia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE monografia SET curso = @curso, aluno = @aluno, data_inicial = @data_inicial, nome = @nome, email = @email, celular = @celular, telefone = @telefone, msn = @msn, problemas = @problemas, objetivos = @objetivos, metodologia = @metodologia, bibliografia = @bibliografia, justificativa = @justificativa, hipotese = @hipotese, data_final = @data_final, nota = @nota, arquivo = @arquivo, obs = @obs, parte1 = @parte1, parte2 = @parte2, parte3 = @parte3, problemas_corrigido = @problemas_corrigido, objetivos_corrigido = @objetivos_corrigido, metodologia_corrigido = @metodologia_corrigido, bibliografia_corrigido = @bibliografia_corrigido, justificativa_corrigido = @justificativa_corrigido, hipotese_corrigido = @hipotese_corrigido, recados = @recados, conteudo = @conteudo, formatacao = @formatacao, pago = @pago WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo)
                    .SetParameter("curso", variavel.curso.codigo)
                    .SetParameter("aluno", variavel.aluno.codigo)
                    .SetParameter("data_inicial", variavel.data_inicial)
                    .SetParameter("nome", variavel.nome)
                    .SetParameter("email", variavel.email)
                    .SetParameter("celular", variavel.celular)
                    .SetParameter("telefone", variavel.telefone)
                    .SetParameter("msn", variavel.msn)
                    .SetParameter("problemas", variavel.problemas)
                    .SetParameter("objetivos", variavel.objetivos)
                    .SetParameter("metodologia", variavel.metodologia)
                    .SetParameter("bibliografia", variavel.bibliografia)
                    .SetParameter("justificativa", variavel.justificativa)
                    .SetParameter("hipotese", variavel.hipotese)
                    .SetParameter("data_final", variavel.data_final)
                    .SetParameter("nota", variavel.nota)
                    .SetParameter("arquivo", variavel.arquivo)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("parte1", variavel.parte1)
                    .SetParameter("parte2", variavel.parte2)
                    .SetParameter("parte3", variavel.parte3)
                    .SetParameter("problemas_corrigido", variavel.problemas_corrigido)
                    .SetParameter("objetivos_corrigido", variavel.objetivos_corrigido)
                    .SetParameter("metodologia_corrigido", variavel.metodologia_corrigido)
                    .SetParameter("bibliografia_corrigido", variavel.bibliografia_corrigido)
                    .SetParameter("justificativa_corrigido", variavel.justificativa_corrigido)
                    .SetParameter("hipotese_corrigido", variavel.hipotese_corrigido)
                    .SetParameter("recados", variavel.recados)
                    .SetParameter("conteudo", variavel.conteudo)
                    .SetParameter("formatacao", variavel.formatacao)
                    .SetParameter("pago", variavel.pago);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Monografia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM monografia WHERE codigo = @codigo");
                query.SetParameter("codigo", variavel.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Monografia Buscar(int codigo)
        {
            try
            {
                Monografia retorno = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(data_inicial,  '1900-01-01') AS data_inicial, isnull(nome,  '') AS nome, isnull(email,  '') AS email, isnull(celular,  '') AS celular, isnull(telefone,  '') AS telefone, isnull(msn,  '') AS msn, isnull(problemas,  '') AS problemas, isnull(objetivos,  '') AS objetivos, isnull(metodologia,  '') AS metodologia, isnull(bibliografia,  '') AS bibliografia, isnull(justificativa,  '') AS justificativa, isnull(hipotese,  '') AS hipotese, isnull(data_final,  '1900-01-01') AS data_final, isnull(nota,  0) AS nota, isnull(arquivo,  '') AS arquivo, isnull(obs,  '') AS obs, isnull(parte1,  0) AS parte1, isnull(parte2,  0) AS parte2, isnull(parte3,  0) AS parte3, isnull(problemas_corrigido,  '') AS problemas_corrigido, isnull(objetivos_corrigido,  '') AS objetivos_corrigido, isnull(metodologia_corrigido,  '') AS metodologia_corrigido, isnull(bibliografia_corrigido,  '') AS bibliografia_corrigido, isnull(justificativa_corrigido,  '') AS justificativa_corrigido, isnull(hipotese_corrigido,  '') AS hipotese_corrigido, isnull(recados,  '') AS recados, isnull(conteudo,  0) AS conteudo, isnull(formatacao,  0) AS formatacao, isnull(pago,  0) AS pago FROM monografia WHERE codigo = @codigo");
                query.SetParameter("@codigo", codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Monografia(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data_inicial"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["msn"]), Convert.ToString(reader["problemas"]), Convert.ToString(reader["objetivos"]), Convert.ToString(reader["metodologia"]), Convert.ToString(reader["bibliografia"]), Convert.ToString(reader["justificativa"]), Convert.ToString(reader["hipotese"]), Convert.ToDateTime(reader["data_final"]), Convert.ToDouble(reader["nota"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["parte1"]), Convert.ToInt32(reader["parte2"]), Convert.ToInt32(reader["parte3"]), Convert.ToString(reader["problemas_corrigido"]), Convert.ToString(reader["objetivos_corrigido"]), Convert.ToString(reader["metodologia_corrigido"]), Convert.ToString(reader["bibliografia_corrigido"]), Convert.ToString(reader["justificativa_corrigido"]), Convert.ToString(reader["hipotese_corrigido"]), Convert.ToString(reader["recados"]), Convert.ToInt32(reader["conteudo"]), Convert.ToInt32(reader["formatacao"]), Convert.ToInt32(reader["pago"]));
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

        public Monografia Buscar(int aluno, int curso)
        {
            try
            {
                Monografia retorno = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(data_inicial,  '1900-01-01') AS data_inicial, isnull(nome,  '') AS nome, isnull(email,  '') AS email, isnull(celular,  '') AS celular, isnull(telefone,  '') AS telefone, isnull(msn,  '') AS msn, isnull(problemas,  '') AS problemas, isnull(objetivos,  '') AS objetivos, isnull(metodologia,  '') AS metodologia, isnull(bibliografia,  '') AS bibliografia, isnull(justificativa,  '') AS justificativa, isnull(hipotese,  '') AS hipotese, isnull(data_final,  '1900-01-01') AS data_final, isnull(nota,  0) AS nota, isnull(arquivo,  '') AS arquivo, isnull(obs,  '') AS obs, isnull(parte1,  0) AS parte1, isnull(parte2,  0) AS parte2, isnull(parte3,  0) AS parte3, isnull(problemas_corrigido,  '') AS problemas_corrigido, isnull(objetivos_corrigido,  '') AS objetivos_corrigido, isnull(metodologia_corrigido,  '') AS metodologia_corrigido, isnull(bibliografia_corrigido,  '') AS bibliografia_corrigido, isnull(justificativa_corrigido,  '') AS justificativa_corrigido, isnull(hipotese_corrigido,  '') AS hipotese_corrigido, isnull(recados,  '') AS recados, isnull(conteudo,  0) AS conteudo, isnull(formatacao,  0) AS formatacao, isnull(pago,  0) AS pago FROM monografia WHERE aluno = @aluno AND curso = @curso");
                query.SetParameter("@aluno", aluno)
                    .SetParameter("@curso", curso);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Monografia(Convert.ToInt32(reader["codigo"]), new Curso() { codigo = Convert.ToInt32(reader["curso"]) }, new Aluno() { codigo = Convert.ToInt32(reader["aluno"]) }, Convert.ToDateTime(reader["data_inicial"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["msn"]), Convert.ToString(reader["problemas"]), Convert.ToString(reader["objetivos"]), Convert.ToString(reader["metodologia"]), Convert.ToString(reader["bibliografia"]), Convert.ToString(reader["justificativa"]), Convert.ToString(reader["hipotese"]), Convert.ToDateTime(reader["data_final"]), Convert.ToDouble(reader["nota"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["parte1"]), Convert.ToInt32(reader["parte2"]), Convert.ToInt32(reader["parte3"]), Convert.ToString(reader["problemas_corrigido"]), Convert.ToString(reader["objetivos_corrigido"]), Convert.ToString(reader["metodologia_corrigido"]), Convert.ToString(reader["bibliografia_corrigido"]), Convert.ToString(reader["justificativa_corrigido"]), Convert.ToString(reader["hipotese_corrigido"]), Convert.ToString(reader["recados"]), Convert.ToInt32(reader["conteudo"]), Convert.ToInt32(reader["formatacao"]), Convert.ToInt32(reader["pago"]));
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

        public Monografia Buscar(Aluno aluno, Curso curso)
        {
            try
            {
                Monografia retorno = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(codigo, 0) AS codigo, isnull(curso,   0) AS curso, isnull(aluno,   0) AS aluno, isnull(data_inicial,  '1900-01-01') AS data_inicial, isnull(nome,  '') AS nome, isnull(email,  '') AS email, isnull(celular,  '') AS celular, isnull(telefone,  '') AS telefone, isnull(msn,  '') AS msn, isnull(problemas,  '') AS problemas, isnull(objetivos,  '') AS objetivos, isnull(metodologia,  '') AS metodologia, isnull(bibliografia,  '') AS bibliografia, isnull(justificativa,  '') AS justificativa, isnull(hipotese,  '') AS hipotese, isnull(data_final,  '1900-01-01') AS data_final, isnull(nota,  0) AS nota, isnull(arquivo,  '') AS arquivo, isnull(obs,  '') AS obs, isnull(parte1,  0) AS parte1, isnull(parte2,  0) AS parte2, isnull(parte3,  0) AS parte3, isnull(problemas_corrigido,  '') AS problemas_corrigido, isnull(objetivos_corrigido,  '') AS objetivos_corrigido, isnull(metodologia_corrigido,  '') AS metodologia_corrigido, isnull(bibliografia_corrigido,  '') AS bibliografia_corrigido, isnull(justificativa_corrigido,  '') AS justificativa_corrigido, isnull(hipotese_corrigido,  '') AS hipotese_corrigido, isnull(recados,  '') AS recados, isnull(conteudo,  0) AS conteudo, isnull(formatacao,  0) AS formatacao, isnull(pago,  0) AS pago FROM monografia WHERE aluno = @aluno AND curso = @curso");
                query.SetParameter("@aluno", aluno.codigo)
                    .SetParameter("@curso", curso.codigo);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Monografia(Convert.ToInt32(reader["codigo"]), curso, aluno, Convert.ToDateTime(reader["data_inicial"]), Convert.ToString(reader["nome"]), Convert.ToString(reader["email"]), Convert.ToString(reader["celular"]), Convert.ToString(reader["telefone"]), Convert.ToString(reader["msn"]), Convert.ToString(reader["problemas"]), Convert.ToString(reader["objetivos"]), Convert.ToString(reader["metodologia"]), Convert.ToString(reader["bibliografia"]), Convert.ToString(reader["justificativa"]), Convert.ToString(reader["hipotese"]), Convert.ToDateTime(reader["data_final"]), Convert.ToDouble(reader["nota"]), Convert.ToString(reader["arquivo"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["parte1"]), Convert.ToInt32(reader["parte2"]), Convert.ToInt32(reader["parte3"]), Convert.ToString(reader["problemas_corrigido"]), Convert.ToString(reader["objetivos_corrigido"]), Convert.ToString(reader["metodologia_corrigido"]), Convert.ToString(reader["bibliografia_corrigido"]), Convert.ToString(reader["justificativa_corrigido"]), Convert.ToString(reader["hipotese_corrigido"]), Convert.ToString(reader["recados"]), Convert.ToInt32(reader["conteudo"]), Convert.ToInt32(reader["formatacao"]), Convert.ToInt32(reader["pago"]));
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
