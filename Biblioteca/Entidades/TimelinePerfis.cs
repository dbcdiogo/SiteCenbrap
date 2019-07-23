using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelinePerfis
    {
        public int idperfil { get; set; }
        public string txperfil { get; set; }
        public string menus { get; set; }
        public string widgets { get; set; }

        public TimelinePerfis()
        {
            this.idperfil = 0;
            this.txperfil = "";
            this.menus = "";
            this.widgets = "";
        }

        public TimelinePerfis(int idperfil, string txperfil, string menus, string widgets)
        {
            this.idperfil = idperfil;
            this.txperfil = txperfil;
            this.menus = menus;
            this.widgets = widgets;
        }


    }

}
