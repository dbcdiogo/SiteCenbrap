using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Clicou
    {
        public int idclicou { get; set; }
        public Enviado idenviado { get; set; }
        public DateTime dtclicou { get; set; }
        public int cont { get; set; }

        public Clicou()
        {
            this.idclicou = 0;
            this.idenviado = new Enviado();
            this.dtclicou = Convert.ToDateTime("01/01/1900");
            this.cont = 0;
        }

        public Clicou(int id, int cont)
        {
            this.idenviado = new Enviado() { idenviado = id };
            this.dtclicou = DateTime.Now;
            this.cont = cont;

            new ClicouDB().Salvar(this);
        }

        public Clicou(int id, Enviado enviado, DateTime data, int cont)
        {
            this.idclicou = id;
            this.idenviado = enviado;
            this.dtclicou = data;
            this.cont = cont;
        }
    }
}
