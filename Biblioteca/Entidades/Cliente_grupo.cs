using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cliente_grupo
    {
        public int codigo { get; set; }
        public string grupo { get; set; }
        public string cod_municipio { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public int negativado { get; set; }

        public Cliente_grupo()
        {
            this.codigo = 0;
            this.grupo = "";
            this.cod_municipio = "";
            this.cidade = "";
            this.estado = "";
            this.negativado = 0;
        }

        public Cliente_grupo(int codigo, string grupo, string cod_municipio, string cidade, string estado, int negativado)
        {
            this.codigo = codigo;
            this.grupo = grupo;
            this.cod_municipio = cod_municipio;
            this.cidade = cidade;
            this.estado = estado;
            this.negativado = negativado;
        }

        public void Salvar()
        {
            new Cliente_grupoDB().Salvar(this);
            this.codigo = new Cliente_grupoDB().Buscar(this.grupo).codigo;
        }
    }
}
