using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Campanhas_Agendamento
    {
        public int idcampanha { get; set; }
        public string tpagendamento { get; set; }
        public string dtenvio { get; set; }
        public int nrdiasciclico { get; set; }
        public string dtiniciociclico { get; set; }
        public int nrdiasprazo { get; set; }
        public int idcampanhaprazo { get; set; }

        public Campanhas_Agendamento()
        {
            this.idcampanha = 0;
            this.tpagendamento = "A";
            this.dtenvio = "";
            this.nrdiasciclico = 0;
            this.dtiniciociclico = ""; 
            this.nrdiasprazo = 0;
            this.idcampanhaprazo = 0;
        }


        public Campanhas_Agendamento(int id, string agendamento, string dataenvio, int diasciclico, string dataciclico, int diasprazo, int campanha)
        {
            this.idcampanha = id;
            this.tpagendamento = agendamento;
            this.dtenvio = dataenvio;
            this.nrdiasciclico = diasciclico;
            this.dtiniciociclico = dataciclico;
            this.nrdiasprazo = diasprazo;
            this.idcampanhaprazo = campanha;
        }

        public int Existe(int id)
        {
            return new Campanhas_AgendamentoDB().Existe(id);
        }

    }

}
