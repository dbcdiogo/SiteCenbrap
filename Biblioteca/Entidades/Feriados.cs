using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Feriados
    {
        public int idferiado { get; set; }
        public string txferiado { get; set; }
        public int dia { get; set; }
        public int mes { get; set; }
        public Nullable<int> ano { get; set; }
        public Nullable<int> idcidade { get; set; }
        public Nullable<int> idestado { get; set; }

        public Feriados()
        {
            this.idferiado = 0;
            this.txferiado = "";
            this.dia = 0;
            this.mes = 0;
            this.ano = null;
            this.idcidade = null;
            this.idestado = null;
        }

        public Feriados(int idferiado, string txferiado, int dia, int mes, Nullable<int> ano, Nullable<int> idcidade, Nullable<int> idestado)
        {
            this.idferiado = idferiado;
            this.txferiado = txferiado;
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.idcidade = idcidade;
            this.idestado = idestado;
        }
    }
}
