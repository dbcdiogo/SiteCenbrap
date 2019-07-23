using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Encontro
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public Curso curso { get; set; }
        public int modulo { get; set; }
        public int numero { get; set; }
        public int ativo { get; set; }
        public string titulo { get; set; }
        public DateTime data_encontro { get; set; }
        public DateTime data_encontro1 { get; set; }
        public DateTime data_encontro2 { get; set; }
        public string local { get; set; }
        public int disciplina { get; set; }
        public int disciplina1 { get; set; }
        public int disciplina2 { get; set; }
        public int disciplina3 { get; set; }
        public string obs { get; set; }
        public int situacao { get; set; }
        public int situacao1 { get; set; }
        public string obs1 { get; set; }
        public int enviado { get; set; }

        public string disciplina_titulo { get; set; }
        public string professor_nome { get; set; }
        public double nota { get; set; }
        public double frequencia { get; set; }
        public int visualizar { get; set; }

        public Encontro()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.curso = new Curso() { codigo = 0 };
            this.modulo = 0;
            this.numero = 0;
            this.ativo = 0;
            this.titulo = "";
            this.data_encontro = DateTime.Now;
            this.data_encontro1 = DateTime.Now;
            this.data_encontro2 = DateTime.Now;
            this.local = "";
            this.disciplina = 0;
            this.disciplina1 = 0;
            this.disciplina2 = 0;
            this.disciplina3 = 0;
            this.obs = "";
            this.situacao = 0;
            this.situacao1 = 0;
            this.obs1 = "";
            this.enviado = 0;

            this.disciplina_titulo = "";
            this.professor_nome = "";
            this.nota = 0;
            this.frequencia = 0;
            this.visualizar = 1;
        }

        public Encontro(int codigo, DateTime data, Painel painel, Curso curso, int modulo, int numero, int ativo, string titulo, DateTime data_encontro, DateTime data_encontro1, DateTime data_encontro2, string local, int disciplina, int disciplina1, int disciplina2, int disciplina3, string obs, int situacao, int situacao1, string obs1, int enviado, string disciplina_titulo = "", string professor_nome = "", double nota = 0, double frequencia = 0, int visualizar = 1)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.curso = curso;
            this.modulo = modulo;
            this.numero = numero;
            this.ativo = ativo;
            this.titulo = titulo;
            this.data_encontro = data_encontro;
            this.data_encontro1 = data_encontro1;
            this.data_encontro2 = data_encontro2;
            this.local = local;
            this.disciplina = disciplina;
            this.disciplina1 = disciplina1;
            this.disciplina2 = disciplina2;
            this.disciplina3 = disciplina3;
            this.obs = obs;
            this.situacao = situacao;
            this.situacao1 = situacao1;
            this.obs1 = obs1;
            this.enviado = enviado;

            this.disciplina_titulo = disciplina_titulo;
            this.professor_nome = professor_nome;
            this.nota = nota;
            this.frequencia = frequencia;
            this.visualizar = visualizar;
        }

        public string Data()
        {
            string data = "";

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia1 = this.data_encontro1.Day;
            int dia2 = this.data_encontro2.Day;
            int ano = this.data_encontro1.Year;
            string mes1 = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(this.data_encontro1.Month));
            string mes2 = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(this.data_encontro2.Month));

            if (this.data_encontro1.Month == this.data_encontro2.Month)
            {
                data = dia1 + " e " + dia2 + " de " + mes1 + " de " + ano;
            }
            else
            {
                data = dia1 + " de " + mes1 + " e " + dia2 + " de " + mes2 + " de " + ano;
            }

            return data;
        }
    }

    public class EncontroEmail
    {
        public string turma { get; set; }
        public DateTime data { get; set; }
        public string obs { get; set; }
        public string titulo { get; set; }
        public string professor { get; set; }
        public int gabarito { get; set; }

        public EncontroEmail(string turma, DateTime data, string obs, string titulo, string professor, int gabarito)
        {
            this.turma = turma;
            this.data = data;
            this.obs = obs;
            this.titulo = titulo;
            this.professor = professor;
            this.gabarito = gabarito;
        }
    }
}
