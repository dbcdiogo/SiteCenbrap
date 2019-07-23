using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Cartaz
    {
        public int cartaz_id { get; set; }
        public string cidade { get; set; }
        public DateTime data { get; set; }
        public string ip { get; set; }

        public Cartaz()
        {
            this.cartaz_id = 0;
            this.cidade = "";
            this.data = DateTime.Now;
            this.ip = "";
        }

        public Cartaz(int cartaz_id, string cidade, DateTime data, string ip)
        {
            this.cartaz_id = cartaz_id;
            this.cidade = cidade;
            this.data = data;
            this.ip = ip;
        }

        public void Salvar()
        {
            new CartazDB().Salvar(this);
        }
    }
}
