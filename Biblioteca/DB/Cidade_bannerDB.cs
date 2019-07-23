using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cidade_bannerDB
    {
        public void Salvar(Cidade_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Cidade_banner (cidade, imagem) VALUES (@cidade, @imagem) ");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Cidade_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Cidade_banner SET imagem = @imagem WHERE cidade = @cidade");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Cidade_banner variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM Cidade_banner WHERE cidade = @cidade");
                query.SetParameter("cidade", variavel.cidade.codigo)
                    .SetParameter("imagem", variavel.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Cidade_banner Buscar(int codigo)
        {
            try
            {
                Cidade_banner retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Cidade_banner WHERE Cidade = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Cidade_banner(new Cidade() { codigo = Convert.ToInt32(reader["cidade"]) }, Convert.ToString(reader["imagem"]));
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
