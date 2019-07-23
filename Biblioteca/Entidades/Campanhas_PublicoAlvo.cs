using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Campanhas_PublicoAlvo
    {
        public int idcampanha { get; set; }
        public int fltipo { get; set; }
        public int idcampanharef { get; set; }

        public Campanhas_PublicoAlvo()
        {
            this.idcampanha = 0;
            this.fltipo = 0;
            this.idcampanharef = 0;
        }

        public Campanhas_PublicoAlvo(int id, int tipo, int campanha)
        {
            this.idcampanha = id;
            this.fltipo = tipo;
            this.idcampanharef = campanha;
        }

        public int Existe(int id)
        {
            return new Campanhas_PublicoAlvoDB().Existe(id);
        }

        public void ExcluirPublicoAlvo(int id)
        {
            new Campanhas_PublicoAlvoDB().ExcluirPublicoAlvo(id);
        }
    }

    public class Campanhas_PublicoAlvo_Cursos
    {
        public int idcampanha { get; set; }
        public int idtitulo { get; set; }
        public int idcurso { get; set; }
        public string fltipo { get; set; }
        public string titulo { get; set; }
        public string turma { get; set; }

        public Campanhas_PublicoAlvo_Cursos()
        {
            this.idcampanha = 0;
            this.idtitulo = 0;
            this.idcurso = 0;
            this.fltipo = "";
            this.titulo = "";
            this.turma = "";
        }

        public Campanhas_PublicoAlvo_Cursos(int idcampanha, int idtitulo, int idcurso, string fltipo)
        {
            this.idcampanha = idcampanha;
            this.idtitulo = idtitulo;
            this.idcurso = idcurso;
            this.fltipo = fltipo;
        }

        public Campanhas_PublicoAlvo_Cursos(int idcampanha, int idtitulo, int idcurso, string fltipo, string titulo, string turma)
        {
            this.idcampanha = idcampanha;
            this.idtitulo = idtitulo;
            this.idcurso = idcurso;
            this.fltipo = fltipo;
            this.titulo = titulo;
            this.turma = turma;
        }

        public void ExcluirPublicoAlvoCurso(int id)
        {
            new Campanhas_PublicoAlvoDB().ExcluirPublicoAlvoCurso(id);
        }

        public void SalvarPublicoAlvoCurso()
        {
            new Campanhas_PublicoAlvoDB().SalvarPublicoAlvoCurso(this);
        }

        public void ExcluirExclusoesCurso(int id)
        {
            new Campanhas_PublicoAlvoDB().ExcluirExclusoesCurso(id);
        }

        public void SalvarExclusoesCurso()
        {
            new Campanhas_PublicoAlvoDB().SalvarExclusoesCurso(this);
        }
    }

}
