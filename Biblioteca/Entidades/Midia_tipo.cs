using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia_tipo
    {
        public int midia_tipo_id { get; set; }
        public string titulo { get; set; }
        public bool email { get; set; }
        public bool sms { get; set; }
        public bool facebook { get; set; }

        public Midia_tipo()
        {
            this.midia_tipo_id = 0;
            this.titulo = "";
            this.email = false;
            this.sms = false;
            this.facebook = false;
        }

        public Midia_tipo(int id, string titulo, bool email = false, bool sms = false, bool facebook = false)
        {
            this.midia_tipo_id = id;
            this.titulo = titulo;
            this.email = email;
            this.sms = sms;
            this.facebook = facebook;
        }

        public void Salvar()
        {
            new Midia_tipoDB().Salvar(this);
        }

        public void Alterar()
        {
            new Midia_tipoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Midia_tipoDB().Excluir(this);
        }
    }
}
