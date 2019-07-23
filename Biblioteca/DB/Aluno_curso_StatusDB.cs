using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Aluno_curso_StatusDB
    {
        public void Salvar(Aluno_curso_Status variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO aluno_curso_status (aluno_curso, status, dtstatus, idusuario) values (@aluno_curso, @status, getdate(), @idusuario)");
                query.SetParameter("aluno_curso", variavel.aluno_curso);
                query.SetParameter("status", variavel.status);
                query.SetParameter("idusuario", variavel.idusuario);
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
