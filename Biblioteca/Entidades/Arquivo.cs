using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Arquivo
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public Curso curso { get; set; }
        public int modulo { get; set; }
        public Disciplina disciplina { get; set; }
        public Professor professor { get; set; }
        public string arquivo { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string obs { get; set; }
        public string link { get; set; }

        public Arquivo()
        {
            this.codigo = 0;
            this.data = Convert.ToDateTime("01/01/1900");
            this.painel = new Painel();
            this.curso = new Curso();
            this.modulo = 0;
            this.disciplina = new Disciplina();
            this.professor = new Professor();
            this.arquivo = "";
            this.titulo = "";
            this.texto = "";
            this.obs = "";
            this.link = "";
        }

        public Arquivo(int codigo, DateTime data, Painel painel, Curso curso, int modulo, Disciplina disciplina, Professor professor, string arquivo, string titulo, string texto, string obs, string link)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.curso = curso;
            this.modulo = modulo;
            this.disciplina = disciplina;
            this.professor = professor;
            this.arquivo = arquivo;
            this.titulo = titulo;
            this.texto = texto;
            this.obs = obs;
            this.link = link;
        }

        public void Salvar()
        {
            new ArquivoDB().Salvar(this);
        }

        public void Alterar()
        {
            new ArquivoDB().Alterar(this);
        }

        public void Excluir()
        {
            new ArquivoDB().Excluir(this);
        }
    }

    public class ArquivoVisualizar
    {
        public string codigo { get; set; }
        public int disciplina_professor { get; set; }
        public int visualizacao { get; set; }
        public int modulo { get; set; }
        public int encontro { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string disciplina_titulo { get; set; }
        public string professor { get; set; }
        public DateTime data { get; set; }
        public DateTime data_arquivo { get; set; }
        public DateTime data_encontro { get; set; }
        public DateTime data_encontro1 { get; set; }

        public ArquivoVisualizar()
        {
            this.codigo = "";
            this.disciplina_professor = 0;
            this.visualizacao = 0;
            this.modulo = 0;
            this.encontro = 0;
            this.titulo = "";
            this.texto = "";
            this.disciplina_titulo = "";
            this.professor = "";
            this.data = Convert.ToDateTime("01/01/1900");
            this.data_arquivo = Convert.ToDateTime("01/01/1900");
            this.data_encontro = Convert.ToDateTime("01/01/1900");
            this.data_encontro1 = Convert.ToDateTime("01/01/1900");
        }

        public ArquivoVisualizar(string codigo, int disciplina_professor, int visualizacao, int modulo, string titulo, string texto, string disciplina_titulo, string professor, DateTime data, DateTime data_arquivo, DateTime data_encontro, DateTime data_encontro1)
        {
            this.codigo = codigo;
            this.disciplina_professor = disciplina_professor;
            this.visualizacao = visualizacao;
            this.modulo = modulo;
            this.encontro = encontro;
            this.titulo = titulo;
            this.texto = texto;
            this.disciplina_titulo = disciplina_titulo;
            this.professor = professor;
            this.data = data;
            this.data_arquivo = data_arquivo;
            this.data_encontro = data_encontro;
            this.data_encontro1 = data_encontro1;
        }

        public string Texto()
        {
            if (this.texto.IndexOf("#data_recente#") > -1)
                this.texto = this.texto.Replace("#data_recente#", this.data.Day + " de " + new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(this.data.Month)) + " de " + this.data.Year);
                        
            if (this.texto.IndexOf("#data_encontro#") > -1)
            {

                int dia = this.data_encontro.Day;
                int dia1 = this.data_encontro1.Day;
                int ano = this.data_encontro.Year;
                string mes = new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(this.data_encontro.Month));
                string data = dia + " de " + mes + " de " + ano;

                if(this.data_encontro1.Day == 1)
                {
                    this.texto = this.texto.Replace("#data_encontro#", this.data_encontro.Day + " de " + new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(this.data_encontro.Month)) + " e " + this.data_encontro1.Day + " de " + new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(this.data_encontro1.Month)) + " de " + this.data_encontro.Year);
                }
                else
                {
                    this.texto = this.texto.Replace("#data_encontro#", this.data_encontro.Day + " e " + this.data_encontro1.Day + " de " + new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(this.data_encontro.Month)) + " de " + this.data_encontro.Year);
                }
            }
            return this.texto;
        }
    }

}
