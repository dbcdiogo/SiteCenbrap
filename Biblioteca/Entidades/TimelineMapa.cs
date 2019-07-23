using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class TimelineMapa
    {
        public int tipo { get; set; }
        public string nome { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public TimelineMapa()
        {
            this.tipo = 0;
            this.nome = "";
            this.cep = "";
            this.cidade = "";
            this.estado = "";
            this.latitude = "";
            this.longitude = "";
        }

        public TimelineMapa(int tipo, string nome, string cep, string cidade, string estado, string latitude, string longitude)
        {
            this.tipo = tipo;
            this.nome = nome;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
