using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCenbrap.Models
{
    public class InscrevaView
    {
        public Cidade cidade { get; set; }
        public Titulo_curso curso { get; set; }
        public List<Cidade> cidades { get; set; }
        public List<Curso> cursos { get; set; }
        public List<Titulo_curso> titulocurso { get; set; }

        public InscrevaView()
        {
            this.cidades = new List<Cidade>();
            this.cursos = new List<Curso>();
            this.titulocurso = new List<Titulo_curso>();
            this.cidade = new Cidade();
            this.curso = new Titulo_curso();
            this.cidades = new CidadeDB().Listar();
            this.cursos = new CursoDB().ListarVisualizaSite();
            this.titulocurso = new Titulo_cursoDB().Listar();
        }

        public InscrevaView(int id = 0, int id2 = 0)
        {
            this.cidades = new List<Cidade>();
            this.cursos = new List<Curso>();
            this.titulocurso = new List<Titulo_curso>();
            this.cidades = new CidadeDB().ListarCursosAtivos();

            if ((id == 0) && (id2 == 0))
            {
                this.cidade = new Cidade();
                this.curso = new Titulo_curso();
                this.cursos = new CursoDB().ListarVisualizaSite();
                this.titulocurso = new Titulo_cursoDB().Listar(0, 0);
            }

            if ((id > 0) && (id2 == 0))
            {
                this.cidade = new CidadeDB().Buscar(id);
                this.curso = new Titulo_curso();
                this.cursos = new CursoDB().ListarVisualizaSite(id, 0);
                this.titulocurso = new Titulo_cursoDB().Listar(id, 0);
            }

            if ((id == 0) && (id2 > 0))
            {
                this.cidade = new Cidade();
                this.curso = new Titulo_cursoDB().Buscar(id2);
                this.cursos = new CursoDB().ListarVisualizaSite(0, id2);
                this.cidades = new CidadeDB().ListarTituloCurso(id2);
                this.titulocurso = new Titulo_cursoDB().Listar(0, id2);
            }

            if ((id > 0) && (id2 > 0))
            {
                this.cidade = new CidadeDB().Buscar(id);
                this.curso = new Titulo_cursoDB().Buscar(id2);
                this.cursos = new CursoDB().ListarVisualizaSite(id, id2);
                this.titulocurso = new Titulo_cursoDB().Listar(id, id2);
            }
         
        }

    }

}