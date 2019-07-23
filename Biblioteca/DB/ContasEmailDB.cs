using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ContasEmailDB
    {
        public void Salvar(Contas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_emails (iddominio, txusuario, txsenha, qtlimite) VALUES (@dominio, @usuario, @senha, @limite) ");
                query.SetParameter("dominio", variavel.dominio.iddominio)
                    .SetParameter("usuario", variavel.usuario)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("limite", variavel.limite);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Contas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_emails SET iddominio = @dominio, txusuario = @usuario, txsenha = @senha, qtlimite = @limite WHERE idemail = @id");
                query.SetParameter("dominio", variavel.dominio.iddominio)
                    .SetParameter("usuario", variavel.usuario)
                    .SetParameter("senha", variavel.senha)
                    .SetParameter("limite", variavel.limite)
                    .SetParameter("id", variavel.idemail);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Contas variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_emails WHERE idemail = @id");
                query.SetParameter("id", variavel.idemail);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Contas Buscar(int id)
        {
            try
            {
                Contas contas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio WHERE mr.idemail = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contas = new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"]));
                }
                reader.Close();
                session.Close();

                return contas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Contas Buscar(string usuario)
        {
            try
            {
                Contas contas = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio WHERE mr.txusuario = @usuario");
                quey.SetParameter("txusuario", usuario);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    contas = new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"]));
                }
                reader.Close();
                session.Close();

                return contas;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Contas> Listar(int pagina = 1)
        {
            try
            {
                List<Contas> dataLote = new List<Contas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio ORDER BY mr.txusuario OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"])));
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

        public List<Contas> Listar(int pagina = 1, string usuario = "")
        {
            try
            {
                List<Contas> dataLote = new List<Contas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio WHERE mr.txusuario like '%" + usuario.Replace(" ", "%") + "%' ORDER BY mr.txusuario OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"])));
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
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio ");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string usuario = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio WHERE mr.txusuario like '%" + usuario.Replace(" ", "%") + "%'");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<Contas> Listar()
        {
            try
            {
                List<Contas> dataLote = new List<Contas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio ORDER BY mr.txusuario");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"])));
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

        //public List<Contas> Listar(string usuario)
        //{
        //    try
        //    {
        //        List<Contas> dataLote = new List<Contas>();

        //        DBSession session = new DBSession();
        //        Query quey = session.CreateQuery("SELECT mr.*, md.txdominio FROM mailing_emails mr left join mailing_dominios md on md.iddominio = mr.iddominio WHERE mr.txusuario = @usuario ORDER BY mr.txusuario");
        //        quey.SetParameter("usuario", usuario);
        //        IDataReader reader = quey.ExecuteQuery();

        //        while (reader.Read())
        //        {
        //            dataLote.Add(new Contas(Convert.ToInt32(reader["idemail"]), new Dominio() { iddominio = Convert.ToInt32(reader["iddominio"]) }, Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"])));
        //        }
        //        reader.Close();
        //        session.Close();

        //        return dataLote;
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }
        //}

    }
}
