using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Campanhas_Cidades
    {
        public int idcampanha { get; set; }
        public string txestado { get; set; }
        public string txcidade { get; set; }

        public Campanhas_Cidades()
        {
            this.idcampanha = 0;
            this.txestado = "";
            this.txcidade = "";
        }

        public Campanhas_Cidades(int id, string estado, string cidade)
        {
            this.idcampanha = id;
            this.txestado = estado;
            this.txcidade = cidade;
        }

        public int Existe(int id)
        {
            return new Campanhas_CidadesDB().Existe(id);
        }

        public void ExcluirCidades(int id)
        {
            new Campanhas_CidadesDB().ExcluirCidades(id);
        }
    }

    public class Campanhas_Cidades_Estados
    {
        public int idcampanha { get; set; }
        public string estados { get; set; }
        public string cidades { get; set; }

        public Campanhas_Cidades_Estados(int idcampanha, string estado)
        {
            this.idcampanha = idcampanha;
            this.estados = estado;
            this.cidades = new Campanhas_CidadesDB().BuscarCidades(idcampanha, estado);
        }
    }

}
