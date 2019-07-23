using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class ClicouDB
    {
        public void Salvar(Clicou variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_clicou (idenviado, dtclicou, cont) VALUES (@idenviado, @dtclicou, @cont) ");
                query.SetParameter("idenviado", variavel.idenviado.idenviado)
                .SetParameter("dtclicou", variavel.dtclicou)
                .SetParameter("cont", variavel.cont);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Clicou variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_clicou WHERE idclicou = @idclicou");
                query.SetParameter("idclicou", variavel.idclicou);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Clicou> Listar(Enviado enviado)
        {
            try
            {
                List<Clicou> clicou = new List<Clicou>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(idclicou, 0) as idclicou, isnull(idenviado, 0) as idenviado, isnull(dtclicou, '01/01/1900') as dtclicou, isnull(cont, 0) as cont FROM mailing_clicou WHERE idenviado = @idenviado ORDER BY dtclicou DESC");
                query.SetParameter("@idenviado", enviado.idenviado);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    clicou.Add(new Clicou(Convert.ToInt32(reader["idemail"]), new Enviado() { idenviado = Convert.ToInt32(reader["idenviado"]) }, Convert.ToDateTime(reader["dtclicou"]), Convert.ToInt32(reader["cont"])));
                }
                reader.Close();
                session.Close();

                return clicou;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

    }
}
