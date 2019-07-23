using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Campanhas_AgendamentoDB
    {

        public void Salvar(Campanhas_Agendamento agendamento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_agendamento (idcampanha, tpagendamento, dtenvio, nrdiasciclico, dtiniciociclico, nrdiasprazo, idcampanhaprazo) VALUES (@campanha, @agendamento, @dataenvio, @diasciclico, @dataciclico, @diasprazo, @idcampanha) ");
                query.SetParameter("campanha", agendamento.idcampanha);
                query.SetParameter("agendamento", agendamento.tpagendamento);
                query.SetParameter("dataenvio", agendamento.dtenvio);
                query.SetParameter("diasciclico", agendamento.nrdiasciclico);
                query.SetParameter("dataciclico", agendamento.dtiniciociclico);
                query.SetParameter("diasprazo", agendamento.nrdiasprazo);
                query.SetParameter("idcampanha", agendamento.idcampanhaprazo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Campanhas_Agendamento agendamento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_campanhas_agendamento set tpagendamento = @agendamento, dtenvio = @dataenvio, nrdiasciclico = @diasciclico, dtiniciociclico = @dataciclico, nrdiasprazo = @diasprazo, idcampanhaprazo = @idcampanha where idcampanha = @campanha");
                query.SetParameter("campanha", agendamento.idcampanha);
                query.SetParameter("agendamento", agendamento.tpagendamento);
                query.SetParameter("dataenvio", agendamento.dtenvio);
                query.SetParameter("diasciclico", agendamento.nrdiasciclico);
                query.SetParameter("dataciclico", agendamento.dtiniciociclico);
                query.SetParameter("diasprazo", agendamento.nrdiasprazo);
                query.SetParameter("idcampanha", agendamento.idcampanhaprazo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Campanhas_Agendamento Buscar(int id)
        {
            try
            {
                Campanhas_Agendamento agendamento = null;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_agendamento where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    agendamento = new Campanhas_Agendamento(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["tpagendamento"]), Convert.ToString(reader["dtenvio"]), Convert.ToInt32(reader["nrdiasciclico"]), Convert.ToString(reader["dtiniciociclico"]), Convert.ToInt32(reader["nrdiasprazo"]), Convert.ToInt32(reader["idcampanhaprazo"]));
                }
                reader.Close();
                session.Close();

                return agendamento;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public int Existe(int id)
        {
            try
            {
                int idcampanha = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_agendamento where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    idcampanha = Convert.ToInt32(reader["idcampanha"]);
                }
                reader.Close();
                session.Close();

                return idcampanha;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Campanhas_Agendamento> AgendadosProximaHora()
        {
            try
            {
                List<Campanhas_Agendamento> agendamento = new List<Campanhas_Agendamento>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_agendamento where tpagendamento = 'A' and dtenvio between dateadd(hour, -1, getdate()) and dateadd(hour, 1, getdate())");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    agendamento.Add(new Campanhas_Agendamento(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["tpagendamento"]), Convert.ToString(reader["dtenvio"]), Convert.ToInt32(reader["nrdiasciclico"]), Convert.ToString(reader["dtiniciociclico"]), Convert.ToInt32(reader["nrdiasprazo"]), Convert.ToInt32(reader["idcampanhaprazo"])));
                }
                reader.Close();
                session.Close();

                return agendamento;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
