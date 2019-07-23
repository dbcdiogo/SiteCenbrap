using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class DataLote
    {
        public int dataLote_id { get; set; }
        public string dominio { get; set; }
        public string titulo { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public double valor { get; set; }

        public DataLote()
        {
            this.dataLote_id = 0;
            this.dominio = "";
            this.titulo = "";
            this.inicio = DateTime.Now;
            this.fim = DateTime.Now;
            this.valor = 0;
        }

        public DataLote(int id, string dominio, string titulo, DateTime inicio, DateTime fim , double valor)
        {
            this.dataLote_id = id;
            this.dominio = dominio;
            this.titulo = titulo;
            this.inicio = inicio;
            this.fim = fim;
            this.valor = valor;
        }

        public string Data()
        {
            string txt = "";

            if (inicio <= Convert.ToDateTime("01/01/1900"))
                txt = " até " + fim.Day.ToString("00") + "/" + fim.Month.ToString("00");

            if (inicio > Convert.ToDateTime("01/01/1900") && fim < Convert.ToDateTime("01/01/2100"))
                txt = inicio.Day.ToString("00") + "/" + inicio.Month.ToString("00") + " a " + fim.Day.ToString("00") + "/" + fim.Month.ToString("00");

            if(fim >= Convert.ToDateTime("01/01/2100"))
                txt = "Até o evento";

            return txt;
        }
    }
}
