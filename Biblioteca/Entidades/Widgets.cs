using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Widgets
    {
        public int idwidget { get; set; }
        public string txwidget { get; set; }
        public string txaplicativo { get; set; }
        public int nrheight { get; set; }
        public int nrwidth { get; set; }
        public int nrtop { get; set; }
        public int nrleft { get; set; }
        public string txclass { get; set; }
        public string txcor { get; set; }
        public int idgrupo { get; set; }
        public string txgrupo { get; set; }

        public Widgets()
        {
            this.idwidget = 0;
            this.txwidget = "";
            this.txaplicativo = "";
            this.nrheight = 0;
            this.nrwidth = 0;
            this.nrtop = 0;
            this.nrleft = 0;
            this.txclass = "";
            this.txcor = "#eeeeee";
            this.idgrupo = 0;
        }

        public Widgets(int idwidget, string txwidget, string txaplicativo, int nrheight, int nrwidth, int idgrupo)
        {
            this.idwidget = idwidget;
            this.txwidget = txwidget;
            this.txaplicativo = txaplicativo;
            this.nrheight = nrheight;
            this.nrwidth = nrwidth;
            this.idgrupo = idgrupo;
            this.txgrupo = new WidgetsDB().BuscarGrupo(idgrupo).txgrupo;
        }

        public Widgets(int idwidget, string txwidget, string txaplicativo, int nrheight, int nrwidth, int nrtop, int nrleft, string txclass, string txcor)
        {
            this.idwidget = idwidget;
            this.txwidget = txwidget;
            this.txaplicativo = txaplicativo;
            this.nrheight = nrheight;
            this.nrwidth = nrwidth;
            this.nrtop = nrtop;
            this.nrleft = nrleft;
            this.txclass = txclass;
            this.txcor = txcor;
        }

        public void Salvar()
        {
            new WidgetsDB().Salvar(this);
        }

        public void Alterar()
        {
            new WidgetsDB().Alterar(this);
        }

        public void Excluir()
        {
            new WidgetsDB().Excluir(this);
        }

    }

    public class WidgetsUsuario
    {
        public int idwidget { get; set; }
        public int idusuario { get; set; }
        public int nrheight { get; set; }
        public int nrwidth { get; set; }
        public int nrtop { get; set; }
        public int nrleft { get; set; }
        public string txclass { get; set; }
        public string txcor { get; set; }

        public WidgetsUsuario()
        {
            this.idwidget = 0;
            this.idusuario = 0;
            this.nrheight = 0;
            this.nrwidth = 0;
            this.nrtop = 0;
            this.nrleft = 0;
            this.txclass = "";
            this.txcor = "#eeeeee";
        }

        public WidgetsUsuario(int idwidget, int idusuario, int nrheight, int nrwidth, int nrtop, int nrleft, string txclass, string txcor)
        {
            this.idwidget = idwidget;
            this.idusuario = idusuario;
            this.nrheight = nrheight;
            this.nrwidth = nrwidth;
            this.nrtop = nrtop;
            this.nrleft = nrleft;
            this.txclass = txclass;
            this.txcor = txcor;
        }

        public void Salvar()
        {
            new WidgetsDB().SalvarWidgetUsuario(this);
        }

        public void Alterar()
        {
            new WidgetsDB().AlterarWidgetUsuario(this);
        }

        public void Excluir()
        {
            new WidgetsDB().ExcluirWidgetUsuario(this);
        }

    }

    public class WidgetsGrupos
    {
        public int idgrupo { get; set; }
        public string txgrupo { get; set; }

        public WidgetsGrupos()
        {
            this.idgrupo = 0;
            this.txgrupo = "";
        }

        public WidgetsGrupos(int idgrupo, string txgrupo)
        {
            this.idgrupo = idgrupo;
            this.txgrupo = txgrupo;
        }

    }
}
