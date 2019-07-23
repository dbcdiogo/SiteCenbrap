using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Timeline_Emails_Tipos
    {
        public int idemailtipo { get; set; }
        public int idtipo { get; set; }
        public string txtitulo { get; set; }
        public string txtipo { get; set; }
        public int idmensagem { get; set; }

        public Timeline_Emails_Tipos()
        {
            this.idemailtipo = 0;
            this.idtipo = 0;
            this.txtitulo = "";
            this.txtipo = "";
            this.idmensagem = 0;
        }

        public Timeline_Emails_Tipos(int idemailtipo, int idtipo, string txtitulo, string txtipo, int idmensagem)
        {
            this.idemailtipo = idemailtipo;
            this.idtipo = idtipo;
            this.txtitulo = txtitulo;
            this.txtipo = txtipo;
            this.idmensagem = idmensagem;
        }
    }

    public class Timeline_Emails_Sistema
    {
        public int idemailtipo { get; set; }
        public int idmensagem { get; set; }

        public Timeline_Emails_Sistema()
        {
            this.idemailtipo = 0;
            this.idmensagem = 0;
        }

        public Timeline_Emails_Sistema(int idemailtipo, int idmensagem)
        {
            this.idemailtipo = idemailtipo;
            this.idmensagem = idmensagem;
        }


    }
}
