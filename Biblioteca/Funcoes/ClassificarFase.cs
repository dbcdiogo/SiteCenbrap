using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class ClassificarFase
    {
        public void Classifica()
        {
            Aluno_cursoDB db = new Aluno_cursoDB();
            List<Aluno_curso_fase> list = db.ListarClassificarFase();

            foreach(var l in list)
            {
                l.QualFase();
                db.AlterarFase(l.codigo, l.fase);
            }
        }
    }
}
