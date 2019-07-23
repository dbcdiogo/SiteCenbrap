using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace SiteCenbrap.Models
{
    public class CursosView
    {
        public Titulo_curso titulo_curso { get; set; }
        public List<Depoimento> depoimentos { get; set; }
        public List<Curso> curso { get; set; }
        public List<Titulo_curso_Disciplina> disciplina { get; set; }
        public List<Titulo_curso_professor> professores { get; set; }
        public decimal matricula { get; set; }
        public decimal matricula1 { get; set; }
        public decimal valor { get; set; }
        public int parcelas { get; set; }
        public List<Faq> faq { get; set; }
        public int tipo_curso { get; set; }
        public int carga_horaria { get; set; }
        public string curso_texto { get; set; }
        public string certificadora { get; set; }
        public List<Curso> cidades { get; set; }
        public int idhotel { get; set; }

        public CursosView()
        {
            this.titulo_curso = new Titulo_curso();
            this.depoimentos = new List<Depoimento>();
            this.curso = new List<Curso>();
            this.disciplina = new List<Titulo_curso_Disciplina>();
            this.professores = new List<Titulo_curso_professor>();
            this.matricula = 390;
            this.matricula1 = 490;
            this.valor = 890;
            this.parcelas = 18;
            this.faq = new List<Faq>();
            this.tipo_curso = 0;
            this.carga_horaria = 0;
            this.curso_texto = "";
            this.certificadora = "";
            this.cidades = new List<Curso>();
            this.idhotel = 0;
        }

        public CursosView(string link)
        {
            this.titulo_curso = new Titulo_curso();
            this.titulo_curso = new Titulo_cursoDB().Buscar(link);           

            this.depoimentos = new List<Depoimento>();
            this.depoimentos = new DepoimentoDB().Listar("cenbrap.com.br");

            this.curso = new List<Curso>();
            this.disciplina = new List<Titulo_curso_Disciplina>();
            this.faq = new FaqDB().Listar(this.titulo_curso.codigo, "cenbrap.com.br");

            if (this.titulo_curso != null)
            {
                this.curso = new CursoDB().ProximosWorkshop(this.titulo_curso, 8);
                //this.curso = new CursoDB().Proximos(this.titulo_curso, 4);
                this.cidades = new CursoDB().CursosCidade2(this.titulo_curso);
                //this.curso = new CursoDB().Proximos(this.titulo_curso, TipoCurso.PosGraduacao, 4);
                this.disciplina = new Titulo_curso_DisciplinaDB().Listar(this.titulo_curso.codigo);
                this.professores = new Titulo_curso_professorDB().Listar(this.titulo_curso.codigo);

                if(this.curso.Count > 0)
                {
                    this.matricula = this.curso.First().matricula;
                    this.matricula1 = this.curso.First().matricula1;
                    this.valor = this.curso.First().valor;
                    this.parcelas = this.curso.First().qtd_parcelas;
                    this.valor = this.valor / this.parcelas;
                    this.tipo_curso = this.curso.First().tipo;
                    this.carga_horaria = this.curso.First().carga_horaria;
                    this.curso_texto = this.curso.First().texto;
                    this.certificadora = this.curso.First().certificadora_id.titulo_abreviado;
                    this.idhotel = this.curso.First().idhotel;
                }
            }
        }
    }
}