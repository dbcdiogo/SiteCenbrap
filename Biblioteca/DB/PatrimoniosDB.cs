using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class PatrimoniosDB
    {
        public int Salvar(Patrimonios variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Patrimonios (idcategoria, iddepartamento, idsituacao, txdescricao, nrvalor, dtcompra, txobservacoes, idlocal, idcomprador, nrpatrimonio, qtdade, txnrserie, idpatrimoniovinc) output INSERTED.idpatrimonio VALUES (@idcategoria, @iddepartamento, @idsituacao, @txdescricao, @nrvalor, @dtcompra, @txobservacoes, @idlocal, @idcomprador, @nrpatrimonio, @qtdade, @txnrserie, @idpatrimoniovinc) ");
                query.SetParameter("idcategoria", variavel.idcategoria);
                query.SetParameter("iddepartamento", variavel.iddepartamento);
                query.SetParameter("idsituacao", variavel.idsituacao);
                query.SetParameter("txdescricao", variavel.txdescricao);
                query.SetParameter("nrvalor", variavel.nrvalor);
                query.SetParameter("dtcompra", variavel.dtcompra);
                query.SetParameter("txobservacoes", variavel.txobservacoes);
                query.SetParameter("idlocal", variavel.idlocal);
                query.SetParameter("idcomprador", variavel.idcomprador);
                query.SetParameter("nrpatrimonio", variavel.nrpatrimonio);
                query.SetParameter("qtdade", variavel.qtdade);
                query.SetParameter("txnrserie", variavel.txnrserie);
                query.SetParameter("idpatrimoniovinc", variavel.idpatrimoniovinc);
                id = query.ExecuteScalar();
                session.Close();
                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Patrimonios variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Patrimonios SET idcategoria = @idcategoria, iddepartamento = @iddepartamento, idsituacao = @idsituacao, txdescricao = @txdescricao, nrvalor = @nrvalor, dtcompra = @dtcompra, txobservacoes = @txobservacoes, idlocal = @idlocal, idcomprador = @idcomprador, nrpatrimonio = @nrpatrimonio, qtdade = @qtdade, txnrserie = @txnrserie, idpatrimoniovinc = @idpatrimoniovinc WHERE idpatrimonio = @idpatrimonio");
                query.SetParameter("idpatrimonio", variavel.idpatrimonio);
                query.SetParameter("idcategoria", variavel.idcategoria);
                query.SetParameter("iddepartamento", variavel.iddepartamento);
                query.SetParameter("idsituacao", variavel.idsituacao);
                query.SetParameter("txdescricao", variavel.txdescricao);
                query.SetParameter("nrvalor", variavel.nrvalor);
                query.SetParameter("dtcompra", variavel.dtcompra);
                query.SetParameter("txobservacoes", variavel.txobservacoes);
                query.SetParameter("idlocal", variavel.idlocal);
                query.SetParameter("idcomprador", variavel.idcomprador);
                query.SetParameter("nrpatrimonio", variavel.nrpatrimonio);
                query.SetParameter("qtdade", variavel.qtdade);
                query.SetParameter("txnrserie", variavel.txnrserie);
                query.SetParameter("idpatrimoniovinc", variavel.idpatrimoniovinc);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Patrimonios variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Patrimonios WHERE idpatrimonio = @idpatrimonio");
                query.SetParameter("idpatrimonio", variavel.idpatrimonio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Patrimonios Buscar(int idpatrimonio)
        {
            try
            {
                Patrimonios patrimonio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Patrimonios WHERE idpatrimonio = @idpatrimonio");
                quey.SetParameter("idpatrimonio", idpatrimonio);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    patrimonio = new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idcategoria"]), Convert.ToInt32(reader["iddepartamento"]), Convert.ToInt32(reader["idsituacao"]), Convert.ToString(reader["txdescricao"]), Convert.ToDecimal(reader["nrvalor"]), Convert.ToDateTime(reader["dtcompra"]), Convert.ToString(reader["txobservacoes"]), Convert.ToInt32(reader["idlocal"]), Convert.ToInt32(reader["idcomprador"]), Convert.ToInt32(reader["nrpatrimonio"]), Convert.ToInt32(reader["qtdade"]), Convert.ToString(reader["txnrserie"]), Convert.ToString(reader["idpatrimoniovinc"]));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Patrimonios Buscar(string txdescricao)
        {
            try
            {
                Patrimonios patrimonio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Patrimonios WHERE txdescricao like '%" + txdescricao.Replace(" ", "%") + "%'");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    patrimonio = new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idcategoria"]), Convert.ToInt32(reader["iddepartamento"]), Convert.ToInt32(reader["idsituacao"]), Convert.ToString(reader["txdescricao"]), Convert.ToDecimal(reader["nrvalor"]), Convert.ToDateTime(reader["dtcompra"]), Convert.ToString(reader["txobservacoes"]), Convert.ToInt32(reader["idlocal"]), Convert.ToInt32(reader["idcomprador"]), Convert.ToInt32(reader["nrpatrimonio"]), Convert.ToInt32(reader["qtdade"]), Convert.ToString(reader["txnrserie"]), Convert.ToString(reader["idpatrimoniovinc"]));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Patrimonios> Listar(int pagina = 1)
        {
            try
            {
                List<Patrimonios> patrimonio = new List<Patrimonios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Patrimonios ORDER BY txdescricao OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idcategoria"]), Convert.ToInt32(reader["iddepartamento"]), Convert.ToInt32(reader["idsituacao"]), Convert.ToString(reader["txdescricao"]), Convert.ToDecimal(reader["nrvalor"]), Convert.ToDateTime(reader["dtcompra"]), Convert.ToString(reader["txobservacoes"]), Convert.ToInt32(reader["idlocal"]), Convert.ToInt32(reader["idcomprador"]), Convert.ToInt32(reader["nrpatrimonio"]), Convert.ToInt32(reader["qtdade"]), Convert.ToString(reader["txnrserie"]), Convert.ToString(reader["idpatrimoniovinc"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Patrimonios> Listar(int pagina = 1, string txdescricao = "", int idcategoria = 0, int iddepartamento = 0)
        {
            try
            {
                List<Patrimonios> patrimonio = new List<Patrimonios>();

                string qry = "";

                qry += "SELECT * FROM Patrimonios WHERE 1 = 1 ";
                if (txdescricao != "")
                {
                    qry += "and txdescricao like '%" + txdescricao.Replace(" ", "%") + "%' or nrpatrimonio like '%" + txdescricao.Replace(" ", "%") + "%' or txnrserie like '%" + txdescricao.Replace(" ", "%") + "%' ";
                }
                if (idcategoria > 0)
                {
                    qry += "and idcategoria = " + idcategoria + " ";
                }
                if (iddepartamento > 0)
                {
                    qry += "and iddepartamento = " + iddepartamento + " ";
                }
                qry += "ORDER BY txdescricao OFFSET 10 * (" + pagina + " - 1) ROWS FETCH NEXT 10 ROWS ONLY";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(qry);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idcategoria"]), Convert.ToInt32(reader["iddepartamento"]), Convert.ToInt32(reader["idsituacao"]), Convert.ToString(reader["txdescricao"]), Convert.ToDecimal(reader["nrvalor"]), Convert.ToDateTime(reader["dtcompra"]), Convert.ToString(reader["txobservacoes"]), Convert.ToInt32(reader["idlocal"]), Convert.ToInt32(reader["idcomprador"]), Convert.ToInt32(reader["nrpatrimonio"]), Convert.ToInt32(reader["qtdade"]), Convert.ToString(reader["txnrserie"]), Convert.ToString(reader["idpatrimoniovinc"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Patrimonios BuscarResumido(int idpatrimonio)
        {
            try
            {
                Patrimonios patrimonio = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Patrimonios WHERE idpatrimonio = @idpatrimonio");
                quey.SetParameter("idpatrimonio", idpatrimonio);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    patrimonio = new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToString(reader["txdescricao"]), Convert.ToInt32(reader["nrpatrimonio"]));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Patrimonios> Listar(string txdescricao = "")
        {
            try
            {
                List<Patrimonios> patrimonio = new List<Patrimonios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Patrimonios WHERE txdescricao like '%" + txdescricao.Replace(" ", "%") + "%' or nrpatrimonio like '%" + txdescricao.Replace(" ", "%") + "%' or txnrserie like '%" + txdescricao.Replace(" ", "%") + "%' ORDER BY txdescricao");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToString(reader["txdescricao"]), Convert.ToInt32(reader["nrpatrimonio"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Patrimonios> BuscarVinculados(int idpatrimonio = 0)
        {
            try
            {
                List<Patrimonios> patrimonio = new List<Patrimonios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM patrimonios WHERE idpatrimonio IN (SELECT * FROM CSVToTable((select idpatrimoniovinc from patrimonios where idpatrimonio = @idpatrimonio))) order by nrpatrimonio");
                quey.SetParameter("idpatrimonio", idpatrimonio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new Patrimonios(Convert.ToInt32(reader["idpatrimonio"]), Convert.ToString(reader["txdescricao"]), Convert.ToInt32(reader["nrpatrimonio"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Patrimonios");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string txdescricao = "", int idcategoria = 0, int iddepartamento = 0)
        {
            int r = 0;
            string qry = "";

            qry += "SELECT count(*) as total FROM Patrimonios WHERE 1 = 1 ";
            if (txdescricao != "") {
                qry += "and txdescricao like '%" + txdescricao.Replace(" ", "%") + "%' or nrpatrimonio like '%" + txdescricao.Replace(" ", "%") + "%' or txnrserie like '%" + txdescricao.Replace(" ", "%") + "%' ";
            }
            if (idcategoria > 0) {
                qry += "and idcategoria = " + idcategoria + " ";
            }
            if (iddepartamento > 0) {
                qry += "and iddepartamento = " + iddepartamento + " ";
            }

            DBSession session = new DBSession();
            Query quey = session.CreateQuery(qry);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<PatrimonioCategoria> ListarCategorias()
        {
            try
            {
                List<PatrimonioCategoria> categorias = new List<PatrimonioCategoria>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioCategoria ORDER BY txcategoria");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    categorias.Add(new PatrimonioCategoria(Convert.ToInt32(reader["idcategoria"]), Convert.ToString(reader["txcategoria"])));
                }
                reader.Close();
                session.Close();

                return categorias;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PatrimonioSituacao> ListarSituacao()
        {
            try
            {
                List<PatrimonioSituacao> situacao = new List<PatrimonioSituacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioSituacao ORDER BY txsituacao");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    situacao.Add(new PatrimonioSituacao(Convert.ToInt32(reader["idsituacao"]), Convert.ToString(reader["txsituacao"])));
                }
                reader.Close();
                session.Close();

                return situacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PatrimonioLocal> ListarLocal()
        {
            try
            {
                List<PatrimonioLocal> local = new List<PatrimonioLocal>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioLocal ORDER BY txlocal");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    local.Add(new PatrimonioLocal(Convert.ToInt32(reader["idlocal"]), Convert.ToString(reader["txlocal"])));
                }
                reader.Close();
                session.Close();

                return local;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarLocal(PatrimonioLocal variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PatrimonioLocal (txlocal) output INSERTED.idlocal VALUES (@txlocal) ");
                query.SetParameter("txlocal", variavel.txlocal);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarCategoria(PatrimonioCategoria variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PatrimonioCategoria (txcategoria) output INSERTED.idcategoria VALUES (@txcategoria) ");
                query.SetParameter("txcategoria", variavel.txcategoria);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarDepartamento(Departamento variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Departamentos (txdepartamento) output INSERTED.iddepartamento VALUES (@txdepartamento) ");
                query.SetParameter("txdepartamento", variavel.txdepartamento);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarSituacao(PatrimonioSituacao variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PatrimonioSituacao (txsituacao) output INSERTED.idsituacao VALUES (@txsituacao) ");
                query.SetParameter("txsituacao", variavel.txsituacao);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public string BuscarSituacao(int idsituacao)
        {
            try
            {
                string situacao = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioSituacao WHERE idsituacao = @idsituacao");
                quey.SetParameter("idsituacao", idsituacao);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    situacao = Convert.ToString(reader["txsituacao"]);
                }
                reader.Close();
                session.Close();

                return situacao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarCategoria(int idcategoria)
        {
            try
            {
                string categoria = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioCategoria WHERE idcategoria = @idcategoria");
                quey.SetParameter("idcategoria", idcategoria);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    categoria = Convert.ToString(reader["txcategoria"]);
                }
                reader.Close();
                session.Close();

                return categoria;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string BuscarLocal(int idlocal)
        {
            try
            {
                string local = "";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioLocal WHERE idlocal = @idlocal");
                quey.SetParameter("idlocal", idlocal);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    local = Convert.ToString(reader["txlocal"]);
                }
                reader.Close();
                session.Close();

                return local;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int ValidarNumero(int idpatrimonio = 0, string nrpatrimonio = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Patrimonios WHERE nrpatrimonio = @nrpatrimonio AND idpatrimonio <> @idpatrimonio");
            quey.SetParameter("nrpatrimonio", nrpatrimonio);
            quey.SetParameter("idpatrimonio", idpatrimonio);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int NumeroPatrimonio()
        {
            int r = 1;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT (isnull(max(nrpatrimonio),0) + 1) as nrpatrimonio FROM Patrimonios");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["nrpatrimonio"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public void SalvarMovimentacao(PatrimonioMovimentacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO PatrimonioMovimentacao (idpatrimonio, idlocal, dtmovimentacao, idusuario) VALUES (@idpatrimonio, @idlocal, @dtmovimentacao, @idusuario) ");
                query.SetParameter("idpatrimonio", variavel.idpatrimonio);
                query.SetParameter("idlocal", variavel.idlocal);
                query.SetParameter("dtmovimentacao", variavel.dtmovimentacao);
                query.SetParameter("idusuario", variavel.idusuario);
                query.ExecuteQuery();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PatrimonioMovimentacao> ListarMovimentacao(int idpatrimonio = 0)
        {
            try
            {
                List<PatrimonioMovimentacao> patrimonio = new List<PatrimonioMovimentacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM PatrimonioMovimentacao WHERE idpatrimonio = @idpatrimonio order by dtmovimentacao");
                quey.SetParameter("idpatrimonio", idpatrimonio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new PatrimonioMovimentacao(Convert.ToInt32(reader["idmovimentacao"]), Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idlocal"]), Convert.ToDateTime(reader["dtmovimentacao"]), Convert.ToInt32(reader["idusuario"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarAlteraSituacao(PatrimonioAlteraSituacao variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO patrimonioAlteraSituacao (idpatrimonio, idsituacao, dtalteracao, idusuario, nralteracao) VALUES (@idpatrimonio, @idsituacao, @dtalteracao, @idusuario, @nralteracao) ");
                query.SetParameter("idpatrimonio", variavel.idpatrimonio);
                query.SetParameter("idsituacao", variavel.idsituacao);
                query.SetParameter("dtalteracao", variavel.dtalteracao);
                query.SetParameter("idusuario", variavel.idusuario);
                query.SetParameter("nralteracao", variavel.nralteracao);
                query.ExecuteQuery();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<PatrimonioAlteraSituacao> ListarAlteraSituacao(int idpatrimonio = 0)
        {
            try
            {
                List<PatrimonioAlteraSituacao> patrimonio = new List<PatrimonioAlteraSituacao>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM patrimonioAlteraSituacao WHERE idpatrimonio = @idpatrimonio order by dtalteracao");
                quey.SetParameter("idpatrimonio", idpatrimonio);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    patrimonio.Add(new PatrimonioAlteraSituacao(Convert.ToInt32(reader["idaltsituacao"]), Convert.ToInt32(reader["idpatrimonio"]), Convert.ToInt32(reader["idsituacao"]), Convert.ToDateTime(reader["dtalteracao"]), Convert.ToInt32(reader["idusuario"]), Convert.ToDecimal(reader["nralteracao"])));
                }
                reader.Close();
                session.Close();

                return patrimonio;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
