using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class BoletoEcommerce_view
    {
        public int idConv { get; set; } = 0;
        public string refTran { get; set; } = "";
        public int valor { get; set; } = 0;
        public string dtVenc { get; set; } = "";
        public int tpPagamento { get; set; } = 2;
        public string cpfCnpj { get; set; } = "";
        public int indicadorPessoa { get; set; } = 1;
        public string tpDuplicata { get; set; } = "DM";
        public string urlRetorno { get; set; } = "http://www.cenbrap.com.br/";
        public string urlInforma { get; set; } = "http://www.cenbrap.com.br/";
        public string nome { get; set; } = "";
        public string endereco { get; set; } = "";
        public string cidade { get; set; } = "";
        public string uf { get; set; } = "";
        public string cep { get; set; } = "";
        public string msgLoja { get; set; } = "";
    }
}
