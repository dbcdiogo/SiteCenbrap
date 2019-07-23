using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace SiteCenbrap.Models
{
    public class CursoView
    {
        public Curso curso { get; set; }
        public Titulo_curso titulo_curso { get; set; }
        public List<Titulo_curso_professor> professores { get; set; }
        public List<Titulo_curso_Disciplina> disciplinas { get; set; }
        public List<Documentos> documentos { get; set; }
        public List<Encontro> encontros { get; set; }
        public List<GrupoData> grupoData { get; set; }
        public List<Faq> faq { get; set; }
        public List<Curso> proximasTurmas { get; set; }
        public string texto_button { get; set; }
        public string data_prevista { get; set; }
        public Hoteis hotel { get; set; }
        public int qtd { get; set; }


        public CursoView()
        {
            this.curso = new Curso();
            this.titulo_curso = new Titulo_curso();
            this.professores = new List<Titulo_curso_professor>();
            this.disciplinas = new List<Titulo_curso_Disciplina>();
            this.documentos = new List<Documentos>();
            this.encontros = new List<Encontro>();
            this.grupoData = new List<GrupoData>();
            this.faq = new List<Faq>();
            this.proximasTurmas = new List<Curso>();
            this.texto_button = "Quero me matricular";
            this.data_prevista = "";
            this.hotel = null;
        }

        public CursoView(Curso curso)
        {
            curso.cidade_codigo = new CidadeDB().Buscar(curso.cidade_codigo.codigo);
            curso.cidade_local = new Cidade_localDB().BuscarCidade(curso.cidade_codigo.codigo);
            this.curso = curso;
            this.titulo_curso = new Titulo_cursoDB().Buscar(curso.titulo_curso.codigo);
            this.professores = new Titulo_curso_professorDB().Listar(curso.titulo_curso.codigo);
            this.disciplinas = new Titulo_curso_DisciplinaDB().Listar(curso.titulo_curso.codigo);
            this.documentos = new DocumentosDB().Listar(curso);
            this.encontros = new EncontroDB().Listar(curso);
            this.faq = new FaqDB().Listar(curso.titulo_curso.codigo, "cenbrap.com.br");
            this.proximasTurmas = new CursoDB().ProximosSite(TipoCurso.PosGraduacao, 3);
            this.grupoData = new GrupoDataDB().Listar(curso.data_inicio);
            this.hotel = new HoteisDB().Buscar(curso.idhotel);

            Aluno_cursoDB db = new Aluno_cursoDB();
            this.qtd = db.Qtd(curso);

            if (this.curso.ativo == 0)
            {
                
                if (this.curso.inicio_confirmado == 1)
                {
                    this.texto_button = "Início confirmado";
                    this.data_prevista = this.curso.inicio_confirmado_data.ToShortDateString();
                } else {
                    this.texto_button = "Pré-reserva";

                    int mes = DateTime.Now.Month;
                    int ano = DateTime.Now.Year;
                    int semestre = 2;
                    if (mes >= 6)
                    {
                        semestre = 1;
                        ano++;
                    }
                    this.data_prevista = semestre + "º semestre de " + ano;
                }
                
            }
            else
            {
                this.texto_button = "";
                if (this.curso.inicio_confirmado == 1 && (this.curso.tipo == 0 || this.curso.tipo == 1))
                    this.texto_button += "Turma confirmada! <BR>";
                this.texto_button += "Quero me matricular";
            }


        }
    }
}