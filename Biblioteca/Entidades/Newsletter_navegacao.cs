using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Newsletter_navegacao
    {
        public Newsletter newsletter { get; set; }
        public string _ga { get; set; }
        public DateTime data { get; set; }

        public Newsletter_navegacao()
        {
            this.newsletter = new Newsletter();
            this._ga = "";
            this.data = DateTime.Now;
        }

        public Newsletter_navegacao(int codigo, string _ga)
        {
            this.newsletter = new Newsletter(codigo);
            this._ga = _ga;
            this.data = DateTime.Now;
        }

        public Newsletter_navegacao(Newsletter newsletter, string _ga, DateTime data)
        {
            this.newsletter = newsletter;
            this._ga = _ga;
            this.data = data;
        }

        public void Salvar()
        {
            new Newsletter_navegacaoDB().Salvar(this);
        }
        
    }
}
