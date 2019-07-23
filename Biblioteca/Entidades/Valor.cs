using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Valor
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string link { get; set; }
        public string link_trailer { get; set; }
        public string texto { get; set; }
        public string grupoead { get; set;  }

        public Valor()
        {
            this.id = 0;
            this.titulo = "";
            this.link = "";
            this.link_trailer = "";
            this.grupoead = "";
        }

        public Valor(int id, string titulo, string link)
        {
            this.id = id;
            this.titulo = titulo;
            this.link = link;
        }

        public string Option(int id = 0)
        {
            string texto = "<option value='" + this.id + "'";
            if(id == this.id)
            {
                texto += " selected";
            }
            texto += ">" + this.titulo + "</option>";
            return texto;
        }
    }

    public class Turma : Valor
    {
        public DateTime data_inicio { get; set; }
        public int ativo { get; set; }
        public bool inicio_confirmado { get; set; }
        public bool ultimas_vagas { get; set; }
        public string codTurma { get; set; }
        public string grupoead { get; set; }

        public Turma()
        {
            this.ativo = 1;
            this.id = 0;
            this.titulo = "";
            this.data_inicio = DateTime.Now;
            this.inicio_confirmado = false;
            this.ultimas_vagas = false;
            this.codTurma = "";
            this.grupoead = "";
        }

        public Turma(int id, string titulo, DateTime data_inicio, bool inicio_confirmado, bool ultimas_vagas)
        {
            this.id = id;
            this.titulo = titulo;
            this.data_inicio = data_inicio;
            this.inicio_confirmado = inicio_confirmado;
            this.ultimas_vagas = ultimas_vagas;
        }

        public Turma(int id, string titulo, DateTime data_inicio, bool inicio_confirmado, bool ultimas_vagas, int ativo = 1, string codTurma = "")
        {
            this.ativo = ativo;
            this.id = id;
            this.titulo = titulo;
            this.data_inicio = data_inicio;
            this.inicio_confirmado = inicio_confirmado;
            this.ultimas_vagas = ultimas_vagas;
            this.codTurma = codTurma;
        }

        public Turma(int id, string titulo, DateTime data_inicio, bool inicio_confirmado, bool ultimas_vagas, int ativo = 1, string codTurma = "", string grupoead = "")
        {
            this.ativo = ativo;
            this.id = id;
            this.titulo = titulo;
            this.data_inicio = data_inicio;
            this.inicio_confirmado = inicio_confirmado;
            this.ultimas_vagas = ultimas_vagas;
            this.codTurma = codTurma;
            this.grupoead = grupoead;
        }
    }

    public class Cursos : Valor
    {
        public string imagem { get; set; }
        public int codigo { get; set; }
        public string titulo1 { get; set; }

        public Cursos()
        {
            this.id = 0;
            this.titulo = "";
            this.imagem = "";
            this.codigo = 0;
            this.titulo1 = "";
        }

        public Cursos(int id, string titulo, string imagem, string link)
        {
            this.id = id;
            this.titulo = titulo;
            this.link = link;
            this.codigo = codigo;
            if (imagem == "" || imagem == null)
                this.imagem = "/images/banner.png";
            else
                this.imagem = imagem;
        }

        public Cursos(int id, string titulo, string imagem, string link, int codigo, string titulo1 = "")
        {
            this.id = id;
            this.titulo = titulo;
            this.link = link;
            this.codigo = codigo;
            if (imagem == "" || imagem == null)
                this.imagem = "/images/banner.png";
            else
                this.imagem = imagem;
            this.titulo1 = titulo1;
        }

        public Cursos(int id, string titulo, string imagem, string link, int codigo, string titulo1 = "", string link_trailer = "", string texto = "")
        {
            this.id = id;
            this.titulo = titulo;
            this.link = link;
            this.codigo = codigo;
            if (imagem == "" || imagem == null)
                this.imagem = "/images/banner.png";
            else
                this.imagem = imagem;
            this.titulo1 = titulo1;
            this.link_trailer = link_trailer;
            this.texto = texto;
        }

        public Cursos(int id, string titulo, string imagem, string link, int codigo, string titulo1 = "", string link_trailer = "", string texto = "", string grupoead = "")
        {
            this.id = id;
            this.titulo = titulo;
            this.link = link;
            this.codigo = codigo;
            if (imagem == "" || imagem == null)
                this.imagem = "/images/banner.png";
            else
                this.imagem = imagem;
            this.titulo1 = titulo1;
            this.link_trailer = link_trailer;
            this.texto = texto;
            this.grupoead = grupoead;
        }
    }

    public class ProximasAulas
    {
        public int id { get; set; }
        public string curso { get; set; }
        public string cidade { get; set; }
        public string professor { get; set; }
        public string disciplina { get; set; }
        public DateTime data { get; set; }

        public ProximasAulas()
        {
            this.id = 0;
            this.curso = "";
            this.cidade = "";
            this.professor = "";
            this.disciplina = "";
            this.data = DateTime.Now;
        }

        public ProximasAulas(int id, string curso, string cidade, string professor, string disciplina, DateTime data)
        {
            this.id = id;
            this.curso = curso;
            this.cidade = cidade;
            this.professor = professor;
            this.disciplina = disciplina;
            this.data = data;
        }
    }

    public class Busca
    {
        public int tipo { get; set; }
        public int cidade { get; set; }
        public int curso { get; set; }
        public List<Valor> cidades { get; set; }
        public List<Turma> cursos { get; set; }

        public Busca()
        {
            this.tipo = 0;
            this.cidade = 0;
            this.curso = 0;
            this.cidades = new List<Valor>();
            this.cursos = new List<Turma>();
        }

        public Busca(int tipo, int cidade = 0, int curso = 0)
        {
            this.tipo = tipo;
            this.cidade = cidade;
            this.curso = curso;

            this.cidades = new CursoDB().Cidades(tipo, curso);
            if (tipo == 2)
            {
                this.cursos = new CursoDB().CursosHomeEad(tipo, cidade, curso);
            }
            else
            {
                this.cursos = new CursoDB().CursosHome(tipo, cidade, curso);
            }
        }
    }


}
