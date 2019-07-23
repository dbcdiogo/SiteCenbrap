using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ScoreCidadesDB
    {
        public List<ScoreCidadesDashboard> ListarDashboard(int ano)
        {
            try
            {
                List<ScoreCidadesDashboard> dataLote = new List<ScoreCidadesDashboard>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select sce.txestado, sce.txcidade, sum(sccv.ptcriterio) as pontos, sce.flinterior
                    from Score_Cidades_Valores scv
                    left join Score_Cidades_Criterios_Valores sccv on sccv.idcriterio = scv.idcriterio and scv.vlcriterio between sccv.vlmin and isnull(sccv.vlmax, 999999)
                    left join Score_Cidades_Estados sce on sce.idestado = scv.idestado
                    where scv.nrano = @ano
                    group by sce.txestado, sce.txcidade, sce.flinterior, scv.idestado
                    order by sum(sccv.ptcriterio) desc, (select s1.vlcriterio from Score_Cidades_Valores s1 where s1.idestado = scv.idestado and s1. idcriterio = 6)");
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ScoreCidadesDashboard()
                    {
                        pontos = Convert.ToInt32(reader["pontos"]),
                        estado = Convert.ToString(reader["txestado"]) + " / " + Convert.ToString(reader["txcidade"]),
                        flinterior = Convert.ToInt32(reader["flinterior"]),
                        turmas = new ScoreCidadesDB().ListaTurmasAbertas(Convert.ToString(reader["txestado"]), Convert.ToString(reader["txcidade"]))
                    });

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

        public int ListaTurmasAbertas(string estado, string cidade)
        {
            try
            {
                int r = 0;
                string qry = "";

                if (cidade == "Todas")
                {
                    qry = "select count(c.codigo) as total, ci.estado, ci.cidade from curso c left join cidade ci on ci.codigo = c.cidade_codigo where c.inicio_confirmado = 1 and isnull(c.inicio_confirmado_data, '1900-01-01') <> '1900-01-01' and c.tipo in (0) and ci.estado = '" + estado + "' and ci.cidade <> '" + cidade + "' group by ci.estado, ci.cidade";
                }
                else
                {
                    qry = "select count(c.codigo) as total, ci.estado, ci.cidade from curso c left join cidade ci on ci.codigo = c.cidade_codigo where c.inicio_confirmado = 1 and isnull(c.inicio_confirmado_data, '1900-01-01') <> '1900-01-01' and c.tipo in (0) and ci.estado = '" + estado + "' and ci.cidade = '" + cidade + "' group by ci.estado, ci.cidade";
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
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<ScoreCidadesEstados> ListarEstados()
        {
            try
            {
                List<ScoreCidadesEstados> dataLote = new List<ScoreCidadesEstados>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Score_Cidades_Estados order by txestado, flinterior");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ScoreCidadesEstados(Convert.ToInt32(reader["idestado"]), Convert.ToString(reader["txestado"]), Convert.ToInt32(reader["flinterior"]), Convert.ToString(reader["txcidade"])));
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

        public List<ScoreCidadesCriterios> ListarCriteriosComValores()
        {
            try
            {
                List<ScoreCidadesCriterios> dataLote = new List<ScoreCidadesCriterios>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Score_Cidades_Criterios order by idcriterio");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ScoreCidadesCriterios()
                    {
                        idcriterio = Convert.ToInt32(reader["idcriterio"]),
                        txcriterio = Convert.ToString(reader["txcriterio"]),
                        valores = new ScoreCidadesDB().ListarCriteriosComValores(Convert.ToInt32(reader["idcriterio"]))
                    });
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

        public List<ScoreCidades> ListarValores(int ano)
        {
            try
            {
                List<ScoreCidades> dataLote = new List<ScoreCidades>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Score_Cidades_Valores where nrano = " + ano);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ScoreCidades()
                    {
                        idestado = Convert.ToInt32(reader["idestado"]),
                        idcriterio = Convert.ToInt32(reader["idcriterio"]),
                        vlcriterio = Convert.ToDecimal(reader["vlcriterio"]),
                        nrano = Convert.ToInt32(reader["nrano"])
                    });
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

        public List<ScoreCidadesCriteriosValores> ListarCriteriosComValores(int criterio)
        {
            try
            {
                List<ScoreCidadesCriteriosValores> dataLote = new List<ScoreCidadesCriteriosValores>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select idvalor, idcriterio, vlmin, isnull(vlmax,9999) as vlmax, ptcriterio from Score_Cidades_Criterios_Valores where idcriterio = " + criterio + " order by vlmin");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new ScoreCidadesCriteriosValores(Convert.ToInt32(reader["idvalor"]), Convert.ToInt32(reader["idcriterio"]), Convert.ToDecimal(reader["vlmin"]), Convert.ToDecimal(reader["vlmax"]), Convert.ToInt32(reader["ptcriterio"])));
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

        public ScoreCidades BuscarValor(int criterio, int estado, int ano)
        {
            try
            {
                ScoreCidades bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Score_Cidades_Valores where idestado = @estado and idcriterio = @criterio and nrano = @ano");
                quey.SetParameter("estado", estado);
                quey.SetParameter("criterio", criterio);
                quey.SetParameter("ano", ano);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new ScoreCidades(Convert.ToInt32(reader["idestado"]), Convert.ToInt32(reader["idcriterio"]), Convert.ToDecimal(reader["vlcriterio"]), Convert.ToInt32(reader["nrano"]));
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

        public ScoreCidadesCriteriosValores BuscarCriterioValor(int idvalor)
        {
            try
            {
                ScoreCidadesCriteriosValores bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select idvalor, idcriterio, vlmin, isnull(vlmax, 9999) as vlmax, ptcriterio from Score_Cidades_Criterios_Valores where idvalor = @idvalor");
                quey.SetParameter("idvalor", idvalor);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new ScoreCidadesCriteriosValores(Convert.ToInt32(reader["idvalor"]), Convert.ToInt32(reader["idcriterio"]), Convert.ToDecimal(reader["vlmin"]), Convert.ToDecimal(reader["vlmax"]), Convert.ToInt32(reader["ptcriterio"]));
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

        public void SalvarValor(ScoreCidades variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Score_Cidades_Valores (idestado, idcriterio, vlcriterio, nrano) VALUES (@idestado, @idcriterio, @vlcriterio, @nrano)");
                query.SetParameter("idestado", variavel.idestado);
                query.SetParameter("idcriterio", variavel.idcriterio);
                query.SetParameter("vlcriterio", variavel.vlcriterio);
                query.SetParameter("nrano", variavel.nrano);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarValor(ScoreCidades variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Score_Cidades_Valores SET vlcriterio = @vlcriterio WHERE idestado = @idestado and idcriterio = @idcriterio and nrano = @nrano");
                query.SetParameter("idestado", variavel.idestado);
                query.SetParameter("idcriterio", variavel.idcriterio);
                query.SetParameter("vlcriterio", variavel.vlcriterio);
                query.SetParameter("nrano", variavel.nrano);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarCriterioValor(ScoreCidadesCriteriosValores variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Score_Cidades_Criterios_Valores SET vlmin = @vlmin, vlmax = @vlmax, ptcriterio = @ptcriterio WHERE idvalor = @idvalor");
                query.SetParameter("idvalor", variavel.idvalor);
                query.SetParameter("vlmin", variavel.vlmin);
                query.SetParameter("vlmax", variavel.vlmax);
                query.SetParameter("ptcriterio", variavel.ptcriterio);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirValor(ScoreCidades variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Score_Cidades_Valores WHERE idestado = @idestado and idcriterio = @idcriterio and nrano = @nrano");
                query.SetParameter("idestado", variavel.idestado);
                query.SetParameter("idcriterio", variavel.idcriterio);
                query.SetParameter("nrano", variavel.nrano);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarEstado(ScoreCidadesEstados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Score_Cidades_Estados (txestado, flinterior, txcidade) VALUES (@txestado, @flinterior, @txcidade)");
                query.SetParameter("txestado", variavel.txestado);
                query.SetParameter("flinterior", variavel.flinterior);
                query.SetParameter("txcidade", variavel.txcidade);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AlterarEstado(ScoreCidadesEstados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Score_Cidades_Estados SET txestado = @txestado, flinterior = @flinterior, txcidade = @txcidade WHERE idestado = @idestado");
                query.SetParameter("txestado", variavel.txestado);
                query.SetParameter("flinterior", variavel.flinterior);
                query.SetParameter("txcidade", variavel.txcidade);
                query.SetParameter("idestado", variavel.idestado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public void ExcluirEstado(ScoreCidadesEstados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Score_Cidades_Estados WHERE idestado = @idestado");
                query.SetParameter("idestado", variavel.idestado);
                query.ExecuteUpdate();
                session.Close();

                DBSession session2 = new DBSession();
                Query query2 = session2.CreateQuery("DELETE FROM Score_Cidades_Valores WHERE idestado = @idestado");
                query2.SetParameter("idestado", variavel.idestado);
                query2.ExecuteUpdate();
                session2.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public ScoreCidadesEstados BuscarEstado(int idestado)
        {
            try
            {
                ScoreCidadesEstados bsc = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from Score_Cidades_Estados where idestado = @idestado");
                quey.SetParameter("idestado", idestado);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    bsc = new ScoreCidadesEstados(Convert.ToInt32(reader["idestado"]), Convert.ToString(reader["txestado"]), Convert.ToInt32(reader["flinterior"]), Convert.ToString(reader["txcidade"]));
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
