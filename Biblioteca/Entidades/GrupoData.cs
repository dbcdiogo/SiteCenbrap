using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class GrupoData
    {
        public int grupoData_id { get; set; }
        public int grupo { get; set; }
        public DateTime data1 { get; set; }
        public DateTime data2 { get; set; }

        public GrupoData()
        {
            this.grupoData_id = 0;
            this.grupo = 1;
            this.data1 = DateTime.Now;
            this.data2 = DateTime.Now.AddDays(1);
        }

        public GrupoData(int id, int grupo, DateTime data1, DateTime data2)
        {
            this.grupoData_id = id;
            this.grupo = grupo;
            this.data1 = data1;
            this.data2 = data2;
        }

        public string Data()
        {
            string data = "";

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia1 = this.data1.Day;
            int dia2 = this.data2.Day;
            int ano = this.data1.Year;
            string mes1 = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(this.data1.Month));
            string mes2 = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(this.data2.Month));

            if(this.data1.Month == this.data2.Month)
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
}
