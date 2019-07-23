using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class InvestimentoDB
    {
        public int SalvarInvestimento(Investimentos variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Investimentos (vlinvestimento, idtipoinvestimento, idtipoperiodo, dtinicio, dtfim, txobs, idusuario, txinvestimento, dtcadastro) output INSERTED.idinvestimento VALUES (@vlinvestimento, @idtipoinvestimento, @idtipoperiodo, @dtinicio, @dtfim, @txobs, @idusuario, @txinvestimento, getdate()) ");
                query.SetParameter("vlinvestimento", variavel.vlinvestimento)
                    .SetParameter("idtipoinvestimento", variavel.idtipoinvestimento)
                    .SetParameter("idtipoperiodo", variavel.idtipoperiodo)
                    .SetParameter("dtinicio", variavel.dtinicio)
                    .SetParameter("dtfim", variavel.dtfim)
                    .SetParameter("txobs", variavel.txobs)
                    .SetParameter("idusuario", variavel.idusuario)
                    .SetParameter("txinvestimento", variavel.txinvestimento);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarInvestimento(Investimentos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Investimentos SET  vlinvestimento = @vlinvestimento, idtipoinvestimento = @idtipoinvestimento, idtipoperiodo = @idtipoperiodo, dtinicio = @dtinicio, dtfim = @dtfim, txobs = @txobs, txinvestimento = @txinvestimento WHERE idinvestimento = @idinvestimento");
                query.SetParameter("vlinvestimento", variavel.vlinvestimento)
                   .SetParameter("idtipoinvestimento", variavel.idtipoinvestimento)
                   .SetParameter("idtipoperiodo", variavel.idtipoperiodo)
                   .SetParameter("dtinicio", variavel.dtinicio)
                   .SetParameter("dtfim", variavel.dtfim)
                   .SetParameter("txobs", variavel.txobs)
                   .SetParameter("idinvestimento", variavel.idinvestimento)
                   .SetParameter("txinvestimento", variavel.txinvestimento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarCursoVinculado(int idturma, int idinvestimento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO investimentos_turmas (idturma, idinvestimento) VALUES (@idturma, @idinvestimento) ");
                query.SetParameter("idinvestimento", idinvestimento)
                .SetParameter("idturma", idturma);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Investimentos BuscarInvestimento(int idinvestimento)
        {
            try
            {
                Investimentos invest = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Investimentos WHERE idinvestimento = @idinvestimento");
                quey.SetParameter("idinvestimento", idinvestimento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    invest = new Investimentos(Convert.ToInt32(reader["idinvestimento"]), Convert.ToDecimal(reader["vlinvestimento"]), Convert.ToInt32(reader["idtipoinvestimento"]), Convert.ToInt32(reader["idtipoperiodo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txobs"]), Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txinvestimento"]));
                }
                reader.Close();
                session.Close();

                return invest;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<InvestimentoTipos> ListarTipos()
        {
            try
            {
                List<InvestimentoTipos> dataLote = new List<InvestimentoTipos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Investimentos_Tipos ORDER BY txtipoinvestimento");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new InvestimentoTipos(Convert.ToInt32(reader["idtipoinvestimento"]), Convert.ToString(reader["txtipoinvestimento"])));
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

        public List<InvestimentoPeriodos> ListarPeriodos()
        {
            try
            {
                List<InvestimentoPeriodos> dataLote = new List<InvestimentoPeriodos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Investimentos_periodos ORDER BY txtipoperiodo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new InvestimentoPeriodos(Convert.ToInt32(reader["idtipoperiodo"]), Convert.ToString(reader["txtipoperiodo"])));
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

        public int SalvarTipo(InvestimentoTipos variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Investimentos_Tipos (txtipoinvestimento) output INSERTED.idtipoinvestimento VALUES (@txtipoinvestimento) ");
                query.SetParameter("txtipoinvestimento", variavel.txtipoinvestimento);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Investimentos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Investimentos_turmas WHERE idinvestimento = @id");
                query.SetParameter("id", variavel.idinvestimento);
                query.ExecuteUpdate();
                session.Close();

                DBSession session2 = new DBSession();
                Query query2 = session2.CreateQuery("DELETE FROM investimentos_acoes WHERE idinvestimento = @id");
                query2.SetParameter("id", variavel.idinvestimento);
                query2.ExecuteUpdate();
                session2.Close();

                DBSession session3 = new DBSession();
                Query query3 = session3.CreateQuery("DELETE FROM investimentos_alteracoes WHERE idinvestimento = @id");
                query3.SetParameter("id", variavel.idinvestimento);
                query3.ExecuteUpdate();
                session3.Close();

                DBSession session4 = new DBSession();
                Query query4 = session4.CreateQuery("DELETE FROM Investimentos WHERE idinvestimento = @id");
                query4.SetParameter("id", variavel.idinvestimento);
                query4.ExecuteUpdate();
                session4.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirCursosVinculados(int idinvestimento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Investimentos_turmas WHERE idinvestimento = @idinvestimento");
                query.SetParameter("idinvestimento", idinvestimento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Investimentos> Listar(int pagina = 1)
        {
            try
            {
                List<Investimentos> dataLote = new List<Investimentos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Investimentos ORDER BY idinvestimento desc OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Investimentos(Convert.ToInt32(reader["idinvestimento"]), Convert.ToDecimal(reader["vlinvestimento"]), Convert.ToInt32(reader["idtipoinvestimento"]), Convert.ToInt32(reader["idtipoperiodo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txobs"]), Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txinvestimento"])));
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

        public List<Investimentos> Listar(int pagina = 1, string descricao = "")
        {
            try
            {
                List<Investimentos> dataLote = new List<Investimentos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Investimentos WHERE txinvestimento like '%" + descricao.Replace(" ", "%") + "%' ORDER BY idinvestimento desc OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Investimentos(Convert.ToInt32(reader["idinvestimento"]), Convert.ToDecimal(reader["vlinvestimento"]), Convert.ToInt32(reader["idtipoinvestimento"]), Convert.ToInt32(reader["idtipoperiodo"]), Convert.ToDateTime(reader["dtinicio"]), Convert.ToDateTime(reader["dtfim"]), Convert.ToString(reader["txobs"]), Convert.ToInt32(reader["idusuario"]), Convert.ToString(reader["txinvestimento"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Investimentos");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string descricao = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Investimentos WHERE txinvestimento like '%" + descricao.Replace(" ", "%") + "%'");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<InvestimentoTurmas> ListarTurmasInvestimento(int idinvestimento = 0)
        {
            try
            {
                List<InvestimentoTurmas> dataLote = new List<InvestimentoTurmas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select it.*, c.titulo1 from investimentos_turmas it inner join curso c on c.codigo = it.idturma where it.idinvestimento = @idinvestimento");
                quey.SetParameter("idinvestimento", idinvestimento);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new InvestimentoTurmas(Convert.ToInt32(reader["idinvestimento"]),  Convert.ToInt32(reader["idturma"]), Convert.ToString(reader["titulo1"])));
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

        public void Pausar(int idinvestimento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO investimentos_acoes (idinvestimento, dtpausa) VALUES (@idinvestimento, getdate()) ");
                query.SetParameter("idinvestimento", idinvestimento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Reativar(int idinvestimento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE investimentos_acoes set dtreativado = getdate() WHERE idinvestimento = @idinvestimento AND dtreativado is null");
                query.SetParameter("idinvestimento", idinvestimento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<InvestimentoAcoes> Alteracoes(int idinvestimento)
        {
            try
            {
                List<InvestimentoAcoes> dataLote = new List<InvestimentoAcoes>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT idinvestimento, dtpausa, isnull(dtreativado, '1900-01-01') as dtreativado FROM investimentos_acoes WHERE idinvestimento = @idinvestimento ORDER BY dtreativado DESC, dtpausa DESC");
                quey.SetParameter("idinvestimento", idinvestimento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    dataLote.Add(new InvestimentoAcoes(Convert.ToInt32(reader["idinvestimento"]), Convert.ToDateTime(reader["dtpausa"]), Convert.ToDateTime(reader["dtreativado"])));
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

        public void Valores(int idinvestimento, decimal valor, DateTime data)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO investimentos_alteracoes (idinvestimento, dtalteracao, vlalteracao) VALUES (@idinvestimento, @dtalteracao, @vlalteracao) ");
                query.SetParameter("idinvestimento", idinvestimento)
                    .SetParameter("vlalteracao", valor)
                    .SetParameter("dtalteracao", data);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<InvestimentoValores> Valores(int idinvestimento = 0)
        {
            try
            {
                List<InvestimentoValores> dataLote = new List<InvestimentoValores>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from investimentos_alteracoes where idinvestimento = @idinvestimento order by dtalteracao");
                quey.SetParameter("idinvestimento", idinvestimento);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new InvestimentoValores(Convert.ToInt32(reader["idinvestimento"]), Convert.ToDateTime(reader["dtalteracao"]), Convert.ToDecimal(reader["vlalteracao"])));
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
    }
}

