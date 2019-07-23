using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Certificadora
    {
        public int certificadora_id { get; set; }
        public string titulo { get; set; }
        public string titulo_abreviado { get; set; }

        public Certificadora()
        {
            this.certificadora_id = 0;
            this.titulo = "";
            this.titulo_abreviado = "";
        }

        public Certificadora(int id)
        {
            this.certificadora_id = id;
            this.titulo = "";
            this.titulo_abreviado = "";
        }

        public Certificadora(int id, string titulo, string titulo_abreviado)
        {
            this.certificadora_id = id;
            this.titulo = titulo;
            this.titulo_abreviado = titulo_abreviado;
        }
    }

}
