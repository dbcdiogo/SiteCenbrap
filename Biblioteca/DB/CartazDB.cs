using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class CartazDB
    {
        public void Salvar(Cartaz variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO cartaz (cidade, data, ip) VALUES (@cidade, @data, @ip) ");
                query.SetParameter("cidade", variavel.cidade)
                    .SetParameter("data", variavel.data)
                    .SetParameter("ip", variavel.ip);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
