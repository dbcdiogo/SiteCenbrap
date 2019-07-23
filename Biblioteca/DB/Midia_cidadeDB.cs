using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Midia_cidadeDB
    {
        public void Salvar(Midia_cidade variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Midia_cidade (midia_id, cidade) VALUES (@midia_id, @cidade) ");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("cidade", variavel.cidade.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia_cidade variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Midia_cidade WHERE midia_id = @midia_id AND cidade = @cidade");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("cidade", variavel.cidade.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Midia_cidade WHERE midia_id = @midia_id");
                query.SetParameter("midia_id", variavel.midia_id);
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
