using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Titulo_curso_bannerDB
    {
        public void Salvar(Titulo_curso_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Titulo_curso_banner (titulo_curso, imagem) VALUES (@titulo_curso, @imagem) ");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Titulo_curso_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Titulo_curso_banner SET imagem = @imagem WHERE titulo_curso = @titulo_curso");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Titulo_curso_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Titulo_curso_banner WHERE titulo_curso = @titulo_curso");
                query.SetParameter("titulo_curso", variavel.titulo_curso.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Titulo_curso_banner Buscar(int codigo)
        {
            try
            {
                Titulo_curso_banner retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Titulo_curso_banner WHERE Titulo_curso = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Titulo_curso_banner(new Titulo_curso() { codigo = Convert.ToInt32(reader["titulo_curso"]) }, Convert.ToString(reader["imagem"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
    }
}
