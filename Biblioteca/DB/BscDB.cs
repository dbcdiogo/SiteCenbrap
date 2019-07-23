using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class BscDB
    {

        // SALVAR

        public int SalvarPerspectivaRetornar(BSC_Perspectivas variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO BSC_Perspectivas (txperspectiva, nrordem, txcor, txiniciativa) output INSERTED.idperspectiva VALUES (@txperspectiva, @nrordem, @txcor, @txiniciativa)");
                query.SetParameter("txperspectiva", variavel.txperspectiva);
                query.SetParameter("nrordem", variavel.nrordem);
                query.SetParameter("txcor", variavel.txcor);
                query.SetParameter("txiniciativa", variavel.txiniciativa);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarObjetivoRetornar(BSC_Objetivos variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO BSC_Objetivos (idperspectiva, txobjetivo, nrordem) output INSERTED.idobjetivo VALUES (@idperspectiva, @txobjetivo, @nrordem)");
                query.SetParameter("idperspectiva", variavel.idperspectiva);
                query.SetParameter("txobjetivo", variavel.txobjetivo);
                query.SetParameter("nrordem", variavel.nrordem);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int SalvarIndicadorRetornar(BSC_Indicadores variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO BSC_Indicadores (idobjetivo, txindicador, nrordem, txunidade, idcondicao) output INSERTED.idindicador VALUES (@idobjetivo, @txindicador, @nrordem, @txunidade, @idcondicao)");
                query.SetParameter("idobjetivo", variavel.idobjetivo);
                query.SetParameter("txindicador", variavel.txindicador);
                query.SetParameter("nrordem", variavel.nrordem);
                query.SetParameter("txunidade", variavel.txunidade);
                query.SetParameter("idcondicao", variavel.idcondicao);
                id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //public int SalvarKpiRetornar(BSC_Kpis variavel)
        //{
        //    try
        //    {
        //        int id = 0;
        //        DBSession session = new DBSession();
        //        Query query = session.CreateQuery("INSERT INTO BSC_Kpis (idindicador, txkpi, nrordem, txformula, txunidade) output INSERTED.idkpi VALUES (@idindicador, @txkpi, @nrordem, @txformula, @txunidade)");
        //        query.SetParameter("idindicador", variavel.idindicador);
        //        query.SetParameter("txkpi", variavel.txkpi);
        //        query.SetParameter("nrordem", variavel.nrordem);
        //        query.SetParameter("txformula", variavel.txformula);
        //        query.SetParameter("txunidade", variavel.txunidade);
        //        id = query.ExecuteScalar();
        //        session.Close();

        //        return id;
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //}

        public void SalvarMeta(BSC_Metas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO BSC_Indicadores_Metas (idindicador, txano, txvalor) VALUES (@idindicador, @txano, @txvalor)");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("txano", variavel.txano);
                query.SetParameter("txvalor", variavel.txvalor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void SalvarIndicadorValor(BSC_Indicadores_Valor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO BSC_Indicadores_Valores (idindicador, ano, mes, valor) VALUES (@idindicador, @ano, @mes, @valor)");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("ano", variavel.ano);
                query.SetParameter("mes", variavel.mes);
                query.SetParameter("valor", variavel.valor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        // ALTERAR

        public void AlterarPerspectiva(BSC_Perspectivas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE BSC_Perspectivas SET txperspectiva = @txperspectiva, nrordem = @nrordem, txcor = @txcor, txiniciativa = @txiniciativa WHERE idperspectiva = @idperspectiva");
                query.SetParameter("idperspectiva", variavel.idperspectiva);
                query.SetParameter("txperspectiva", variavel.txperspectiva);
                query.SetParameter("nrordem", variavel.nrordem);
                query.SetParameter("txcor", variavel.txcor);
                query.SetParameter("txiniciativa", variavel.txiniciativa);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarObjetivo(BSC_Objetivos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE BSC_Objetivos SET idperspectiva = @idperspectiva, txobjetivo = @txobjetivo, nrordem = @nrordem WHERE idobjetivo = @idobjetivo");
                query.SetParameter("idobjetivo", variavel.idobjetivo);
                query.SetParameter("idperspectiva", variavel.idperspectiva);
                query.SetParameter("txobjetivo", variavel.txobjetivo);
                query.SetParameter("nrordem", variavel.nrordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarIndicador(BSC_Indicadores variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE BSC_Indicadores SET idobjetivo = @idobjetivo, txindicador = @txindicador, nrordem = @nrordem, txunidade = @txunidade, idcondicao = @idcondicao WHERE idindicador = @idindicador");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("idobjetivo", variavel.idobjetivo);
                query.SetParameter("txindicador", variavel.txindicador);
                query.SetParameter("nrordem", variavel.nrordem);
                query.SetParameter("txunidade", variavel.txunidade);
                query.SetParameter("idcondicao", variavel.idcondicao);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        //public void AlterarKpi(BSC_Kpis variavel)
        //{
        //    try
        //    {
        //        DBSession session = new DBSession();
        //        Query query = session.CreateQuery("UPDATE BSC_Kpis SET idindicador = @idindicador, txkpi = @txkpi, nrordem = @nrordem, txformula = @txformula, txunidade = @txunidade WHERE idkpi = @idkpi");
        //        query.SetParameter("idkpi", variavel.idkpi);
        //        query.SetParameter("idindicador", variavel.idindicador);
        //        query.SetParameter("txkpi", variavel.txkpi);
        //        query.SetParameter("nrordem", variavel.nrordem);
        //        query.SetParameter("txformula", variavel.txformula);
        //        query.SetParameter("txunidade", variavel.txunidade);
        //        query.ExecuteUpdate();
        //        session.Close();
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //}

        public void AlterarMeta(BSC_Metas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE BSC_Indicadores_Metas SET txvalor = @txvalor WHERE idindicador = @idindicador AND txano = @txano");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("txano", variavel.txano);
                query.SetParameter("txvalor", variavel.txvalor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarIndicadorValor(BSC_Indicadores_Valor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE BSC_Indicadores_Valores SET valor = @valor WHERE idindicador = @idindicador AND ano = @ano AND mes = @mes");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("ano", variavel.ano);
                query.SetParameter("mes", variavel.mes);
                query.SetParameter("valor", variavel.valor);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        // EXCLUIR

        public void ExcluirPerspectiva(BSC_Perspectivas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Perspectivas WHERE idperspectiva = @codigo");
                query.SetParameter("codigo", variavel.idperspectiva);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirObjetivo(BSC_Objetivos variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Objetivos WHERE idobjetivo = @codigo");
                query.SetParameter("codigo", variavel.idobjetivo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirIndicador(BSC_Indicadores variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Indicadores WHERE idindicador = @codigo");
                query.SetParameter("codigo", variavel.idindicador);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //public void ExcluirKpi(BSC_Kpis variavel)
        //{
        //    try
        //    {
        //        DBSession session = new DBSession();
        //        Query query = session.CreateQuery("DELETE FROM BSC_Kpis WHERE idkpi = @codigo");
        //        query.SetParameter("codigo", variavel.idkpi);
        //        query.ExecuteUpdate();
        //        session.Close();
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //}

        public void ExcluirMetas(int idindicador = 0, string anos = "0")
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Indicadores_Metas WHERE idindicador = " + idindicador + " AND txano NOT IN (" + anos + ")");
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirIndicadoresObj(int idobjetivo = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE from BSC_Indicadores_Metas where idindicador in (select idindicador from bsc_indicadores where idobjetivo = @codigo)");
                query.SetParameter("codigo", idobjetivo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM bsc_indicadores WHERE idobjetivo = @codigo");
                query.SetParameter("codigo", idobjetivo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirObjetivosPers(int idperspectiva = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("delete from BSC_Indicadores_Metas where idindicador in (select idindicador from bsc_indicadores where idobjetivo in (select idobjetivo from BSC_Objetivos where idperspectiva = @codigo))");
                query.SetParameter("codigo", idperspectiva);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM bsc_indicadores WHERE idobjetivo in (select idobjetivo from BSC_Objetivos where idperspectiva = @codigo)");
                query.SetParameter("codigo", idperspectiva);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Objetivos WHERE idperspectiva = @codigo");
                query.SetParameter("codigo", idperspectiva);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirIndicadorValor(BSC_Indicadores_Valor variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM BSC_Indicadores_Valores WHERE idindicador = @idindicador AND ano = @ano AND mes = @mes");
                query.SetParameter("idindicador", variavel.idindicador);
                query.SetParameter("mes", variavel.mes);
                query.SetParameter("ano", variavel.ano);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        // LISTAR

        public List<BSC_Perspectivas> ListarPerspectivas()
        {
            try
            {
                List<BSC_Perspectivas> list = new List<BSC_Perspectivas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Perspectivas ORDER BY nrordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Perspectivas(Convert.ToInt32(reader["idperspectiva"]), Convert.ToString(reader["txperspectiva"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txcor"]), Convert.ToString(reader["txiniciativa"])));
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

        public List<BSC_Objetivos> ListarObjetivos(int idperspectiva = 0)
        {
            try
            {
                List<BSC_Objetivos> list = new List<BSC_Objetivos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Objetivos WHERE idperspectiva = @idperspectiva ORDER BY nrordem");
                quey.SetParameter("idperspectiva", idperspectiva);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Objetivos(Convert.ToInt32(reader["idobjetivo"]), Convert.ToInt32(reader["idperspectiva"]), Convert.ToString(reader["txobjetivo"]), Convert.ToInt32(reader["nrordem"])));
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

        public List<BSC_Indicadores> ListarIndicadores(int idobjetivo = 0)
        {
            try
            {
                List<BSC_Indicadores> list = new List<BSC_Indicadores>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores WHERE idobjetivo = @idobjetivo ORDER BY nrordem");
                quey.SetParameter("idobjetivo", idobjetivo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Indicadores(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["idobjetivo"]), Convert.ToString(reader["txindicador"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txunidade"]), Convert.ToInt32(reader["idcondicao"])));
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

        //public List<BSC_Kpis> ListarKpis(int idindicador = 0)
        //{
        //    try
        //    {
        //        List<BSC_Kpis> list = new List<BSC_Kpis>();

        //        DBSession session = new DBSession();
        //        Query quey = session.CreateQuery("SELECT * FROM BSC_Kpis WHERE idindicador = @idindicador ORDER BY nrordem");
        //        quey.SetParameter("idindicador", idindicador);
        //        IDataReader reader = quey.ExecuteQuery();

        //        while (reader.Read())
        //        {
        //            list.Add(new BSC_Kpis(Convert.ToInt32(reader["idkpi"]), Convert.ToInt32(reader["idindicador"]), Convert.ToString(reader["txkpi"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txformula"]), Convert.ToString(reader["txunidade"])));
        //        }
        //        reader.Close();
        //        session.Close();

        //        return list;
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //}

        public List<BSC_Metas> ListarMetas(int idindicador = 0)
        {
            try
            {
                List<BSC_Metas> list = new List<BSC_Metas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores_Metas WHERE idindicador = @idindicador ORDER BY txano");
                quey.SetParameter("idindicador", idindicador);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Metas(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["txano"]), Convert.ToString(reader["txvalor"])));
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

        public List<BSC_Indicadores_Valor> ListarIndicadorValores(int idindicador = 0)
        {
            try
            {
                List<BSC_Indicadores_Valor> list = new List<BSC_Indicadores_Valor>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores_Valores WHERE idindicador = @idindicador ORDER BY ano");
                quey.SetParameter("idindicador", idindicador);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Indicadores_Valor(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["ano"]), Convert.ToInt32(reader["mes"]), Convert.ToInt32(reader["valor"])));
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

        public List<BSC_Perspectivas> ListarScoreCard()
        {
            try
            {
                List<BSC_Perspectivas> list = new List<BSC_Perspectivas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Perspectivas ORDER BY nrordem");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Perspectivas()
                    {
                        txperspectiva = Convert.ToString(reader["txperspectiva"]),
                        txcor = Convert.ToString(reader["txcor"]),
                        txiniciativa = Convert.ToString(reader["txiniciativa"]),
                        objetivos = new BscDB().ListarScoreCardObjetivos(Convert.ToInt32(reader["idperspectiva"]))
                    });
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

        public List<BSC_Objetivos> ListarScoreCardObjetivos(int idperspectiva = 0)
        {
            try
            {
                List<BSC_Objetivos> list = new List<BSC_Objetivos>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Objetivos WHERE idperspectiva = @idperspectiva ORDER BY nrordem");
                quey.SetParameter("idperspectiva", idperspectiva);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Objetivos()
                    {
                        txobjetivo = Convert.ToString(reader["txobjetivo"]),
                        inidicadores = new BscDB().ListarScoreCardIndicadores(Convert.ToInt32(reader["idobjetivo"]))
                    });
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

        public List<BSC_Indicadores> ListarScoreCardIndicadores(int idobjetivo = 0)
        {
            try
            {
                List<BSC_Indicadores> list = new List<BSC_Indicadores>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores WHERE idobjetivo = @idobjetivo ORDER BY nrordem");
                quey.SetParameter("idobjetivo", idobjetivo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    list.Add(new BSC_Indicadores()
                    {
                        idindicador = Convert.ToInt32(reader["idindicador"]),
                        txindicador = Convert.ToString(reader["txindicador"]),
                        txunidade = Convert.ToString(reader["txunidade"]),
                        idcondicao = Convert.ToInt32(reader["idcondicao"]),
                        metas = new BscDB().ListarMetas(Convert.ToInt32(reader["idindicador"])),
                        valores = new BscDB().ListarIndicadorValores(Convert.ToInt32(reader["idindicador"]))
                });
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

        // BUSCAR

        public BSC_Perspectivas BuscarPerspectiva(int idperspectiva)
        {
            try
            {
                BSC_Perspectivas bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Perspectivas WHERE idperspectiva = @idperspectiva");
                quey.SetParameter("idperspectiva", idperspectiva);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Perspectivas(Convert.ToInt32(reader["idperspectiva"]), Convert.ToString(reader["txperspectiva"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txcor"]), Convert.ToString(reader["txiniciativa"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public BSC_Objetivos BuscarObjetivo(int idobjetivo)
        {
            try
            {
                BSC_Objetivos bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Objetivos WHERE idobjetivo = @idobjetivo");
                quey.SetParameter("idobjetivo", idobjetivo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Objetivos(Convert.ToInt32(reader["idobjetivo"]), Convert.ToInt32(reader["idperspectiva"]), Convert.ToString(reader["txobjetivo"]), Convert.ToInt32(reader["nrordem"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public BSC_Indicadores BuscarIndicador(int idindicador)
        {
            try
            {
                BSC_Indicadores bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores WHERE idindicador = @idindicador");
                quey.SetParameter("idindicador", idindicador);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Indicadores(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["idobjetivo"]), Convert.ToString(reader["txindicador"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txunidade"]), Convert.ToInt32(reader["idcondicao"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        //public BSC_Kpis BuscarKpi(int idkpi)
        //{
        //    try
        //    {
        //        BSC_Kpis bsc = null;

        //        DBSession session = new DBSession();
        //        Query quey = session.CreateQuery("SELECT * FROM BSC_Kpis WHERE idkpi = @idkpi");
        //        quey.SetParameter("idkpi", idkpi);
        //        IDataReader reader = quey.ExecuteQuery();

        //        if (reader.Read())
        //        {
        //            bsc = new BSC_Kpis(Convert.ToInt32(reader["idkpi"]), Convert.ToInt32(reader["idindicador"]), Convert.ToString(reader["txkpi"]), Convert.ToInt32(reader["nrordem"]), Convert.ToString(reader["txformula"]), Convert.ToString(reader["txunidade"]));
        //        }
        //        reader.Close();
        //        session.Close();

        //        return bsc;
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //}

        public BSC_Metas BuscarMeta(int idindicador = 0, int txano = 0)
        {
            try
            {
                BSC_Metas bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores_Metas WHERE idindicador = @idindicador AND txano = @txano");
                quey.SetParameter("idindicador", idindicador);
                quey.SetParameter("txano", txano);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Metas(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["txano"]), Convert.ToString(reader["txvalor"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public BSC_Indicadores_Valor BuscarIndicadorValor(int idindicador = 0)
        {
            try
            {
                BSC_Indicadores_Valor bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores_Valores WHERE idindicador = @idindicador");
                quey.SetParameter("idindicador", idindicador);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Indicadores_Valor(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["ano"]), Convert.ToInt32(reader["mes"]), Convert.ToInt32(reader["valor"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error; 
            }
        }

        public BSC_Indicadores_Valor BuscarIndicadorValor(int idindicador = 0, int mes = 0, int ano = 0)
        {
            try
            {
                BSC_Indicadores_Valor bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM BSC_Indicadores_Valores WHERE idindicador = @idindicador AND ano = @ano AND mes = @mes");
                quey.SetParameter("idindicador", idindicador);
                quey.SetParameter("mes", mes);
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new BSC_Indicadores_Valor(Convert.ToInt32(reader["idindicador"]), Convert.ToInt32(reader["ano"]), Convert.ToInt32(reader["mes"]), Convert.ToInt32(reader["valor"]));
                }
                reader.Close();
                session.Close();

                return bsc;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}