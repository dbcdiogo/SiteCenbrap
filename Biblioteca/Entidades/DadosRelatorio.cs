using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class DadosRelatorio
    {
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public int confirmado { get; set; }
        public int aberto { get; set; }
        public int desistente { get; set; }
        public int contrato { get; set; }
        public int nao_fara_o_curso { get; set; }

        public DadosRelatorio()
        {
            this.data = DateTime.Now;
            this.titulo = "";
            this.confirmado = 0;
            this.aberto = 0;
            this.desistente = 0;
            this.contrato = 0;
            this.nao_fara_o_curso = 0;
        }

        public DadosRelatorio(DateTime data, int confirmado, int aberto, int desistente, int contrato, int nao_fara_o_curso)
        {
            this.data = data;
            this.titulo = data.ToShortDateString();
            this.confirmado = confirmado;
            this.aberto = aberto;
            this.desistente = desistente;
            this.contrato = contrato;
            this.nao_fara_o_curso = nao_fara_o_curso;
        }

        public DadosRelatorio(string titulo, DateTime data, int confirmado = 0, int aberto = 0, int desistente = 0, int contrato = 0)
        {
            this.data = data;
            this.titulo = titulo;
            this.confirmado = confirmado;
            this.aberto = aberto;
            this.desistente = desistente;
            this.contrato = contrato;
        }
    }

    public class Datas
    {
        public string titulo { get; set; }
        public DateTime data { get; set; }

        public Datas()
        {
            this.titulo = "";
            this.data = DateTime.Now;
        }

        public Datas(string titulo, DateTime data)
        {
            this.titulo = titulo;
            this.data = data;
        }
    }

    public class Relatorio
    {
        public string curso { get; set; }
        public IEnumerable<DadosRelatorio> dados { get; set; }

        public Relatorio(string curso, IEnumerable<DadosRelatorio> dados)
        {
            this.curso = curso;
            this.dados = dados;
        }
    }
}
