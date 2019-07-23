using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Departamento
    {
        public int iddepartamento { get; set; }
        public string txdepartamento { get; set; }

        public Departamento()
        {
            this.iddepartamento = 0;
            this.txdepartamento = "";
        }

        public Departamento(int iddepartamento, string txdepartamento)
        {
            this.iddepartamento = iddepartamento;
            this.txdepartamento = txdepartamento;
        }

        public void Salvar()
        {
            new DepartamentosDB().Salvar(this);
        }

        public void Alterar()
        {
            new DepartamentosDB().Alterar(this);
        }

    }
}
