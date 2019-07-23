using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Midia_titulo_cursoDB
    {
        public void Salvar(Midia_titulo_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Midia_titulo_curso (midia_id, titulo_curso) VALUES (@midia_id, @titulo_curso) ");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("titulo_curso", variavel.titulo_curso.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia_titulo_curso variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Midia_titulo_curso WHERE midia_id = @midia_id AND titulo_curso = @titulo_curso");
                query.SetParameter("midia_id", variavel.midia_id.midia_id)
                    .SetParameter("titulo_curso", variavel.titulo_curso.codigo);
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
                Query query = session.CreateQuery("DELETE FROM Midia_titulo_curso WHERE midia_id = @midia_id");
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
