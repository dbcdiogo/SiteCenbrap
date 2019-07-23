using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Pendencias
    {
        public List<PendenciasDocumentos> documentos { get; set; }
        public List<PendenciasDisciplinas> disciplinas { get; set; }

        public Pendencias()
        {
            this.documentos = new List<PendenciasDocumentos>();
            this.disciplinas = new List<PendenciasDisciplinas>();
        }

        public void Montar(Curso curso, Aluno aluno)
        {
            this.documentos = new DocumentosDB().Pendencias(curso, aluno);
            this.disciplinas = new Aluno_curso_encontroDB().Pendencias(curso, aluno);
        }

        public void Documentos(Curso curso, Aluno aluno)
        {
            this.documentos = new DocumentosDB().PendenciasN(curso, aluno);
        }
    }

    public class PendenciasDocumentos
    {
        public string documento { get; set; }
        public bool entregue { get; set; }

        public PendenciasDocumentos()
        {
            this.documento = "";
            this.entregue = false;
        }

        public PendenciasDocumentos(string documento, bool entregue)
        {
            this.documento = documento;
            this.entregue = entregue;
        }
    }

    public class PendenciasDisciplinas
    {
        public int disciplina_codigo { get; set; }
        public string disciplina_titulo { get; set; }
        public double nota { get; set; }
        public double frequencia { get; set; }
        public List<PendenciasDisciplinasEncontros> encontros { get; set; }

        public PendenciasDisciplinas()
        {
            this.disciplina_codigo = 0;
            this.disciplina_titulo = "";
            this.nota = 0;
            this.frequencia = 0;
            this.encontros = new List<PendenciasDisciplinasEncontros>();

        }

        public PendenciasDisciplinas(int codigo, string titulo, double nota, double frequencia, int aluno, int curso)
        {
            this.disciplina_codigo = codigo;
            this.disciplina_titulo = titulo;
            this.nota = nota;
            this.frequencia = frequencia;
            this.encontros = new Aluno_curso_encontroDB().PendenciasDisciplinas(codigo, aluno, curso);
            
        }
    }

    public class PendenciasDisciplinasEncontros
    {
        public int disciplina { get; set; }
        public int encontro { get; set; }
        public int curso { get; set; }
        public string curso_titulo { get; set; }
        public int qtd_reposicao { get; set; }
        public int qtd_utilizadas { get; set; }
        public DateTime data_encontro { get; set; }
        public DateTime data_encontro1 { get; set; }
        public int ativo { get; set; }
        public PendenciasReposicao reposicao { get; set; }
        public string local { get; set; }
        public string professor { get; set; }

        public PendenciasDisciplinasEncontros()
        {
            this.disciplina = 0;
            this.encontro = 0;
            this.curso = 0;
            this.curso_titulo = "";
            this.qtd_reposicao = 0;
            this.qtd_utilizadas = 0;
            this.data_encontro = Convert.ToDateTime("01/01/1900");
            this.data_encontro1 = Convert.ToDateTime("01/01/1900");
            this.ativo = 0;
            this.reposicao = new PendenciasReposicao();
            this.local = "";
            this.professor = "";
        }

        public PendenciasDisciplinasEncontros(int disciplina, int encontro, int curso, string curso_titulo, int qtd_reposicao, int qtd_utilizadas, DateTime data_encontro, DateTime data_encontro1, int ativo, string reposicao)
        {
            this.disciplina = disciplina;
            this.encontro = encontro;
            this.curso = curso;
            this.curso_titulo = curso_titulo;
            this.qtd_reposicao = qtd_reposicao;
            this.qtd_utilizadas = qtd_utilizadas;
            this.data_encontro = data_encontro;
            this.data_encontro1 = data_encontro1;
            this.ativo = ativo;
            this.reposicao = new PendenciasReposicao(reposicao);
        }

        public PendenciasDisciplinasEncontros(int disciplina, int encontro, int curso, string curso_titulo, int qtd_reposicao, int qtd_utilizadas, DateTime data_encontro, DateTime data_encontro1, int ativo, string reposicao, string local)
        {
            this.disciplina = disciplina;
            this.encontro = encontro;
            this.curso = curso;
            this.curso_titulo = curso_titulo;
            this.qtd_reposicao = qtd_reposicao;
            this.qtd_utilizadas = qtd_utilizadas;
            this.data_encontro = data_encontro;
            this.data_encontro1 = data_encontro1;
            this.ativo = ativo;
            this.reposicao = new PendenciasReposicao(reposicao);
            this.local = local;
        }

        public PendenciasDisciplinasEncontros(int disciplina, int encontro, int curso, string curso_titulo, int qtd_reposicao, int qtd_utilizadas, DateTime data_encontro, DateTime data_encontro1, int ativo, string reposicao, string local, string professor)
        {
            this.disciplina = disciplina;
            this.encontro = encontro;
            this.curso = curso;
            this.curso_titulo = curso_titulo;
            this.qtd_reposicao = qtd_reposicao;
            this.qtd_utilizadas = qtd_utilizadas;
            this.data_encontro = data_encontro;
            this.data_encontro1 = data_encontro1;
            this.ativo = ativo;
            this.reposicao = new PendenciasReposicao(reposicao);
            this.local = local;
            this.professor = professor;
        }
    }

    public class PendenciasReposicao
    {
        public int id { get; set; }
        public int confirmada { get; set; }
        public int cancelada { get; set; }
        public string arquivo_mapa { get; set; }
        public string arquivo_material { get; set; }

        public PendenciasReposicao()
        {
            this.id = 0;
            this.confirmada = 0;
            this.cancelada = 0;
            this.arquivo_mapa = "";
            this.arquivo_material = "";
        }

        public PendenciasReposicao(string texto)
        {
            this.id = 0;
            this.confirmada = 0;
            this.cancelada = 0;
            this.arquivo_mapa = "";
            this.arquivo_material = "";

            if (texto != "")
            {
                var txts = texto.Split('#');

                this.id = Convert.ToInt32(txts[0]);
                this.confirmada = Convert.ToInt32(txts[1]);
                this.cancelada = Convert.ToInt32(txts[2]);
                this.arquivo_mapa = Convert.ToString(txts[3]);
                this.arquivo_material = Convert.ToString(txts[4]);
            }
            
        }
    }

    public class PendenciasNotificacao
    {
        public string tipo { get; set; }
        public int codigo { get; set; }
        public string texto { get; set; }

        public PendenciasNotificacao()
        {
            this.codigo = 0;
            this.texto = "";
            this.tipo = "";
        }

        public PendenciasNotificacao(string tipo, int codigo, string texto)
        {
            this.codigo = codigo;
            this.texto = texto;
            this.tipo = tipo;
        }
    }
}
