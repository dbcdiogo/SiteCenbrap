using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia_cidade
    {
        public Midia midia_id { get; set; }
        public Cidade cidade { get; set; }

        public Midia_cidade()
        {
            this.midia_id = new Midia();
            this.cidade = new Cidade();
        }

        public Midia_cidade(Midia midia, Cidade cidade)
        {
            this.midia_id = midia;
            this.cidade = cidade;
        }

        public void Salvar()
        {
            new Midia_cidadeDB().Salvar(this);
        }

        public void Excluir()
        {
            new Midia_cidadeDB().Excluir(this);
        }

    }
}
