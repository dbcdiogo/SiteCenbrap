using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class UrlRelatorio
    {
        public string aluno { get; set; }
        public string curso { get; set; }
        public DateTime data { get; set; }
        public string origem { get; set; }
        public DateTime impressaoBoleto { get; set; }
        public DateTime dataConfirmacao { get; set; }
        public string identificador { get; set; }
        public DateTime dataVencimento { get; set; }
        public int aluno_curso { get; set; }
        public int acoes { get; set; }
        public int status { get; set; }
        public int retorno { get; set; }
        public DateTime lista_espera { get; set; }
        public int curso_codigo { get; set; }
        public int destaques { get; set; }
        public DateTime inicio_confirmado { get; set; }
        public int cont { get; set; }

        public UrlRelatorio()
        {
            this.aluno = "";
            this.curso = "";
            this.data = DateTime.Now;
            this.origem = "";
            this.impressaoBoleto = Convert.ToDateTime("01/01/1900");
            this.dataConfirmacao = Convert.ToDateTime("01/01/1900");
            this.identificador = "";
            this.dataVencimento = Convert.ToDateTime("01/01/1900");
            this.aluno_curso = 0;
            this.acoes = 0;
            this.status = 2;
            this.retorno = 0;
            this.lista_espera = Convert.ToDateTime("01/01/1900");
            this.destaques = 0;
            this.inicio_confirmado = Convert.ToDateTime("01/01/1900");
            this.cont = 1;
        }

        public UrlRelatorio(string aluno, string curso, DateTime data, string origem, string identificador = "")
        {
            this.aluno = aluno;
            this.curso = curso;
            this.data = data;
            this.origem = origem;
            this.identificador = identificador;
        }

        public UrlRelatorio(string aluno, string curso, DateTime data)
        {
            this.aluno = aluno;
            this.curso = curso;
            this.data = data;
        }

        public UrlRelatorio(string aluno, string curso, DateTime data, string origem, DateTime impressaoBoleto, DateTime dataConfirmacao, DateTime inicio_confirmado, string identificador = "", int aluno_curso = 0, int acoes = 0, int status = 2, int retorno = 0, int destaques = 0, int cont = 1)
        {
            this.aluno = aluno;
            this.curso = curso;
            this.data = data;
            this.origem = origem;
            this.impressaoBoleto = impressaoBoleto;
            this.dataConfirmacao = dataConfirmacao;
            this.identificador = identificador;
            this.aluno_curso = aluno_curso;
            this.acoes = acoes;
            this.status = status;
            this.retorno = retorno;
            this.lista_espera = new CursoDB().BuscarDataListaEspera(curso);
            this.curso_codigo = new CursoDB().BuscarCodigo(curso);
            this.inicio_confirmado = inicio_confirmado;
            this.destaques = destaques;
            this.cont = cont;
            if (impressaoBoleto.Year != 1900)
            {
                DateTime datatemp = impressaoBoleto.AddDays(2);

                // Verifica final de semana
                if (datatemp.DayOfWeek.ToString() == "Saturday")
                {
                    datatemp = datatemp.AddDays(2);
                }
                if (datatemp.DayOfWeek.ToString() == "Sunday")
                {
                    datatemp = datatemp.AddDays(1);
                }

                // Verifica se é feriado
                if (new FeriadosDB().Validar(datatemp.Day, datatemp.Month))
                {
                    datatemp = datatemp.AddDays(1);
                }

                // Verifica novamente se é final de semana
                if (datatemp.DayOfWeek.ToString() == "Saturday")
                {
                    datatemp = datatemp.AddDays(2);
                }
                if (datatemp.DayOfWeek.ToString() == "Sunday")
                {
                    datatemp = datatemp.AddDays(1);
                }

                // 1 dia para compensação
                datatemp = datatemp.AddDays(1);

                this.dataVencimento = datatemp;
            }
            else
            {
                this.dataVencimento = Convert.ToDateTime("01/01/1900");
            }
        }
    
        public UrlRelatorio(string aluno, string curso, DateTime data, string origem, DateTime impressaoBoleto, DateTime dataConfirmacao, string identificador = "", int aluno_curso = 0, int acoes = 0, int status = 2, int retorno = 0)
        {
            this.aluno = aluno;
            this.curso = curso;
            this.data = data;
            this.origem = origem;
            this.impressaoBoleto = impressaoBoleto;
            this.dataConfirmacao = dataConfirmacao;
            this.identificador = identificador;
            this.aluno_curso = aluno_curso;
            this.acoes = acoes;
            this.status = status;
            this.retorno = retorno;
            this.lista_espera = new CursoDB().BuscarDataListaEspera(curso);
            this.curso_codigo = new CursoDB().BuscarCodigo(curso);
            if (impressaoBoleto.Year != 1900)
            {
                DateTime datatemp = impressaoBoleto.AddDays(2);
                
                // Verifica final de semana
                if (datatemp.DayOfWeek.ToString() == "Saturday") {
                    datatemp = datatemp.AddDays(2);
                }
                if (datatemp.DayOfWeek.ToString() == "Sunday")
                {
                    datatemp = datatemp.AddDays(1);
                }

                // Verifica se é feriado
                if (new FeriadosDB().Validar(datatemp.Day, datatemp.Month))
                {
                    datatemp = datatemp.AddDays(1);
                }

                // Verifica novamente se é final de semana
                if (datatemp.DayOfWeek.ToString() == "Saturday")
                {
                    datatemp = datatemp.AddDays(2);
                }
                if (datatemp.DayOfWeek.ToString() == "Sunday")
                {
                    datatemp = datatemp.AddDays(1);
                }

                // 1 dia para compensação
                datatemp = datatemp.AddDays(1);

                this.dataVencimento = datatemp;
            }
                else
            {
                this.dataVencimento = Convert.ToDateTime("01/01/1900");
            }
        }
    }

    public class UrlRelatorioGroup
    {
        public string origem { get; set; }
        public int qtd { get; set; }

        public UrlRelatorioGroup()
        {
            this.origem = "";
            this.qtd = 0;
        }

        public UrlRelatorioGroup(string origem, int qtd)
        {
            this.origem = origem;
            this.qtd = qtd;
        }
    }

    public class RelatorioUrl
    {
        public List<UrlRelatorio> relatorio { get; set; }
        public List<UrlRelatorioGroup> qtds { get; set; }
    }
}
