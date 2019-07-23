using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Abriu
    {
        public int idabriu { get; set; }
        public Enviado idenviado { get; set; }
        public DateTime dtabriu { get; set; }

        public Abriu()
        {
            this.idabriu = 0;
            this.idenviado = new Enviado();
            this.dtabriu = Convert.ToDateTime("01/01/1900");
        }

        public Abriu(int id)
        {
            this.idenviado = new Enviado() { idenviado = id };
            this.dtabriu = DateTime.Now;

            new AbriuDB().Salvar(this);
        }

        public Abriu(int id, Enviado enviado, DateTime data)
        {
            this.idabriu = id;
            this.idenviado = enviado;
            this.dtabriu = data;
        }
    }
}
