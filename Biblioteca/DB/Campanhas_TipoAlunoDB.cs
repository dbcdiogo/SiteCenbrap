using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Campanhas_TipoAlunoDB
    {

        public void Salvar(Campanhas_TipoAluno tipo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_tipoaluno (idcampanha, flnovos, flantigos, txstatus) VALUES (@campanha, @novos, @antigos, @status) ");
                query.SetParameter("campanha", tipo.idcampanha);
                query.SetParameter("novos", tipo.flnovos);
                query.SetParameter("antigos", tipo.flantigos);
                query.SetParameter("status", tipo.txstatus);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Campanhas_TipoAluno tipo)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_campanhas_tipoaluno set flnovos = @novos, flantigos = @antigos, txstatus = @status where idcampanha = @id ");
                query.SetParameter("id", tipo.idcampanha);
                query.SetParameter("novos", tipo.flnovos);
                query.SetParameter("antigos", tipo.flantigos);
                query.SetParameter("status", tipo.txstatus);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Campanhas_TipoAluno Buscar(int id)
        {
            try
            {
                Campanhas_TipoAluno tipoaluno = null;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_tipoaluno where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    tipoaluno = new Campanhas_TipoAluno(Convert.ToInt32(reader["idcampanha"]), Convert.ToInt32(reader["flnovos"]), Convert.ToInt32(reader["flantigos"]), Convert.ToString(reader["txstatus"]));
                }
                reader.Close();
                session.Close();

                return tipoaluno;
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
                Query query = session.CreateQuery("select * from mailing_campanhas_tipoaluno where idcampanha = @campanha");
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

    }
}
