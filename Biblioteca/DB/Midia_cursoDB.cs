using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Midia_cursoDB
    {
        public void Salvar(Midia_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Midia_curso (midia_id, curso) VALUES (@midia_id, @curso) ");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("curso", variavel.curso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Midia_curso WHERE midia_id = @midia_id AND curso = @curso");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("curso", variavel.curso.codigo);
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
                Query query = session.CreateQuery("DELETE FROM Midia_curso WHERE midia_id = @midia_id");
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
