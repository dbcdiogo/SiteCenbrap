using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Categoria
    {
        public int categoria_id { get; set; }
        public string titulo { get; set; }

        public Categoria()
        {
            this.categoria_id = 0;
            this.titulo = "";
        }

        public Categoria(int id)
        {
            this.categoria_id = id;
            this.titulo = "";
        }

        public Categoria(int id, string titulo)
        {
            this.categoria_id = id;
            this.titulo = titulo;
        }

        public void Salvar()
        {
            this.categoria_id = new CategoriaDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new CategoriaDB().Alterar(this);
        }

        public void Excluir()
        {
            new CategoriaDB().Excluir(this);
        }
    }
}
