using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Enderecos
    {
        public int id { get; set; }
        public string cep { get; set; }
        public string uf  { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int ibge_cod_uf { get; set; }
        public int ibge_cod_cidade { get; set; }
        public string area_cidade_km2 { get; set; }
        public int ddd { get; set; }

        public Enderecos()
        {
            this.id = 0;
            this.cep = "";
            this.uf = "";
            this.cidade = "";
            this.bairro = "";
            this.logradouro = "";
            this.latitude = "";
            this.longitude = "";
            this.ibge_cod_uf = 0;
            this.ibge_cod_cidade = 0;
            this.area_cidade_km2 = "";
            this.ddd = 0;
        }

        public Enderecos(int id, string cep, string uf, string cidade, string bairro, string logradouro, string latitude, string longitude, int ibge_cod_uf, int ibge_cod_cidade, string area_cidade_km2, int ddd)
        {
            this.id = id;
            this.cep = cep;
            this.uf = uf;
            this.cidade = cidade;
            this.bairro = bairro;
            this.logradouro = logradouro;
            this.latitude = latitude;
            this.longitude = longitude;
            this.ibge_cod_uf = ibge_cod_uf;
            this.ibge_cod_cidade = ibge_cod_cidade;
            this.area_cidade_km2 = area_cidade_km2;
            this.ddd = ddd;
        }
    }
}
