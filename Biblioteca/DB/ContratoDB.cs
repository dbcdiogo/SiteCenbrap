using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ContratoDB
    {
        public void Salvar(Contrato variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO contratos (txcontrato, txtexto) VALUES (@txcontrato, @txtexto) ");
                query.SetParameter("txcontrato", variavel.txcontrato)
                    .SetParameter("txtexto", variavel.txtexto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Contrato variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE contratos SET txcontrato = @txcontrato, txtexto = @txtexto WHERE idcontrato = @idcontrato");
                query.SetParameter("idcontrato", variavel.idcontrato)
                    .SetParameter("txcontrato", variavel.txcontrato)
                    .SetParameter("txtexto", variavel.txtexto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Contrato variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM contratos WHERE idcontrato = @idcontrato");
                query.SetParameter("idcontrato", variavel.idcontrato);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Contrato Buscar(int id)
        {
            try
            {
                Contrato contrato = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contratos WHERE idcontrato = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contrato = new Contrato(Convert.ToInt32(reader["idcontrato"]), Convert.ToString(reader["txcontrato"]), Convert.ToString(reader["txtexto"]));
                }
                reader.Close();
                session.Close();

                return contrato;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Contrato Buscar(string txcontrato)
        {
            try
            {
                Contrato contrato = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contratos WHERE txcontrato = @txcontrato");
                quey.SetParameter("txcontrato", txcontrato);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contrato = new Contrato(Convert.ToInt32(reader["idcontrato"]), Convert.ToString(reader["txcontrato"]), Convert.ToString(reader["txtexto"]));
                }
                reader.Close();
                session.Close();

                return contrato;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Contrato> Listar()
        {
            try
            {
                List<Contrato> contrato = new List<Contrato>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contratos ORDER BY txcontrato");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contrato.Add(new Contrato(Convert.ToInt32(reader["idcontrato"]), Convert.ToString(reader["txcontrato"]), Convert.ToString(reader["txtexto"])));
                }
                reader.Close();
                session.Close();

                return contrato;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Contrato> Listar(int pagina = 1)
        {
            try
            {
                List<Contrato> contrato = new List<Contrato>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contratos ORDER BY txcontrato OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contrato.Add(new Contrato(Convert.ToInt32(reader["idcontrato"]), Convert.ToString(reader["txcontrato"]), Convert.ToString(reader["txtexto"])));
                }
                reader.Close();
                session.Close();

                return contrato;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Contrato> Listar(int pagina = 1, string txcontrato = "")
        {
            try
            {
                List<Contrato> contrato = new List<Contrato>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM contratos WHERE txcontrato like '%" + txcontrato.Replace(" ", "%") + "%' ORDER BY txcontrato OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("txcontrato", txcontrato);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    contrato.Add(new Contrato(Convert.ToInt32(reader["idcontrato"]), Convert.ToString(reader["txcontrato"]), Convert.ToString(reader["txtexto"])));
                }
                reader.Close();
                session.Close();

                return contrato;
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM contratos");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string txcontrato = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM contratos WHERE txcontrato like '%" + txcontrato.Replace(" ", "%") + "%'");
            quey.SetParameter("txcontrato", txcontrato);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }
    }
}
