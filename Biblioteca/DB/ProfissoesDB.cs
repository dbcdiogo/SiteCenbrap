using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ProfissoesDB
    {        
        public Profissoes Buscar(int idprofissao)
        {
            try
            {
                Profissoes profissao = null;
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from profissoes where idprofissao = @idprofissao");
                quey.SetParameter("idprofissao", idprofissao);
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    profissao = new Profissoes(Convert.ToInt32(reader["idprofissao"]), Convert.ToString(reader["txprofissao"]));
                }
                reader.Close();
                session.Close();
                return profissao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }        

        public List<Profissoes> Listar()
        {
            try
            {
                List<Profissoes> profissao = new List<Profissoes>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from profissoes ORDER BY txprofissao");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    profissao.Add(new Profissoes(Convert.ToInt32(reader["idprofissao"]), Convert.ToString(reader["txprofissao"])));
                }
                reader.Close();
                session.Close();
                return profissao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Profissoes> ListarCBMTPM()
        {
            try
            {
                List<Profissoes> profissao = new List<Profissoes>();
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from profissoes ORDER BY ordemcbmtpm");
                IDataReader reader = quey.ExecuteQuery();
                while (reader.Read())
                {
                    profissao.Add(new Profissoes(Convert.ToInt32(reader["idprofissao"]), Convert.ToString(reader["txprofissao"])));
                }
                reader.Close();
                session.Close();
                return profissao;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
