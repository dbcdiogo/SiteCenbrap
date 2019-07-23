using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class FeriadosDB
    {

        public void Salvar(Feriados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Feriados (txferiado, dia, mes, ano, idcidade, idestado) VALUES (@txferiado, @dia, @mes, @ano, @idcidade, @idestado) ");
                query.SetParameter("txferiado", variavel.txferiado)
                    .SetParameter("dia", variavel.dia)
                    .SetParameter("mes", variavel.mes)
                    .SetParameter("ano", variavel.ano)
                    .SetParameter("idcidade", variavel.idcidade)
                    .SetParameter("idestado", variavel.idestado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Feriados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Feriados SET txferiado = @txferiado, dia = @dia, mes = @mes, ano = @ano, idcidade = @idcidade, idestado = @idestado WHERE idferiado = @idferiado");
                query.SetParameter("txferiado", variavel.txferiado)
                    .SetParameter("dia", variavel.dia)
                    .SetParameter("mes", variavel.mes)
                    .SetParameter("ano", variavel.ano)
                    .SetParameter("idcidade", variavel.idcidade)
                    .SetParameter("idestado", variavel.idestado)
                    .SetParameter("idferiado", variavel.idferiado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Feriados variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Feriados WHERE idferiado = @idferiado");
                query.SetParameter("idferiado", variavel.idferiado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Feriados Buscar(int idferiado)
        {
            try
            {
                Feriados feriado = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Feriados WHERE idferiado = @idferiado");
                quey.SetParameter("idferiado", idferiado);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    feriado = new Feriados()
                    {
                        idferiado = Convert.ToInt32(reader["idferiado"]),
                        txferiado = Convert.ToString(reader["txferiado"]),
                        dia = Convert.ToInt32(reader["dia"]),
                        mes = Convert.ToInt32(reader["mes"]),
                        ano = (reader["ano"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ano"]) : null),
                        idcidade = (reader["idcidade"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idcidade"]) : null),
                        idestado = (reader["idestado"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idestado"]) : null),
                    };
                }

                reader.Close();
                session.Close();

                return feriado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Feriados Buscar(string txferiado)
        {
            try
            {
                Feriados feriado = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Feriados WHERE txferiado = @txferiado");
                quey.SetParameter("txferiado", txferiado);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    feriado = new Feriados()
                    {
                        idferiado = Convert.ToInt32(reader["idferiado"]),
                        txferiado = Convert.ToString(reader["txferiado"]),
                        dia = Convert.ToInt32(reader["dia"]),
                        mes = Convert.ToInt32(reader["mes"]),
                        ano = (reader["ano"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ano"]) : null),
                        idcidade = (reader["idcidade"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idcidade"]) : null),
                        idestado = (reader["idestado"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idestado"]) : null),
                    };
                }
                reader.Close();
                session.Close();

                return feriado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Feriados> Listar(int pagina = 1)
        {
            try
            {
                List<Feriados> dataLote = new List<Feriados>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Feriados ORDER BY txferiado OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Feriados()
                        {
                            idferiado = Convert.ToInt32(reader["idferiado"]),
                            txferiado = Convert.ToString(reader["txferiado"]),
                            dia = Convert.ToInt32(reader["dia"]),
                            mes = Convert.ToInt32(reader["mes"]),
                            ano = (reader["ano"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ano"]) : null),
                            idcidade = (reader["idcidade"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idcidade"]) : null),
                            idestado = (reader["idestado"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idestado"]) : null),
                        }    
                    );
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

        public List<Feriados> Listar(int pagina = 1, string txferiado = "")
        {
            try
            {
                List<Feriados> dataLote = new List<Feriados>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Feriados WHERE txferiado like '%" + txferiado.Replace(" ", "%") + "%' ORDER BY txferiado OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("txferiado", txferiado);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Feriados()
                        {
                            idferiado = Convert.ToInt32(reader["idferiado"]),
                            txferiado = Convert.ToString(reader["txferiado"]),
                            dia = Convert.ToInt32(reader["dia"]),
                            mes = Convert.ToInt32(reader["mes"]),
                            ano = (reader["ano"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ano"]) : null),
                            idcidade = (reader["idcidade"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idcidade"]) : null),
                            idestado = (reader["idestado"] != DBNull.Value ? (int?)Convert.ToInt32(reader["idestado"]) : null),
                        }
                    );
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Feriados");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string txferiado = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Feriados WHERE txferiado like '%" + txferiado.Replace(" ", "%") + "%'");
            quey.SetParameter("txferiado", txferiado);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public Boolean Validar(int dia, int mes)
        {
            try
            {
                Boolean feriado = false;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM feriados WHERE dia = @dia and mes = @mes and ano is null");
                quey.SetParameter("dia", dia);
                quey.SetParameter("mes", mes);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    feriado = true;
                }
                reader.Close();
                session.Close();

                return feriado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
               
        

    }
}
