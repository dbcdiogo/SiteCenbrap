using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Cron_nfe
    {
        public int cron_nfe_id { get; set; }
        public Entrada entrada { get; set; }
        public DateTime data { get; set; }
        public int situacao { get; set; } //0 - aguardando execução    1 - concluido     2 - erro
        public string texto { get; set; }
        public string xml { get; set; }

        public Cron_nfe()
        {
            this.cron_nfe_id = 0;
            this.entrada = new Entrada();
            this.data = DateTime.Now;
            this.situacao = 0;
            this.texto = "";
            this.xml = "";
        }

        public Cron_nfe(int id, Entrada entrada, DateTime data, int situacao, string texto, string xml)
        {
            this.cron_nfe_id = id;
            this.entrada = entrada;
            this.data = data;
            this.situacao = situacao;
            this.texto = texto;
            this.xml = xml;
        }
    }
}
