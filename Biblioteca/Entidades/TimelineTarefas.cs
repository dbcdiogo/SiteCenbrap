using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineTarefas
    {
        public int idcurso { get; set; }
        public int idevento { get; set; }
        public string txtitulo { get; set; }
        public string txtexto { get; set; }
        public DateTime dtevento { get; set; }
        public string fltipo { get; set; }
        public int idusuario { get; set; }
        public DateTime dttarefa { get; set; }
        public DateTime dtdeadline { get; set; }
        public DateTime dteventoini { get; set; }
        public DateTime dteventofim { get; set; }

        public TimelineTarefas()
        {
            this.idcurso = 0;
            this.idevento = 0;
            this.txtitulo = "";
            this.txtexto = "";
            this.dtevento = Convert.ToDateTime("01/01/1900");
            this.fltipo = "";
            this.idusuario = 0;
            this.dttarefa = Convert.ToDateTime("01/01/1900");
            this.dtdeadline = Convert.ToDateTime("01/01/1900");
            this.dteventoini = Convert.ToDateTime("01/01/1900");
            this.dteventofim = Convert.ToDateTime("01/01/1900");
    }

        public TimelineTarefas(int idcurso, int idevento, string txtitulo, string txtexto, DateTime dtevento, string fltipo, int idusuario, DateTime dttarefa, DateTime dtdeadline, DateTime dteventoini, DateTime dteventofim)
        {
            this.idcurso = idcurso;
            this.idevento = idevento;
            this.txtitulo = txtitulo;
            this.txtexto = txtexto;
            this.dtevento = dtevento;
            this.fltipo = fltipo;
            this.idusuario = idusuario;
            this.dttarefa = dttarefa;
            this.dtdeadline = dtdeadline;
            this.dteventoini = dteventoini;
            this.dteventofim = dteventofim;
        }

        public int Salvar()
        {
            return new TimelineTarefasDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new TimelineTarefasDB().Alterar(this);
        }
    }

    public class TimelineTarefasUsuarios
    {
        public int idevento { get; set; }
        public int idusuario { get; set; }

        public TimelineTarefasUsuarios()
        {
            this.idevento = 0;
            this.idusuario = 0;
        }

        public TimelineTarefasUsuarios(int idevento, int idusuario)
        {
            this.idevento = idevento;
            this.idusuario = idusuario;
        }
    }

    public class TimelineTarefasItens
    {
        public int idevento { get; set; }
        public int iditem { get; set; }
        public string txitem { get; set; }
        public string txobs { get; set; }
        public int fldashboard { get; set; }
        public List<TimelineTarefasUsuarioAcao> acao_usuario { get; set; }
        public TimelineTarefasUsuarioAcao acao { get; set; }

        public TimelineTarefasItens()
        {
            this.idevento = 0;
            this.iditem = 0;
            this.txitem = "";
            this.txobs = "";
            this.acao_usuario = null;
            this.acao = null;
            this.fldashboard = 0;
        }

        public TimelineTarefasItens(int idevento, int iditem, string txitem, int fldashboard)
        {
            this.idevento = idevento;
            this.iditem = iditem;
            this.txitem = txitem;
            this.fldashboard = fldashboard;
            this.acao_usuario = new TimelineEventosDB().AcoesUsuarios(idevento, iditem);
        }

        public TimelineTarefasItens(int idevento, int iditem, string txitem, int idusuario, int fldashboard)
        {
            this.idevento = idevento;
            this.iditem = iditem;
            this.txitem = txitem;
            this.fldashboard = fldashboard;
            this.acao = new TimelineEventosDB().AcaoUsuario(idevento, iditem, idusuario);
        }

        public void Salvar()
        {
            new TimelineTarefasDB().SalvarItem(this);
        }

        public void Alterar()
        {
            new TimelineTarefasDB().AlterarItem(this);
        }
    }

    public class TimelineTarefasUsuarioAcao
    {
        public string txnome { get; set; }
        public string txfoto { get; set; }
        public DateTime dtacao { get; set; }
        public string txobs { get; set; }

        public TimelineTarefasUsuarioAcao()
        {
            this.txnome = "";
            this.txfoto = "";
            this.dtacao = Convert.ToDateTime("01/01/1900");
            this.txobs = "";
        }

        public TimelineTarefasUsuarioAcao(string txnome, string txfoto, DateTime dtacao, string txobs)
        {
            this.txnome = txnome;
            this.txfoto = txfoto;
            this.dtacao = dtacao;
            this.txobs = txobs;
        }
    }

}
