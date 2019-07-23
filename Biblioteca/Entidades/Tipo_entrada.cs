using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Tipo_entrada
    {
        public int codigo { get; set; }
        public string tipo { get; set; }

        public Tipo_entrada()
        {
            this.codigo = 0;
            this.tipo = "";
        }

        public Tipo_entrada(int codigo, string tipo)
        {
            this.codigo = codigo;
            this.tipo = tipo;
        }
        
        public void Salvar()
        {
            new Tipo_entradaDB().Salvar(this);
        }

        public void Alterar()
        {
            new Tipo_entradaDB().Alterar(this);
        }

        public void Excluir()
        {
            new Tipo_entradaDB().Excluir(this);
        }
    }
}
