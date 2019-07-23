using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineEventosDestaque
    {
        public int idevento { get; set; }
        public int idusuario { get; set; }
        public int idcurso { get; set; }
        public DateTime dtinicio { get; set; }
        public DateTime dtfim { get; set; }
        public string txdestaque { get; set; }
        public string txremocao { get; set; }

        public TimelineEventosDestaque()
        {
            this.idevento = 0;
            this.idusuario = 0;
            this.idcurso = 0;
            this.dtinicio = Convert.ToDateTime("01/01/1900");
            this.dtfim = Convert.ToDateTime("01/01/1900");
            this.txdestaque = "";
            this.txremocao = "";
        }

        public TimelineEventosDestaque(int idevento, int idusuario, int idcurso, DateTime dtinicio, DateTime dtfim, string txdestaque, string txremocao)
        {
            this.idevento = idevento;
            this.idusuario = idusuario;
            this.idcurso = idcurso;
            this.dtinicio = dtinicio;
            this.dtfim = dtfim;
            this.txdestaque = txdestaque;
            this.txremocao = txremocao;
        }

        public void Salvar()
        {
            new TimelineEventosDestaqueDB().Salvar(this);
        }

        public void Alterar()
        {
            new TimelineEventosDestaqueDB().Alterar(this);
        }

    }   

}
