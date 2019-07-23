using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Cliente_grupo_subgrupo
    {
        public int codigo { get; set; }
        public Cliente_grupo grupo { get; set; }
        public string subgrupo { get; set; }

        public Cliente_grupo_subgrupo()
        {
            this.codigo = 0;
            this.grupo = new Cliente_grupo() { codigo = 0 };
            this.subgrupo = "";
        }

        public Cliente_grupo_subgrupo(int codigo, Cliente_grupo grupo, string subgrupo)
        {
            this.codigo = codigo;
            this.grupo = grupo;
            this.subgrupo = subgrupo;
        }
    }
}
