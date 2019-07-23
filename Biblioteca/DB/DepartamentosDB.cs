using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class DepartamentosDB
    {
        public void Salvar(Departamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Departamentos (txdepartamento) VALUES (@txdepartamento) ");
                query.SetParameter("txdepartamento", variavel.txdepartamento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Departamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Departamentos SET txdepartamento = @txdepartamento WHERE iddepartamento = @iddepartamento");
                query.SetParameter("iddepartamento", variavel.iddepartamento)
                    .SetParameter("txdepartamento", variavel.txdepartamento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Departamento variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Departamentos WHERE iddepartamento = @iddepartamento");
                query.SetParameter("iddepartamento", variavel.iddepartamento);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Departamento Buscar(int iddepartamento)
        {
            try
            {
                Departamento depto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Departamentos WHERE iddepartamento = @iddepartamento");
                quey.SetParameter("iddepartamento", iddepartamento);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    depto = new Departamento(Convert.ToInt32(reader["iddepartamento"]), Convert.ToString(reader["txdepartamento"]));
                }
                reader.Close();
                session.Close();

                return depto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Departamento Buscar(string txdepartamento)
        {
            try
            {
                Departamento depto = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Departamentos WHERE txdepartamento like '%" + txdepartamento.Replace(" ", "%") + "%'");
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    depto = new Departamento(Convert.ToInt32(reader["iddepartamento"]), Convert.ToString(reader["txdepartamento"]));
                }
                reader.Close();
                session.Close();

                return depto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Departamento> Listar()
        {
            try
            {
                List<Departamento> depto = new List<Departamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Departamentos ORDER BY txdepartamento");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    depto.Add(new Departamento(Convert.ToInt32(reader["iddepartamento"]), Convert.ToString(reader["txdepartamento"])));
                }
                reader.Close();
                session.Close();

                return depto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Departamento> Listar(int pagina = 1)
        {
            try
            {
                List<Departamento> depto = new List<Departamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Departamentos ORDER BY txdepartamento OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    depto.Add(new Departamento(Convert.ToInt32(reader["iddepartamento"]), Convert.ToString(reader["txdepartamento"])));
                }
                reader.Close();
                session.Close();

                return depto;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Departamento> Listar(int pagina = 1, string txdepartamento = "")
        {
            try
            {
                List<Departamento> depto = new List<Departamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Departamentos WHERE txdepartamento like '%" + txdepartamento.Replace(" ", "%") + "%' ORDER BY txdepartamento OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    depto.Add(new Departamento(Convert.ToInt32(reader["iddepartamento"]), Convert.ToString(reader["txdepartamento"])));
                }
                reader.Close();
                session.Close();

                return depto;
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Departamentos");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string txdepartamento = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM Departamentos WHERE txdepartamento like '%" + txdepartamento.Replace(" ", "%") + "%'");
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
