using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Conteudo_ead_alunoDB
    {
        public void Salvar(Conteudo_ead_aluno variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO Conteudo_ead_aluno (conteudo_ead_id,data,aluno) VALUES (@conteudo_ead_id,@data,@aluno) ");
                query.SetParameter("conteudo_ead_id", variavel.conteudo_ead_id.conteudo_ead_id)
                    .SetParameter("data", variavel.data)
                    .SetParameter("aluno", variavel.aluno.codigo);
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
