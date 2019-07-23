using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Autor
    {
        public int autor_id { get; set; }
        public string nome { get; set; }

        public Autor()
        {
            this.autor_id = 0;
            this.nome = "";
        }

        public Autor(int id)
        {
            this.autor_id = id;
            this.nome = "";
        }

        public Autor(int id, string nome)
        {
            this.autor_id = id;
            this.nome = nome;
        }

        public void Salvar()
        {
            this.autor_id = new AutorDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new AutorDB().Alterar(this);
        }

        public void Excluir()
        {
            new AutorDB().Excluir(this);
        }
    }
}
