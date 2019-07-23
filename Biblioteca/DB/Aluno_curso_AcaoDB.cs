using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_curso_AcaoDB
    {
        public int Salvar(Aluno_curso_Acao variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_curso_acoes (aluno_curso, dtacao, txacao, tipo, idusuario, dtretorno, txobs) output INSERTED.idacao values (@aluno_curso, @dtacao, @txacao, @tipo, @idusuario, @dtretorno, @txobs)");
                query.SetParameter("aluno_curso", variavel.aluno_curso);
                query.SetParameter("dtacao", variavel.dtacao);
                query.SetParameter("txacao", variavel.txacao);
                query.SetParameter("tipo", variavel.tipo);
                query.SetParameter("dtretorno", variavel.dtretorno);
                query.SetParameter("txobs", variavel.txobs);
                query.SetParameter("idusuario", variavel.idusuario);
                id = query.ExecuteScalar();
                session.Close();
                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Aluno_curso_Acao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE aluno_curso_acoes SET dtacao = @dtacao, txacao = @txacao, dtretorno = @dtretorno, txobs = @txobs WHERE idacao = @idacao and aluno_curso = @aluno_curso");
                query.SetParameter("idacao", variavel.idacao)
                    .SetParameter("aluno_curso", variavel.aluno_curso)
                    .SetParameter("dtacao", variavel.dtacao)
                    .SetParameter("dtretorno", variavel.dtretorno)
                    .SetParameter("txobs", variavel.txobs)
                    .SetParameter("txacao", variavel.txacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(int idacao)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_curso_acoes WHERE idacao = @idacao");
                query.SetParameter("idacao", idacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Aluno_curso_Acao Buscar(int idacao)
        {
            try
            {
                Aluno_curso_Acao acao = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from aluno_curso_acoes where idacao = @idacao");
                quey.SetParameter("idacao", idacao);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    acao = new Aluno_curso_Acao(Convert.ToInt32(reader["idacao"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToString(reader["txacao"]), Convert.ToString(reader["tipo"]), Convert.ToDateTime(reader["dtacao"]), Convert.ToInt32(reader["idusuario"]), Convert.ToDateTime(reader["dtretorno"]), Convert.ToString(reader["txobs"]));
                }
                reader.Close();
                session.Close();

                return acao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        public List<Aluno_curso_Acao> Lista(int aluno_curso)
        {
            try
            {
                List<Aluno_curso_Acao> acoes = new List<Aluno_curso_Acao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select idacao, aluno_curso, dtacao, txacao, tipo, idusuario, txobs, isnull(dtretorno, '1900-01-01') as dtretorno from aluno_curso_acoes WHERE aluno_curso = @aluno_curso order by dtacao desc");
                quey.SetParameter("aluno_curso", aluno_curso);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    acoes.Add(new Aluno_curso_Acao(Convert.ToInt32(reader["idacao"]), Convert.ToInt32(reader["aluno_curso"]), Convert.ToString(reader["txacao"]), Convert.ToString(reader["tipo"]), Convert.ToDateTime(reader["dtacao"]), Convert.ToInt32(reader["idusuario"]), Convert.ToDateTime(reader["dtretorno"]), Convert.ToString(reader["txobs"])));
                }

                reader.Close();
                session.Close();

                return acoes;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirUsuarios(int idacao)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM aluno_curso_acoes_usuarios WHERE idacao = @idacao");
                query.SetParameter("idacao", idacao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AdicionarUsuarios(int idacao, int idusuario)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_curso_acoes_usuarios (idacao, idusuario) VALUES (@idacao, @idusuario) ");
                query.SetParameter("idacao", idacao);
                query.SetParameter("idusuario", idusuario);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int VerificaUusario(int idacao, int idusuario)
        {
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("select count(*) as total from aluno_curso_acoes_usuarios where idacao = @idacao and idusuario = @idusuario");
            quey.SetParameter("idacao", idacao);
            quey.SetParameter("idusuario", idusuario);
            IDataReader reader = quey.ExecuteQuery();
            int retorno = 0;
            if (reader.Read())
            {
                retorno = Convert.ToInt32(reader["total"]);
            }
            else
            {
                retorno = 0;
            }
            reader.Close();
            session.Close();
            return retorno;
        }

        public List<Aluno_curso_Acao_Usuario> ListarUsuarios(int idacao)
        {
            try
            {
                List<Aluno_curso_Acao_Usuario> usuarios = new List<Aluno_curso_Acao_Usuario>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT a.idacao, a.idusuario, u.txnome from aluno_curso_acoes_usuarios a left join timeline_usuarios u on u.idusuario = a.idusuario where a.idacao = @idacao order by u.txnome");
                quey.SetParameter("idacao", idacao);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    usuarios.Add(new Aluno_curso_Acao_Usuario(Convert.ToInt32(reader["idacao"]), Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txnome"])));
                }
                reader.Close();
                session.Close();

                return usuarios;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
